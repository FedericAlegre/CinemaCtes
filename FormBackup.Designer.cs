namespace CinemaCtes
{
    partial class FormBackup
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
            this.BHacerBackup = new System.Windows.Forms.Button();
            this.BValidar = new System.Windows.Forms.Button();
            this.BRestaurarBD = new System.Windows.Forms.Button();
            this.LContraseña = new System.Windows.Forms.Label();
            this.LCorreo = new System.Windows.Forms.Label();
            this.TContraseñaSupervisor = new System.Windows.Forms.TextBox();
            this.TCorreoSupervisor = new System.Windows.Forms.TextBox();
            this.LBackup = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BHacerBackup
            // 
            this.BHacerBackup.Location = new System.Drawing.Point(24, 221);
            this.BHacerBackup.Name = "BHacerBackup";
            this.BHacerBackup.Size = new System.Drawing.Size(102, 23);
            this.BHacerBackup.TabIndex = 4;
            this.BHacerBackup.Text = "Realizar backup";
            this.BHacerBackup.UseVisualStyleBackColor = true;
            this.BHacerBackup.Click += new System.EventHandler(this.BHacerBackup_Click);
            // 
            // BValidar
            // 
            this.BValidar.Location = new System.Drawing.Point(123, 179);
            this.BValidar.Name = "BValidar";
            this.BValidar.Size = new System.Drawing.Size(75, 23);
            this.BValidar.TabIndex = 6;
            this.BValidar.Text = "Validar";
            this.BValidar.UseVisualStyleBackColor = true;
            this.BValidar.Click += new System.EventHandler(this.BValidar_Click);
            // 
            // BRestaurarBD
            // 
            this.BRestaurarBD.Location = new System.Drawing.Point(188, 221);
            this.BRestaurarBD.Name = "BRestaurarBD";
            this.BRestaurarBD.Size = new System.Drawing.Size(102, 23);
            this.BRestaurarBD.TabIndex = 7;
            this.BRestaurarBD.Text = "Restaurar backup";
            this.BRestaurarBD.UseVisualStyleBackColor = true;
            this.BRestaurarBD.Click += new System.EventHandler(this.BRestaurarBD_Click);
            // 
            // LContraseña
            // 
            this.LContraseña.AutoSize = true;
            this.LContraseña.Location = new System.Drawing.Point(108, 109);
            this.LContraseña.Name = "LContraseña";
            this.LContraseña.Size = new System.Drawing.Size(112, 13);
            this.LContraseña.TabIndex = 11;
            this.LContraseña.Text = "Contraseña supervisor";
            // 
            // LCorreo
            // 
            this.LCorreo.AutoSize = true;
            this.LCorreo.Location = new System.Drawing.Point(120, 47);
            this.LCorreo.Name = "LCorreo";
            this.LCorreo.Size = new System.Drawing.Size(89, 13);
            this.LCorreo.TabIndex = 10;
            this.LCorreo.Text = "Correo supervisor";
            // 
            // TContraseñaSupervisor
            // 
            this.TContraseñaSupervisor.Location = new System.Drawing.Point(95, 125);
            this.TContraseñaSupervisor.Name = "TContraseñaSupervisor";
            this.TContraseñaSupervisor.PasswordChar = '*';
            this.TContraseñaSupervisor.Size = new System.Drawing.Size(138, 20);
            this.TContraseñaSupervisor.TabIndex = 9;
            // 
            // TCorreoSupervisor
            // 
            this.TCorreoSupervisor.Location = new System.Drawing.Point(95, 63);
            this.TCorreoSupervisor.Name = "TCorreoSupervisor";
            this.TCorreoSupervisor.Size = new System.Drawing.Size(138, 20);
            this.TCorreoSupervisor.TabIndex = 8;
            // 
            // LBackup
            // 
            this.LBackup.AutoSize = true;
            this.LBackup.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.LBackup.Location = new System.Drawing.Point(84, 9);
            this.LBackup.Name = "LBackup";
            this.LBackup.Size = new System.Drawing.Size(158, 22);
            this.LBackup.TabIndex = 36;
            this.LBackup.Text = "Funciones Backup";
            // 
            // FormBackup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 271);
            this.Controls.Add(this.LBackup);
            this.Controls.Add(this.LContraseña);
            this.Controls.Add(this.LCorreo);
            this.Controls.Add(this.TContraseñaSupervisor);
            this.Controls.Add(this.TCorreoSupervisor);
            this.Controls.Add(this.BRestaurarBD);
            this.Controls.Add(this.BValidar);
            this.Controls.Add(this.BHacerBackup);
            this.Name = "FormBackup";
            this.Text = "FormBackup";
            this.Load += new System.EventHandler(this.FormBackup_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BHacerBackup;
        private System.Windows.Forms.Button BValidar;
        private System.Windows.Forms.Button BRestaurarBD;
        private System.Windows.Forms.Label LContraseña;
        private System.Windows.Forms.Label LCorreo;
        private System.Windows.Forms.TextBox TContraseñaSupervisor;
        private System.Windows.Forms.TextBox TCorreoSupervisor;
        private System.Windows.Forms.Label LBackup;
    }
}