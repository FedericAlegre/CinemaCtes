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
    public partial class FormRegistrarBeneficio : Form
    {

        // Propiedades públicas para exponer los datos ingresados
        public string Descripcion => TDescripcion.Text;
        public string Descuento => TDescuento.Text;
        public int IdTipoBeneficio => Convert.ToInt32(CBTipo.SelectedValue); 

        public FormRegistrarBeneficio()
        {
            InitializeComponent();
        }

        private void FormRegistrarBeneficio_Load(object sender, EventArgs e)
        {
            CargarComboTipos();
        }

        private void CargarComboTipos()
        {
            ConexionBD conexionBD = new ConexionBD();
            try
            {
                using (SqlConnection conexion = conexionBD.ObtenerConexión())
                {
                    using (SqlCommand comando = new SqlCommand("SP_ListarTiposBeneficio", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;

                        using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                        {
                            DataTable dt = new DataTable();
                            adaptador.Fill(dt);

                            // Configuramos el ComboBox
                            CBTipo.DataSource = dt;
                            CBTipo.DisplayMember = "descripcion";     // Lo que ve el usuario
                            CBTipo.ValueMember = "id_tipo_beneficio"; // El ID oculto que se usará para la FK
                            CBTipo.SelectedIndex = -1;                // Opcional: Para que comience sin selección por defecto
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los tipos de beneficio: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BInsertar_Click(object sender, EventArgs e)
        {
            // Validar que la descripción no esté vacía
            if (!ClassValidacionesHelper.ValidarCampoVacio(TDescripcion, "descripción")) return;

            // Validar que el descuento tenga contenido (por ejemplo, "10%" o "2x1")
            if (!ClassValidacionesHelper.ValidarCampoVacio(TDescuento, "descuento")) return;

            // Validar seleccion para el tipo de descuento
            if (!ClassValidacionesHelper.ValidarComboBox(CBTipo, "un tipo de beneficio")) return;

            // Validar longitud mínima para la descripción
            if (TDescripcion.Text.Trim().Length < 5)
            {
                MessageBox.Show(
                    "La descripción debe tener al menos 5 caracteres.",
                    "Longitud de descripción inválida",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                TDescripcion.Focus();
                TDescripcion.SelectAll();
                return;
            }

            // asignamos el resultado OK y cerramos.
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        //Metodo para filtrar espacios en los textbox de descuento y descripcion
        private void LimpiarEspacios_TextChanged(object sender, EventArgs e)
        {
            // Convertimos el 'sender' al tipo TextBox para saber cuál control lo llamó
            if (sender is TextBox txtBox)
            {
                int cursorPos = txtBox.SelectionStart;
                string textoSinEspacios = txtBox.Text.Replace(" ", "");

                if (txtBox.Text != textoSinEspacios)
                {
                    txtBox.Text = textoSinEspacios;
                    txtBox.SelectionStart = Math.Max(0, cursorPos - 1);
                }
            }
        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            // Indicamos que el resultado de la ventana es Cancelar
            this.DialogResult = DialogResult.Cancel;

            // Cerramos el formulario de registro
            this.Close();
        }

        public void CargarDatos(string descripcion, string tipo, string descuento)
        {
            TDescripcion.Text = descripcion;
            TDescuento.Text = descuento;

            // Seleccionamos el tipo de beneficio en el ComboBox de forma segura buscando por texto
            CBTipo.Text = tipo;
            this.Text = "Modificar Beneficio";
        }
    }
}
