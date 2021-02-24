
namespace csci321_assignment02
{
    partial class CustomOFD
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomOFD));
            this.ofdCancel = new System.Windows.Forms.Button();
            this.ofdLoad = new System.Windows.Forms.Button();
            this.ofdFilePath = new System.Windows.Forms.TextBox();
            this.ofdPrevDir = new System.Windows.Forms.Button();
            this.ofdListView = new System.Windows.Forms.ListView();
            this.Filename = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DateModified = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Size = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.icons = new System.Windows.Forms.ImageList(this.components);
            this.ofdPreview = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ofdPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // ofdCancel
            // 
            this.ofdCancel.Location = new System.Drawing.Point(1188, 575);
            this.ofdCancel.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.ofdCancel.Name = "ofdCancel";
            this.ofdCancel.Size = new System.Drawing.Size(125, 32);
            this.ofdCancel.TabIndex = 0;
            this.ofdCancel.Text = "Cancel";
            this.ofdCancel.UseVisualStyleBackColor = true;
            this.ofdCancel.Click += new System.EventHandler(this.ofdCancel_Click);
            // 
            // ofdLoad
            // 
            this.ofdLoad.Location = new System.Drawing.Point(1053, 575);
            this.ofdLoad.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.ofdLoad.Name = "ofdLoad";
            this.ofdLoad.Size = new System.Drawing.Size(125, 32);
            this.ofdLoad.TabIndex = 1;
            this.ofdLoad.Text = "Load";
            this.ofdLoad.UseVisualStyleBackColor = true;
            this.ofdLoad.Click += new System.EventHandler(this.ofdLoad_Click);
            // 
            // ofdFilePath
            // 
            this.ofdFilePath.Font = new System.Drawing.Font("Liberation Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ofdFilePath.Location = new System.Drawing.Point(82, 575);
            this.ofdFilePath.Margin = new System.Windows.Forms.Padding(5);
            this.ofdFilePath.Name = "ofdFilePath";
            this.ofdFilePath.Size = new System.Drawing.Size(961, 26);
            this.ofdFilePath.TabIndex = 2;
            this.ofdFilePath.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ofdFilePath_KeyPress);
            // 
            // ofdPrevDir
            // 
            this.ofdPrevDir.Font = new System.Drawing.Font("Liberation Mono", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ofdPrevDir.Location = new System.Drawing.Point(13, 575);
            this.ofdPrevDir.Name = "ofdPrevDir";
            this.ofdPrevDir.Size = new System.Drawing.Size(61, 32);
            this.ofdPrevDir.TabIndex = 3;
            this.ofdPrevDir.Text = "▲";
            this.ofdPrevDir.UseVisualStyleBackColor = true;
            this.ofdPrevDir.Click += new System.EventHandler(this.ofdPrevDir_Click);
            // 
            // ofdListView
            // 
            this.ofdListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Filename,
            this.DateModified,
            this.Type,
            this.Size});
            this.ofdListView.HideSelection = false;
            this.ofdListView.Location = new System.Drawing.Point(13, 13);
            this.ofdListView.Name = "ofdListView";
            this.ofdListView.Size = new System.Drawing.Size(1030, 556);
            this.ofdListView.SmallImageList = this.icons;
            this.ofdListView.TabIndex = 4;
            this.ofdListView.UseCompatibleStateImageBehavior = false;
            this.ofdListView.View = System.Windows.Forms.View.Details;
            // 
            // Filename
            // 
            this.Filename.Text = "Name";
            this.Filename.Width = 320;
            // 
            // DateModified
            // 
            this.DateModified.Text = "Date Modified";
            this.DateModified.Width = 240;
            // 
            // Type
            // 
            this.Type.Text = "Type";
            this.Type.Width = 200;
            // 
            // Size
            // 
            this.Size.Text = "Size";
            this.Size.Width = 160;
            // 
            // icons
            // 
            this.icons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("icons.ImageStream")));
            this.icons.TransparentColor = System.Drawing.Color.Transparent;
            this.icons.Images.SetKeyName(0, "mrb_icon.png");
            this.icons.Images.SetKeyName(1, "folder_icon.png");
            this.icons.Images.SetKeyName(2, "txt_icon.png");
            this.icons.Images.SetKeyName(3, "image_icon.png");
            this.icons.Images.SetKeyName(4, "misc_icon.png");
            // 
            // ofdPreview
            // 
            this.ofdPreview.Location = new System.Drawing.Point(1073, 13);
            this.ofdPreview.Name = "ofdPreview";
            this.ofdPreview.Size = new System.Drawing.Size(240, 240);
            this.ofdPreview.TabIndex = 5;
            this.ofdPreview.TabStop = false;
            // 
            // CustomOFD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1333, 623);
            this.Controls.Add(this.ofdPreview);
            this.Controls.Add(this.ofdListView);
            this.Controls.Add(this.ofdPrevDir);
            this.Controls.Add(this.ofdFilePath);
            this.Controls.Add(this.ofdLoad);
            this.Controls.Add(this.ofdCancel);
            this.Font = new System.Drawing.Font("Liberation Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "CustomOFD";
            this.Text = "Load Game File";
            this.Load += new System.EventHandler(this.CustomOFD_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ofdPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ofdCancel;
        private System.Windows.Forms.Button ofdLoad;
        private System.Windows.Forms.TextBox ofdFilePath;
        private System.Windows.Forms.Button ofdPrevDir;
        private System.Windows.Forms.ListView ofdListView;
        private System.Windows.Forms.ColumnHeader Filename;
        private System.Windows.Forms.ColumnHeader DateModified;
        private System.Windows.Forms.ColumnHeader Type;
        private System.Windows.Forms.ColumnHeader Size;
        private System.Windows.Forms.ImageList icons;
        private System.Windows.Forms.PictureBox ofdPreview;
    }
}