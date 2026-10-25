using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CinemaCtes
{
    public partial class FormFunciones : Form
    {
        public FormFunciones()
        {
            InitializeComponent();

            // Forzamos por código la asociación del botón de anulación masiva
            BAnularRango.Click -= BAnularMasivo_Click;
            BAnularRango.Click += BAnularMasivo_Click;
        }

        private string placeholderTexto = "Buscar Función...";

        private void FormFunciones_Load(object sender, EventArgs e)
        {
            ClassEstilosHelper.ConfigurarPlaceholder(TBuscar, placeholderTexto);
            ClassEstilosHelper.AplicarEstiloTabla(DGVFunciones);
            ClassEstilosHelper.AgregarBotonesAccion2(DGVFunciones);

            // Suscribimos el evento de formateo para cambiar el texto del botón dinámicamente
            DGVFunciones.CellFormatting += DGVFunciones_CellFormatting;

            CargarCombosFiltros();
            CargarTablaFunciones();
        }

        // 🚀 Evento para cambiar el texto del botón dinámicamente según el estado de la función
        private void DGVFunciones_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Verificamos si estamos en la columna del botón de acción (asumiendo que es una columna de tipo botón)
            // Ajustá "CEliminar" o el índice de la columna de tu botón si es necesario
            if (DGVFunciones.Columns[e.ColumnIndex].Name == "CEliminar" && e.RowIndex >= 0)
            {
                DataGridViewRow row = DGVFunciones.Rows[e.RowIndex];
                if (row.Cells[5].Value != null)
                {
                    string estado = row.Cells[5].Value.ToString().Trim();

                    // Si está Inactivo, el botón debe ofrecer "Activar", de lo contrario "Desactivar"
                    if (estado.Equals("Inactivo", StringComparison.OrdinalIgnoreCase))
                    {
                        e.Value = "Activar";
                    }
                    else
                    {
                        e.Value = "Desactivar";
                    }
                    e.FormattingApplied = true;
                }
            }
        }

        // Método para cargar los ComboBox de filtros superiores desde la BD
        private void CargarCombosFiltros()
        {
            ClassEstilosHelper.CargarComboEstados(CBEstado);

            CBSala.Items.Clear();
            CBSala.Items.Add("Todas");

            ConexionBD conexionBD = new ConexionBD();
            try
            {
                using (SqlConnection conexion = conexionBD.ObtenerConexión())
                {
                    using (SqlCommand comando = new SqlCommand("SP_ListarSalas", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader lector = comando.ExecuteReader())
                        {
                            while (lector.Read())
                            {
                                CBSala.Items.Add(lector["nro_sala"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar salas para el filtro: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (CBSala.Items.Count > 0)
                CBSala.SelectedIndex = 0;
        }

        // Método para cargar datos desde SQL Server en el DataGridView
        private void CargarTablaFunciones()
        {
            DGVFunciones.Rows.Clear();
            ConexionBD conexionBD = new ConexionBD();

            try
            {
                using (SqlConnection conexion = conexionBD.ObtenerConexión())
                {
                    using (SqlCommand comando = new SqlCommand("SP_ListarFunciones", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader lector = comando.ExecuteReader())
                        {
                            while (lector.Read())
                            {
                                int n = DGVFunciones.Rows.Add();

                                DateTime fecha = Convert.ToDateTime(lector["fecha"]);
                                DGVFunciones.Rows[n].Cells[0].Value = fecha.ToShortDateString();
                                DGVFunciones.Rows[n].Cells[1].Value = lector["pelicula"];
                                DGVFunciones.Rows[n].Cells[2].Value = lector["hora_inicio"];
                                DGVFunciones.Rows[n].Cells[3].Value = lector["hora_fin"];
                                DGVFunciones.Rows[n].Cells[4].Value = lector["nro_sala"];
                                DGVFunciones.Rows[n].Cells[5].Value = lector["estado"];
                                DGVFunciones.Rows[n].Cells[6].Value = lector["id_funcion"]; // ID Oculto
                            }
                        }
                    }
                }
                AplicarFiltros();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las funciones: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BAnadirFuncion_Click(object sender, EventArgs e)
        {
            using (FormRegistroFuncion formRegistro = new FormRegistroFuncion())
            {
                DialogResult resultado = formRegistro.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    int idPelicula = formRegistro.IdPeliculaSeleccionada;
                    int nroSala = formRegistro.NroSalaSeleccionada;
                    string horariosCsv = formRegistro.HorariosSeleccionadosCsv;
                    DateTime fechaInicioSemana = formRegistro.FechaInicioSeleccionada;

                    ConexionBD conexionBD = new ConexionBD();
                    try
                    {
                        int resultadoGeneracion = 0;

                        using (SqlConnection conexion = conexionBD.ObtenerConexión())
                        {
                            using (SqlCommand comando = new SqlCommand("SP_GenerarFuncionesMasivas", conexion))
                            {
                                comando.CommandType = CommandType.StoredProcedure;
                                comando.Parameters.AddWithValue("@IdPelicula", idPelicula);
                                comando.Parameters.AddWithValue("@NroSala", nroSala);
                                comando.Parameters.AddWithValue("@HorariosCsv", horariosCsv);
                                comando.Parameters.AddWithValue("@FechaInicio", fechaInicioSemana);

                                SqlParameter paramResultado = new SqlParameter("@Resultado", SqlDbType.Int);
                                paramResultado.Direction = ParameterDirection.Output;
                                comando.Parameters.Add(paramResultado);

                                comando.ExecuteNonQuery();
                                resultadoGeneracion = Convert.ToInt32(paramResultado.Value);
                            }
                        }

                        if (resultadoGeneracion == 0)
                        {
                            MessageBox.Show("No se pudieron generar las funciones. Verifique que no existan solapamientos de horarios en la sala para ese período.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            CargarTablaFunciones();
                            MessageBox.Show("Programación semanal generada con éxito para los 7 días.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al generar las funciones: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void DGVFunciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && !DGVFunciones.Rows[e.RowIndex].IsNewRow)
            {
                string nombreColumna = DGVFunciones.Columns[e.ColumnIndex].Name;
                int idFuncion = Convert.ToInt32(DGVFunciones.Rows[e.RowIndex].Cells[6].Value);
                string peliculaActual = DGVFunciones.Rows[e.RowIndex].Cells[1].Value?.ToString() ?? "";

                if (nombreColumna == "CEliminar")
                {
                    ConexionBD conexionBD = new ConexionBD();
                    try
                    {
                        using (SqlConnection conexion = conexionBD.ObtenerConexión())
                        {
                            using (SqlCommand comando = new SqlCommand("SP_CambiarEstadoFuncion", conexion))
                            {
                                comando.CommandType = CommandType.StoredProcedure;
                                comando.Parameters.AddWithValue("@IdFuncion", idFuncion);
                                comando.ExecuteNonQuery();
                            }
                        }

                        CargarTablaFunciones();
                        MessageBox.Show($"El estado de la función de '{peliculaActual}' fue actualizado correctamente.", "Estado Actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al cambiar el estado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void AplicarFiltros()
        {
            string textoBusqueda = TBuscar?.Text.Trim().ToLower() ?? "";
            if (textoBusqueda == placeholderTexto.ToLower()) textoBusqueda = "";

            string salaFiltro = CBSala?.SelectedItem?.ToString() ?? "Todas";
            string estadoFiltro = CBEstado?.SelectedItem?.ToString() ?? "Todos";

            DateTime fechaDesde = DTPDesde.Value.Date;
            DateTime fechaHasta = DTPHasta.Value.Date;

            foreach (DataGridViewRow row in DGVFunciones.Rows)
            {
                if (row.IsNewRow) continue;

                string fechaCeldaStr = row.Cells[0].Value?.ToString() ?? "";
                string pelicula = row.Cells[1].Value?.ToString().ToLower() ?? "";
                string sala = row.Cells[4].Value?.ToString().Trim() ?? "";
                string estado = row.Cells[5].Value?.ToString().Trim() ?? "";

                bool cumpleFechaRango = true;
                if (DateTime.TryParse(fechaCeldaStr, out DateTime fechaFila))
                {
                    cumpleFechaRango = (fechaFila.Date >= fechaDesde && fechaFila.Date <= fechaHasta);
                }

                bool cumpleTexto = string.IsNullOrEmpty(textoBusqueda) || pelicula.Contains(textoBusqueda);
                bool cumpleSala = salaFiltro.Equals("Todas", StringComparison.OrdinalIgnoreCase) || sala.Equals(salaFiltro, StringComparison.OrdinalIgnoreCase);
                bool cumpleEstado = estadoFiltro.Equals("Todos", StringComparison.OrdinalIgnoreCase) || estado.Equals(estadoFiltro, StringComparison.OrdinalIgnoreCase);

                row.Visible = cumpleFechaRango && cumpleTexto && cumpleSala && cumpleEstado;
            }
        }

        private void DTPDesde_ValueChanged(object sender, EventArgs e)
        {
            ValidarRangoFechas();
            AplicarFiltros();
        }

        private void DTPHasta_ValueChanged(object sender, EventArgs e)
        {
            ValidarRangoFechas();
            AplicarFiltros();
        }

        private void TBuscar_TextChanged(object sender, EventArgs e) => AplicarFiltros();
        private void CBSalaFiltro_SelectedIndexChanged(object sender, EventArgs e) => AplicarFiltros();
        private void CBEstadoFiltro_SelectedIndexChanged(object sender, EventArgs e) => AplicarFiltros();
        private void DTPFecha_ValueChanged(object sender, EventArgs e) => AplicarFiltros();

        private bool ValidarRangoFechas()
        {
            DateTime desde = DTPDesde.Value.Date;
            DateTime hasta = DTPHasta.Value.Date;

            if (desde > hasta)
            {
                MessageBox.Show(
                    "La fecha 'Desde' no puede ser posterior a la fecha 'Hasta'. Por favor, corrija el rango seleccionado.",
                    "Rango de fechas inválido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                DTPHasta.Value = desde;
                return false;
            }

            return true;
        }

        private void BAnularMasivo_Click(object sender, EventArgs e)
        {
            if (DTPDesde.Value.Date > DTPHasta.Value.Date)
            {
                MessageBox.Show("La fecha 'Desde' no puede ser posterior a la fecha 'Hasta'.", "Rango inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(CBSala.Text.Trim(), out int nroSala))
            {
                MessageBox.Show("Por favor, ingrese un número de sala válido.", "Sala requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime fechaDesde = DTPDesde.Value.Date;
            DateTime fechaHasta = DTPHasta.Value.Date;

            List<string> peliculasUnicas = new List<string>();

            foreach (DataGridViewRow row in DGVFunciones.Rows)
            {
                if (row.IsNewRow) continue;

                string nombrePeli = row.Cells["CPelicula"].Value?.ToString();

                if (!string.IsNullOrEmpty(nombrePeli) && !peliculasUnicas.Contains(nombrePeli))
                {
                    peliculasUnicas.Add(nombrePeli);
                }
            }

            if (peliculasUnicas.Count == 0)
            {
                MessageBox.Show("No se encontraron funciones registradas para los filtros actuales.", "Sin funciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string tituloPeliculaAfectada = null;

            if (peliculasUnicas.Count == 1)
            {
                tituloPeliculaAfectada = peliculasUnicas[0];

                DialogResult resultadoUnico = MessageBox.Show(
                    $"Se detectó una única película afectada en este rango:\n\n📌 {tituloPeliculaAfectada}\n\n¿Confirma la anulación masiva de funciones en la Sala {nroSala} desde el {fechaDesde.ToShortDateString()} al {fechaHasta.ToShortDateString()}?",
                    "Confirmación de anulación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (resultadoUnico == DialogResult.No) return;
            }
            else
            {
                string listaNombres = string.Join("\n- ", peliculasUnicas);

                DialogResult resultadoMultiple = MessageBox.Show(
                    $"⚠️ Atención: El listado actual contiene funciones de múltiples películas ({peliculasUnicas.Count}):\n\n- {listaNombres}\n\n¿Desea continuar de todos modos y desactivar masivamente todas las funciones de este rango?",
                    "Advertencia: Múltiples películas",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (resultadoMultiple == DialogResult.No) return;

                tituloPeliculaAfectada = null;
            }

            ConexionBD conexionBD = new ConexionBD();
            try
            {
                using (SqlConnection conexion = conexionBD.ObtenerConexión())
                {
                    using (SqlCommand comando = new SqlCommand("SP_AnularFuncionesPorRango", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;

                        comando.Parameters.AddWithValue("@TituloPelicula", (object)tituloPeliculaAfectada ?? DBNull.Value);
                        comando.Parameters.AddWithValue("@NroSala", nroSala);
                        comando.Parameters.AddWithValue("@FechaDesde", fechaDesde);
                        comando.Parameters.AddWithValue("@FechaHasta", fechaHasta);

                        comando.ExecuteNonQuery();

                        MessageBox.Show("Las funciones fueron anuladas correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        CargarTablaFunciones();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ejecutar la anulación masiva: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
