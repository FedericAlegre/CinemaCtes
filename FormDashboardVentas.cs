using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Data.SqlClient;

namespace CinemaCtes
{
    public partial class FormDashboardVentas : Form
    {
        public FormDashboardVentas()
        {
            InitializeComponent();
            this.MinimumSize = new Size(816, 489);
        }

        private void FormDashboardVentas_Load(object sender, EventArgs e)
        {
            // Configurar el DateTimePicker "Desde" para que muestre solo Mes y Año
            DTPDesde.Format = DateTimePickerFormat.Custom;
            DTPDesde.CustomFormat = "MMMM yyyy";
            DTPDesde.ShowUpDown = true;

            // Configurar el DateTimePicker "Hasta"
            DTPHasta.Format = DateTimePickerFormat.Custom;
            DTPHasta.CustomFormat = "MMMM yyyy";
            DTPHasta.ShowUpDown = true;

            // Definir un rango por defecto al abrir
            DTPDesde.Value = new DateTime(DateTime.Now.Year, 1, 1);
            DTPHasta.Value = DateTime.Now;

            // Cargamos todos los gráficos por defecto al abrir la ventana
            CargarTodosLosGraficos();
        }

        private void BFiltrar_Click(object sender, EventArgs e)
        {
            DateTime mesDesde = new DateTime(DTPDesde.Value.Year, DTPDesde.Value.Month, 1);
            DateTime mesHasta = new DateTime(DTPHasta.Value.Year, DTPHasta.Value.Month, 1);
            DateTime mesActual = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

            // Validar que la fecha "Desde" no supere al "Hasta"
            if (mesDesde > mesHasta)
            {
                MessageBox.Show("La fecha 'Desde' no puede ser posterior a la fecha 'Hasta'.",
                    "Rango de fechas inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Reseteamos al valor por defecto seguro
                DTPDesde.Value = new DateTime(DateTime.Now.Year, 1, 1);
                DTPHasta.Value = DateTime.Now;
                return;
            }

            // Validar que la fecha "Hasta" no supere el presente (mes actual)
            if (mesHasta > mesActual)
            {
                MessageBox.Show("La fecha 'Hasta' no puede superar el mes actual.",
                    "Fecha futura no permitida", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Reseteamos al mes actual por seguridad
                DTPHasta.Value = DateTime.Now;
                return;
            }

            // Si pasa las validaciones, cargamos los gráficos normalmente
            CargarTodosLosGraficos();
        }

        private void CargarTodosLosGraficos()
        {
            DateTime fechaInicio = new DateTime(DTPDesde.Value.Year, DTPDesde.Value.Month, 1);

            // "Hasta" -> Último día exacto del mes seleccionado
            int ultimoDia = DateTime.DaysInMonth(DTPHasta.Value.Year, DTPHasta.Value.Month);
            DateTime fechaFin = new DateTime(DTPHasta.Value.Year, DTPHasta.Value.Month, ultimoDia);

            // Llamamos a los métodos de carga de los primeros 4 gráficos originales
            CargarGraficoPeliculas(fechaInicio, fechaFin);
            CargarGraficoBeneficios(fechaInicio, fechaFin);
            CargarGraficoMetodosPago(fechaInicio, fechaFin);
            CargarGraficoVentasPorMes(fechaInicio, fechaFin);

            // Llamamos a los 4 nuevos gráficos agregados
            CargarGraficoVentasPorCajero(fechaInicio, fechaFin);
            CargarGraficoClientesVsAnonimos(fechaInicio, fechaFin);
            CargarGraficoFranjaHoraria(fechaInicio, fechaFin);
            CargarGraficoVentasPorEtiqueta(fechaInicio, fechaFin);

            // Aplicamos el estilo oscuro a TODOS los gráficos del dashboard
            ClassEstilosHelper.AplicarEstiloOscuroGrafico(chartPeliculas);
            ClassEstilosHelper.AplicarEstiloOscuroGrafico(chartBeneficios);
            ClassEstilosHelper.AplicarEstiloOscuroGrafico(chartMetodosPago);
            ClassEstilosHelper.AplicarEstiloOscuroGrafico(chartEvolucionVentas);
            ClassEstilosHelper.AplicarEstiloOscuroGrafico(chartCajeros);
            ClassEstilosHelper.AplicarEstiloOscuroGrafico(chartClientes);
            ClassEstilosHelper.AplicarEstiloOscuroGrafico(chartFranjaHoraria);
            ClassEstilosHelper.AplicarEstiloOscuroGrafico(chartEtiquetas);
        }

        // Gráfico de Películas Más Vendidas
        private void CargarGraficoPeliculas(DateTime inicio, DateTime fin)
        {
            ConexionBD conexionBD = new ConexionBD();
            try
            {
                using (SqlConnection conexion = conexionBD.ObtenerConexión())
                {
                    using (SqlCommand comando = new SqlCommand("SP_GraficoPeliculasMasVendidas", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.AddWithValue("@FechaInicio", inicio);
                        comando.Parameters.AddWithValue("@FechaFin", fin);

                        using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                        {
                            DataTable dt = new DataTable();
                            adaptador.Fill(dt);

                            chartPeliculas.Series.Clear();
                            Series serie = new Series("Entradas");
                            serie.ChartType = SeriesChartType.Column;
                            serie.IsValueShownAsLabel = true;

                            foreach (DataRow row in dt.Rows)
                            {
                                serie.Points.AddXY(row["Pelicula"].ToString(), Convert.ToInt32(row["EntradasVendidas"]));
                            }

                            chartPeliculas.Series.Add(serie);
                            chartPeliculas.Titles.Clear();
                            chartPeliculas.Titles.Add("Top 5 - Películas Más Vendidas");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en gráfico de películas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Gráfico de Uso de Beneficios (Torta)
        private void CargarGraficoBeneficios(DateTime inicio, DateTime fin)
        {
            ConexionBD conexionBD = new ConexionBD();
            try
            {
                using (SqlConnection conexion = conexionBD.ObtenerConexión())
                {
                    using (SqlCommand comando = new SqlCommand("SP_GraficoUsoBeneficios", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.AddWithValue("@FechaInicio", inicio);
                        comando.Parameters.AddWithValue("@FechaFin", fin);

                        using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                        {
                            DataTable dt = new DataTable();
                            adaptador.Fill(dt);

                            chartBeneficios.Series.Clear();
                            Series serie = new Series("Beneficios");
                            serie.ChartType = SeriesChartType.Pie;
                            serie.IsValueShownAsLabel = true;

                            foreach (DataRow row in dt.Rows)
                            {
                                serie.Points.AddXY(row["Beneficio"].ToString(), Convert.ToInt32(row["CantidadUsos"]));
                            }

                            chartBeneficios.Series.Add(serie);
                            chartBeneficios.Titles.Clear();
                            chartBeneficios.Titles.Add("Uso de Beneficios");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en gráfico de beneficios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Gráfico de Métodos de Pago
        private void CargarGraficoMetodosPago(DateTime inicio, DateTime fin)
        {
            ConexionBD conexionBD = new ConexionBD();
            try
            {
                using (SqlConnection conexion = conexionBD.ObtenerConexión())
                {
                    using (SqlCommand comando = new SqlCommand("SP_GraficoVentasPorMetodoPago", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.AddWithValue("@FechaInicio", inicio);
                        comando.Parameters.AddWithValue("@FechaFin", fin);

                        using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                        {
                            DataTable dt = new DataTable();
                            adaptador.Fill(dt);

                            chartMetodosPago.Series.Clear();
                            Series serie = new Series("Recaudación");
                            serie.ChartType = SeriesChartType.Column;
                            serie.IsValueShownAsLabel = true;

                            foreach (DataRow row in dt.Rows)
                            {
                                serie.Points.AddXY(row["MetodoPago"].ToString(), Convert.ToDecimal(row["TotalRecaudado"]));
                            }

                            chartMetodosPago.Series.Add(serie);
                            chartMetodosPago.Titles.Clear();
                            chartMetodosPago.Titles.Add("Recaudación por Método de Pago");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en gráfico de métodos de pago: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Gráfico de Evolución de Ventas por Mes (Líneas)
        private void CargarGraficoVentasPorMes(DateTime inicio, DateTime fin)
        {
            ConexionBD conexionBD = new ConexionBD();
            try
            {
                using (SqlConnection conexion = conexionBD.ObtenerConexión())
                {
                    using (SqlCommand comando = new SqlCommand("SP_GraficoVentasPorFecha", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.AddWithValue("@FechaInicio", inicio);
                        comando.Parameters.AddWithValue("@FechaFin", fin);

                        using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                        {
                            DataTable dt = new DataTable();
                            adaptador.Fill(dt);

                            chartEvolucionVentas.Series.Clear();
                            Series serie = new Series("Ventas Mensuales");
                            serie.ChartType = SeriesChartType.Spline;
                            serie.IsValueShownAsLabel = true;

                            foreach (DataRow row in dt.Rows)
                            {
                                serie.Points.AddXY(row["MesVenta"].ToString(), Convert.ToDecimal(row["RecaudacionMensual"]));
                            }

                            chartEvolucionVentas.Series.Add(serie);
                            chartEvolucionVentas.Titles.Clear();
                            chartEvolucionVentas.Titles.Add("Evolución de Ventas por Mes");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en gráfico de evolución: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==========================================
        // 🚀 NUEVOS MÉTODOS PARA LOS 4 GRÁfICOS AGREGADOS
        // ==========================================

        // 5. Gráfico de Ventas por Cajero
        private void CargarGraficoVentasPorCajero(DateTime inicio, DateTime fin)
        {
            ConexionBD conexionBD = new ConexionBD();
            try
            {
                using (SqlConnection conexion = conexionBD.ObtenerConexión())
                {
                    using (SqlCommand comando = new SqlCommand("SP_GraficoVentasPorCajero", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.AddWithValue("@FechaInicio", inicio);
                        comando.Parameters.AddWithValue("@FechaFin", fin);

                        using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                        {
                            DataTable dt = new DataTable();
                            adaptador.Fill(dt);

                            chartCajeros.Series.Clear();
                            Series serie = new Series("Ventas");
                            serie.ChartType = SeriesChartType.Bar; // Barras horizontales ideal para nombres
                            serie.IsValueShownAsLabel = true;

                            foreach (DataRow row in dt.Rows)
                            {
                                serie.Points.AddXY(row["Cajero"].ToString(), Convert.ToInt32(row["CantidadVentas"]));
                            }

                            chartCajeros.Series.Add(serie);
                            chartCajeros.Titles.Clear();
                            chartCajeros.Titles.Add("Ventas Realizadas por Cajero");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en gráfico de cajeros: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 6. Gráfico de Clientes Registrados vs Anónimos
        private void CargarGraficoClientesVsAnonimos(DateTime inicio, DateTime fin)
        {
            ConexionBD conexionBD = new ConexionBD();
            try
            {
                using (SqlConnection conexion = conexionBD.ObtenerConexión())
                {
                    using (SqlCommand comando = new SqlCommand("SP_GraficoClientesVsAnonimos", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.AddWithValue("@FechaInicio", inicio);
                        comando.Parameters.AddWithValue("@FechaFin", fin);

                        using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                        {
                            DataTable dt = new DataTable();
                            adaptador.Fill(dt);

                            chartClientes.Series.Clear();
                            Series serie = new Series("Clientes");
                            serie.ChartType = SeriesChartType.Pie;
                            serie.IsValueShownAsLabel = true;

                            foreach (DataRow row in dt.Rows)
                            {
                                serie.Points.AddXY(row["TipoCliente"].ToString(), Convert.ToInt32(row["CantidadVentas"]));
                            }

                            chartClientes.Series.Add(serie);
                            chartClientes.Titles.Clear();
                            chartClientes.Titles.Add("Clientes Registrados vs Anónimos");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en gráfico de clientes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 7. Gráfico de Demanda por Franja Horaria
        private void CargarGraficoFranjaHoraria(DateTime inicio, DateTime fin)
        {
            ConexionBD conexionBD = new ConexionBD();
            try
            {
                using (SqlConnection conexion = conexionBD.ObtenerConexión())
                {
                    using (SqlCommand comando = new SqlCommand("SP_GraficoVentasPorFranjaHoraria", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.AddWithValue("@FechaInicio", inicio);
                        comando.Parameters.AddWithValue("@FechaFin", fin);

                        using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                        {
                            DataTable dt = new DataTable();
                            adaptador.Fill(dt);

                            chartFranjaHoraria.Series.Clear();
                            Series serie = new Series("Entradas");
                            serie.ChartType = SeriesChartType.Column;
                            serie.IsValueShownAsLabel = true;

                            foreach (DataRow row in dt.Rows)
                            {
                                serie.Points.AddXY(row["FranjaHoraria"].ToString(), Convert.ToInt32(row["EntradasVendidas"]));
                            }

                            chartFranjaHoraria.Series.Add(serie);
                            chartFranjaHoraria.Titles.Clear();
                            chartFranjaHoraria.Titles.Add("Demanda por Franja Horaria");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en gráfico de franja horaria: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 8. Gráfico de Recaudación por Género / Etiqueta
        private void CargarGraficoVentasPorEtiqueta(DateTime inicio, DateTime fin)
        {
            ConexionBD conexionBD = new ConexionBD();
            try
            {
                using (SqlConnection conexion = conexionBD.ObtenerConexión())
                {
                    using (SqlCommand comando = new SqlCommand("SP_GraficoVentasPorEtiqueta", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.AddWithValue("@FechaInicio", inicio);
                        comando.Parameters.AddWithValue("@FechaFin", fin);

                        using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                        {
                            DataTable dt = new DataTable();
                            adaptador.Fill(dt);

                            chartEtiquetas.Series.Clear();
                            Series serie = new Series("Recaudación");
                            serie.ChartType = SeriesChartType.Column;
                            serie.IsValueShownAsLabel = true;

                            foreach (DataRow row in dt.Rows)
                            {
                                serie.Points.AddXY(row["Etiqueta"].ToString(), Convert.ToDecimal(row["TotalRecaudado"]));
                            }

                            chartEtiquetas.Series.Add(serie);
                            chartEtiquetas.Titles.Clear();
                            chartEtiquetas.Titles.Add("Recaudación por Género / Etiqueta");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en gráfico de etiquetas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BAgregar_Click(object sender, EventArgs e)
        {

        }
    }
}