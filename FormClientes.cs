using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace CinemaCtes
{
    public partial class FormClientes : Form
    {
        public FormClientes()
        {
            InitializeComponent();
        }

        private bool cargandoFormulario = true;
        private string placeholderTexto = "Buscar por DNI, nombre, apellido o correo...";
        private ConexionBD conexionBD = new ConexionBD();

        private void FormClientes_Load(object sender, EventArgs e)
        {
            // 1. Aplica la responsividad básica del formulario
            ClassEstilosHelper.AplicarFormularioResponsivo(this);

            // 2. Aplica estilos visuales a la tabla (sin sobreescribir el Dock manual)
            ClassEstilosHelper.AplicarEstiloTabla(DGVClientes, true);
            DGVClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            ClassEstilosHelper.AgregarBotonesAccion(DGVClientes);

            // 3. Formatea la barra de filtros en TableLayoutPanel si corresponde
            if (tableLayoutPanel1 != null)
            {
                ClassEstilosHelper.ConfigurarFiltrosTableLayout(tableLayoutPanel1);
            }

            // 4. Configura el placeholder del buscador y combo
            ClassEstilosHelper.ConfigurarPlaceholder(TBuscar, placeholderTexto);
            ClassEstilosHelper.CargarComboEstados2(CBEstado);

            // 5. Carga de datos desde la base de datos
            CargarClientesDesdeBD();

            cargandoFormulario = false;
        }

        private void CargarClientesDesdeBD()
        {
            DGVClientes.Rows.Clear();

            try
            {
                using (SqlConnection conexion = conexionBD.ObtenerConexión())
                {
                    using (SqlCommand cmd = new SqlCommand("SP_ListarClientesConCompras", conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int idCliente = Convert.ToInt32(reader["id_cliente"]);
                                string dni = reader["dni"]?.ToString() ?? "";
                                string nombre = reader["nombre"]?.ToString() ?? "";
                                string apellido = reader["apellido"]?.ToString() ?? "";
                                string correo = reader["correo"]?.ToString() ?? "";
                                string compras = reader["compras"]?.ToString() ?? "0";
                                string estado = reader["estado"]?.ToString() ?? "Activo";

                                int rowIndex = DGVClientes.Rows.Add(dni, nombre, apellido, correo, compras, estado);

                                // Guardamos el id_cliente internamente en la propiedad Tag de la fila
                                DGVClientes.Rows[rowIndex].Tag = idCliente;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al listar los clientes: " + ex.Message, "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DGVClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = DGVClientes.Rows[e.RowIndex];
                string nombreColumna = DGVClientes.Columns[e.ColumnIndex].Name;

                // Verificamos que la fila tenga asignado su ID en el Tag
                if (fila.Tag == null)
                {
                    MessageBox.Show("No se pudo identificar el ID del cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int idCliente = Convert.ToInt32(fila.Tag);
                string dniCliente = fila.Cells[0].Value?.ToString() ?? ""; // Columna 0: DNI

                // Botón Modificar Correo
                if (nombreColumna == "CModificar")
                {
                    string correoActual = fila.Cells[3].Value?.ToString() ?? ""; // Columna 3: Correo

                    using (FormModificarCorreo formCorreo = new FormModificarCorreo(idCliente, correoActual))
                    {
                        if (formCorreo.ShowDialog() == DialogResult.OK)
                        {
                            string nuevoCorreo = formCorreo.NuevoCorreoIngresado;
                            fila.Cells[3].Value = nuevoCorreo; // Actualizar celda visualmente

                            MessageBox.Show($"El correo del cliente DNI {dniCliente} fue actualizado con éxito.",
                                "Actualización Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                // Botón Alternar Estado (Activo/Inactivo)
                else if (nombreColumna == "CEliminar")
                {
                    try
                    {
                        string nuevoEstado = "";
                        ConexionBD conexionBD = new ConexionBD();

                        using (SqlConnection conexion = conexionBD.ObtenerConexión())
                        {
                            using (SqlCommand cmd = new SqlCommand("SP_AlternarEstadoCliente", conexion))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@id_cliente", idCliente);

                                // Ejecutamos y obtenemos el nuevo estado retornado por el SP
                                object resultado = cmd.ExecuteScalar();
                                if (resultado != null)
                                {
                                    nuevoEstado = resultado.ToString();
                                }
                            }
                        }

                        // Actualizamos la celda de Estado visualmente en la grilla
                        fila.Cells[5].Value = nuevoEstado;

                        MessageBox.Show($"El estado del cliente DNI {dniCliente} ha cambiado a: {nuevoEstado}",
                            "Estado Actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al cambiar el estado del cliente: " + ex.Message, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void FiltrarClientes()
        {
            if (cargandoFormulario) return;

            CurrencyManager cm = (CurrencyManager)BindingContext[DGVClientes.DataSource ?? DGVClientes.Rows];
            cm.SuspendBinding();

            string filtroBusqueda = TBuscar.Text.Trim().ToLower();
            if (filtroBusqueda == placeholderTexto.ToLower()) filtroBusqueda = "";

            string estadoSeleccionado = CBEstado.SelectedItem?.ToString() ?? "Todos";

            foreach (DataGridViewRow fila in DGVClientes.Rows)
            {
                if (fila.IsNewRow) continue;

                string dniFila = fila.Cells[0].Value?.ToString().ToLower() ?? "";
                string nombreFila = fila.Cells[1].Value?.ToString().ToLower() ?? "";
                string apellidoFila = fila.Cells[2].Value?.ToString().ToLower() ?? "";
                string correoFila = fila.Cells[3].Value?.ToString().ToLower() ?? "";
                string estadoFila = fila.Cells[5].Value?.ToString() ?? "";

                bool cumpleBusqueda = string.IsNullOrEmpty(filtroBusqueda) ||
                                      dniFila.Contains(filtroBusqueda) ||
                                      nombreFila.Contains(filtroBusqueda) ||
                                      apellidoFila.Contains(filtroBusqueda) ||
                                      correoFila.Contains(filtroBusqueda);

                bool cumpleEstado = string.IsNullOrEmpty(estadoSeleccionado) ||
                                    estadoSeleccionado == "Todos" ||
                                    estadoFila.Equals(estadoSeleccionado, StringComparison.OrdinalIgnoreCase);

                fila.Visible = cumpleBusqueda && cumpleEstado;
            }

            cm.ResumeBinding();
        }

        private void TBuscar_TextChanged(object sender, EventArgs e)
        {
            FiltrarClientes();
        }

        private void CBEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarClientes();
        }
    }
}