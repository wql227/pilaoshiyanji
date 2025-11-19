using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Doli.DoPE10;

namespace DoPENetConnect
{
    public partial class FormProgControl : Form
    {
        /// <summary>
        /// element 0:cmd name
        /// </summary>
        public List<string[]> cmdDta=null; 
        public int currentCmdIndex = 0;
        public FormProgControl()
        {
            InitializeComponent();
        }
        public void SetCmdParmas(List<string[]> dta)
        {
            cmdDta = dta;
            currentCmdIndex = 0;
        }

        public void StartRunProgram()
        {
            string[] cmdParams = cmdDta[currentCmdIndex][2].Split(',');
            string[] cmd = new string[20];
            switch (cmdDta[currentCmdIndex][1]) {
                case "等速位移":
                   cmd[0] = cmdParams[1].Split(':').ElementAt(1).Substring(0, cmdParams[1].Split(':').ElementAt(1).IndexOf("mm"));
                   cmd[1] = cmdParams[2].Split(':').ElementAt(1).Substring(0, cmdParams[2].Split(':').ElementAt(1).IndexOf("mm"));
                    //pos 指令
                   MainForm.mainform.MovePos(DoPE.CTRL.POS, double.Parse(cmd[0])/60, double.Parse(cmd[1]));
                    break;
                case "等速力":
                    cmd[0] = cmdParams[1].Split(':').ElementAt(1).Substring(0, cmdParams[1].Split(':').ElementAt(1).IndexOf("kN"));
                    cmd[1] = cmdParams[2].Split(':').ElementAt(1).Substring(0, cmdParams[2].Split(':').ElementAt(1).IndexOf("kN"));
                    //pos 指令
                    MainForm.mainform.MovePos(DoPE.CTRL.LOAD, double.Parse(cmd[0])*1000, double.Parse(cmd[1])*1000);
                    break;
                case "位移保持":
                    break;
                case "力保持":
                    break;
                case "波形控制":
                    break;
                case "延时":
                    break;
                case "高压启动":
                    break;
                case "切换到低压":
                    break;
                case "试验结束":
                    break;
            }
        }
    }
}
