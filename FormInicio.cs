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
    public partial class FormInicio : Form
    {
        public FormInicio()
        {
            InitializeComponent();
        }

        private void FormInicio_Load(object sender, EventArgs e)
        {
            // Cargamos la fecha actual en la esquina superior derecha de forma dinámica
            LFecha.Text = DateTime.Now.ToString("dddd, dd 'de' MMMM 'de' yyyy");

            // Aplicamos estilo y configuración de la tabla
            ClassEstilosHelper.AplicarEstiloTabla(DGVProximas);

            // Cargamos los datos reales desde la Base de Datos
            CargarDashboardAdministrador();
        }

        private void CargarDashboardAdministrador()
        {
            ConexionBD conexionBD = new ConexionBD();
            try
            {
                using (SqlConnection conexion = conexionBD.ObtenerConexión())
                {
                    // COMANDO SQL DIRECTO: Contar Películas Activas
                    using (SqlCommand cmdPeliculas = new SqlCommand("SELECT COUNT(*) FROM pelicula WHERE estado = 'Activo'", conexion))
                    {
                        object resultadoPeliculas = cmdPeliculas.ExecuteScalar();
                        int cantPeliculas = resultadoPeliculas != DBNull.Value ? Convert.ToInt32(resultadoPeliculas) : 0;
                        lblPeliculasActivas.Text = $"({cantPeliculas})";
                    }

                    // COMANDO SQL DIRECTO: Contar Salas Operativas
                    using (SqlCommand cmdSalas = new SqlCommand("SELECT COUNT(*) FROM sala WHERE estado = 'Activo'", conexion))
                    {
                        object resultadoSalas = cmdSalas.ExecuteScalar();
                        int cantSalas = resultadoSalas != DBNull.Value ? Convert.ToInt32(resultadoSalas) : 0;
                        lblSalasOperativas.Text = $"({cantSalas})"; 
                    }

                    // STORED PROCEDURE: Contar Funciones de Hoy
                    using (SqlCommand cmdFuncionesHoy = new SqlCommand("SP_ContarFuncionesHoy", conexion))
                    {
                        cmdFuncionesHoy.CommandType = CommandType.StoredProcedure;
                        object resultadoFunciones = cmdFuncionesHoy.ExecuteScalar();
                        int cantFunciones = resultadoFunciones != DBNull.Value ? Convert.ToInt32(resultadoFunciones) : 0;
                        lblFuncionesHoy.Text = $"({cantFunciones})";
                    }

                    // STORED PROCEDURE: Cargar el DataGridView con las funciones de hoy
                    using (SqlCommand cmdTabla = new SqlCommand("SP_ListarFuncionesHoyDGV", conexion))
                    {
                        cmdTabla.CommandType = CommandType.StoredProcedure;
                        using (SqlDataAdapter adaptador = new SqlDataAdapter(cmdTabla))
                        {
                            DataTable dtFunciones = new DataTable();
                            adaptador.Fill(dtFunciones);

                            // Asignamos el resultado al DataGridView
                            DGVProximas.DataSource = dtFunciones;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el panel principal: " + ex.Message, "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BModMetodoPago_Click(object sender, EventArgs e)
        {
            FormModificarMetodoPago formModificar = new FormModificarMetodoPago();
            formModificar.ShowDialog();
        }

        private void BModPrecioBoleto_Click(object sender, EventArgs e)
        {
            FormModificarPrecio formModificar = new FormModificarPrecio();
            formModificar.ShowDialog();
        }

        private void BBackup_Click(object sender, EventArgs e)
        {
            FormBackup formBackup = new FormBackup();
            formBackup.ShowDialog(); // Abre el formulario de forma modal
        }
    }
}
