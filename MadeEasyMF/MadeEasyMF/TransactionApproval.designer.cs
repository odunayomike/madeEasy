namespace SoftlightMF
{
    partial class TransactionApproval
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
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.sSMessage = new System.Windows.Forms.StatusStrip();
            this.tSSMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.comboFilter = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.regEdit = new System.Windows.Forms.Label();
            this.linkHome = new System.Windows.Forms.LinkLabel();
            this.linkLogout = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.comboLedgerID = new System.Windows.Forms.ComboBox();
            this.dataGridLedger = new System.Windows.Forms.DataGridView();
            this.checkApprovedTransaction = new System.Windows.Forms.CheckBox();
            this.btnDisApprove = new System.Windows.Forms.Button();
            this.btnApprove = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.sSMessage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridLedger)).BeginInit();
            this.SuspendLayout();
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // sSMessage
            // 
            this.sSMessage.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSSMessage});
            this.sSMessage.Location = new System.Drawing.Point(0, 253);
            this.sSMessage.Name = "sSMessage";
            this.sSMessage.Size = new System.Drawing.Size(499, 22);
            this.sSMessage.TabIndex = 239;
            this.sSMessage.Text = "statusStrip1";
            this.sSMessage.Visible = false;
            // 
            // tSSMessage
            // 
            this.tSSMessage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.tSSMessage.ForeColor = System.Drawing.Color.Red;
            this.tSSMessage.Name = "tSSMessage";
            this.tSSMessage.Size = new System.Drawing.Size(127, 17);
            this.tSSMessage.Text = "toolStripStatusLabel1";
            // 
            // comboFilter
            // 
            this.comboFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboFilter.ForeColor = System.Drawing.Color.Maroon;
            this.comboFilter.FormattingEnabled = true;
            this.comboFilter.Location = new System.Drawing.Point(12, 51);
            this.comboFilter.Name = "comboFilter";
            this.comboFilter.Size = new System.Drawing.Size(107, 23);
            this.comboFilter.TabIndex = 235;
            this.comboFilter.Text = "Filter";
            this.comboFilter.SelectedIndexChanged += new System.EventHandler(this.comboFilter_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Maroon;
            this.button2.Dock = System.Windows.Forms.DockStyle.Top;
            this.button2.Location = new System.Drawing.Point(0, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(561, 45);
            this.button2.TabIndex = 230;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // regEdit
            // 
            this.regEdit.AutoSize = true;
            this.regEdit.BackColor = System.Drawing.Color.Maroon;
            this.regEdit.Font = new System.Drawing.Font("Old English Text MT", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.regEdit.ForeColor = System.Drawing.Color.White;
            this.regEdit.Location = new System.Drawing.Point(116, 8);
            this.regEdit.Name = "regEdit";
            this.regEdit.Size = new System.Drawing.Size(275, 32);
            this.regEdit.TabIndex = 231;
            this.regEdit.Text = "Transaction Approval";
            // 
            // linkHome
            // 
            this.linkHome.AutoSize = true;
            this.linkHome.BackColor = System.Drawing.Color.Maroon;
            this.linkHome.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkHome.ForeColor = System.Drawing.Color.White;
            this.linkHome.LinkColor = System.Drawing.Color.White;
            this.linkHome.Location = new System.Drawing.Point(453, 21);
            this.linkHome.Name = "linkHome";
            this.linkHome.Size = new System.Drawing.Size(45, 15);
            this.linkHome.TabIndex = 233;
            this.linkHome.TabStop = true;
            this.linkHome.Text = "Home";
            this.linkHome.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkHome_LinkClicked);
            // 
            // linkLogout
            // 
            this.linkLogout.AutoSize = true;
            this.linkLogout.BackColor = System.Drawing.Color.Maroon;
            this.linkLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLogout.LinkColor = System.Drawing.Color.White;
            this.linkLogout.Location = new System.Drawing.Point(501, 21);
            this.linkLogout.Name = "linkLogout";
            this.linkLogout.Size = new System.Drawing.Size(51, 15);
            this.linkLogout.TabIndex = 234;
            this.linkLogout.TabStop = true;
            this.linkLogout.Text = "Logout";
            this.linkLogout.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLogout_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Maroon;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(494, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 15);
            this.label1.TabIndex = 232;
            this.label1.Text = "/";
            // 
            // comboLedgerID
            // 
            this.comboLedgerID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboLedgerID.ForeColor = System.Drawing.Color.Maroon;
            this.comboLedgerID.FormattingEnabled = true;
            this.comboLedgerID.Location = new System.Drawing.Point(125, 51);
            this.comboLedgerID.Name = "comboLedgerID";
            this.comboLedgerID.Size = new System.Drawing.Size(107, 23);
            this.comboLedgerID.TabIndex = 235;
            this.comboLedgerID.Text = "Ledger ID";
            this.comboLedgerID.SelectedIndexChanged += new System.EventHandler(this.comboLedgerID_SelectedIndexChanged);
            // 
            // dataGridLedger
            // 
            this.dataGridLedger.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridLedger.Location = new System.Drawing.Point(8, 91);
            this.dataGridLedger.Name = "dataGridLedger";
            this.dataGridLedger.Size = new System.Drawing.Size(544, 150);
            this.dataGridLedger.TabIndex = 241;
            this.dataGridLedger.Visible = false;
            // 
            // checkApprovedTransaction
            // 
            this.checkApprovedTransaction.AutoSize = true;
            this.checkApprovedTransaction.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkApprovedTransaction.ForeColor = System.Drawing.Color.Maroon;
            this.checkApprovedTransaction.Location = new System.Drawing.Point(332, 51);
            this.checkApprovedTransaction.Name = "checkApprovedTransaction";
            this.checkApprovedTransaction.Size = new System.Drawing.Size(220, 19);
            this.checkApprovedTransaction.TabIndex = 242;
            this.checkApprovedTransaction.Text = "Show Approved Transaction(s)";
            this.checkApprovedTransaction.UseVisualStyleBackColor = true;
            this.checkApprovedTransaction.CheckedChanged += new System.EventHandler(this.checkApprovedTransaction_CheckedChanged);
            // 
            // btnDisApprove
            // 
            this.btnDisApprove.BackColor = System.Drawing.Color.White;
            this.btnDisApprove.BackgroundImage = global::SoftlightMF.Properties.Resources.disapprove;
            this.btnDisApprove.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDisApprove.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDisApprove.ForeColor = System.Drawing.Color.White;
            this.btnDisApprove.Location = new System.Drawing.Point(271, 49);
            this.btnDisApprove.Name = "btnDisApprove";
            this.btnDisApprove.Size = new System.Drawing.Size(28, 26);
            this.btnDisApprove.TabIndex = 243;
            this.toolTip.SetToolTip(this.btnDisApprove, "Disapprove Transaction");
            this.btnDisApprove.UseVisualStyleBackColor = false;
            this.btnDisApprove.Click += new System.EventHandler(this.btnDisapprove_Click);
            // 
            // btnApprove
            // 
            this.btnApprove.BackColor = System.Drawing.Color.White;
            this.btnApprove.BackgroundImage = global::SoftlightMF.Properties.Resources.approve2;
            this.btnApprove.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnApprove.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApprove.ForeColor = System.Drawing.Color.White;
            this.btnApprove.Location = new System.Drawing.Point(237, 49);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(28, 26);
            this.btnApprove.TabIndex = 240;
            this.toolTip.SetToolTip(this.btnApprove, "Approve Transaction");
            this.btnApprove.UseVisualStyleBackColor = false;
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
            // 
            // toolTip
            // 
            this.toolTip.IsBalloon = true;
            // 
            // TransactionApproval
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(561, 275);
            this.Controls.Add(this.btnDisApprove);
            this.Controls.Add(this.checkApprovedTransaction);
            this.Controls.Add(this.dataGridLedger);
            this.Controls.Add(this.btnApprove);
            this.Controls.Add(this.comboLedgerID);
            this.Controls.Add(this.comboFilter);
            this.Controls.Add(this.regEdit);
            this.Controls.Add(this.linkHome);
            this.Controls.Add(this.linkLogout);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.sSMessage);
            this.Name = "TransactionApproval";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transaction Approval";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.sSMessage.ResumeLayout(false);
            this.sSMessage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridLedger)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.StatusStrip sSMessage;
        private System.Windows.Forms.ToolStripStatusLabel tSSMessage;
        private System.Windows.Forms.ComboBox comboFilter;
        private System.Windows.Forms.Label regEdit;
        private System.Windows.Forms.LinkLabel linkHome;
        private System.Windows.Forms.LinkLabel linkLogout;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox comboLedgerID;
        private System.Windows.Forms.Button btnApprove;
        private System.Windows.Forms.DataGridView dataGridLedger;
        private System.Windows.Forms.CheckBox checkApprovedTransaction;
        private System.Windows.Forms.Button btnDisApprove;
        private System.Windows.Forms.ToolTip toolTip;
    }
}