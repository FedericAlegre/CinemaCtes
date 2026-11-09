namespace CinemaCtes
{
    partial class FormVentas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.PHeader = new System.Windows.Forms.Panel();
            this.BDashboardVentas = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BAñadir = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.CBBeneficio = new System.Windows.Forms.ComboBox();
            this.CBEstado = new System.Windows.Forms.ComboBox();
            this.LEstado = new System.Windows.Forms.Label();
            this.LPelicula = new System.Windows.Forms.Label();
            this.CBPelicula = new System.Windows.Forms.ComboBox();
            this.LHasta = new System.Windows.Forms.Label();
            this.DTPDesde = new System.Windows.Forms.DateTimePicker();
            this.TBuscar = new System.Windows.Forms.TextBox();
            this.LBeneficio = new System.Windows.Forms.Label();
            this.LDesde = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.DTPHasta = new System.Windows.Forms.DateTimePicker();
            this.LBuscar = new System.Windows.Forms.Label();
            this.DGVVentas = new System.Windows.Forms.DataGridView();
            this.CIdVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CDni = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CPelicula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CSala = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CBeneficio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CMonto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PHeader.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVVentas)).BeginInit();
            this.SuspendLayout();
            // 
            // PHeader
            // 
            this.PHeader.AutoScroll = true;
            this.PHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
            this.PHeader.Controls.Add(this.BDashboardVentas);
            this.PHeader.Controls.Add(this.panel1);
            this.PHeader.Controls.Add(this.BAñadir);
            this.PHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.PHeader.Location = new System.Drawing.Point(0, 0);
            this.PHeader.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PHeader.Name = "PHeader";
            this.PHeader.Size = new System.Drawing.Size(882, 78);
            this.PHeader.TabIndex = 3;
            this.PHeader.Paint += new System.Windows.Forms.PaintEventHandler(this.PHeader_Paint);
            // 
            // BDashboardVentas
            // 
            this.BDashboardVentas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BDashboardVentas.BackColor = System.Drawing.Color.AliceBlue;
            this.BDashboardVentas.Location = new System.Drawing.Point(431, 33);
            this.BDashboardVentas.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.BDashboardVentas.Name = "BDashboardVentas";
            this.BDashboardVentas.Size = new System.Drawing.Size(197, 33);
            this.BDashboardVentas.TabIndex = 3;
            this.BDashboardVentas.Text = "Dashboard de ventas";
            this.BDashboardVentas.UseVisualStyleBackColor = false;
            this.BDashboardVentas.Click += new System.EventHandler(this.BDashboardVentas_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(16, 15);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(410, 59);
            this.panel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(5, 4);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(398, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Historial General de Ventas y Transacciones";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(3, 36);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(227, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Administra beneficios y promociones";
            // 
            // BAñadir
            // 
            this.BAñadir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BAñadir.BackColor = System.Drawing.Color.AliceBlue;
            this.BAñadir.Location = new System.Drawing.Point(663, 33);
            this.BAñadir.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.BAñadir.Name = "BAñadir";
            this.BAñadir.Size = new System.Drawing.Size(197, 33);
            this.BAñadir.TabIndex = 1;
            this.BAñadir.Text = "Modificar precio de boletos";
            this.BAñadir.UseVisualStyleBackColor = false;
            this.BAñadir.Click += new System.EventHandler(this.BtnModificarPrecios_Click);
            // 
            // panel3
            // 
            this.panel3.AutoScroll = true;
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(18)))), ((int)(((byte)(38)))));
            this.panel3.Controls.Add(this.tableLayoutPanel1);
            this.panel3.Controls.Add(this.LBuscar);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 78);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(882, 135);
            this.panel3.TabIndex = 4;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.CBBeneficio, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.CBEstado, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.LEstado, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.LPelicula, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.CBPelicula, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.LHasta, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.DTPDesde, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.TBuscar, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.LBeneficio, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.LDesde, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.DTPHasta, 1, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(16, -1);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(850, 132);
            this.tableLayoutPanel1.TabIndex = 12;
            // 
            // CBBeneficio
            // 
            this.CBBeneficio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CBBeneficio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBBeneficio.FormattingEnabled = true;
            this.CBBeneficio.Items.AddRange(new object[] {
            "Todos",
            "Promoción",
            "Descuento"});
            this.CBBeneficio.Location = new System.Drawing.Point(343, 35);
            this.CBBeneficio.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CBBeneficio.Name = "CBBeneficio";
            this.CBBeneficio.Size = new System.Drawing.Size(164, 24);
            this.CBBeneficio.TabIndex = 5;
            this.CBBeneficio.SelectedIndexChanged += new System.EventHandler(this.CBBeneficio_SelectedIndexChanged);
            // 
            // CBEstado
            // 
            this.CBEstado.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CBEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBEstado.FormattingEnabled = true;
            this.CBEstado.Items.AddRange(new object[] {
            "Todos",
            "Activo",
            "Inactivo"});
            this.CBEstado.Location = new System.Drawing.Point(683, 35);
            this.CBEstado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CBEstado.Name = "CBEstado";
            this.CBEstado.Size = new System.Drawing.Size(164, 24);
            this.CBEstado.TabIndex = 1;
            this.CBEstado.SelectedIndexChanged += new System.EventHandler(this.CBEstado_SelectedIndexChanged);
            // 
            // LEstado
            // 
            this.LEstado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.LEstado.AutoSize = true;
            this.LEstado.ForeColor = System.Drawing.Color.White;
            this.LEstado.Location = new System.Drawing.Point(683, 10);
            this.LEstado.Margin = new System.Windows.Forms.Padding(3, 5, 3, 2);
            this.LEstado.MinimumSize = new System.Drawing.Size(147, 0);
            this.LEstado.Name = "LEstado";
            this.LEstado.Size = new System.Drawing.Size(164, 16);
            this.LEstado.TabIndex = 4;
            this.LEstado.Text = "Estado";
            // 
            // LPelicula
            // 
            this.LPelicula.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.LPelicula.AutoSize = true;
            this.LPelicula.ForeColor = System.Drawing.Color.White;
            this.LPelicula.Location = new System.Drawing.Point(513, 10);
            this.LPelicula.Margin = new System.Windows.Forms.Padding(3, 5, 3, 2);
            this.LPelicula.MinimumSize = new System.Drawing.Size(147, 0);
            this.LPelicula.Name = "LPelicula";
            this.LPelicula.Size = new System.Drawing.Size(164, 16);
            this.LPelicula.TabIndex = 3;
            this.LPelicula.Text = "Pelicula";
            this.LPelicula.Click += new System.EventHandler(this.LPelicula_Click);
            // 
            // CBPelicula
            // 
            this.CBPelicula.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CBPelicula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBPelicula.FormattingEnabled = true;
            this.CBPelicula.Items.AddRange(new object[] {
            "Todos",
            "Promoción",
            "Descuento"});
            this.CBPelicula.Location = new System.Drawing.Point(513, 35);
            this.CBPelicula.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CBPelicula.Name = "CBPelicula";
            this.CBPelicula.Size = new System.Drawing.Size(164, 24);
            this.CBPelicula.TabIndex = 2;
            this.CBPelicula.SelectedIndexChanged += new System.EventHandler(this.CBPelicula_SelectedIndexChanged);
            // 
            // LHasta
            // 
            this.LHasta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.LHasta.AutoSize = true;
            this.LHasta.ForeColor = System.Drawing.Color.White;
            this.LHasta.Location = new System.Drawing.Point(173, 76);
            this.LHasta.Margin = new System.Windows.Forms.Padding(3, 5, 3, 2);
            this.LHasta.MinimumSize = new System.Drawing.Size(147, 0);
            this.LHasta.Name = "LHasta";
            this.LHasta.Size = new System.Drawing.Size(164, 16);
            this.LHasta.TabIndex = 10;
            this.LHasta.Text = "Hasta";
            // 
            // DTPDesde
            // 
            this.DTPDesde.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DTPDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTPDesde.Location = new System.Drawing.Point(173, 35);
            this.DTPDesde.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DTPDesde.MinimumSize = new System.Drawing.Size(4, 4);
            this.DTPDesde.Name = "DTPDesde";
            this.DTPDesde.Size = new System.Drawing.Size(164, 22);
            this.DTPDesde.TabIndex = 9;
            this.DTPDesde.ValueChanged += new System.EventHandler(this.DTPDesde_ValueChanged);
            // 
            // TBuscar
            // 
            this.TBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TBuscar.ForeColor = System.Drawing.Color.Black;
            this.TBuscar.Location = new System.Drawing.Point(3, 35);
            this.TBuscar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TBuscar.Name = "TBuscar";
            this.TBuscar.Size = new System.Drawing.Size(164, 22);
            this.TBuscar.TabIndex = 0;
            this.TBuscar.TextChanged += new System.EventHandler(this.TBuscar_TextChanged);
            // 
            // LBeneficio
            // 
            this.LBeneficio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.LBeneficio.AutoSize = true;
            this.LBeneficio.ForeColor = System.Drawing.Color.White;
            this.LBeneficio.Location = new System.Drawing.Point(343, 10);
            this.LBeneficio.Margin = new System.Windows.Forms.Padding(3, 5, 3, 2);
            this.LBeneficio.MinimumSize = new System.Drawing.Size(147, 0);
            this.LBeneficio.Name = "LBeneficio";
            this.LBeneficio.Size = new System.Drawing.Size(164, 16);
            this.LBeneficio.TabIndex = 6;
            this.LBeneficio.Text = "Beneficio";
            // 
            // LDesde
            // 
            this.LDesde.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.LDesde.AutoSize = true;
            this.LDesde.ForeColor = System.Drawing.Color.White;
            this.LDesde.Location = new System.Drawing.Point(173, 10);
            this.LDesde.Margin = new System.Windows.Forms.Padding(3, 5, 3, 2);
            this.LDesde.MinimumSize = new System.Drawing.Size(147, 0);
            this.LDesde.Name = "LDesde";
            this.LDesde.Size = new System.Drawing.Size(164, 16);
            this.LDesde.TabIndex = 8;
            this.LDesde.Text = "Desde";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(3, 10);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 5, 3, 2);
            this.label3.MinimumSize = new System.Drawing.Size(147, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(164, 16);
            this.label3.TabIndex = 12;
            this.label3.Text = "DNI";
            // 
            // DTPHasta
            // 
            this.DTPHasta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DTPHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTPHasta.Location = new System.Drawing.Point(173, 101);
            this.DTPHasta.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DTPHasta.Name = "DTPHasta";
            this.DTPHasta.Size = new System.Drawing.Size(164, 22);
            this.DTPHasta.TabIndex = 11;
            this.DTPHasta.ValueChanged += new System.EventHandler(this.DTPHasta_ValueChanged);
            // 
            // LBuscar
            // 
            this.LBuscar.Location = new System.Drawing.Point(-4, 0);
            this.LBuscar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBuscar.Name = "LBuscar";
            this.LBuscar.Size = new System.Drawing.Size(133, 28);
            this.LBuscar.TabIndex = 0;
            // 
            // DGVVentas
            // 
            this.DGVVentas.AllowUserToAddRows = false;
            this.DGVVentas.AllowUserToDeleteRows = false;
            this.DGVVentas.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(18)))), ((int)(((byte)(38)))));
            this.DGVVentas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(27)))), ((int)(((byte)(56)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVVentas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DGVVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVVentas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CIdVenta,
            this.CFecha,
            this.CDni,
            this.CPelicula,
            this.CSala,
            this.CBeneficio,
            this.CMonto,
            this.CEstado});
            this.DGVVentas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVVentas.EnableHeadersVisualStyles = false;
            this.DGVVentas.Location = new System.Drawing.Point(0, 213);
            this.DGVVentas.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.DGVVentas.Name = "DGVVentas";
            this.DGVVentas.ReadOnly = true;
            this.DGVVentas.RowHeadersVisible = false;
            this.DGVVentas.RowHeadersWidth = 51;
            this.DGVVentas.Size = new System.Drawing.Size(882, 245);
            this.DGVVentas.TabIndex = 5;
            this.DGVVentas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVVentas_CellClick);
            // 
            // CIdVenta
            // 
            this.CIdVenta.HeaderText = "Nro Venta";
            this.CIdVenta.MinimumWidth = 6;
            this.CIdVenta.Name = "CIdVenta";
            this.CIdVenta.ReadOnly = true;
            this.CIdVenta.Width = 110;
            // 
            // CFecha
            // 
            this.CFecha.HeaderText = "Fecha/Hora";
            this.CFecha.MinimumWidth = 6;
            this.CFecha.Name = "CFecha";
            this.CFecha.ReadOnly = true;
            this.CFecha.Width = 110;
            // 
            // CDni
            // 
            this.CDni.HeaderText = "DNI Cliente";
            this.CDni.MinimumWidth = 6;
            this.CDni.Name = "CDni";
            this.CDni.ReadOnly = true;
            this.CDni.Width = 107;
            // 
            // CPelicula
            // 
            this.CPelicula.HeaderText = "Pelicula";
            this.CPelicula.MinimumWidth = 6;
            this.CPelicula.Name = "CPelicula";
            this.CPelicula.ReadOnly = true;
            this.CPelicula.Width = 111;
            // 
            // CSala
            // 
            this.CSala.HeaderText = "Sala";
            this.CSala.MinimumWidth = 6;
            this.CSala.Name = "CSala";
            this.CSala.ReadOnly = true;
            this.CSala.Width = 111;
            // 
            // CBeneficio
            // 
            this.CBeneficio.HeaderText = "Beneficio";
            this.CBeneficio.MinimumWidth = 6;
            this.CBeneficio.Name = "CBeneficio";
            this.CBeneficio.ReadOnly = true;
            this.CBeneficio.Width = 111;
            // 
            // CMonto
            // 
            this.CMonto.HeaderText = "Monto Total";
            this.CMonto.MinimumWidth = 6;
            this.CMonto.Name = "CMonto";
            this.CMonto.ReadOnly = true;
            this.CMonto.Width = 110;
            // 
            // CEstado
            // 
            this.CEstado.HeaderText = "Estado";
            this.CEstado.MinimumWidth = 6;
            this.CEstado.Name = "CEstado";
            this.CEstado.ReadOnly = true;
            this.CEstado.Width = 111;
            // 
            // FormVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(882, 458);
            this.Controls.Add(this.DGVVentas);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.PHeader);
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.MinimumSize = new System.Drawing.Size(900, 450);
            this.Name = "FormVentas";
            this.Text = "FormVentas";
            this.Load += new System.EventHandler(this.FormVentas_Load);
            this.PHeader.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVVentas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PHeader;
        private System.Windows.Forms.Button BAñadir;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label LBuscar;
        private System.Windows.Forms.Label LEstado;
        private System.Windows.Forms.Label LPelicula;
        private System.Windows.Forms.ComboBox CBPelicula;
        private System.Windows.Forms.ComboBox CBEstado;
        private System.Windows.Forms.Label LDesde;
        private System.Windows.Forms.Label LBeneficio;
        private System.Windows.Forms.ComboBox CBBeneficio;
        private System.Windows.Forms.DataGridView DGVVentas;
        private System.Windows.Forms.DataGridViewTextBoxColumn CIdVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn CFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn CDni;
        private System.Windows.Forms.DataGridViewTextBoxColumn CPelicula;
        private System.Windows.Forms.DataGridViewTextBoxColumn CSala;
        private System.Windows.Forms.DataGridViewTextBoxColumn CBeneficio;
        private System.Windows.Forms.DataGridViewTextBoxColumn CMonto;
        private System.Windows.Forms.DateTimePicker DTPDesde;
        private System.Windows.Forms.DataGridViewTextBoxColumn CEstado;
        private System.Windows.Forms.Label LHasta;
        private System.Windows.Forms.DateTimePicker DTPHasta;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox TBuscar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BDashboardVentas;
    }
}