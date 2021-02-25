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
        private string gamePath;
        public string GamePath
        {
            set
            {
                gamePath = value;
            }
            get
            {
                return gamePath;
            }
        }

        private void CustomOFD_Load(object sender, EventArgs e)
        {
            this.sizeLabel.Text = "";
            this.ballsLabel.Text = "";
            this.wallsLabel.Text = "";
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
                catch (NullReferenceException)
                {
                    ofdFilePath.Text = currentPath;
                    populateListView(currentPath);
                    MessageBox.Show("Invalid Path");
                }
                catch (UnauthorizedAccessException)
                {
                    ofdFilePath.Text = currentPath;
                    populateListView(currentPath);
                    MessageBox.Show("Unauthorized access");
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
                mrbLabels();
            }
            else
            {
                if (ofdPreview.Image != null)
                {
                    removePreview();
                }
            }
            
        }

        private void ofdDouble_Click(object sender, MouseEventArgs e)
        {
            string selectedName = this.ofdListView.SelectedItems[0].Text;
            string fullPath = currentPath + "\\" + selectedName;
            string selectedType = this.ofdListView.SelectedItems[0].SubItems[2].Text;
            if (selectedType == "File Folder")
            {
                try
                {
                    goToFolder(fullPath);
                }
                catch (UnauthorizedAccessException)
                {
                    ofdFilePath.Text = currentPath;
                    populateListView(currentPath);
                    MessageBox.Show("Unauthorized access");
                }
            }
            else if (selectedType == ".mrb")
            {
                mrbExtract(this.ofdFilePath.Text);
                setGamePath();
                this.Close();
            }
            ofdFilePath.Text = fullPath;
        }

        private void ofdLoad_Click(object sender, EventArgs e)
        {
            if (this.ofdListView.SelectedItems.Count > 0)
            {
                string selectedName = this.ofdListView.SelectedItems[0].Text;
                string fullPath = currentPath + "\\" + selectedName;
                string selectedType = this.ofdListView.SelectedItems[0].SubItems[2].Text;
                if (selectedType == "File Folder")
                {
                    try
                    {
                        goToFolder(fullPath);
                    }
                    catch (UnauthorizedAccessException)
                    {
                        ofdFilePath.Text = currentPath;
                        populateListView(currentPath);
                        MessageBox.Show("Unauthorized access");
                    }
                }
                else if (selectedType == ".mrb")
                {
                    this.DialogResult = DialogResult.OK;
                    mrbExtract(this.ofdFilePath.Text);
                    setGamePath();
                    this.Close();
                }
                ofdFilePath.Text = fullPath;
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
            tempLocation = System.IO.Path.Combine(System.IO.Path.GetTempPath(), System.IO.Path.GetRandomFileName());
            System.IO.Directory.CreateDirectory(tempLocation);
            System.IO.Compression.ZipArchive mrb = System.IO.Compression.ZipFile.OpenRead(mrbPath);
            foreach(System.IO.Compression.ZipArchiveEntry entry in mrb.Entries)
            {
                entry.ExtractToFile(System.IO.Path.Combine(tempLocation, entry.FullName), true);
            }
        }

        private void mrbLabels()
        {
            string txtPath = System.IO.Path.Combine(tempLocation, "puzzle.txt");
            string[] lines = System.IO.File.ReadAllLines(txtPath);
            string[] counts = lines[0].Split(' ');
            int size = Convert.ToInt32(counts[0]);
            int balls = Convert.ToInt32(counts[1]);
            int walls = Convert.ToInt32(counts[2]);
            this.sizeLabel.Text = "Board Size: " + size + " x " + size;
            this.ballsLabel.Text = "Balls: " + balls;
            this.wallsLabel.Text = "Walls: " + walls;
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

        private void removePreview()
        {
            ofdPreview.Image = null;
            ofdPreview.Invalidate();
            this.sizeLabel.Text = "";
            this.ballsLabel.Text = "";
            this.wallsLabel.Text = "";
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

        private void setGamePath()
        {
            gamePath = tempLocation;
        }
    }
}
