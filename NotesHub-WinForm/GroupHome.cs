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
                var Documents = post.Documents;
                ListViewItem item;
                if (Documents != null)
                {
                    item = new ListViewItem(new[] { post.id.ToString(), post.title, post.description, post.Documents.Length.ToString() });
                }
                else
                {
                    item = new ListViewItem(new[] { post.id.ToString(), post.title, post.description, "0" });


                }
                listView1.Items.Add(item);
            }
        }
        private void ListViewGroups_ItemActivate(object sender, EventArgs e)
        {
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            CreatePost createPost = new CreatePost(groupId, userId);
            createPost.ShowDialog();
        }

        private void listView1_ItemActivate(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                string postId = listView1.SelectedItems[0].SubItems[0].Text;
                PostHome groupForm = new PostHome(userId: userId, postId: Int32.Parse(postId), groupId: groupId);
                this.Hide();
                groupForm.ShowDialog();
            }
        }
    }
}
