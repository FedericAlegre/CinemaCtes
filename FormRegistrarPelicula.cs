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
    public partial class FormRegistrarPelicula : Form
    {
        public string Titulo => TTitulo.Text.Trim();
        public int Duracion => int.TryParse(TDuracion.Text.Trim(), out int dur) ? dur : 0;
        public DateTime Desde => DTPDesde.Value;
        public DateTime Hasta => DTPHasta.Value;
        public string Sinopsis => RTBSinopsis.Text.Trim();

        public FormRegistrarPelicula()
        {
            InitializeComponent();
            DTPDesde.Value = DateTime.Now;
            DTPHasta.Value = DateTime.Now.AddDays(30);
        }

        private void FormRegistrarPelicula_Load(object sender, EventArgs e)
        {
            CargarCheckedListBoxEtiquetasBD();
        }

        // Exponemos una lista con los IDs de las etiquetas tildadas en el CheckedListBox
        public List<int> ObtenerEtiquetasSeleccionadas()
        {
            List<int> idsEtiquetas = new List<int>();

            foreach (DataRowView item in CLBEtiquetas.CheckedItems)
            {
                idsEtiquetas.ConvertAll(x => x);
                idsEtiquetas.Add(Convert.ToInt32(item["id_etiqueta"]));
            }

            return idsEtiquetas;
        }

        // Método para cargar el CheckedListBox usando el SP de etiquetas
        private void CargarCheckedListBoxEtiquetasBD()
        {
            ConexionBD conexionBD = new ConexionBD();
            try
            {
                using (SqlConnection conexion = conexionBD.ObtenerConexión())
                {
                    using (SqlCommand comando = new SqlCommand("SP_ListarEtiquetas", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;

                        using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                        {
                            DataTable dt = new DataTable();
                            adaptador.Fill(dt);

                            CLBEtiquetas.DataSource = dt;
                            CLBEtiquetas.DisplayMember = "descripcion";
                            CLBEtiquetas.ValueMember = "id_etiqueta";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las etiquetas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TDuracion_TextChanged(object sender, EventArgs e)
        {
            if (sender is TextBox txtBox)
            {
                int cursorPos = txtBox.SelectionStart;
                string soloNumeros = new string(txtBox.Text.Where(char.IsDigit).ToArray());

                if (txtBox.Text != soloNumeros)
                {
                    txtBox.Text = soloNumeros;
                    txtBox.SelectionStart = Math.Min(cursorPos, txtBox.Text.Length);
                }
            }
        }

        private void BInsertar_Click(object sender, EventArgs e)
        {
            if (!ClassValidacionesHelper.ValidarCampoVacio(TTitulo, "título")) return;
            if (!ClassValidacionesHelper.ValidarCampoVacio(TDuracion, "duracion")) return;
            if (!ClassValidacionesHelper.ValidarCampoVacio(RTBSinopsis, "sinopsis")) return;

            if (Duracion <= 0 || Duracion > 400)
            {
                MessageBox.Show("La duración debe ser mayor a 0 y menor a 400 minutos.", "Valor inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (DTPDesde.Value.Date < DateTime.Now.Date || DTPHasta.Value < DTPDesde.Value)
            {
                MessageBox.Show("Verifique que las fechas sean correctas.", "Fechas inválidas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validación del límite de etiquetas (mínimo 1, máximo 3)
            int cantidadSeleccionadas = CLBEtiquetas.CheckedItems.Count;
            if (cantidadSeleccionadas == 0)
            {
                MessageBox.Show("Debes seleccionar al menos una etiqueta.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cantidadSeleccionadas > 3)
            {
                MessageBox.Show("Solo puedes seleccionar un máximo de 3 etiquetas por película.", "Límite excedido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        public void CargarDatos(string titulo, int duracion, DateTime desde, DateTime hasta, string sinopsis)
        {
            TTitulo.Text = titulo;
            TDuracion.Text = duracion.ToString();
            TDuracion.Enabled = false; 
            DTPDesde.Value = desde;
            DTPHasta.Value = hasta;
            RTBSinopsis.Text = sinopsis;
            this.Text = "Modificar Película";
        }
    }
}