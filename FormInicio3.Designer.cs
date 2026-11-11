namespace CinemaCtes
{
    partial class FormInicio3
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblSaludo = new System.Windows.Forms.Label();
            this.pnlTotal = new System.Windows.Forms.Panel();
            this.LTotalRecaudado = new System.Windows.Forms.Label();
            this.lblTotalTitulo = new System.Windows.Forms.Label();
            this.lCartelera = new System.Windows.Forms.Label();
            this.dgvFunciones = new System.Windows.Forms.DataGridView();
            this.PHeader = new System.Windows.Forms.Panel();
            this.LFecha = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblCantidadVentas = new System.Windows.Forms.Label();
            this.LVentasRealizadas = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pnlTotal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFunciones)).BeginInit();
            this.PHeader.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSaludo
            // 
            this.lblSaludo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSaludo.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaludo.ForeColor = System.Drawing.Color.White;
            this.lblSaludo.Location = new System.Drawing.Point(282, 0);
            this.lblSaludo.Name = "lblSaludo";
            this.lblSaludo.Size = new System.Drawing.Size(273, 47);
            this.lblSaludo.TabIndex = 1;
            this.lblSaludo.Text = "¡Hola, Vendedor!";
            this.lblSaludo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pnlTotal
            // 
            this.pnlTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(55)))));
            this.pnlTotal.Controls.Add(this.LTotalRecaudado);
            this.pnlTotal.Controls.Add(this.lblTotalTitulo);
            this.pnlTotal.Location = new System.Drawing.Point(3, 100);
            this.pnlTotal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlTotal.Name = "pnlTotal";
            this.pnlTotal.Size = new System.Drawing.Size(273, 94);
            this.pnlTotal.TabIndex = 2;
            // 
            // LTotalRecaudado
            // 
            this.LTotalRecaudado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LTotalRecaudado.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTotalRecaudado.ForeColor = System.Drawing.Color.White;
            this.LTotalRecaudado.Location = new System.Drawing.Point(0, 21);
            this.LTotalRecaudado.Name = "LTotalRecaudado";
            this.LTotalRecaudado.Size = new System.Drawing.Size(273, 73);
            this.LTotalRecaudado.TabIndex = 3;
            this.LTotalRecaudado.Text = "$ 10000,00";
            this.LTotalRecaudado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LTotalRecaudado.Click += new System.EventHandler(this.LTotalRecaudado_Click);
            // 
            // lblTotalTitulo
            // 
            this.lblTotalTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTotalTitulo.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTotalTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTotalTitulo.Name = "lblTotalTitulo";
            this.lblTotalTitulo.Size = new System.Drawing.Size(273, 21);
            this.lblTotalTitulo.TabIndex = 3;
            this.lblTotalTitulo.Text = "TOTAL RECAUDADO HOY";
            this.lblTotalTitulo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblTotalTitulo.Click += new System.EventHandler(this.lblTotalTitulo_Click);
            // 
            // lCartelera
            // 
            this.lCartelera.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lCartelera.AutoSize = true;
            this.lCartelera.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lCartelera.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lCartelera.Location = new System.Drawing.Point(14, 326);
            this.lCartelera.Name = "lCartelera";
            this.lCartelera.Size = new System.Drawing.Size(414, 25);
            this.lCartelera.TabIndex = 4;
            this.lCartelera.Text = "Funciones Próximas a Iniciar (Cartelera Activa):";
            // 
            // dgvFunciones
            // 
            this.dgvFunciones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvFunciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFunciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFunciones.Location = new System.Drawing.Point(0, 353);
            this.dgvFunciones.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvFunciones.Name = "dgvFunciones";
            this.dgvFunciones.ReadOnly = true;
            this.dgvFunciones.RowHeadersVisible = false;
            this.dgvFunciones.RowHeadersWidth = 51;
            this.dgvFunciones.RowTemplate.Height = 24;
            this.dgvFunciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFunciones.Size = new System.Drawing.Size(979, 243);
            this.dgvFunciones.TabIndex = 5;
            // 
            // PHeader
            // 
            this.PHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
            this.PHeader.Controls.Add(this.LFecha);
            this.PHeader.Controls.Add(this.label2);
            this.PHeader.Controls.Add(this.label1);
            this.PHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.PHeader.Location = new System.Drawing.Point(0, 0);
            this.PHeader.Margin = new System.Windows.Forms.Padding(4);
            this.PHeader.Name = "PHeader";
            this.PHeader.Size = new System.Drawing.Size(979, 80);
            this.PHeader.TabIndex = 6;
            // 
            // LFecha
            // 
            this.LFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LFecha.AutoSize = true;
            this.LFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.LFecha.ForeColor = System.Drawing.Color.White;
            this.LFecha.Location = new System.Drawing.Point(691, 27);
            this.LFecha.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LFecha.Name = "LFecha";
            this.LFecha.Size = new System.Drawing.Size(57, 18);
            this.LFecha.TabIndex = 1;
            this.LFecha.Text = "[Fecha]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(16, 44);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Vista general - Dashboard";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(16, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(267, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "CinemaCtes - Panel Principal";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(55)))));
            this.panel1.Controls.Add(this.lblCantidadVentas);
            this.panel1.Controls.Add(this.LVentasRealizadas);
            this.panel1.Location = new System.Drawing.Point(561, 100);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(274, 94);
            this.panel1.TabIndex = 4;
            // 
            // lblCantidadVentas
            // 
            this.lblCantidadVentas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCantidadVentas.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidadVentas.ForeColor = System.Drawing.Color.White;
            this.lblCantidadVentas.Location = new System.Drawing.Point(0, 29);
            this.lblCantidadVentas.Name = "lblCantidadVentas";
            this.lblCantidadVentas.Size = new System.Drawing.Size(274, 65);
            this.lblCantidadVentas.TabIndex = 3;
            this.lblCantidadVentas.Text = "10";
            this.lblCantidadVentas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCantidadVentas.Click += new System.EventHandler(this.lblCantidadVentas_Click);
            // 
            // LVentasRealizadas
            // 
            this.LVentasRealizadas.Dock = System.Windows.Forms.DockStyle.Top;
            this.LVentasRealizadas.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LVentasRealizadas.ForeColor = System.Drawing.Color.White;
            this.LVentasRealizadas.Location = new System.Drawing.Point(0, 0);
            this.LVentasRealizadas.Name = "LVentasRealizadas";
            this.LVentasRealizadas.Size = new System.Drawing.Size(274, 29);
            this.LVentasRealizadas.TabIndex = 3;
            this.LVentasRealizadas.Text = "VENTAS REALIZADAS HOY";
            this.LVentasRealizadas.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.pnlTotal, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblSaludo, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(66, 87);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(838, 196);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // FormInicio3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(18)))), ((int)(((byte)(38)))));
            this.ClientSize = new System.Drawing.Size(979, 567);
            this.Controls.Add(this.lCartelera);
            this.Controls.Add(this.PHeader);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.dgvFunciones);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormInicio3";
            this.Text = "CineMaCtes - Panel de Venta";
            this.Load += new System.EventHandler(this.lblCartelera_Load);
            this.pnlTotal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFunciones)).EndInit();
            this.PHeader.ResumeLayout(false);
            this.PHeader.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblSaludo;
        private System.Windows.Forms.Panel pnlTotal;
        private System.Windows.Forms.Label lblTotalTitulo;
        private System.Windows.Forms.Label LTotalRecaudado;
        private System.Windows.Forms.Label lCartelera;
        private System.Windows.Forms.DataGridView dgvFunciones;
        private System.Windows.Forms.Panel PHeader;
        private System.Windows.Forms.Label LFecha;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblCantidadVentas;
        private System.Windows.Forms.Label LVentasRealizadas;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}

