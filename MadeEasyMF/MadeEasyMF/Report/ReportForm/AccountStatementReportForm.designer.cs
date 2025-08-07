namespace SoftlightMF.Report.ReportForm
{
    partial class AccountStatementReportForm
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
            this.accountStatementViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // accountStatementViewer
            // 
            this.accountStatementViewer.ActiveViewIndex = -1;
            this.accountStatementViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.accountStatementViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.accountStatementViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.accountStatementViewer.Location = new System.Drawing.Point(0, 0);
            this.accountStatementViewer.Name = "accountStatementViewer";
            this.accountStatementViewer.Size = new System.Drawing.Size(925, 552);
            this.accountStatementViewer.TabIndex = 0;
            this.accountStatementViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // AccountStatementReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(925, 552);
            this.Controls.Add(this.accountStatementViewer);
            this.MaximizeBox = false;
            this.Name = "AccountStatementReportForm";
            this.Text = "Account Statement Report";
            this.Load += new System.EventHandler(this.AccountStatementReportForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer accountStatementViewer;
    }
}