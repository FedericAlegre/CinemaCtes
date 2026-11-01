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
    public partial class FormRegistrarVenta : Form
    {
        public FormRegistrarVenta()
        {
            InitializeComponent();
        }

        private void FormRegistrarVenta_Load(object sender, EventArgs e)
        {
            ClassEstilosHelper.AplicarEstiloTabla(DGVVentas);

            // Cargamos las películas activas y configuramos la fecha inicial
            CargarPeliculasBD();
            DTPFecha.Value = DateTime.Now.Date;

            // Cargamos los combos desde la Base de Datos
            CargarMetodosPagoBD();
            CargarBeneficiosBD();
            BloquearBeneficios(true);

            // Cargamos la grilla de ventas de prueba (maqueta) por ahora
            CargarGrillaVentasMaqueta();

            // Suscribimos los eventos de cambio para refrescar los horarios en tiempo real
            CBPelicula.SelectedIndexChanged += CBPelicula_SelectedIndexChanged;
            DTPFecha.ValueChanged += DTPFecha_ValueChanged;
        }

        // Cargar películas activas desde la Base de Datos
        private void CargarPeliculasBD()
        {
            ConexionBD conexionBD = new ConexionBD();
            try
            {
                using (SqlConnection conexion = conexionBD.ObtenerConexión())
                {
                    using (SqlCommand comando = new SqlCommand("SELECT id_pelicula, titulo FROM pelicula WHERE estado = 'Activo'", conexion))
                    {
                        using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                        {
                            DataTable dt = new DataTable();
                            adaptador.Fill(dt);

                            CBPelicula.DataSource = dt;
                            CBPelicula.DisplayMember = "titulo";
                            CBPelicula.ValueMember = "id_pelicula";
                            CBPelicula.SelectedIndex = -1; // Sin selección inicial para forzar al usuario a elegir
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las películas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Cargar horarios según la película y la fecha seleccionadas usando el SP
        private void CargarHorariosBD()
        {
            CBHorario.Items.Clear();

            // Validamos que haya una película seleccionada y que el valor sea un entero válido
            if (CBPelicula.SelectedValue == null || !int.TryParse(CBPelicula.SelectedValue.ToString(), out int idPelicula))
            {
                return;
            }

            DateTime fechaSeleccionada = DTPFecha.Value.Date;

            ConexionBD conexionBD = new ConexionBD();
            try
            {
                using (SqlConnection conexion = conexionBD.ObtenerConexión())
                {
                    using (SqlCommand comando = new SqlCommand("SP_ListarHorariosPorPeliculaYFecha", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.AddWithValue("@IdPelicula", idPelicula);
                        comando.Parameters.AddWithValue("@Fecha", fechaSeleccionada);

                        using (SqlDataReader lector = comando.ExecuteReader())
                        {
                            while (lector.Read())
                            {
                                // Agregamos el horario formateado (ej: "18:30")
                                CBHorario.Items.Add(lector["horario"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los horarios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (CBHorario.Items.Count > 0)
                CBHorario.SelectedIndex = 0;
        }

        // Cargar Métodos de Pago activos desde la Base de Datos
        private void CargarMetodosPagoBD()
        {
            ConexionBD conexionBD = new ConexionBD();
            try
            {
                using (SqlConnection conexion = conexionBD.ObtenerConexión())
                {
                    using (SqlCommand comando = new SqlCommand("SP_ListarMetodosPagoActivos", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                        {
                            DataTable dt = new DataTable();
                            adaptador.Fill(dt);

                            CBMetodoPago.DataSource = dt;
                            CBMetodoPago.DisplayMember = "descripcion";
                            CBMetodoPago.ValueMember = "id_metodo_pago";
                            if (CBMetodoPago.Items.Count > 0)
                                CBMetodoPago.SelectedIndex = 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los métodos de pago: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Cargar Beneficios activos desde la Base de Datos
        private void CargarBeneficiosBD()
        {
            ConexionBD conexionBD = new ConexionBD();
            try
            {
                using (SqlConnection conexion = conexionBD.ObtenerConexión())
                {
                    using (SqlCommand comando = new SqlCommand("SP_ListarBeneficiosActivos", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                        {
                            DataTable dt = new DataTable();
                            adaptador.Fill(dt);

                            // Opcional: Agregar una fila por defecto para cuando no aplica beneficio
                            DataRow row = dt.NewRow();
                            row["id_beneficio"] = DBNull.Value;
                            row["descripcion"] = "Ninguno";
                            dt.Rows.InsertAt(row, 0);

                            CBBeneficio.DataSource = dt;
                            CBBeneficio.DisplayMember = "descripcion";
                            CBBeneficio.ValueMember = "id_beneficio";
                            CBBeneficio.SelectedIndex = 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los beneficios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarGrillaVentasMaqueta()
        {
            DataTable dtVentas = new DataTable();
            dtVentas.Columns.Add("NroVenta", typeof(int));
            dtVentas.Columns.Add("butacas", typeof(string));
            dtVentas.Columns.Add("Monto Total", typeof(decimal));

            dtVentas.Rows.Add(101, "A1, A2", 9000.00m);
            dtVentas.Rows.Add(102, "B4", 4500.00m);
            dtVentas.Rows.Add(103, "C1, C2, C3", 13500.00m);

            DGVVentas.DataSource = dtVentas;
            DGVVentas.Columns["Monto Total"].DefaultCellStyle.Format = "C2";
        }

        // Eventos que refrescan los horarios al cambiar la película o la fecha
        private void CBPelicula_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarHorariosBD();
        }

        private void DTPFecha_ValueChanged(object sender, EventArgs e)
        {
            CargarHorariosBD();
        }

        private void BConfirmarVenta_Click(object sender, EventArgs e)
        {
            // (La lógica de confirmación de venta la dejamos intacta por ahora como pediste)
        }

        private void TDni_TextChanged(object sender, EventArgs e)
        {
            int cursorPosition = TDni.SelectionStart;
            string textoFiltrado = new string(TDni.Text.Where(char.IsDigit).ToArray());

            if (TDni.Text != textoFiltrado)
            {
                TDni.Text = textoFiltrado;
                TDni.SelectionStart = Math.Min(cursorPosition, TDni.Text.Length);
            }
        }

        private void TDni_Leave(object sender, EventArgs e)
        {
            string dniTexto = TDni.Text.Trim();

            // Si el campo está vacío, es un Consumidor Final anónimo
            if (string.IsNullOrEmpty(dniTexto))
            {
                BloquearBeneficios(true); // Bloqueamos beneficios porque requiere cliente registrado
                CalcularMontoTotal();
                return;
            }

            // Validamos longitud básica antes de consultar
            if (dniTexto.Length < 7 || dniTexto.Length > 8)
            {
                return;
            }

            ConexionBD conexionBD = new ConexionBD();
            try
            {
                using (SqlConnection conexion = conexionBD.ObtenerConexión())
                {
                    using (SqlCommand comando = new SqlCommand("SP_BuscarClientePorDni", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.AddWithValue("@Dni", Convert.ToInt32(dniTexto));

                        using (SqlDataReader lector = comando.ExecuteReader())
                        {
                            if (lector.Read())
                            {
                                // Cliente encontrado con éxito
                                string nombreCompleto = $"{lector["nombre"]} {lector["apellido"]}";
                                MessageBox.Show($"Cliente identificado: {nombreCompleto}", "Cliente Encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                BloquearBeneficios(false); // Habilitamos el combo de beneficios
                            }
                            else
                            {
                                // El usuario no existe -> Advertencia y bloqueo de beneficios
                                MessageBox.Show("No existe ningún usuario registrado con ese DNI.", "Cliente no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                BloquearBeneficios(true);
                                TDni.Focus(); // devuelve el foco para corregir o limpiar
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar el cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BloquearBeneficios(bool bloquear)
        {
            CBBeneficio.Enabled = !bloquear;
            if (bloquear)
            {
                CBBeneficio.SelectedIndex = 0; // Selecciona "Ninguno" por defecto
            }
        }

        private void BRegistrarCliente_Click(object sender, EventArgs e)
        {
            // Abrimos el formulario de registro de cliente como un diálogo modal
            using (FormRegistrarCliente formCliente = new FormRegistrarCliente())
            {
                DialogResult resultado = formCliente.ShowDialog();

                // Si el usuario guardó el cliente con éxito (DialogResult.OK)
                if (resultado == DialogResult.OK)
                {
                    // Autocompletamos el DNI en la caja de texto de ventas con el DNI que acaba de registrar
                    TDni.Text = formCliente.DniRegistrado;

                    TDni_Leave(TDni, EventArgs.Empty);
                }
            }
        }

        private void CalcularMontoTotal()
        {
            decimal precioBasePorButaca = 0.00m;
            ConexionBD conexionBD = new ConexionBD();

            // Obtenemos el precio base desde la tabla tarifa (Obligatorio, sin fallback hardcodeado)
            try
            {
                using (SqlConnection conexion = conexionBD.ObtenerConexión())
                {
                    string query = "SELECT TOP 1 precio_base FROM tarifa";
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        object resultado = comando.ExecuteScalar();
                        if (resultado != null && resultado != DBNull.Value)
                        {
                            precioBasePorButaca = Convert.ToDecimal(resultado);
                        }
                        else
                        {
                            MessageBox.Show("No se encontró ninguna tarifa configurada en el sistema.", "Error de Configuración", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            LMonto.Text = "$0,00";
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar con la base de datos para obtener el precio: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LMonto.Text = "$0,00";
                return;
            }

            // Contamos cuántas butacas hay seleccionadas en el CheckedListBox
            int cantidadButacasSeleccionadas = 0;
            foreach (var item in CLBButaca.CheckedItems)
            {
                cantidadButacasSeleccionadas++;
            }

            // Si no hay butacas, el total es 0 directamente
            if (cantidadButacasSeleccionadas == 0)
            {
                LMonto.Text = "$0,00";
                return;
            }

            decimal montoFinal = cantidadButacasSeleccionadas * precioBasePorButaca;
            string textoDescuento = "";

            // Si hay un beneficio seleccionado, consultamos su regla de descuento en la BD
            if (CBBeneficio.SelectedValue != null && int.TryParse(CBBeneficio.SelectedValue.ToString(), out int idBeneficio))
            {
                try
                {
                    using (SqlConnection conexion = conexionBD.ObtenerConexión())
                    {
                        string queryBeneficio = "SELECT descuento FROM beneficio WHERE id_beneficio = @IdBeneficio";
                        using (SqlCommand comando = new SqlCommand(queryBeneficio, conexion))
                        {
                            comando.Parameters.AddWithValue("@IdBeneficio", idBeneficio);
                            object resDesc = comando.ExecuteScalar();
                            if (resDesc != null && resDesc != DBNull.Value)
                            {
                                textoDescuento = resDesc.ToString().Trim().ToLower();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener el beneficio: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // Aplicamos la lógica según el tipo de descuento ("2x1" o porcentaje "XX%")
                if (textoDescuento == "2x1")
                {
                    // Lógica 2x1: Cada 2 entradas, se paga 1. 
                    int entradasAPagar = (cantidadButacasSeleccionadas / 2) + (cantidadButacasSeleccionadas % 2);
                    montoFinal = entradasAPagar * precioBasePorButaca;
                }
                else if (textoDescuento.EndsWith("%"))
                {
                    // Lógica Porcentual (ej: "20%")
                    string valorNumericoStr = textoDescuento.Replace("%", "").Trim();
                    if (decimal.TryParse(valorNumericoStr, out decimal porcentaje))
                    {
                        decimal subtotal = cantidadButacasSeleccionadas * precioBasePorButaca;
                        montoFinal = subtotal - (subtotal * (porcentaje / 100m));
                    }
                }
            }

            // Mostramos el resultado formateado como moneda en tu Label
            LMonto.Text = montoFinal.ToString("C2");
        }

        private void CLBButaca_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcularMontoTotal();
        }

        private void CBBeneficio_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcularMontoTotal();
        }
    }
}
