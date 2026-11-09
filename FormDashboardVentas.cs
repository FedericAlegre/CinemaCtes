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
        }

        private void FormDashboardVentas_Load(object sender, EventArgs e)
        {
            // 1. Configurar el DateTimePicker "Desde" para que muestre solo Mes y Año
            DTPDesde.Format = DateTimePickerFormat.Custom;
            DTPDesde.CustomFormat = "MMMM yyyy";
            DTPDesde.ShowUpDown = true;

            // 2. Configurar el DateTimePicker "Hasta"
            DTPHasta.Format = DateTimePickerFormat.Custom;
            DTPHasta.CustomFormat = "MMMM yyyy";
            DTPHasta.ShowUpDown = true;

            // 3. Definir un rango por defecto al abrir (ej: desde enero de este año hasta el mes actual)
            DTPDesde.Value = new DateTime(DateTime.Now.Year, 1, 1);
            DTPHasta.Value = DateTime.Now;

            // 4. Cargamos todos los gráficos por defecto al abrir la ventana
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

                // Opcional: Reseteamos al valor por defecto seguro
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

            // Llamamos a los 4 métodos de carga pasándoles las fechas
            CargarGraficoPeliculas(fechaInicio, fechaFin);
            CargarGraficoBeneficios(fechaInicio, fechaFin);
            CargarGraficoMetodosPago(fechaInicio, fechaFin);
            CargarGraficoVentasPorMes(fechaInicio, fechaFin);
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

                            // Asegúrate de cambiar 'chartBeneficios' por el nombre real de tu segundo chart si es diferente
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

                            // Ajusta el nombre del chart (ej: chartMetodosPago) según tu diseñador
                            chartMetodosPago.Series.Clear();
                            Series serie = new Series("Recaudación");
                            serie.ChartType = SeriesChartType.Column; // O Bar (horizontal)
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

                            // Ajusta el nombre del chart (ej: chartEvolucionVentas) según tu diseñador
                            chartEvolucionVentas.Series.Clear();
                            Series serie = new Series("Ventas Mensuales");
                            serie.ChartType = SeriesChartType.Spline; // Línea con curvas suaves
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
    }
}
