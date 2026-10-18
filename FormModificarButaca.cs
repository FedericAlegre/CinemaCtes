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
    public partial class FormModificarButaca : Form
    {
        public FormModificarButaca()
        {
            InitializeComponent();
        }

        private void FormModificarButaca_Load(object sender, EventArgs e)
        {
            CargarComboSalasBD();
        }

        //Cargar el ComboBox con las salas disponibles
        private void CargarComboSalasBD()
        {
            ConexionBD conexionBD = new ConexionBD();
            try
            {
                using (SqlConnection conexion = conexionBD.ObtenerConexión())
                {
                    // Asumiendo que tenés una tabla 'sala' con un campo 'nro_sala' o similar
                    using (SqlCommand comando = new SqlCommand("SELECT nro_sala FROM sala", conexion))
                    {
                        using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                        {
                            DataTable dt = new DataTable();
                            adaptador.Fill(dt);

                            CBSala.DataSource = dt;
                            CBSala.DisplayMember = "nro_sala";
                            CBSala.ValueMember = "nro_sala";
                            CBSala.SelectedIndex = -1; // Sin selección inicial
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las salas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Al cambiar de sala, cargamos las butacas correspondientes en el CheckedListBox
        private void CBSala_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBSala.SelectedValue != null && int.TryParse(CBSala.SelectedValue.ToString(), out int nroSala))
            {
                CargarButacasPorSala(nroSala);
            }
        }

        private void CargarButacasPorSala(int nroSala)
        {
            CLBButacas.Items.Clear();
            ConexionBD conexionBD = new ConexionBD();

            try
            {
                using (SqlConnection conexion = conexionBD.ObtenerConexión())
                {
                    using (SqlCommand comando = new SqlCommand("SP_ListarButacasPorSala", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.AddWithValue("@NroSala", nroSala);

                        using (SqlDataReader lector = comando.ExecuteReader())
                        {
                            while (lector.Read())
                            {
                                int idButaca = Convert.ToInt32(lector["id_butaca"]);
                                string codigoButaca = lector["codigo_butaca"].ToString(); // Ej: "A1"
                                string estado = lector["estado"].ToString();             // "Activo" o "Inactivo"

                                // Creamos un objeto o elemento visual para el CheckedListBox
                                ItemButaca item = new ItemButaca
                                {
                                    IdButaca = idButaca,
                                    Codigo = codigoButaca,
                                    EstadoActual = estado
                                };

                                // Añadimos al CheckedListBox
                                int index = CLBButacas.Items.Add(item);

                                // Si la butaca está Activa, la dejamos tildada por defecto
                                if (estado.Equals("Activo", StringComparison.OrdinalIgnoreCase))
                                {
                                    CLBButacas.SetItemChecked(index, true);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las butacas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Botón Confirmar: Alterna/Actualiza los estados según el estado de los checks
        private void BConfirmar_Click(object sender, EventArgs e)
        {
            if (CBSala.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar una sala.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Recorremos todos los elementos del CheckedListBox para separar cuáles quedan Activos y cuáles Inactivos
            var idsActivos = new System.Collections.Generic.List<string>();
            var idsInactivos = new System.Collections.Generic.List<string>();

            foreach (var item in CLBButacas.Items)
            {
                if (item is ItemButaca butaca)
                {
                    // Verificamos si el ítem está tildado en el control
                    bool estaTildado = CLBButacas.GetItemChecked(CLBButacas.Items.IndexOf(butaca));

                    if (estaTildado)
                        idsActivos.Add(butaca.IdButaca.ToString());
                    else
                        idsInactivos.Add(butaca.IdButaca.ToString());
                }
            }

            ConexionBD conexionBD = new ConexionBD();
            try
            {
                using (SqlConnection conexion = conexionBD.ObtenerConexión())
                {
                    // Actualizamos las que pasaron a Activo
                    if (idsActivos.Count > 0)
                    {
                        using (SqlCommand cmdActivar = new SqlCommand("SP_ActualizarEstadoButacasMasivo", conexion))
                        {
                            cmdActivar.CommandType = CommandType.StoredProcedure;
                            cmdActivar.Parameters.AddWithValue("@IdsButacas", string.Join(",", idsActivos));
                            cmdActivar.Parameters.AddWithValue("@NuevoEstado", "Activo");
                            cmdActivar.ExecuteNonQuery();
                        }
                    }

                    // Actualizamos las que pasaron a Inactivo
                    if (idsInactivos.Count > 0)
                    {
                        using (SqlCommand cmdInactivar = new SqlCommand("SP_ActualizarEstadoButacasMasivo", conexion))
                        {
                            cmdInactivar.CommandType = CommandType.StoredProcedure;
                            cmdInactivar.Parameters.AddWithValue("@IdsButacas", string.Join(",", idsInactivos));
                            cmdInactivar.Parameters.AddWithValue("@NuevoEstado", "Inactivo");
                            cmdInactivar.ExecuteNonQuery();
                        }
                    }
                }

                MessageBox.Show("Estados de las butacas actualizados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar las butacas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }

    // Clase auxiliar para manejar los datos dentro del CheckedListBox de forma limpia
    public class ItemButaca
    {
        public int IdButaca { get; set; }
        public string Codigo { get; set; }
        public string EstadoActual { get; set; }

        public override string ToString()
        {
            // Esto es lo que se va a mostrar visualmente en el CheckedListBox: "A1 (Activo)"
            return $"{Codigo} ({EstadoActual})";
        }
    }
}
