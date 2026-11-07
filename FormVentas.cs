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
    public partial class FormVentas : Form
    {
        public FormVentas()
        {
            InitializeComponent();
        }

        private string placeholderTexto = "Buscar DNI...";
        private bool cargandoFormulario = true; // Bandera para evitar filtrados prematuros

        private void FormVentas_Load(object sender, EventArgs e)
        {
            // Configuración visual de la grilla
            ClassEstilosHelper.AplicarEstiloTabla(DGVVentas);

            // Configuración inicial del buscador y su placeholder
            ClassEstilosHelper.ConfigurarPlaceholder(TBuscar, placeholderTexto);

            // Crear la columna de botón Switch si no existe en la grilla
            if (!DGVVentas.Columns.Contains("CEliminar"))
            {
                DataGridViewButtonColumn CEliminar = new DataGridViewButtonColumn();
                CEliminar.Name = "CEliminar";
                CEliminar.HeaderText = "Acción";
                CEliminar.Text = "Cambiar Estado";
                CEliminar.UseColumnTextForButtonValue = true;
                DGVVentas.Columns.Add(CEliminar);
            }

            // Cargar los combos desplegables desde la base de datos
            CargarComboBeneficios();
            CargarComboPeliculas();

            // Cargar las ventas reales desde la base de datos
            CargarVentasDesdeBD();

            cargandoFormulario = false; // Formulario listo para permitir filtrado
        }

        private void CargarComboBeneficios()
        {
            ConexionBD conexionBD = new ConexionBD();

            try
            {
                DataTable dt = new DataTable();

                using (SqlConnection conexion = conexionBD.ObtenerConexión())
                {
                    using (SqlCommand comando = new SqlCommand("SP_ListarBeneficios", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter adapter = new SqlDataAdapter(comando);
                        adapter.Fill(dt);
                    }
                }

                // Identificamos las columnas de forma segura por si varían sus nombres
                string columnaId = dt.Columns.Contains("id_beneficio") ? "id_beneficio" : dt.Columns[0].ColumnName;
                string columnaTexto = dt.Columns.Contains("descripcion") ? "descripcion" : dt.Columns[1].ColumnName;

                // Insertamos la opción "Todos" al inicio para que sirva de filtro
                DataRow dr = dt.NewRow();
                dr[columnaId] = 0;
                dr[columnaTexto] = "Todos";
                dt.Rows.InsertAt(dr, 0);

                CBBeneficio.DataSource = dt;
                CBBeneficio.DisplayMember = columnaTexto;
                CBBeneficio.ValueMember = columnaId;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar beneficios: " + ex.Message, "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarComboPeliculas()
        {
            ConexionBD conexionBD = new ConexionBD();

            try
            {
                DataTable dt = new DataTable();

                using (SqlConnection conexion = conexionBD.ObtenerConexión())
                {
                    // Consulta directa a la tabla pelicula
                    string consulta = "SELECT id_pelicula, titulo FROM pelicula ORDER BY titulo ASC";

                    using (SqlCommand comando = new SqlCommand(consulta, conexion))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(comando);
                        adapter.Fill(dt);
                    }
                }

                // Insertamos la opción "Todas" al inicio para el filtro
                DataRow dr = dt.NewRow();
                dr["id_pelicula"] = 0;
                dr["titulo"] = "Todas";
                dt.Rows.InsertAt(dr, 0);

                CBPelicula.DataSource = dt;
                CBPelicula.DisplayMember = "titulo";
                CBPelicula.ValueMember = "id_pelicula";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar películas: " + ex.Message, "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarVentasDesdeBD()
        {
            ConexionBD conexionBD = new ConexionBD();

            try
            {
                DGVVentas.Rows.Clear();

                using (SqlConnection conexion = conexionBD.ObtenerConexión())
                {
                    // Obtenemos los campos realizando JOINs para traer los nombres y títulos asociados
                    string consulta = @"
                        SELECT 
                            v.id_venta AS NroVenta,
                            FORMAT(v.fecha, 'dd/MM/yyyy HH:mm') AS FechaHora,
                            ISNULL(c.dni, 0) AS DniCliente,
                            ISNULL(p.titulo, 'N/D') AS Pelicula,
                            ISNULL(CONCAT('Sala ', f.nro_sala), 'N/D') AS Sala,
                            ISNULL(b.descripcion, 'Sin Beneficio') AS Beneficio,
                            CONCAT('$ ', FORMAT(v.monto_total, 'N2')) AS MontoTotal,
                            v.estado AS Estado
                        FROM venta v
                        LEFT JOIN cliente c ON v.id_cliente = c.id_cliente
                        LEFT JOIN beneficio b ON v.id_beneficio = b.id_beneficio
                        LEFT JOIN Boleto bol ON bol.id_venta = v.id_venta
                        LEFT JOIN funcion f ON bol.id_funcion = f.id_funcion
                        LEFT JOIN pelicula p ON f.id_pelicula = p.id_pelicula
                        GROUP BY v.id_venta, v.fecha, c.dni, p.titulo, f.nro_sala, b.descripcion, v.monto_total, v.estado
                        ORDER BY v.id_venta DESC";

                    using (SqlCommand comando = new SqlCommand(consulta, conexion))
                    {
                        using (SqlDataReader lector = comando.ExecuteReader())
                        {
                            while (lector.Read())
                            {
                                DGVVentas.Rows.Add(
                                    lector["NroVenta"].ToString(),
                                    lector["FechaHora"].ToString(),
                                    lector["DniCliente"].ToString(),
                                    lector["Pelicula"].ToString(),
                                    lector["Sala"].ToString(),
                                    lector["Beneficio"].ToString(),
                                    lector["MontoTotal"].ToString(),
                                    lector["Estado"].ToString()
                                );
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el historial de ventas: " + ex.Message, "Error de BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DGVVentas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificamos clic en la columna del botón "CEliminar" (Cambiar Estado)
            if (e.RowIndex >= 0 && DGVVentas.Columns[e.ColumnIndex].Name == "CEliminar")
            {
                DataGridViewRow fila = DGVVentas.Rows[e.RowIndex];

                int indiceColumnaEstado = DGVVentas.Columns["CEstado"].Index;
                string estadoActual = fila.Cells[indiceColumnaEstado].Value?.ToString() ?? "Activo";
                string nroVenta = fila.Cells[0].Value?.ToString() ?? "N/D";

                string nuevoEstado = (estadoActual == "Activo") ? "Inactivo" : "Activo";

                DialogResult resultado = MessageBox.Show(
                    $"¿Desea cambiar el estado de la venta N° {nroVenta} a '{nuevoEstado}'?",
                    "Confirmar cambio de estado",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    // Actualizamos en la Base de Datos
                    if (ActualizarEstadoVentaEnBD(nroVenta, nuevoEstado))
                    {
                        fila.Cells[indiceColumnaEstado].Value = nuevoEstado;

                        // Refrescamos la vista por si hay un filtro de estado activo
                        FiltrarVentas();

                        MessageBox.Show($"La venta N° {nroVenta} ahora se encuentra '{nuevoEstado}'.",
                            "Estado actualizado",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                }
            }
        }

        private bool ActualizarEstadoVentaEnBD(string idVenta, string nuevoEstado)
        {
            ConexionBD conexionBD = new ConexionBD();

            try
            {
                using (SqlConnection conexion = conexionBD.ObtenerConexión())
                {
                    string consulta = "UPDATE venta SET estado = @Estado WHERE id_venta = @IdVenta";

                    using (SqlCommand comando = new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@Estado", nuevoEstado);
                        comando.Parameters.AddWithValue("@IdVenta", idVenta);
                        comando.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar estado en BD: " + ex.Message, "Error de BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void BtnModificarPrecios_Click(object sender, EventArgs e)
        {
            using (FormModificarPrecio formPrecios = new FormModificarPrecio())
            {
                formPrecios.ShowDialog();
            }
        }

        private void DTPDesde_ValueChanged(object sender, EventArgs e)
        {
            // Si la fecha 'Hasta' es menor que la nueva fecha 'Desde' (considerando año, mes y día), la igualamos
            if (DTPHasta.Value.Date < DTPDesde.Value.Date)
            {
                DTPHasta.Value = DTPDesde.Value.Date;
            }

            // Fijamos la fecha mínima seleccionable en DTPHasta
            DTPHasta.MinDate = DTPDesde.Value.Date;

            FiltrarVentas();
        }

        private void DTPHasta_ValueChanged(object sender, EventArgs e)
        {
            // Validación de resguardo
            if (DTPHasta.Value.Date < DTPDesde.Value.Date)
            {
                MessageBox.Show("La fecha 'Hasta' no puede ser anterior a la fecha 'Desde'.",
                                "Rango de Fechas Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DTPHasta.Value = DTPDesde.Value.Date;
            }

            FiltrarVentas();
        }

        private void FiltrarVentas()
        {
            if (cargandoFormulario) return;

            // 1. Obtención de filtros
            string filtroDni = TBuscar.Text.Trim().ToLower();
            if (filtroDni == placeholderTexto.ToLower()) filtroDni = "";

            string peliculaSeleccionada = string.IsNullOrEmpty(CBPelicula.Text) ? "Todas" : CBPelicula.Text;
            string beneficioSeleccionado = string.IsNullOrEmpty(CBBeneficio.Text) ? "Todos" : CBBeneficio.Text;
            string estadoSeleccionado = CBEstado.SelectedItem?.ToString() ?? "";

            // Convertimos las fechas a rangos completos (00:00:00 del primer día hasta las 23:59:59 del último día)
            DateTime fechaDesde = DTPDesde.Value.Date;
            DateTime fechaHasta = DTPHasta.Value.Date.AddDays(1).AddTicks(-1);

            // 2. Quitamos la celda activa para evitar errores en WinForms
            DGVVentas.CurrentCell = null;

            // 3. Evaluamos cada fila de la grilla
            foreach (DataGridViewRow fila in DGVVentas.Rows)
            {
                if (fila.IsNewRow) continue;

                string fechaHoraTexto = fila.Cells[1].Value?.ToString() ?? "";
                string dniFila = fila.Cells[2].Value?.ToString().ToLower() ?? "";
                string peliculaFila = fila.Cells[3].Value?.ToString() ?? "";
                string beneficioFila = fila.Cells[5].Value?.ToString() ?? "";
                string estadoFila = fila.Cells["CEstado"].Value?.ToString() ?? "";

                // Comparación correcta por objeto DateTime (Respeta año, mes y día)
                bool cumpleFecha = true;
                if (DateTime.TryParse(fechaHoraTexto, out DateTime fechaFila))
                {
                    cumpleFecha = fechaFila >= fechaDesde && fechaFila <= fechaHasta;
                }

                bool cumpleDni = string.IsNullOrEmpty(filtroDni) || dniFila.Contains(filtroDni);
                bool cumplePelicula = string.IsNullOrEmpty(peliculaSeleccionada) || peliculaSeleccionada == "Todas" || peliculaFila == peliculaSeleccionada;
                bool cumpleBeneficio = string.IsNullOrEmpty(beneficioSeleccionado) || beneficioSeleccionado == "Todos" || beneficioFila == beneficioSeleccionado;
                bool cumpleEstado = string.IsNullOrEmpty(estadoSeleccionado) || estadoSeleccionado == "Todos" || estadoFila == estadoSeleccionado;

                bool visibilidadDestino = cumpleFecha && cumpleDni && cumplePelicula && cumpleBeneficio && cumpleEstado;

                if (fila.Visible != visibilidadDestino)
                {
                    fila.Visible = visibilidadDestino;
                }
            }
        }

        private void TBuscar_TextChanged(object sender, EventArgs e)
        {
            FiltrarVentas();
        }

        private void CBPelicula_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarVentas();
        }

        private void CBBeneficio_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarVentas();
        }

        private void CBEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarVentas();
        }

        private void DTPFecha_ValueChanged(object sender, EventArgs e)
        {
            FiltrarVentas();
        }

        private void LPelicula_Click(object sender, EventArgs e)
        {

        }
    }
}