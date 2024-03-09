using NotesHub_WinForm.NotesHubService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotesHub_WinForm
{
    public partial class CreateGrourp : Form
    {
        int userId { get; set; }
        public CreateGrourp(int userId)
        {
            this.userId = userId;
            InitializeComponent();
        }

        private void CreateGrourp_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string groupName = label1.Text;
            string groupDescription = label2.Text;
            if(groupName == "" && groupDescription == "")
            {
                label4.Text = "Please fill all the fields";
                label4.ForeColor = Color.Red;
                return;
            }
            GroupModel groupModel = new GroupModel();
            groupModel.name = groupName;
            groupModel.description = groupDescription;
            NotesHubServiceClient notesHub = new NotesHubServiceClient();
            int response = notesHub.CreateGroup(groupModel);
            GroupHome groupForm = new GroupHome(groupId: response, userId: userId);
            this.Close();
            groupForm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Home home = new Home(userId: userId);
            home.ShowDialog();
        }
    }
}
