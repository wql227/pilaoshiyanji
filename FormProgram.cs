using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoPENetConnect.Util;

namespace DoPENetConnect
{
    public partial class FormProgram : Form
    {
        public string programName {
            get;
            set;
        }

        public string step_No {
            get;
            set;
        }
        
        public string cmdParameter {
            get;
            set;
        }

        public string cmdString {
            get;
            set;
        }

        public string[] programParams = new string[18] ;
        



        public FormProgram()
        {
            InitializeComponent();

        }

        private void btnX_FrmProtectOption_OK_Click(object sender, EventArgs e)
        {
            FormInputBox tmpInput = new FormInputBox();
            tmpInput.Location = new Point(this.Location.X + this.Width / 2, this.Location.Y + 100);
            tmpInput.ShowDialog();
            //if(tmpInput.)
            Console.WriteLine(this.Name);
            if (tmpInput.inputedString != null) {
                programName = tmpInput.inputedString;
                comboBoxEx1.Items.Add(programName);
                comboBoxEx1.Text = programName;
            }

            while (dataGridViewX1.Rows.Count > 0) {
                dataGridViewX1.Rows.RemoveAt(dataGridViewX1.Rows.Count - 1);
            }
        }

        private void comboBoxEx3_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxEx3.Text)
            {
                case "等速位移":
                    panelEx_boxing.Visible = false;
                    panelEx_delay.Visible = false;
                    panelEx_Empty.Visible = false;
                    panelEx_dengsuweiyi.Visible = true;

                    labelX23.Text = "速率mm/min";
                    labelX24.Text = "mm";
                    comboBoxEx8.Text = "位移达到";
                    break;
                case "等速力":
                    panelEx_boxing.Visible = false;
                    panelEx_delay.Visible = false;
                    panelEx_Empty.Visible = false;
                    panelEx_dengsuweiyi.Visible = true;
                    labelX23.Text = "速率kN/s";
                    labelX24.Text = "kN";
                    comboBoxEx8.Text = "力达到";
                    break;
                case "位移保持":
                    panelEx_boxing.Visible = false;
                    panelEx_delay.Visible = false;
                    panelEx_Empty.Visible = false;
                    panelEx_dengsuweiyi.Visible = true;
                    labelX23.Text = "目标mm";
                    labelX24.Text = "时间s";
                    comboBoxEx8.Text = "保持时间";
                    break;
                case "力保持":
                    panelEx_boxing.Visible = false;
                    panelEx_delay.Visible = false;
                    panelEx_Empty.Visible = false;
                    panelEx_dengsuweiyi.Visible = true;
                    labelX23.Text = "目标kN";
                    labelX24.Text = "s";
                    comboBoxEx8.Text = "保持时间";
                    break;
                case "波形控制":
                    panelEx_boxing.Visible = true;
                    panelEx_delay.Visible = false;
                    panelEx_Empty.Visible = false;
                    panelEx_dengsuweiyi.Visible = false;
                    labelX5.Text = "中值mm";
                    labelX6.Text = "振幅mm";
                    labelX7.Text = "频率Hz";
                    labelX11.Text = "起始速度mm/min";
                    labelX12.Text = "目标值mm";
                    comboBoxEx4.SelectedIndex = 0;
                    break;
                case "延时":
                    panelEx_boxing.Visible = false;
                    panelEx_delay.Visible = true;
                    panelEx_Empty.Visible = false;
                    panelEx_dengsuweiyi.Visible = false;
                    break;
                case "高压启动":
                    panelEx_boxing.Visible = false;
                    panelEx_delay.Visible = true;
                    panelEx_Empty.Visible = false;
                    panelEx_dengsuweiyi.Visible = false;
                    break;
                case "切换到低压":
                    panelEx_boxing.Visible = false;
                    panelEx_delay.Visible = true;
                    panelEx_Empty.Visible = false;
                    panelEx_dengsuweiyi.Visible = false;
                    break;
                case "试验结束":
                    panelEx_boxing.Visible = false;
                    panelEx_delay.Visible = true;
                    panelEx_Empty.Visible = false;
                    panelEx_dengsuweiyi.Visible = false;
                    break;
                default:
                    panelEx_boxing.Visible = false;
                    panelEx_delay.Visible = false;
                    panelEx_Empty.Visible = true;
                    panelEx_dengsuweiyi.Visible = false;
                    break;


            }
        }

        private void FormProgram_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“programdb11DataSet.NewTable”中。您可以根据需要移动或删除它。
            RemoveDataGridView();
            comboBoxEx3.SelectedIndex = 0;
            comboBoxEx2.SelectedIndex = 0;
            comboBoxEx5.SelectedIndex = 1;

            //获取表格并填充至控件
            FillProgramList();
        }

        private void FillProgramList()
        {
            AccessHelper tmpHelper = new AccessHelper();
            tmpHelper.InitProgramDb();
            string[] tmpTbNames = tmpHelper.GetTableNames();
            if(tmpTbNames!=null)
                comboBoxEx1.Items.AddRange(tmpTbNames);
        }

        private void btnX_FrmProtectOption_Cencel_Click(object sender, EventArgs e)
        {

            if (comboBoxEx1.Text == "") {
                MessageBox.Show("请先点击新建程序按钮新建一个程序！");
                return;
            }
            if (!SaveProgram(comboBoxEx1.Text)) {
                MessageBox.Show("保存失败，请检查程序是否已经存在");
                return;
            };
            MainForm.mainform.RefreshDbNameList();
        }

        public bool SaveProgram(string programName)
        {
            AccessHelper tmpHelper = new AccessHelper();
            tmpHelper.InitProgramDb();
            if (tmpHelper.IsTableExists(programName)) {    //程序已经存在
                tmpHelper.DropTable(programName);
            };

            tmpHelper.CreateTable(programName, "步骤", "指令参数", "指令内容", "跳转到", "循环");

            if (dataGridViewX1.Rows.Count == 0) {
                MessageBox.Show("程序内容为空，请先输入程序内容再保存！");
                return false;
            }
            else
            {
                foreach (DataGridViewRow tmpRow in dataGridViewX1.Rows)
                {

                    tmpHelper.AddOneRecord(programName, tmpRow.Cells[0].Value.ToString(), tmpRow.Cells[1].Value.ToString(), tmpRow.Cells[2].Value.ToString(), tmpRow.Cells[3].Value.ToString(), tmpRow.Cells[4].Value.ToString());

                }
            }

            return true;
        }

        public string[] GetInsertStrings() {
            string[] tmpStrings = new string[5];
            tmpStrings[0] = comboBoxEx2.Text;
            tmpStrings[1] = comboBoxEx3.Text;

            string[] tmpParams1 = new string[18];
            switch (comboBoxEx3.Text)
            {
                case "等速位移":
                    tmpStrings[2] = string.Format("{3},速率:{0}mm/min,{1}:{2}mm", textBoxX15.Text, comboBoxEx8.Text, textBoxX16.Text, comboBoxEx3.Text);
                    break;
                case "等速力":
                    tmpStrings[2] = string.Format("{3},速率:{0}kN/s,{1}:{2}kN", textBoxX15.Text, comboBoxEx8.Text, textBoxX16.Text, comboBoxEx3.Text);
                    break;
                case "位移保持":
                    tmpStrings[2] = string.Format("{3},保持目标:{0}mm,{1}:{2}s", textBoxX15.Text, comboBoxEx8.Text, textBoxX16.Text, comboBoxEx3.Text);
                    break;
                case "力保持":
                    tmpStrings[2] = string.Format("{3},保持目标:{0}kN,{1}:{2}s", textBoxX15.Text, comboBoxEx8.Text, textBoxX16.Text, comboBoxEx3.Text);
                    break;
                case "波形控制":
                    tmpStrings[2] = string.Format("{3},波形:{0},中值{1}mm,振幅:{2}mm,频率:{4}Hz,试验次数:{5},趋近速度:{6}mm/min,目标值:{7}mm", comboBoxEx4.Text, textBoxX1.Text, textBoxX3.Text, comboBoxEx3.Text, textBoxX2.Text, textBoxX5.Text, textBoxX6.Text, textBoxX7.Text);
                    break;
                case "延时":
                    tmpStrings[2] = string.Format("{1},延时:{0}s", textBoxX12.Text, comboBoxEx3.Text);
                    break;
                case "高压启动":
                    break;
                case "切换到低压":
                    break;
                case "试验结束":
                    break;
                    //case "等速位移":
                    //    break;
            }
            tmpStrings[3] = comboBoxEx5.Text;   //存储跳转到第几步
            tmpStrings[4] = textBoxX4.Text;     //循环多少次
            return tmpStrings;
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            string[] tmpCmdParams = GetInsertStrings();
            AddOneSteps(tmpCmdParams);
        }

        public void RemoveDataGridView()
        {
            dataGridViewX1.AllowUserToAddRows = false;
            while (dataGridViewX1.RowCount > 0)
            {
                dataGridViewX1.Rows.RemoveAt(0);
            }
        }

        public void AddOneSteps(string[] cmdParams)
        {
            //replace&insert
            foreach (DataGridViewRow tmpRow in dataGridViewX1.Rows)
            {
                if (tmpRow.Cells[0].Value.ToString() == cmdParams[0]) {
                    int tmpIndex = tmpRow.Index;
                    dataGridViewX1.Rows.RemoveAt(tmpRow.Index);
                    dataGridViewX1.Rows.Insert(tmpIndex, cmdParams);
                    return;
                }
            }

            //add
            string[] tmpCmdParams = new string[5];
            tmpCmdParams[1] = "等速位移";
            tmpCmdParams[2] = "等速位移,速率:0mm/min,保持时间0s";
            tmpCmdParams[3] = "0";
            tmpCmdParams[4] = "0";
            
            if (dataGridViewX1.Rows.Count > 0)
            {
                for (int i = int.Parse(dataGridViewX1.Rows[dataGridViewX1.Rows.Count-1].Cells[0].Value.ToString()); i < int.Parse(cmdParams[0])-1; i++)
                {
                    tmpCmdParams[0] = (i+1).ToString();
                    dataGridViewX1.Rows.Add(tmpCmdParams);
                    //newRow.HeaderCell.Value = (dataGridViewX1.Rows.Count).ToString();
                }
            }
                dataGridViewX1.Rows.Add(cmdParams);

            dataGridViewX1.ClearSelection();
            dataGridViewX1.Rows[dataGridViewX1.Rows.Count - 1].Selected = true;
            //for (int i = 0; i < dataGridViewX1.Rows.Count; i++)
            //{
            //    Console.WriteLine("glm{0}", dataGridViewX1.Rows[i].Cells[2].Value.ToString());
            //}
        }
        public void InsertOneSteps(string[] cmdParams)
        {
            int  needChangeIndex = 0;
            int tmpIndex = 0;
            int tmpIndex1 = 0;
            string[] cmdParamsExt = new string[5];
            string[] cmdParamsCurrent = new string[5];
            foreach (DataGridViewRow tmpRow in dataGridViewX1.Rows)
            {
                if (tmpRow.Cells[0].Value.ToString() == cmdParams[0])   //如果包含这个
                {
                    tmpIndex = tmpRow.Index;
                    tmpIndex1 = tmpIndex;
                    for (int i = 0; i < cmdParamsExt.Length; i++)
                    {
                        cmdParamsExt[i] = dataGridViewX1.Rows[tmpIndex].Cells[i].Value.ToString();
                        tmpRow.Cells[i].Value = cmdParams[i];
                    }
                    //dataGridViewX1.Rows.RemoveAt(tmpIndex);
                    //dataGridViewX1.Rows.Insert(tmpIndex, cmdParams);
                    needChangeIndex = 1;
                }

                if (1 == needChangeIndex)
                {
                    needChangeIndex = 2;
                    dataGridViewX1.ClearSelection();
                    dataGridViewX1.Rows[tmpIndex1].Selected = true;
                    continue;

                }
                else if (needChangeIndex == 2)
                {
                    tmpIndex += 1;
                    for (int i = 0; i < cmdParamsCurrent.Length; i++)
                    {
                        cmdParamsCurrent[i] = tmpRow.Cells[i].Value.ToString();
                        tmpRow.Cells[i].Value = cmdParamsExt[i];
                    }
                    Array.Copy(cmdParamsCurrent, cmdParamsExt, cmdParamsExt.Length);
                    tmpRow.Cells[0].Value = (tmpIndex+1).ToString();
                }

            }
            cmdParamsExt[0] = (int.Parse(cmdParamsExt[0]) + 1).ToString();
            dataGridViewX1.Rows.Add(cmdParamsExt);
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            string[] tmpCmdParams = GetInsertStrings();
            if (dataGridViewX1.RowCount == 0) {    //空表
                AddOneSteps(tmpCmdParams);
            }
            else
                InsertOneSteps(tmpCmdParams);
        }

        private void dataGridViewX1_MouseClick(object sender, MouseEventArgs e)
        {
            //Console.WriteLine("hello aaabbb{0}",dataGridViewX1.SelectedRows[0].Index);
            if (dataGridViewX1.Rows.Count != 0)
            {
                comboBoxEx2.Text = (dataGridViewX1.SelectedRows[0].Index + 1).ToString();
            }
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            RemoveOneSteps();
        }

        public void RemoveOneSteps()
        {
            int needChangeIndex = 0;
            int tmpIndex = 0;
            int tmpIndex1 = 0;
            foreach (DataGridViewRow tmpRow in dataGridViewX1.Rows)
            {
                if (tmpRow.Cells[0].Value.ToString() == comboBoxEx2.Text)   //如果包含这个
                {
                    tmpIndex = tmpRow.Index;
                    tmpIndex1 = tmpIndex;
                    if (dataGridViewX1.Rows.Count == int.Parse(tmpRow.Cells[0].Value.ToString())&& dataGridViewX1.Rows.Count!=1)
                    {
                        comboBoxEx2.Text = (tmpIndex).ToString();
                    }
                    dataGridViewX1.Rows.RemoveAt(tmpIndex);
                    needChangeIndex = 1;
                }

                //if (1 == needChangeIndex)
                //{
                //    needChangeIndex = 2;
                //    dataGridViewX1.ClearSelection();
                //    dataGridViewX1.Rows[tmpIndex1].Selected = true;
                //    //tmpRow.Cells[0].Value = (tmpIndex-1).ToString();
                //    //    continue;
                //}
                //}
                //else if (needChangeIndex == 2)
                //{
                //    //tmpIndex += 1;
                //    tmpRow.Cells[0].Value = (int.Parse(tmpRow.Cells[0].Value.ToString())-1).ToString();
                //    Console.WriteLine("tmpRow:{0}", tmpRow.Index);
                //}

            }
            for (int i = 0; i < dataGridViewX1.Rows.Count; i++) {
                if (i == tmpIndex) {

                    dataGridViewX1.ClearSelection();
                    dataGridViewX1.Rows[tmpIndex1].Selected = true;
                }
                if (i>=tmpIndex) {
                    dataGridViewX1.Rows[i].Cells[0].Value = (i + 1).ToString();
                }
            }
            //for (int i = 0; i < dataGridViewX1.Rows.Count; i++)
            //{
                //Console.WriteLine("glmselected{0}", dataGridViewX1.SelectedRows[0].Index);
            //}
        }

        private void buttonX6_Click(object sender, EventArgs e)
        {
            //AccessHelper tmpAccessHelper = new AccessHelper();
            //tmpAccessHelper.InitProgramDb();
            //dataGridViewX1.DataSource = tmpAccessHelper.viewAccessInfo();

            AccessHelper tmpHelper = new AccessHelper();
            tmpHelper.InitProgramDb();

            List<string[]> tmpDtas = tmpHelper.GetDtas("12121");

            if (tmpDtas.Count != 0)
            {
                while (dataGridViewX1.Rows.Count != 0)
                {   //清空当前gridview
                    dataGridViewX1.Rows.RemoveAt(dataGridViewX1.Rows.Count - 1);
                }

                for(int i=0;i< tmpDtas.Count;i++)
                {
                    dataGridViewX1.Rows.Add(tmpDtas[i]);
                }
            }
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            AccessHelper tmpHelper = new AccessHelper();
            tmpHelper.InitProgramDb();

            if (comboBoxEx1.Text != "")
            {
                if (tmpHelper.IsTableExists(comboBoxEx1.Text))
                {    //程序已经存在
                    string program2Del = comboBoxEx1.Text;
                    tmpHelper.DropTable(comboBoxEx1.Text);
                    int index = comboBoxEx1.Items.IndexOf(comboBoxEx1.Text);
                    comboBoxEx1.Items.RemoveAt(index);
                    comboBoxEx1.Text = "";
                    dataGridViewX1.Rows.Clear();

                    MainForm.mainform.RefreshDbNameList(); //更新主界面程序名称列表控件内容
                    MainForm.mainform.ClearProgramDataGridView(program2Del);//清除当前程序显示
                };
            }
        }

        private void buttonX5_Click(object sender, EventArgs e)
        {
            //DialogResult res =  MessageBox.Show("确定另存为")
            FormInputBox tmpInput = new FormInputBox();
            tmpInput.SetTitle("程序另存为");
            tmpInput.Location = new Point(this.Location.X + this.Width / 2, this.Location.Y + 100);
            tmpInput.ShowDialog();
            //if(tmpInput.)
            Console.WriteLine(this.Name);
            if (tmpInput.inputedString != null)
            {
                programName = tmpInput.inputedString;
                if (comboBoxEx1.Text == programName) {
                    MessageBox.Show("名称与现有程序同名，请重试");
                    return;
                }
                comboBoxEx1.Items.Add(programName);
                comboBoxEx1.Text = programName;

                if (!SaveProgram(comboBoxEx1.Text))
                {
                    MessageBox.Show("保存失败，请检查程序是否已经存在");
                    return;
                };

                MainForm.mainform.RefreshDbNameList(); //更新主界面程序名称列表控件内容
            }
        }

        private void comboBoxEx1_SelectedIndexChanged(object sender, EventArgs e)
        {
            AccessHelper tmpHelper = new AccessHelper();
            tmpHelper.InitProgramDb();

            List<string[]> tmpDtas = tmpHelper.GetDtas(comboBoxEx1.Text);

            if (tmpDtas.Count != 0)
            {
                while (dataGridViewX1.Rows.Count != 0)
                {   //清空当前gridview
                    dataGridViewX1.Rows.RemoveAt(dataGridViewX1.Rows.Count - 1);
                }

                for(int i=0;i< tmpDtas.Count;i++){
                    dataGridViewX1.Rows.Add(tmpDtas[i]);
                }
            }

            
        }

        private void FormProgram_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (comboBoxEx1.Text != "") {
                AccessHelper tmpHelper = new AccessHelper();
                tmpHelper.InitProgramDb();

                List<string[]> tmpDtas = tmpHelper.GetDtas(comboBoxEx1.Text);

                if (tmpDtas.Count != 0)
                {
                    MainForm.mainform.SetProgramDtas(comboBoxEx1.Text, tmpDtas);
                }
            }
        }
    }
}
