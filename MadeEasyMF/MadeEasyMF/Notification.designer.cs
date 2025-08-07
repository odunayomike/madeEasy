namespace SoftlightMF
{
    partial class Notification
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
            this.button1 = new System.Windows.Forms.Button();
            this.linkLogout = new System.Windows.Forms.LinkLabel();
            this.linkHome = new System.Windows.Forms.LinkLabel();
            this.label15 = new System.Windows.Forms.Label();
            this.accountTypeViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.comboTitle = new System.Windows.Forms.ComboBox();
            this.comboSubject = new System.Windows.Forms.Label();
            this.lblDateTime = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Maroon;
            this.button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.button1.Font = new System.Drawing.Font("Old English Text MT", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(899, 42);
            this.button1.TabIndex = 135;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // linkLogout
            // 
            this.linkLogout.AutoSize = true;
            this.linkLogout.BackColor = System.Drawing.Color.Maroon;
            this.linkLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLogout.LinkColor = System.Drawing.Color.White;
            this.linkLogout.Location = new System.Drawing.Point(828, 16);
            this.linkLogout.Name = "linkLogout";
            this.linkLogout.Size = new System.Drawing.Size(51, 15);
            this.linkLogout.TabIndex = 138;
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
            this.linkHome.Location = new System.Drawing.Point(780, 16);
            this.linkHome.Name = "linkHome";
            this.linkHome.Size = new System.Drawing.Size(45, 15);
            this.linkHome.TabIndex = 137;
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
            this.label15.Location = new System.Drawing.Point(821, 17);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(11, 15);
            this.label15.TabIndex = 136;
            this.label15.Text = "/";
            // 
            // accountTypeViewer
            // 
            this.accountTypeViewer.ActiveViewIndex = -1;
            this.accountTypeViewer.AutoScroll = true;
            this.accountTypeViewer.AutoSize = true;
            this.accountTypeViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.accountTypeViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.accountTypeViewer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accountTypeViewer.ForeColor = System.Drawing.Color.Maroon;
            this.accountTypeViewer.Location = new System.Drawing.Point(4, 84);
            this.accountTypeViewer.Name = "accountTypeViewer";
            this.accountTypeViewer.Size = new System.Drawing.Size(894, 612);
            this.accountTypeViewer.TabIndex = 142;
            this.accountTypeViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.accountTypeViewer.Visible = false;
            // 
            // comboTitle
            // 
            this.comboTitle.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboTitle.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboTitle.ForeColor = System.Drawing.Color.Maroon;
            this.comboTitle.FormattingEnabled = true;
            this.comboTitle.Location = new System.Drawing.Point(54, 54);
            this.comboTitle.Name = "comboTitle";
            this.comboTitle.Size = new System.Drawing.Size(303, 24);
            this.comboTitle.TabIndex = 143;
            this.comboTitle.Text = "Select Notification Title";
            this.comboTitle.SelectedIndexChanged += new System.EventHandler(this.comboTitle_SelectedIndexChanged);
            // 
            // comboSubject
            // 
            this.comboSubject.AutoSize = true;
            this.comboSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboSubject.ForeColor = System.Drawing.Color.Maroon;
            this.comboSubject.Location = new System.Drawing.Point(12, 54);
            this.comboSubject.Name = "comboSubject";
            this.comboSubject.Size = new System.Drawing.Size(40, 17);
            this.comboSubject.TabIndex = 144;
            this.comboSubject.Text = "Title";
            // 
            // lblDateTime
            // 
            this.lblDateTime.AutoSize = true;
            this.lblDateTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateTime.ForeColor = System.Drawing.Color.Maroon;
            this.lblDateTime.Location = new System.Drawing.Point(363, 54);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(82, 17);
            this.lblDateTime.TabIndex = 144;
            this.lblDateTime.Text = "Date Time";
            this.lblDateTime.Visible = false;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // Notification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(899, 83);
            this.Controls.Add(this.lblDateTime);
            this.Controls.Add(this.comboSubject);
            this.Controls.Add(this.comboTitle);
            this.Controls.Add(this.linkLogout);
            this.Controls.Add(this.linkHome);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.accountTypeViewer);
            this.Controls.Add(this.button1);
            this.DoubleBuffered = true;
            this.Name = "Notification";
            this.Text = "Notification";
            this.Load += new System.EventHandler(this.Notification_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.LinkLabel linkLogout;
        private System.Windows.Forms.LinkLabel linkHome;
        private System.Windows.Forms.Label label15;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer accountTypeViewer;
        private System.Windows.Forms.ComboBox comboTitle;
        private System.Windows.Forms.Label comboSubject;
        private System.Windows.Forms.Label lblDateTime;
        private System.Windows.Forms.ErrorProvider errorProvider;


    }
}