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

        // Clase auxiliar interna para manejar el ID y el Texto de forma 100% segura en el CheckedListBox
        private class ItemEtiqueta
        {
            public int Id { get; set; }
            public string Descripcion { get; set; }

            public override string ToString()
            {
                return Descripcion; // Esto es lo que mostrará visualmente el CheckedListBox
            }
        }

        // Exponemos una lista con los IDs de las etiquetas tildadas de forma totalmente segura
        public List<int> ObtenerEtiquetasSeleccionadas()
        {
            List<int> listaIds = new List<int>();

            foreach (var item in CLBEtiquetas.CheckedItems)
            {
                if (item is ItemEtiqueta etiqueta)
                {
                    listaIds.Add(etiqueta.Id);
                }
            }

            return listaIds;
        }

        private void CargarCheckedListBoxEtiquetasBD()
        {
            CLBEtiquetas.Items.Clear();
            ConexionBD conexionBD = new ConexionBD();

            try
            {
                using (SqlConnection conexion = conexionBD.ObtenerConexión())
                {
                    using (SqlCommand comando = new SqlCommand("SP_ListarEtiquetas", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader lector = comando.ExecuteReader())
                        {
                            while (lector.Read())
                            {
                                int idEtiqueta = Convert.ToInt32(lector["id_etiqueta"]);
                                string descripcion = lector["descripcion"].ToString();

                                // Añadimos nuestra clase auxiliar limpia
                                CLBEtiquetas.Items.Add(new ItemEtiqueta { Id = idEtiqueta, Descripcion = descripcion });
                            }
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
            try
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

                // Conteo manual y seguro de etiquetas tildadas
                int cantidadSeleccionadas = 0;
                for (int i = 0; i < CLBEtiquetas.Items.Count; i++)
                {
                    if (CLBEtiquetas.GetItemChecked(i))
                    {
                        cantidadSeleccionadas++;
                    }
                }

                // Validaciones estrictas
                if (cantidadSeleccionadas == 0)
                {
                    MessageBox.Show("Debes seleccionar al menos una etiqueta.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Frena aquí y NO se cierra
                }

                if (cantidadSeleccionadas > 3)
                {
                    MessageBox.Show("Solo puedes seleccionar un máximo de 3 etiquetas por película. (Seleccionaste: " + cantidadSeleccionadas + ")", "Límite excedido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Frena aquí y NO se cierra
                }

                // Si pasó las validaciones, recién aquí cerramos con OK
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                // Esto atrapará cualquier error oculto y te dirá exactamente qué línea o qué falló sin cerrar la ventana
                MessageBox.Show("Error interno en el formulario: " + ex.Message, "Excepción no controlada", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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