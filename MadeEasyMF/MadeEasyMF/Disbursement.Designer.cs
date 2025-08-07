namespace SoftlightMF
{
    partial class Disbursement
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
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.lblNames = new System.Windows.Forms.Label();
            this.pan = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPercent = new System.Windows.Forms.TextBox();
            this.radDaily = new System.Windows.Forms.RadioButton();
            this.radWeekly = new System.Windows.Forms.RadioButton();
            this.linkGuarantor = new System.Windows.Forms.LinkLabel();
            this.checkPercent = new System.Windows.Forms.CheckBox();
            this.checkGuarantor = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAccNumber = new System.Windows.Forms.TextBox();
            this.linkLogout = new System.Windows.Forms.LinkLabel();
            this.linkHome = new System.Windows.Forms.LinkLabel();
            this.label15 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.asterisksPrincipal = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupTermOfPay = new System.Windows.Forms.GroupBox();
            this.radMonthly = new System.Windows.Forms.RadioButton();
            this.txtPrincipal = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtDuration = new System.Windows.Forms.TextBox();
            this.btnExtend = new System.Windows.Forms.Button();
            this.btnDisburse = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblPrincipal = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.sSMessage = new System.Windows.Forms.StatusStrip();
            this.tSSMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.comboAccOff = new System.Windows.Forms.ComboBox();
            this.asteriskAccOfficer = new System.Windows.Forms.Label();
            this.lblAccOfficer = new System.Windows.Forms.Label();
            this.pan.SuspendLayout();
            this.groupTermOfPay.SuspendLayout();
            this.sSMessage.SuspendLayout();
            this.SuspendLayout();
            // 
            // datePicker
            // 
            this.datePicker.CustomFormat = "yyyy-MM-dd";
            this.datePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datePicker.Location = new System.Drawing.Point(436, 220);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(96, 20);
            this.datePicker.TabIndex = 114;
            // 
            // lblNames
            // 
            this.lblNames.AutoSize = true;
            this.lblNames.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNames.ForeColor = System.Drawing.Color.Maroon;
            this.lblNames.Location = new System.Drawing.Point(32, 44);
            this.lblNames.Name = "lblNames";
            this.lblNames.Size = new System.Drawing.Size(119, 16);
            this.lblNames.TabIndex = 113;
            this.lblNames.Text = "Customer name ";
            this.lblNames.UseMnemonic = false;
            this.lblNames.Visible = false;
            // 
            // pan
            // 
            this.pan.Controls.Add(this.label4);
            this.pan.Controls.Add(this.txtPercent);
            this.pan.Location = new System.Drawing.Point(29, 212);
            this.pan.Name = "pan";
            this.pan.Size = new System.Drawing.Size(273, 29);
            this.pan.TabIndex = 111;
            this.pan.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Maroon;
            this.label4.Location = new System.Drawing.Point(65, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 17);
            this.label4.TabIndex = 39;
            this.label4.Text = "Percent:";
            // 
            // txtPercent
            // 
            this.txtPercent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPercent.Location = new System.Drawing.Point(169, 5);
            this.txtPercent.Name = "txtPercent";
            this.txtPercent.Size = new System.Drawing.Size(100, 21);
            this.txtPercent.TabIndex = 45;
            // 
            // radDaily
            // 
            this.radDaily.AutoSize = true;
            this.radDaily.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radDaily.ForeColor = System.Drawing.Color.Maroon;
            this.radDaily.Location = new System.Drawing.Point(14, 20);
            this.radDaily.Name = "radDaily";
            this.radDaily.Size = new System.Drawing.Size(57, 19);
            this.radDaily.TabIndex = 29;
            this.radDaily.TabStop = true;
            this.radDaily.Text = "Daily";
            this.radDaily.UseVisualStyleBackColor = true;
            // 
            // radWeekly
            // 
            this.radWeekly.AutoSize = true;
            this.radWeekly.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radWeekly.ForeColor = System.Drawing.Color.Maroon;
            this.radWeekly.Location = new System.Drawing.Point(14, 42);
            this.radWeekly.Name = "radWeekly";
            this.radWeekly.Size = new System.Drawing.Size(70, 19);
            this.radWeekly.TabIndex = 30;
            this.radWeekly.TabStop = true;
            this.radWeekly.Text = "Weekly";
            this.radWeekly.UseVisualStyleBackColor = true;
            // 
            // linkGuarantor
            // 
            this.linkGuarantor.AutoSize = true;
            this.linkGuarantor.DisabledLinkColor = System.Drawing.Color.DimGray;
            this.linkGuarantor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkGuarantor.ForeColor = System.Drawing.Color.Black;
            this.linkGuarantor.LinkColor = System.Drawing.Color.Maroon;
            this.linkGuarantor.Location = new System.Drawing.Point(461, 44);
            this.linkGuarantor.Name = "linkGuarantor";
            this.linkGuarantor.Size = new System.Drawing.Size(112, 15);
            this.linkGuarantor.TabIndex = 115;
            this.linkGuarantor.TabStop = true;
            this.linkGuarantor.Text = "Check guarantor";
            this.linkGuarantor.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkGuarantor_LinkClicked);
            // 
            // checkPercent
            // 
            this.checkPercent.AutoSize = true;
            this.checkPercent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkPercent.ForeColor = System.Drawing.Color.Maroon;
            this.checkPercent.Location = new System.Drawing.Point(354, 218);
            this.checkPercent.Name = "checkPercent";
            this.checkPercent.Size = new System.Drawing.Size(80, 20);
            this.checkPercent.TabIndex = 110;
            this.checkPercent.Text = "Percent";
            this.checkPercent.UseVisualStyleBackColor = true;
            this.checkPercent.CheckedChanged += new System.EventHandler(this.checkPercent_CheckedChanged);
            // 
            // checkGuarantor
            // 
            this.checkGuarantor.AutoSize = true;
            this.checkGuarantor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkGuarantor.ForeColor = System.Drawing.Color.Maroon;
            this.checkGuarantor.Location = new System.Drawing.Point(67, 251);
            this.checkGuarantor.Name = "checkGuarantor";
            this.checkGuarantor.Size = new System.Drawing.Size(95, 20);
            this.checkGuarantor.TabIndex = 109;
            this.checkGuarantor.Text = "Guarantor";
            this.checkGuarantor.UseVisualStyleBackColor = true;
            this.checkGuarantor.CheckedChanged += new System.EventHandler(this.checkGuarantor_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Maroon;
            this.label6.Location = new System.Drawing.Point(309, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(18, 22);
            this.label6.TabIndex = 108;
            this.label6.Text = "*";
            // 
            // txtAccNumber
            // 
            this.txtAccNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccNumber.Location = new System.Drawing.Point(166, 76);
            this.txtAccNumber.Name = "txtAccNumber";
            this.txtAccNumber.Size = new System.Drawing.Size(132, 21);
            this.txtAccNumber.TabIndex = 107;
            this.txtAccNumber.TextChanged += new System.EventHandler(this.txtAccNumber_TextChanged);
            // 
            // linkLogout
            // 
            this.linkLogout.AutoSize = true;
            this.linkLogout.BackColor = System.Drawing.Color.Maroon;
            this.linkLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLogout.LinkColor = System.Drawing.Color.White;
            this.linkLogout.Location = new System.Drawing.Point(509, 12);
            this.linkLogout.Name = "linkLogout";
            this.linkLogout.Size = new System.Drawing.Size(51, 15);
            this.linkLogout.TabIndex = 105;
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
            this.linkHome.Location = new System.Drawing.Point(461, 12);
            this.linkHome.Name = "linkHome";
            this.linkHome.Size = new System.Drawing.Size(45, 15);
            this.linkHome.TabIndex = 104;
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
            this.label15.Location = new System.Drawing.Point(502, 13);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(11, 15);
            this.label15.TabIndex = 103;
            this.label15.Text = "/";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Maroon;
            this.label5.Location = new System.Drawing.Point(309, 149);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 22);
            this.label5.TabIndex = 102;
            this.label5.Text = "*";
            // 
            // asterisksPrincipal
            // 
            this.asterisksPrincipal.AutoSize = true;
            this.asterisksPrincipal.BackColor = System.Drawing.Color.White;
            this.asterisksPrincipal.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.asterisksPrincipal.ForeColor = System.Drawing.Color.Maroon;
            this.asterisksPrincipal.Location = new System.Drawing.Point(309, 113);
            this.asterisksPrincipal.Name = "asterisksPrincipal";
            this.asterisksPrincipal.Size = new System.Drawing.Size(18, 22);
            this.asterisksPrincipal.TabIndex = 101;
            this.asterisksPrincipal.Text = "*";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Maroon;
            this.label7.Location = new System.Drawing.Point(17, 74);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(132, 17);
            this.label7.TabIndex = 106;
            this.label7.Text = "Account Number:";
            // 
            // groupTermOfPay
            // 
            this.groupTermOfPay.Controls.Add(this.radDaily);
            this.groupTermOfPay.Controls.Add(this.radWeekly);
            this.groupTermOfPay.Controls.Add(this.radMonthly);
            this.groupTermOfPay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupTermOfPay.Location = new System.Drawing.Point(340, 76);
            this.groupTermOfPay.Name = "groupTermOfPay";
            this.groupTermOfPay.Size = new System.Drawing.Size(192, 93);
            this.groupTermOfPay.TabIndex = 100;
            this.groupTermOfPay.TabStop = false;
            this.groupTermOfPay.Text = "Terms of Payment";
            // 
            // radMonthly
            // 
            this.radMonthly.AutoSize = true;
            this.radMonthly.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radMonthly.ForeColor = System.Drawing.Color.Maroon;
            this.radMonthly.Location = new System.Drawing.Point(14, 63);
            this.radMonthly.Name = "radMonthly";
            this.radMonthly.Size = new System.Drawing.Size(75, 19);
            this.radMonthly.TabIndex = 31;
            this.radMonthly.TabStop = true;
            this.radMonthly.Text = "Monthly";
            this.radMonthly.UseVisualStyleBackColor = true;
            // 
            // txtPrincipal
            // 
            this.txtPrincipal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrincipal.Location = new System.Drawing.Point(166, 112);
            this.txtPrincipal.Name = "txtPrincipal";
            this.txtPrincipal.Size = new System.Drawing.Size(132, 21);
            this.txtPrincipal.TabIndex = 95;
            this.txtPrincipal.TextChanged += new System.EventHandler(this.txtPrincipal_TextChanged);
            this.txtPrincipal.MouseHover += new System.EventHandler(this.txtPrincipal_MouseHover);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Maroon;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(310, 247);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(87, 24);
            this.btnClear.TabIndex = 99;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // txtDuration
            // 
            this.txtDuration.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDuration.Location = new System.Drawing.Point(166, 147);
            this.txtDuration.Name = "txtDuration";
            this.txtDuration.Size = new System.Drawing.Size(132, 21);
            this.txtDuration.TabIndex = 96;
            this.txtDuration.TextChanged += new System.EventHandler(this.txtDuration_TextChanged);
            // 
            // btnExtend
            // 
            this.btnExtend.BackColor = System.Drawing.Color.Maroon;
            this.btnExtend.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExtend.ForeColor = System.Drawing.Color.White;
            this.btnExtend.Location = new System.Drawing.Point(408, 247);
            this.btnExtend.Name = "btnExtend";
            this.btnExtend.Size = new System.Drawing.Size(87, 24);
            this.btnExtend.TabIndex = 98;
            this.btnExtend.Text = "Extend";
            this.btnExtend.UseVisualStyleBackColor = false;
            this.btnExtend.Click += new System.EventHandler(this.btnExtend_Click);
            // 
            // btnDisburse
            // 
            this.btnDisburse.BackColor = System.Drawing.Color.Maroon;
            this.btnDisburse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDisburse.ForeColor = System.Drawing.Color.White;
            this.btnDisburse.Location = new System.Drawing.Point(192, 247);
            this.btnDisburse.Name = "btnDisburse";
            this.btnDisburse.Size = new System.Drawing.Size(87, 24);
            this.btnDisburse.TabIndex = 97;
            this.btnDisburse.Text = "Disburse";
            this.btnDisburse.UseVisualStyleBackColor = false;
            this.btnDisburse.Click += new System.EventHandler(this.btnDisburse_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Maroon;
            this.label3.Location = new System.Drawing.Point(72, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 17);
            this.label3.TabIndex = 90;
            this.label3.Text = "Duration:";
            // 
            // lblPrincipal
            // 
            this.lblPrincipal.AutoSize = true;
            this.lblPrincipal.BackColor = System.Drawing.Color.White;
            this.lblPrincipal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrincipal.ForeColor = System.Drawing.Color.Maroon;
            this.lblPrincipal.Location = new System.Drawing.Point(72, 110);
            this.lblPrincipal.Name = "lblPrincipal";
            this.lblPrincipal.Size = new System.Drawing.Size(76, 17);
            this.lblPrincipal.TabIndex = 91;
            this.lblPrincipal.Text = "Principal:";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Maroon;
            this.lblTitle.Font = new System.Drawing.Font("Old English Text MT", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(208, 3);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(209, 28);
            this.lblTitle.TabIndex = 92;
            this.lblTitle.Text = "Loan Disbursement";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Maroon;
            this.button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(584, 39);
            this.button1.TabIndex = 93;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // sSMessage
            // 
            this.sSMessage.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSSMessage});
            this.sSMessage.Location = new System.Drawing.Point(0, 279);
            this.sSMessage.Name = "sSMessage";
            this.sSMessage.Size = new System.Drawing.Size(584, 22);
            this.sSMessage.TabIndex = 94;
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
            // comboAccOff
            // 
            this.comboAccOff.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboAccOff.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboAccOff.FormattingEnabled = true;
            this.comboAccOff.Location = new System.Drawing.Point(166, 180);
            this.comboAccOff.Name = "comboAccOff";
            this.comboAccOff.Size = new System.Drawing.Size(132, 21);
            this.comboAccOff.TabIndex = 119;
            // 
            // asteriskAccOfficer
            // 
            this.asteriskAccOfficer.AutoSize = true;
            this.asteriskAccOfficer.BackColor = System.Drawing.Color.White;
            this.asteriskAccOfficer.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.asteriskAccOfficer.ForeColor = System.Drawing.Color.Maroon;
            this.asteriskAccOfficer.Location = new System.Drawing.Point(309, 178);
            this.asteriskAccOfficer.Name = "asteriskAccOfficer";
            this.asteriskAccOfficer.Size = new System.Drawing.Size(18, 22);
            this.asteriskAccOfficer.TabIndex = 117;
            this.asteriskAccOfficer.Text = "*";
            // 
            // lblAccOfficer
            // 
            this.lblAccOfficer.AutoSize = true;
            this.lblAccOfficer.BackColor = System.Drawing.Color.White;
            this.lblAccOfficer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccOfficer.ForeColor = System.Drawing.Color.Maroon;
            this.lblAccOfficer.Location = new System.Drawing.Point(23, 175);
            this.lblAccOfficer.Name = "lblAccOfficer";
            this.lblAccOfficer.Size = new System.Drawing.Size(125, 17);
            this.lblAccOfficer.TabIndex = 118;
            this.lblAccOfficer.Text = "Account Officer:";
            // 
            // Disbursement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(584, 301);
            this.Controls.Add(this.comboAccOff);
            this.Controls.Add(this.asteriskAccOfficer);
            this.Controls.Add(this.lblAccOfficer);
            this.Controls.Add(this.datePicker);
            this.Controls.Add(this.lblNames);
            this.Controls.Add(this.pan);
            this.Controls.Add(this.linkGuarantor);
            this.Controls.Add(this.checkPercent);
            this.Controls.Add(this.checkGuarantor);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtAccNumber);
            this.Controls.Add(this.linkLogout);
            this.Controls.Add(this.linkHome);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.asterisksPrincipal);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupTermOfPay);
            this.Controls.Add(this.txtPrincipal);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.txtDuration);
            this.Controls.Add(this.btnExtend);
            this.Controls.Add(this.btnDisburse);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblPrincipal);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.sSMessage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Disbursement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Disbursement";
            this.Load += new System.EventHandler(this.Disbursement_Load);
            this.pan.ResumeLayout(false);
            this.pan.PerformLayout();
            this.groupTermOfPay.ResumeLayout(false);
            this.groupTermOfPay.PerformLayout();
            this.sSMessage.ResumeLayout(false);
            this.sSMessage.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.Label lblNames;
        private System.Windows.Forms.Panel pan;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPercent;
        private System.Windows.Forms.RadioButton radDaily;
        private System.Windows.Forms.RadioButton radWeekly;
        public System.Windows.Forms.LinkLabel linkGuarantor;
        private System.Windows.Forms.CheckBox checkPercent;
        private System.Windows.Forms.CheckBox checkGuarantor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAccNumber;
        private System.Windows.Forms.LinkLabel linkLogout;
        private System.Windows.Forms.LinkLabel linkHome;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label asterisksPrincipal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupTermOfPay;
        private System.Windows.Forms.RadioButton radMonthly;
        private System.Windows.Forms.TextBox txtPrincipal;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox txtDuration;
        private System.Windows.Forms.Button btnExtend;
        private System.Windows.Forms.Button btnDisburse;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblPrincipal;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.StatusStrip sSMessage;
        private System.Windows.Forms.ToolStripStatusLabel tSSMessage;
        private System.Windows.Forms.ComboBox comboAccOff;
        private System.Windows.Forms.Label asteriskAccOfficer;
        private System.Windows.Forms.Label lblAccOfficer;
    }
}