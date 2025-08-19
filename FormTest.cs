using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoPENetConnect
{
    public partial class FormTest : Form
    {
        public string sampleCode {
            set;
            get;
        }
        public string sampleNo
        {
            set;
            get;
        }
        public string sampleShape
        {
            set;
            get;
        }
        public string sampleOperator
        {
            set;
            get;
        }
        public string sampleChecker
        {
            set;
            get;
        }
        public string sampleDependation
        {
            set;
            get;
        }
        public string sampleNotes
        {
            set;
            get;
        }
        public string sampleLoad
        {
            set;
            get;
        }

        public FormTest()
        {
            InitializeComponent();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {

        }

        private void FormTest_Load(object sender, EventArgs e)
        {
            this.Activate();
        }

        private void FormTest_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Visible = false;
            }
        }
    }
}
