namespace SoftlightMF
{
    partial class Support
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
            this.lblDate = new System.Windows.Forms.Label();
            this.panSupportMessage = new System.Windows.Forms.Panel();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.richTxtSupportMessage = new System.Windows.Forms.RichTextBox();
            this.lblTime = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.panResponseStatus = new System.Windows.Forms.Panel();
            this.txtTicketNumber = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblResponseStatus = new System.Windows.Forms.Label();
            this.btnCheck = new System.Windows.Forms.Button();
            this.radSupport = new System.Windows.Forms.RadioButton();
            this.radResponse = new System.Windows.Forms.RadioButton();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.linkLogout = new System.Windows.Forms.LinkLabel();
            this.linkHome = new System.Windows.Forms.LinkLabel();
            this.label15 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.sSMessage = new System.Windows.Forms.StatusStrip();
            this.tSSMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.panSupportMessage.SuspendLayout();
            this.panResponseStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.sSMessage.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.Color.Maroon;
            this.lblDate.Location = new System.Drawing.Point(273, 6);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(41, 16);
            this.lblDate.TabIndex = 94;
            this.lblDate.Text = "Date";
            this.lblDate.Visible = false;
            // 
            // panSupportMessage
            // 
            this.panSupportMessage.Controls.Add(this.txtSubject);
            this.panSupportMessage.Controls.Add(this.richTxtSupportMessage);
            this.panSupportMessage.Controls.Add(this.lblTime);
            this.panSupportMessage.Controls.Add(this.lblDate);
            this.panSupportMessage.Controls.Add(this.label2);
            this.panSupportMessage.Controls.Add(this.btnSend);
            this.panSupportMessage.Location = new System.Drawing.Point(55, 127);
            this.panSupportMessage.Name = "panSupportMessage";
            this.panSupportMessage.Size = new System.Drawing.Size(660, 270);
            this.panSupportMessage.TabIndex = 105;
            this.panSupportMessage.Visible = false;
            // 
            // txtSubject
            // 
            this.txtSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubject.Location = new System.Drawing.Point(72, 5);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(195, 21);
            this.txtSubject.TabIndex = 86;
            // 
            // richTxtSupportMessage
            // 
            this.richTxtSupportMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTxtSupportMessage.Location = new System.Drawing.Point(11, 31);
            this.richTxtSupportMessage.Name = "richTxtSupportMessage";
            this.richTxtSupportMessage.Size = new System.Drawing.Size(626, 191);
            this.richTxtSupportMessage.TabIndex = 95;
            this.richTxtSupportMessage.Text = "";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.Color.Maroon;
            this.lblTime.Location = new System.Drawing.Point(356, 5);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(43, 16);
            this.lblTime.TabIndex = 94;
            this.lblTime.Text = "Time";
            this.lblTime.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Maroon;
            this.label2.Location = new System.Drawing.Point(8, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 16);
            this.label2.TabIndex = 94;
            this.label2.Text = "Subject";
            // 
            // btnSend
            // 
            this.btnSend.BackColor = System.Drawing.Color.Maroon;
            this.btnSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSend.ForeColor = System.Drawing.Color.White;
            this.btnSend.Location = new System.Drawing.Point(551, 228);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(86, 26);
            this.btnSend.TabIndex = 82;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // panResponseStatus
            // 
            this.panResponseStatus.Controls.Add(this.txtTicketNumber);
            this.panResponseStatus.Controls.Add(this.label5);
            this.panResponseStatus.Controls.Add(this.lblResponseStatus);
            this.panResponseStatus.Controls.Add(this.btnCheck);
            this.panResponseStatus.Location = new System.Drawing.Point(55, 90);
            this.panResponseStatus.Name = "panResponseStatus";
            this.panResponseStatus.Size = new System.Drawing.Size(660, 33);
            this.panResponseStatus.TabIndex = 106;
            this.panResponseStatus.Visible = false;
            // 
            // txtTicketNumber
            // 
            this.txtTicketNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTicketNumber.Location = new System.Drawing.Point(119, 7);
            this.txtTicketNumber.Name = "txtTicketNumber";
            this.txtTicketNumber.Size = new System.Drawing.Size(151, 21);
            this.txtTicketNumber.TabIndex = 86;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Maroon;
            this.label5.Location = new System.Drawing.Point(11, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 16);
            this.label5.TabIndex = 84;
            this.label5.Text = "Ticket Number";
            // 
            // lblResponseStatus
            // 
            this.lblResponseStatus.AutoSize = true;
            this.lblResponseStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResponseStatus.ForeColor = System.Drawing.Color.Maroon;
            this.lblResponseStatus.Location = new System.Drawing.Point(365, 6);
            this.lblResponseStatus.Name = "lblResponseStatus";
            this.lblResponseStatus.Size = new System.Drawing.Size(126, 16);
            this.lblResponseStatus.TabIndex = 94;
            this.lblResponseStatus.Text = "Response Status";
            this.lblResponseStatus.Visible = false;
            // 
            // btnCheck
            // 
            this.btnCheck.BackColor = System.Drawing.Color.Maroon;
            this.btnCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheck.ForeColor = System.Drawing.Color.White;
            this.btnCheck.Location = new System.Drawing.Point(276, 5);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(83, 24);
            this.btnCheck.TabIndex = 83;
            this.btnCheck.Text = "Check";
            this.btnCheck.UseVisualStyleBackColor = false;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // radSupport
            // 
            this.radSupport.AutoSize = true;
            this.radSupport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radSupport.ForeColor = System.Drawing.Color.Maroon;
            this.radSupport.Location = new System.Drawing.Point(69, 62);
            this.radSupport.Name = "radSupport";
            this.radSupport.Size = new System.Drawing.Size(75, 19);
            this.radSupport.TabIndex = 97;
            this.radSupport.TabStop = true;
            this.radSupport.Text = "Support";
            this.radSupport.UseVisualStyleBackColor = true;
            this.radSupport.CheckedChanged += new System.EventHandler(this.radSupport_CheckedChanged);
            // 
            // radResponse
            // 
            this.radResponse.AutoSize = true;
            this.radResponse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radResponse.ForeColor = System.Drawing.Color.Maroon;
            this.radResponse.Location = new System.Drawing.Point(150, 62);
            this.radResponse.Name = "radResponse";
            this.radResponse.Size = new System.Drawing.Size(89, 19);
            this.radResponse.TabIndex = 98;
            this.radResponse.TabStop = true;
            this.radResponse.Text = "Response";
            this.radResponse.UseVisualStyleBackColor = true;
            this.radResponse.CheckedChanged += new System.EventHandler(this.radResponse_CheckedChanged);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // linkLogout
            // 
            this.linkLogout.AutoSize = true;
            this.linkLogout.BackColor = System.Drawing.Color.Maroon;
            this.linkLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLogout.LinkColor = System.Drawing.Color.White;
            this.linkLogout.Location = new System.Drawing.Point(700, 17);
            this.linkLogout.Name = "linkLogout";
            this.linkLogout.Size = new System.Drawing.Size(51, 15);
            this.linkLogout.TabIndex = 104;
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
            this.linkHome.Location = new System.Drawing.Point(652, 17);
            this.linkHome.Name = "linkHome";
            this.linkHome.Size = new System.Drawing.Size(45, 15);
            this.linkHome.TabIndex = 103;
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
            this.label15.Location = new System.Drawing.Point(693, 18);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(11, 15);
            this.label15.TabIndex = 102;
            this.label15.Text = "/";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Maroon;
            this.label1.Font = new System.Drawing.Font("Old English Text MT", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(346, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 28);
            this.label1.TabIndex = 100;
            this.label1.Text = "Support";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Maroon;
            this.button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(780, 39);
            this.button1.TabIndex = 101;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // sSMessage
            // 
            this.sSMessage.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSSMessage});
            this.sSMessage.Location = new System.Drawing.Point(0, 415);
            this.sSMessage.Name = "sSMessage";
            this.sSMessage.Size = new System.Drawing.Size(780, 22);
            this.sSMessage.TabIndex = 99;
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
            // Support
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(780, 437);
            this.Controls.Add(this.panSupportMessage);
            this.Controls.Add(this.panResponseStatus);
            this.Controls.Add(this.radSupport);
            this.Controls.Add(this.radResponse);
            this.Controls.Add(this.linkLogout);
            this.Controls.Add(this.linkHome);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.sSMessage);
            this.Name = "Support";
            this.Text = "Support";
            this.panSupportMessage.ResumeLayout(false);
            this.panSupportMessage.PerformLayout();
            this.panResponseStatus.ResumeLayout(false);
            this.panResponseStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.sSMessage.ResumeLayout(false);
            this.sSMessage.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Panel panSupportMessage;
        private System.Windows.Forms.TextBox txtSubject;
        private System.Windows.Forms.RichTextBox richTxtSupportMessage;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Panel panResponseStatus;
        private System.Windows.Forms.TextBox txtTicketNumber;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblResponseStatus;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.RadioButton radSupport;
        private System.Windows.Forms.RadioButton radResponse;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.LinkLabel linkLogout;
        private System.Windows.Forms.LinkLabel linkHome;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.StatusStrip sSMessage;
        private System.Windows.Forms.ToolStripStatusLabel tSSMessage;
    }
}