using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoPE10Net_CSharpDemo
{
    public partial class FrmDynCtrl : Form
    {
        public FrmDynCtrl()
        {
            InitializeComponent();

            //comboBoxEx1.Doub

            //comboBoxEx1.ControlStyles.OptimizedDoubleBuffer = true;
            //comboBoxEx1.ControlStyles.AllPaintingInWmPaint = true;

            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }


    }
}
