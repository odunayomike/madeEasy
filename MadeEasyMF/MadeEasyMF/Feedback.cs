using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DatabaseLibrary;

namespace SoftlightMF
{
    public partial class Feedback : Form
    {
        private DatabaseLib db = new DatabaseLib();
        private DataTable tb;
        ExposeProperties user = new ExposeProperties();
        private string username, subject, feedback;
        public Feedback()
        {
            InitializeComponent();
            richNote.Text = "Your feedback is imperative to us; so we appreciate your feedbacks as it helps us to improve more on our software. " +
            "Please kindly drop your suggestion and or rate us on a scale of 1 to 10. Thank you.\n\n" +
            "For complaints or technical issues, please use the support page.";
        }
        private void feedbackMessage()
        {
            try
            {
                subject = txtSubject.Text;
                feedback = richFeedback.Text;
                username = user.getUser;
                db.connect();
                db.insertFeedback(ExposeProperties.ClientID, username, subject, feedback);
                db.getConnection.Close();
                tb = new DataTable();
                db.getDataAdapter.Fill(tb);
                sSMessage.Visible = true;
                tSSMessage.Text = "Feedback submitted successfully. Thank you.";
                txtSubject.Text = "";
                richFeedback.Text = "";
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private int validateFeedback()
        {
            int flag = 0;
            if (txtSubject.Text == "")
            {
                txtSubject.Focus();
                errorProvider.SetError(txtSubject, "Please enter the feedback subject");
                flag = 1;
            }
            if (richFeedback.Text == "")
            {
                richFeedback.Focus();
                errorProvider.SetError(richFeedback, "Please enter the feedback message");
                flag = 1;
            }
            return flag;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (validateFeedback() == 0)
            {
                db.connect();
                db.getSub(ExposeProperties.ClientID);
                db.getConnection.Close();
                DataTable sub = new DataTable();
                db.getDataAdapter.Fill(sub);
                string status = sub.Rows[0]["Status"].ToString();
                string maintenance = sub.Rows[0]["MaintenanceStatus"].ToString();

                db.connect();
                db.getWorkHourSubMessage(ExposeProperties.ClientID);
                db.getConnection.Close();
                DataTable workHourSubMsg = new DataTable();
                db.getDataAdapter.Fill(workHourSubMsg);
                int open = (int)workHourSubMsg.Rows[0]["OpenHour"];
                int close = (int)workHourSubMsg.Rows[0]["CloseHour"];
                string cloudMessage = workHourSubMsg.Rows[0]["CloudMessage"].ToString();
                string maintenanceMsg = workHourSubMsg.Rows[0]["MaintenanceMessage"].ToString();

                if (maintenance != "Expired")
                {
                    if (status != "Expired")
                    {
                        int hour = int.Parse(new Home().databaseDate().Hour.ToString());
                        int minute = int.Parse(new Home().databaseDate().Minute.ToString());
                        if (hour < open)
                        {
                            MessageBox.Show("Sorry, itsn't open hour yet", "Can't Connect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            new Login().Show();
                            Hide();
                        }
                        else if (hour >= close && minute >= 1)
                        {
                            MessageBox.Show("Sorry, work hour is over", "Can't Connect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            new Login().Show();
                            Hide();
                        }
                        else
                        {
                            feedbackMessage();
                        }
                    }
                    else
                    {
                        MessageBox.Show(cloudMessage, "Can't Connect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        new Login().Show();
                        Hide();
                    }
                }
                else
                {
                    MessageBox.Show(maintenanceMsg, "Can't Connect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    new Login().Show();
                    Hide();
                }
            }
        }

        private void linkHome_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Home().Show();
            Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Login().Show();
            Hide();
        }
    }
}
