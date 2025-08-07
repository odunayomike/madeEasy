namespace SoftlightMF
{
    partial class BalanceLoan
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
            this.btnClear = new System.Windows.Forms.Button();
            this.btnBalance = new System.Windows.Forms.Button();
            this.tSSMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.linkLogout = new System.Windows.Forms.LinkLabel();
            this.linkHome = new System.Windows.Forms.LinkLabel();
            this.label15 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.sSMessage = new System.Windows.Forms.StatusStrip();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.numMonthWaiver = new System.Windows.Forms.NumericUpDown();
            this.checkWaiver = new System.Windows.Forms.CheckBox();
            this.txtAccNo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.sSMessage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMonthWaiver)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Maroon;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(202, 124);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(83, 23);
            this.btnClear.TabIndex = 71;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnBalance
            // 
            this.btnBalance.BackColor = System.Drawing.Color.Maroon;
            this.btnBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBalance.ForeColor = System.Drawing.Color.White;
            this.btnBalance.Location = new System.Drawing.Point(110, 124);
            this.btnBalance.Name = "btnBalance";
            this.btnBalance.Size = new System.Drawing.Size(86, 23);
            this.btnBalance.TabIndex = 70;
            this.btnBalance.Text = "Balance";
            this.btnBalance.UseVisualStyleBackColor = false;
            this.btnBalance.Click += new System.EventHandler(this.btnBalance_Click);
            // 
            // tSSMessage
            // 
            this.tSSMessage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.tSSMessage.ForeColor = System.Drawing.Color.Red;
            this.tSSMessage.Name = "tSSMessage";
            this.tSSMessage.Size = new System.Drawing.Size(127, 17);
            this.tSSMessage.Text = "toolStripStatusLabel1";
            // 
            // linkLogout
            // 
            this.linkLogout.AutoSize = true;
            this.linkLogout.BackColor = System.Drawing.Color.Maroon;
            this.linkLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLogout.LinkColor = System.Drawing.Color.White;
            this.linkLogout.Location = new System.Drawing.Point(308, 15);
            this.linkLogout.Name = "linkLogout";
            this.linkLogout.Size = new System.Drawing.Size(51, 15);
            this.linkLogout.TabIndex = 79;
            this.linkLogout.TabStop = true;
            this.linkLogout.Text = "Logout";
            this.linkLogout.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLogout_LinkClicked_1);
            // 
            // linkHome
            // 
            this.linkHome.AutoSize = true;
            this.linkHome.BackColor = System.Drawing.Color.Maroon;
            this.linkHome.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkHome.ForeColor = System.Drawing.Color.White;
            this.linkHome.LinkColor = System.Drawing.Color.White;
            this.linkHome.Location = new System.Drawing.Point(260, 15);
            this.linkHome.Name = "linkHome";
            this.linkHome.Size = new System.Drawing.Size(45, 15);
            this.linkHome.TabIndex = 78;
            this.linkHome.TabStop = true;
            this.linkHome.Text = "Home";
            this.linkHome.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkHome_LinkClicked);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Maroon;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(301, 16);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(11, 15);
            this.label15.TabIndex = 77;
            this.label15.Text = "/";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Maroon;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(100, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 20);
            this.label1.TabIndex = 75;
            this.label1.Text = "Balance Loan";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Maroon;
            this.button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(377, 39);
            this.button1.TabIndex = 76;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // sSMessage
            // 
            this.sSMessage.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSSMessage});
            this.sSMessage.Location = new System.Drawing.Point(0, 150);
            this.sSMessage.Name = "sSMessage";
            this.sSMessage.Size = new System.Drawing.Size(377, 22);
            this.sSMessage.TabIndex = 74;
            this.sSMessage.Text = "statusStrip1";
            this.sSMessage.Visible = false;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // numMonthWaiver
            // 
            this.numMonthWaiver.Location = new System.Drawing.Point(174, 91);
            this.numMonthWaiver.Name = "numMonthWaiver";
            this.numMonthWaiver.Size = new System.Drawing.Size(50, 20);
            this.numMonthWaiver.TabIndex = 86;
            this.numMonthWaiver.Visible = false;
            // 
            // checkWaiver
            // 
            this.checkWaiver.AutoSize = true;
            this.checkWaiver.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkWaiver.ForeColor = System.Drawing.Color.Maroon;
            this.checkWaiver.Location = new System.Drawing.Point(100, 90);
            this.checkWaiver.Name = "checkWaiver";
            this.checkWaiver.Size = new System.Drawing.Size(69, 19);
            this.checkWaiver.TabIndex = 85;
            this.checkWaiver.Text = "Waiver";
            this.checkWaiver.UseVisualStyleBackColor = true;
            this.checkWaiver.CheckedChanged += new System.EventHandler(this.checkWaiver_CheckedChanged);
            // 
            // txtAccNo
            // 
            this.txtAccNo.Location = new System.Drawing.Point(174, 53);
            this.txtAccNo.Name = "txtAccNo";
            this.txtAccNo.Size = new System.Drawing.Size(154, 20);
            this.txtAccNo.TabIndex = 84;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Maroon;
            this.label5.Location = new System.Drawing.Point(48, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 16);
            this.label5.TabIndex = 83;
            this.label5.Text = "Account Number";
            // 
            // BalanceLoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(377, 172);
            this.Controls.Add(this.numMonthWaiver);
            this.Controls.Add(this.checkWaiver);
            this.Controls.Add(this.txtAccNo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnBalance);
            this.Controls.Add(this.linkLogout);
            this.Controls.Add(this.linkHome);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.sSMessage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "BalanceLoan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Balance Loan";
            this.sSMessage.ResumeLayout(false);
            this.sSMessage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMonthWaiver)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnBalance;
        private System.Windows.Forms.ToolStripStatusLabel tSSMessage;
        private System.Windows.Forms.LinkLabel linkLogout;
        private System.Windows.Forms.LinkLabel linkHome;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.StatusStrip sSMessage;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.NumericUpDown numMonthWaiver;
        private System.Windows.Forms.CheckBox checkWaiver;
        private System.Windows.Forms.TextBox txtAccNo;
        private System.Windows.Forms.Label label5;
    }
}