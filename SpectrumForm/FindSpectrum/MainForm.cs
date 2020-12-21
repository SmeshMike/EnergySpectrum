using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FindSpectrum
{
    public partial class MainForm : Form
    {
        MethodMath mm;
        private List<List<double>> chart;
        private List<List<MethodMath.Complex>> chartComplex;
        public MainForm()
        {
            InitializeComponent();
            var r = Convert.ToDouble(rTextBox.Text);
            var step = Convert.ToDouble(stepTextBox.Text.Replace('.', ','));
            mm = new MethodMath(step,r);
            chart = new List<List<double>>();
            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();

            this.chart1.BorderlineColor = System.Drawing.Color.Black;
            this.chart1.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea1.Name = "ChartArea1";
            chartArea1.ShadowColor = System.Drawing.Color.Black;
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(5, 2);
            this.chart1.Name = "SignalChart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Legend = "Legend1";
            series2.Name = "Series2";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(910, 510);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            this.Controls.Add(this.chart1);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
        }

        private void drawButton_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
           
            var k = Convert.ToInt32(orderTextBox.Text);

            for (var i = -mm.R; i <= mm.R; i += mm.Step)
            {
                int index = Convert.ToInt32((i + mm.R) / mm.Step);
                chart1.Series[0].Points.AddXY(i, chart[k][index]);
            }
        }

        private void runStaticButtonClick(object sender, EventArgs e)
        {
            mm.R = Convert.ToDouble(rTextBox.Text);

            mm.Step = Convert.ToDouble(stepTextBox.Text.Replace('.', ','));
            mm.K = Convert.ToDouble(kTextBox.Text);

            var maxK = Convert.ToInt32(maxKTextBox.Text);

            chart = mm.FindStationaryPsi(maxK);
        }

        private void runEvolutionButtonClick(object sender, EventArgs e)
        {
            mm.R = Convert.ToDouble(rTextBox.Text);

            mm.Step = Convert.ToDouble(stepTextBox.Text.Replace('.', ','));
            mm.K = Convert.ToDouble(kTextBox.Text);

            var maxT = Convert.ToInt32(tMaxTextBox.Text);

            chartComplex = mm.FindEvolution(maxT);
        }

        private void drawEvolutionButton_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();

            var t = Convert.ToInt32(tTextBox.Text);

            for (var i = -mm.R; i <= mm.R; i += mm.Step)
            {
                int index = Convert.ToInt32((i + mm.R) / mm.Step);
                chart1.Series[0].Points.AddXY(i, chartComplex[t][index].Real);
            }
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            var step = Convert.ToDouble(stepTextBox.Text.Replace('.', ','));
            var r = Convert.ToDouble(rTextBox.Text);
            mm.Refresh(step, r);
        }
    }
}
