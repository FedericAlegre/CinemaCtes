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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea8 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend8 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea7 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend7 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartPeliculas = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartBeneficios = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartMetodosPago = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartEvolucionVentas = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.DTPDesde = new System.Windows.Forms.DateTimePicker();
            this.DTPHasta = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.BCerrar = new System.Windows.Forms.Button();
            this.BFiltrar = new System.Windows.Forms.Button();
            this.LHasta = new System.Windows.Forms.Label();
            this.LDesde = new System.Windows.Forms.Label();
            this.chartCajeros = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartClientes = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartFranjaHoraria = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartEtiquetas = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartPeliculas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartBeneficios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartMetodosPago)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartEvolucionVentas)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartCajeros)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartClientes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartFranjaHoraria)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartEtiquetas)).BeginInit();
            this.SuspendLayout();
            // 
            // chartPeliculas
            // 
            chartArea1.Name = "ChartArea1";
            this.chartPeliculas.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartPeliculas.Legends.Add(legend1);
            this.chartPeliculas.Location = new System.Drawing.Point(182, 3);
            this.chartPeliculas.Name = "chartPeliculas";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartPeliculas.Series.Add(series1);
            this.chartPeliculas.Size = new System.Drawing.Size(300, 219);
            this.chartPeliculas.TabIndex = 0;
            this.chartPeliculas.Text = "chart1";
            // 
            // chartBeneficios
            // 
            chartArea2.Name = "ChartArea1";
            this.chartBeneficios.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartBeneficios.Legends.Add(legend2);
            this.chartBeneficios.Location = new System.Drawing.Point(488, 3);
            this.chartBeneficios.Name = "chartBeneficios";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartBeneficios.Series.Add(series2);
            this.chartBeneficios.Size = new System.Drawing.Size(300, 219);
            this.chartBeneficios.TabIndex = 1;
            // 
            // chartMetodosPago
            // 
            chartArea3.Name = "ChartArea1";
            this.chartMetodosPago.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chartMetodosPago.Legends.Add(legend3);
            this.chartMetodosPago.Location = new System.Drawing.Point(182, 228);
            this.chartMetodosPago.Name = "chartMetodosPago";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chartMetodosPago.Series.Add(series3);
            this.chartMetodosPago.Size = new System.Drawing.Size(300, 219);
            this.chartMetodosPago.TabIndex = 2;
            this.chartMetodosPago.Text = "chart3";
            // 
            // chartEvolucionVentas
            // 
            chartArea4.Name = "ChartArea1";
            this.chartEvolucionVentas.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chartEvolucionVentas.Legends.Add(legend4);
            this.chartEvolucionVentas.Location = new System.Drawing.Point(488, 228);
            this.chartEvolucionVentas.Name = "chartEvolucionVentas";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.chartEvolucionVentas.Series.Add(series4);
            this.chartEvolucionVentas.Size = new System.Drawing.Size(300, 219);
            this.chartEvolucionVentas.TabIndex = 3;
            this.chartEvolucionVentas.Text = "chart4";
            // 
            // DTPDesde
            // 
            this.DTPDesde.Location = new System.Drawing.Point(20, 92);
            this.DTPDesde.Name = "DTPDesde";
            this.DTPDesde.Size = new System.Drawing.Size(133, 20);
            this.DTPDesde.TabIndex = 4;
            // 
            // DTPHasta
            // 
            this.DTPHasta.Location = new System.Drawing.Point(20, 151);
            this.DTPHasta.Name = "DTPHasta";
            this.DTPHasta.Size = new System.Drawing.Size(133, 20);
            this.DTPHasta.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(18)))), ((int)(((byte)(38)))));
            this.panel1.Controls.Add(this.chartEtiquetas);
            this.panel1.Controls.Add(this.chartFranjaHoraria);
            this.panel1.Controls.Add(this.chartClientes);
            this.panel1.Controls.Add(this.chartCajeros);
            this.panel1.Controls.Add(this.chartEvolucionVentas);
            this.panel1.Controls.Add(this.chartMetodosPago);
            this.panel1.Controls.Add(this.chartBeneficios);
            this.panel1.Controls.Add(this.chartPeliculas);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 450);
            this.panel1.TabIndex = 10;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.BCerrar);
            this.panel2.Controls.Add(this.DTPDesde);
            this.panel2.Controls.Add(this.DTPHasta);
            this.panel2.Controls.Add(this.BFiltrar);
            this.panel2.Controls.Add(this.LHasta);
            this.panel2.Controls.Add(this.LDesde);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(185, 450);
            this.panel2.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(16, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 20);
            this.label1.TabIndex = 24;
            this.label1.Text = "Dashboard - ventas";
            // 
            // BCerrar
            // 
            this.BCerrar.BackColor = System.Drawing.Color.AliceBlue;
            this.BCerrar.Location = new System.Drawing.Point(29, 394);
            this.BCerrar.Name = "BCerrar";
            this.BCerrar.Size = new System.Drawing.Size(113, 27);
            this.BCerrar.TabIndex = 23;
            this.BCerrar.Text = "Cerrar";
            this.BCerrar.UseVisualStyleBackColor = false;
            this.BCerrar.Click += new System.EventHandler(this.BCerrar_Click);
            // 
            // BFiltrar
            // 
            this.BFiltrar.BackColor = System.Drawing.Color.AliceBlue;
            this.BFiltrar.Location = new System.Drawing.Point(29, 210);
            this.BFiltrar.Name = "BFiltrar";
            this.BFiltrar.Size = new System.Drawing.Size(113, 27);
            this.BFiltrar.TabIndex = 22;
            this.BFiltrar.Text = "Filtrar";
            this.BFiltrar.UseVisualStyleBackColor = false;
            this.BFiltrar.Click += new System.EventHandler(this.BFiltrar_Click);
            // 
            // LHasta
            // 
            this.LHasta.AutoSize = true;
            this.LHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.LHasta.ForeColor = System.Drawing.Color.White;
            this.LHasta.Location = new System.Drawing.Point(66, 133);
            this.LHasta.Name = "LHasta";
            this.LHasta.Size = new System.Drawing.Size(39, 15);
            this.LHasta.TabIndex = 3;
            this.LHasta.Text = "Hasta";
            // 
            // LDesde
            // 
            this.LDesde.AutoSize = true;
            this.LDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.LDesde.ForeColor = System.Drawing.Color.White;
            this.LDesde.Location = new System.Drawing.Point(66, 74);
            this.LDesde.Name = "LDesde";
            this.LDesde.Size = new System.Drawing.Size(43, 15);
            this.LDesde.TabIndex = 2;
            this.LDesde.Text = "Desde";
            // 
            // chartCajeros
            // 
            chartArea8.Name = "ChartArea1";
            this.chartCajeros.ChartAreas.Add(chartArea8);
            legend8.Name = "Legend1";
            this.chartCajeros.Legends.Add(legend8);
            this.chartCajeros.Location = new System.Drawing.Point(182, 453);
            this.chartCajeros.Name = "chartCajeros";
            series8.ChartArea = "ChartArea1";
            series8.Legend = "Legend1";
            series8.Name = "Series1";
            this.chartCajeros.Series.Add(series8);
            this.chartCajeros.Size = new System.Drawing.Size(300, 219);
            this.chartCajeros.TabIndex = 4;
            this.chartCajeros.Text = "chart3";
            // 
            // chartClientes
            // 
            chartArea7.Name = "ChartArea1";
            this.chartClientes.ChartAreas.Add(chartArea7);
            legend7.Name = "Legend1";
            this.chartClientes.Legends.Add(legend7);
            this.chartClientes.Location = new System.Drawing.Point(488, 453);
            this.chartClientes.Name = "chartClientes";
            series7.ChartArea = "ChartArea1";
            series7.Legend = "Legend1";
            series7.Name = "Series1";
            this.chartClientes.Series.Add(series7);
            this.chartClientes.Size = new System.Drawing.Size(300, 219);
            this.chartClientes.TabIndex = 5;
            this.chartClientes.Text = "chart3";
            // 
            // chartFranjaHoraria
            // 
            chartArea6.Name = "ChartArea1";
            this.chartFranjaHoraria.ChartAreas.Add(chartArea6);
            legend6.Name = "Legend1";
            this.chartFranjaHoraria.Legends.Add(legend6);
            this.chartFranjaHoraria.Location = new System.Drawing.Point(182, 678);
            this.chartFranjaHoraria.Name = "chartFranjaHoraria";
            series6.ChartArea = "ChartArea1";
            series6.Legend = "Legend1";
            series6.Name = "Series1";
            this.chartFranjaHoraria.Series.Add(series6);
            this.chartFranjaHoraria.Size = new System.Drawing.Size(300, 219);
            this.chartFranjaHoraria.TabIndex = 6;
            this.chartFranjaHoraria.Text = "chart3";
            // 
            // chartEtiquetas
            // 
            chartArea5.Name = "ChartArea1";
            this.chartEtiquetas.ChartAreas.Add(chartArea5);
            legend5.Name = "Legend1";
            this.chartEtiquetas.Legends.Add(legend5);
            this.chartEtiquetas.Location = new System.Drawing.Point(488, 678);
            this.chartEtiquetas.Name = "chartEtiquetas";
            series5.ChartArea = "ChartArea1";
            series5.Legend = "Legend1";
            series5.Name = "Series1";
            this.chartEtiquetas.Series.Add(series5);
            this.chartEtiquetas.Size = new System.Drawing.Size(300, 219);
            this.chartEtiquetas.TabIndex = 7;
            this.chartEtiquetas.Text = "chart3";
            // 
            // FormDashboardVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FormDashboardVentas";
            this.Text = "FormDashboardVentas";
            this.Load += new System.EventHandler(this.FormDashboardVentas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartPeliculas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartBeneficios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartMetodosPago)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartEvolucionVentas)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartCajeros)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartClientes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartFranjaHoraria)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartEtiquetas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartPeliculas;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartBeneficios;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartMetodosPago;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartEvolucionVentas;
        private System.Windows.Forms.DateTimePicker DTPDesde;
        private System.Windows.Forms.DateTimePicker DTPHasta;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label LHasta;
        private System.Windows.Forms.Label LDesde;
        private System.Windows.Forms.Button BFiltrar;
        private System.Windows.Forms.Button BCerrar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartEtiquetas;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartFranjaHoraria;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartClientes;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartCajeros;
    }
}