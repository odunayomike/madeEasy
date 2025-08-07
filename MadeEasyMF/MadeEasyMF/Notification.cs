using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.ReportSource;
using CrystalDecisions.CrystalReports.Engine;
using DatabaseLibrary;

namespace SoftlightMF
{
    public partial class Notification : Form
    {
        private ExposeProperties cl = new ExposeProperties();
        private DatabaseLib db = new DatabaseLib();
        private DataTable tb;
        private TextObject reportTitle;
        private string notificationTitle, content;
        private DateTime dateTime;
        public Notification()
        {
            InitializeComponent();
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Login().Show();
        }

        private void homeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AccountStatement accState = new AccountStatement();
            accState.MdiParent = this;
            accState.Show();
        }

        private void customerRegToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerRegistration cust = new CustomerRegistration();
            cust.MdiParent = this;
            cust.Show();
        }

        private void banksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AccountStatement accState = new AccountStatement();
            accState.MdiParent = this;
            accState.Show();
        }

        private void custToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerRegistration cust = new CustomerRegistration();
            cust.MdiParent = this;
            cust.Show();
        }
        private void getNotificationTitle()
        {
            db.connect();
            db.getNotificationTitle();
            db.getConnection.Close();
            tb = new DataTable();
            db.getDataAdapter.Fill(tb);

            foreach (DataRow dr in tb.Rows)
            {
                comboTitle.Items.Add(dr["Title"].ToString());
            }
        }
        private int validateReadNotification()
        {
            int flag = 0;
            if(comboTitle.Text.Equals("Select Notification Title"))
            {
                comboTitle.Focus();
                errorProvider.SetError(comboTitle, "Please select the notification title");
                flag = 1;
            }
            return flag;
        }
        private void readNotification()
        {
            if (validateReadNotification() == 0)
            {
                notificationTitle = comboTitle.SelectedItem.ToString();
                db.connect();
                db.readNotification(notificationTitle, cl.getUser);
                db.getConnection.Close();
                tb = new DataTable();
                db.getDataAdapter.Fill(tb);
                notificationTitle = tb.Rows[0]["Title"].ToString();
                content = tb.Rows[0]["Content"].ToString();
                dateTime = DateTime.Parse(tb.Rows[0]["DateTime"].ToString());

                string date = dateTime.ToShortDateString();
                string time = dateTime.ToShortTimeString();
                lblDateTime.Text = date + " " + time;

                Report.CrystalReport.NotificationReport notification = new Report.CrystalReport.NotificationReport();
                notification.Database.Tables["Notification"].SetDataSource(tb);
                reportTitle = (TextObject)notification.ReportDefinition.ReportObjects["title"];
                reportTitle.Text = notificationTitle.ToUpper();
                 
                accountTypeViewer.Visible = true;
                accountTypeViewer.ReportSource = null;
                accountTypeViewer.ReportSource = notification;
            }
        }
        private void comboTitle_SelectedIndexChanged(object sender, EventArgs e)
        {
            readNotification();
            if(!lblDateTime.Text.Equals("Date Time"))
            {
                lblDateTime.Visible = true;
                this.StartPosition = FormStartPosition.CenterScreen;
                this.Size = new Size(915, 738);
            }
        }
        private void Notification_Load(object sender, EventArgs e)
        {
            getNotificationTitle();
        }
        private void linkHome_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Home().Show();
            Hide();
        }
        private void linkLogout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Login().Show();
            Hide();
        }
    }
}
