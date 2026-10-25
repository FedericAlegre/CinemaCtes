namespace CinemaCtes
{
    partial class FormRegistroFuncion
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
            this.LAñadir = new System.Windows.Forms.Label();
            this.BCancelar = new System.Windows.Forms.Button();
            this.BInsertar = new System.Windows.Forms.Button();
            this.LPelicula = new System.Windows.Forms.Label();
            this.CBPelicula = new System.Windows.Forms.ComboBox();
            this.LSala = new System.Windows.Forms.Label();
            this.CBSala = new System.Windows.Forms.ComboBox();
            this.Linicio = new System.Windows.Forms.Label();
            this.DTPInicio = new System.Windows.Forms.DateTimePicker();
            this.BAñadir = new System.Windows.Forms.Button();
            this.LBHorarios = new System.Windows.Forms.ListBox();
            this.BBorrar = new System.Windows.Forms.Button();
            this.LFecha = new System.Windows.Forms.Label();
            this.DTPFecha = new System.Windows.Forms.DateTimePicker();
            this.LblRangoCalculado = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LAñadir
            // 
            this.LAñadir.AutoSize = true;
            this.LAñadir.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.LAñadir.Location = new System.Drawing.Point(174, 41);
            this.LAñadir.Name = "LAñadir";
            this.LAñadir.Size = new System.Drawing.Size(131, 22);
            this.LAñadir.TabIndex = 15;
            this.LAñadir.Text = "Añadir Funcion";
            // 
            // BCancelar
            // 
            this.BCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BCancelar.Location = new System.Drawing.Point(256, 258);
            this.BCancelar.Name = "BCancelar";
            this.BCancelar.Size = new System.Drawing.Size(75, 23);
            this.BCancelar.TabIndex = 7;
            this.BCancelar.Text = "Cancelar";
            this.BCancelar.UseVisualStyleBackColor = true;
            this.BCancelar.Click += new System.EventHandler(this.BCancelar_Click);
            // 
            // BInsertar
            // 
            this.BInsertar.Location = new System.Drawing.Point(125, 258);
            this.BInsertar.Name = "BInsertar";
            this.BInsertar.Size = new System.Drawing.Size(75, 23);
            this.BInsertar.TabIndex = 6;
            this.BInsertar.Text = "Insertar";
            this.BInsertar.UseVisualStyleBackColor = true;
            this.BInsertar.Click += new System.EventHandler(this.BInsertar_Click);
            // 
            // LPelicula
            // 
            this.LPelicula.AutoSize = true;
            this.LPelicula.Location = new System.Drawing.Point(36, 115);
            this.LPelicula.Name = "LPelicula";
            this.LPelicula.Size = new System.Drawing.Size(44, 13);
            this.LPelicula.TabIndex = 0;
            this.LPelicula.Text = "Pelicula";
            // 
            // CBPelicula
            // 
            this.CBPelicula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBPelicula.FormattingEnabled = true;
            this.CBPelicula.Items.AddRange(new object[] {
            "Administrador",
            "Supervisor",
            "Vendedor"});
            this.CBPelicula.Location = new System.Drawing.Point(95, 112);
            this.CBPelicula.Name = "CBPelicula";
            this.CBPelicula.Size = new System.Drawing.Size(128, 21);
            this.CBPelicula.TabIndex = 0;
            // 
            // LSala
            // 
            this.LSala.AutoSize = true;
            this.LSala.Location = new System.Drawing.Point(36, 153);
            this.LSala.Name = "LSala";
            this.LSala.Size = new System.Drawing.Size(28, 13);
            this.LSala.TabIndex = 25;
            this.LSala.Text = "Sala";
            // 
            // CBSala
            // 
            this.CBSala.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBSala.FormattingEnabled = true;
            this.CBSala.Items.AddRange(new object[] {
            "Administrador",
            "Supervisor",
            "Vendedor"});
            this.CBSala.Location = new System.Drawing.Point(95, 150);
            this.CBSala.Name = "CBSala";
            this.CBSala.Size = new System.Drawing.Size(128, 21);
            this.CBSala.TabIndex = 1;
            // 
            // Linicio
            // 
            this.Linicio.AutoSize = true;
            this.Linicio.Location = new System.Drawing.Point(283, 96);
            this.Linicio.Name = "Linicio";
            this.Linicio.Size = new System.Drawing.Size(68, 13);
            this.Linicio.TabIndex = 20;
            this.Linicio.Text = "Horario inicio";
            // 
            // DTPInicio
            // 
            this.DTPInicio.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.DTPInicio.Location = new System.Drawing.Point(256, 112);
            this.DTPInicio.Name = "DTPInicio";
            this.DTPInicio.ShowUpDown = true;
            this.DTPInicio.Size = new System.Drawing.Size(128, 20);
            this.DTPInicio.TabIndex = 2;
            // 
            // BAñadir
            // 
            this.BAñadir.Location = new System.Drawing.Point(400, 111);
            this.BAñadir.Name = "BAñadir";
            this.BAñadir.Size = new System.Drawing.Size(46, 20);
            this.BAñadir.TabIndex = 26;
            this.BAñadir.Text = "Añadir";
            this.BAñadir.UseVisualStyleBackColor = true;
            this.BAñadir.Click += new System.EventHandler(this.BAñadir_Click);
            // 
            // LBHorarios
            // 
            this.LBHorarios.FormattingEnabled = true;
            this.LBHorarios.Location = new System.Drawing.Point(256, 150);
            this.LBHorarios.Name = "LBHorarios";
            this.LBHorarios.Size = new System.Drawing.Size(128, 56);
            this.LBHorarios.TabIndex = 27;
            // 
            // BBorrar
            // 
            this.BBorrar.Location = new System.Drawing.Point(400, 166);
            this.BBorrar.Name = "BBorrar";
            this.BBorrar.Size = new System.Drawing.Size(46, 20);
            this.BBorrar.TabIndex = 28;
            this.BBorrar.Text = "Borrar";
            this.BBorrar.UseVisualStyleBackColor = true;
            this.BBorrar.Click += new System.EventHandler(this.BBorrar_Click);
            // 
            // LFecha
            // 
            this.LFecha.AutoSize = true;
            this.LFecha.Location = new System.Drawing.Point(36, 188);
            this.LFecha.Name = "LFecha";
            this.LFecha.Size = new System.Drawing.Size(37, 13);
            this.LFecha.TabIndex = 30;
            this.LFecha.Text = "Fecha";
            // 
            // DTPFecha
            // 
            this.DTPFecha.Location = new System.Drawing.Point(95, 186);
            this.DTPFecha.Name = "DTPFecha";
            this.DTPFecha.Size = new System.Drawing.Size(128, 20);
            this.DTPFecha.TabIndex = 31;
            this.DTPFecha.ValueChanged += new System.EventHandler(this.DTPFecha_ValueChanged);
            // 
            // LblRangoCalculado
            // 
            this.LblRangoCalculado.AutoSize = true;
            this.LblRangoCalculado.Location = new System.Drawing.Point(92, 218);
            this.LblRangoCalculado.Name = "LblRangoCalculado";
            this.LblRangoCalculado.Size = new System.Drawing.Size(0, 13);
            this.LblRangoCalculado.TabIndex = 32;
            // 
            // FormRegistroFuncion
            // 
            this.AcceptButton = this.BInsertar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BCancelar;
            this.ClientSize = new System.Drawing.Size(469, 325);
            this.Controls.Add(this.LblRangoCalculado);
            this.Controls.Add(this.DTPFecha);
            this.Controls.Add(this.LFecha);
            this.Controls.Add(this.BBorrar);
            this.Controls.Add(this.LBHorarios);
            this.Controls.Add(this.BAñadir);
            this.Controls.Add(this.DTPInicio);
            this.Controls.Add(this.Linicio);
            this.Controls.Add(this.LSala);
            this.Controls.Add(this.CBSala);
            this.Controls.Add(this.LPelicula);
            this.Controls.Add(this.CBPelicula);
            this.Controls.Add(this.BCancelar);
            this.Controls.Add(this.BInsertar);
            this.Controls.Add(this.LAñadir);
            this.Name = "FormRegistroFuncion";
            this.Text = "FormRegistroFuncion";
            this.Load += new System.EventHandler(this.FormRegistroFuncion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LAñadir;
        private System.Windows.Forms.Button BCancelar;
        private System.Windows.Forms.Button BInsertar;
        private System.Windows.Forms.Label LPelicula;
        private System.Windows.Forms.ComboBox CBPelicula;
        private System.Windows.Forms.Label LSala;
        private System.Windows.Forms.ComboBox CBSala;
        private System.Windows.Forms.Label Linicio;
        private System.Windows.Forms.DateTimePicker DTPInicio;
        private System.Windows.Forms.Button BAñadir;
        private System.Windows.Forms.ListBox LBHorarios;
        private System.Windows.Forms.Button BBorrar;
        private System.Windows.Forms.Label LFecha;
        private System.Windows.Forms.DateTimePicker DTPFecha;
        private System.Windows.Forms.Label LblRangoCalculado;
    }
}