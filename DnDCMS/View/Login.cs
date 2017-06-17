using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DnDCMS.View;

namespace DnDCMS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Player_Click(object sender, EventArgs e)
        {
            Player newForm = new Player();
            this.Hide();
            if (newForm.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new Player());
            }
            else
            {
                Application.Exit();
            }
        }

        private void btn_DM_Click(object sender, EventArgs e)
        {
            DM newForm = new DM();
            this.Hide();
            if (newForm.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new DM());
            }
            else
            {
                Application.Exit();
            }
        }
    }
}
