namespace SoftlightMF
{
    partial class Expenditure
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
            this.comboItem = new System.Windows.Forms.ComboBox();
            this.radDate = new System.Windows.Forms.RadioButton();
            this.radItem = new System.Windows.Forms.RadioButton();
            this.radLogExpenditure = new System.Windows.Forms.RadioButton();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.linkHome = new System.Windows.Forms.LinkLabel();
            this.linkLogout = new System.Windows.Forms.LinkLabel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.comboInterval = new System.Windows.Forms.ComboBox();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.panAdmin = new System.Windows.Forms.Panel();
            this.txtItem = new System.Windows.Forms.TextBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panExpense = new System.Windows.Forms.Panel();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtBenefactor = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTimeLogExpenditure = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.radRegisterItem = new System.Windows.Forms.RadioButton();
            this.panGridView = new System.Windows.Forms.Panel();
            this.expenditureViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.btnSearch = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.panNavigate = new System.Windows.Forms.Panel();
            this.txtBeneficiary = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.panAdmin.SuspendLayout();
            this.panExpense.SuspendLayout();
            this.panGridView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.panNavigate.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboItem
            // 
            this.comboItem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboItem.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboItem.ForeColor = System.Drawing.Color.Maroon;
            this.comboItem.FormattingEnabled = true;
            this.comboItem.Location = new System.Drawing.Point(12, 70);
            this.comboItem.Name = "comboItem";
            this.comboItem.Size = new System.Drawing.Size(119, 21);
            this.comboItem.Sorted = true;
            this.comboItem.TabIndex = 135;
            this.comboItem.Text = "SELECT ITEM";
            this.comboItem.Visible = false;
            // 
            // radDate
            // 
            this.radDate.AutoSize = true;
            this.radDate.BackColor = System.Drawing.Color.White;
            this.radDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radDate.ForeColor = System.Drawing.Color.Maroon;
            this.radDate.Location = new System.Drawing.Point(378, 43);
            this.radDate.Name = "radDate";
            this.radDate.Size = new System.Drawing.Size(120, 19);
            this.radDate.TabIndex = 136;
            this.radDate.Text = "Search by date";
            this.radDate.UseVisualStyleBackColor = false;
            this.radDate.CheckedChanged += new System.EventHandler(this.radDate_CheckedChanged);
            // 
            // radItem
            // 
            this.radItem.AutoSize = true;
            this.radItem.BackColor = System.Drawing.Color.White;
            this.radItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radItem.ForeColor = System.Drawing.Color.Maroon;
            this.radItem.Location = new System.Drawing.Point(257, 43);
            this.radItem.Name = "radItem";
            this.radItem.Size = new System.Drawing.Size(120, 19);
            this.radItem.TabIndex = 137;
            this.radItem.Text = "Search by Item";
            this.radItem.UseVisualStyleBackColor = false;
            this.radItem.CheckedChanged += new System.EventHandler(this.radItem_CheckedChanged);
            // 
            // radLogExpenditure
            // 
            this.radLogExpenditure.AutoSize = true;
            this.radLogExpenditure.BackColor = System.Drawing.Color.White;
            this.radLogExpenditure.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLogExpenditure.ForeColor = System.Drawing.Color.Maroon;
            this.radLogExpenditure.Location = new System.Drawing.Point(12, 43);
            this.radLogExpenditure.Name = "radLogExpenditure";
            this.radLogExpenditure.Size = new System.Drawing.Size(130, 19);
            this.radLogExpenditure.TabIndex = 138;
            this.radLogExpenditure.Text = "Log Expenditure";
            this.radLogExpenditure.UseVisualStyleBackColor = false;
            this.radLogExpenditure.CheckedChanged += new System.EventHandler(this.radLogExpenditure_CheckedChanged);
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.BackColor = System.Drawing.Color.Maroon;
            this.linkLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel2.LinkColor = System.Drawing.Color.White;
            this.linkLabel2.Location = new System.Drawing.Point(49, 6);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(11, 15);
            this.linkLabel2.TabIndex = 141;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "/";
            // 
            // linkHome
            // 
            this.linkHome.AutoSize = true;
            this.linkHome.BackColor = System.Drawing.Color.Maroon;
            this.linkHome.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkHome.LinkColor = System.Drawing.Color.White;
            this.linkHome.Location = new System.Drawing.Point(8, 6);
            this.linkHome.Name = "linkHome";
            this.linkHome.Size = new System.Drawing.Size(45, 15);
            this.linkHome.TabIndex = 142;
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
            this.linkLogout.Location = new System.Drawing.Point(55, 6);
            this.linkLogout.Name = "linkLogout";
            this.linkLogout.Size = new System.Drawing.Size(51, 15);
            this.linkLogout.TabIndex = 143;
            this.linkLogout.TabStop = true;
            this.linkLogout.Text = "Logout";
            this.linkLogout.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLogout_LinkClicked);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Maroon;
            this.lblTitle.Font = new System.Drawing.Font("Old English Text MT", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(335, 3);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(150, 32);
            this.lblTitle.TabIndex = 140;
            this.lblTitle.Text = "Expenditure";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Maroon;
            this.button1.Location = new System.Drawing.Point(-3, -2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(820, 41);
            this.button1.TabIndex = 139;
            this.button1.UseVisualStyleBackColor = false;
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
            "All",
            "Day",
            "Month",
            "Year"});
            this.comboInterval.Location = new System.Drawing.Point(137, 70);
            this.comboInterval.Name = "comboInterval";
            this.comboInterval.Size = new System.Drawing.Size(139, 21);
            this.comboInterval.Sorted = true;
            this.comboInterval.TabIndex = 135;
            this.comboInterval.Text = "SELECT INTERVAL";
            this.comboInterval.Visible = false;
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.CalendarForeColor = System.Drawing.Color.Maroon;
            this.dateTimePicker.CalendarTitleForeColor = System.Drawing.Color.Maroon;
            this.dateTimePicker.CustomFormat = "yyyy-MM-dd";
            this.dateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker.Location = new System.Drawing.Point(282, 71);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(90, 20);
            this.dateTimePicker.TabIndex = 144;
            this.dateTimePicker.Visible = false;
            // 
            // panAdmin
            // 
            this.panAdmin.Controls.Add(this.txtItem);
            this.panAdmin.Controls.Add(this.btnRegister);
            this.panAdmin.Controls.Add(this.label2);
            this.panAdmin.Controls.Add(this.label9);
            this.panAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panAdmin.ForeColor = System.Drawing.Color.Maroon;
            this.panAdmin.Location = new System.Drawing.Point(280, 97);
            this.panAdmin.Name = "panAdmin";
            this.panAdmin.Size = new System.Drawing.Size(221, 61);
            this.panAdmin.TabIndex = 145;
            this.panAdmin.Visible = false;
            // 
            // txtItem
            // 
            this.txtItem.Location = new System.Drawing.Point(50, 7);
            this.txtItem.Name = "txtItem";
            this.txtItem.Size = new System.Drawing.Size(142, 21);
            this.txtItem.TabIndex = 149;
            // 
            // btnRegister
            // 
            this.btnRegister.BackColor = System.Drawing.Color.Maroon;
            this.btnRegister.ForeColor = System.Drawing.Color.White;
            this.btnRegister.Location = new System.Drawing.Point(117, 31);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(75, 26);
            this.btnRegister.TabIndex = 151;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = false;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 15);
            this.label2.TabIndex = 146;
            this.label2.Text = "Item:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(207, 7);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(13, 15);
            this.label9.TabIndex = 146;
            this.label9.Text = "*";
            // 
            // panExpense
            // 
            this.panExpense.Controls.Add(this.txtAmount);
            this.panExpense.Controls.Add(this.txtDescription);
            this.panExpense.Controls.Add(this.txtBeneficiary);
            this.panExpense.Controls.Add(this.txtBenefactor);
            this.panExpense.Controls.Add(this.label8);
            this.panExpense.Controls.Add(this.label7);
            this.panExpense.Controls.Add(this.label6);
            this.panExpense.Controls.Add(this.btnSubmit);
            this.panExpense.Controls.Add(this.label4);
            this.panExpense.Controls.Add(this.label10);
            this.panExpense.Controls.Add(this.label5);
            this.panExpense.Controls.Add(this.dateTimeLogExpenditure);
            this.panExpense.Controls.Add(this.label3);
            this.panExpense.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panExpense.ForeColor = System.Drawing.Color.Maroon;
            this.panExpense.Location = new System.Drawing.Point(12, 101);
            this.panExpense.Name = "panExpense";
            this.panExpense.Size = new System.Drawing.Size(262, 145);
            this.panExpense.TabIndex = 0;
            this.panExpense.Visible = false;
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(101, 88);
            this.txtAmount.Multiline = true;
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(129, 22);
            this.txtAmount.TabIndex = 146;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(83, 60);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(147, 22);
            this.txtDescription.TabIndex = 147;
            // 
            // txtBenefactor
            // 
            this.txtBenefactor.Location = new System.Drawing.Point(83, 7);
            this.txtBenefactor.Multiline = true;
            this.txtBenefactor.Name = "txtBenefactor";
            this.txtBenefactor.Size = new System.Drawing.Size(147, 21);
            this.txtBenefactor.TabIndex = 148;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(242, 61);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(13, 15);
            this.label8.TabIndex = 146;
            this.label8.Text = "*";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(242, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(13, 15);
            this.label7.TabIndex = 146;
            this.label7.Text = "*";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(242, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 15);
            this.label6.TabIndex = 146;
            this.label6.Text = "*";
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.Maroon;
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.Location = new System.Drawing.Point(135, 115);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(96, 26);
            this.btnSubmit.TabIndex = 150;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 15);
            this.label4.TabIndex = 148;
            this.label4.Text = "Amount:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(2, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 15);
            this.label5.TabIndex = 149;
            this.label5.Text = "Beneficiary:";
            // 
            // dateTimeLogExpenditure
            // 
            this.dateTimeLogExpenditure.CalendarForeColor = System.Drawing.Color.Maroon;
            this.dateTimeLogExpenditure.CalendarTitleForeColor = System.Drawing.Color.Maroon;
            this.dateTimeLogExpenditure.CustomFormat = "yyyy-MM-dd";
            this.dateTimeLogExpenditure.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimeLogExpenditure.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeLogExpenditure.Location = new System.Drawing.Point(39, 117);
            this.dateTimeLogExpenditure.Name = "dateTimeLogExpenditure";
            this.dateTimeLogExpenditure.Size = new System.Drawing.Size(90, 20);
            this.dateTimeLogExpenditure.TabIndex = 144;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 15);
            this.label3.TabIndex = 147;
            this.label3.Text = "Description:";
            // 
            // radRegisterItem
            // 
            this.radRegisterItem.AutoSize = true;
            this.radRegisterItem.BackColor = System.Drawing.Color.White;
            this.radRegisterItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radRegisterItem.ForeColor = System.Drawing.Color.Maroon;
            this.radRegisterItem.Location = new System.Drawing.Point(143, 43);
            this.radRegisterItem.Name = "radRegisterItem";
            this.radRegisterItem.Size = new System.Drawing.Size(111, 19);
            this.radRegisterItem.TabIndex = 137;
            this.radRegisterItem.Text = "Register Item";
            this.radRegisterItem.UseVisualStyleBackColor = false;
            this.radRegisterItem.CheckedChanged += new System.EventHandler(this.radRegisterItem_CheckedChanged);
            // 
            // panGridView
            // 
            this.panGridView.Controls.Add(this.expenditureViewer);
            this.panGridView.Location = new System.Drawing.Point(12, 246);
            this.panGridView.Name = "panGridView";
            this.panGridView.Size = new System.Drawing.Size(805, 261);
            this.panGridView.TabIndex = 146;
            this.panGridView.Visible = false;
            // 
            // expenditureViewer
            // 
            this.expenditureViewer.ActiveViewIndex = -1;
            this.expenditureViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.expenditureViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.expenditureViewer.Location = new System.Drawing.Point(3, 3);
            this.expenditureViewer.Name = "expenditureViewer";
            this.expenditureViewer.Size = new System.Drawing.Size(798, 255);
            this.expenditureViewer.TabIndex = 154;
            this.expenditureViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Maroon;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(378, 70);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(81, 23);
            this.btnSearch.TabIndex = 150;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Visible = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // panNavigate
            // 
            this.panNavigate.BackColor = System.Drawing.Color.Maroon;
            this.panNavigate.Controls.Add(this.linkLogout);
            this.panNavigate.Controls.Add(this.linkHome);
            this.panNavigate.Controls.Add(this.linkLabel2);
            this.panNavigate.Location = new System.Drawing.Point(700, 9);
            this.panNavigate.Name = "panNavigate";
            this.panNavigate.Size = new System.Drawing.Size(111, 25);
            this.panNavigate.TabIndex = 151;
            // 
            // txtBeneficiary
            // 
            this.txtBeneficiary.Location = new System.Drawing.Point(83, 33);
            this.txtBeneficiary.Multiline = true;
            this.txtBeneficiary.Name = "txtBeneficiary";
            this.txtBeneficiary.Size = new System.Drawing.Size(147, 22);
            this.txtBeneficiary.TabIndex = 148;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(4, 7);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 15);
            this.label10.TabIndex = 149;
            this.label10.Text = "Benefactor:";
            // 
            // Expenditure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(818, 510);
            this.Controls.Add(this.panNavigate);
            this.Controls.Add(this.panGridView);
            this.Controls.Add(this.panExpense);
            this.Controls.Add(this.panAdmin);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.radDate);
            this.Controls.Add(this.radRegisterItem);
            this.Controls.Add(this.radItem);
            this.Controls.Add(this.radLogExpenditure);
            this.Controls.Add(this.comboInterval);
            this.Controls.Add(this.comboItem);
            this.MaximizeBox = false;
            this.Name = "Expenditure";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Expenditure";
            this.panAdmin.ResumeLayout(false);
            this.panAdmin.PerformLayout();
            this.panExpense.ResumeLayout(false);
            this.panExpense.PerformLayout();
            this.panGridView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.panNavigate.ResumeLayout(false);
            this.panNavigate.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboItem;
        private System.Windows.Forms.RadioButton radDate;
        private System.Windows.Forms.RadioButton radItem;
        private System.Windows.Forms.RadioButton radLogExpenditure;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.LinkLabel linkHome;
        private System.Windows.Forms.LinkLabel linkLogout;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboInterval;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Panel panAdmin;
        private System.Windows.Forms.Panel panExpense;
        private System.Windows.Forms.TextBox txtItem;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtBenefactor;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimeLogExpenditure;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton radRegisterItem;
        private System.Windows.Forms.Panel panGridView;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer expenditureViewer;
        private System.Windows.Forms.Panel panNavigate;
        private System.Windows.Forms.TextBox txtBeneficiary;
        private System.Windows.Forms.Label label10;
    }
}