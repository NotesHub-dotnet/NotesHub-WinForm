using NotesHub_WinForm.NotesHubService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace NotesHub_WinForm
{
    public partial class PostHome : Form
    {
        int userId { get; set; }
        int groupId { get; set; }
        int postId { get; set; }

        PostModel post { get; set; }
        public PostHome(int postId, int groupId, int userId)
        {
            InitializeComponent();
            this.postId = postId;
            this.groupId = groupId;
            this.userId = userId;
            NotesHubServiceClient db = new NotesHubServiceClient();
            post = db.GetPostById(postId);
            DisplayPostDetails();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            GroupHome groupHome = new GroupHome(groupId, userId);
            groupHome.Show();
        }


        private void DisplayPostDetails()
        {
            Controls.Clear();

            Label labelPostTitle = new Label();
            labelPostTitle.Text = post.title;
            labelPostTitle.AutoSize = true;
            labelPostTitle.Font = new System.Drawing.Font("Arial", 16, System.Drawing.FontStyle.Bold);
            labelPostTitle.Location = new System.Drawing.Point(20, 20);

            Label labelPostDescription = new Label();
            labelPostDescription.Text = post.description;
            labelPostDescription.AutoSize = true;
            labelPostDescription.Location = new System.Drawing.Point(20, 60);

            FlowLayoutPanel flowLayoutPanelDocuments = new FlowLayoutPanel();
            flowLayoutPanelDocuments.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanelDocuments.AutoScroll = true;
            flowLayoutPanelDocuments.Location = new System.Drawing.Point(20, 100);

            foreach (var document in post.Documents)
            {
                Label labelDocumentName = new Label();
                labelDocumentName.Text = document.name;
                labelDocumentName.AutoSize = true;

                Button btnDownload = new Button();
                btnDownload.Text = "Download";
                btnDownload.Tag = document;
                btnDownload.Click += BtnDownload_Click;

                flowLayoutPanelDocuments.Controls.Add(labelDocumentName);
                flowLayoutPanelDocuments.Controls.Add(btnDownload);
            }

            Controls.Add(labelPostTitle);
            Controls.Add(labelPostDescription);
            Controls.Add(flowLayoutPanelDocuments);
        }

        private void BtnDownload_Click(object sender, EventArgs e)
        {
            Button btnDownload = (Button)sender;
            DocumentModel document = (DocumentModel)btnDownload.Tag;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = document.name; // Default file name
            saveFileDialog.Filter = "All Files|*.*";  // Set appropriate file filters if needed

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Save the document content to the selected file location
                File.WriteAllBytes(saveFileDialog.FileName, document.fileBytes);

                MessageBox.Show($"File '{document.name}' downloaded successfully.");
            }
        }
    }
}
