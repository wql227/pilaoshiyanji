using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace DoPENetConnect
{
    public partial class FormPVPlot : Form
    {

        public double AxisXMax = 5;

        public List<double> chartX = new List<double>();
        public List<double> chartPosPeak = new List<double>();
        public List<double> chartPosValley = new List<double>();
        public List<double> chartLoadPeak = new List<double>();
        public List<double> chartLoadValley = new List<double>();

        public FormPVPlot()
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            Hide();
        }

        public void InitPVchartArea()
        {
            chartX.Clear();
            chartPosPeak.Clear();
            chartPosValley.Clear();
            chartLoadPeak.Clear();
            chartLoadValley.Clear();
            
        }

        public void AddPVData(int xdta, double pos_pdta, double pos_vdta, double load_pdta, double load_vdta)
        {
            chartX.Add(xdta);
            chartPosPeak.Add(pos_pdta);
            chartPosValley.Add(pos_vdta);
            chartLoadPeak.Add(load_pdta);
            chartLoadValley.Add(load_vdta);
        }

        public void ShowPvDtas()
        {
            if (chartX.Count > 0)
            {
                axTChart1.Series(0).AddArray(chartX.Count, chartPosPeak.ToArray(), chartX.ToArray());
                axTChart1.Series(1).AddArray(chartX.Count, chartPosValley.ToArray(), chartX.ToArray());
                axTChart1.Series(2).AddArray(chartX.Count, chartLoadPeak.ToArray(), chartX.ToArray());
                axTChart1.Series(3).AddArray(chartX.Count, chartLoadValley.ToArray(), chartX.ToArray());
            }
        }

        private void FormDensity_Load(object sender, EventArgs e)
        {
            axTChart1.Axis.Bottom.Minimum = 0;
            //axTChart1.Axis.Bottom.SetMinMax(0, AxisXMax);
            //axTChart1.Axis.Left.SetMinMax(0,10);
            //axTChart1.Axis.Right.SetMinMax(0,10);

            //axTChart1.Series(0).Color = (uint)(Color.Blue.B << 16) | (ushort)((Color.Blue.G << 8) | Color.Blue.R);
           // axTChart1.Series(1).Color = (uint)(Color.Red.B << 16) | (ushort)((Color.Red.G << 8) | Color.Red.R);

            axTChart1.Repaint();
            for (int i = 0; i < axTChart1.SeriesCount; i++) {
                axTChart1.Series(i).Clear();
            }

        }

        private void cb_ShowPosition_CheckedChanged(object sender, EventArgs e)
        {
            //bShowPosition = cb_ShowPosition.Checked;
            //axTChart1.Series(0).Active = bShowPosition;
            axTChart1.Series(0).Pen.Visible = cb_ShowPosition.Checked; 
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            ShowPvData();
        }

        public void ShowDensity()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Path.Combine(System.Environment.CurrentDirectory, "DynmaticPVData");
            openFileDialog.Filter = "Pv文件 (*.pv)|*.pv"; // 如果需要筛选特定类型的文件，如CSV
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog.FileName;
                // 使用选中的文件路径进行操作

                if (!string.IsNullOrEmpty(selectedFilePath))
                {
                    ExcelHelper excelHelper = new ExcelHelper(selectedFilePath);

                    string[] testInfo = { "", "", "", "", "", "", "", "" };
                    DataTable trCsvData = excelHelper.CSVToDataTableStatic(true, testInfo);
                    if (trCsvData == null) return;
                    //Console.WriteLine("glm-+testInfo{0}", testInfo);

                    #region reset chart zoom
                    axTChart1.Zoom.Undo();
                    #endregion


                    for (int i = 0; i < axTChart1.SeriesCount; i++)
                    {
                        axTChart1.Series(i).Clear();
                    }

                    axTChart1.Axis.Left.Automatic = true;
                    axTChart1.Axis.Bottom.Automatic = true;

                    chartX.Clear();
                    chartPosPeak.Clear();

                    if (trCsvData != null && trCsvData.Rows.Count >= 1)
                    {
                        //dpZero = new DataPoint(0, 0);
                        //chart_machine.Series[0].Points.Add(dpZero);
                        //chart_machine.Series[1].Points.Add(dpZero);
                        //chart_machine.Series[2].Points.Add(dpZero);
                        //chart_machine.Series[3].Points.Add(dpZero);
                        //chart_machine.Series[4].Points.Add(dpZero);
                        //chart_machine.Series[5].Points.Add(dpZero);

                        for (int i = 0; i < trCsvData.Rows.Count; i++)
                        {
                            //Console.WriteLine("glm-density{0}", trCsvData.Rows[i][0].ToString());
                            double strX = double.Parse(trCsvData.Rows[i][0].ToString());// double.Parse(trCsvData.Rows[i][2].ToString())/(Math.PI* double.Parse(trCsvData.Rows[i][7].ToString()) * double.Parse(trCsvData.Rows[i][7].ToString()))/4;    //横坐标改为试验力
                            double strYPos = double.Parse(trCsvData.Rows[i][5].ToString());
                            //double strYLoad = double.Parse(trCsvData.Rows[i][2].ToString());
                            //double strYExt = double.Parse(trCsvData.Rows[i][3].ToString());
                            //double strYCommand = double.Parse(trCsvData.Rows[i][4].ToString());

                            //double realX = 0;
                            //if (i != 7)
                            {
                                //realX = strX - double.Parse(trCsvData.Rows[0][0].ToString());
                            }

                            chartX.Add(strX);
                            chartPosPeak.Add(strYPos);
                            //axTChart1.Series(0).AddXY(strX, strYPos, null, 0);
                            //axTChart1.Series(1).AddXY(realX, strYLoad, null, 0);
                            //axTChart1.Series(2).AddXY(realX, strYExt, null, 0);
                            //axTChart1.Series(3).AddXY(realX, strYCommand, null, 0);
                            //axTChart1.Series(4).AddXY(strYPos, strYLoad, null, 0);
                            //axTChart1.Series(5).AddXY(strYExt, strYLoad, null, 0);


                        }
                        axTChart1.Series(0).AddArray(chartX.Count, chartPosPeak.ToArray(), chartX.ToArray());
                        //AutoFittingCurve(maxSeries0, minSeries0, maxSeries1, minSeries1, maxSeries2, minSeries2, maxSeries3, minSeries3);
                        //chart_machine.Invalidate();
                    }
                    else
                    {
                        MessageBox.Show("所选的文件内无数据！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }
        }
        public void ShowPvData()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Path.Combine(System.Environment.CurrentDirectory, "DynmaticPVData");
            openFileDialog.Filter = "Pv文件 (*.pv)|*.pv"; // 如果需要筛选特定类型的文件，如CSV
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog.FileName;
                // 使用选中的文件路径进行操作

                if (!string.IsNullOrEmpty(selectedFilePath))
                {
                    //ExcelHelper excelHelper = new ExcelHelper(selectedFilePath);

                    //string[] testInfo = { "", "", "", "", "", "", "", "" };
                    //DataTable trCsvData = excelHelper.CSVToDataTableStatic(true, testInfo);
                    //if (trCsvData == null) return;
                    //Console.WriteLine("glm-+testInfo{0}", testInfo);

                    #region reset chart zoom
                    axTChart1.Zoom.Undo();
                    #endregion


                    for (int i = 0; i < axTChart1.SeriesCount; i++)
                    {
                        axTChart1.Series(i).Clear();
                    }

                    axTChart1.Axis.Left.Automatic = true;
                    axTChart1.Axis.Bottom.Automatic = true;

                    chartX.Clear();
                    chartPosPeak.Clear();


                    //if (trCsvData != null && trCsvData.Rows.Count >= 1)
                    //{
                    //dpZero = new DataPoint(0, 0);
                    //chart_machine.Series[0].Points.Add(dpZero);
                    //chart_machine.Series[1].Points.Add(dpZero);
                    //chart_machine.Series[2].Points.Add(dpZero);
                    //chart_machine.Series[3].Points.Add(dpZero);
                    //chart_machine.Series[4].Points.Add(dpZero);
                    //chart_machine.Series[5].Points.Add(dpZero);
                    using (StreamReader sw = new StreamReader(selectedFilePath, Encoding.Default, true))
                    {
                        int dataIndex = 1;
                        while (!sw.EndOfStream)
                        {
                            string tmpLine = sw.ReadLine();
                            if (dataIndex > 1) {
                                chartX.Add(double.Parse(tmpLine.Split(',').ElementAt(6)));

                                chartPosPeak.Add(double.Parse(tmpLine.Split(',').ElementAt(0)));
                                chartPosValley.Add(double.Parse(tmpLine.Split(',').ElementAt(1)));
                                chartLoadPeak.Add(double.Parse(tmpLine.Split(',').ElementAt(2)));
                                chartLoadValley.Add(double.Parse(tmpLine.Split(',').ElementAt(3)));
                            }
                            dataIndex++;
                        }

                        axTChart1.Series(0).AddArray(chartX.Count, chartPosPeak.ToArray(), chartX.ToArray());
                        axTChart1.Series(1).AddArray(chartX.Count, chartPosValley.ToArray(), chartX.ToArray());
                        axTChart1.Series(2).AddArray(chartX.Count, chartLoadPeak.ToArray(), chartX.ToArray());
                        axTChart1.Series(3).AddArray(chartX.Count, chartLoadValley.ToArray(), chartX.ToArray());

                        //for (int i = 0; i < trCsvData.Rows.Count; i++)
                        //{
                        //    //Console.WriteLine("glm-density{0}", trCsvData.Rows[i][0].ToString());
                        //    double strX = double.Parse(trCsvData.Rows[i][0].ToString());// double.Parse(trCsvData.Rows[i][2].ToString())/(Math.PI* double.Parse(trCsvData.Rows[i][7].ToString()) * double.Parse(trCsvData.Rows[i][7].ToString()))/4;    //横坐标改为试验力
                        //    double strYPos = double.Parse(trCsvData.Rows[i][5].ToString());
                        //    //double strYLoad = double.Parse(trCsvData.Rows[i][2].ToString());
                        //    //double strYExt = double.Parse(trCsvData.Rows[i][3].ToString());
                        //    //double strYCommand = double.Parse(trCsvData.Rows[i][4].ToString());

                        //    //double realX = 0;
                        //    //if (i != 7)
                        //    {
                        //        //realX = strX - double.Parse(trCsvData.Rows[0][0].ToString());
                        //    }

                        //    chartX.Add(strX);
                        //    chartPosPeak.Add(strYPos);
                        //    //axTChart1.Series(0).AddXY(strX, strYPos, null, 0);
                        //    //axTChart1.Series(1).AddXY(realX, strYLoad, null, 0);
                        //    //axTChart1.Series(2).AddXY(realX, strYExt, null, 0);
                        //    //axTChart1.Series(3).AddXY(realX, strYCommand, null, 0);
                        //    //axTChart1.Series(4).AddXY(strYPos, strYLoad, null, 0);
                        //    //axTChart1.Series(5).AddXY(strYExt, strYLoad, null, 0);


                        //}
                        //axTChart1.Series(0).AddArray(chartX.Count, chartPosPeak.ToArray(), chartX.ToArray());
                        ////AutoFittingCurve(maxSeries0, minSeries0, maxSeries1, minSeries1, maxSeries2, minSeries2, maxSeries3, minSeries3);
                        ////chart_machine.Invalidate();
                    }
                    //else
                    //{
                    //    MessageBox.Show("所选的文件内无数据！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    return;
                    //}
                }
            }
        }

        private void FormDensity_Shown(object sender, EventArgs e)
        {
            //ShowDensity();
            ShowPvDtas();
        }

        private void FormPVPlot_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                datarefresh_timer.Start();
                ShowPvDtas();
            }
            else if (!this.Visible) {
                datarefresh_timer.Stop();
            }
        }

        private void datarefresh_timer_Tick(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                ShowPvDtas();
            }
        }

        private void axTChart1_OnClickLegend(object sender, AxTeeChart.ITChartEvents_OnClickLegendEvent e)
        {
            axTChart1.Series(1).Active = axTChart1.Series(0).Active;
            axTChart1.Series(3).Active = axTChart1.Series(2).Active;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MainForm.mainform.isRunning)
            {
                MessageBox.Show("试验正在运行，请等待试验结束或者手动点击结束按钮后再试！","警告",MessageBoxButtons.OK,MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                return;
            }

            InitPVchartArea();
            for (int i = 0; i < 4; i++)
                axTChart1.Series(i).Clear();
            ShowPvData();
        }
    }
}
