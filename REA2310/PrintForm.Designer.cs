
namespace REA2310
{
    partial class PrintForm
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
            this.viewer1 = new GrapeCity.ActiveReports.Viewer.Win.Viewer();
            this.SuspendLayout();
            // 
            // viewer1
            // 
            this.viewer1.CurrentPage = 0;
            this.viewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewer1.Location = new System.Drawing.Point(0, 0);
            this.viewer1.Name = "viewer1";
            this.viewer1.PreviewPages = 0;
            // 
            // 
            // 
            // 
            // 
            // 
            this.viewer1.Sidebar.ParametersPanel.ContextMenu = null;
            this.viewer1.Sidebar.ParametersPanel.Text = "パラメータ";
            this.viewer1.Sidebar.ParametersPanel.Width = 200;
            // 
            // 
            // 
            this.viewer1.Sidebar.SearchPanel.ContextMenu = null;
            this.viewer1.Sidebar.SearchPanel.Text = "検索";
            this.viewer1.Sidebar.SearchPanel.Width = 200;
            // 
            // 
            // 
            this.viewer1.Sidebar.ThumbnailsPanel.ContextMenu = null;
            this.viewer1.Sidebar.ThumbnailsPanel.Text = "サムネイル";
            this.viewer1.Sidebar.ThumbnailsPanel.Width = 200;
            this.viewer1.Sidebar.ThumbnailsPanel.Zoom = 0.1D;
            // 
            // 
            // 
            this.viewer1.Sidebar.TocPanel.ContextMenu = null;
            this.viewer1.Sidebar.TocPanel.Expanded = true;
            this.viewer1.Sidebar.TocPanel.Text = "見出しマップラベル";
            this.viewer1.Sidebar.TocPanel.Width = 200;
            this.viewer1.Sidebar.Width = 200;
            this.viewer1.Size = new System.Drawing.Size(1264, 681);
            this.viewer1.TabIndex = 0;
            this.viewer1.Load += new System.EventHandler(this.viewer1_Load);
            // 
            // PrintForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.viewer1);
            this.Name = "PrintForm";
            this.Text = "PrintForm";
            this.ResumeLayout(false);

        }

        #endregion

        private GrapeCity.ActiveReports.Viewer.Win.Viewer viewer1;
    }
}