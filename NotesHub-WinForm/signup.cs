using NotesHub_WinForm.NotesHubService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void password_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void signup1_Click(object sender, EventArgs e)
        {
            string usernameValue = username.Text;
            string nameValue = textBox1.Text;
            string passwordValue = password.Text;
            string emailValue = textBox2.Text;

            if(usernameValue == "" && nameValue == "" &&  passwordValue == "" && emailValue == "")
            {
                label5.Text = "All the fields are required";
                label5.ForeColor = Color.Red;
                return;
            } 
            NotesHubServiceClient notesHubServiceClient = new NotesHubServiceClient();
            UserModel userModel = new UserModel();
            userModel.username = usernameValue;
            userModel.name = nameValue;
            userModel.password = passwordValue;
            userModel.email = emailValue;
            int id = notesHubServiceClient.Signup(userModel);

            if(id ==  0)
            {
                label5.Text = "Username already exists";
                label5.ForeColor = Color.Red;
                return;
            }
            label5.Text = "Signup successful please login to continue";
            label5.ForeColor = Color.Green;

        }
    }
}
