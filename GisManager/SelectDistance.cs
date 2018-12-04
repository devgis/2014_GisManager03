using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GisManager
{
    public partial class SelectDistance : Form
    {
        public int Distance = -1;
        public SelectDistance()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Distance = Convert.ToInt32(tbDistance.Text);
                this.DialogResult = DialogResult.OK;
            }
            catch
            {
                MessageBox.Show("请输入正确的距离（整数）！");
                tbDistance.Focus();
            }
        }

        private void SelectDistance_Load(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}