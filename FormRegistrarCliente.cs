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
    public partial class FormRegistrarCliente : Form
    {
        // Propiedad para exponer el DNI registrado al formulario principal
        public string DniRegistrado => TDni.Text.Trim();

        public FormRegistrarCliente()
        {
            InitializeComponent();
        }

        // Filtro en tiempo real: Solo permite letras y espacios en el Nombre
        private void TNombre_TextChanged(object sender, EventArgs e)
        {
            int cursorPosition = TNombre.SelectionStart;
            string textoFiltrado = new string(TNombre.Text.Where(c => char.IsLetter(c) || char.IsWhiteSpace(c)).ToArray());

            if (TNombre.Text != textoFiltrado)
            {
                TNombre.Text = textoFiltrado;
                TNombre.SelectionStart = Math.Min(cursorPosition, TNombre.Text.Length);
            }
        }

        // Filtro en tiempo real: Solo permite letras y espacios en el Apellido
        private void TApellido_TextChanged(object sender, EventArgs e)
        {
            int cursorPosition = TApellido.SelectionStart;
            string textoFiltrado = new string(TApellido.Text.Where(c => char.IsLetter(c) || char.IsWhiteSpace(c)).ToArray());

            if (TApellido.Text != textoFiltrado)
            {
                TApellido.Text = textoFiltrado;
                TApellido.SelectionStart = Math.Min(cursorPosition, TApellido.Text.Length); // Nota: asegurate que coincida con el nombre de tu control
            }
        }

        // Filtro en tiempo real: Solo permite números enteros en el DNI
        private void TDni_TextChanged(object sender, EventArgs e)
        {
            int cursorPosition = TDni.SelectionStart;
            string textoFiltrado = new string(TDni.Text.Where(char.IsDigit).ToArray());

            if (TDni.Text != textoFiltrado)
            {
                TDni.Text = textoFiltrado;
                TDni.SelectionStart = Math.Min(cursorPosition, TDni.Text.Length);
            }
        }

        private void BAñadir_Click(object sender, EventArgs e)
        {
            // Validar campos vacíos utilizando tu clase helper
            if (!ClassValidacionesHelper.ValidarCampoVacio(TNombre, "el nombre")) return;
            if (!ClassValidacionesHelper.ValidarCampoVacio(TApellido, "el apellido")) return;
            if (!ClassValidacionesHelper.ValidarCampoVacio(TDni, "el DNI")) return;

            // Validar longitud específica del DNI (7 a 8 dígitos)
            string dniTexto = TDni.Text.Trim();
            if (dniTexto.Length < 7 || dniTexto.Length > 8)
            {
                MessageBox.Show(
                    "El DNI ingresado no es válido. Debe tener entre 7 y 8 dígitos.",
                    "Longitud incorrecta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                TDni.Focus();
                return;
            }

            // Validar correo vacío y formato correcto usando el helper
            if (!ClassValidacionesHelper.ValidarCampoVacio(TCorreo, "el correo electrónico")) return;
            if (!ClassValidacionesHelper.ValidarEmail(TCorreo)) return;

            // Inserción real en la Base de Datos mediante el Stored Procedure
            ConexionBD conexionBD = new ConexionBD();
            try
            {
                using (SqlConnection conexion = conexionBD.ObtenerConexión())
                {
                    using (SqlCommand comando = new SqlCommand("SP_RegistrarCliente", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.AddWithValue("@Nombre", TNombre.Text.Trim());
                        comando.Parameters.AddWithValue("@Apellido", TApellido.Text.Trim());
                        comando.Parameters.AddWithValue("@Correo", TCorreo.Text.Trim());
                        comando.Parameters.AddWithValue("@Dni", Convert.ToInt32(dniTexto));

                        // Parámetro de salida para verificar el éxito de la operación
                        SqlParameter paramResultado = new SqlParameter("@Resultado", SqlDbType.Int);
                        paramResultado.Direction = ParameterDirection.Output;
                        comando.Parameters.Add(paramResultado);

                        comando.ExecuteNonQuery();
                        int resultado = Convert.ToInt32(paramResultado.Value);

                        if (resultado == 1)
                        {
                            MessageBox.Show(
                                "¡Cliente registrado con éxito en el sistema!",
                                "Operación Exitosa",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information
                            );

                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show(
                                "No se pudo registrar el cliente. Es posible que el DNI o el correo electrónico ya se encuentren en uso.",
                                "Error de registro",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning
                            );
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar con la base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
