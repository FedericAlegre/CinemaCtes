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
            this.pnlTotal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFunciones)).BeginInit();
            this.PHeader.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSaludo
            // 
            this.lblSaludo.AutoSize = true;
            this.lblSaludo.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaludo.ForeColor = System.Drawing.Color.White;
            this.lblSaludo.Location = new System.Drawing.Point(272, 83);
            this.lblSaludo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSaludo.Name = "lblSaludo";
            this.lblSaludo.Size = new System.Drawing.Size(177, 30);
            this.lblSaludo.TabIndex = 1;
            this.lblSaludo.Text = "¡Hola, Vendedor!";
            // 
            // pnlTotal
            // 
            this.pnlTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(55)))));
            this.pnlTotal.Controls.Add(this.LTotalRecaudado);
            this.pnlTotal.Controls.Add(this.lblTotalTitulo);
            this.pnlTotal.Location = new System.Drawing.Point(44, 125);
            this.pnlTotal.Margin = new System.Windows.Forms.Padding(2);
            this.pnlTotal.Name = "pnlTotal";
            this.pnlTotal.Size = new System.Drawing.Size(165, 57);
            this.pnlTotal.TabIndex = 2;
            // 
            // LTotalRecaudado
            // 
            this.LTotalRecaudado.AutoSize = true;
            this.LTotalRecaudado.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTotalRecaudado.ForeColor = System.Drawing.Color.White;
            this.LTotalRecaudado.Location = new System.Drawing.Point(18, 21);
            this.LTotalRecaudado.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LTotalRecaudado.Name = "LTotalRecaudado";
            this.LTotalRecaudado.Size = new System.Drawing.Size(129, 30);
            this.LTotalRecaudado.TabIndex = 3;
            this.LTotalRecaudado.Text = "$ 10000,00";
            // 
            // lblTotalTitulo
            // 
            this.lblTotalTitulo.AutoSize = true;
            this.lblTotalTitulo.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTotalTitulo.Location = new System.Drawing.Point(10, 7);
            this.lblTotalTitulo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalTitulo.Name = "lblTotalTitulo";
            this.lblTotalTitulo.Size = new System.Drawing.Size(137, 13);
            this.lblTotalTitulo.TabIndex = 3;
            this.lblTotalTitulo.Text = "TOTAL RECAUDADO HOY";
            // 
            // lCartelera
            // 
            this.lCartelera.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lCartelera.AutoSize = true;
            this.lCartelera.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lCartelera.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lCartelera.Location = new System.Drawing.Point(12, 213);
            this.lCartelera.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lCartelera.Name = "lCartelera";
            this.lCartelera.Size = new System.Drawing.Size(338, 20);
            this.lCartelera.TabIndex = 4;
            this.lCartelera.Text = "Funciones Próximas a Iniciar (Cartelera Activa):";
            // 
            // dgvFunciones
            // 
            this.dgvFunciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFunciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFunciones.Location = new System.Drawing.Point(0, 235);
            this.dgvFunciones.Margin = new System.Windows.Forms.Padding(2);
            this.dgvFunciones.Name = "dgvFunciones";
            this.dgvFunciones.ReadOnly = true;
            this.dgvFunciones.RowHeadersVisible = false;
            this.dgvFunciones.RowHeadersWidth = 51;
            this.dgvFunciones.RowTemplate.Height = 24;
            this.dgvFunciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFunciones.Size = new System.Drawing.Size(734, 226);
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
            this.PHeader.Name = "PHeader";
            this.PHeader.Size = new System.Drawing.Size(734, 65);
            this.PHeader.TabIndex = 6;
            // 
            // LFecha
            // 
            this.LFecha.AutoSize = true;
            this.LFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.LFecha.ForeColor = System.Drawing.Color.White;
            this.LFecha.Location = new System.Drawing.Point(512, 21);
            this.LFecha.Name = "LFecha";
            this.LFecha.Size = new System.Drawing.Size(47, 15);
            this.LFecha.TabIndex = 1;
            this.LFecha.Text = "[Fecha]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Vista general - Dashboard";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "CinemaCtes - Panel Principal";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(55)))));
            this.panel1.Controls.Add(this.lblCantidadVentas);
            this.panel1.Controls.Add(this.LVentasRealizadas);
            this.panel1.Location = new System.Drawing.Point(504, 125);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(165, 57);
            this.panel1.TabIndex = 4;
            // 
            // lblCantidadVentas
            // 
            this.lblCantidadVentas.AutoSize = true;
            this.lblCantidadVentas.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidadVentas.ForeColor = System.Drawing.Color.White;
            this.lblCantidadVentas.Location = new System.Drawing.Point(64, 22);
            this.lblCantidadVentas.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCantidadVentas.Name = "lblCantidadVentas";
            this.lblCantidadVentas.Size = new System.Drawing.Size(39, 30);
            this.lblCantidadVentas.TabIndex = 3;
            this.lblCantidadVentas.Text = "10";
            // 
            // LVentasRealizadas
            // 
            this.LVentasRealizadas.AutoSize = true;
            this.LVentasRealizadas.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LVentasRealizadas.ForeColor = System.Drawing.Color.White;
            this.LVentasRealizadas.Location = new System.Drawing.Point(10, 7);
            this.LVentasRealizadas.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LVentasRealizadas.Name = "LVentasRealizadas";
            this.LVentasRealizadas.Size = new System.Drawing.Size(144, 13);
            this.LVentasRealizadas.TabIndex = 3;
            this.LVentasRealizadas.Text = "VENTAS REALIZADAS HOY";
            // 
            // FormInicio3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(18)))), ((int)(((byte)(38)))));
            this.ClientSize = new System.Drawing.Size(734, 461);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.PHeader);
            this.Controls.Add(this.dgvFunciones);
            this.Controls.Add(this.lCartelera);
            this.Controls.Add(this.pnlTotal);
            this.Controls.Add(this.lblSaludo);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormInicio3";
            this.Text = "CineMaCtes - Panel de Venta";
            this.Load += new System.EventHandler(this.lblCartelera_Load);
            this.pnlTotal.ResumeLayout(false);
            this.pnlTotal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFunciones)).EndInit();
            this.PHeader.ResumeLayout(false);
            this.PHeader.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
    }
}

