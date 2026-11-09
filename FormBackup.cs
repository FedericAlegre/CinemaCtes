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
    public partial class FormBackup : Form
    {
        public FormBackup()
        {
            InitializeComponent();
        }

        private void FormBackup_Load(object sender, EventArgs e)
        {
            // Desactivamos los botones de backup y restauración al iniciar el formulario
            BHacerBackup.Enabled = false;
            BRestaurarBD.Enabled = false;
        }

        // Método para validar las credenciales del supervisor
        private void BValidar_Click(object sender, EventArgs e)
        {
            // Validar campos vacíos usando tus helpers
            if (!ClassValidacionesHelper.ValidarCampoVacio(TCorreoSupervisor, "correo del supervisor")) return;
            if (!ClassValidacionesHelper.ValidarCampoVacio(TContraseñaSupervisor, "contraseña del supervisor")) return;
            if (!ClassValidacionesHelper.ValidarEmail(TCorreoSupervisor)) return;

            bool credencialesValidas = false;
            string rolUsuario = "";
            string nombreSupervisor = "";

            ConexionBD conexionBD = new ConexionBD();
            try
            {
                using (SqlConnection conexion = conexionBD.ObtenerConexión())
                {
                    // Utilizamos tu SP de login existente para verificar las credenciales
                    using (SqlCommand comando = new SqlCommand("SP_LoginUsuario", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.AddWithValue("@Correo", TCorreoSupervisor.Text.Trim());
                        comando.Parameters.AddWithValue("@Contrasena", TContraseñaSupervisor.Text.Trim());

                        using (SqlDataReader lector = comando.ExecuteReader())
                        {
                            if (lector.Read())
                            {
                                nombreSupervisor = lector["nombre"].ToString();
                                rolUsuario = lector["id_tipo_usuario"].ToString();
                                credencialesValidas = true;
                            }
                        }
                    }
                }

                if (credencialesValidas)
                {
                    // Validamos que el rol sea Supervisor (Rol 2)
                    if (rolUsuario == "2")
                    {
                        MessageBox.Show($"¡Supervisor {nombreSupervisor} verificado con éxito!\nAcceso concedido a las funciones de respaldo.",
                            "Validación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Habilitamos los botones de respaldo y restauración
                        BHacerBackup.Enabled = true;
                        BRestaurarBD.Enabled = true;

                        // Bloqueamos los campos de validación para fijar la sesión de autorización en esta vista
                        TCorreoSupervisor.Enabled = false;
                        TContraseñaSupervisor.Enabled = false;
                        BValidar.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Las credenciales ingresadas pertenecen a un usuario sin privilegios de supervisor.",
                            "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Correo o contraseña de supervisor incorrectos.",
                        "Error de Autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TContraseñaSupervisor.Clear();
                    TContraseñaSupervisor.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar con la base de datos: " + ex.Message, "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para hacer un Backup del estado actual de la BD
        private void BHacerBackup_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Backup de SQL Server (*.bak)|*.bak";
                saveFileDialog.Title = "Guardar Respaldo de Base de Datos";
                saveFileDialog.FileName = $"CinemaCtes_Backup_{DateTime.Now:yyyy-MM-dd_HH:mm}.bak";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string rutaArchivo = saveFileDialog.FileName;
                    EjecutarRespaldoBD(rutaArchivo);
                }
            }
        }

        private void EjecutarRespaldoBD(string rutaDestino)
        {
            string nombreBD = "db_CinemaCtes";

            ConexionBD conexionBD = new ConexionBD();
            try
            {
                using (SqlConnection conexion = conexionBD.ObtenerConexión())
                {
                    string query = $"BACKUP DATABASE [{nombreBD}] TO DISK = @ruta WITH FORMAT, STATS = 10";

                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@ruta", rutaDestino);
                        comando.ExecuteNonQuery();

                        MessageBox.Show("¡Copia de seguridad realizada con éxito!", "Respaldo Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al realizar el backup: " + ex.Message, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para restaurar una versión de la BD
        private void BRestaurarBD_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Backup de SQL Server (*.bak)|*.bak";
                openFileDialog.Title = "Seleccionar Archivo de Respaldo para Restaurar";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string rutaArchivo = openFileDialog.FileName;

                    DialogResult confirmacion = MessageBox.Show(
                        "ADVERTENCIA: Restaurar la base de datos sobrescribirá todos los datos actuales con los del archivo seleccionado.\n\n¿Estás seguro de que deseas continuar?",
                        "Confirmar Restauración",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning,
                        MessageBoxDefaultButton.Button2
                    );

                    if (confirmacion == DialogResult.Yes)
                    {
                        EjecutarRestauracionBD(rutaArchivo);
                    }
                }
            }
        }

        private void EjecutarRestauracionBD(string rutaOrigen)
        {
            string nombreBD = "db_CinemaCtes";

            ConexionBD conexionBD = new ConexionBD();
            try
            {
                using (SqlConnection conexion = conexionBD.ObtenerConexión())
                {
                    string query = $@"
                        ALTER DATABASE [{nombreBD}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
                        RESTORE DATABASE [{nombreBD}] FROM DISK = @ruta WITH REPLACE;
                        ALTER DATABASE [{nombreBD}] SET MULTI_USER;";

                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@ruta", rutaOrigen);
                        comando.CommandTimeout = 300; // 5 minutos de timeout
                        comando.ExecuteNonQuery();

                        MessageBox.Show("¡Base de datos restaurada con éxito! Se recomienda reiniciar la aplicación.", "Restauración Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al restaurar la base de datos: " + ex.Message, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}