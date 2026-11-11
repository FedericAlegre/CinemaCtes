using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CinemaCtes
{
    public partial class FormPeliculas : Form
    {
        public FormPeliculas()
        {
            InitializeComponent();
        }

        private string placeholderTexto = "Buscar Pelicula...";

        private void FormPeliculas_Load(object sender, EventArgs e)
        {
            ClassEstilosHelper.ConfigurarPlaceholder(TBuscar, placeholderTexto);
            ClassEstilosHelper.AplicarEstiloTabla(DGVPeliculas);
            ClassEstilosHelper.AgregarBotonesAccion(DGVPeliculas);

            CargarCombosFiltros(); // Cargamos filtros desde la BD
            CargarTablaPeliculas(); // Cargamos la grilla desde la BD
        }

        // Método para cargar los combos de filtros
        private void CargarCombosFiltros()
        {
            // Filtro de Estado
            ClassEstilosHelper.CargarComboEstados(CBEstado);

            // Filtro de Etiquetas desde la BD
            CBEtiqueta.Items.Clear();
            CBEtiqueta.Items.Add("Todas");

            ConexionBD conexionBD = new ConexionBD();
            try
            {
                using (SqlConnection conexion = conexionBD.ObtenerConexión())
                {
                    using (SqlCommand comando = new SqlCommand("SP_ListarEtiquetas", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader lector = comando.ExecuteReader())
                        {
                            while (lector.Read())
                            {
                                CBEtiqueta.Items.Add(lector["descripcion"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar etiquetas para el filtro: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (CBEtiqueta.Items.Count > 0)
                CBEtiqueta.SelectedIndex = 0;
        }

        // Método para cargar datos desde la Base de Datos en el DataGridView
        private void CargarTablaPeliculas()
        {
            DGVPeliculas.Rows.Clear();
            ConexionBD conexionBD = new ConexionBD();

            try
            {
                using (SqlConnection conexion = conexionBD.ObtenerConexión())
                {
                    using (SqlCommand comando = new SqlCommand("SP_ListarPeliculas", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader lector = comando.ExecuteReader())
                        {
                            while (lector.Read())
                            {
                                int n = DGVPeliculas.Rows.Add();
                                DGVPeliculas.Rows[n].Cells[0].Value = lector["titulo"];
                                DGVPeliculas.Rows[n].Cells[1].Value = lector["duracion"] + " min";
                                DGVPeliculas.Rows[n].Cells[2].Value = lector["sinopsis"];

                                DateTime desde = Convert.ToDateTime(lector["desde"]);
                                DateTime hasta = Convert.ToDateTime(lector["hasta"]);
                                DGVPeliculas.Rows[n].Cells[3].Value = desde.ToShortDateString();
                                DGVPeliculas.Rows[n].Cells[4].Value = hasta.ToShortDateString();

                                DGVPeliculas.Rows[n].Cells[5].Value = lector["etiquetas"]?.ToString() ?? ""; // Múltiples etiquetas separadas por coma
                                DGVPeliculas.Rows[n].Cells[6].Value = lector["estado"];
                                DGVPeliculas.Rows[n].Cells[7].Value = lector["id_pelicula"]; // ID Oculto
                            }
                        }
                    }
                }
                AplicarFiltros();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las películas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento para abrir el formulario de registro y dar de alta una película
        private void BAnadirPelicula_Click(object sender, EventArgs e)
        {
            using (FormRegistrarPelicula formRegistrar = new FormRegistrarPelicula())
            {
                DialogResult resultado = formRegistrar.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    // Obtenemos la lista de IDs seleccionados en el CheckedListBox y los unimos en formato "1,2,3"
                    List<int> idsEtiquetas = formRegistrar.ObtenerEtiquetasSeleccionadas();
                    string idsEtiquetasCsv = string.Join(",", idsEtiquetas);

                    ConexionBD conexionBD = new ConexionBD();
                    try
                    {
                        int resultadoRegistro = 0;

                        using (SqlConnection conexion = conexionBD.ObtenerConexión())
                        {
                            using (SqlCommand comando = new SqlCommand("SP_RegistrarPelicula", conexion))
                            {
                                comando.CommandType = CommandType.StoredProcedure;
                                comando.Parameters.AddWithValue("@Titulo", formRegistrar.Titulo);
                                comando.Parameters.AddWithValue("@Sinopsis", formRegistrar.Sinopsis);
                                comando.Parameters.AddWithValue("@Duracion", formRegistrar.Duracion);
                                comando.Parameters.AddWithValue("@Desde", formRegistrar.Desde);
                                comando.Parameters.AddWithValue("@Hasta", formRegistrar.Hasta);
                                comando.Parameters.AddWithValue("@IdsEtiquetas", idsEtiquetasCsv);

                                SqlParameter paramResultado = new SqlParameter("@Resultado", SqlDbType.Int);
                                paramResultado.Direction = ParameterDirection.Output;
                                comando.Parameters.Add(paramResultado);

                                comando.ExecuteNonQuery();
                                resultadoRegistro = Convert.ToInt32(paramResultado.Value);
                            }
                        }

                        if (resultadoRegistro == 0)
                        {
                            MessageBox.Show("Ya existe una película registrada con ese título.", "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            CargarTablaPeliculas();
                            MessageBox.Show($"Película '{formRegistrar.Titulo}' agregada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al guardar la película: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // Evento para modificar o cambiar el estado desde los botones de la grilla
        private void DGVPeliculas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && !DGVPeliculas.Rows[e.RowIndex].IsNewRow)
            {
                string nombreColumna = DGVPeliculas.Columns[e.ColumnIndex].Name;
                int idPelicula = Convert.ToInt32(DGVPeliculas.Rows[e.RowIndex].Cells[7].Value);

                string tituloActual = DGVPeliculas.Rows[e.RowIndex].Cells[0].Value?.ToString() ?? "";
                string duracionTexto = DGVPeliculas.Rows[e.RowIndex].Cells[1].Value?.ToString().Replace(" min", "") ?? "0";
                int.TryParse(duracionTexto, out int duracionActual);

                string sinopsisActual = DGVPeliculas.Rows[e.RowIndex].Cells[2].Value?.ToString() ?? "";
                DateTime desdeActual = Convert.ToDateTime(DGVPeliculas.Rows[e.RowIndex].Cells[3].Value);
                DateTime hastaActual = Convert.ToDateTime(DGVPeliculas.Rows[e.RowIndex].Cells[4].Value);
                string estadoActual = DGVPeliculas.Rows[e.RowIndex].Cells[6].Value?.ToString() ?? "Activo";

                if (nombreColumna == "CModificar")
                {
                    using (FormRegistrarPelicula formModificar = new FormRegistrarPelicula())
                    {
                        formModificar.CargarDatos(tituloActual, duracionActual, desdeActual, hastaActual, sinopsisActual);
                        DialogResult resultado = formModificar.ShowDialog();

                        if (resultado == DialogResult.OK)
                        {
                            List<int> idsEtiquetas = formModificar.ObtenerEtiquetasSeleccionadas();
                            string idsEtiquetasCsv = string.Join(",", idsEtiquetas);

                            ConexionBD conexionBD = new ConexionBD();
                            try
                            {
                                int resultadoModificacion = 0;

                                using (SqlConnection conexion = conexionBD.ObtenerConexión())
                                {
                                    // Verificamos de forma previa si esta película tiene funciones activas programadas
                                    // para advertirle al usuario antes de aplicar cambios de fechas.
                                    bool tieneFuncionesActivas = false;
                                    using (SqlCommand cmdVerificar = new SqlCommand("SELECT COUNT(1) FROM funcion WHERE id_pelicula = @IdPelicula AND fecha >= GETDATE() AND estado = 'Activo'", conexion))
                                    {
                                        cmdVerificar.Parameters.AddWithValue("@IdPelicula", idPelicula);
                                        tieneFuncionesActivas = Convert.ToInt32(cmdVerificar.ExecuteScalar()) > 0;
                                    }

                                    if (tieneFuncionesActivas)
                                    {
                                        DialogResult advResult = MessageBox.Show(
                                            $"Atención: La película '{tituloActual}' tiene funciones activas programadas.\n\nSi modifica el rango de fechas y alguna función queda fuera del nuevo período, se desactivará automáticamente.\n\n¿Desea continuar?",
                                            "Advertencia de Funciones Asociadas",
                                            MessageBoxButtons.YesNo,
                                            MessageBoxIcon.Warning
                                        );

                                        if (advResult == DialogResult.No) return;
                                    }

                                    // Ejecutamos la modificación
                                    using (SqlCommand comando = new SqlCommand("SP_ModificarPelicula", conexion))
                                    {
                                        comando.CommandType = CommandType.StoredProcedure;
                                        comando.Parameters.AddWithValue("@IdPelicula", idPelicula);
                                        comando.Parameters.AddWithValue("@Titulo", formModificar.Titulo);
                                        comando.Parameters.AddWithValue("@Sinopsis", formModificar.Sinopsis);
                                        comando.Parameters.AddWithValue("@Desde", formModificar.Desde);
                                        comando.Parameters.AddWithValue("@Hasta", formModificar.Hasta);
                                        comando.Parameters.AddWithValue("@IdsEtiquetas", idsEtiquetasCsv);

                                        SqlParameter paramResultado = new SqlParameter("@Resultado", SqlDbType.Int);
                                        paramResultado.Direction = ParameterDirection.Output;
                                        comando.Parameters.Add(paramResultado);

                                        comando.ExecuteNonQuery();
                                        resultadoModificacion = Convert.ToInt32(paramResultado.Value);
                                    }
                                }

                                if (resultadoModificacion == 0)
                                {
                                    MessageBox.Show("No se pudo modificar porque ya existe otra película con ese título.", "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                                else
                                {
                                    CargarTablaPeliculas();
                                    MessageBox.Show("Película modificada correctamente.", "Modificado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error al modificar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                else if (nombreColumna == "CEliminar")
                {
                    ConexionBD conexionBD = new ConexionBD();
                    try
                    {
                        int resultadoEstado = 1;

                        // Intentamos cambiar el estado con @ForzarBaja = 0 (evaluación preventiva)
                        using (SqlConnection conexion = conexionBD.ObtenerConexión())
                        {
                            using (SqlCommand comando = new SqlCommand("SP_CambiarEstadoPelicula", conexion))
                            {
                                comando.CommandType = CommandType.StoredProcedure;
                                comando.Parameters.AddWithValue("@IdPelicula", idPelicula);
                                comando.Parameters.AddWithValue("@ForzarBaja", 0);

                                SqlParameter paramResultado = new SqlParameter("@Resultado", SqlDbType.Int);
                                paramResultado.Direction = ParameterDirection.Output;
                                comando.Parameters.Add(paramResultado);

                                comando.ExecuteNonQuery();
                                resultadoEstado = Convert.ToInt32(paramResultado.Value);
                            }
                        }

                        // Si el resultado es 0, significa que tiene funciones activas futuras
                        if (resultadoEstado == 0)
                        {
                            DialogResult dialogResult = MessageBox.Show(
                                $"La película '{tituloActual}' tiene funciones activas programadas.\n\n¿Desea desactivarla de todos modos? Se cancelarán automáticamente sus funciones asociadas.",
                                "Funciones Activas Detectadas",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Warning
                            );

                            if (dialogResult == DialogResult.Yes)
                            {
                                // Volvemos a llamar al SP pero esta vez forzando la baja en cascada (@ForzarBaja = 1)
                                using (SqlConnection conexion = conexionBD.ObtenerConexión())
                                {
                                    using (SqlCommand comando = new SqlCommand("SP_CambiarEstadoPelicula", conexion))
                                    {
                                        comando.CommandType = CommandType.StoredProcedure;
                                        comando.Parameters.AddWithValue("@IdPelicula", idPelicula);
                                        comando.Parameters.AddWithValue("@ForzarBaja", 1);

                                        SqlParameter paramResultado = new SqlParameter("@Resultado", SqlDbType.Int);
                                        paramResultado.Direction = ParameterDirection.Output;
                                        comando.Parameters.Add(paramResultado);

                                        comando.ExecuteNonQuery();
                                    }
                                }

                                CargarTablaPeliculas();
                                MessageBox.Show("La película y sus funciones futuras fueron desactivadas correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            // Si no tenía funciones o se estaba activando, se hizo de forma directa
                            CargarTablaPeliculas();
                            MessageBox.Show("Estado de la película actualizado correctamente.", "Estado Actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al cambiar estado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // Método para aplicar los filtros de búsqueda y selección en el DataGridView
        private void AplicarFiltros()
        {
            string textoBusqueda = TBuscar?.Text.Trim().ToLower() ?? "";
            if (textoBusqueda == placeholderTexto.ToLower()) textoBusqueda = "";

            string etiquetaFiltro = CBEtiqueta?.SelectedItem?.ToString() ?? "Todas";
            string estadoFiltro = CBEstado?.SelectedItem?.ToString() ?? "Todos";

            // Obtenemos las fechas seleccionadas en los controles de la interfaz
            DateTime fechaFiltroDesde = DTPDesde.Value.Date;
            DateTime fechaFiltroHasta = DTPHasta.Value.Date;

            foreach (DataGridViewRow row in DGVPeliculas.Rows)
            {
                if (row.IsNewRow) continue;

                string titulo = row.Cells[0].Value?.ToString().ToLower() ?? "";

                DateTime fechaPeliDesde = Convert.ToDateTime(row.Cells[3].Value).Date; 
                DateTime fechaPeliHasta = Convert.ToDateTime(row.Cells[4].Value).Date; 

                string etiquetasFila = row.Cells[5].Value?.ToString().ToLower() ?? "";
                string estado = row.Cells[6].Value?.ToString().Trim() ?? "";

                bool cumpleTexto = string.IsNullOrEmpty(textoBusqueda) || titulo.Contains(textoBusqueda);

                bool cumpleEtiqueta = etiquetaFiltro.Equals("Todas", StringComparison.OrdinalIgnoreCase) ||
                                      etiquetasFila.Contains(etiquetaFiltro.ToLower());

                bool cumpleEstado = estadoFiltro.Equals("Todos", StringComparison.OrdinalIgnoreCase) ||
                                    estado.Equals(estadoFiltro, StringComparison.OrdinalIgnoreCase);

                // Lógica de superposición de fechas (la película coincide con el rango buscado)
                bool cumpleFechas = (fechaPeliDesde <= fechaFiltroHasta) && (fechaPeliHasta >= fechaFiltroDesde);

                row.Visible = cumpleTexto && cumpleEtiqueta && cumpleEstado && cumpleFechas;
            }
        }

        private void TBuscar_TextChanged(object sender, EventArgs e) => AplicarFiltros();
        private void CBEtiqueta_SelectedIndexChanged(object sender, EventArgs e) => AplicarFiltros();
        private void CBEstado_SelectedIndexChanged(object sender, EventArgs e) => AplicarFiltros();


        // Eventos de cambio en los DateTimePickers de rango
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

                // Opcional: devolvemos el DateTimePicker "Hasta" al mismo valor que "Desde" para corregirlo automáticamente
                DTPHasta.Value = desde;
                return false;
            }

            return true;
        }

        private void PHeader_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}