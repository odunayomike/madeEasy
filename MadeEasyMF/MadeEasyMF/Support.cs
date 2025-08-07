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
    public partial class Support : Form
    {
        private DatabaseLib db = new DatabaseLib();
        private DataTable tb;
        ExposeProperties user = new ExposeProperties();
        private DateTime dt;
        private int ticketNumber, conpareTicketNumber;
        private string subject, supportMsg, username, supportStatus, day, hour, minute, second, ticketNo, date, time;
        public Support()
        {
            InitializeComponent();
            dt = databaseDate();
        }
        private DateTime databaseDate()
        {
            DateTime date = DateTime.Now;
            try
            {
                db.connect();
                db.dbDate();
                db.getConnection.Close();
                tb = new DataTable();
                db.getDataAdapter.Fill(tb);
                date = (DateTime)tb.Rows[0]["DbDate"];
            }
            catch (SqlException sql)
            {
                MessageBox.Show(sql.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return date;
        }
        private void radSupport_CheckedChanged(object sender, EventArgs e)
        {
            panSupportMessage.Visible = true;
            lblDate.Visible = false;
            lblTime.Visible = false;
            if (radSupport.Checked == false)
            {
                panSupportMessage.Visible = false;
            }
            if (btnSend.Visible == false)
            {
                txtSubject.Text = "";
                richTxtSupportMessage.Text = "";
            }
        }
        private void radResponse_CheckedChanged(object sender, EventArgs e)
        {
            panResponseStatus.Visible = true;
            if (radResponse.Checked == false)
            {
                panResponseStatus.Visible = false;
            }
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
        private int getTicketNumber()
        {
            ticketNo = null;
            day = dt.Day.ToString();
            hour = dt.Hour.ToString();
            minute = dt.Minute.ToString();
            second = dt.Second.ToString();
            ticketNo = minute + hour + second + day;
            ticketNumber = int.Parse(ticketNo);
            return ticketNumber;
        }
        private void supportMessage()
        {
            btnSend.Visible = true;
            panResponseStatus.Visible = false;
            try
            {
                ticketNumber = getTicketNumber();
                subject = txtSubject.Text;
                supportMsg = richTxtSupportMessage.Text;
                username = user.getUser;
                db.connect();
                db.insertSupport(ExposeProperties.ClientID, ticketNumber, username, subject, supportMsg);
                db.getConnection.Close();
                tb = new DataTable();
                db.getDataAdapter.Fill(tb);
                sSMessage.Visible = true;
                tSSMessage.Text = "Support message sent successfully. Your ticket number is " + ticketNumber;
                txtSubject.Text = "";
                richTxtSupportMessage.Text = "";
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void supportResponse()
        {
            sSMessage.Visible = false;
            btnSend.Visible = false;
            ticketNumber = int.Parse(txtTicketNumber.Text);
            try
            {
                DateTime dbDate, dbTime;
                db.connect();
                db.getSupportResponse(ticketNumber);
                db.getConnection.Close();
                tb = new DataTable();
                db.getDataAdapter.Fill(tb);
                subject = tb.Rows[0]["Subject"].ToString();
                supportStatus = tb.Rows[0]["Status"].ToString();

                panResponseStatus.Visible = true;
                panSupportMessage.Visible = true;
                lblDate.Visible = true;
                lblTime.Visible = true;
                txtSubject.Text = subject;
                lblResponseStatus.Visible = true;
                lblResponseStatus.Text = supportStatus;

                if (supportStatus != "Pending")
                {
                    supportMsg = tb.Rows[0]["Response"].ToString();
                    dbDate = DateTime.Parse(tb.Rows[0]["ResponseDate"].ToString());
                    dbTime = DateTime.Parse(tb.Rows[0]["ResponseTime"].ToString());
                    date = dbDate.ToShortDateString();
                    time = dbTime.ToShortTimeString();

                    richTxtSupportMessage.Text = supportMsg;
                    lblDate.Text = date;
                    lblTime.Text = time;
                }
                else
                {
                    supportMsg = tb.Rows[0]["Message"].ToString();
                    dbDate = DateTime.Parse(tb.Rows[0]["Date"].ToString());
                    dbTime = DateTime.Parse(tb.Rows[0]["Time"].ToString());
                    date = dbDate.ToShortDateString();
                    time = dbTime.ToShortTimeString();

                    richTxtSupportMessage.Text = supportMsg;
                    lblDate.Text = date;
                    lblTime.Text = time;
                }
            }
            catch (IndexOutOfRangeException e)
            {
                sSMessage.Visible = true;
                tSSMessage.Text = "Ticket number is invalid!";
            }
        }
        private int validateSupportMessage()
        {
            int flag = 0;
            if (txtSubject.Text == "")
            {
                txtSubject.Focus();
                errorProvider.SetError(txtSubject, "Please enter the support subject");
                flag = 1;
            }
            if (richTxtSupportMessage.Text == "")
            {
                richTxtSupportMessage.Focus();
                errorProvider.SetError(richTxtSupportMessage, "Please enter the support message");
                flag = 1;
            }
            return flag;
        }
        private int validateResponseMessage()
        {
            int flag = 0;
            if (txtTicketNumber.Text == "")
            {
                txtTicketNumber.Focus();
                errorProvider.SetError(txtTicketNumber, "Please enter the ticket number");
                flag = 1;
            }
            return flag;
        }
        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (validateResponseMessage() == 0)
            {
                db.connect();
                db.getSub(ExposeProperties.ClientID);
                db.getConnection.Close();
                DataTable subMsg = new DataTable();
                db.getDataAdapter.Fill(subMsg);
                string status = subMsg.Rows[0]["Status"].ToString();
                string maintenance = subMsg.Rows[0]["MaintenanceStatus"].ToString();

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
                            supportResponse();
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
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (validateSupportMessage() == 0)
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
                            supportMessage();
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
    }
}
