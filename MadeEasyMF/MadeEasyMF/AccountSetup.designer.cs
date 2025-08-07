namespace SoftlightMF
{
    partial class AccountSetup
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
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtMiddleName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.btnDepClear = new System.Windows.Forms.Button();
            this.btnReg = new System.Windows.Forms.Button();
            this.groupGender = new System.Windows.Forms.GroupBox();
            this.radFemale = new System.Windows.Forms.RadioButton();
            this.radMale = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.radDeleteEmployee = new System.Windows.Forms.RadioButton();
            this.radEditEmployee = new System.Windows.Forms.RadioButton();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.button1 = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.sSMessage = new System.Windows.Forms.StatusStrip();
            this.tSSMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.regEdit = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.linkLogout = new System.Windows.Forms.LinkLabel();
            this.linkHome = new System.Windows.Forms.LinkLabel();
            this.button2 = new System.Windows.Forms.Button();
            this.panAccountType = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.txtAccountType = new System.Windows.Forms.TextBox();
            this.comboAccountType = new System.Windows.Forms.ComboBox();
            this.radEdit = new System.Windows.Forms.RadioButton();
            this.radDelete = new System.Windows.Forms.RadioButton();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnRegister = new System.Windows.Forms.Button();
            this.panComboAcctType = new System.Windows.Forms.Panel();
            this.radRegister = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupGender.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.sSMessage.SuspendLayout();
            this.panAccountType.SuspendLayout();
            this.panComboAcctType.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtFirstName
            // 
            this.txtFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFirstName.Location = new System.Drawing.Point(40, 4);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(197, 21);
            this.txtFirstName.TabIndex = 4;
            // 
            // txtMiddleName
            // 
            this.txtMiddleName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMiddleName.Location = new System.Drawing.Point(26, 33);
            this.txtMiddleName.Name = "txtMiddleName";
            this.txtMiddleName.Size = new System.Drawing.Size(197, 21);
            this.txtMiddleName.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(375, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Account Type ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(465, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "Amount";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.btnDepClear);
            this.splitContainer2.Panel2.Controls.Add(this.btnReg);
            this.splitContainer2.Panel2.Controls.Add(this.groupGender);
            this.splitContainer2.Panel2.Controls.Add(this.txtFirstName);
            this.splitContainer2.Panel2.Controls.Add(this.txtMiddleName);
            this.splitContainer2.Size = new System.Drawing.Size(670, 202);
            this.splitContainer2.SplitterDistance = 358;
            this.splitContainer2.TabIndex = 0;
            // 
            // btnDepClear
            // 
            this.btnDepClear.BackColor = System.Drawing.Color.Maroon;
            this.btnDepClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDepClear.ForeColor = System.Drawing.Color.White;
            this.btnDepClear.Location = new System.Drawing.Point(139, 152);
            this.btnDepClear.Name = "btnDepClear";
            this.btnDepClear.Size = new System.Drawing.Size(75, 27);
            this.btnDepClear.TabIndex = 5;
            this.btnDepClear.Text = "Clear";
            this.btnDepClear.UseVisualStyleBackColor = false;
            // 
            // btnReg
            // 
            this.btnReg.BackColor = System.Drawing.Color.Maroon;
            this.btnReg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReg.ForeColor = System.Drawing.Color.White;
            this.btnReg.Location = new System.Drawing.Point(40, 152);
            this.btnReg.Name = "btnReg";
            this.btnReg.Size = new System.Drawing.Size(86, 27);
            this.btnReg.TabIndex = 4;
            this.btnReg.Text = "Register";
            this.btnReg.UseVisualStyleBackColor = false;
            // 
            // groupGender
            // 
            this.groupGender.Controls.Add(this.radFemale);
            this.groupGender.Controls.Add(this.radMale);
            this.groupGender.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupGender.ForeColor = System.Drawing.Color.Maroon;
            this.groupGender.Location = new System.Drawing.Point(26, 64);
            this.groupGender.Name = "groupGender";
            this.groupGender.Size = new System.Drawing.Size(207, 76);
            this.groupGender.TabIndex = 1;
            this.groupGender.TabStop = false;
            this.groupGender.Text = "Gender";
            // 
            // radFemale
            // 
            this.radFemale.AutoSize = true;
            this.radFemale.Location = new System.Drawing.Point(9, 51);
            this.radFemale.Name = "radFemale";
            this.radFemale.Size = new System.Drawing.Size(73, 19);
            this.radFemale.TabIndex = 1;
            this.radFemale.TabStop = true;
            this.radFemale.Text = "Female";
            this.radFemale.UseVisualStyleBackColor = true;
            // 
            // radMale
            // 
            this.radMale.AutoSize = true;
            this.radMale.Location = new System.Drawing.Point(9, 25);
            this.radMale.Name = "radMale";
            this.radMale.Size = new System.Drawing.Size(57, 19);
            this.radMale.TabIndex = 0;
            this.radMale.TabStop = true;
            this.radMale.Text = "Male";
            this.radMale.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Maroon;
            this.label8.Font = new System.Drawing.Font("Old English Text MT", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(244, 5);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(192, 33);
            this.label8.TabIndex = 41;
            this.label8.Text = "Account Setup";
            // 
            // radDeleteEmployee
            // 
            this.radDeleteEmployee.AutoSize = true;
            this.radDeleteEmployee.BackColor = System.Drawing.Color.White;
            this.radDeleteEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radDeleteEmployee.ForeColor = System.Drawing.Color.Maroon;
            this.radDeleteEmployee.Location = new System.Drawing.Point(142, 49);
            this.radDeleteEmployee.Name = "radDeleteEmployee";
            this.radDeleteEmployee.Size = new System.Drawing.Size(148, 21);
            this.radDeleteEmployee.TabIndex = 40;
            this.radDeleteEmployee.TabStop = true;
            this.radDeleteEmployee.Text = "Delete Employee";
            this.radDeleteEmployee.UseVisualStyleBackColor = false;
            // 
            // radEditEmployee
            // 
            this.radEditEmployee.AutoSize = true;
            this.radEditEmployee.BackColor = System.Drawing.Color.White;
            this.radEditEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radEditEmployee.ForeColor = System.Drawing.Color.Maroon;
            this.radEditEmployee.Location = new System.Drawing.Point(7, 49);
            this.radEditEmployee.Name = "radEditEmployee";
            this.radEditEmployee.Size = new System.Drawing.Size(129, 21);
            this.radEditEmployee.TabIndex = 40;
            this.radEditEmployee.TabStop = true;
            this.radEditEmployee.Text = "Edit Employee";
            this.radEditEmployee.UseVisualStyleBackColor = false;
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.BackColor = System.Drawing.Color.Maroon;
            this.linkLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel2.LinkColor = System.Drawing.Color.White;
            this.linkLabel2.Location = new System.Drawing.Point(594, 19);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(11, 15);
            this.linkLabel2.TabIndex = 1;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "/";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Maroon;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(660, 43);
            this.button1.TabIndex = 6;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // sSMessage
            // 
            this.sSMessage.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSSMessage});
            this.sSMessage.Location = new System.Drawing.Point(0, 256);
            this.sSMessage.Name = "sSMessage";
            this.sSMessage.Size = new System.Drawing.Size(538, 22);
            this.sSMessage.TabIndex = 28;
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
            // regEdit
            // 
            this.regEdit.AutoSize = true;
            this.regEdit.BackColor = System.Drawing.Color.Maroon;
            this.regEdit.Font = new System.Drawing.Font("Old English Text MT", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.regEdit.ForeColor = System.Drawing.Color.White;
            this.regEdit.Location = new System.Drawing.Point(171, 9);
            this.regEdit.Name = "regEdit";
            this.regEdit.Size = new System.Drawing.Size(189, 32);
            this.regEdit.TabIndex = 60;
            this.regEdit.Text = "Account Setup";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BackColor = System.Drawing.Color.Maroon;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.LinkColor = System.Drawing.Color.White;
            this.linkLabel1.Location = new System.Drawing.Point(462, 22);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(11, 15);
            this.linkLabel1.TabIndex = 58;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "/";
            // 
            // linkLogout
            // 
            this.linkLogout.AutoSize = true;
            this.linkLogout.BackColor = System.Drawing.Color.Maroon;
            this.linkLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLogout.LinkColor = System.Drawing.Color.White;
            this.linkLogout.Location = new System.Drawing.Point(469, 22);
            this.linkLogout.Name = "linkLogout";
            this.linkLogout.Size = new System.Drawing.Size(51, 15);
            this.linkLogout.TabIndex = 57;
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
            this.linkHome.Location = new System.Drawing.Point(421, 22);
            this.linkHome.Name = "linkHome";
            this.linkHome.Size = new System.Drawing.Size(45, 15);
            this.linkHome.TabIndex = 56;
            this.linkHome.TabStop = true;
            this.linkHome.Text = "Home";
            this.linkHome.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkHome_LinkClicked);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Maroon;
            this.button2.Dock = System.Windows.Forms.DockStyle.Top;
            this.button2.Location = new System.Drawing.Point(0, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(538, 46);
            this.button2.TabIndex = 59;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // panAccountType
            // 
            this.panAccountType.Controls.Add(this.label1);
            this.panAccountType.Controls.Add(this.label);
            this.panAccountType.Controls.Add(this.txtAmount);
            this.panAccountType.Controls.Add(this.txtAccountType);
            this.panAccountType.Location = new System.Drawing.Point(12, 96);
            this.panAccountType.Name = "panAccountType";
            this.panAccountType.Size = new System.Drawing.Size(509, 101);
            this.panAccountType.TabIndex = 112;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(80, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 17);
            this.label1.TabIndex = 105;
            this.label1.Text = "Amount";
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.ForeColor = System.Drawing.Color.Maroon;
            this.label.Location = new System.Drawing.Point(80, 17);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(107, 17);
            this.label.TabIndex = 106;
            this.label.Text = "Account Type";
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(217, 60);
            this.txtAmount.Multiline = true;
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(190, 26);
            this.txtAmount.TabIndex = 104;
            // 
            // txtAccountType
            // 
            this.txtAccountType.Location = new System.Drawing.Point(217, 17);
            this.txtAccountType.Multiline = true;
            this.txtAccountType.Name = "txtAccountType";
            this.txtAccountType.Size = new System.Drawing.Size(190, 27);
            this.txtAccountType.TabIndex = 103;
            // 
            // comboAccountType
            // 
            this.comboAccountType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboAccountType.ForeColor = System.Drawing.Color.Maroon;
            this.comboAccountType.FormattingEnabled = true;
            this.comboAccountType.Location = new System.Drawing.Point(4, 5);
            this.comboAccountType.Name = "comboAccountType";
            this.comboAccountType.Size = new System.Drawing.Size(150, 24);
            this.comboAccountType.TabIndex = 110;
            this.comboAccountType.SelectedIndexChanged += new System.EventHandler(this.comboAccountType_SelectedIndexChanged);
            // 
            // radEdit
            // 
            this.radEdit.AutoSize = true;
            this.radEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radEdit.ForeColor = System.Drawing.Color.Maroon;
            this.radEdit.Location = new System.Drawing.Point(96, 52);
            this.radEdit.Name = "radEdit";
            this.radEdit.Size = new System.Drawing.Size(59, 21);
            this.radEdit.TabIndex = 29;
            this.radEdit.TabStop = true;
            this.radEdit.Text = "Edit ";
            this.radEdit.UseVisualStyleBackColor = true;
            this.radEdit.CheckedChanged += new System.EventHandler(this.radEdit_CheckedChanged);
            // 
            // radDelete
            // 
            this.radDelete.AutoSize = true;
            this.radDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radDelete.ForeColor = System.Drawing.Color.Maroon;
            this.radDelete.Location = new System.Drawing.Point(12, 52);
            this.radDelete.Name = "radDelete";
            this.radDelete.Size = new System.Drawing.Size(78, 21);
            this.radDelete.TabIndex = 31;
            this.radDelete.TabStop = true;
            this.radDelete.Text = "Delete ";
            this.radDelete.UseVisualStyleBackColor = true;
            this.radDelete.CheckedChanged += new System.EventHandler(this.radDelete_CheckedChanged);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Maroon;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(269, 214);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 29);
            this.btnClear.TabIndex = 108;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnRegister
            // 
            this.btnRegister.BackColor = System.Drawing.Color.Maroon;
            this.btnRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegister.ForeColor = System.Drawing.Color.White;
            this.btnRegister.Location = new System.Drawing.Point(177, 214);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(86, 29);
            this.btnRegister.TabIndex = 107;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = false;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // panComboAcctType
            // 
            this.panComboAcctType.Controls.Add(this.comboAccountType);
            this.panComboAcctType.Location = new System.Drawing.Point(265, 52);
            this.panComboAcctType.Name = "panComboAcctType";
            this.panComboAcctType.Size = new System.Drawing.Size(166, 32);
            this.panComboAcctType.TabIndex = 113;
            this.panComboAcctType.Visible = false;
            // 
            // radRegister
            // 
            this.radRegister.AutoSize = true;
            this.radRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radRegister.ForeColor = System.Drawing.Color.Maroon;
            this.radRegister.Location = new System.Drawing.Point(161, 52);
            this.radRegister.Name = "radRegister";
            this.radRegister.Size = new System.Drawing.Size(87, 21);
            this.radRegister.TabIndex = 29;
            this.radRegister.TabStop = true;
            this.radRegister.Text = "Register";
            this.radRegister.UseVisualStyleBackColor = true;
            this.radRegister.CheckedChanged += new System.EventHandler(this.radRegister_CheckedChanged);
            // 
            // AccountSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(538, 278);
            this.Controls.Add(this.radDelete);
            this.Controls.Add(this.panComboAcctType);
            this.Controls.Add(this.panAccountType);
            this.Controls.Add(this.regEdit);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.radRegister);
            this.Controls.Add(this.radEdit);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.linkLogout);
            this.Controls.Add(this.linkHome);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.sSMessage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "AccountSetup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Account Setup";
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupGender.ResumeLayout(false);
            this.groupGender.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.sSMessage.ResumeLayout(false);
            this.sSMessage.PerformLayout();
            this.panAccountType.ResumeLayout(false);
            this.panAccountType.PerformLayout();
            this.panComboAcctType.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtMiddleName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button btnDepClear;
        private System.Windows.Forms.Button btnReg;
        private System.Windows.Forms.GroupBox groupGender;
        private System.Windows.Forms.RadioButton radFemale;
        private System.Windows.Forms.RadioButton radMale;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton radDeleteEmployee;
        private System.Windows.Forms.RadioButton radEditEmployee;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.StatusStrip sSMessage;
        private System.Windows.Forms.ToolStripStatusLabel tSSMessage;
        private System.Windows.Forms.Label regEdit;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.LinkLabel linkLogout;
        private System.Windows.Forms.LinkLabel linkHome;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox comboAccountType;
        private System.Windows.Forms.RadioButton radDelete;
        private System.Windows.Forms.Panel panAccountType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.RadioButton radEdit;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.TextBox txtAccountType;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Panel panComboAcctType;
        private System.Windows.Forms.RadioButton radRegister;
    }
}