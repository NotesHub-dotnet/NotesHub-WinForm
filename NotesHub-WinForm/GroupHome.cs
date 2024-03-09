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
    public partial class GroupHome : Form
    {
        int groupId { get; set; }
        int userId { get; set; }

        List<PostModel> posts { get; set; }
        public GroupHome(int groupId, int userId)
        {
            InitializeComponent();
            this.groupId = groupId;
            this.userId = userId;

            NotesHubServiceClient service = new NotesHubServiceClient();
            this.posts = service.GetAllPostByGroupId(groupId).ToList();

            listView1.View = View.Details;

            listView1.Columns.Add("Post ID", 80);
            listView1.Columns.Add("Post Title", 120);
            listView1.Columns.Add("Post Description", 120);
            listView1.Columns.Add("Post Document Count", 120);

            var groups = new Object();

            foreach (var post in this.posts)
            {
                ListViewItem item = new ListViewItem(new[] { post.id.ToString(), post.title, post.description, post.Documents.Length.ToString() });
                listView1.Items.Add(item);
            }
        }
        private void ListViewGroups_ItemActivate(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                string postId = listView1.SelectedItems[0].SubItems[0].Text;
                //GroupHome groupForm = new GroupHome(userId: userId, postId: Int32.Parse(postId));
                //this.Hide();
                //groupForm.ShowDialog();
            }
        }

        private void GroupHome_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home home = new Home(userId: userId);
            home.ShowDialog();
        }
    }
}
