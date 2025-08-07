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
    public partial class Settings : Form
    {
        DatabaseLib db = new DatabaseLib();
        DataTable tb;
        ExposeProperties cl = new ExposeProperties();
        private string forgotPassword, sub, date;
        int interval;
        
        public Settings()
        {
            InitializeComponent();
        }
        private void linkHome_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Home().Show();
            Hide();
        }

        private void linkLogout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login log = new Login();
            ExposeProperties exp = new ExposeProperties();
            log.logFile(exp.getUser, "Offline");
            new Login().Show();
            Hide();
        }
        private void changePassword()
        {
            try
            {
                string currentPass, newPass, rePass, pass, empID;
                currentPass = txtCurrentPass.Text;
                newPass = txtNewPass.Text;
                rePass = txtRePass.Text;

                db.connect();
                db.passChange(ExposeProperties.TransactionTypeStatus);
                db.getConnection.Close();
                tb = new DataTable();
                db.getDataAdapter.Fill(tb);
                pass = tb.Rows[0]["Password"].ToString();
                empID = tb.Rows[0]["EmployeeID"].ToString();

                if (currentPass == pass)
                {
                    if (rePass == newPass)
                    {
                        db.connect();
                        db.updatePass(empID, newPass, ExposeProperties.UserLogin);
                        db.getConnection.Close();
                        tb = new DataTable();
                        db.getDataAdapter.Fill(tb);

                        int status = (int)tb.Rows[0]["Status"];

                        if (status == 0)
                        {
                            MessageBox.Show("Password changed successfully", "Info",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Password could not be changed!", "Info",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        sSMessage.Visible = true;
                        tSSMessage.Text = "Re-enter password did not match!";
                    }
                }
                else
                {
                    sSMessage.Visible = true;
                    tSSMessage.Text = "Your current password is incorrect!";
                }
            }
            catch (IndexOutOfRangeException idx)
            {
                sSMessage.Visible = true;
                tSSMessage.Text = "Your password is incorrect!";
            }
        }
        private void forgotPassoword()
        {
            panPassExpire.Enabled = false;
            panColor.Enabled = false;
            string newPass, rePass;
            newPass = txtNewPass.Text;
            rePass = txtRePass.Text;
            if (rePass == newPass)
            {
                db.connect();
                db.updatePass(ExposeProperties.EmpID, newPass, ExposeProperties.Username);
                db.getConnection.Close();
                tb = new DataTable();
                db.getDataAdapter.Fill(tb);

                int status = (int)tb.Rows[0]["Status"];

                if (status == 0)
                {
                    MessageBox.Show("Password changed successfully", "Info",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Password could not be changed!", "Info",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                linkHome.Visible = false;
            }
            else
            {
                sSMessage.Visible = true;
                tSSMessage.Text = "Re-enter password did not match!";
            }
        }
        private void btnChange_Click(object sender, EventArgs e)
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
                        if (forgotPassword.Equals("forgotPassword"))
                        {
                            forgotPassoword();
                        }
                        else
                        {
                            changePassword();
                        }
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
        private void btnDepClear_Click(object sender, EventArgs e)
        {
            txtCurrentPass.Text = "";
            txtNewPass.Text = "";
            txtRePass.Text = "";
            sSMessage.Visible = false;
            tSSMessage.Text = "";
        }
        private void checkShow_CheckedChanged(object sender, EventArgs e)
        {
            txtCurrentPass.PasswordChar = '\0';
            if (checkShow.Checked == false)
            {
                txtCurrentPass.PasswordChar = '*';
            }
        }
        private void Settings_Load(object sender, EventArgs e)
        {
            panPassExpire.Enabled = true;
            panColor.Enabled = true;
            forgotPassword = ExposeProperties.UserLogin;
            if(forgotPassword.Equals("forgotPassword"))
            {
                lblCurrentPass.Visible = false;
                txtCurrentPass.Visible = false;
                panPassExpire.Enabled = false;
                panColor.Enabled = false;
            }
        }
        private int validatePasswordAutoExpire()
        {
            int flag = 0;
            if(comboInterval.Text.Equals("SELECT INTERVAL"))
            {
                comboInterval.Focus();
                errorProvider.SetError(comboInterval, "Please select the interval!");
                flag = 1;
            }
            return flag;
        }
        private int getInterval()
        {
            string interval = null;
            int intervalNumber = 0;
            DateTime sysDate;
            interval = comboInterval.SelectedItem.ToString();
            if(interval.Equals("Weekly"))
            {
                intervalNumber = 7;
            }
            else if (interval.Equals("Monthly"))
            {
                intervalNumber = 31;
            }
            else 
            {
                intervalNumber = 92;
            }
            return intervalNumber;
        }
        private void setupPasswordAutoExpire()
        {
            date = datePicker.Value.AddDays(getInterval()).ToShortDateString();
            db.connect();
            db.setupPassAutoExpire(cl.getUser, date, getInterval());
            db.getConnection.Close();
            tb = new DataTable();
            db.getDataAdapter.Fill(tb);
            int status = (int)tb.Rows[0]["Success"];

            if(status == 0)
            {
                MessageBox.Show("Password auto-expire setup successfully", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                errorProvider.Clear();
            }
            else
            {
                MessageBox.Show("Password auto-expire could not be setup!", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                errorProvider.Clear();
            }
        }
        private void deletePasswordAutoExpire()
        {
            db.connect();
            db.deletePassAutoExpire(ExposeProperties.Username);
            db.getConnection.Close();
            tb = new DataTable();
            db.getDataAdapter.Fill(tb);
            int status = (int)tb.Rows[0]["Status"];

            if (status == 0)
            {
                MessageBox.Show("Password auto-expire deleted successfully", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Password auto-expire could not be deleted!", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void checkDeletePassAutoExpire_CheckedChanged(object sender, EventArgs e)
        {
            btnSetup.Text = "Delete";
            if(checkDeletePassAutoExpire.Checked == false)
            {
                btnSetup.Text = "Setup";
            }
        }
        private void btnSetup_Click(object sender, EventArgs e)
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
                        if (btnSetup.Text.Equals("Setup"))
                        {
                            if (validatePasswordAutoExpire() == 0)
                            {
                                setupPasswordAutoExpire();
                            }
                        }
                        else
                        {
                            if (MessageBox.Show("Are you sure you want to delete the password auto-expire?", "Delete",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                deletePasswordAutoExpire();
                            }
                        }
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
