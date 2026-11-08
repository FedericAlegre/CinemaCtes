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
    public partial class FormModificarPrecio : Form
    {

        public FormModificarPrecio()
        {
            InitializeComponent();
        }

        private void FormModificarPrecio_Load(object sender, EventArgs e)
        {
            CargarPrecioActual();
        }

        private void CargarPrecioActual()
        {
            ConexionBD conexionBD = new ConexionBD();
            try
            {
                using (SqlConnection conexion = conexionBD.ObtenerConexión())
                {
                    // Puedes usar un SP o una consulta directa rápida para traer el precio actual
                    using (SqlCommand comando = new SqlCommand("SELECT TOP 1 precio_base FROM tarifa", conexion))
                    {
                        object resultado = comando.ExecuteScalar();
                        if (resultado != null && resultado != DBNull.Value)
                        {
                            decimal precioActual = Convert.ToDecimal(resultado);

                            lblPrecioActual.Text = $"Precio actual: ${precioActual:N0}";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el precio actual: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BConfirmar_Click(object sender, EventArgs e)
        {
            if (!ClassValidacionesHelper.ValidarCampoVacio(TPrecio, "precio nuevo")) return;

            // Validamos que el precio sea un número decimal válido y mayor a cero
            if (decimal.TryParse(TPrecio.Text.Trim(), out decimal nuevoPrecio))
            {
                if (nuevoPrecio <= 0)
                {
                    MessageBox.Show("El precio debe ser mayor a cero.", "Valor inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Confirmación de la modificación
                DialogResult resultado = MessageBox.Show(
                    $"¿Confirma actualizar el precio del boleto a ${nuevoPrecio}?",
                    "Confirmar Modificación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    ConexionBD conexionBD = new ConexionBD();
                    try
                    {
                        using (SqlConnection conexion = conexionBD.ObtenerConexión())
                        {
                            using (SqlCommand comando = new SqlCommand("SP_ActualizarPrecioBoleto", conexion))
                            {
                                comando.CommandType = CommandType.StoredProcedure;
                                comando.Parameters.AddWithValue("@nuevo_precio", nuevoPrecio);
                                comando.ExecuteNonQuery();
                            }
                        }

                        MessageBox.Show("Precio actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Cerramos el formulario devolviendo un resultado OK
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al actualizar el precio en la base de datos: " + ex.Message, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un valor numérico válido.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TPrecio.Focus();
                TPrecio.SelectAll();
            }
        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void TPrecio_TextChanged(object sender, EventArgs e)
        {
            int seleccionInicio = TPrecio.SelectionStart;
            string textoFiltrado = new string(TPrecio.Text.Where(char.IsDigit).ToArray());

            if (TPrecio.Text != textoFiltrado)
            {
                TPrecio.Text = textoFiltrado;
                TPrecio.SelectionStart = Math.Min(seleccionInicio, TPrecio.Text.Length);
            }
        }
    }
}
