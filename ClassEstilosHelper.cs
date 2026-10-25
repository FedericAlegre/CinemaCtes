using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CinemaCtes
{
    public static class ClassEstilosHelper
    {
        // Método para aplicar un estilo uniforme a los DataGridView
        public static void AplicarEstiloTabla(DataGridView dgv)
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

            // Estilo de encabezados
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.ColumnHeadersHeight = 38;
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
    }
}
