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
    public partial class FormRegistroFuncion : Form
    {
        // Propiedades públicas para exponer los datos seleccionados al formulario principal

        // Obtenemos el ID de la película seleccionada mediante el ValueMember del ComboBox
        public int IdPeliculaSeleccionada => CBPelicula.SelectedValue != null && int.TryParse(CBPelicula.SelectedValue.ToString(), out int id) ? id : 0;

        public int NroSalaSeleccionada => int.TryParse(CBSala.SelectedItem?.ToString(), out int sala) ? sala : 0;

        public DateTime FechaInicioSeleccionada => DTPFecha.Value.Date;

        // Propiedad para obtener los horarios cargados en formato CSV listos para el SP 
        public string HorariosSeleccionadosCsv
        {
            get
            {
                List<string> lista = new List<string>();
                foreach (var item in LBHorarios.Items)
                {
                    lista.Add(item.ToString());
                }
                return string.Join(",", lista);
            }
        }

        public FormRegistroFuncion()
        {
            InitializeComponent();
        }

        private void FormRegistroFuncion_Load(object sender, EventArgs e)
        {
            CargarPeliculasBD();
            CargarSalasBD();

            DTPFecha.Value = DateTime.Now.Date;
            ActualizarEtiquetaRango();
        }

        // Cargar las películas activas desde la Base de Datos
        private void CargarPeliculasBD()
        {
            ConexionBD conexionBD = new ConexionBD();
            try
            {
                using (SqlConnection conexion = conexionBD.ObtenerConexión())
                {
                    // Listamos las películas para que el operador seleccione a cuál aplicarle los horarios
                    using (SqlCommand comando = new SqlCommand("SELECT id_pelicula, titulo FROM pelicula WHERE estado = 'Activo'", conexion))
                    {
                        using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                        {
                            DataTable dt = new DataTable();
                            adaptador.Fill(dt);

                            CBPelicula.DataSource = dt;
                            CBPelicula.DisplayMember = "titulo";
                            CBPelicula.ValueMember = "id_pelicula";
                            CBPelicula.SelectedIndex = -1;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las películas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Cargar las salas desde la Base de Datos usando nuestro helper o una consulta directa
        private void CargarSalasBD()
        {
            CBSala.Items.Clear();
            ConexionBD conexionBD = new ConexionBD();

            try
            {
                using (SqlConnection conexion = conexionBD.ObtenerConexión())
                {
                    using (SqlCommand comando = new SqlCommand("SP_ListarSalas", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader lector = comando.ExecuteReader())
                        {
                            while (lector.Read())
                            {
                                CBSala.Items.Add(lector["nro_sala"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las salas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (CBSala.Items.Count > 0)
                CBSala.SelectedIndex = 0;
        }

        // Botón para agregar un horario a la lista con validación de solapamiento
        private void BAñadir_Click(object sender, EventArgs e)
        {
            // Validar que se haya seleccionado una película antes de añadir horarios (necesitamos su duración)
            if (CBPelicula.SelectedValue == null || !int.TryParse(CBPelicula.SelectedValue.ToString(), out int idPelicula))
            {
                MessageBox.Show("Por favor, seleccione una película primero para calcular la duración de la función.", "Película requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar el límite máximo (ejemplo: máximo 4 horarios diarios)
            if (LBHorarios.Items.Count >= 4)
            {
                MessageBox.Show("Solo puedes configurar un máximo de 4 horarios por día.", "Límite alcanzado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Obtenemos la duración de la película desde la Base de Datos
            int duracionMinutos = 0;
            ConexionBD conexionBD = new ConexionBD();
            try
            {
                using (SqlConnection conexion = conexionBD.ObtenerConexión())
                {
                    using (SqlCommand comando = new SqlCommand("SELECT duracion FROM pelicula WHERE id_pelicula = @IdPelicula", conexion))
                    {
                        comando.Parameters.AddWithValue("@IdPelicula", idPelicula);
                        object resultado = comando.ExecuteScalar();
                        if (resultado != null)
                        {
                            duracionMinutos = Convert.ToInt32(resultado);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener la duración de la película: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Tomamos la hora del DateTimePicker de inicio
            TimeSpan horaNuevaInicio = DTPInicio.Value.TimeOfDay;
            TimeSpan horaNuevaFin = horaNuevaInicio.Add(TimeSpan.FromMinutes(duracionMinutos));

            string horaNuevaStr = DTPInicio.Value.ToString("HH:mm");

            // Evitar duplicados exactos en la lista
            if (LBHorarios.Items.Contains(horaNuevaStr))
            {
                MessageBox.Show("Ese horario ya fue agregado a la lista.", "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Validar solapamientos con los horarios ya cargados en el ListBox
            foreach (var item in LBHorarios.Items)
            {
                if (TimeSpan.TryParse(item.ToString(), out TimeSpan horaExistenteInicio))
                {
                    TimeSpan horaExistenteFin = horaExistenteInicio.Add(TimeSpan.FromMinutes(duracionMinutos));

                    // Lógica de solapamiento de intervalos de tiempo
                    bool seSolapan = (horaNuevaInicio < horaExistenteFin) && (horaNuevaFin > horaExistenteInicio);

                    if (seSolapan)
                    {
                        MessageBox.Show(
                            $"El horario ingresado ({horaNuevaStr}) se solapa con otra función ya agregada en la lista ({item.ToString()} - Fin estimado: {horaExistenteFin.ToString(@"hh\:mm")}).",
                            "Conflicto de horarios",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                        return;
                    }
                }
            }

            // Si pasa todas las validaciones, lo agregamos
            LBHorarios.Items.Add(horaNuevaStr);
        }

        // Evento del botón "Insertar" (Confirmar la generación masiva)
        private void BInsertar_Click(object sender, EventArgs e)
        {
            // Validaciones con corte de flujo si fallan
            if (!ClassValidacionesHelper.ValidarComboBox(CBPelicula, "Pelicula")) return;
            if (!ClassValidacionesHelper.ValidarComboBox(CBSala, "sala")) return;

            if (LBHorarios.Items.Count == 0)
            {
                MessageBox.Show("Debe agregar al menos un horario de función para la programación.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void BBorrar_Click(object sender, EventArgs e)
        {
            // Botón para eliminar el último horario agregado (Comportamiento de Pila / LIFO)
            if (LBHorarios.Items.Count > 0)
            {
                int ultimoIndice = LBHorarios.Items.Count - 1;
                string horaEliminada = LBHorarios.Items[ultimoIndice].ToString();

                LBHorarios.Items.RemoveAt(ultimoIndice);
            }
            else
            {
                MessageBox.Show("No hay horarios en la lista para eliminar.", "Lista vacía", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DTPFecha_ValueChanged(object sender, EventArgs e)
        {
            ActualizarEtiquetaRango();
        }

        private void ActualizarEtiquetaRango()
        {
            DateTime fechaInicio = DTPFecha.Value.Date;
            // Sumamos 6 días para completar los 7 días de la semana operativa (Jueves a Miércoles)
            DateTime fechaFin = fechaInicio.AddDays(6);

            // Mostramos el rango dinámico en el Label
            LblRangoCalculado.Text = $"Período: {fechaInicio.ToShortDateString()} al {fechaFin.ToShortDateString()} (7 días)";
        }
    }
}