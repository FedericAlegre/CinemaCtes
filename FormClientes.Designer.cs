namespace CinemaCtes
{
    partial class FormClientes
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.PHeader = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DGVClientes = new System.Windows.Forms.DataGridView();
            this.CDni = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CApellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CCorreo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CCompras = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LEstado = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.TBuscar = new System.Windows.Forms.TextBox();
            this.CBEstado = new System.Windows.Forms.ComboBox();
            this.PHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVClientes)).BeginInit();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PHeader
            // 
            this.PHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
            this.PHeader.Controls.Add(this.label2);
            this.PHeader.Controls.Add(this.label1);
            this.PHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.PHeader.Location = new System.Drawing.Point(0, 0);
            this.PHeader.Margin = new System.Windows.Forms.Padding(0);
            this.PHeader.Name = "PHeader";
            this.PHeader.Size = new System.Drawing.Size(956, 70);
            this.PHeader.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(16, 44);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(238, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Administra y consulta datos de clientes";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(16, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Gestión Clientes";
            // 
            // DGVClientes
            // 
            this.DGVClientes.AllowUserToAddRows = false;
            this.DGVClientes.AllowUserToDeleteRows = false;
            this.DGVClientes.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(18)))), ((int)(((byte)(38)))));
            this.DGVClientes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(27)))), ((int)(((byte)(56)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVClientes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGVClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVClientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CDni,
            this.CNombre,
            this.CApellido,
            this.CCorreo,
            this.CCompras,
            this.CEstado,
            this.IdCliente});
            this.DGVClientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVClientes.EnableHeadersVisualStyles = false;
            this.DGVClientes.Location = new System.Drawing.Point(0, 135);
            this.DGVClientes.Margin = new System.Windows.Forms.Padding(0);
            this.DGVClientes.Name = "DGVClientes";
            this.DGVClientes.ReadOnly = true;
            this.DGVClientes.RowHeadersWidth = 51;
            this.DGVClientes.Size = new System.Drawing.Size(956, 441);
            this.DGVClientes.TabIndex = 5;
            this.DGVClientes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVClientes_CellClick);
            // 
            // CDni
            // 
            this.CDni.HeaderText = "DNI";
            this.CDni.MinimumWidth = 6;
            this.CDni.Name = "CDni";
            this.CDni.ReadOnly = true;
            this.CDni.Width = 150;
            // 
            // CNombre
            // 
            this.CNombre.HeaderText = "Nombre";
            this.CNombre.MinimumWidth = 6;
            this.CNombre.Name = "CNombre";
            this.CNombre.ReadOnly = true;
            this.CNombre.Width = 151;
            // 
            // CApellido
            // 
            this.CApellido.HeaderText = "Apellido";
            this.CApellido.MinimumWidth = 6;
            this.CApellido.Name = "CApellido";
            this.CApellido.ReadOnly = true;
            this.CApellido.Width = 151;
            // 
            // CCorreo
            // 
            this.CCorreo.HeaderText = "Correo";
            this.CCorreo.MinimumWidth = 6;
            this.CCorreo.Name = "CCorreo";
            this.CCorreo.ReadOnly = true;
            this.CCorreo.Width = 150;
            // 
            // CCompras
            // 
            this.CCompras.HeaderText = "Compras";
            this.CCompras.MinimumWidth = 6;
            this.CCompras.Name = "CCompras";
            this.CCompras.ReadOnly = true;
            this.CCompras.Width = 151;
            // 
            // CEstado
            // 
            this.CEstado.HeaderText = "Estado";
            this.CEstado.MinimumWidth = 6;
            this.CEstado.Name = "CEstado";
            this.CEstado.ReadOnly = true;
            this.CEstado.Width = 152;
            // 
            // IdCliente
            // 
            this.IdCliente.HeaderText = "CIdCliente";
            this.IdCliente.MinimumWidth = 6;
            this.IdCliente.Name = "IdCliente";
            this.IdCliente.ReadOnly = true;
            this.IdCliente.Visible = false;
            this.IdCliente.Width = 125;
            // 
            // LEstado
            // 
            this.LEstado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LEstado.AutoSize = true;
            this.LEstado.ForeColor = System.Drawing.Color.White;
            this.LEstado.Location = new System.Drawing.Point(556, 0);
            this.LEstado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LEstado.Name = "LEstado";
            this.LEstado.Size = new System.Drawing.Size(362, 29);
            this.LEstado.TabIndex = 4;
            this.LEstado.Text = "Estado";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(18)))), ((int)(((byte)(38)))));
            this.panel3.Controls.Add(this.tableLayoutPanel1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 70);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.panel3.Size = new System.Drawing.Size(956, 65);
            this.panel3.TabIndex = 4;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.Controls.Add(this.TBuscar, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.CBEstado, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.LEstado, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(21, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(922, 59);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // TBuscar
            // 
            this.TBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TBuscar.ForeColor = System.Drawing.Color.Black;
            this.TBuscar.Location = new System.Drawing.Point(4, 33);
            this.TBuscar.Margin = new System.Windows.Forms.Padding(4);
            this.TBuscar.Name = "TBuscar";
            this.TBuscar.Size = new System.Drawing.Size(360, 22);
            this.TBuscar.TabIndex = 0;
            this.TBuscar.TextChanged += new System.EventHandler(this.TBuscar_TextChanged);
            // 
            // CBEstado
            // 
            this.CBEstado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CBEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBEstado.FormattingEnabled = true;
            this.CBEstado.Items.AddRange(new object[] {
            "Todos",
            "Activo",
            "Inactivo"});
            this.CBEstado.Location = new System.Drawing.Point(556, 33);
            this.CBEstado.Margin = new System.Windows.Forms.Padding(4);
            this.CBEstado.Name = "CBEstado";
            this.CBEstado.Size = new System.Drawing.Size(362, 24);
            this.CBEstado.TabIndex = 1;
            this.CBEstado.SelectedIndexChanged += new System.EventHandler(this.CBEstado_SelectedIndexChanged);
            // 
            // FormClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(956, 576);
            this.Controls.Add(this.DGVClientes);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.PHeader);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormClientes";
            this.Text = "FormClientes";
            this.Load += new System.EventHandler(this.FormClientes_Load);
            this.PHeader.ResumeLayout(false);
            this.PHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVClientes)).EndInit();
            this.panel3.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PHeader;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DGVClientes;
        private System.Windows.Forms.DataGridViewTextBoxColumn CDni;
        private System.Windows.Forms.DataGridViewTextBoxColumn CNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn CApellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn CCorreo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CCompras;
        private System.Windows.Forms.DataGridViewTextBoxColumn CEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdCliente;
        private System.Windows.Forms.Label LEstado;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox TBuscar;
        private System.Windows.Forms.ComboBox CBEstado;
    }
}