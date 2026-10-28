namespace CinemaCtes
{
    partial class FormRegistrarCliente
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
            this.TNombre = new System.Windows.Forms.TextBox();
            this.TApellido = new System.Windows.Forms.TextBox();
            this.TDni = new System.Windows.Forms.TextBox();
            this.TCorreo = new System.Windows.Forms.TextBox();
            this.LNombre = new System.Windows.Forms.Label();
            this.LApeliido = new System.Windows.Forms.Label();
            this.LDni = new System.Windows.Forms.Label();
            this.LCorreo = new System.Windows.Forms.Label();
            this.BCancelar = new System.Windows.Forms.Button();
            this.BAñadir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LAñadir
            // 
            this.LAñadir.AutoSize = true;
            this.LAñadir.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.LAñadir.Location = new System.Drawing.Point(119, 27);
            this.LAñadir.Name = "LAñadir";
            this.LAñadir.Size = new System.Drawing.Size(123, 22);
            this.LAñadir.TabIndex = 28;
            this.LAñadir.Text = "Añadir Cliente";
            // 
            // TNombre
            // 
            this.TNombre.Location = new System.Drawing.Point(36, 86);
            this.TNombre.Name = "TNombre";
            this.TNombre.Size = new System.Drawing.Size(121, 20);
            this.TNombre.TabIndex = 29;
            this.TNombre.TextChanged += new System.EventHandler(this.TNombre_TextChanged);
            // 
            // TApellido
            // 
            this.TApellido.Location = new System.Drawing.Point(36, 154);
            this.TApellido.Name = "TApellido";
            this.TApellido.Size = new System.Drawing.Size(121, 20);
            this.TApellido.TabIndex = 30;
            this.TApellido.TextChanged += new System.EventHandler(this.TApellido_TextChanged);
            // 
            // TDni
            // 
            this.TDni.Location = new System.Drawing.Point(205, 86);
            this.TDni.Name = "TDni";
            this.TDni.Size = new System.Drawing.Size(121, 20);
            this.TDni.TabIndex = 31;
            this.TDni.TextChanged += new System.EventHandler(this.TDni_TextChanged);
            // 
            // TCorreo
            // 
            this.TCorreo.Location = new System.Drawing.Point(205, 154);
            this.TCorreo.Name = "TCorreo";
            this.TCorreo.Size = new System.Drawing.Size(121, 20);
            this.TCorreo.TabIndex = 32;
            // 
            // LNombre
            // 
            this.LNombre.AutoSize = true;
            this.LNombre.Location = new System.Drawing.Point(76, 70);
            this.LNombre.Name = "LNombre";
            this.LNombre.Size = new System.Drawing.Size(44, 13);
            this.LNombre.TabIndex = 33;
            this.LNombre.Text = "Nombre";
            // 
            // LApeliido
            // 
            this.LApeliido.AutoSize = true;
            this.LApeliido.Location = new System.Drawing.Point(77, 138);
            this.LApeliido.Name = "LApeliido";
            this.LApeliido.Size = new System.Drawing.Size(42, 13);
            this.LApeliido.TabIndex = 34;
            this.LApeliido.Text = "Apelido";
            // 
            // LDni
            // 
            this.LDni.AutoSize = true;
            this.LDni.Location = new System.Drawing.Point(251, 70);
            this.LDni.Name = "LDni";
            this.LDni.Size = new System.Drawing.Size(26, 13);
            this.LDni.TabIndex = 35;
            this.LDni.Text = "DNI";
            // 
            // LCorreo
            // 
            this.LCorreo.AutoSize = true;
            this.LCorreo.Location = new System.Drawing.Point(247, 138);
            this.LCorreo.Name = "LCorreo";
            this.LCorreo.Size = new System.Drawing.Size(38, 13);
            this.LCorreo.TabIndex = 36;
            this.LCorreo.Text = "Correo";
            // 
            // BCancelar
            // 
            this.BCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BCancelar.Location = new System.Drawing.Point(212, 210);
            this.BCancelar.Name = "BCancelar";
            this.BCancelar.Size = new System.Drawing.Size(75, 23);
            this.BCancelar.TabIndex = 37;
            this.BCancelar.Text = "Cancelar";
            this.BCancelar.UseVisualStyleBackColor = true;
            this.BCancelar.Click += new System.EventHandler(this.BCancelar_Click);
            // 
            // BAñadir
            // 
            this.BAñadir.Location = new System.Drawing.Point(75, 210);
            this.BAñadir.Name = "BAñadir";
            this.BAñadir.Size = new System.Drawing.Size(75, 23);
            this.BAñadir.TabIndex = 38;
            this.BAñadir.Text = "Registrar";
            this.BAñadir.UseVisualStyleBackColor = true;
            this.BAñadir.Click += new System.EventHandler(this.BAñadir_Click);
            // 
            // FormRegistrarCliente
            // 
            this.AcceptButton = this.BAñadir;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BCancelar;
            this.ClientSize = new System.Drawing.Size(369, 258);
            this.Controls.Add(this.BAñadir);
            this.Controls.Add(this.BCancelar);
            this.Controls.Add(this.LCorreo);
            this.Controls.Add(this.LDni);
            this.Controls.Add(this.LApeliido);
            this.Controls.Add(this.LNombre);
            this.Controls.Add(this.TCorreo);
            this.Controls.Add(this.TDni);
            this.Controls.Add(this.TApellido);
            this.Controls.Add(this.TNombre);
            this.Controls.Add(this.LAñadir);
            this.Name = "FormRegistrarCliente";
            this.Text = "FormRegistrarCliente";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LAñadir;
        private System.Windows.Forms.TextBox TNombre;
        private System.Windows.Forms.TextBox TApellido;
        private System.Windows.Forms.TextBox TDni;
        private System.Windows.Forms.TextBox TCorreo;
        private System.Windows.Forms.Label LNombre;
        private System.Windows.Forms.Label LApeliido;
        private System.Windows.Forms.Label LDni;
        private System.Windows.Forms.Label LCorreo;
        private System.Windows.Forms.Button BCancelar;
        private System.Windows.Forms.Button BAñadir;
    }
}