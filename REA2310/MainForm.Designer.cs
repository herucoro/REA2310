
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.dateMtb = new System.Windows.Forms.MaskedTextBox();
            this.dateLabel = new System.Windows.Forms.Label();
            this.endBtn = new System.Windows.Forms.Button();
            this.printBtn = new System.Windows.Forms.Button();
            this.approvalRb = new System.Windows.Forms.RadioButton();
            this.unapprovalRb = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.depositCbx0 = new System.Windows.Forms.CheckBox();
            this.depositCbx1 = new System.Windows.Forms.CheckBox();
            this.depositCbx2 = new System.Windows.Forms.CheckBox();
            this.depositCbx3 = new System.Windows.Forms.CheckBox();
            this.bankCbx3 = new System.Windows.Forms.CheckBox();
            this.bankCbx2 = new System.Windows.Forms.CheckBox();
            this.bankCbx1 = new System.Windows.Forms.CheckBox();
            this.bankCbx0 = new System.Windows.Forms.CheckBox();
            this.approvalPanel = new System.Windows.Forms.Panel();
            this.selectDepostiPanel = new System.Windows.Forms.Panel();
            this.selectBankPanel = new System.Windows.Forms.Panel();
            this.allDepositCbx = new System.Windows.Forms.CheckBox();
            this.allBankCbx = new System.Windows.Forms.CheckBox();
            this.approvalPanel.SuspendLayout();
            this.selectDepostiPanel.SuspendLayout();
            this.selectBankPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // dateMtb
            // 
            this.dateMtb.Font = new System.Drawing.Font("MS UI Gothic", 14F);
            this.dateMtb.Location = new System.Drawing.Point(217, 45);
            this.dateMtb.Mask = "##/##";
            this.dateMtb.Name = "dateMtb";
            this.dateMtb.Size = new System.Drawing.Size(100, 26);
            this.dateMtb.TabIndex = 1;
            this.dateMtb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dateMtb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dateMtb_KeyDown);
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.dateLabel.Location = new System.Drawing.Point(82, 49);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(98, 22);
            this.dateLabel.TabIndex = 1;
            this.dateLabel.Text = "開始年月";
            // 
            // endBtn
            // 
            this.endBtn.Font = new System.Drawing.Font("MS UI Gothic", 14F);
            this.endBtn.Location = new System.Drawing.Point(364, 378);
            this.endBtn.Name = "endBtn";
            this.endBtn.Size = new System.Drawing.Size(100, 43);
            this.endBtn.TabIndex = 99;
            this.endBtn.Text = "終了";
            this.endBtn.UseVisualStyleBackColor = true;
            this.endBtn.Click += new System.EventHandler(this.endBtn_Click);
            // 
            // printBtn
            // 
            this.printBtn.Font = new System.Drawing.Font("MS UI Gothic", 14F);
            this.printBtn.Location = new System.Drawing.Point(144, 378);
            this.printBtn.Name = "printBtn";
            this.printBtn.Size = new System.Drawing.Size(100, 43);
            this.printBtn.TabIndex = 16;
            this.printBtn.Text = "印刷";
            this.printBtn.UseVisualStyleBackColor = true;
            this.printBtn.Click += new System.EventHandler(this.printBtn_Click);
            // 
            // approvalRb
            // 
            this.approvalRb.AutoSize = true;
            this.approvalRb.Checked = true;
            this.approvalRb.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.approvalRb.Location = new System.Drawing.Point(10, 12);
            this.approvalRb.Name = "approvalRb";
            this.approvalRb.Size = new System.Drawing.Size(65, 23);
            this.approvalRb.TabIndex = 2;
            this.approvalRb.TabStop = true;
            this.approvalRb.Text = "決裁";
            this.approvalRb.UseVisualStyleBackColor = true;
            // 
            // unapprovalRb
            // 
            this.unapprovalRb.AutoSize = true;
            this.unapprovalRb.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.unapprovalRb.Location = new System.Drawing.Point(92, 12);
            this.unapprovalRb.Name = "unapprovalRb";
            this.unapprovalRb.Size = new System.Drawing.Size(84, 23);
            this.unapprovalRb.TabIndex = 3;
            this.unapprovalRb.Text = "未決裁";
            this.unapprovalRb.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.label1.Location = new System.Drawing.Point(82, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 22);
            this.label1.TabIndex = 8;
            this.label1.Text = "決裁状態";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.label2.Location = new System.Drawing.Point(82, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 22);
            this.label2.TabIndex = 9;
            this.label2.Text = "入金種別";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.label3.Location = new System.Drawing.Point(126, 245);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 22);
            this.label3.TabIndex = 10;
            this.label3.Text = "銀行";
            // 
            // depositCbx0
            // 
            this.depositCbx0.AutoSize = true;
            this.depositCbx0.Checked = true;
            this.depositCbx0.CheckState = System.Windows.Forms.CheckState.Checked;
            this.depositCbx0.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.depositCbx0.Location = new System.Drawing.Point(10, 7);
            this.depositCbx0.Name = "depositCbx0";
            this.depositCbx0.Size = new System.Drawing.Size(59, 20);
            this.depositCbx0.TabIndex = 6;
            this.depositCbx0.Text = "手形";
            this.depositCbx0.UseVisualStyleBackColor = true;
            // 
            // depositCbx1
            // 
            this.depositCbx1.AutoSize = true;
            this.depositCbx1.Checked = true;
            this.depositCbx1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.depositCbx1.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.depositCbx1.Location = new System.Drawing.Point(75, 7);
            this.depositCbx1.Name = "depositCbx1";
            this.depositCbx1.Size = new System.Drawing.Size(59, 20);
            this.depositCbx1.TabIndex = 7;
            this.depositCbx1.Text = "電債";
            this.depositCbx1.UseVisualStyleBackColor = true;
            // 
            // depositCbx2
            // 
            this.depositCbx2.AutoSize = true;
            this.depositCbx2.Checked = true;
            this.depositCbx2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.depositCbx2.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.depositCbx2.Location = new System.Drawing.Point(140, 7);
            this.depositCbx2.Name = "depositCbx2";
            this.depositCbx2.Size = new System.Drawing.Size(91, 20);
            this.depositCbx2.TabIndex = 8;
            this.depositCbx2.Text = "期日指定";
            this.depositCbx2.UseVisualStyleBackColor = true;
            // 
            // depositCbx3
            // 
            this.depositCbx3.AutoSize = true;
            this.depositCbx3.Checked = true;
            this.depositCbx3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.depositCbx3.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.depositCbx3.Location = new System.Drawing.Point(237, 7);
            this.depositCbx3.Name = "depositCbx3";
            this.depositCbx3.Size = new System.Drawing.Size(102, 20);
            this.depositCbx3.TabIndex = 9;
            this.depositCbx3.Text = "ファクタリング";
            this.depositCbx3.UseVisualStyleBackColor = true;
            // 
            // bankCbx3
            // 
            this.bankCbx3.AutoSize = true;
            this.bankCbx3.Checked = true;
            this.bankCbx3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.bankCbx3.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.bankCbx3.Location = new System.Drawing.Point(205, 13);
            this.bankCbx3.Name = "bankCbx3";
            this.bankCbx3.Size = new System.Drawing.Size(91, 20);
            this.bankCbx3.TabIndex = 15;
            this.bankCbx3.Text = "三井住友";
            this.bankCbx3.UseVisualStyleBackColor = true;
            // 
            // bankCbx2
            // 
            this.bankCbx2.AutoSize = true;
            this.bankCbx2.Checked = true;
            this.bankCbx2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.bankCbx2.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.bankCbx2.Location = new System.Drawing.Point(140, 13);
            this.bankCbx2.Name = "bankCbx2";
            this.bankCbx2.Size = new System.Drawing.Size(59, 20);
            this.bankCbx2.TabIndex = 14;
            this.bankCbx2.Text = "碧信";
            this.bankCbx2.UseVisualStyleBackColor = true;
            // 
            // bankCbx1
            // 
            this.bankCbx1.AutoSize = true;
            this.bankCbx1.Checked = true;
            this.bankCbx1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.bankCbx1.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.bankCbx1.Location = new System.Drawing.Point(75, 13);
            this.bankCbx1.Name = "bankCbx1";
            this.bankCbx1.Size = new System.Drawing.Size(55, 20);
            this.bankCbx1.TabIndex = 13;
            this.bankCbx1.Text = "UFJ";
            this.bankCbx1.UseVisualStyleBackColor = true;
            // 
            // bankCbx0
            // 
            this.bankCbx0.AutoSize = true;
            this.bankCbx0.Checked = true;
            this.bankCbx0.CheckState = System.Windows.Forms.CheckState.Checked;
            this.bankCbx0.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.bankCbx0.Location = new System.Drawing.Point(10, 13);
            this.bankCbx0.Name = "bankCbx0";
            this.bankCbx0.Size = new System.Drawing.Size(59, 20);
            this.bankCbx0.TabIndex = 12;
            this.bankCbx0.Text = "豊信";
            this.bankCbx0.UseVisualStyleBackColor = true;
            // 
            // approvalPanel
            // 
            this.approvalPanel.Controls.Add(this.approvalRb);
            this.approvalPanel.Controls.Add(this.unapprovalRb);
            this.approvalPanel.Location = new System.Drawing.Point(207, 87);
            this.approvalPanel.Name = "approvalPanel";
            this.approvalPanel.Size = new System.Drawing.Size(200, 50);
            this.approvalPanel.TabIndex = 2;
            // 
            // selectDepostiPanel
            // 
            this.selectDepostiPanel.Controls.Add(this.depositCbx0);
            this.selectDepostiPanel.Controls.Add(this.depositCbx1);
            this.selectDepostiPanel.Controls.Add(this.depositCbx2);
            this.selectDepostiPanel.Controls.Add(this.depositCbx3);
            this.selectDepostiPanel.Location = new System.Drawing.Point(207, 190);
            this.selectDepostiPanel.Name = "selectDepostiPanel";
            this.selectDepostiPanel.Size = new System.Drawing.Size(364, 30);
            this.selectDepostiPanel.TabIndex = 6;
            // 
            // selectBankPanel
            // 
            this.selectBankPanel.Controls.Add(this.bankCbx0);
            this.selectBankPanel.Controls.Add(this.bankCbx1);
            this.selectBankPanel.Controls.Add(this.bankCbx2);
            this.selectBankPanel.Controls.Add(this.bankCbx3);
            this.selectBankPanel.Location = new System.Drawing.Point(207, 283);
            this.selectBankPanel.Name = "selectBankPanel";
            this.selectBankPanel.Size = new System.Drawing.Size(364, 46);
            this.selectBankPanel.TabIndex = 12;
            // 
            // allDepositCbx
            // 
            this.allDepositCbx.AutoSize = true;
            this.allDepositCbx.Checked = true;
            this.allDepositCbx.CheckState = System.Windows.Forms.CheckState.Checked;
            this.allDepositCbx.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.allDepositCbx.Location = new System.Drawing.Point(217, 156);
            this.allDepositCbx.Name = "allDepositCbx";
            this.allDepositCbx.Size = new System.Drawing.Size(56, 20);
            this.allDepositCbx.TabIndex = 100;
            this.allDepositCbx.Text = "全て";
            this.allDepositCbx.UseVisualStyleBackColor = true;
            // 
            // allBankCbx
            // 
            this.allBankCbx.AutoSize = true;
            this.allBankCbx.Checked = true;
            this.allBankCbx.CheckState = System.Windows.Forms.CheckState.Checked;
            this.allBankCbx.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.allBankCbx.Location = new System.Drawing.Point(217, 248);
            this.allBankCbx.Name = "allBankCbx";
            this.allBankCbx.Size = new System.Drawing.Size(56, 20);
            this.allBankCbx.TabIndex = 101;
            this.allBankCbx.Text = "全て";
            this.allBankCbx.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 459);
            this.Controls.Add(this.allBankCbx);
            this.Controls.Add(this.allDepositCbx);
            this.Controls.Add(this.selectBankPanel);
            this.Controls.Add(this.selectDepostiPanel);
            this.Controls.Add(this.approvalPanel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.printBtn);
            this.Controls.Add(this.endBtn);
            this.Controls.Add(this.dateLabel);
            this.Controls.Add(this.dateMtb);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.approvalPanel.ResumeLayout(false);
            this.approvalPanel.PerformLayout();
            this.selectDepostiPanel.ResumeLayout(false);
            this.selectDepostiPanel.PerformLayout();
            this.selectBankPanel.ResumeLayout(false);
            this.selectBankPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox dateMtb;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.Button endBtn;
        private System.Windows.Forms.Button printBtn;
        private System.Windows.Forms.RadioButton approvalRb;
        private System.Windows.Forms.RadioButton unapprovalRb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox depositCbx0;
        private System.Windows.Forms.CheckBox depositCbx1;
        private System.Windows.Forms.CheckBox depositCbx2;
        private System.Windows.Forms.CheckBox depositCbx3;
        private System.Windows.Forms.CheckBox bankCbx3;
        private System.Windows.Forms.CheckBox bankCbx2;
        private System.Windows.Forms.CheckBox bankCbx1;
        private System.Windows.Forms.CheckBox bankCbx0;
        private System.Windows.Forms.Panel approvalPanel;
        private System.Windows.Forms.Panel selectDepostiPanel;
        private System.Windows.Forms.Panel selectBankPanel;
        private System.Windows.Forms.CheckBox allDepositCbx;
        private System.Windows.Forms.CheckBox allBankCbx;
    }
}

