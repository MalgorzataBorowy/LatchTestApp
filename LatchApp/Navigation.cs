using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LatchApp
{
    public partial class Navigation : Form
    {
        public Navigation()
        {
            InitializeComponent();
        }

        private void btn_AddData_Click(object sender, EventArgs e)
        {
            Form frm = new AddData();
            frm.ShowDialog();
        }

        private void btn_ViewData_Click(object sender, EventArgs e)
        {
            Form frm = new ViewData();
            frm.ShowDialog();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }
    }
}
