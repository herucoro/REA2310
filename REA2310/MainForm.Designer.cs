
namespace REA2310
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
            this.label1 = new System.Windows.Forms.Label();
            this.approvalRb0 = new System.Windows.Forms.RadioButton();
            this.approvalRb1 = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.allPaymentCbx = new System.Windows.Forms.CheckBox();
            this.paymentCbx0 = new System.Windows.Forms.CheckBox();
            this.paymentCbx1 = new System.Windows.Forms.CheckBox();
            this.paymentCbx2 = new System.Windows.Forms.CheckBox();
            this.paymentCbx3 = new System.Windows.Forms.CheckBox();
            this.allBankCbx = new System.Windows.Forms.CheckBox();
            this.selectPaymentPanel = new System.Windows.Forms.Panel();
            this.selectBankPanel = new System.Windows.Forms.Panel();
            this.bankCbx0 = new System.Windows.Forms.CheckBox();
            this.bankCbx1 = new System.Windows.Forms.CheckBox();
            this.bankCbx2 = new System.Windows.Forms.CheckBox();
            this.bankCbx3 = new System.Windows.Forms.CheckBox();
            this.approvalPanel = new System.Windows.Forms.Panel();
            this.selectPaymentPanel.SuspendLayout();
            this.selectBankPanel.SuspendLayout();
            this.approvalPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // dateMtb
            // 
            this.dateMtb.Font = new System.Drawing.Font("MS UI Gothic", 14F);
            this.dateMtb.Location = new System.Drawing.Point(202, 30);
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
            this.dateLabel.Location = new System.Drawing.Point(67, 34);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(98, 22);
            this.dateLabel.TabIndex = 1;
            this.dateLabel.Text = "開始年月";
            // 
            // endBtn
            // 
            this.endBtn.Font = new System.Drawing.Font("MS UI Gothic", 14F);
            this.endBtn.Location = new System.Drawing.Point(386, 255);
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
            this.printBtn.Location = new System.Drawing.Point(106, 255);
            this.printBtn.Name = "printBtn";
            this.printBtn.Size = new System.Drawing.Size(94, 43);
            this.printBtn.TabIndex = 3;
            this.printBtn.Text = "印刷";
            this.printBtn.UseVisualStyleBackColor = true;
            this.printBtn.Click += new System.EventHandler(this.printBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.label1.Location = new System.Drawing.Point(67, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 22);
            this.label1.TabIndex = 6;
            this.label1.Text = "決裁状態";
            // 
            // approvalRb0
            // 
            this.approvalRb0.AutoSize = true;
            this.approvalRb0.Checked = true;
            this.approvalRb0.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.approvalRb0.Location = new System.Drawing.Point(17, 6);
            this.approvalRb0.Name = "approvalRb0";
            this.approvalRb0.Size = new System.Drawing.Size(58, 20);
            this.approvalRb0.TabIndex = 7;
            this.approvalRb0.TabStop = true;
            this.approvalRb0.Text = "決裁";
            this.approvalRb0.UseVisualStyleBackColor = true;
            // 
            // approvalRb1
            // 
            this.approvalRb1.AutoSize = true;
            this.approvalRb1.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.approvalRb1.Location = new System.Drawing.Point(103, 6);
            this.approvalRb1.Name = "approvalRb1";
            this.approvalRb1.Size = new System.Drawing.Size(74, 20);
            this.approvalRb1.TabIndex = 8;
            this.approvalRb1.Text = "未決裁";
            this.approvalRb1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.label2.Location = new System.Drawing.Point(67, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 22);
            this.label2.TabIndex = 9;
            this.label2.Text = "入金種別";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.label3.Location = new System.Drawing.Point(67, 180);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 22);
            this.label3.TabIndex = 10;
            this.label3.Text = "銀行";
            // 
            // allPaymentCbx
            // 
            this.allPaymentCbx.AutoSize = true;
            this.allPaymentCbx.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.allPaymentCbx.Location = new System.Drawing.Point(202, 122);
            this.allPaymentCbx.Name = "allPaymentCbx";
            this.allPaymentCbx.Size = new System.Drawing.Size(56, 20);
            this.allPaymentCbx.TabIndex = 11;
            this.allPaymentCbx.Text = "全て";
            this.allPaymentCbx.UseVisualStyleBackColor = true;
            // 
            // paymentCbx0
            // 
            this.paymentCbx0.AutoSize = true;
            this.paymentCbx0.Location = new System.Drawing.Point(17, 4);
            this.paymentCbx0.Name = "paymentCbx0";
            this.paymentCbx0.Size = new System.Drawing.Size(59, 20);
            this.paymentCbx0.TabIndex = 12;
            this.paymentCbx0.Text = "手形";
            this.paymentCbx0.UseVisualStyleBackColor = true;
            // 
            // paymentCbx1
            // 
            this.paymentCbx1.AutoSize = true;
            this.paymentCbx1.Location = new System.Drawing.Point(103, 3);
            this.paymentCbx1.Name = "paymentCbx1";
            this.paymentCbx1.Size = new System.Drawing.Size(59, 20);
            this.paymentCbx1.TabIndex = 13;
            this.paymentCbx1.Text = "電債";
            this.paymentCbx1.UseVisualStyleBackColor = true;
            // 
            // paymentCbx2
            // 
            this.paymentCbx2.AutoSize = true;
            this.paymentCbx2.Location = new System.Drawing.Point(178, 3);
            this.paymentCbx2.Name = "paymentCbx2";
            this.paymentCbx2.Size = new System.Drawing.Size(91, 20);
            this.paymentCbx2.TabIndex = 14;
            this.paymentCbx2.Text = "期日指定";
            this.paymentCbx2.UseVisualStyleBackColor = true;
            // 
            // paymentCbx3
            // 
            this.paymentCbx3.AutoSize = true;
            this.paymentCbx3.Location = new System.Drawing.Point(285, 4);
            this.paymentCbx3.Name = "paymentCbx3";
            this.paymentCbx3.Size = new System.Drawing.Size(102, 20);
            this.paymentCbx3.TabIndex = 15;
            this.paymentCbx3.Text = "ファクタリング";
            this.paymentCbx3.UseVisualStyleBackColor = true;
            // 
            // allBankCbx
            // 
            this.allBankCbx.AutoSize = true;
            this.allBankCbx.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.allBankCbx.Location = new System.Drawing.Point(202, 186);
            this.allBankCbx.Name = "allBankCbx";
            this.allBankCbx.Size = new System.Drawing.Size(56, 20);
            this.allBankCbx.TabIndex = 16;
            this.allBankCbx.Text = "全て";
            this.allBankCbx.UseVisualStyleBackColor = true;
            // 
            // selectPaymentPanel
            // 
            this.selectPaymentPanel.Controls.Add(this.paymentCbx0);
            this.selectPaymentPanel.Controls.Add(this.paymentCbx1);
            this.selectPaymentPanel.Controls.Add(this.paymentCbx2);
            this.selectPaymentPanel.Controls.Add(this.paymentCbx3);
            this.selectPaymentPanel.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.selectPaymentPanel.Location = new System.Drawing.Point(185, 147);
            this.selectPaymentPanel.Name = "selectPaymentPanel";
            this.selectPaymentPanel.Size = new System.Drawing.Size(389, 33);
            this.selectPaymentPanel.TabIndex = 21;
            // 
            // selectBankPanel
            // 
            this.selectBankPanel.Controls.Add(this.bankCbx0);
            this.selectBankPanel.Controls.Add(this.bankCbx1);
            this.selectBankPanel.Controls.Add(this.bankCbx2);
            this.selectBankPanel.Controls.Add(this.bankCbx3);
            this.selectBankPanel.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.selectBankPanel.Location = new System.Drawing.Point(185, 208);
            this.selectBankPanel.Name = "selectBankPanel";
            this.selectBankPanel.Size = new System.Drawing.Size(389, 30);
            this.selectBankPanel.TabIndex = 22;
            // 
            // bankCbx0
            // 
            this.bankCbx0.AutoSize = true;
            this.bankCbx0.Location = new System.Drawing.Point(17, 4);
            this.bankCbx0.Name = "bankCbx0";
            this.bankCbx0.Size = new System.Drawing.Size(59, 20);
            this.bankCbx0.TabIndex = 12;
            this.bankCbx0.Text = "豊信";
            this.bankCbx0.UseVisualStyleBackColor = true;
            // 
            // bankCbx1
            // 
            this.bankCbx1.AutoSize = true;
            this.bankCbx1.Location = new System.Drawing.Point(103, 4);
            this.bankCbx1.Name = "bankCbx1";
            this.bankCbx1.Size = new System.Drawing.Size(55, 20);
            this.bankCbx1.TabIndex = 13;
            this.bankCbx1.Text = "UFJ";
            this.bankCbx1.UseVisualStyleBackColor = true;
            // 
            // bankCbx2
            // 
            this.bankCbx2.AutoSize = true;
            this.bankCbx2.Location = new System.Drawing.Point(178, 4);
            this.bankCbx2.Name = "bankCbx2";
            this.bankCbx2.Size = new System.Drawing.Size(59, 20);
            this.bankCbx2.TabIndex = 14;
            this.bankCbx2.Text = "碧信";
            this.bankCbx2.UseVisualStyleBackColor = true;
            // 
            // bankCbx3
            // 
            this.bankCbx3.AutoSize = true;
            this.bankCbx3.Location = new System.Drawing.Point(259, 4);
            this.bankCbx3.Name = "bankCbx3";
            this.bankCbx3.Size = new System.Drawing.Size(91, 20);
            this.bankCbx3.TabIndex = 15;
            this.bankCbx3.Text = "三井住友";
            this.bankCbx3.UseVisualStyleBackColor = true;
            // 
            // approvalPanel
            // 
            this.approvalPanel.Controls.Add(this.approvalRb0);
            this.approvalPanel.Controls.Add(this.approvalRb1);
            this.approvalPanel.Location = new System.Drawing.Point(185, 79);
            this.approvalPanel.Name = "approvalPanel";
            this.approvalPanel.Size = new System.Drawing.Size(389, 29);
            this.approvalPanel.TabIndex = 23;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 322);
            this.Controls.Add(this.approvalPanel);
            this.Controls.Add(this.selectBankPanel);
            this.Controls.Add(this.selectPaymentPanel);
            this.Controls.Add(this.allBankCbx);
            this.Controls.Add(this.allPaymentCbx);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.printBtn);
            this.Controls.Add(this.endBtn);
            this.Controls.Add(this.dateLabel);
            this.Controls.Add(this.dateMtb);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.selectPaymentPanel.ResumeLayout(false);
            this.selectPaymentPanel.PerformLayout();
            this.selectBankPanel.ResumeLayout(false);
            this.selectBankPanel.PerformLayout();
            this.approvalPanel.ResumeLayout(false);
            this.approvalPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox dateMtb;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.Button endBtn;
        private System.Windows.Forms.Button printBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton approvalRb0;
        private System.Windows.Forms.RadioButton approvalRb1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox allPaymentCbx;
        private System.Windows.Forms.CheckBox paymentCbx0;
        private System.Windows.Forms.CheckBox paymentCbx1;
        private System.Windows.Forms.CheckBox paymentCbx2;
        private System.Windows.Forms.CheckBox paymentCbx3;
        private System.Windows.Forms.CheckBox allBankCbx;
        private System.Windows.Forms.Panel selectPaymentPanel;
        private System.Windows.Forms.Panel selectBankPanel;
        private System.Windows.Forms.CheckBox bankCbx0;
        private System.Windows.Forms.CheckBox bankCbx1;
        private System.Windows.Forms.CheckBox bankCbx2;
        private System.Windows.Forms.CheckBox bankCbx3;
        private System.Windows.Forms.Panel approvalPanel;
    }
}

