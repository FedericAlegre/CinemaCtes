namespace CinemaCtes
{
    partial class FormModificarMetodoPago
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
            this.LMetodoPago = new System.Windows.Forms.Label();
            this.CBMetodoPago = new System.Windows.Forms.ComboBox();
            this.LModificar = new System.Windows.Forms.Label();
            this.BCancelar = new System.Windows.Forms.Button();
            this.BConfirmar = new System.Windows.Forms.Button();
            this.LEstado = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LMetodoPago
            // 
            this.LMetodoPago.AutoSize = true;
            this.LMetodoPago.Location = new System.Drawing.Point(88, 68);
            this.LMetodoPago.Name = "LMetodoPago";
            this.LMetodoPago.Size = new System.Drawing.Size(85, 13);
            this.LMetodoPago.TabIndex = 37;
            this.LMetodoPago.Text = "Metodo de pago";
            // 
            // CBMetodoPago
            // 
            this.CBMetodoPago.FormattingEnabled = true;
            this.CBMetodoPago.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.CBMetodoPago.Location = new System.Drawing.Point(80, 84);
            this.CBMetodoPago.Name = "CBMetodoPago";
            this.CBMetodoPago.Size = new System.Drawing.Size(100, 21);
            this.CBMetodoPago.TabIndex = 36;
            this.CBMetodoPago.SelectedIndexChanged += new System.EventHandler(this.CBMetodoPago_SelectedIndexChanged);
            // 
            // LModificar
            // 
            this.LModificar.AutoSize = true;
            this.LModificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.LModificar.Location = new System.Drawing.Point(24, 24);
            this.LModificar.Name = "LModificar";
            this.LModificar.Size = new System.Drawing.Size(216, 22);
            this.LModificar.TabIndex = 35;
            this.LModificar.Text = "Modificar metodo de pago";
            // 
            // BCancelar
            // 
            this.BCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BCancelar.Location = new System.Drawing.Point(159, 166);
            this.BCancelar.Name = "BCancelar";
            this.BCancelar.Size = new System.Drawing.Size(75, 23);
            this.BCancelar.TabIndex = 39;
            this.BCancelar.Text = "Cancelar";
            this.BCancelar.UseVisualStyleBackColor = true;
            this.BCancelar.Click += new System.EventHandler(this.BCancelar_Click);
            // 
            // BConfirmar
            // 
            this.BConfirmar.Location = new System.Drawing.Point(28, 166);
            this.BConfirmar.Name = "BConfirmar";
            this.BConfirmar.Size = new System.Drawing.Size(75, 23);
            this.BConfirmar.TabIndex = 38;
            this.BConfirmar.Text = "Confirmar";
            this.BConfirmar.UseVisualStyleBackColor = true;
            this.BConfirmar.Click += new System.EventHandler(this.BConfirmar_Click);
            // 
            // LEstado
            // 
            this.LEstado.AutoSize = true;
            this.LEstado.Location = new System.Drawing.Point(83, 112);
            this.LEstado.Name = "LEstado";
            this.LEstado.Size = new System.Drawing.Size(0, 13);
            this.LEstado.TabIndex = 40;
            // 
            // FormModificarMetodoPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(264, 218);
            this.Controls.Add(this.LEstado);
            this.Controls.Add(this.BCancelar);
            this.Controls.Add(this.BConfirmar);
            this.Controls.Add(this.LMetodoPago);
            this.Controls.Add(this.CBMetodoPago);
            this.Controls.Add(this.LModificar);
            this.Name = "FormModificarMetodoPago";
            this.Text = "FormModificarMetodoPago";
            this.Load += new System.EventHandler(this.FormModificarMetodoPago_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LMetodoPago;
        private System.Windows.Forms.ComboBox CBMetodoPago;
        private System.Windows.Forms.Label LModificar;
        private System.Windows.Forms.Button BCancelar;
        private System.Windows.Forms.Button BConfirmar;
        private System.Windows.Forms.Label LEstado;
    }
}