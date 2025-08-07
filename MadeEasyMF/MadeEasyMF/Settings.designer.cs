namespace SoftlightMF
{
    partial class Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.picTools = new System.Windows.Forms.PictureBox();
            this.linkLogout = new System.Windows.Forms.LinkLabel();
            this.linkHome = new System.Windows.Forms.LinkLabel();
            this.button1 = new System.Windows.Forms.Button();
            this.btnDepClear = new System.Windows.Forms.Button();
            this.btnChange = new System.Windows.Forms.Button();
            this.sSMessage = new System.Windows.Forms.StatusStrip();
            this.tSSMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCurrentPass = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRePass = new System.Windows.Forms.TextBox();
            this.txtNewPass = new System.Windows.Forms.TextBox();
            this.txtCurrentPass = new System.Windows.Forms.TextBox();
            this.lblChangePass = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabChangePass = new System.Windows.Forms.TabControl();
            this.tabChange = new System.Windows.Forms.TabPage();
            this.checkShow = new System.Windows.Forms.CheckBox();
            this.tabPassExpiration = new System.Windows.Forms.TabPage();
            this.panPassExpire = new System.Windows.Forms.Panel();
            this.checkDeletePassAutoExpire = new System.Windows.Forms.CheckBox();
            this.btnSetup = new System.Windows.Forms.Button();
            this.comboInterval = new System.Windows.Forms.ComboBox();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.tabColor = new System.Windows.Forms.TabPage();
            this.panColor = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.btnForeColour = new System.Windows.Forms.Button();
            this.btnBgColour = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picTools)).BeginInit();
            this.sSMessage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabChangePass.SuspendLayout();
            this.tabChange.SuspendLayout();
            this.tabPassExpiration.SuspendLayout();
            this.panPassExpire.SuspendLayout();
            this.tabColor.SuspendLayout();
            this.panColor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.BackColor = System.Drawing.Color.Maroon;
            this.linkLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel2.LinkColor = System.Drawing.Color.White;
            this.linkLabel2.Location = new System.Drawing.Point(389, 22);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(11, 15);
            this.linkLabel2.TabIndex = 9;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "/";
            // 
            // picTools
            // 
            this.picTools.BackColor = System.Drawing.Color.White;
            this.picTools.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picTools.Image = ((System.Drawing.Image)(resources.GetObject("picTools.Image")));
            this.picTools.Location = new System.Drawing.Point(0, 0);
            this.picTools.Name = "picTools";
            this.picTools.Size = new System.Drawing.Size(222, 368);
            this.picTools.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picTools.TabIndex = 0;
            this.picTools.TabStop = false;
            // 
            // linkLogout
            // 
            this.linkLogout.AutoSize = true;
            this.linkLogout.BackColor = System.Drawing.Color.Maroon;
            this.linkLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLogout.LinkColor = System.Drawing.Color.White;
            this.linkLogout.Location = new System.Drawing.Point(396, 22);
            this.linkLogout.Name = "linkLogout";
            this.linkLogout.Size = new System.Drawing.Size(51, 15);
            this.linkLogout.TabIndex = 10;
            this.linkLogout.TabStop = true;
            this.linkLogout.Text = "Logout";
            this.linkLogout.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLogout_LinkClicked);
            // 
            // linkHome
            // 
            this.linkHome.AutoSize = true;
            this.linkHome.BackColor = System.Drawing.Color.Maroon;
            this.linkHome.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkHome.LinkColor = System.Drawing.Color.White;
            this.linkHome.Location = new System.Drawing.Point(348, 22);
            this.linkHome.Name = "linkHome";
            this.linkHome.Size = new System.Drawing.Size(45, 15);
            this.linkHome.TabIndex = 9;
            this.linkHome.TabStop = true;
            this.linkHome.Text = "Home";
            this.linkHome.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkHome_LinkClicked);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Maroon;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(460, 47);
            this.button1.TabIndex = 16;
            this.button1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // btnDepClear
            // 
            this.btnDepClear.BackColor = System.Drawing.Color.Maroon;
            this.btnDepClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDepClear.ForeColor = System.Drawing.Color.White;
            this.btnDepClear.Location = new System.Drawing.Point(222, 209);
            this.btnDepClear.Name = "btnDepClear";
            this.btnDepClear.Size = new System.Drawing.Size(112, 28);
            this.btnDepClear.TabIndex = 15;
            this.btnDepClear.Text = "Clear";
            this.btnDepClear.UseVisualStyleBackColor = false;
            this.btnDepClear.Click += new System.EventHandler(this.btnDepClear_Click);
            // 
            // btnChange
            // 
            this.btnChange.BackColor = System.Drawing.Color.Maroon;
            this.btnChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChange.ForeColor = System.Drawing.Color.White;
            this.btnChange.Location = new System.Drawing.Point(106, 209);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(111, 28);
            this.btnChange.TabIndex = 14;
            this.btnChange.Text = "Change";
            this.btnChange.UseVisualStyleBackColor = false;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // sSMessage
            // 
            this.sSMessage.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSSMessage});
            this.sSMessage.Location = new System.Drawing.Point(0, 346);
            this.sSMessage.Name = "sSMessage";
            this.sSMessage.Size = new System.Drawing.Size(463, 22);
            this.sSMessage.TabIndex = 13;
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Maroon;
            this.label2.Location = new System.Drawing.Point(71, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 17);
            this.label2.TabIndex = 25;
            this.label2.Text = "New Password";
            // 
            // lblCurrentPass
            // 
            this.lblCurrentPass.AutoSize = true;
            this.lblCurrentPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentPass.ForeColor = System.Drawing.Color.Maroon;
            this.lblCurrentPass.Location = new System.Drawing.Point(47, 86);
            this.lblCurrentPass.Name = "lblCurrentPass";
            this.lblCurrentPass.Size = new System.Drawing.Size(136, 17);
            this.lblCurrentPass.TabIndex = 24;
            this.lblCurrentPass.Text = "Current Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Maroon;
            this.label3.Location = new System.Drawing.Point(37, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 17);
            this.label3.TabIndex = 26;
            this.label3.Text = "Re-enter Password";
            // 
            // txtRePass
            // 
            this.txtRePass.Location = new System.Drawing.Point(189, 165);
            this.txtRePass.Name = "txtRePass";
            this.txtRePass.PasswordChar = '*';
            this.txtRePass.Size = new System.Drawing.Size(183, 21);
            this.txtRePass.TabIndex = 29;
            // 
            // txtNewPass
            // 
            this.txtNewPass.Location = new System.Drawing.Point(189, 125);
            this.txtNewPass.Name = "txtNewPass";
            this.txtNewPass.PasswordChar = '*';
            this.txtNewPass.Size = new System.Drawing.Size(183, 21);
            this.txtNewPass.TabIndex = 28;
            // 
            // txtCurrentPass
            // 
            this.txtCurrentPass.Location = new System.Drawing.Point(189, 85);
            this.txtCurrentPass.Name = "txtCurrentPass";
            this.txtCurrentPass.PasswordChar = '*';
            this.txtCurrentPass.Size = new System.Drawing.Size(183, 21);
            this.txtCurrentPass.TabIndex = 27;
            // 
            // lblChangePass
            // 
            this.lblChangePass.AutoSize = true;
            this.lblChangePass.Font = new System.Drawing.Font("Old English Text MT", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChangePass.ForeColor = System.Drawing.Color.Maroon;
            this.lblChangePass.Location = new System.Drawing.Point(102, 5);
            this.lblChangePass.Name = "lblChangePass";
            this.lblChangePass.Size = new System.Drawing.Size(246, 34);
            this.lblChangePass.TabIndex = 23;
            this.lblChangePass.Text = "Change Password";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.picTools);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel2.Controls.Add(this.linkLogout);
            this.splitContainer1.Panel2.Controls.Add(this.linkLabel2);
            this.splitContainer1.Panel2.Controls.Add(this.linkHome);
            this.splitContainer1.Panel2.Controls.Add(this.sSMessage);
            this.splitContainer1.Panel2.Controls.Add(this.tabChangePass);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.button1);
            this.splitContainer1.Size = new System.Drawing.Size(689, 368);
            this.splitContainer1.SplitterDistance = 222;
            this.splitContainer1.TabIndex = 2;
            // 
            // tabChangePass
            // 
            this.tabChangePass.Controls.Add(this.tabChange);
            this.tabChangePass.Controls.Add(this.tabPassExpiration);
            this.tabChangePass.Controls.Add(this.tabColor);
            this.tabChangePass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabChangePass.Location = new System.Drawing.Point(17, 53);
            this.tabChangePass.Name = "tabChangePass";
            this.tabChangePass.SelectedIndex = 0;
            this.tabChangePass.Size = new System.Drawing.Size(434, 285);
            this.tabChangePass.TabIndex = 12;
            // 
            // tabChange
            // 
            this.tabChange.Controls.Add(this.label3);
            this.tabChange.Controls.Add(this.label2);
            this.tabChange.Controls.Add(this.txtRePass);
            this.tabChange.Controls.Add(this.lblCurrentPass);
            this.tabChange.Controls.Add(this.checkShow);
            this.tabChange.Controls.Add(this.txtNewPass);
            this.tabChange.Controls.Add(this.lblChangePass);
            this.tabChange.Controls.Add(this.btnChange);
            this.tabChange.Controls.Add(this.btnDepClear);
            this.tabChange.Controls.Add(this.txtCurrentPass);
            this.tabChange.ForeColor = System.Drawing.Color.Maroon;
            this.tabChange.Location = new System.Drawing.Point(4, 24);
            this.tabChange.Name = "tabChange";
            this.tabChange.Padding = new System.Windows.Forms.Padding(3);
            this.tabChange.Size = new System.Drawing.Size(426, 257);
            this.tabChange.TabIndex = 1;
            this.tabChange.Text = "Change Password";
            this.tabChange.UseVisualStyleBackColor = true;
            // 
            // checkShow
            // 
            this.checkShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkShow.Location = new System.Drawing.Point(47, 49);
            this.checkShow.Name = "checkShow";
            this.checkShow.Size = new System.Drawing.Size(141, 24);
            this.checkShow.TabIndex = 25;
            this.checkShow.Text = "Show Password";
            this.checkShow.UseVisualStyleBackColor = true;
            this.checkShow.CheckedChanged += new System.EventHandler(this.checkShow_CheckedChanged);
            // 
            // tabPassExpiration
            // 
            this.tabPassExpiration.Controls.Add(this.panPassExpire);
            this.tabPassExpiration.Location = new System.Drawing.Point(4, 24);
            this.tabPassExpiration.Name = "tabPassExpiration";
            this.tabPassExpiration.Padding = new System.Windows.Forms.Padding(3);
            this.tabPassExpiration.Size = new System.Drawing.Size(426, 257);
            this.tabPassExpiration.TabIndex = 2;
            this.tabPassExpiration.Text = "Password Expiration";
            this.tabPassExpiration.UseVisualStyleBackColor = true;
            // 
            // panPassExpire
            // 
            this.panPassExpire.Controls.Add(this.checkDeletePassAutoExpire);
            this.panPassExpire.Controls.Add(this.btnSetup);
            this.panPassExpire.Controls.Add(this.comboInterval);
            this.panPassExpire.Controls.Add(this.datePicker);
            this.panPassExpire.Controls.Add(this.label4);
            this.panPassExpire.Location = new System.Drawing.Point(6, 6);
            this.panPassExpire.Name = "panPassExpire";
            this.panPassExpire.Size = new System.Drawing.Size(417, 245);
            this.panPassExpire.TabIndex = 24;
            // 
            // checkDeletePassAutoExpire
            // 
            this.checkDeletePassAutoExpire.AutoSize = true;
            this.checkDeletePassAutoExpire.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkDeletePassAutoExpire.ForeColor = System.Drawing.Color.Maroon;
            this.checkDeletePassAutoExpire.Location = new System.Drawing.Point(11, 72);
            this.checkDeletePassAutoExpire.Name = "checkDeletePassAutoExpire";
            this.checkDeletePassAutoExpire.Size = new System.Drawing.Size(237, 21);
            this.checkDeletePassAutoExpire.TabIndex = 143;
            this.checkDeletePassAutoExpire.Text = "Delete Password Auto-Expire";
            this.checkDeletePassAutoExpire.UseVisualStyleBackColor = true;
            this.checkDeletePassAutoExpire.CheckedChanged += new System.EventHandler(this.checkDeletePassAutoExpire_CheckedChanged);
            // 
            // btnSetup
            // 
            this.btnSetup.BackColor = System.Drawing.Color.Maroon;
            this.btnSetup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetup.ForeColor = System.Drawing.Color.White;
            this.btnSetup.Location = new System.Drawing.Point(170, 152);
            this.btnSetup.Name = "btnSetup";
            this.btnSetup.Size = new System.Drawing.Size(111, 28);
            this.btnSetup.TabIndex = 142;
            this.btnSetup.Text = "Setup";
            this.btnSetup.UseVisualStyleBackColor = false;
            this.btnSetup.Click += new System.EventHandler(this.btnSetup_Click);
            // 
            // comboInterval
            // 
            this.comboInterval.AutoCompleteCustomSource.AddRange(new string[] {
            "Day",
            "Month",
            "Year",
            "All"});
            this.comboInterval.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboInterval.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.comboInterval.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboInterval.ForeColor = System.Drawing.Color.Maroon;
            this.comboInterval.FormattingEnabled = true;
            this.comboInterval.Items.AddRange(new object[] {
            "Monthly",
            "Quarterly",
            "Weekly"});
            this.comboInterval.Location = new System.Drawing.Point(83, 108);
            this.comboInterval.Name = "comboInterval";
            this.comboInterval.Size = new System.Drawing.Size(139, 21);
            this.comboInterval.Sorted = true;
            this.comboInterval.TabIndex = 141;
            this.comboInterval.Text = "SELECT INTERVAL";
            // 
            // datePicker
            // 
            this.datePicker.CustomFormat = "yyyy-MM-dd";
            this.datePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datePicker.Location = new System.Drawing.Point(243, 108);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(112, 21);
            this.datePicker.TabIndex = 140;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Old English Text MT", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Maroon;
            this.label4.Location = new System.Drawing.Point(34, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(372, 34);
            this.label4.TabIndex = 139;
            this.label4.Text = "Setup Password Expiration";
            // 
            // tabColor
            // 
            this.tabColor.Controls.Add(this.panColor);
            this.tabColor.Location = new System.Drawing.Point(4, 24);
            this.tabColor.Name = "tabColor";
            this.tabColor.Padding = new System.Windows.Forms.Padding(3);
            this.tabColor.Size = new System.Drawing.Size(426, 257);
            this.tabColor.TabIndex = 0;
            this.tabColor.Text = "Colour";
            this.tabColor.UseVisualStyleBackColor = true;
            // 
            // panColor
            // 
            this.panColor.Controls.Add(this.label5);
            this.panColor.Controls.Add(this.btnForeColour);
            this.panColor.Controls.Add(this.btnBgColour);
            this.panColor.Location = new System.Drawing.Point(6, 6);
            this.panColor.Name = "panColor";
            this.panColor.Size = new System.Drawing.Size(417, 245);
            this.panColor.TabIndex = 25;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Old English Text MT", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Maroon;
            this.label5.Location = new System.Drawing.Point(4, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(409, 32);
            this.label5.TabIndex = 27;
            this.label5.Text = "Change Fore/Backgroud Colour";
            // 
            // btnForeColour
            // 
            this.btnForeColour.BackColor = System.Drawing.Color.Maroon;
            this.btnForeColour.ForeColor = System.Drawing.Color.White;
            this.btnForeColour.Location = new System.Drawing.Point(10, 157);
            this.btnForeColour.Name = "btnForeColour";
            this.btnForeColour.Size = new System.Drawing.Size(203, 28);
            this.btnForeColour.TabIndex = 26;
            this.btnForeColour.Text = "Change Fore Colour";
            this.btnForeColour.UseVisualStyleBackColor = false;
            // 
            // btnBgColour
            // 
            this.btnBgColour.BackColor = System.Drawing.Color.Maroon;
            this.btnBgColour.ForeColor = System.Drawing.Color.White;
            this.btnBgColour.Location = new System.Drawing.Point(10, 89);
            this.btnBgColour.Name = "btnBgColour";
            this.btnBgColour.Size = new System.Drawing.Size(203, 33);
            this.btnBgColour.TabIndex = 25;
            this.btnBgColour.Text = "Change Background Colour";
            this.btnBgColour.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Maroon;
            this.label1.Font = new System.Drawing.Font("Old English Text MT", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(155, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 35);
            this.label1.TabIndex = 23;
            this.label1.Text = "Settings";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(689, 368);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picTools)).EndInit();
            this.sSMessage.ResumeLayout(false);
            this.sSMessage.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabChangePass.ResumeLayout(false);
            this.tabChange.ResumeLayout(false);
            this.tabChange.PerformLayout();
            this.tabPassExpiration.ResumeLayout(false);
            this.panPassExpire.ResumeLayout(false);
            this.panPassExpire.PerformLayout();
            this.tabColor.ResumeLayout(false);
            this.panColor.ResumeLayout(false);
            this.panColor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.PictureBox picTools;
        private System.Windows.Forms.LinkLabel linkLogout;
        private System.Windows.Forms.LinkLabel linkHome;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnDepClear;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.StatusStrip sSMessage;
        private System.Windows.Forms.ToolStripStatusLabel tSSMessage;
        private System.Windows.Forms.TextBox txtRePass;
        private System.Windows.Forms.TextBox txtNewPass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCurrentPass;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCurrentPass;
        private System.Windows.Forms.Label lblChangePass;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabChangePass;
        private System.Windows.Forms.TabPage tabChange;
        private System.Windows.Forms.CheckBox checkShow;
        private System.Windows.Forms.TabPage tabColor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPassExpiration;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Panel panPassExpire;
        private System.Windows.Forms.CheckBox checkDeletePassAutoExpire;
        private System.Windows.Forms.Button btnSetup;
        private System.Windows.Forms.ComboBox comboInterval;
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panColor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnForeColour;
        private System.Windows.Forms.Button btnBgColour;
    }
}