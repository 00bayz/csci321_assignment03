using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Compression;

namespace csci321_assignment02
{
    public partial class CustomOFD : Form
    {
        public CustomOFD()
        {
            InitializeComponent();
        }

        private string currentPath = string.Empty;
        private string tempLocation = string.Empty;

        private void CustomOFD_Load(object sender, EventArgs e)
        {
            currentPath = Environment.CurrentDirectory;
            this.ofdFilePath.Text = currentPath;
            populateListView(currentPath);
        }

        private void ofdFilePath_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                try
                {
                    populateListView(ofdFilePath.Text);
                    currentPath = ofdFilePath.Text;
                }
                catch
                {
                    ofdFilePath.Text = currentPath;
                    populateListView(currentPath);
                    MessageBox.Show("Invalid Path");
                }
            }
        }

        private void ofdPrevDir_Click(object sender, EventArgs e)
        {
            if (System.IO.Directory.GetParent(currentPath) == null)
            {
                MessageBox.Show("Invalid Path");
            }
            else
            {
                ofdPreview.Image = null;
                string parentDir = System.IO.Directory.GetParent(currentPath).ToString();
                goToFolder(parentDir);
            }
        }

        private void ofdSingle_Click(object sender, EventArgs e)
        {
            string selectedName = this.ofdListView.SelectedItems[0].Text;
            string fullPath = currentPath + "\\" + selectedName;
            string selectedType = this.ofdListView.SelectedItems[0].SubItems[2].Text;
            ofdFilePath.Text = fullPath;
            if (selectedType == ".mrb")
            {
                mrbExtract(fullPath);
                mrbPreview();
            }
            else
            {
                if (ofdPreview.Image != null)
                {
                    ofdPreview.Image = null;
                    ofdPreview.Invalidate();
                }
            }
        }

        private void ofdDouble_Click(object sender, MouseEventArgs e)
        {
            string selectedName = this.ofdListView.SelectedItems[0].Text;
            string fullPath = currentPath + "\\" + selectedName;
            string selectedType = this.ofdListView.SelectedItems[0].SubItems[2].Text;
            ofdFilePath.Text = fullPath;
            if (selectedType == "File Folder")
            {
                goToFolder(fullPath);
                
            }
            else if (selectedType == ".mrb")
            {

            }
            
        }

        private void ofdLoad_Click(object sender, EventArgs e)
        {
            string selectedName = this.ofdListView.SelectedItems[0].Text;
            string fullPath = currentPath + "\\" + selectedName;
            string selectedType = this.ofdListView.SelectedItems[0].SubItems[2].Text;
            ofdFilePath.Text = fullPath;
            if (selectedType == "File Folder")
            {
                goToFolder(fullPath);
            }
            else if (selectedType == ".mrb")
            {
                this.DialogResult = DialogResult.OK;
                mrbExtract(this.ofdFilePath.Text);
                this.Close();
            }
        }

        private void ofdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mrbExtract(string mrbPath)
        {
            if (tempLocation != "")
            {
                removeTempDirectory();
            }
            // temp test variable
            string mrbTest = @"C:\Users\bayz\source\school\csci321\csci321_assignment03\csci321_assignment02\bin\Debug\base.mrb";
            tempLocation = System.IO.Path.Combine(System.IO.Path.GetTempPath(), System.IO.Path.GetRandomFileName());
            System.IO.Directory.CreateDirectory(tempLocation);
            System.IO.Compression.ZipArchive mrb = System.IO.Compression.ZipFile.OpenRead(mrbTest);
            foreach(System.IO.Compression.ZipArchiveEntry entry in mrb.Entries)
            {
                entry.ExtractToFile(System.IO.Path.Combine(tempLocation, entry.FullName), true);
            }
        }

        private void mrbPreview()
        {
            using (Image tempImage = Image.FromFile(System.IO.Path.Combine(tempLocation, "puzzle.jpg")))
            {
                Bitmap bm = new Bitmap(ofdPreview.Width, ofdPreview.Height);
                Rectangle r = new Rectangle(0, 0, ofdPreview.Width, ofdPreview.Height);
                Graphics g = Graphics.FromImage(bm);
                g.DrawImage(tempImage, r, 0, 0, tempImage.Width, tempImage.Height, GraphicsUnit.Pixel);
                ofdPreview.Image = bm;
            }
        }

        private void populateListView(string dir)
        {
            ofdListView.Items.Clear();
            string[] files = System.IO.Directory.GetFiles(dir);
            string[] dirs = System.IO.Directory.GetDirectories(dir);
            for (int i = 0; i < dirs.Length; i++)
            {
                System.IO.DirectoryInfo info = new System.IO.DirectoryInfo(dirs[i]);
                string dirname = info.Name;
                string dateMod = info.LastWriteTime.ToString();
                string fileType = "File Folder";

                ListViewItem item = new ListViewItem();
                item.Text = dirname;
                item.SubItems.Add(dateMod);
                item.SubItems.Add(fileType);
                item.ImageIndex = 1;
                ofdListView.Items.Add(item);
            }
            for (int i = 0; i < files.Length; i++)
            {
                System.IO.FileInfo info = new System.IO.FileInfo(files[i]);
                string filename = info.Name;
                string filesize = convertFileSize((int)info.Length);
                string dateMod = info.LastWriteTime.ToString();
                string fileType = System.IO.Path.GetExtension(files[i]);
                int iconIndex = -1;

                ListViewItem item = new ListViewItem();
                item.Text = filename;
                item.SubItems.Add(dateMod);
                item.SubItems.Add(fileType);
                item.SubItems.Add(filesize);
                Console.WriteLine(fileType);
                if (fileType == ".mrb")
                {
                    iconIndex = 0;
                }
                else if (fileType == ".txt")
                {
                    iconIndex = 2;
                }
                else if (fileType == ".jpg")
                {
                    iconIndex = 3;
                }
                else
                {
                    iconIndex = 4;
                }
                item.ImageIndex = iconIndex;
                ofdListView.Items.Add(item);
            }
        }

        private void goToFolder(string dir)
        {
            currentPath = dir;
            ofdFilePath.Text = dir;
            populateListView(dir);
        }

        private void removeTempDirectory()
        {
            System.IO.DirectoryInfo dirInfo = new System.IO.DirectoryInfo(tempLocation);
            System.IO.FileInfo[] fileList = dirInfo.GetFiles();
            foreach (System.IO.FileInfo file in fileList)
            {
                System.IO.File.Delete(file.FullName);
            }
            System.IO.Directory.Delete(tempLocation);
        }

        private string convertFileSize(int bytes)
        {
            string res = bytes.ToString() + " B";
            if (bytes > 1000)
            {
                res = (bytes/1000).ToString() + " KB";
            }
            else if (bytes > 1000000)
            {
                res = (bytes / 1000000).ToString() + " MB";
            }
            return res;
        }
    }
}
