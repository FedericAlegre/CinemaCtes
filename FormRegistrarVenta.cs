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

        private int? idClienteSeleccionado = null;

        private int idUsuarioActual;

        private decimal montoTotalActual = 0.00m;

        public FormRegistrarVenta(int idUsuario)
        {
            InitializeComponent();
            idUsuarioActual = idUsuario;
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
            DTPFecha.MinDate = DateTime.Now.Date;

            // Bloqueamos el boton de confirmar compra
            BAñadir.Enabled = false;
            CalcularMontoTotal();

            // Cargar ventas del dia
            CargarVentasDelDia();
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

        //Cargar butacas disponibles por función
        private void CargarButacasDisponibles()
        {
            CLBButaca.Items.Clear();

            if (CBPelicula.SelectedValue == null || CBHorario.SelectedValue == null)
                return;

            int idFuncion = 0;
            if (CBHorario.SelectedItem is DataRowView filaSeleccionada)
            {
                idFuncion = Convert.ToInt32(filaSeleccionada["id_funcion"]);
            }
            else if (!int.TryParse(CBHorario.SelectedValue.ToString(), out idFuncion))
            {
                return;
            }

            ConexionBD conexionBD = new ConexionBD();
            try
            {
                using (SqlConnection conexion = conexionBD.ObtenerConexión())
                {
                    using (SqlCommand comando = new SqlCommand("SP_ObtenerButacasDisponibles", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.AddWithValue("@id_funcion", idFuncion);

                        using (SqlDataReader lector = comando.ExecuteReader())
                        {
                            while (lector.Read())
                            {
                                int idButaca = Convert.ToInt32(lector["id_butaca"]);
                                string codigoButaca = lector["codigo_butaca"].ToString();

                                // Creamos el ítem corto para las disponibles
                                ItemButacaDisp itemDisp = new ItemButacaDisp()
                                {
                                    IdButaca = idButaca,
                                    IdFuncion = idFuncion,
                                    Codigo = codigoButaca
                                };

                                CLBButaca.Items.Add(itemDisp);
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

        // Cargar horarios según la película y la fecha seleccionadas usando el SP
        private void CargarHorariosBD()
        {
            // Validamos que haya una película seleccionada y que el valor sea un entero válido
            if (CBPelicula.SelectedValue == null || !int.TryParse(CBPelicula.SelectedValue.ToString(), out int idPelicula))
            {
                CBHorario.DataSource = null;
                CBHorario.Items.Clear();
                CBHorario.Enabled = false; // Desactivamos si no hay película válida
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

                        using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                        {
                            DataTable dtHorarios = new DataTable();
                            adaptador.Fill(dtHorarios);

                            // Verificamos si hay registros disponibles
                            if (dtHorarios.Rows.Count > 0)
                            {
                                // Si hay funciones, habilitamos el ComboBox y cargamos normalmente
                                CBHorario.Enabled = true;
                                CBHorario.DataSource = dtHorarios;
                                CBHorario.DisplayMember = "horario";    // Mostrará por ejemplo: "14:00 (Sala 1)"
                                CBHorario.ValueMember = "id_funcion";   // El id_funcion oculto
                                CBHorario.SelectedIndex = 0;
                            }
                            else
                            {
                                // Si no hay funciones, limpiamos y mostramos el mensaje de aviso
                                CBHorario.DataSource = null;
                                CBHorario.Items.Clear();

                                // Agregamos un item temporal o texto descriptivo y bloqueamos el control
                                CBHorario.Items.Add("No hay funciones próximas");
                                CBHorario.SelectedIndex = 0;
                                CBHorario.Enabled = false; // Bloquea el ComboBox para que no se pueda interactuar
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los horarios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        // Boton para registrar ventas
        private void BConfirmarVenta_Click(object sender, EventArgs e)
        {
            // Validaciones previas
            if (CLBCarrito.CheckedItems.Count == 0)
            {
                MessageBox.Show("El carrito está vacío o no hay elementos seleccionados.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (CBMetodoPago.SelectedValue == null)
            {
                MessageBox.Show("Por favor, selecciona un método de pago.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Preparamos el DataTable que simula el TipoDetalleBoleto de SQL
            DataTable dtDetalle = new DataTable();
            dtDetalle.Columns.Add("id_funcion", typeof(int));
            dtDetalle.Columns.Add("id_butaca", typeof(int));

            foreach (var item in CLBCarrito.CheckedItems)
            {
                if (item is ItemCarritoBoleto boletoItem)
                {
                    dtDetalle.Rows.Add(boletoItem.IdFuncion, boletoItem.IdButaca);
                }
            }

            int cantidadBoletos = dtDetalle.Rows.Count;

            // Obtenemos los valores de los controles del formulario
            int idMetodoPago = Convert.ToInt32(CBMetodoPago.SelectedValue);

            int? idBeneficio = null;
            if (CBBeneficio.SelectedValue != null && int.TryParse(CBBeneficio.SelectedValue.ToString(), out int beneficioVal))
            {
                idBeneficio = beneficioVal;
            }

            // Usamos el id_cliente real que capturamos cuando se validó el DNI (o null si es anónimo)
            int? idCliente = idClienteSeleccionado;

            // Usamos el id_usuario dinámico que vino por el constructor 
            int idUsuarioLogueado = idUsuarioActual;

            // Tomamos el monto total directamente de nuestra variable numérica segura (Adiós problemas de CultureInfo en PCs ajenas)
            decimal montoTotal = montoTotalActual;

            // Ejecución en la Base de Datos usando SqlClient
            ConexionBD conexionBD = new ConexionBD();
            try
            {
                using (SqlConnection conexion = conexionBD.ObtenerConexión())
                {
                    using (SqlCommand comando = new SqlCommand("SP_RegistrarVentaCompleta", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;

                        // Pasamos los parámetros requeridos
                        comando.Parameters.AddWithValue("@id_usuario", idUsuarioLogueado);
                        comando.Parameters.AddWithValue("@id_cliente", (object)idCliente ?? DBNull.Value);
                        comando.Parameters.AddWithValue("@id_metodo_pago", idMetodoPago);
                        comando.Parameters.AddWithValue("@id_beneficio", (object)idBeneficio ?? DBNull.Value);
                        comando.Parameters.AddWithValue("@monto_total", montoTotal);
                        comando.Parameters.AddWithValue("@cantidad", cantidadBoletos);

                        // Pasamos el DataTable como parámetro estructurado
                        SqlParameter paramDetalle = comando.Parameters.AddWithValue("@detalles", dtDetalle);
                        paramDetalle.SqlDbType = SqlDbType.Structured;
                        paramDetalle.TypeName = "TipoDetalleBoleto";

                        // Ejecutamos y obtenemos el ID de venta generado
                        object resultado = comando.ExecuteScalar();

                        if (resultado != null && resultado != DBNull.Value)
                        {
                            int idVentaGenerada = Convert.ToInt32(resultado);
                            MessageBox.Show($"¡Venta registrada con éxito!\nNro de Venta: {idVentaGenerada}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Abrimos el formulario de vista previa del ticket 
                            FormVistaPreviaTicket formTicket = new FormVistaPreviaTicket(idVentaGenerada);
                            formTicket.ShowDialog();

                            // Limpieza de la interfaz tras la venta exitosa
                            CLBCarrito.Items.Clear();
                            montoTotalActual = 0.00m;
                            LMonto.Text = "$0,00";
                            TDni.Clear();
                            idClienteSeleccionado = null; // Reseteamos el cliente para la siguiente venta
                            if (CBPelicula.Items.Count > 0) CBPelicula.SelectedIndex = -1;
                            if (CBHorario.Items.Count > 0) CBHorario.DataSource = null; // Limpia el combo de horarios
                            if (CBMetodoPago.Items.Count > 0) CBMetodoPago.SelectedIndex = -1;
                            if (CBBeneficio.Items.Count > 0) CBBeneficio.SelectedIndex = -1;
                            BloquearBeneficios(true);

                            // Refrescamos las butacas disponibles de la función actual para que se oculten las recién vendidas
                            CargarButacasDisponibles();

                            // Refrescamos la lista de ventas registradas
                            CargarVentasDelDia();

                            // Bloqueamos el boton de confirmar compra
                            BAñadir.Enabled = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar la venta: " + ex.Message, "Error crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                idClienteSeleccionado = null; // Limpiamos el ID por si antes tenía uno cargado
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
                                // Capturamos el id_cliente real de la tabla cliente
                                idClienteSeleccionado = Convert.ToInt32(lector["id_cliente"]);

                                // Cliente encontrado con éxito
                                string nombreCompleto = $"{lector["nombre"]} {lector["apellido"]}";
                                MessageBox.Show($"Cliente identificado: {nombreCompleto}", "Cliente Encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                BloquearBeneficios(false); // Habilitamos el combo de beneficios
                            }
                            else
                            {
                                // Si no existe, reseteamos el ID a null
                                idClienteSeleccionado = null;

                                // El cliente no existe -> Advertencia y bloqueo de beneficios
                                MessageBox.Show("No existe ningún cliente registrado con ese DNI.", "Cliente no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            // Obtenemos el precio base desde la tabla tarifa
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
                            montoTotalActual = 0.00m;
                            LMonto.Text = "$0,00";
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar con la base de datos para obtener el precio: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                montoTotalActual = 0.00m;
                LMonto.Text = "$0,00";
                return;
            }

            // Contamos cuántas butacas hay tildadas en el CARRITO
            int cantidadButacasSeleccionadas = 0;
            foreach (var item in CLBCarrito.CheckedItems)
            {
                cantidadButacasSeleccionadas++;
            }

            // Si no hay butacas en el carrito, el total es 0 directamente
            if (cantidadButacasSeleccionadas == 0)
            {
                montoTotalActual = 0.00m;
                LMonto.Text = "$0,00";
                return;
            }

            // Cálculo inicial estándar (Cantidad * Precio Base)
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

                // Aplicamos la lógica según el tipo de descuento
                if (textoDescuento == "2x1")
                {
                    int entradasAPagar = (cantidadButacasSeleccionadas / 2) + (cantidadButacasSeleccionadas % 2);
                    montoFinal = entradasAPagar * precioBasePorButaca;
                }
                else if (textoDescuento.EndsWith("%"))
                {
                    string valorNumericoStr = textoDescuento.Replace("%", "").Trim();
                    if (decimal.TryParse(valorNumericoStr, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out decimal porcentaje))
                    {
                        decimal subtotal = cantidadButacasSeleccionadas * precioBasePorButaca;
                        montoFinal = subtotal - (subtotal * (porcentaje / 100m));
                    }
                }
            }

            // Guardamos el valor numérico en la variable de clase
            montoTotalActual = montoFinal;

            // Mostramos el resultado formateado forzando la cultura de Argentina (evita que aparezcan Euros o puntos invertidos)
            System.Globalization.CultureInfo culturaAr = new System.Globalization.CultureInfo("es-AR");
            LMonto.Text = montoTotalActual.ToString("C2", culturaAr);
        }

        private void CLBButaca_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcularMontoTotal();
        }
        private void CBBeneficio_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcularMontoTotal();
        }

        private void BAgregar_Click(object sender, EventArgs e)
        {
            if (CLBButaca.CheckedItems.Count == 0)
            {
                MessageBox.Show("Por favor, selecciona al menos una butaca disponible.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nombrePelicula = CBPelicula.Text;
            string horaFuncion = CBHorario.Text;

            foreach (var item in CLBButaca.CheckedItems.Cast<object>().ToList())
            {
                ItemButacaDisp itemDisp = (ItemButacaDisp)item;

                // Verificamos si ya existe en el carrito
                bool yaExiste = false;
                foreach (var itemEnCarrito in CLBCarrito.Items)
                {
                    ItemCarritoBoleto carritoItem = (ItemCarritoBoleto)itemEnCarrito;
                    if (carritoItem.IdButaca == itemDisp.IdButaca && carritoItem.IdFuncion == itemDisp.IdFuncion)
                    {
                        yaExiste = true;
                        break;
                    }
                }

                if (!yaExiste)
                {
                    // Creamos el ítem con la información completa para el carrito
                    ItemCarritoBoleto itemCarrito = new ItemCarritoBoleto()
                    {
                        IdButaca = itemDisp.IdButaca,
                        IdFuncion = itemDisp.IdFuncion,
                        TextoCompleto = $"{itemDisp.Codigo} - {nombrePelicula} ({horaFuncion})"
                    };

                    int index = CLBCarrito.Items.Add(itemCarrito);
                    CLBCarrito.SetItemChecked(index, true);
                }
            }

            // Desmarcamos las disponibles
            for (int i = 0; i < CLBButaca.Items.Count; i++)
            {
                CLBButaca.SetItemChecked(i, false);
            }

            ActualizarEstadoYTotal();
        }

        private void ActualizarEstadoYTotal()
        {
            // Contamos solo los elementos que tienen el tilde puesto en el carrito
            int itemsTildadosEnCarrito = CLBCarrito.CheckedItems.Count;

            // Bloquea o desbloquea el botón de registrar venta según corresponda
            BAñadir.Enabled = (itemsTildadosEnCarrito > 0);

            // Llamamos a tu método de cálculo de monto, asegurándonos de que 
            CalcularMontoTotal();
        }

        private void CLBCarrito_ItemCheck(object sender, ItemCheckEventArgs e)
        {

            this.BeginInvoke((MethodInvoker)delegate {
                ActualizarEstadoYTotal();
            });
        }

        private void CLBCarrito_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarEstadoYTotal();
        }

        private void CBHorario_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarButacasDisponibles();
        }

        private void CBPelicula_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            // Limpiamos los horarios y butacas actuales antes de buscar los nuevos
            CBHorario.DataSource = null;
            CBHorario.Items.Clear();
            CLBButaca.Items.Clear();

            CargarHorariosBD();
        }

        private void DTPFecha_ValueChanged_1(object sender, EventArgs e)
        {
            // Limpiamos los horarios y butacas actuales al cambiar la fecha
            CBHorario.DataSource = null;
            CBHorario.Items.Clear();
            CLBButaca.Items.Clear();

            CargarHorariosBD();
        }

        private void CargarVentasDelDia()
        {
            ConexionBD conexionBD = new ConexionBD();
            try
            {
                using (SqlConnection conexion = conexionBD.ObtenerConexión())
                {
                    using (SqlCommand comando = new SqlCommand("SP_ListarVentasDelDiaPorUsuario", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        // Le pasamos el ID del cajero logueado actualmente
                        comando.Parameters.AddWithValue("@id_usuario", idUsuarioActual);

                        using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                        {
                            DataTable dtVentas = new DataTable();
                            adaptador.Fill(dtVentas);

                            // Asignamos el resultado al DataGridView de la interfaz
                            DGVVentas.DataSource = dtVentas;

                            // Ajustar formato de columnas
                            if (DGVVentas.Columns["Monto Total"] != null)
                            {
                                DGVVentas.Columns["Monto Total"].DefaultCellStyle.Format = "C2"; // Formato moneda
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las ventas del día: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LBeneficio_Click(object sender, EventArgs e)
        {

        }

        private void DGVVentas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

    // Clase simple solo para mostrar la butaca limpia en el selector
    public class ItemButacaDisp
    {
        public int IdButaca { get; set; }
        public int IdFuncion { get; set; }
        public string Codigo { get; set; }

        public override string ToString()
        {
            return Codigo; // Muestra solo "A1", "A2", etc.
        }
    }

    // Clase para el carrito, que muestra la información completa
    public class ItemCarritoBoleto
    {
        public int IdButaca { get; set; }
        public int IdFuncion { get; set; }
        public string TextoCompleto { get; set; } // Ej: "A1 - Película (18:30)"

        public override string ToString()
        {
            return TextoCompleto;
        }
    }


}
