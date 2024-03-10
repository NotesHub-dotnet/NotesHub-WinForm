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
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace NotesHub_WinForm
{
    public partial class CreatePost : Form
    {
        int groupId { get; set; }
        int userId { get; set; }
        private List<Document> uploadedDocuments = new List<Document>();

        public CreatePost(int groupId, int userId)
        {
            InitializeComponent();
            this.groupId = groupId;
            this.userId = userId;


            
            dataGridView1.Columns.Add("document name", "document name");
        }

        private void btnUploadDocument_Click(object sender, EventArgs e)
        {
          
        }

        private void DisplayUploadedDocuments()
        {
            dataGridView1.Rows.Clear();

            foreach (var document in uploadedDocuments)
            {
                dataGridView1.Rows.Add(document.Name);
            }
        }

        private void btnCreatePost_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "All Files|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (string fileName in openFileDialog.FileNames)
                {
                    byte[] fileContent = File.ReadAllBytes(fileName);

                    Document document = new Document
                    {
                        Name = Path.GetFileName(fileName),
                        Content = fileContent
                    };
                    uploadedDocuments.Add(document);

                    DisplayUploadedDocuments();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            GroupHome groupHome = new GroupHome(groupId: groupId, userId:userId);
            groupHome.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string postContent = textBox1.Text;
            string postDescription = textBox2.Text;
            PostModel newPost = new PostModel
            {
                title = postContent,
                description = postDescription,
                Documents = uploadedDocuments.Select(document => new DocumentModel { name = document.Name, fileBytes = document.Content }).ToArray(),
                user_id = userId,
                group_id = groupId,
            };
            NotesHubServiceClient notesHubServiceClient = new NotesHubServiceClient();
            int response = notesHubServiceClient.CreatePost(newPost);

            this.Close();
        }
    }
    public class Document
    {
        public string Name { get; set; }
        public byte[] Content { get; set; }
    }

}
