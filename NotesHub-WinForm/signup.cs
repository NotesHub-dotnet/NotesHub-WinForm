using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotesHub_WinForm
{
    public partial class signup : Form
    {
        public signup()
        {
            InitializeComponent();
        }

        private void login_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            login form1 = new login();
            this.Hide();
            form1.ShowDialog();
        }
    }
}
