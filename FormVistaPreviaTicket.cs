using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;


namespace CinemaCtes
{
    public partial class FormVistaPreviaTicket : Form
    {
        private int idVentaActual;
        private string textoComprobanteGeneral = "";
        private string textoBoletosIndividuales = "";

        private PrintDocument printDocumentGeneral = new PrintDocument();
        private PrintDocument printDocumentBoletos = new PrintDocument();

        public FormVistaPreviaTicket(int idVenta)
        {
            InitializeComponent();
            idVentaActual = idVenta;

            // Configuramos los eventos de impresión
            printDocumentGeneral.PrintPage += new PrintPageEventHandler(printDocumentGeneral_PrintPage);
            printDocumentBoletos.PrintPage += new PrintPageEventHandler(printDocumentBoletos_PrintPage);

            txtVistaComprobante.ReadOnly = true;
            txtVistaBoletos.ReadOnly = true;
        }

        private void FormVistaPreviaTicket_Load(object sender, EventArgs e)
        {
            CargarDatosTicketDesdeSP();
        }

        private void CargarDatosTicketDesdeSP()
        {
            ConexionBD conexionBD = new ConexionBD();
            try
            {
                using (SqlConnection conexion = conexionBD.ObtenerConexión())
                {
                    using (SqlCommand comando = new SqlCommand("SP_ObtenerDatosTicket", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.AddWithValue("@id_venta", idVentaActual);

                        using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                        {
                            DataTable dtTicket = new DataTable();
                            adaptador.Fill(dtTicket);

                            if (dtTicket.Rows.Count > 0)
                            {
                                DataRow rowCabecera = dtTicket.Rows[0];

                                // CONSTRUIR EL COMPROBANTE DE PAGO GENERAL
                                textoComprobanteGeneral = "====================================\r\n";
                                textoComprobanteGeneral += "         COMPROBANTE DE PAGO        \r\n";
                                textoComprobanteGeneral += "            CINEMACTES S.A.         \r\n";
                                textoComprobanteGeneral += "====================================\r\n";
                                textoComprobanteGeneral += $"Nro Venta: {rowCabecera["id_venta"]}\r\n";
                                textoComprobanteGeneral += $"Fecha: {Convert.ToDateTime(rowCabecera["fecha"]):dd/MM/yyyy HH:mm}\r\n";
                                textoComprobanteGeneral += $"Cliente: {rowCabecera["cliente_nombre"]}\r\n";
                                textoComprobanteGeneral += $"Método de Pago: {rowCabecera["metodo_pago"]}\r\n";
                                textoComprobanteGeneral += $"Beneficio: {rowCabecera["beneficio"]}\r\n";
                                textoComprobanteGeneral += "------------------------------------\r\n";
                                textoComprobanteGeneral += " RESUMEN DE BUTACAS:\r\n";

                                foreach (DataRow row in dtTicket.Rows)
                                {
                                    textoComprobanteGeneral += $" - Asiento [{row["codigo_butaca"]}] - ${row["precio_boleto"]}\r\n";
                                }

                                textoComprobanteGeneral += "------------------------------------\r\n";
                                textoComprobanteGeneral += $"MONTO TOTAL: ${rowCabecera["monto_total"]}\r\n";
                                textoComprobanteGeneral += "====================================\r\n";


                                // CONSTRUIR LOS BOLETOS INDIVIDUALES (Uno debajo del otro)
                                textoBoletosIndividuales = "";

                                foreach (DataRow row in dtTicket.Rows)
                                {
                                    textoBoletosIndividuales += "====================================\r\n";
                                    textoBoletosIndividuales += $"       ENTRADA DE CINE    \r\n";
                                    textoBoletosIndividuales += "====================================\r\n";
                                    textoBoletosIndividuales += $"Película: {row["pelicula"]}\r\n";
                                    textoBoletosIndividuales += $"Función: {Convert.ToDateTime(row["fecha_funcion"]):dd/MM/yyyy} - {row["hora_funcion"]}\r\n";
                                    textoBoletosIndividuales += $"Sala: {row["nro_sala"]}   |   Asiento: {row["codigo_butaca"]}\r\n";
                                    textoBoletosIndividuales += $"Precio: ${row["precio_boleto"]}\r\n";
                                    textoBoletosIndividuales += $"Venta Nro: {row["id_venta"]}\r\n";
                                    textoBoletosIndividuales += "====================================\r\n\r\n";
                                }

                                txtVistaComprobante.Text = textoComprobanteGeneral;
                                txtVistaBoletos.Text = textoBoletosIndividuales;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar la vista previa: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Eventos para dibujar la impresión
        private void printDocumentGeneral_PrintPage(object sender, PrintPageEventArgs e)
        {
            Font fuente = new Font("Consolas", 10, FontStyle.Regular);
            e.Graphics.DrawString(textoComprobanteGeneral, fuente, Brushes.Black, 10, 10);
        }

        private void printDocumentBoletos_PrintPage(object sender, PrintPageEventArgs e)
        {
            Font fuente = new Font("Consolas", 10, FontStyle.Regular);
            e.Graphics.DrawString(textoBoletosIndividuales, fuente, Brushes.Black, 10, 10);
        }

        // Botón para imprimir el Comprobante General
        private void BImprimirComprobante_Click(object sender, EventArgs e)
        {
            if (PrinterSettings.InstalledPrinters.Count == 0)
            {
                MessageBox.Show("No se detectó ninguna impresora instalada.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PrintPreviewDialog preview = new PrintPreviewDialog();
            preview.Document = printDocumentGeneral;
            preview.ShowDialog();
        }

        // Botón para imprimir los Boletos Individuales
        private void BImprimirBoletos_Click(object sender, EventArgs e)
        {
            if (PrinterSettings.InstalledPrinters.Count == 0)
            {
                MessageBox.Show("No se detectó ninguna impresora instalada.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PrintPreviewDialog preview = new PrintPreviewDialog();
            preview.Document = printDocumentBoletos;
            preview.ShowDialog();
        }

        private void BCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}