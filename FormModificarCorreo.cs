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
    public partial class FormModificarCorreo : Form
    {
        private int idClienteActual; // Almacenamos el ID para saber qué cliente actualizar
        public string NuevoCorreoIngresado { get; private set; }

        // Actualizamos el constructor para recibir el ID del cliente y su correo actual
        public FormModificarCorreo(int idCliente, string correoActual)
        {
            InitializeComponent();
            idClienteActual = idCliente;
            TCorreo.Text = correoActual; // Precargamos el correo actual para comodidad
        }

        private void FormModificarCorreo_Load(object sender, EventArgs e)
        {
        }

        private void BConfirmar_Click(object sender, EventArgs e)
        {
            // Validar que ningún campo esté vacío
            if (!ClassValidacionesHelper.ValidarCampoVacio(TCorreo, "correo electrónico")) return;

            // Validar formato básico de correo electrónico
            if (!ClassValidacionesHelper.ValidarEmail(TCorreo)) return;

            NuevoCorreoIngresado = TCorreo.Text.Trim();

            // Conectamos con la Base de Datos para actualizar el correo
            ConexionBD conexionBD = new ConexionBD();
            try
            {
                using (SqlConnection conexion = conexionBD.ObtenerConexión())
                {
                    using (SqlCommand comando = new SqlCommand("SP_ModificarCorreoCliente", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;

                        // Pasamos los parámetros requeridos por el SP
                        comando.Parameters.AddWithValue("@id_cliente", idClienteActual);
                        comando.Parameters.AddWithValue("@nuevo_correo", NuevoCorreoIngresado);

                        // Ejecutamos la actualización
                        comando.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("¡Correo electrónico actualizado con éxito!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el correo en la base de datos: " + ex.Message, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}