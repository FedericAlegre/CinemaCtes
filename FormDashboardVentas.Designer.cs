namespace CinemaCtes
{
    partial class FormDashboardVentas
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea17 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend17 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series17 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea18 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend18 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series18 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea19 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend19 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series19 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea20 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend20 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series20 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartPeliculas = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartBeneficios = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartMetodosPago = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartEvolucionVentas = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.DTPDesde = new System.Windows.Forms.DateTimePicker();
            this.DTPHasta = new System.Windows.Forms.DateTimePicker();
            this.LDesde = new System.Windows.Forms.Label();
            this.LHasta = new System.Windows.Forms.Label();
            this.BFlitrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chartPeliculas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartBeneficios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartMetodosPago)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartEvolucionVentas)).BeginInit();
            this.SuspendLayout();
            // 
            // chartPeliculas
            // 
            chartArea17.Name = "ChartArea1";
            this.chartPeliculas.ChartAreas.Add(chartArea17);
            legend17.Name = "Legend1";
            this.chartPeliculas.Legends.Add(legend17);
            this.chartPeliculas.Location = new System.Drawing.Point(183, 1);
            this.chartPeliculas.Name = "chartPeliculas";
            series17.ChartArea = "ChartArea1";
            series17.Legend = "Legend1";
            series17.Name = "Series1";
            this.chartPeliculas.Series.Add(series17);
            this.chartPeliculas.Size = new System.Drawing.Size(300, 219);
            this.chartPeliculas.TabIndex = 0;
            this.chartPeliculas.Text = "chart1";
            // 
            // chartBeneficios
            // 
            chartArea18.Name = "ChartArea1";
            this.chartBeneficios.ChartAreas.Add(chartArea18);
            legend18.Name = "Legend1";
            this.chartBeneficios.Legends.Add(legend18);
            this.chartBeneficios.Location = new System.Drawing.Point(489, 1);
            this.chartBeneficios.Name = "chartBeneficios";
            series18.ChartArea = "ChartArea1";
            series18.Legend = "Legend1";
            series18.Name = "Series1";
            this.chartBeneficios.Series.Add(series18);
            this.chartBeneficios.Size = new System.Drawing.Size(300, 219);
            this.chartBeneficios.TabIndex = 1;
            // 
            // chartMetodosPago
            // 
            chartArea19.Name = "ChartArea1";
            this.chartMetodosPago.ChartAreas.Add(chartArea19);
            legend19.Name = "Legend1";
            this.chartMetodosPago.Legends.Add(legend19);
            this.chartMetodosPago.Location = new System.Drawing.Point(183, 226);
            this.chartMetodosPago.Name = "chartMetodosPago";
            series19.ChartArea = "ChartArea1";
            series19.Legend = "Legend1";
            series19.Name = "Series1";
            this.chartMetodosPago.Series.Add(series19);
            this.chartMetodosPago.Size = new System.Drawing.Size(300, 219);
            this.chartMetodosPago.TabIndex = 2;
            this.chartMetodosPago.Text = "chart3";
            // 
            // chartEvolucionVentas
            // 
            chartArea20.Name = "ChartArea1";
            this.chartEvolucionVentas.ChartAreas.Add(chartArea20);
            legend20.Name = "Legend1";
            this.chartEvolucionVentas.Legends.Add(legend20);
            this.chartEvolucionVentas.Location = new System.Drawing.Point(489, 226);
            this.chartEvolucionVentas.Name = "chartEvolucionVentas";
            series20.ChartArea = "ChartArea1";
            series20.Legend = "Legend1";
            series20.Name = "Series1";
            this.chartEvolucionVentas.Series.Add(series20);
            this.chartEvolucionVentas.Size = new System.Drawing.Size(300, 219);
            this.chartEvolucionVentas.TabIndex = 3;
            this.chartEvolucionVentas.Text = "chart4";
            // 
            // DTPDesde
            // 
            this.DTPDesde.Location = new System.Drawing.Point(20, 52);
            this.DTPDesde.Name = "DTPDesde";
            this.DTPDesde.Size = new System.Drawing.Size(133, 20);
            this.DTPDesde.TabIndex = 4;
            // 
            // DTPHasta
            // 
            this.DTPHasta.Location = new System.Drawing.Point(20, 105);
            this.DTPHasta.Name = "DTPHasta";
            this.DTPHasta.Size = new System.Drawing.Size(133, 20);
            this.DTPHasta.TabIndex = 5;
            // 
            // LDesde
            // 
            this.LDesde.AutoSize = true;
            this.LDesde.Location = new System.Drawing.Point(66, 36);
            this.LDesde.Name = "LDesde";
            this.LDesde.Size = new System.Drawing.Size(38, 13);
            this.LDesde.TabIndex = 6;
            this.LDesde.Text = "Desde";
            // 
            // LHasta
            // 
            this.LHasta.AutoSize = true;
            this.LHasta.Location = new System.Drawing.Point(66, 89);
            this.LHasta.Name = "LHasta";
            this.LHasta.Size = new System.Drawing.Size(35, 13);
            this.LHasta.TabIndex = 7;
            this.LHasta.Text = "Hasta";
            // 
            // BFlitrar
            // 
            this.BFlitrar.Location = new System.Drawing.Point(50, 147);
            this.BFlitrar.Name = "BFlitrar";
            this.BFlitrar.Size = new System.Drawing.Size(75, 23);
            this.BFlitrar.TabIndex = 8;
            this.BFlitrar.Text = "Filtrar";
            this.BFlitrar.UseVisualStyleBackColor = true;
            this.BFlitrar.Click += new System.EventHandler(this.BFiltrar_Click);
            // 
            // FormDashboardVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BFlitrar);
            this.Controls.Add(this.LHasta);
            this.Controls.Add(this.LDesde);
            this.Controls.Add(this.DTPHasta);
            this.Controls.Add(this.DTPDesde);
            this.Controls.Add(this.chartEvolucionVentas);
            this.Controls.Add(this.chartMetodosPago);
            this.Controls.Add(this.chartBeneficios);
            this.Controls.Add(this.chartPeliculas);
            this.Name = "FormDashboardVentas";
            this.Text = "FormDashboardVentas";
            this.Load += new System.EventHandler(this.FormDashboardVentas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartPeliculas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartBeneficios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartMetodosPago)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartEvolucionVentas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartPeliculas;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartBeneficios;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartMetodosPago;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartEvolucionVentas;
        private System.Windows.Forms.DateTimePicker DTPDesde;
        private System.Windows.Forms.DateTimePicker DTPHasta;
        private System.Windows.Forms.Label LDesde;
        private System.Windows.Forms.Label LHasta;
        private System.Windows.Forms.Button BFlitrar;
    }
}