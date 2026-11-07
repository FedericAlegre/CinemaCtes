namespace CinemaCtes
{
    partial class FormVistaPreviaTicket
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
            this.BGuardar = new System.Windows.Forms.Button();
            this.txtVistaComprobante = new System.Windows.Forms.RichTextBox();
            this.txtVistaBoletos = new System.Windows.Forms.RichTextBox();
            this.Bimprimir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BCerrar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BGuardar
            // 
            this.BGuardar.Location = new System.Drawing.Point(133, 270);
            this.BGuardar.Name = "BGuardar";
            this.BGuardar.Size = new System.Drawing.Size(75, 23);
            this.BGuardar.TabIndex = 0;
            this.BGuardar.Text = "Imprimir";
            this.BGuardar.UseVisualStyleBackColor = true;
            this.BGuardar.Click += new System.EventHandler(this.BImprimirComprobante_Click);
            // 
            // txtVistaComprobante
            // 
            this.txtVistaComprobante.Location = new System.Drawing.Point(76, 31);
            this.txtVistaComprobante.Name = "txtVistaComprobante";
            this.txtVistaComprobante.Size = new System.Drawing.Size(196, 228);
            this.txtVistaComprobante.TabIndex = 1;
            this.txtVistaComprobante.Text = "";
            // 
            // txtVistaBoletos
            // 
            this.txtVistaBoletos.Location = new System.Drawing.Point(365, 31);
            this.txtVistaBoletos.Name = "txtVistaBoletos";
            this.txtVistaBoletos.Size = new System.Drawing.Size(196, 228);
            this.txtVistaBoletos.TabIndex = 4;
            this.txtVistaBoletos.Text = "";
            // 
            // Bimprimir
            // 
            this.Bimprimir.Location = new System.Drawing.Point(422, 270);
            this.Bimprimir.Name = "Bimprimir";
            this.Bimprimir.Size = new System.Drawing.Size(75, 23);
            this.Bimprimir.TabIndex = 3;
            this.Bimprimir.Text = "Imprimir";
            this.Bimprimir.UseVisualStyleBackColor = true;
            this.Bimprimir.Click += new System.EventHandler(this.BImprimirBoletos_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(138, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Comprobante";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(444, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Boletos";
            // 
            // BCerrar
            // 
            this.BCerrar.Location = new System.Drawing.Point(553, 284);
            this.BCerrar.Name = "BCerrar";
            this.BCerrar.Size = new System.Drawing.Size(75, 23);
            this.BCerrar.TabIndex = 7;
            this.BCerrar.Text = "Cerrar";
            this.BCerrar.UseVisualStyleBackColor = true;
            this.BCerrar.Click += new System.EventHandler(this.BCerrar_Click);
            // 
            // FormVistaPreviaTicket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 319);
            this.Controls.Add(this.BCerrar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtVistaBoletos);
            this.Controls.Add(this.Bimprimir);
            this.Controls.Add(this.txtVistaComprobante);
            this.Controls.Add(this.BGuardar);
            this.Name = "FormVistaPreviaTicket";
            this.Text = "FormVistaPreviaTicket";
            this.Load += new System.EventHandler(this.FormVistaPreviaTicket_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BGuardar;
        private System.Windows.Forms.RichTextBox txtVistaComprobante;
        private System.Windows.Forms.RichTextBox txtVistaBoletos;
        private System.Windows.Forms.Button Bimprimir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BCerrar;
    }
}