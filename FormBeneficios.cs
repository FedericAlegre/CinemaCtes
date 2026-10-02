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
    public partial class FormBeneficios : Form
    {
        private string placeholderTexto = "Buscar beneficio...";

        public FormBeneficios()
        {
            InitializeComponent();

            CBTipo.SelectedIndex = 0; // Seleccionar "Todos" por defecto
            CBEstado.SelectedIndex = 0;
        }

        private void FormBeneficios_Load(object sender, EventArgs e)
        {
            ClassEstilosHelper.ConfigurarPlaceholder(TBuscar, placeholderTexto);
            ClassEstilosHelper.AplicarEstiloTabla(DGVBeneficios);
            ClassEstilosHelper.AgregarBotonesAccion(DGVBeneficios);

            // Cargar los datos reales desde la BD al iniciar
            CargarTablaBeneficios();
        }

        // Método para poblar el DataGridView desde SQL Server
        private void CargarTablaBeneficios()
        {
            DGVBeneficios.Rows.Clear();
            ConexionBD conexionBD = new ConexionBD();

            try
            {
                using (SqlConnection conexion = conexionBD.ObtenerConexión())
                {
                    using (SqlCommand comando = new SqlCommand("SP_ListarBeneficios", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader lector = comando.ExecuteReader())
                        {
                            while (lector.Read())
                            {
                                DGVBeneficios.Rows.Add(
                                    lector["id_beneficio"],
                                    lector["beneficio_descripcion"],
                                    lector["tipo_beneficio_descripcion"], 
                                    lector["descuento"],
                                    lector["estado"]
                                );
                            }
                        }
                    }
                }
                FiltrarTabla();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los beneficios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BAñadir_Click(object sender, EventArgs e)
        {
            using (FormRegistrarBeneficio formRegistro = new FormRegistrarBeneficio())
            {
                DialogResult resultado = formRegistro.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    ConexionBD conexionBD = new ConexionBD();
                    try
                    {
                        int resultadoRegistro = 0;

                        using (SqlConnection conexion = conexionBD.ObtenerConexión())
                        {
                            using (SqlCommand comando = new SqlCommand("SP_RegistrarBeneficio", conexion))
                            {
                                comando.CommandType = CommandType.StoredProcedure;
                                comando.Parameters.AddWithValue("@Descripcion", formRegistro.Descripcion);
                                comando.Parameters.AddWithValue("@IdTipoBeneficio", formRegistro.IdTipoBeneficio);
                                comando.Parameters.AddWithValue("@Descuento", formRegistro.Descuento);

                                // Parámetro de salida que nos devuelve 1 (éxito) o 0 (duplicado atrapado por SQL)
                                SqlParameter paramResultado = new SqlParameter("@Resultado", SqlDbType.Int);
                                paramResultado.Direction = ParameterDirection.Output;
                                comando.Parameters.Add(paramResultado);

                                comando.ExecuteNonQuery();

                                resultadoRegistro = Convert.ToInt32(paramResultado.Value);
                            }
                        }

                        if (resultadoRegistro == 0)
                        {
                            MessageBox.Show(
                                "No se pudo registrar el beneficio porque ya existe uno con la misma descripción.",
                                "Duplicado detectado",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning
                            );
                        }
                        else
                        {
                            CargarTablaBeneficios(); // Recargamos la tabla desde la BD con el nuevo registro activo
                            MessageBox.Show(
                                "Se registró con éxito el beneficio.",
                                "Registro Guardado",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information
                            );
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al guardar el beneficio: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void DGVBeneficios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && !DGVBeneficios.Rows[e.RowIndex].IsNewRow)
            {
                string nombreColumna = DGVBeneficios.Columns[e.ColumnIndex].Name;

                int idBeneficio = Convert.ToInt32(DGVBeneficios.Rows[e.RowIndex].Cells[0].Value);

                if (nombreColumna == "CModificar")
                {
                    string descActual = DGVBeneficios.Rows[e.RowIndex].Cells[1].Value?.ToString() ?? "";
                    string tipoActual = DGVBeneficios.Rows[e.RowIndex].Cells[2].Value?.ToString() ?? "";
                    string descUsoActual = DGVBeneficios.Rows[e.RowIndex].Cells[3].Value?.ToString() ?? "";

                    using (FormRegistrarBeneficio formModificar = new FormRegistrarBeneficio())
                    {
                        formModificar.CargarDatos(descActual, tipoActual, descUsoActual);
                        DialogResult resultado = formModificar.ShowDialog();

                        if (resultado == DialogResult.OK)
                        {
                            ConexionBD conexionBD = new ConexionBD();
                            try
                            {
                                using (SqlConnection conexion = conexionBD.ObtenerConexión())
                                {
                                    using (SqlCommand comando = new SqlCommand("SP_ModificarBeneficio", conexion))
                                    {
                                        comando.CommandType = CommandType.StoredProcedure;
                                        comando.Parameters.AddWithValue("@IdBeneficio", idBeneficio);
                                        comando.Parameters.AddWithValue("@Descripcion", formModificar.Descripcion);
                                        comando.Parameters.AddWithValue("@TipoBeneficio", formModificar.IdTipoBeneficio);
                                        comando.Parameters.AddWithValue("@Descuento", formModificar.Descuento);

                                        comando.ExecuteNonQuery();
                                    }
                                }

                                CargarTablaBeneficios();
                                MessageBox.Show("Beneficio modificado correctamente.", "Modificado", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        using (SqlConnection conexion = conexionBD.ObtenerConexión())
                        {
                            using (SqlCommand comando = new SqlCommand("SP_CambiarEstadoBeneficio", conexion))
                            {
                                comando.CommandType = CommandType.StoredProcedure;
                                comando.Parameters.AddWithValue("@IdBeneficio", idBeneficio);

                                comando.ExecuteNonQuery();
                            }
                        }

                        CargarTablaBeneficios();
                        MessageBox.Show("Estado del beneficio actualizado correctamente.", "Estado Actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al cambiar estado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void FiltrarTabla()
        {
            string textoBusqueda = TBuscar.Text.Trim().ToLower();
            if (textoBusqueda == placeholderTexto.ToLower()) textoBusqueda = "";

            string tipoSeleccionado = CBTipo.SelectedItem?.ToString() ?? "Todos";
            string estadoSeleccionado = CBEstado.SelectedItem?.ToString() ?? "Todos";

            foreach (DataGridViewRow row in DGVBeneficios.Rows)
            {
                if (row.IsNewRow) continue;

                // Ajustando a los índices reales según si el ID está en la celda 0
                string descripcion = row.Cells[1].Value?.ToString().ToLower() ?? "";
                string tipo = row.Cells[2].Value?.ToString() ?? "";
                string estado = row.Cells[4].Value?.ToString() ?? "";

                bool coincideTexto = string.IsNullOrEmpty(textoBusqueda) || descripcion.Contains(textoBusqueda);
                bool coincideTipo = (tipoSeleccionado == "Todos") || (tipo == tipoSeleccionado);
                bool coincideEstado = (estadoSeleccionado == "Todos") || (estado == estadoSeleccionado);

                row.Visible = coincideTexto && coincideTipo && coincideEstado;
            }
        }

        private void TBuscar_TextChanged(object sender, EventArgs e) => FiltrarTabla();
        private void CBTipo_SelectedIndexChanged(object sender, EventArgs e) => FiltrarTabla();
        private void CBEstado_SelectedIndexChanged(object sender, EventArgs e) => FiltrarTabla();

        private void DGVBeneficios_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (DGVBeneficios.Columns[e.ColumnIndex].Name == "CEliminar" && e.RowIndex >= 0)
            {
                // Celda 4 es el estado en este mapeo con ID incluido
                string estado = DGVBeneficios.Rows[e.RowIndex].Cells[4].Value?.ToString() ?? "Activo";
                e.Value = (estado == "Activo") ? "Desactivar" : "Activar";
            }
        }
    }
}
