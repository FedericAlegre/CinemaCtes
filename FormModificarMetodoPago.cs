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
    public partial class FormModificarMetodoPago : Form
    {
        public FormModificarMetodoPago()
        {
            InitializeComponent();
        }

        private void FormModificarMetodoPago_Load(object sender, EventArgs e)
        {
            CargarMetodosPago();
        }

        private void CargarMetodosPago()
        {
            ConexionBD conexionBD = new ConexionBD();
            try
            {
                using (SqlConnection conexion = conexionBD.ObtenerConexión())
                {
                    string query = "SELECT id_metodo_pago, descripcion FROM metodo_pago";
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        using (SqlDataReader lector = comando.ExecuteReader())
                        {
                            System.Data.DataTable tabla = new System.Data.DataTable();
                            tabla.Load(lector);

                            CBMetodoPago.DataSource = tabla;
                            CBMetodoPago.DisplayMember = "descripcion";
                            CBMetodoPago.ValueMember = "id_metodo_pago";
                            CBMetodoPago.SelectedIndex = -1; // Para que arranque sin nada seleccionado
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los métodos de pago: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CBMetodoPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verificamos que haya un ítem seleccionado válidamente
            if (CBMetodoPago.SelectedValue != null && int.TryParse(CBMetodoPago.SelectedValue.ToString(), out int idMetodoPago))
            {
                ConexionBD conexionBD = new ConexionBD();
                try
                {
                    using (SqlConnection conexion = conexionBD.ObtenerConexión())
                    {
                        string query = "SELECT estado FROM metodo_pago WHERE id_metodo_pago = @Id";
                        using (SqlCommand comando = new SqlCommand(query, conexion))
                        {
                            comando.Parameters.AddWithValue("@Id", idMetodoPago);
                            object resultado = comando.ExecuteScalar();
                            if (resultado != null && resultado != DBNull.Value)
                            {
                                // Suponiendo que tu Label se llama LblEstado
                                LEstado.Text = "Estado actual: " + resultado.ToString();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener el estado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BConfirmar_Click(object sender, EventArgs e)
        {
            if (CBMetodoPago.SelectedValue == null || !int.TryParse(CBMetodoPago.SelectedValue.ToString(), out int idMetodoPago))
            {
                MessageBox.Show("Por favor, selecciona un método de pago.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ConexionBD conexionBD = new ConexionBD();
            try
            {
                using (SqlConnection conexion = conexionBD.ObtenerConexión())
                {
                    // Consultamos el estado actual para saber a qué alternarlo
                    string querySelect = "SELECT estado FROM metodo_pago WHERE id_metodo_pago = @Id";
                    string estadoActual = "";

                    using (SqlCommand cmdSelect = new SqlCommand(querySelect, conexion))
                    {
                        cmdSelect.Parameters.AddWithValue("@Id", idMetodoPago);
                        estadoActual = cmdSelect.ExecuteScalar()?.ToString().Trim();
                    }

                    // Definimos el nuevo estado opuesto (Ej: Si es 'Activo' pasa a 'Inactivo', y viceversa)
                    string nuevoEstado = (estadoActual.Equals("Activo", StringComparison.OrdinalIgnoreCase)) ? "Inactivo" : "Activo";

                    // Ejecutamos el UPDATE
                    string queryUpdate = "UPDATE metodo_pago SET estado = @NuevoEstado WHERE id_metodo_pago = @Id";
                    using (SqlCommand cmdUpdate = new SqlCommand(queryUpdate, conexion))
                    {
                        cmdUpdate.Parameters.AddWithValue("@NuevoEstado", nuevoEstado);
                        cmdUpdate.Parameters.AddWithValue("@Id", idMetodoPago);
                        cmdUpdate.ExecuteNonQuery();
                    }

                    MessageBox.Show($"El estado del método de pago cambió exitosamente a: {nuevoEstado}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Actualizamos el label en pantalla
                    LEstado.Text = "Estado actual: " + nuevoEstado;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar el estado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}