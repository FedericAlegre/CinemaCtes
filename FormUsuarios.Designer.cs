namespace CinemaCtes
{
    partial class FormUsuarios
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.BAñadir = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.LEstado = new System.Windows.Forms.Label();
            this.LTipo = new System.Windows.Forms.Label();
            this.CBTipo = new System.Windows.Forms.ComboBox();
            this.CBEstado = new System.Windows.Forms.ComboBox();
            this.TBuscar = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.DGVUsuarios = new System.Windows.Forms.DataGridView();
            this.CNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CApellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CCorreo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CDni = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CIdUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CIdTipoUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CId_usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CId_tipo_usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.PHeader.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVUsuarios)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PHeader
            // 
            this.PHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
            this.PHeader.Controls.Add(this.panel1);
            this.PHeader.Controls.Add(this.label2);
            this.PHeader.Controls.Add(this.label1);
            this.PHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.PHeader.Location = new System.Drawing.Point(0, 0);
            this.PHeader.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PHeader.Name = "PHeader";
            this.PHeader.Size = new System.Drawing.Size(979, 80);
            this.PHeader.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
            this.panel1.Controls.Add(this.BAñadir);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(979, 80);
            this.panel1.TabIndex = 3;
            // 
            // BAñadir
            // 
            this.BAñadir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BAñadir.Location = new System.Drawing.Point(812, 27);
            this.BAñadir.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BAñadir.Name = "BAñadir";
            this.BAñadir.Size = new System.Drawing.Size(151, 33);
            this.BAñadir.TabIndex = 0;
            this.BAñadir.Text = "Añadir usuario";
            this.BAñadir.UseVisualStyleBackColor = true;
            this.BAñadir.Click += new System.EventHandler(this.BAñadir_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(16, 44);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(196, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Administra usuarios del sistema";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(16, 20);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(161, 25);
            this.label4.TabIndex = 0;
            this.label4.Text = "Gestión Usuarios";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(16, 44);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(227, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Administra beneficios y promociones";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(16, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Gestión Beneficios";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(18)))), ((int)(((byte)(38)))));
            this.panel3.Controls.Add(this.tableLayoutPanel1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 80);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(979, 79);
            this.panel3.TabIndex = 4;
            // 
            // LEstado
            // 
            this.LEstado.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LEstado.AutoSize = true;
            this.LEstado.ForeColor = System.Drawing.Color.White;
            this.LEstado.Location = new System.Drawing.Point(738, 0);
            this.LEstado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LEstado.Name = "LEstado";
            this.LEstado.Size = new System.Drawing.Size(200, 16);
            this.LEstado.TabIndex = 4;
            this.LEstado.Text = "Estado";
            // 
            // LTipo
            // 
            this.LTipo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LTipo.AutoSize = true;
            this.LTipo.ForeColor = System.Drawing.Color.White;
            this.LTipo.Location = new System.Drawing.Point(531, 0);
            this.LTipo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LTipo.Name = "LTipo";
            this.LTipo.Size = new System.Drawing.Size(199, 16);
            this.LTipo.TabIndex = 3;
            this.LTipo.Text = "Tipo";
            // 
            // CBTipo
            // 
            this.CBTipo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CBTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBTipo.FormattingEnabled = true;
            this.CBTipo.Items.AddRange(new object[] {
            "Todos",
            "Administrador",
            "Supervisor",
            "Vendedor"});
            this.CBTipo.Location = new System.Drawing.Point(531, 34);
            this.CBTipo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CBTipo.Name = "CBTipo";
            this.CBTipo.Size = new System.Drawing.Size(199, 24);
            this.CBTipo.TabIndex = 2;
            this.CBTipo.SelectedIndexChanged += new System.EventHandler(this.CBTipo_SelectedIndexChanged);
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
            this.CBEstado.Location = new System.Drawing.Point(738, 34);
            this.CBEstado.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CBEstado.Name = "CBEstado";
            this.CBEstado.Size = new System.Drawing.Size(200, 24);
            this.CBEstado.TabIndex = 1;
            this.CBEstado.SelectedIndexChanged += new System.EventHandler(this.CBEstado_SelectedIndexChanged);
            // 
            // TBuscar
            // 
            this.TBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TBuscar.ForeColor = System.Drawing.Color.Black;
            this.TBuscar.Location = new System.Drawing.Point(4, 34);
            this.TBuscar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TBuscar.Name = "TBuscar";
            this.TBuscar.Size = new System.Drawing.Size(463, 22);
            this.TBuscar.TabIndex = 0;
            this.TBuscar.TextChanged += new System.EventHandler(this.TBuscar_TextChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.DGVUsuarios);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 80);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(979, 487);
            this.panel2.TabIndex = 5;
            // 
            // DGVUsuarios
            // 
            this.DGVUsuarios.AllowUserToAddRows = false;
            this.DGVUsuarios.AllowUserToDeleteRows = false;
            this.DGVUsuarios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGVUsuarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVUsuarios.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(18)))), ((int)(((byte)(38)))));
            this.DGVUsuarios.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(27)))), ((int)(((byte)(56)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVUsuarios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGVUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVUsuarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CNombre,
            this.CApellido,
            this.CCorreo,
            this.CDni,
            this.CEstado,
            this.CTipo,
            this.CIdUsuario,
            this.CIdTipoUsuario});
            this.DGVUsuarios.EnableHeadersVisualStyles = false;
            this.DGVUsuarios.Location = new System.Drawing.Point(0, 74);
            this.DGVUsuarios.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DGVUsuarios.Name = "DGVUsuarios";
            this.DGVUsuarios.ReadOnly = true;
            this.DGVUsuarios.RowHeadersWidth = 51;
            this.DGVUsuarios.Size = new System.Drawing.Size(979, 425);
            this.DGVUsuarios.TabIndex = 3;
            this.DGVUsuarios.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVUsuarios_CellContentClick);
            // 
            // CNombre
            // 
            this.CNombre.HeaderText = "Nombre";
            this.CNombre.MinimumWidth = 6;
            this.CNombre.Name = "CNombre";
            this.CNombre.ReadOnly = true;
            // 
            // CApellido
            // 
            this.CApellido.HeaderText = "Apellido";
            this.CApellido.MinimumWidth = 6;
            this.CApellido.Name = "CApellido";
            this.CApellido.ReadOnly = true;
            // 
            // CCorreo
            // 
            this.CCorreo.HeaderText = "Correo";
            this.CCorreo.MinimumWidth = 6;
            this.CCorreo.Name = "CCorreo";
            this.CCorreo.ReadOnly = true;
            // 
            // CDni
            // 
            this.CDni.HeaderText = "DNI";
            this.CDni.MinimumWidth = 6;
            this.CDni.Name = "CDni";
            this.CDni.ReadOnly = true;
            // 
            // CEstado
            // 
            this.CEstado.HeaderText = "Estado";
            this.CEstado.MinimumWidth = 6;
            this.CEstado.Name = "CEstado";
            this.CEstado.ReadOnly = true;
            // 
            // CTipo
            // 
            this.CTipo.HeaderText = "Tipo";
            this.CTipo.MinimumWidth = 6;
            this.CTipo.Name = "CTipo";
            this.CTipo.ReadOnly = true;
            // 
            // CIdUsuario
            // 
            this.CIdUsuario.HeaderText = "id_usuario";
            this.CIdUsuario.MinimumWidth = 6;
            this.CIdUsuario.Name = "CIdUsuario";
            this.CIdUsuario.ReadOnly = true;
            this.CIdUsuario.Visible = false;
            // 
            // CIdTipoUsuario
            // 
            this.CIdTipoUsuario.HeaderText = "Tipo_usuario";
            this.CIdTipoUsuario.MinimumWidth = 6;
            this.CIdTipoUsuario.Name = "CIdTipoUsuario";
            this.CIdTipoUsuario.ReadOnly = true;
            this.CIdTipoUsuario.Visible = false;
            // 
            // CId_usuario
            // 
            this.CId_usuario.HeaderText = "Column1";
            this.CId_usuario.MinimumWidth = 6;
            this.CId_usuario.Name = "CId_usuario";
            this.CId_usuario.Visible = false;
            this.CId_usuario.Width = 125;
            // 
            // CId_tipo_usuario
            // 
            this.CId_tipo_usuario.HeaderText = "tipo_usuario";
            this.CId_tipo_usuario.MinimumWidth = 6;
            this.CId_tipo_usuario.Name = "CId_tipo_usuario";
            this.CId_tipo_usuario.Width = 99;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22F));
            this.tableLayoutPanel1.Controls.Add(this.TBuscar, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.CBEstado, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.LEstado, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.LTipo, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.CBTipo, 2, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(21, 7);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(942, 60);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // FormUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 567);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.PHeader);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormUsuarios";
            this.Text = "FormUsuarios";
            this.Load += new System.EventHandler(this.FormUsuarios_Load);
            this.PHeader.ResumeLayout(false);
            this.PHeader.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVUsuarios)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PHeader;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label LEstado;
        private System.Windows.Forms.Label LTipo;
        private System.Windows.Forms.ComboBox CBTipo;
        private System.Windows.Forms.ComboBox CBEstado;
        private System.Windows.Forms.TextBox TBuscar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView DGVUsuarios;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn CNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn CApellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn CCorreo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CDni;
        private System.Windows.Forms.DataGridViewTextBoxColumn CEstado;
        private System.Windows.Forms.Button BAñadir;
        private System.Windows.Forms.DataGridViewTextBoxColumn CTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CIdUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn CIdTipoUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn CId_usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn CId_tipo_usuario;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}