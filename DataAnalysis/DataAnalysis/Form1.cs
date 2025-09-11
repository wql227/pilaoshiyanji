using NPOI.Util;
using NPOI.XWPF.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DataAnalysis
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// 选择的循环次数
        /// </summary>
        public string strSelCycleValue = "";

        /// <summary>
        /// 波形数据
        /// </summary>
        public DataTable WaveData = null;

        /// <summary>
        /// 配置文件
        /// </summary>
        SettingClass setting = new SettingClass();


        public Form1()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 加载数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_LoadData_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = System.Environment.CurrentDirectory;
            openFileDialog.Filter = "CSV文件 (*.csv)|*.csv"; // 如果需要筛选特定类型的文件，如CSV
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog.FileName;
                // 使用选中的文件路径进行操作

                if (!string.IsNullOrEmpty(selectedFilePath))
                {
                    ExcelHelper excelHelper = new ExcelHelper(selectedFilePath);

                    WaveData = excelHelper.CSVToDataTable(false);

                    if (WaveData != null && WaveData.Rows.Count >= 1)
                    {
                        //获取循环次数列
                        List<string> values = WaveData.AsEnumerable()
                                          .Select(row => row.Field<string>("循环"))
                                          .Distinct().ToList();

                        //是否存在前一次测试的最后一次循环的数据，有的话删除
                        //if (values.Count > 2)
                        {
                             //string fdsfsdfsd = values[0].ToString();
                            //if (int.Parse(values[0]) > int.Parse(values[1]))
                            {
                                var filteredRows = WaveData.AsEnumerable()
                                .SkipWhile(row =>
                                {
                                    return int.TryParse(row["循环"].ToString(), out int cycle) && cycle != 0;
                                })
                                .ToList();
                                //.CopyToDataTable();

                                //WaveData = validData;

                                DataTable validData;

                                if (filteredRows.Any())
                                {
                                    validData = filteredRows.CopyToDataTable();
                                    WaveData = validData;
                                }
                                //else
                                //{
                                //    // 如果没有符合条件的行，创建一个结构相同但无数据的表
                                //    validData = WaveData.Clone(); // Clone() 只复制结构，不复制数据
                                //}


                                values = WaveData.AsEnumerable()
                                          .Select(row => row.Field<string>("循环"))
                                          .Distinct().ToList();
                            }
                        }

                        dgv_Cycle.DataSource = values.Select(val => new { CycleValue = val }).ToList();

                        LoadCycleDate();

                        LoadCycleChartWaveData();

                        LoadCycleChartDataAll();

                        LoadCycleChartData1();
                        LoadCycleChartData2();
                        LoadCycleChartData3();

                    }

                }

            }

        }

        private void dgv_Cycle_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int nRowIndex = dgv_Cycle.CurrentRow.Index;

            if (nRowIndex < 0)
            {
                return;
            }

            strSelCycleValue = dgv_Cycle.Rows[nRowIndex].Cells[0].Value.ToString();

            List<string> targetValues = new List<string> { "0", "1", "2" }; // 示例值

            DataTable resultTable = WaveData.AsEnumerable()
                .Where(row => targetValues.Contains(row.Field<string>("循环")))
                .CopyToDataTable();

        }

        /// <summary>
        /// 加载指定次数的循环数据
        /// </summary>
        public void LoadCycleDate()
        {
            // 使用 LINQ 进行分组和聚合
            var cycleStats = from row in WaveData.AsEnumerable()
                             group row by row.Field<string>("循环") into g // 按 "循环" 列分组
                             select new
                             {
                                 Cycle = g.Key, // 循环编号
                                 Max_Position = g.Max(r => Convert.ToDouble(r.Field<string>("位移[mm]"))),
                                 Min_Position = g.Min(r => Convert.ToDouble(r.Field<string>("位移[mm]"))),
                                 Max_Load = g.Max(r => Convert.ToDouble(r.Field<string>("试验力[N]"))),
                                 Min_Load = g.Min(r => Convert.ToDouble(r.Field<string>("试验力[N]"))),
                                 Average_Load = Math.Round(g.Average(r => Convert.ToDouble(r.Field<string>("试验力[N]"))), 6)
                                 //Max_Extension = groupby.Max(r => r.Field<double>("变形[mm]")),
                                 //Min_Extension = groupby.Min(r => r.Field<double>("变形[mm]")),
                                 //Max_Command = groupby.Max(r => r.Field<double>("命令")),
                                 //Min_Command = groupby.Min(r => r.Field<double>("命令")),
                                 //Max_Output = groupby.Max(r => r.Field<double>("输出[%]")),
                                 //Min_Output = groupby.Min(r => r.Field<double>("输出[%]")),
                                 //Max_Feedback = groupby.Max(r => r.Field<double>("反馈"))
                                 // Min_Feedback 可以根据需要添加
                             };

            dvg_CycleData.DataSource = cycleStats.ToList();
        }


        /// <summary>
        /// 加载数据到图表
        /// </summary>
        public void LoadCycleChartData1()
        {
            if (string.IsNullOrEmpty("0"))
            {
                return;
            }

            string strCycle1 = "";
            if (dgv_Cycle.Rows.Count >= 5)
            //for (int i = 0; i < dgv_Cycle.Rows.Count; i++)
            {
                strCycle1 = dgv_Cycle.Rows[1].Cells[0].Value.ToString();
            }

            if (string.IsNullOrEmpty(strCycle1))
            {
                return;
            }

            DataTable dtSeldt =  SelCountWave(int.Parse(strCycle1));

            DataPoint dpPosLoad = null;
            DataPoint dpLoad = null;
            DataPoint dpExt = null;
            DataPoint dpCommand = null;

            chart1.Titles[0].Text = string.Format(@"阻尼力-位移曲线（第 1 次）");

            //清除原有数据
            for (int i = 0; i < chart1.Series[0].Points.Count; i++)
            {
                chart1.Series[0].Points.RemoveAt(i);
            }

            chart1.Series[0].Points.Clear();

            //加载新数据
            if (dtSeldt != null && dtSeldt.Rows.Count >= 1)
            {
                for (int i = 0; i < dtSeldt.Rows.Count; i++)
                {
                    double strX = double.Parse(dtSeldt.Rows[i][0].ToString());
                    double strYPos = double.Parse(dtSeldt.Rows[i][1].ToString());
                    double strYLoad = double.Parse(dtSeldt.Rows[i][2].ToString());
                    double strYExt = double.Parse(dtSeldt.Rows[i][3].ToString());
                    double strYCommand = double.Parse(dtSeldt.Rows[i][4].ToString());
                    double strYOutput = double.Parse(dtSeldt.Rows[i][6].ToString());
                    double strYfeedback = double.Parse(dtSeldt.Rows[i][7].ToString());

                    //dpPosLoad = new DataPoint(strX, strYLoad);
                    dpPosLoad = new DataPoint(strYPos, strYLoad);
                    dpLoad = new DataPoint(strX, strYLoad);
                    dpExt = new DataPoint(strX, strYExt);
                    dpCommand = new DataPoint(strX, strYCommand);

                    chart1.Series[0].Points.Add(dpPosLoad);
                    //chart1.Series[1].Points.Add(dpLoad);
                    //chart1.Series[2].Points.Add(dpExt);
                    //chart1.Series[3].Points.Add(dpCommand);
                }
            }
            else
            {
                MessageBox.Show("所选的文件内无数据！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

        }

        /// <summary>
        /// 加载数据到图表
        /// </summary>
        public void LoadCycleChartData2()
        {
            if (string.IsNullOrEmpty("1"))
            {
                return;
            }

            string strCycle2 = "";
            if (dgv_Cycle.Rows.Count >= 5)
            //for (int i= 0; i < dgv_Cycle.Rows.Count; i++)
            {
                strCycle2 = dgv_Cycle.Rows[2].Cells[0].Value.ToString();
                //break;
            }

            if (string.IsNullOrEmpty(strCycle2))
            {
                return;
            }

            DataTable dtSeldt = SelCountWave(int.Parse(strCycle2));

            DataPoint dpPosLoad = null;
            DataPoint dpLoad = null;
            DataPoint dpExt = null;
            DataPoint dpCommand = null;

            chart2.Titles[0].Text = string.Format(@"阻尼力-位移曲线（第 2 次）");

            //清除原有数据
            for (int i = 0; i < chart2.Series[0].Points.Count; i++)
            {
                chart2.Series[0].Points.RemoveAt(i);
            }

            chart2.Series[0].Points.Clear();

            //加载新数据
            if (dtSeldt != null && dtSeldt.Rows.Count >= 1)
            {
                for (int i = 0; i < dtSeldt.Rows.Count; i++)
                {
                    double strX = double.Parse(dtSeldt.Rows[i][0].ToString());
                    double strYPos = double.Parse(dtSeldt.Rows[i][1].ToString());
                    double strYLoad = double.Parse(dtSeldt.Rows[i][2].ToString());
                    double strYExt = double.Parse(dtSeldt.Rows[i][3].ToString());
                    double strYCommand = double.Parse(dtSeldt.Rows[i][4].ToString());
                    double strYOutput = double.Parse(dtSeldt.Rows[i][6].ToString());
                    double strYfeedback = double.Parse(dtSeldt.Rows[i][7].ToString());

                    //dpPosLoad = new DataPoint(strX, strYLoad);
                    dpPosLoad = new DataPoint(strYPos, strYLoad);
                    dpLoad = new DataPoint(strX, strYLoad);
                    dpExt = new DataPoint(strX, strYExt);
                    dpCommand = new DataPoint(strX, strYCommand);

                    chart2.Series[0].Points.Add(dpPosLoad);
                    //chart1.Series[1].Points.Add(dpLoad);
                    //chart1.Series[2].Points.Add(dpExt);
                    //chart1.Series[3].Points.Add(dpCommand);
                }
            }
            else
            {
                MessageBox.Show("所选的文件内无数据！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

        }


        /// <summary>
        /// 加载数据到图表
        /// </summary>
        public void LoadCycleChartData3()
        {
            if (string.IsNullOrEmpty("3"))
            {
                return;
            }

            string strCycle3 = "";
            if (dgv_Cycle.Rows.Count >= 5)
            //for (int i = 0; i < dgv_Cycle.Rows.Count; i++)
            {
                strCycle3 = dgv_Cycle.Rows[3].Cells[0].Value.ToString();
                //break;
            }

            if (string.IsNullOrEmpty(strCycle3))
            {
                return;
            }

            DataTable dtSeldt = SelCountWave(int.Parse(strCycle3));

            DataPoint dpPosLoad = null;
            DataPoint dpLoad = null;
            DataPoint dpExt = null;
            DataPoint dpCommand = null;

            chart3.Titles[0].Text = string.Format(@"阻尼力-位移曲线（第 3 次）");

            //清除原有数据
            for (int i = 0; i < chart3.Series[0].Points.Count; i++)
            {
                chart3.Series[0].Points.RemoveAt(i);
            }

            chart3.Series[0].Points.Clear();

            //加载新数据
            if (dtSeldt != null && dtSeldt.Rows.Count >= 1)
            {
                for (int i = 0; i < dtSeldt.Rows.Count; i++)
                {
                    double strX = double.Parse(dtSeldt.Rows[i][0].ToString());
                    double strYPos = double.Parse(dtSeldt.Rows[i][1].ToString());
                    double strYLoad = double.Parse(dtSeldt.Rows[i][2].ToString());
                    double strYExt = double.Parse(dtSeldt.Rows[i][3].ToString());
                    double strYCommand = double.Parse(dtSeldt.Rows[i][4].ToString());
                    double strYOutput = double.Parse(dtSeldt.Rows[i][6].ToString());
                    double strYfeedback = double.Parse(dtSeldt.Rows[i][7].ToString());

                    //dpPosLoad = new DataPoint(strX, strYLoad);
                    dpPosLoad = new DataPoint(strYPos, strYLoad);
                    dpLoad = new DataPoint(strX, strYLoad);
                    dpExt = new DataPoint(strX, strYExt);
                    dpCommand = new DataPoint(strX, strYCommand);

                    chart3.Series[0].Points.Add(dpPosLoad);
                    //chart1.Series[1].Points.Add(dpLoad);
                    //chart1.Series[2].Points.Add(dpExt);
                    //chart1.Series[3].Points.Add(dpCommand);
                }
            }
            else
            {
                MessageBox.Show("所选的文件内无数据！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

        }


        /// <summary>
        /// 加载数据到图表
        /// </summary>
        public void LoadCycleChartDataAll()
        {
            var targetValues = new List<string>();
            int rowCount = Math.Min(4, dgv_Cycle.Rows.Count);
            string strCycle1 = "";
            for (int i = 0; i < rowCount; i++)
            {
                strCycle1 = dgv_Cycle.Rows[i].Cells[0].Value.ToString();
                targetValues.Add(strCycle1?.ToString() ?? "");
            }

            if (string.IsNullOrEmpty(strCycle1))
            {
                return;
            }

            //var targetValues = new List<string> { "0", "1", "2", "3" };

            try
            {
                // 查询“循环”列等于 A 或 C 的所有行
                DataTable resultTable = WaveData.AsEnumerable()
                    .Where(row => targetValues.Contains(row.Field<string>("循环")))
                    .CopyToDataTable();

                if (string.IsNullOrEmpty("0"))
                {
                    return;
                }

                DataTable dtSeldt = resultTable;

                DataPoint dpPosLoad = null;
                DataPoint dpLoad = null;
                DataPoint dpExt = null;
                DataPoint dpCommand = null;

                //chart1.Titles[0].Text = string.Format(@"阻尼力-位移曲线（第 1 次）");

                //清除原有数据
                for (int i = 0; i < chart4.Series[0].Points.Count; i++)
                {
                    chart4.Series[0].Points.RemoveAt(i);
                }

                chart4.Series[0].Points.Clear();

                //加载新数据
                if (dtSeldt != null && dtSeldt.Rows.Count >= 1)
                {
                    for (int i = 0; i < dtSeldt.Rows.Count; i++)
                    {
                        double strX = double.Parse(dtSeldt.Rows[i][0].ToString());
                        double strYPos = double.Parse(dtSeldt.Rows[i][1].ToString());
                        double strYLoad = double.Parse(dtSeldt.Rows[i][2].ToString());
                        double strYExt = double.Parse(dtSeldt.Rows[i][3].ToString());
                        double strYCommand = double.Parse(dtSeldt.Rows[i][4].ToString());
                        double strYOutput = double.Parse(dtSeldt.Rows[i][6].ToString());
                        double strYfeedback = double.Parse(dtSeldt.Rows[i][7].ToString());

                        //dpPosLoad = new DataPoint(strX, strYLoad);
                        dpPosLoad = new DataPoint(strYPos, strYLoad);
                        dpLoad = new DataPoint(strX, strYLoad);
                        dpExt = new DataPoint(strX, strYExt);
                        dpCommand = new DataPoint(strX, strYCommand);

                        chart4.Series[0].Points.Add(dpPosLoad);
                        //chart1.Series[1].Points.Add(dpLoad);
                        //chart1.Series[2].Points.Add(dpExt);
                        //chart1.Series[3].Points.Add(dpCommand);
                    }
                }
                else
                {
                    MessageBox.Show("所选的文件内无数据！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("所选的文件数据不足！" + ex.ToString(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

        }


        /// <summary>
        /// 加载数据到图表
        /// </summary>
        public void LoadCycleChartWaveData()
        {
            var targetValues = new List<string>();
            int rowCount = Math.Min(4, dgv_Cycle.Rows.Count);
            string strCycle1 = "";
            for (int i = 0; i < rowCount; i++)
            {
                strCycle1 = dgv_Cycle.Rows[i].Cells[0].Value.ToString();
                targetValues.Add(strCycle1?.ToString() ?? "");
            }

            if (string.IsNullOrEmpty(strCycle1))
            {
                return;
            }
            try
            {
                // 查询“循环”列等于 A 或 C 的所有行
                DataTable resultTable = WaveData.AsEnumerable()
                    .Where(row => targetValues.Contains(row.Field<string>("循环")))
                    .CopyToDataTable();

                if (string.IsNullOrEmpty("0"))
                {
                    return;
                }

                DataTable dtSeldt = resultTable;

                DataPoint dpPosLoad = null;
                DataPoint dpPos = null;
                DataPoint dpLoad = null;
                DataPoint dpExt = null;
                DataPoint dpCommand = null;

                //清除原有数据
                //for (int i = 0; i < chart5.Series[0].Points.Count; i++)
                //{
                //    chart5.Series[0].Points.RemoveAt(i);
                //    chart5.Series[1].Points.RemoveAt(i);
                //}

                chart5.Series[0].Points.Clear();
                chart5.Series[1].Points.Clear();

                //加载新数据
                if (dtSeldt != null && dtSeldt.Rows.Count >= 1)
                {
                    for (int i = 0; i < dtSeldt.Rows.Count; i++)
                    {
                        double strX = double.Parse(dtSeldt.Rows[i][0].ToString());
                        double strYPos = double.Parse(dtSeldt.Rows[i][1].ToString());
                        double strYLoad = double.Parse(dtSeldt.Rows[i][2].ToString());
                        double strYExt = double.Parse(dtSeldt.Rows[i][3].ToString());
                        double strYCommand = double.Parse(dtSeldt.Rows[i][4].ToString());
                        double strYOutput = double.Parse(dtSeldt.Rows[i][6].ToString());
                        double strYfeedback = double.Parse(dtSeldt.Rows[i][7].ToString());

                        dpLoad = new DataPoint(strX, strYLoad);
                        dpPos = new DataPoint(strX, strYPos);
                        //dpPosLoad = new DataPoint(strYPos, strYLoad);
                        dpExt = new DataPoint(strX, strYExt);
                        dpCommand = new DataPoint(strX, strYCommand);

                        chart5.Series[0].Points.Add(dpLoad);
                        chart5.Series[1].Points.Add(dpPos);
                        //chart1.Series[1].Points.Add(dpLoad);
                        //chart1.Series[2].Points.Add(dpExt);
                        //chart1.Series[3].Points.Add(dpCommand);
                    }
                }
                else
                {
                    MessageBox.Show("所选的文件内无数据！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("所选的文件数据不足！" + ex.ToString(), "异常", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

        }



        public DataTable SelCountWave(int nCount)
        {
            // 要筛选的列名和目标值
            string columnName = "循环";
            string targetValue = nCount.ToString();

            // 使用 Select 方法筛选行
            DataRow[] filteredRows = WaveData.Select($"{columnName} = '{targetValue}'");

            // 创建新 DataTable，结构与原表相同
            DataTable resultTable = WaveData.Clone(); // Clone 只复制结构，不复制数据

            // 将筛选出的行导入新表
            foreach (DataRow row in filteredRows)
            {
                resultTable.ImportRow(row);
            }

            return resultTable;
        }


        private void Form1_Load(object sender, EventArgs e)
        {

            LoadIni();
        }


        /// <summary>
        /// 加载配置文件
        /// </summary>
        public void LoadIni()
        {
            IniFileHelper iniFileHelper = new IniFileHelper(@"Setting.ini");
            StringBuilder strTmp = new StringBuilder(255);

            #region 加载报告参数
            //报告标题
            IniFileHelper.GetIniString("Setting", "ReportTitle", "试验检测报告", strTmp, strTmp.Capacity);
            setting.ReportTitle = strTmp.ToString();

            //环境温度
            IniFileHelper.GetIniString("Setting", "EnvironmentTemperature", "26", strTmp, strTmp.Capacity);
            setting.EnvironmentTemperature = strTmp.ToString();

            //试验温度
            IniFileHelper.GetIniString("Setting", "ExperimentalTemperature", "26", strTmp, strTmp.Capacity);
            setting.ExperimentalTemperature = strTmp.ToString();

            //试验设备
            IniFileHelper.GetIniString("Setting", "TestingEquipment", "设备", strTmp, strTmp.Capacity);
            setting.TestingEquipment = strTmp.ToString();

            //试验规格
            IniFileHelper.GetIniString("Setting", "SampleSpecification", "规格", strTmp, strTmp.Capacity);
            setting.SampleSpecification = strTmp.ToString();

            //试验人员
            IniFileHelper.GetIniString("Setting", "Tester", "测试人员", strTmp, strTmp.Capacity);
            setting.Tester = strTmp.ToString();

            //审核人员
            IniFileHelper.GetIniString("Setting", "Auditor", "审核人员", strTmp, strTmp.Capacity);
            setting.Auditor = strTmp.ToString();

            //控制方式
            IniFileHelper.GetIniString("Setting", "MoveCtrl", "POS", strTmp, strTmp.Capacity);
            setting.MoveCtrl = strTmp.ToString();

            //波形显示
            IniFileHelper.GetIniString("Setting", "WaveCtrl", "余弦波", strTmp, strTmp.Capacity);
            setting.WaveCtrl = strTmp.ToString();

            //中值
            IniFileHelper.GetIniString("Setting", "Offset", "0", strTmp, strTmp.Capacity);
            setting.MoveOffset = strTmp.ToString();

            //振幅
            IniFileHelper.GetIniString("Setting", "Amplitude", "0", strTmp, strTmp.Capacity);
            setting.MoveAmplitude = strTmp.ToString();

            //频率
            IniFileHelper.GetIniString("Setting", "Frequency", "0", strTmp, strTmp.Capacity);
            setting.MoveFrequency = strTmp.ToString();

            #endregion

            #region 图表调整

            //位移Y轴最大值
            IniFileHelper.GetIniString("FrmSetChartAxisY", "PositionY_MAX", "0", strTmp, strTmp.Capacity);
            setting.PosYAxisMax = double.Parse(strTmp.ToString());

            //位移Y轴最小值
            IniFileHelper.GetIniString("FrmSetChartAxisY", "PositionY_MIN", "0", strTmp, strTmp.Capacity);
            setting.PosYAxisMax = double.Parse(strTmp.ToString());

            //位移Y轴调整量程
            IniFileHelper.GetIniString("FrmSetChartAxisY", "PosRange", "0", strTmp, strTmp.Capacity);
            setting.PosYAxisMax = double.Parse(strTmp.ToString());

            //阻尼力Y轴最大值
            IniFileHelper.GetIniString("FrmSetChartAxisY", "LoadY_MAX", "0", strTmp, strTmp.Capacity);
            setting.PosYAxisMax = double.Parse(strTmp.ToString());

            //阻尼力Y轴最小值
            IniFileHelper.GetIniString("FrmSetChartAxisY", "LoadY_MIN", "0", strTmp, strTmp.Capacity);
            setting.PosYAxisMax = double.Parse(strTmp.ToString());

            //阻尼力Y轴调整量程
            IniFileHelper.GetIniString("FrmSetChartAxisY", "LoadRange", "0", strTmp, strTmp.Capacity);
            setting.PosYAxisMax = double.Parse(strTmp.ToString());

            #endregion
        }


        /// <summary>
        /// 写入配置文件
        /// </summary>
        public void WriteIni()
        {
            //IniFileHelper iniFileHelper = new IniFileHelper(@"Config.ini");
            ////环境温度
            //IniFileHelper.WriteIniString("Setting", "EnvironmentTemperature", tbX_EnvironmentTemperature.Text.ToString());
            //setting.EnvironmentTemperature = tbX_EnvironmentTemperature.Text.ToString();

            ////试验温度
            //IniFileHelper.WriteIniString("Setting", "EnvironmentTemperature", tbX_ExperimentalTemperature.Text.ToString());
            //setting.EnvironmentTemperature = tbX_ExperimentalTemperature.Text.ToString();

            ////试验设备
            //IniFileHelper.WriteIniString("Setting", "TestingEquipment", tbX_TestingEquipment.Text.ToString());
            //setting.EnvironmentTemperature = tbX_TestingEquipment.Text.ToString();

            ////试验规格
            //IniFileHelper.WriteIniString("Setting", "SampleSpecification", tbX_SampleSpecification.Text.ToString());
            //setting.EnvironmentTemperature = tbX_SampleSpecification.Text.ToString();

            ////试验人员
            //IniFileHelper.WriteIniString("Setting", "Tester", tbX_Tester.Text.ToString());
            //setting.EnvironmentTemperature = tbX_Tester.Text.ToString();

            ////审核人员
            //IniFileHelper.WriteIniString("Setting", "Auditor", tbX_Auditor.Text.ToString());
            //setting.EnvironmentTemperature = tbX_Auditor.Text.ToString();

            ////控制方式
            //IniFileHelper.WriteIniString("Setting", "MoveCtrl", cbX_MoveCtrl.Text);
            //setting.MoveCtrl = cbX_MoveCtrl.Text.ToString();

            ////波形显示
            //IniFileHelper.WriteIniString("Setting", "WaveCtrl", tbX_WaveCtrl.Text);
            //setting.WaveCtrl = tbX_WaveCtrl.Text;

            ////中值
            //IniFileHelper.WriteIniString("Setting", "Offset", tbX_WaveCtrl.Text);
            //setting.MoveOffset = tbX_WaveCtrl.Text.ToString();

            ////振幅
            //IniFileHelper.WriteIniString("Setting", "Amplitude", tbX_WaveCtrl.Text);
            //setting.MoveAmplitude = tbX_WaveCtrl.Text.ToString();

            ////频率
            //IniFileHelper.WriteIniString("Setting", "Frequency", tbX_Frequency.Text);
            //setting.MoveFrequency = tbX_Frequency.Text.ToString();
        }



        /// <summary>
        /// 导出报告
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ExportReport_Click(object sender, EventArgs e)
        {
            string dt = DateTime.Now.ToString("yyyyMMddhhmmssfff");
            //位移阻尼力 第一次
            string strFileName1 = String.Format(@"C:\ChartDataImg\{0}1.png", dt);

            //位移阻尼力 第二次
            string strFileName2 = String.Format(@"C:\ChartDataImg\{0}2.png", dt);

            //位移阻尼力 第三次
            string strFileName3 = String.Format(@"C:\ChartDataImg\{0}3.png", dt);

            //位移阻尼力 循环叠加
            string strFileName4 = String.Format(@"C:\ChartDataImg\{0}4.png", dt);

            //位移阻尼力 时间-阻尼力-位移 
            string strFileName5 = String.Format(@"C:\ChartDataImg\{0}5.png", dt);

            chart1.SaveImage(strFileName1, ChartImageFormat.Png);
            chart2.SaveImage(strFileName2, ChartImageFormat.Png);
            chart3.SaveImage(strFileName3, ChartImageFormat.Png);
            chart4.SaveImage(strFileName4, ChartImageFormat.Png);
            chart5.SaveImage(strFileName5, ChartImageFormat.Png);

            try
            {
                // 选择保存路径
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "Word 文件 (*.docx)|*.docx",
                    FileName = string.Format(@"报告{0}.docx", dt)
                };

                if (saveFileDialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                string filePath = saveFileDialog.FileName;

                // 创建 Word 文档
                XWPFDocument doc = new XWPFDocument();
                string strTmp = "";
                //添加标题
                AddParagraph(doc, "阻尼力-位移试验检测报告", true, 16, "center");

                // 环境温度
                strTmp = string.Format(@"{0} ℃", setting.EnvironmentTemperature );
                AddParagraph(doc, "环境温度：" + strTmp, false, 12, "left");

                // 试验温度
                strTmp = string.Format(@"{0} ℃", setting.ExperimentalTemperature);
                AddParagraph(doc, "试验温度：" + strTmp, false, 12, "left");

                // 试验设备
                strTmp = string.Format(@"{0}", setting.TestingEquipment);
                AddParagraph(doc, "试验设备：" + strTmp, false, 12, "left");

                // 试样规格
                strTmp = string.Format(@"{0}", setting.SampleSpecification);
                AddParagraph(doc, "试样规格：" + strTmp, false, 12, "left");

                // 试验输入参数
                strTmp = string.Format(@"控制波形：{0}；中值：{1} mm；幅值：{2} mm；控制频率：{3} Hz；", 
                    setting.WaveCtrl, setting.MoveOffset, setting.MoveAmplitude, setting.MoveFrequency);
                AddParagraph(doc, "试验输入参数：" + strTmp, false, 12, "left");

                // 添加日期
                AddParagraph(doc, $"报告生成时间：{DateTime.Now:yyyy-MM-dd HH:mm:ss}", false, 12, "left");

                // 添加空行
                AddParagraph(doc, "", false, 12, "left");

                // 添加描述性文字
                AddParagraph(doc, "本次检测共有5组图像，详细信息如下：", false, 12, "left");

                //时间位移阻尼力 文字和图像
                AddParagraph(doc, "时间-阻尼力-位移 图像", false, 12, "left");
                AddImage(doc, strFileName5);

                //位移阻尼力 波形叠加图像
                AddParagraph(doc, "阻尼力-位移 叠加图像", false, 12, "left");
                AddImage(doc, strFileName4);

                //位移阻尼力 波形叠加图像
                AddParagraph(doc, "阻尼力-位移 第一次循环", false, 12, "left");
                AddImage(doc, strFileName1);

                //位移阻尼力 波形叠加图像
                AddParagraph(doc, "阻尼力-位移 第二次循环", false, 12, "left");
                AddImage(doc, strFileName2);

                //位移阻尼力 波形叠加图像
                AddParagraph(doc, "阻尼力-位移 第三次循环", false, 12, "left");
                AddImage(doc, strFileName3);

                // 插入图片（替换为你的图片路径）
                //string imagePath = @"C:\chart.png";
                //AddImage(doc, imagePath);
       
                //添加结论
                AddParagraph(doc, "结论：已生成试验报告。", true, 12, "left");

                //添加实验人员
                strTmp = string.Format(@"试验员：{0}     审核：{1}   ",
                    setting.Tester, setting.Auditor);
                AddParagraph(doc, strTmp, true, 12, "left");

                //保存文件
                using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    doc.Write(fs);
                }

                MessageBox.Show(" Word 报告导出成功！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DeleteAllImg();
            }
            catch (Exception ex)
            {
                MessageBox.Show("导出失败：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DeleteAllImg();
            }
        }


        /// <summary>
        /// 添加段落
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="text"></param>
        /// <param name="isBold"></param>
        /// <param name="fontSize"></param>
        /// <param name="align"></param>
        private void AddParagraph(XWPFDocument doc, string text, bool isBold, int fontSize, string align = "left")
        {
            XWPFParagraph para = doc.CreateParagraph();

            switch (align.ToLower())
            {
                case "center":
                    {
                        para.Alignment = ParagraphAlignment.CENTER;
                        break;
                    }
                case "right":
                    {
                        para.Alignment = ParagraphAlignment.RIGHT;
                        break;
                    }
                case "left":
                default:
                    {
                        para.Alignment = ParagraphAlignment.LEFT;
                        break;
                    }
            }

            XWPFRun run = para.CreateRun();
            run.SetText(text);
            run.FontSize = fontSize;
            run.IsBold = isBold;
            run.FontFamily = "宋体";
        }


        //添加图像
        /// <summary>
        /// 
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="text"></param>
        /// <param name="isBold"></param>
        /// <param name="fontSize"></param>
        /// <param name="align"></param>
        private void AddImage(XWPFDocument doc, string imgPath, string align = "left")
        {
            if (File.Exists(imgPath))
            {
                XWPFParagraph para = doc.CreateParagraph();
                XWPFRun run = para.CreateRun();

                switch (align.ToLower())
                {
                    case "center":
                        {
                            para.Alignment = ParagraphAlignment.CENTER;
                            break;
                        }
                    case "right":
                        {
                            para.Alignment = ParagraphAlignment.RIGHT;
                            break;
                        }
                    case "left":
                    default:
                        {
                            para.Alignment = ParagraphAlignment.LEFT;
                            break;
                        }
                }

                using (FileStream fsImg = new FileStream(imgPath, FileMode.Open, FileAccess.Read))
                {
                    run.AddPicture(fsImg, (int)PictureType.PNG, "1", Units.ToEMU(300), Units.ToEMU(200));
                }

                NPOI.OpenXmlFormats.Dml.WordProcessing.CT_Inline inline = run.GetCTR().GetDrawingList()[0].inline[0];
                inline.docPr.id = (uint)(new Random()).Next(1000, 1000000);
                run.AddCarriageReturn();
            }
            else
            {
                AddParagraph(doc, "[图片未找到：chart.png]", false, 12, "left");
            }
        }


        /// <summary>
        /// 删除临时图片文件
        /// </summary>
        public void DeleteAllImg()
        {
            System.IO.DirectoryInfo directory = new System.IO.DirectoryInfo(@"C:\ChartDataImg");
            foreach (System.IO.FileInfo file in directory.GetFiles())
            {
                file.Delete();
            }
        }

        private void btnX_Setting_Click(object sender, EventArgs e)
        {
            FrmSetting frmSetting = new FrmSetting();
            frmSetting.ShowDialog();
        }

        private void btnX_PosYAxisMaxDown_Click(object sender, EventArgs e)
        {
            if (setting.LoadYAxisStep >= (chart5.ChartAreas[0].AxisY.Maximum - chart5.ChartAreas[0].AxisY.Minimum))
            {
                MessageBox.Show("移动量程超过最大最小值!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                chart5.ChartAreas[0].AxisY2.Maximum -= setting.LoadYAxisStep;
            }
        }
    }
}
