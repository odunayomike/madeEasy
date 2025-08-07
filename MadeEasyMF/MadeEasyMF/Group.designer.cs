namespace SoftlightMF
{
    partial class Group
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
            this.comboGroupName = new System.Windows.Forms.ComboBox();
            this.linkLogout = new System.Windows.Forms.LinkLabel();
            this.linkHome = new System.Windows.Forms.LinkLabel();
            this.label15 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tSSMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.comboEditDelete = new System.Windows.Forms.ComboBox();
            this.sSMessage = new System.Windows.Forms.StatusStrip();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.richTxtLocation = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtGroupName = new System.Windows.Forms.TextBox();
            this.txtLeaderName = new System.Windows.Forms.TextBox();
            this.txtSecretaryName = new System.Windows.Forms.TextBox();
            this.pan = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.sSMessage.SuspendLayout();
            this.pan.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // comboGroupName
            // 
            this.comboGroupName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboGroupName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboGroupName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboGroupName.ForeColor = System.Drawing.Color.Maroon;
            this.comboGroupName.FormattingEnabled = true;
            this.comboGroupName.Location = new System.Drawing.Point(176, 43);
            this.comboGroupName.Name = "comboGroupName";
            this.comboGroupName.Size = new System.Drawing.Size(214, 24);
            this.comboGroupName.TabIndex = 132;
            this.comboGroupName.Text = "Select Group Name";
            this.comboGroupName.Visible = false;
            this.comboGroupName.Click += new System.EventHandler(this.comboGroupName_SelectedIndexChanged);
            // 
            // linkLogout
            // 
            this.linkLogout.AutoSize = true;
            this.linkLogout.BackColor = System.Drawing.Color.Maroon;
            this.linkLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLogout.LinkColor = System.Drawing.Color.White;
            this.linkLogout.Location = new System.Drawing.Point(411, 16);
            this.linkLogout.Name = "linkLogout";
            this.linkLogout.Size = new System.Drawing.Size(51, 15);
            this.linkLogout.TabIndex = 130;
            this.linkLogout.TabStop = true;
            this.linkLogout.Text = "Logout";
            this.linkLogout.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLogout_LinkClicked);
            // 
            // linkHome
            // 
            this.linkHome.AutoSize = true;
            this.linkHome.BackColor = System.Drawing.Color.Maroon;
            this.linkHome.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkHome.ForeColor = System.Drawing.Color.White;
            this.linkHome.LinkColor = System.Drawing.Color.White;
            this.linkHome.Location = new System.Drawing.Point(363, 16);
            this.linkHome.Name = "linkHome";
            this.linkHome.Size = new System.Drawing.Size(45, 15);
            this.linkHome.TabIndex = 129;
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
            this.label15.Location = new System.Drawing.Point(404, 17);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(11, 15);
            this.label15.TabIndex = 128;
            this.label15.Text = "/";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Maroon;
            this.button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.button1.Font = new System.Drawing.Font("Old English Text MT", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(474, 39);
            this.button1.TabIndex = 127;
            this.button1.Text = "Group Creation";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // tSSMessage
            // 
            this.tSSMessage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.tSSMessage.ForeColor = System.Drawing.Color.Red;
            this.tSSMessage.Name = "tSSMessage";
            this.tSSMessage.Size = new System.Drawing.Size(127, 17);
            this.tSSMessage.Text = "toolStripStatusLabel1";
            // 
            // comboEditDelete
            // 
            this.comboEditDelete.AutoCompleteCustomSource.AddRange(new string[] {
            "Edit Details",
            "Register Details",
            "Delete Details"});
            this.comboEditDelete.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboEditDelete.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.comboEditDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboEditDelete.ForeColor = System.Drawing.Color.Maroon;
            this.comboEditDelete.FormattingEnabled = true;
            this.comboEditDelete.Items.AddRange(new object[] {
            "Edit Details",
            "Register Details",
            "Delete Details"});
            this.comboEditDelete.Location = new System.Drawing.Point(42, 43);
            this.comboEditDelete.Name = "comboEditDelete";
            this.comboEditDelete.Size = new System.Drawing.Size(121, 24);
            this.comboEditDelete.TabIndex = 133;
            this.comboEditDelete.Text = "Select Option";
            this.comboEditDelete.SelectedIndexChanged += new System.EventHandler(this.comboEditDelete_SelectedIndexChanged);
            this.comboEditDelete.Click += new System.EventHandler(this.comboEditDelete_SelectedIndexChanged);
            // 
            // sSMessage
            // 
            this.sSMessage.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSSMessage});
            this.sSMessage.Location = new System.Drawing.Point(0, 279);
            this.sSMessage.Name = "sSMessage";
            this.sSMessage.Size = new System.Drawing.Size(474, 22);
            this.sSMessage.TabIndex = 126;
            this.sSMessage.Text = "statusStrip1";
            this.sSMessage.Visible = false;
            // 
            // btnCreate
            // 
            this.btnCreate.BackColor = System.Drawing.Color.Maroon;
            this.btnCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreate.ForeColor = System.Drawing.Color.White;
            this.btnCreate.Location = new System.Drawing.Point(127, 168);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(86, 26);
            this.btnCreate.TabIndex = 132;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = false;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Maroon;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(230, 168);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(83, 26);
            this.btnClear.TabIndex = 133;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Maroon;
            this.label2.Location = new System.Drawing.Point(34, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 16);
            this.label2.TabIndex = 140;
            this.label2.Text = "Leader\'s Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Maroon;
            this.label3.Location = new System.Drawing.Point(16, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 16);
            this.label3.TabIndex = 141;
            this.label3.Text = "Secretary\'s Name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Maroon;
            this.label4.Location = new System.Drawing.Point(81, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 16);
            this.label4.TabIndex = 139;
            this.label4.Text = "Location:";
            // 
            // richTxtLocation
            // 
            this.richTxtLocation.Location = new System.Drawing.Point(164, 116);
            this.richTxtLocation.Name = "richTxtLocation";
            this.richTxtLocation.Size = new System.Drawing.Size(215, 45);
            this.richTxtLocation.TabIndex = 132;
            this.richTxtLocation.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Maroon;
            this.label5.Location = new System.Drawing.Point(53, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 16);
            this.label5.TabIndex = 138;
            this.label5.Text = "Group Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(395, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 16);
            this.label1.TabIndex = 137;
            this.label1.Text = "*";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Maroon;
            this.label6.Location = new System.Drawing.Point(395, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 16);
            this.label6.TabIndex = 136;
            this.label6.Text = "*";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Maroon;
            this.label7.Location = new System.Drawing.Point(395, 82);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(14, 16);
            this.label7.TabIndex = 135;
            this.label7.Text = "*";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Maroon;
            this.label8.Location = new System.Drawing.Point(395, 113);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(14, 16);
            this.label8.TabIndex = 134;
            this.label8.Text = "*";
            // 
            // txtGroupName
            // 
            this.txtGroupName.Location = new System.Drawing.Point(165, 18);
            this.txtGroupName.Name = "txtGroupName";
            this.txtGroupName.Size = new System.Drawing.Size(214, 20);
            this.txtGroupName.TabIndex = 143;
            // 
            // txtLeaderName
            // 
            this.txtLeaderName.Location = new System.Drawing.Point(165, 50);
            this.txtLeaderName.Name = "txtLeaderName";
            this.txtLeaderName.Size = new System.Drawing.Size(214, 20);
            this.txtLeaderName.TabIndex = 144;
            // 
            // txtSecretaryName
            // 
            this.txtSecretaryName.Location = new System.Drawing.Point(165, 83);
            this.txtSecretaryName.Name = "txtSecretaryName";
            this.txtSecretaryName.Size = new System.Drawing.Size(214, 20);
            this.txtSecretaryName.TabIndex = 133;
            // 
            // pan
            // 
            this.pan.Controls.Add(this.txtSecretaryName);
            this.pan.Controls.Add(this.txtLeaderName);
            this.pan.Controls.Add(this.txtGroupName);
            this.pan.Controls.Add(this.label8);
            this.pan.Controls.Add(this.label7);
            this.pan.Controls.Add(this.label6);
            this.pan.Controls.Add(this.label1);
            this.pan.Controls.Add(this.label5);
            this.pan.Controls.Add(this.richTxtLocation);
            this.pan.Controls.Add(this.label4);
            this.pan.Controls.Add(this.label3);
            this.pan.Controls.Add(this.label2);
            this.pan.Controls.Add(this.btnClear);
            this.pan.Controls.Add(this.btnCreate);
            this.pan.Location = new System.Drawing.Point(12, 73);
            this.pan.Name = "pan";
            this.pan.Size = new System.Drawing.Size(450, 199);
            this.pan.TabIndex = 134;
            this.pan.Visible = false;
            // 
            // Group
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(474, 301);
            this.Controls.Add(this.pan);
            this.Controls.Add(this.comboGroupName);
            this.Controls.Add(this.linkLogout);
            this.Controls.Add(this.linkHome);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboEditDelete);
            this.Controls.Add(this.sSMessage);
            this.Name = "Group";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Group";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.sSMessage.ResumeLayout(false);
            this.sSMessage.PerformLayout();
            this.pan.ResumeLayout(false);
            this.pan.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.ComboBox comboGroupName;
        private System.Windows.Forms.LinkLabel linkLogout;
        private System.Windows.Forms.LinkLabel linkHome;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboEditDelete;
        private System.Windows.Forms.StatusStrip sSMessage;
        private System.Windows.Forms.ToolStripStatusLabel tSSMessage;
        private System.Windows.Forms.Panel pan;
        private System.Windows.Forms.TextBox txtSecretaryName;
        private System.Windows.Forms.TextBox txtLeaderName;
        private System.Windows.Forms.TextBox txtGroupName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox richTxtLocation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnCreate;
    }
}