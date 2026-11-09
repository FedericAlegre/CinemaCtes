using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CinemaCtes
{
    public static class ClassEstilosHelper
    {
        // ==========================================
        // MÉTODOS RESPONSIVOS Y DE CONTENEDORES
        // ==========================================

        /// <summary>
        /// Configura las propiedades base de responsividad de un Formulario Hijo.
        /// </summary>
        public static void AplicarFormularioResponsivo(Form form)
        {
            form.MinimumSize = new Size(0, 0);
            form.AutoScroll = true;

            // Si es un formulario incrustado en un Panel
            if (!form.TopLevel)
            {
                form.Dock = DockStyle.Fill;
            }
        }

        /// <summary>
        /// Configura el título para que fluya responsivamente y fija el botón superior a la derecha.
        /// </summary>
        public static void ConfigurarCabeceraResponsiva(Label lblTitulo, Control botonDerecho = null)
        {
            lblTitulo.AutoSize = true;
            lblTitulo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblTitulo.MaximumSize = new Size(0, 0);
            lblTitulo.MinimumSize = new Size(0, 0);

            if (botonDerecho != null)
            {
                botonDerecho.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            }
        }

        /// <summary>
        /// Configura los filtros dentro de un TableLayoutPanel y ajusta DateTimePickers a formato corto.
        /// </summary>
        public static void ConfigurarFiltrosTableLayout(TableLayoutPanel tlp)
        {
            tlp.Dock = DockStyle.Top;
            tlp.Margin = new Padding(0);

            // Si tiene 2 columnas, le damos 60% al buscador y 40% a la derecha
            if (tlp.ColumnCount == 2)
            {
                tlp.ColumnStyles.Clear();
                tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
                tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            }

            foreach (Control control in tlp.Controls)
            {
                control.MinimumSize = new Size(0, 0);

                if (control is TextBox)
                {
                    control.Anchor = AnchorStyles.Left | AnchorStyles.Right;
                    control.Margin = new Padding(3, 4, 10, 3);
                }
                else if (control is ComboBox)
                {
                    // El combo no se estira tanto horizontalmente
                    control.Anchor = AnchorStyles.Left;
                    control.Width = 180; // Ancho fijo cómodo para opciones como "Todos / Activo / Inactivo"
                    control.Margin = new Padding(3, 4, 3, 3);
                }
            }
        }


        // Método para aplicar un estilo uniforme a los DataGridView
        public static void AplicarEstiloTabla(DataGridView dgv, bool aplicarDockFill = false)
        {
            // Opciones de comportamiento
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.ReadOnly = true;
            dgv.RowHeadersVisible = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.GridColor = Color.FromArgb(38, 42, 60);

            if (aplicarDockFill)
            {
                dgv.Dock = DockStyle.Fill;
            }

            // Estilo de encabezados
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.ColumnHeadersHeight = 38;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 24, 40);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            // Estilo de las filas
            dgv.BackgroundColor = Color.FromArgb(18, 20, 32);
            dgv.DefaultCellStyle.BackColor = Color.FromArgb(18, 20, 32);
            dgv.DefaultCellStyle.ForeColor = Color.FromArgb(210, 215, 230);
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(48, 38, 75);
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;
            dgv.RowTemplate.Height = 36;
        }

        // Método para agregar las columnas de botones de acción
        public static void AgregarBotonesAccion(DataGridView dgv)
        {
            if (!dgv.Columns.Contains("CModificar"))
            {
                DataGridViewButtonColumn CModificar = new DataGridViewButtonColumn();
                CModificar.Name = "CModificar";
                CModificar.HeaderText = "Acción 1";
                CModificar.Text = "Modificar";
                CModificar.UseColumnTextForButtonValue = true;
                dgv.Columns.Add(CModificar);
            }

            if (!dgv.Columns.Contains("CEliminar"))
            {
                DataGridViewButtonColumn CEliminar = new DataGridViewButtonColumn();
                CEliminar.Name = "CEliminar";
                CEliminar.HeaderText = "Acción 2";
                CEliminar.Text = "Desactivar";
                CEliminar.UseColumnTextForButtonValue = true;
                dgv.Columns.Add(CEliminar);
            }
        }

        public static void AgregarBotonesAccion2(DataGridView dgv)
        {
            if (!dgv.Columns.Contains("CEliminar"))
            {
                DataGridViewButtonColumn CEliminar = new DataGridViewButtonColumn();
                CEliminar.Name = "CEliminar";
                CEliminar.HeaderText = "Acción 2";
                CEliminar.Text = "Desactivar";
                CEliminar.UseColumnTextForButtonValue = true;
                dgv.Columns.Add(CEliminar);
            }
        }

        // Método para configurar el Placeholder de un TextBox
        public static void ConfigurarPlaceholder(TextBox txt, string placeholderTexto)
        {
            // Estado inicial
            if (string.IsNullOrWhiteSpace(txt.Text))
            {
                txt.Text = placeholderTexto;
                txt.ForeColor = Color.Gray;
            }

            // Evento cuando entra el cursor (Enter)
            txt.Enter += (sender, e) =>
            {
                if (txt.Text == placeholderTexto)
                {
                    txt.Text = "";
                    txt.ForeColor = Color.Black; 
                }
            };

            // Evento cuando sale el cursor (Leave)
            txt.Leave += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(txt.Text))
                {
                    txt.Text = placeholderTexto;
                    txt.ForeColor = Color.Gray;
                }
            };
        }

        public static void CargarComboEstados(ComboBox comboBox)
        {
            comboBox.Items.Clear();
            comboBox.Items.Add("Todos");
            comboBox.Items.Add("Activo");
            comboBox.Items.Add("Inactivo");
            comboBox.Items.Add("Finalizado");

            if (comboBox.Items.Count > 0)
                comboBox.SelectedIndex = 0; // Selecciona "Todos" por defecto
        }

        public static void CargarComboEstados2(ComboBox comboBox)
        {
            comboBox.Items.Clear();
            comboBox.Items.Add("Todos");
            comboBox.Items.Add("Activo");
            comboBox.Items.Add("Inactivo");

            if (comboBox.Items.Count > 0)
                comboBox.SelectedIndex = 0; // Selecciona "Todos" por defecto
        }

        internal static void ConfigurarCabeceraResponsiva(Label label1, Label label2, Label lFecha)
        {
            throw new NotImplementedException();
        }

        public static void AplicarEstiloOscuroGrafico(Chart chart)
        {
            // Color de fondo general del control Chart (puedes ajustar el tono morado/oscuro a tu gusto)
            Color fondoOscuro = Color.FromArgb(30, 25, 45); // Un tono morado oscuro muy elegante
            Color textoBlanco = Color.White;
            Color grisSuave = Color.FromArgb(80, 75, 95);   // Para las líneas de la cuadrícula

            chart.BackColor = fondoOscuro;
            chart.BackSecondaryColor = fondoOscuro;

            // Fondo del área interna del gráfico (donde se dibujan las barras/torta)
            if (chart.ChartAreas.Count > 0)
            {
                chart.ChartAreas[0].BackColor = fondoOscuro;

                // Color de los textos y números en los ejes X e Y
                chart.ChartAreas[0].AxisX.LabelStyle.ForeColor = textoBlanco;
                chart.ChartAreas[0].AxisY.LabelStyle.ForeColor = textoBlanco;

                // Títulos de los ejes (si los tienes)
                chart.ChartAreas[0].AxisX.TitleForeColor = textoBlanco;
                chart.ChartAreas[0].AxisY.TitleForeColor = textoBlanco;

                // Líneas de los ejes
                chart.ChartAreas[0].AxisX.LineColor = textoBlanco;
                chart.ChartAreas[0].AxisY.LineColor = textoBlanco;

                // Líneas de la cuadrícula (grilla) con un tono sutil para que no desentonen
                chart.ChartAreas[0].AxisX.MajorGrid.LineColor = grisSuave;
                chart.ChartAreas[0].AxisY.MajorGrid.LineColor = grisSuave;

               // Cambiar el color de los números/etiquetas de los valores dentro del gráfico a BLANCO 
                foreach (Series serie in chart.Series)
                {
                    serie.LabelForeColor = textoBlanco;
                }
            }

            // Color del título principal del gráfico
            foreach (Title titulo in chart.Titles)
            {
                titulo.ForeColor = textoBlanco;
            }

            // Color de las leyendas (el cuadro que dice "Entradas", "Beneficios", etc.)
            foreach (Legend leyenda in chart.Legends)
            {
                leyenda.ForeColor = textoBlanco;
                leyenda.BackColor = Color.Transparent;
            }
        }
    }
}
