using NotesHub_WinForm.NotesHubService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotesHub_WinForm
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            signup form2 = new signup();
            this.Hide();
            form2.ShowDialog();
        }

        private void submit_Click(object sender, EventArgs e)
        {
            NotesHubServiceClient notesHubService = new NotesHubServiceClient();
            UserModel userModel = new UserModel();
            userModel.username = username.Text;
            userModel.password = password.Text;
            int response = notesHubService.Login(userModel);
            if(response != 0)
            {
                Home home = new Home(userId: response);
                this.Hide();
                home.ShowDialog();
            }
            else
            {
                label3.Text = "Incorrect username or password, please try again";

            }
        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
