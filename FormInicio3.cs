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
    public partial class FormInicio3 : Form
    {
        private int idUsuarioActual; // Variable para almacenar el ID del cajero logueado

        // Constructor que recibe el id_usuario desde el menú principal
        public FormInicio3(int idUsuario)
        {
            InitializeComponent();
            idUsuarioActual = idUsuario;
        }

        private void lblCartelera_Load(object sender, EventArgs e)
        {
            // Cargamos la fecha actual en la esquina superior derecha de forma dinámica
            LFecha.Text = DateTime.Now.ToString("dddd, dd 'de' MMMM 'de' yyyy");

            // Aplicamos estilo a la tabla
            ClassEstilosHelper.AplicarEstiloTabla(dgvFunciones);

            // Cargamos los datos reales desde la base de datos
            CargarDashboardVendedor();
        }

        private void CargarDashboardVendedor()
        {
            ConexionBD conexionBD = new ConexionBD();
            try
            {
                using (SqlConnection conexion = conexionBD.ObtenerConexión())
                {
                    // Obtener Total Recaudado Hoy
                    using (SqlCommand cmdTotal = new SqlCommand("SP_ObtenerTotalRecaudadoHoy", conexion))
                    {
                        cmdTotal.CommandType = CommandType.StoredProcedure;
                        cmdTotal.Parameters.AddWithValue("@id_usuario", idUsuarioActual);
                        object resultadoTotal = cmdTotal.ExecuteScalar();

                        decimal total = resultadoTotal != DBNull.Value ? Convert.ToDecimal(resultadoTotal) : 0;
                        LTotalRecaudado.Text = total.ToString("C2"); // Formato moneda (ej: $ 10.000,00)
                    }

                    // Obtener Cantidad de Ventas Realizadas Hoy
                    using (SqlCommand cmdCant = new SqlCommand("SP_ObtenerCantidadVentasHoy", conexion))
                    {
                        cmdCant.CommandType = CommandType.StoredProcedure;
                        cmdCant.Parameters.AddWithValue("@id_usuario", idUsuarioActual);
                        object resultadoCant = cmdCant.ExecuteScalar();

                        int cantidad = resultadoCant != DBNull.Value ? Convert.ToInt32(resultadoCant) : 0;
                        lblCantidadVentas.Text = cantidad.ToString();
                    }

                    // Cargar el DataGridView con las Funciones Próximas de Hoy
                    using (SqlCommand cmdFunciones = new SqlCommand("SP_ListarFuncionesProximasHoy", conexion))
                    {
                        cmdFunciones.CommandType = CommandType.StoredProcedure;
                        using (SqlDataAdapter adaptador = new SqlDataAdapter(cmdFunciones))
                        {
                            DataTable dtFunciones = new DataTable();
                            adaptador.Fill(dtFunciones);

                            // Asignamos el DataTable directamente al DataGridView
                            dgvFunciones.DataSource = dtFunciones;
 
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el panel de inicio: " + ex.Message, "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

