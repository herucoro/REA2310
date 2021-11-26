
namespace REA2300
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.dateMtb = new System.Windows.Forms.MaskedTextBox();
            this.dateLabel = new System.Windows.Forms.Label();
            this.endBtn = new System.Windows.Forms.Button();
            this.printBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dateMtb
            // 
            this.dateMtb.Font = new System.Drawing.Font("MS UI Gothic", 14F);
            this.dateMtb.Location = new System.Drawing.Point(304, 93);
            this.dateMtb.Mask = "##/##";
            this.dateMtb.Name = "dateMtb";
            this.dateMtb.Size = new System.Drawing.Size(100, 26);
            this.dateMtb.TabIndex = 0;
            this.dateMtb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.dateLabel.Location = new System.Drawing.Point(118, 97);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(98, 22);
            this.dateLabel.TabIndex = 1;
            this.dateLabel.Text = "開始年月";
            // 
            // endBtn
            // 
            this.endBtn.Font = new System.Drawing.Font("MS UI Gothic", 14F);
            this.endBtn.Location = new System.Drawing.Point(304, 179);
            this.endBtn.Name = "endBtn";
            this.endBtn.Size = new System.Drawing.Size(100, 43);
            this.endBtn.TabIndex = 5;
            this.endBtn.Text = "終了";
            this.endBtn.UseVisualStyleBackColor = true;
            this.endBtn.Click += new System.EventHandler(this.endBtn_Click);
            // 
            // printBtn
            // 
            this.printBtn.Font = new System.Drawing.Font("MS UI Gothic", 14F);
            this.printBtn.Location = new System.Drawing.Point(116, 179);
            this.printBtn.Name = "printBtn";
            this.printBtn.Size = new System.Drawing.Size(100, 43);
            this.printBtn.TabIndex = 3;
            this.printBtn.Text = "印刷";
            this.printBtn.UseVisualStyleBackColor = true;
            this.printBtn.Click += new System.EventHandler(this.printBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 322);
            this.Controls.Add(this.printBtn);
            this.Controls.Add(this.endBtn);
            this.Controls.Add(this.dateLabel);
            this.Controls.Add(this.dateMtb);
            this.Name = "MainForm";
            this.Text = "入金予定表(REA2300 Ver1.0)";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox dateMtb;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.Button endBtn;
        private System.Windows.Forms.Button printBtn;
    }
}

