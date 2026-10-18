namespace CinemaCtes
{
    partial class FormModificarButaca
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
            this.LButaca = new System.Windows.Forms.Label();
            this.BCancelar = new System.Windows.Forms.Button();
            this.BConfirmar = new System.Windows.Forms.Button();
            this.LAñadir = new System.Windows.Forms.Label();
            this.CBSala = new System.Windows.Forms.ComboBox();
            this.LSala = new System.Windows.Forms.Label();
            this.CLBButacas = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // LButaca
            // 
            this.LButaca.AutoSize = true;
            this.LButaca.Location = new System.Drawing.Point(182, 76);
            this.LButaca.Name = "LButaca";
            this.LButaca.Size = new System.Drawing.Size(41, 13);
            this.LButaca.TabIndex = 32;
            this.LButaca.Text = "Butaca";
            // 
            // BCancelar
            // 
            this.BCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BCancelar.Location = new System.Drawing.Point(170, 201);
            this.BCancelar.Name = "BCancelar";
            this.BCancelar.Size = new System.Drawing.Size(75, 23);
            this.BCancelar.TabIndex = 29;
            this.BCancelar.Text = "Cancelar";
            this.BCancelar.UseVisualStyleBackColor = true;
            this.BCancelar.Click += new System.EventHandler(this.BCancelar_Click);
            // 
            // BConfirmar
            // 
            this.BConfirmar.Location = new System.Drawing.Point(39, 201);
            this.BConfirmar.Name = "BConfirmar";
            this.BConfirmar.Size = new System.Drawing.Size(75, 23);
            this.BConfirmar.TabIndex = 28;
            this.BConfirmar.Text = "Confirmar";
            this.BConfirmar.UseVisualStyleBackColor = true;
            this.BConfirmar.Click += new System.EventHandler(this.BConfirmar_Click);
            // 
            // LAñadir
            // 
            this.LAñadir.AutoSize = true;
            this.LAñadir.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.LAñadir.Location = new System.Drawing.Point(69, 24);
            this.LAñadir.Name = "LAñadir";
            this.LAñadir.Size = new System.Drawing.Size(143, 22);
            this.LAñadir.TabIndex = 27;
            this.LAñadir.Text = "Modificar Butaca";
            // 
            // CBSala
            // 
            this.CBSala.FormattingEnabled = true;
            this.CBSala.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.CBSala.Location = new System.Drawing.Point(19, 92);
            this.CBSala.Name = "CBSala";
            this.CBSala.Size = new System.Drawing.Size(100, 21);
            this.CBSala.TabIndex = 33;
            this.CBSala.SelectedIndexChanged += new System.EventHandler(this.CBSala_SelectedIndexChanged);
            // 
            // LSala
            // 
            this.LSala.AutoSize = true;
            this.LSala.Location = new System.Drawing.Point(55, 76);
            this.LSala.Name = "LSala";
            this.LSala.Size = new System.Drawing.Size(28, 13);
            this.LSala.TabIndex = 34;
            this.LSala.Text = "Sala";
            // 
            // CLBButacas
            // 
            this.CLBButacas.FormattingEnabled = true;
            this.CLBButacas.Location = new System.Drawing.Point(151, 92);
            this.CLBButacas.Name = "CLBButacas";
            this.CLBButacas.Size = new System.Drawing.Size(101, 79);
            this.CLBButacas.TabIndex = 35;
            // 
            // FormModificarButaca
            // 
            this.AcceptButton = this.BConfirmar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BCancelar;
            this.ClientSize = new System.Drawing.Size(280, 251);
            this.Controls.Add(this.CLBButacas);
            this.Controls.Add(this.LSala);
            this.Controls.Add(this.CBSala);
            this.Controls.Add(this.LButaca);
            this.Controls.Add(this.BCancelar);
            this.Controls.Add(this.BConfirmar);
            this.Controls.Add(this.LAñadir);
            this.Name = "FormModificarButaca";
            this.Text = "FormModificarButaca";
            this.Load += new System.EventHandler(this.FormModificarButaca_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LButaca;
        private System.Windows.Forms.Button BCancelar;
        private System.Windows.Forms.Button BConfirmar;
        private System.Windows.Forms.Label LAñadir;
        private System.Windows.Forms.ComboBox CBSala;
        private System.Windows.Forms.Label LSala;
        private System.Windows.Forms.CheckedListBox CLBButacas;
    }
}