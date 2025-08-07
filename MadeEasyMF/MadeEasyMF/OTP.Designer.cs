namespace SoftlightMF
{
    partial class OTP
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
            this.sSMessage = new System.Windows.Forms.StatusStrip();
            this.tSSMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.comboOTPType = new System.Windows.Forms.ComboBox();
            this.comboUser = new System.Windows.Forms.ComboBox();
            this.txtOTP = new System.Windows.Forms.TextBox();
            this.lblCode = new System.Windows.Forms.Label();
            this.linkClearAmount = new System.Windows.Forms.LinkLabel();
            this.sSMessage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // sSMessage
            // 
            this.sSMessage.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSSMessage});
            this.sSMessage.Location = new System.Drawing.Point(0, 137);
            this.sSMessage.Name = "sSMessage";
            this.sSMessage.Size = new System.Drawing.Size(332, 22);
            this.sSMessage.TabIndex = 131;
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
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.Color.Maroon;
            this.btnConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.ForeColor = System.Drawing.Color.White;
            this.btnConfirm.Location = new System.Drawing.Point(178, 105);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(111, 23);
            this.btnConfirm.TabIndex = 130;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Maroon;
            this.lblTitle.Font = new System.Drawing.Font("Old English Text MT", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(106, 8);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(64, 24);
            this.lblTitle.TabIndex = 133;
            this.lblTitle.Text = "OTP";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Maroon;
            this.button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(332, 38);
            this.button1.TabIndex = 132;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // comboOTPType
            // 
            this.comboOTPType.AutoCompleteCustomSource.AddRange(new string[] {
            "Edit Customer",
            "Login",
            "Security Code"});
            this.comboOTPType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboOTPType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.comboOTPType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboOTPType.ForeColor = System.Drawing.Color.Maroon;
            this.comboOTPType.FormattingEnabled = true;
            this.comboOTPType.Items.AddRange(new object[] {
            "Edit Customer",
            "Login",
            "Security Code"});
            this.comboOTPType.Location = new System.Drawing.Point(199, 41);
            this.comboOTPType.Name = "comboOTPType";
            this.comboOTPType.Size = new System.Drawing.Size(119, 21);
            this.comboOTPType.Sorted = true;
            this.comboOTPType.TabIndex = 134;
            this.comboOTPType.Text = "Select OTP Type";
            this.comboOTPType.Visible = false;
            // 
            // comboUser
            // 
            this.comboUser.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboUser.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.comboUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboUser.ForeColor = System.Drawing.Color.Maroon;
            this.comboUser.FormattingEnabled = true;
            this.comboUser.Location = new System.Drawing.Point(50, 105);
            this.comboUser.Name = "comboUser";
            this.comboUser.Size = new System.Drawing.Size(119, 21);
            this.comboUser.TabIndex = 135;
            this.comboUser.Text = "Select User";
            this.comboUser.Visible = false;
            // 
            // txtOTP
            // 
            this.txtOTP.Location = new System.Drawing.Point(145, 75);
            this.txtOTP.Name = "txtOTP";
            this.txtOTP.Size = new System.Drawing.Size(143, 20);
            this.txtOTP.TabIndex = 129;
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCode.ForeColor = System.Drawing.Color.Maroon;
            this.lblCode.Location = new System.Drawing.Point(47, 76);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(79, 16);
            this.lblCode.TabIndex = 128;
            this.lblCode.Text = "Enter OTP";
            // 
            // linkClearAmount
            // 
            this.linkClearAmount.AutoSize = true;
            this.linkClearAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkClearAmount.LinkColor = System.Drawing.Color.Maroon;
            this.linkClearAmount.Location = new System.Drawing.Point(12, 44);
            this.linkClearAmount.Name = "linkClearAmount";
            this.linkClearAmount.Size = new System.Drawing.Size(82, 13);
            this.linkClearAmount.TabIndex = 137;
            this.linkClearAmount.TabStop = true;
            this.linkClearAmount.Text = "Clear Amount";
            this.linkClearAmount.Visible = false;
            this.linkClearAmount.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkClearAmount_LinkClicked);
            // 
            // OTP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(332, 159);
            this.Controls.Add(this.linkClearAmount);
            this.Controls.Add(this.sSMessage);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboOTPType);
            this.Controls.Add(this.comboUser);
            this.Controls.Add(this.txtOTP);
            this.Controls.Add(this.lblCode);
            this.Name = "OTP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OTP";
            this.sSMessage.ResumeLayout(false);
            this.sSMessage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip sSMessage;
        private System.Windows.Forms.ToolStripStatusLabel tSSMessage;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.ComboBox comboOTPType;
        private System.Windows.Forms.ComboBox comboUser;
        private System.Windows.Forms.TextBox txtOTP;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.LinkLabel linkClearAmount;
    }
}