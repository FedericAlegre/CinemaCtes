using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace CinemaCtes
{
    public partial class FormInicio2 : Form
    {
        private ConexionBD conexionBD = new ConexionBD();

        public FormInicio2()
        {
            InitializeComponent();
            this.Load += FormInicio2_Load;
        }

        private void FormInicio2_Load(object sender, EventArgs e)
        {
            // Cargar fecha actual
            LFecha.Text = DateTime.Now.ToString("dddd, dd 'de' MMMM 'de' yyyy");

            // Aplicar estilos a la grilla inferior
            ClassEstilosHelper.AplicarEstiloTabla(DGVRecaudacionPelis);

            // Cargar las 4 tarjetas de estadísticas y la grilla
            CargarEstadisticasTarjetas();
            CargarRecaudacionPeliculasBD();
        }

        /// <summary>
        /// Consulta la BD y muestra los valores de las 4 tarjetas de estadísticas.
        /// </summary>
        private void CargarEstadisticasTarjetas()
        {
            try
            {
                using (SqlConnection conexion = conexionBD.ObtenerConexión())
                {
                    // 1. RECAUDACIÓN DEL DÍA
                    string queryRecaudacion = @"SELECT ISNULL(SUM(monto_total), 0) 
                                        FROM venta 
                                        WHERE CAST(fecha AS DATE) = CAST(GETDATE() AS DATE) 
                                          AND estado = 'Activo'";
                    using (SqlCommand cmd = new SqlCommand(queryRecaudacion, conexion))
                    {
                        // AQUÍ AGREGAS EL CÓDIGO
                        decimal totalHoy = Convert.ToDecimal(cmd.ExecuteScalar());
                        lMonto.Text = $"$ {totalHoy:N0}";
                    }

                    // 2. ENTRADAS VENDIDAS HOY
                    string queryEntradas = @"SELECT COUNT(b.id_boleto) 
                                     FROM Boleto b
                                     INNER JOIN venta v ON b.id_venta = v.id_venta
                                     WHERE CAST(v.fecha AS DATE) = CAST(GETDATE() AS DATE) 
                                       AND v.estado = 'Activo'";
                    using (SqlCommand cmd = new SqlCommand(queryEntradas, conexion))
                    {
                        int entradasHoy = Convert.ToInt32(cmd.ExecuteScalar());
                        lBoletos.Text = $"{entradasHoy} boletos";
                    }

                    // 3. PELÍCULA EN TENDENCIA
                    string queryPeliculaTendencia = @"SELECT TOP 1 p.titulo 
                                             FROM Boleto b
                                             INNER JOIN funcion f ON b.id_funcion = f.id_funcion
                                             INNER JOIN pelicula p ON f.id_pelicula = p.id_pelicula
                                             INNER JOIN venta v ON b.id_venta = v.id_venta
                                             WHERE v.estado = 'Activo'
                                             GROUP BY p.titulo
                                             ORDER BY COUNT(b.id_boleto) DESC";
                    using (SqlCommand cmd = new SqlCommand(queryPeliculaTendencia, conexion))
                    {
                        object resPeli = cmd.ExecuteScalar();
                        lNombrePel.Text = resPeli != null ? resPeli.ToString() : "Sin ventas";
                    }

                    // 4. BENEFICIO MÁS UTILIZADO
                    string queryBeneficio = @"SELECT TOP 1 
                                        b.descripcion AS beneficio,
                                        CAST((COUNT(v.id_venta) * 100.0 / NULLIF((SELECT COUNT(*) FROM venta WHERE estado = 'Activo'), 0)) AS INT) AS porcentaje
                                      FROM venta v
                                      INNER JOIN beneficio b ON v.id_beneficio = b.id_beneficio
                                      WHERE v.estado = 'Activo'
                                      GROUP BY b.descripcion
                                      ORDER BY COUNT(v.id_venta) DESC";
                    using (SqlCommand cmd = new SqlCommand(queryBeneficio, conexion))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string beneficioNombre = reader["beneficio"]?.ToString() ?? "Sin beneficio";
                                string porcentaje = reader["porcentaje"]?.ToString() ?? "0";
                                lBeneficioNombre.Text = $"{beneficioNombre} ({porcentaje}%)";
                            }
                            else
                            {
                                lBeneficioNombre.Text = "Sin datos";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las estadísticas: " + ex.Message, "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Llena la tabla inferior de Películas con más recaudación del mes.
        /// </summary>
        private void CargarRecaudacionPeliculasBD()
        {
            try
            {
                DataTable dt = new DataTable();

                string query = @"SELECT 
                                    p.titulo AS [Pelicula],
                                    COUNT(b.id_boleto) AS [Ventas],
                                    ISNULL(SUM(v.monto_total), 0) AS [Recaudacion]
                                 FROM pelicula p
                                 LEFT JOIN funcion f ON p.id_pelicula = f.id_pelicula
                                 LEFT JOIN Boleto b ON f.id_funcion = b.id_funcion
                                 LEFT JOIN venta v ON b.id_venta = v.id_venta AND v.estado = 'Activo'
                                 GROUP BY p.titulo
                                 HAVING COUNT(b.id_boleto) > 0
                                 ORDER BY Recaudacion DESC";

                using (SqlConnection conexion = conexionBD.ObtenerConexión())
                {
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(comando);
                        adapter.Fill(dt);
                    }
                }

                DGVRecaudacionPelis.DataSource = dt;

                if (DGVRecaudacionPelis.Columns.Contains("Recaudacion"))
                {
                    // Forzamos el formato de moneda con la cultura argentina (signo $)
                    DGVRecaudacionPelis.Columns["Recaudacion"].DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("es-AR");
                    DGVRecaudacionPelis.Columns["Recaudacion"].DefaultCellStyle.Format = "C2";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cargar grilla: " + ex.Message);
            }
        }

        private void BCambiarButaca_Click(object sender, EventArgs e)
        {
            using (FormModificarButaca formModificacion = new FormModificarButaca())
            {
                if (formModificacion.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show(
                        "La gestión de la butaca se completó correctamente en el sistema.",
                        "Aviso del Sistema",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
            }
        }
    }
}