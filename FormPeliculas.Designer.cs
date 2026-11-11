namespace CinemaCtes
{
    partial class FormPeliculas
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
            this.BAñadir = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.LHasta = new System.Windows.Forms.Label();
            this.DTPHasta = new System.Windows.Forms.DateTimePicker();
            this.DTPDesde = new System.Windows.Forms.DateTimePicker();
            this.LDesde = new System.Windows.Forms.Label();
            this.LBuscar = new System.Windows.Forms.Label();
            this.LEstado = new System.Windows.Forms.Label();
            this.LEtiqueta = new System.Windows.Forms.Label();
            this.CBEtiqueta = new System.Windows.Forms.ComboBox();
            this.CBEstado = new System.Windows.Forms.ComboBox();
            this.TBuscar = new System.Windows.Forms.TextBox();
            this.DGVPeliculas = new System.Windows.Forms.DataGridView();
            this.CTitulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CDuracion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CSinopsis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CDesde = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CHasta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CEtiqueta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CIdPelicula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.PHeader.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVPeliculas)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PHeader
            // 
            this.PHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
            this.PHeader.Controls.Add(this.BAñadir);
            this.PHeader.Controls.Add(this.label2);
            this.PHeader.Controls.Add(this.label1);
            this.PHeader.Location = new System.Drawing.Point(0, 0);
            this.PHeader.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PHeader.Name = "PHeader";
            this.PHeader.Size = new System.Drawing.Size(979, 80);
            this.PHeader.TabIndex = 3;
            this.PHeader.Paint += new System.Windows.Forms.PaintEventHandler(this.PHeader_Paint);
            // 
            // BAñadir
            // 
            this.BAñadir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BAñadir.BackColor = System.Drawing.Color.AliceBlue;
            this.BAñadir.Location = new System.Drawing.Point(812, 27);
            this.BAñadir.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BAñadir.Name = "BAñadir";
            this.BAñadir.Size = new System.Drawing.Size(151, 33);
            this.BAñadir.TabIndex = 1;
            this.BAñadir.Text = "Añadir pelicula";
            this.BAñadir.UseVisualStyleBackColor = false;
            this.BAñadir.Click += new System.EventHandler(this.BAnadirPelicula_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(16, 44);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(251, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Administra catálogo general de peliculas";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(16, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Gestión Peliculas";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(18)))), ((int)(((byte)(38)))));
            this.panel3.Controls.Add(this.tableLayoutPanel1);
            this.panel3.Controls.Add(this.LBuscar);
            this.panel3.Location = new System.Drawing.Point(0, 80);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(979, 77);
            this.panel3.TabIndex = 4;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // LHasta
            // 
            this.LHasta.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LHasta.AutoSize = true;
            this.LHasta.ForeColor = System.Drawing.Color.White;
            this.LHasta.Location = new System.Drawing.Point(380, 0);
            this.LHasta.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LHasta.Name = "LHasta";
            this.LHasta.Size = new System.Drawing.Size(180, 20);
            this.LHasta.TabIndex = 14;
            this.LHasta.Text = "Hasta";
            // 
            // DTPHasta
            // 
            this.DTPHasta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DTPHasta.Location = new System.Drawing.Point(380, 24);
            this.DTPHasta.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DTPHasta.Name = "DTPHasta";
            this.DTPHasta.Size = new System.Drawing.Size(180, 22);
            this.DTPHasta.TabIndex = 13;
            this.DTPHasta.ValueChanged += new System.EventHandler(this.DTPHasta_ValueChanged);
            // 
            // DTPDesde
            // 
            this.DTPDesde.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DTPDesde.Location = new System.Drawing.Point(192, 24);
            this.DTPDesde.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DTPDesde.Name = "DTPDesde";
            this.DTPDesde.Size = new System.Drawing.Size(180, 22);
            this.DTPDesde.TabIndex = 12;
            this.DTPDesde.ValueChanged += new System.EventHandler(this.DTPDesde_ValueChanged);
            // 
            // LDesde
            // 
            this.LDesde.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LDesde.AutoSize = true;
            this.LDesde.ForeColor = System.Drawing.Color.White;
            this.LDesde.Location = new System.Drawing.Point(192, 0);
            this.LDesde.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LDesde.Name = "LDesde";
            this.LDesde.Size = new System.Drawing.Size(180, 20);
            this.LDesde.TabIndex = 11;
            this.LDesde.Text = "Desde";
            // 
            // LBuscar
            // 
            this.LBuscar.Location = new System.Drawing.Point(-4, 0);
            this.LBuscar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBuscar.Name = "LBuscar";
            this.LBuscar.Size = new System.Drawing.Size(133, 28);
            this.LBuscar.TabIndex = 0;
            // 
            // LEstado
            // 
            this.LEstado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LEstado.AutoSize = true;
            this.LEstado.ForeColor = System.Drawing.Color.White;
            this.LEstado.Location = new System.Drawing.Point(756, 0);
            this.LEstado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LEstado.Name = "LEstado";
            this.LEstado.Size = new System.Drawing.Size(184, 20);
            this.LEstado.TabIndex = 4;
            this.LEstado.Text = "Estado";
            // 
            // LEtiqueta
            // 
            this.LEtiqueta.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LEtiqueta.AutoSize = true;
            this.LEtiqueta.ForeColor = System.Drawing.Color.White;
            this.LEtiqueta.Location = new System.Drawing.Point(568, 0);
            this.LEtiqueta.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LEtiqueta.Name = "LEtiqueta";
            this.LEtiqueta.Size = new System.Drawing.Size(180, 20);
            this.LEtiqueta.TabIndex = 3;
            this.LEtiqueta.Text = "Etiqueta";
            // 
            // CBEtiqueta
            // 
            this.CBEtiqueta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CBEtiqueta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBEtiqueta.FormattingEnabled = true;
            this.CBEtiqueta.Items.AddRange(new object[] {
            "Todos",
            "Promoción",
            "Descuento"});
            this.CBEtiqueta.Location = new System.Drawing.Point(568, 24);
            this.CBEtiqueta.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CBEtiqueta.Name = "CBEtiqueta";
            this.CBEtiqueta.Size = new System.Drawing.Size(180, 24);
            this.CBEtiqueta.TabIndex = 2;
            this.CBEtiqueta.SelectedIndexChanged += new System.EventHandler(this.CBEtiqueta_SelectedIndexChanged);
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
            this.CBEstado.Location = new System.Drawing.Point(756, 24);
            this.CBEstado.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CBEstado.Name = "CBEstado";
            this.CBEstado.Size = new System.Drawing.Size(184, 24);
            this.CBEstado.TabIndex = 1;
            this.CBEstado.SelectedIndexChanged += new System.EventHandler(this.CBEstado_SelectedIndexChanged);
            // 
            // TBuscar
            // 
            this.TBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TBuscar.ForeColor = System.Drawing.Color.Black;
            this.TBuscar.Location = new System.Drawing.Point(4, 24);
            this.TBuscar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TBuscar.Name = "TBuscar";
            this.TBuscar.Size = new System.Drawing.Size(180, 22);
            this.TBuscar.TabIndex = 0;
            this.TBuscar.TextChanged += new System.EventHandler(this.TBuscar_TextChanged);
            // 
            // DGVPeliculas
            // 
            this.DGVPeliculas.AllowUserToAddRows = false;
            this.DGVPeliculas.AllowUserToDeleteRows = false;
            this.DGVPeliculas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGVPeliculas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVPeliculas.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(18)))), ((int)(((byte)(38)))));
            this.DGVPeliculas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(27)))), ((int)(((byte)(56)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVPeliculas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DGVPeliculas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVPeliculas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CTitulo,
            this.CDuracion,
            this.CSinopsis,
            this.CDesde,
            this.CHasta,
            this.CEtiqueta,
            this.CEstado,
            this.CIdPelicula});
            this.DGVPeliculas.EnableHeadersVisualStyles = false;
            this.DGVPeliculas.Location = new System.Drawing.Point(-1, 156);
            this.DGVPeliculas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DGVPeliculas.Name = "DGVPeliculas";
            this.DGVPeliculas.ReadOnly = true;
            this.DGVPeliculas.RowHeadersWidth = 51;
            this.DGVPeliculas.Size = new System.Drawing.Size(979, 425);
            this.DGVPeliculas.TabIndex = 5;
            this.DGVPeliculas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVPeliculas_CellContentClick);
            // 
            // CTitulo
            // 
            this.CTitulo.HeaderText = "Titulo";
            this.CTitulo.MinimumWidth = 6;
            this.CTitulo.Name = "CTitulo";
            this.CTitulo.ReadOnly = true;
            // 
            // CDuracion
            // 
            this.CDuracion.HeaderText = "Duracion";
            this.CDuracion.MinimumWidth = 6;
            this.CDuracion.Name = "CDuracion";
            this.CDuracion.ReadOnly = true;
            // 
            // CSinopsis
            // 
            this.CSinopsis.HeaderText = "Sinopsis";
            this.CSinopsis.MinimumWidth = 6;
            this.CSinopsis.Name = "CSinopsis";
            this.CSinopsis.ReadOnly = true;
            // 
            // CDesde
            // 
            this.CDesde.HeaderText = "Desde";
            this.CDesde.MinimumWidth = 6;
            this.CDesde.Name = "CDesde";
            this.CDesde.ReadOnly = true;
            // 
            // CHasta
            // 
            this.CHasta.HeaderText = "Hasta";
            this.CHasta.MinimumWidth = 6;
            this.CHasta.Name = "CHasta";
            this.CHasta.ReadOnly = true;
            // 
            // CEtiqueta
            // 
            this.CEtiqueta.HeaderText = "Etiqueta";
            this.CEtiqueta.MinimumWidth = 6;
            this.CEtiqueta.Name = "CEtiqueta";
            this.CEtiqueta.ReadOnly = true;
            // 
            // CEstado
            // 
            this.CEstado.HeaderText = "Estado";
            this.CEstado.MinimumWidth = 6;
            this.CEstado.Name = "CEstado";
            this.CEstado.ReadOnly = true;
            // 
            // CIdPelicula
            // 
            this.CIdPelicula.HeaderText = "IdPelicula";
            this.CIdPelicula.MinimumWidth = 6;
            this.CIdPelicula.Name = "CIdPelicula";
            this.CIdPelicula.ReadOnly = true;
            this.CIdPelicula.Visible = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(18)))), ((int)(((byte)(38)))));
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.TBuscar, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.DTPHasta, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.CBEstado, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.LEstado, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.LHasta, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.CBEtiqueta, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.LEtiqueta, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.LDesde, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.DTPDesde, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(19, 7);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 66.66666F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(944, 62);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // FormPeliculas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 567);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.PHeader);
            this.Controls.Add(this.DGVPeliculas);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormPeliculas";
            this.Text = "FormPeliculas";
            this.Load += new System.EventHandler(this.FormPeliculas_Load);
            this.PHeader.ResumeLayout(false);
            this.PHeader.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVPeliculas)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
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
        private System.Windows.Forms.Label LEtiqueta;
        private System.Windows.Forms.ComboBox CBEtiqueta;
        private System.Windows.Forms.ComboBox CBEstado;
        private System.Windows.Forms.TextBox TBuscar;
        private System.Windows.Forms.DataGridView DGVPeliculas;
        private System.Windows.Forms.DataGridViewTextBoxColumn CTitulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CDuracion;
        private System.Windows.Forms.DataGridViewTextBoxColumn CSinopsis;
        private System.Windows.Forms.DataGridViewTextBoxColumn CDesde;
        private System.Windows.Forms.DataGridViewTextBoxColumn CHasta;
        private System.Windows.Forms.DataGridViewTextBoxColumn CEtiqueta;
        private System.Windows.Forms.DataGridViewTextBoxColumn CEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn CIdPelicula;
        private System.Windows.Forms.Label LHasta;
        private System.Windows.Forms.DateTimePicker DTPHasta;
        private System.Windows.Forms.DateTimePicker DTPDesde;
        private System.Windows.Forms.Label LDesde;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}