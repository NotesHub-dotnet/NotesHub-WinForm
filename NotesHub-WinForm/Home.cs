using NotesHub_WinForm.NotesHubService;
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
    public partial class Home : Form
    {
        int userId { get; set; }
        List<GroupModel> groups { get; set; }
        public Home(int userId)
        {
            this.userId = userId;
            InitializeComponent();
            NotesHubServiceClient service = new NotesHubServiceClient();
            this.groups = service.GetAllGroup().ToList();

            
            listView1.View = View.Details;

            listView1.Columns.Add("Group ID", 80);
            listView1.Columns.Add("Group Name", 120);

            var groups = new Object();

            foreach (var group in this.groups)
            {
                ListViewItem item = new ListViewItem(new[] { group.id.ToString(), group.name });
                listView1.Items.Add(item);
            }
            
            listView1.ItemActivate += ListViewGroups_ItemActivate;
        }
        private void ListViewGroups_ItemActivate(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                string groupId = listView1.SelectedItems[0].SubItems[0].Text;
                GroupHome groupForm = new GroupHome(userId: userId, groupId: Int32.Parse(groupId));
                this.Hide();
                groupForm.ShowDialog();
            }
        }



        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreateGrourp createGroup = new CreateGrourp(userId: userId);
            this.Hide();
            createGroup.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            login loginForm = new login();
            loginForm.ShowDialog();
        }
    }
}
