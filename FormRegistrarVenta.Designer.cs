namespace CinemaCtes
{
    partial class FormRegistrarVenta
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CBPelicula = new System.Windows.Forms.ComboBox();
            this.CLBButaca = new System.Windows.Forms.CheckedListBox();
            this.PHeader = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BAñadir = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.LBeneficio = new System.Windows.Forms.Label();
            this.CBBeneficio = new System.Windows.Forms.ComboBox();
            this.BAgregar = new System.Windows.Forms.Button();
            this.CLBCarrito = new System.Windows.Forms.CheckedListBox();
            this.LCarrito = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.LDni = new System.Windows.Forms.Label();
            this.TDni = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.LMetodoPago = new System.Windows.Forms.Label();
            this.CBMetodoPago = new System.Windows.Forms.ComboBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.LFecha = new System.Windows.Forms.Label();
            this.DTPFecha = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.LHorario = new System.Windows.Forms.Label();
            this.CBHorario = new System.Windows.Forms.ComboBox();
            this.LButaca = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LPelicula = new System.Windows.Forms.Label();
            this.BRegistrarCliente = new System.Windows.Forms.Button();
            this.LMonto = new System.Windows.Forms.Label();
            this.DGVVentas = new System.Windows.Forms.DataGridView();
            this.PHeader.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVVentas)).BeginInit();
            this.SuspendLayout();
            // 
            // CBPelicula
            // 
            this.CBPelicula.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CBPelicula.FormattingEnabled = true;
            this.CBPelicula.Location = new System.Drawing.Point(9, 24);
            this.CBPelicula.Margin = new System.Windows.Forms.Padding(4);
            this.CBPelicula.Name = "CBPelicula";
            this.CBPelicula.Size = new System.Drawing.Size(152, 24);
            this.CBPelicula.TabIndex = 0;
            this.CBPelicula.SelectedIndexChanged += new System.EventHandler(this.CBPelicula_SelectedIndexChanged_1);
            // 
            // CLBButaca
            // 
            this.CLBButaca.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CLBButaca.FormattingEnabled = true;
            this.CLBButaca.Location = new System.Drawing.Point(393, 84);
            this.CLBButaca.Margin = new System.Windows.Forms.Padding(4);
            this.CLBButaca.Name = "CLBButaca";
            this.CLBButaca.Size = new System.Drawing.Size(202, 72);
            this.CLBButaca.TabIndex = 2;
            this.CLBButaca.SelectedIndexChanged += new System.EventHandler(this.CLBButaca_SelectedIndexChanged);
            // 
            // PHeader
            // 
            this.PHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
            this.PHeader.Controls.Add(this.label2);
            this.PHeader.Controls.Add(this.label1);
            this.PHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.PHeader.Location = new System.Drawing.Point(0, 0);
            this.PHeader.Margin = new System.Windows.Forms.Padding(4);
            this.PHeader.Name = "PHeader";
            this.PHeader.Size = new System.Drawing.Size(979, 80);
            this.PHeader.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(16, 44);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(208, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Registra y consulta ventas del dia";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(16, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Registro de Ventas";
            // 
            // BAñadir
            // 
            this.BAñadir.BackColor = System.Drawing.Color.AliceBlue;
            this.BAñadir.Location = new System.Drawing.Point(813, 164);
            this.BAñadir.Margin = new System.Windows.Forms.Padding(4);
            this.BAñadir.Name = "BAñadir";
            this.BAñadir.Size = new System.Drawing.Size(138, 33);
            this.BAñadir.TabIndex = 1;
            this.BAñadir.Text = "Registrar venta";
            this.BAñadir.UseVisualStyleBackColor = false;
            this.BAñadir.Click += new System.EventHandler(this.BConfirmarVenta_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(18)))), ((int)(((byte)(38)))));
            this.panel3.Controls.Add(this.tableLayoutPanel1);
            this.panel3.Controls.Add(this.LMonto);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 80);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(979, 281);
            this.panel3.TabIndex = 5;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.Controls.Add(this.panel7, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.BAgregar, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.CLBCarrito, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.LCarrito, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.BAñadir, 5, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel6, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel5, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.LButaca, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.CLBButaca, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.BRegistrarCliente, 2, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 7);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(955, 241);
            this.tableLayoutPanel1.TabIndex = 23;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.LBeneficio);
            this.panel7.Controls.Add(this.CBBeneficio);
            this.panel7.Location = new System.Drawing.Point(174, 163);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(165, 75);
            this.panel7.TabIndex = 24;
            // 
            // LBeneficio
            // 
            this.LBeneficio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LBeneficio.ForeColor = System.Drawing.Color.White;
            this.LBeneficio.Location = new System.Drawing.Point(40, 9);
            this.LBeneficio.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.LBeneficio.Name = "LBeneficio";
            this.LBeneficio.Size = new System.Drawing.Size(100, 20);
            this.LBeneficio.TabIndex = 14;
            this.LBeneficio.Text = "Beneficio";
            this.LBeneficio.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.LBeneficio.Click += new System.EventHandler(this.LBeneficio_Click);
            // 
            // CBBeneficio
            // 
            this.CBBeneficio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CBBeneficio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBBeneficio.FormattingEnabled = true;
            this.CBBeneficio.Location = new System.Drawing.Point(15, 35);
            this.CBBeneficio.Margin = new System.Windows.Forms.Padding(4);
            this.CBBeneficio.Name = "CBBeneficio";
            this.CBBeneficio.Size = new System.Drawing.Size(148, 24);
            this.CBBeneficio.TabIndex = 13;
            this.CBBeneficio.SelectedIndexChanged += new System.EventHandler(this.CBBeneficio_SelectedIndexChanged);
            // 
            // BAgregar
            // 
            this.BAgregar.BackColor = System.Drawing.Color.AliceBlue;
            this.BAgregar.Location = new System.Drawing.Point(813, 84);
            this.BAgregar.Margin = new System.Windows.Forms.Padding(4);
            this.BAgregar.Name = "BAgregar";
            this.BAgregar.Size = new System.Drawing.Size(138, 33);
            this.BAgregar.TabIndex = 21;
            this.BAgregar.Text = "Agregar al carro";
            this.BAgregar.UseVisualStyleBackColor = false;
            this.BAgregar.Click += new System.EventHandler(this.BAgregar_Click);
            // 
            // CLBCarrito
            // 
            this.CLBCarrito.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CLBCarrito.FormattingEnabled = true;
            this.CLBCarrito.Location = new System.Drawing.Point(603, 84);
            this.CLBCarrito.Margin = new System.Windows.Forms.Padding(4);
            this.CLBCarrito.Name = "CLBCarrito";
            this.CLBCarrito.Size = new System.Drawing.Size(202, 72);
            this.CLBCarrito.TabIndex = 22;
            this.CLBCarrito.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.CLBCarrito_ItemCheck);
            this.CLBCarrito.SelectedIndexChanged += new System.EventHandler(this.CLBCarrito_SelectedIndexChanged);
            // 
            // LCarrito
            // 
            this.LCarrito.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LCarrito.AutoSize = true;
            this.LCarrito.ForeColor = System.Drawing.Color.White;
            this.LCarrito.Location = new System.Drawing.Point(603, 64);
            this.LCarrito.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LCarrito.Name = "LCarrito";
            this.LCarrito.Size = new System.Drawing.Size(46, 16);
            this.LCarrito.TabIndex = 19;
            this.LCarrito.Text = "Carrito";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.LDni);
            this.panel6.Controls.Add(this.TDni);
            this.panel6.Location = new System.Drawing.Point(174, 83);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(165, 74);
            this.panel6.TabIndex = 24;
            // 
            // LDni
            // 
            this.LDni.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LDni.ForeColor = System.Drawing.Color.White;
            this.LDni.Location = new System.Drawing.Point(40, 9);
            this.LDni.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.LDni.Name = "LDni";
            this.LDni.Size = new System.Drawing.Size(100, 20);
            this.LDni.TabIndex = 7;
            this.LDni.Text = "DNI";
            this.LDni.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // TDni
            // 
            this.TDni.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TDni.Location = new System.Drawing.Point(15, 34);
            this.TDni.Margin = new System.Windows.Forms.Padding(4);
            this.TDni.MaxLength = 8;
            this.TDni.Name = "TDni";
            this.TDni.Size = new System.Drawing.Size(146, 22);
            this.TDni.TabIndex = 16;
            this.TDni.TextChanged += new System.EventHandler(this.TDni_TextChanged);
            this.TDni.Leave += new System.EventHandler(this.TDni_Leave);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.LMetodoPago);
            this.panel5.Controls.Add(this.CBMetodoPago);
            this.panel5.Location = new System.Drawing.Point(3, 163);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(165, 75);
            this.panel5.TabIndex = 24;
            // 
            // LMetodoPago
            // 
            this.LMetodoPago.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LMetodoPago.ForeColor = System.Drawing.Color.White;
            this.LMetodoPago.Location = new System.Drawing.Point(22, 9);
            this.LMetodoPago.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.LMetodoPago.Name = "LMetodoPago";
            this.LMetodoPago.Size = new System.Drawing.Size(121, 24);
            this.LMetodoPago.TabIndex = 15;
            this.LMetodoPago.Text = "Metodo de Pago";
            this.LMetodoPago.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // CBMetodoPago
            // 
            this.CBMetodoPago.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CBMetodoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBMetodoPago.FormattingEnabled = true;
            this.CBMetodoPago.Location = new System.Drawing.Point(15, 34);
            this.CBMetodoPago.Margin = new System.Windows.Forms.Padding(4);
            this.CBMetodoPago.Name = "CBMetodoPago";
            this.CBMetodoPago.Size = new System.Drawing.Size(140, 24);
            this.CBMetodoPago.TabIndex = 12;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.LFecha);
            this.panel4.Controls.Add(this.DTPFecha);
            this.panel4.Location = new System.Drawing.Point(174, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(165, 74);
            this.panel4.TabIndex = 24;
            // 
            // LFecha
            // 
            this.LFecha.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LFecha.ForeColor = System.Drawing.Color.White;
            this.LFecha.Location = new System.Drawing.Point(40, 3);
            this.LFecha.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.LFecha.Name = "LFecha";
            this.LFecha.Size = new System.Drawing.Size(100, 20);
            this.LFecha.TabIndex = 10;
            this.LFecha.Text = "Fecha";
            this.LFecha.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // DTPFecha
            // 
            this.DTPFecha.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DTPFecha.Location = new System.Drawing.Point(9, 25);
            this.DTPFecha.Margin = new System.Windows.Forms.Padding(4);
            this.DTPFecha.Name = "DTPFecha";
            this.DTPFecha.Size = new System.Drawing.Size(154, 22);
            this.DTPFecha.TabIndex = 9;
            this.DTPFecha.ValueChanged += new System.EventHandler(this.DTPFecha_ValueChanged_1);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.LHorario);
            this.panel2.Controls.Add(this.CBHorario);
            this.panel2.Location = new System.Drawing.Point(3, 83);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(165, 74);
            this.panel2.TabIndex = 24;
            // 
            // LHorario
            // 
            this.LHorario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LHorario.ForeColor = System.Drawing.Color.White;
            this.LHorario.Location = new System.Drawing.Point(31, 7);
            this.LHorario.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.LHorario.Name = "LHorario";
            this.LHorario.Size = new System.Drawing.Size(100, 20);
            this.LHorario.TabIndex = 8;
            this.LHorario.Text = "Horario";
            this.LHorario.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // CBHorario
            // 
            this.CBHorario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CBHorario.FormattingEnabled = true;
            this.CBHorario.Location = new System.Drawing.Point(12, 31);
            this.CBHorario.Margin = new System.Windows.Forms.Padding(4);
            this.CBHorario.Name = "CBHorario";
            this.CBHorario.Size = new System.Drawing.Size(149, 24);
            this.CBHorario.TabIndex = 3;
            this.CBHorario.SelectedIndexChanged += new System.EventHandler(this.CBHorario_SelectedIndexChanged);
            // 
            // LButaca
            // 
            this.LButaca.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LButaca.AutoSize = true;
            this.LButaca.ForeColor = System.Drawing.Color.White;
            this.LButaca.Location = new System.Drawing.Point(393, 64);
            this.LButaca.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LButaca.Name = "LButaca";
            this.LButaca.Size = new System.Drawing.Size(122, 16);
            this.LButaca.TabIndex = 11;
            this.LButaca.Text = "Butaca disponibles";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.LPelicula);
            this.panel1.Controls.Add(this.CBPelicula);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(165, 74);
            this.panel1.TabIndex = 24;
            // 
            // LPelicula
            // 
            this.LPelicula.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LPelicula.ForeColor = System.Drawing.Color.White;
            this.LPelicula.Location = new System.Drawing.Point(31, 3);
            this.LPelicula.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.LPelicula.Name = "LPelicula";
            this.LPelicula.Size = new System.Drawing.Size(100, 20);
            this.LPelicula.TabIndex = 6;
            this.LPelicula.Text = "Pelicula";
            this.LPelicula.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // BRegistrarCliente
            // 
            this.BRegistrarCliente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BRegistrarCliente.BackColor = System.Drawing.Color.AliceBlue;
            this.BRegistrarCliente.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.BRegistrarCliente.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BRegistrarCliente.Location = new System.Drawing.Point(346, 84);
            this.BRegistrarCliente.Margin = new System.Windows.Forms.Padding(4);
            this.BRegistrarCliente.Name = "BRegistrarCliente";
            this.BRegistrarCliente.Size = new System.Drawing.Size(39, 55);
            this.BRegistrarCliente.TabIndex = 7;
            this.BRegistrarCliente.Text = "+";
            this.BRegistrarCliente.UseVisualStyleBackColor = false;
            this.BRegistrarCliente.Click += new System.EventHandler(this.BRegistrarCliente_Click);
            // 
            // LMonto
            // 
            this.LMonto.AutoSize = true;
            this.LMonto.ForeColor = System.Drawing.Color.White;
            this.LMonto.Location = new System.Drawing.Point(637, 185);
            this.LMonto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LMonto.Name = "LMonto";
            this.LMonto.Size = new System.Drawing.Size(0, 16);
            this.LMonto.TabIndex = 17;
            // 
            // DGVVentas
            // 
            this.DGVVentas.AllowUserToAddRows = false;
            this.DGVVentas.AllowUserToDeleteRows = false;
            this.DGVVentas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGVVentas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVVentas.Location = new System.Drawing.Point(0, 359);
            this.DGVVentas.Margin = new System.Windows.Forms.Padding(4);
            this.DGVVentas.Name = "DGVVentas";
            this.DGVVentas.ReadOnly = true;
            this.DGVVentas.RowHeadersWidth = 51;
            this.DGVVentas.Size = new System.Drawing.Size(979, 218);
            this.DGVVentas.TabIndex = 9;
            this.DGVVentas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVVentas_CellContentClick);
            // 
            // FormRegistrarVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 567);
            this.Controls.Add(this.DGVVentas);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.PHeader);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormRegistrarVenta";
            this.Text = "FormRegistrarVenta";
            this.Load += new System.EventHandler(this.FormRegistrarVenta_Load);
            this.PHeader.ResumeLayout(false);
            this.PHeader.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVVentas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox CBPelicula;
        private System.Windows.Forms.CheckedListBox CLBButaca;
        private System.Windows.Forms.Panel PHeader;
        private System.Windows.Forms.Button BAñadir;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView DGVVentas;
        private System.Windows.Forms.ComboBox CBHorario;
        private System.Windows.Forms.Label LHorario;
        private System.Windows.Forms.Label LDni;
        private System.Windows.Forms.Label LPelicula;
        private System.Windows.Forms.Label LFecha;
        private System.Windows.Forms.DateTimePicker DTPFecha;
        private System.Windows.Forms.Label LMetodoPago;
        private System.Windows.Forms.Label LBeneficio;
        private System.Windows.Forms.ComboBox CBBeneficio;
        private System.Windows.Forms.ComboBox CBMetodoPago;
        private System.Windows.Forms.Label LButaca;
        private System.Windows.Forms.TextBox TDni;
        private System.Windows.Forms.Button BRegistrarCliente;
        private System.Windows.Forms.Label LMonto;
        private System.Windows.Forms.Label LCarrito;
        private System.Windows.Forms.CheckedListBox CLBCarrito;
        private System.Windows.Forms.Button BAgregar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel7;
    }
}