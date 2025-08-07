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
    public partial class Delete : Form
    {
        private DatabaseLib db = new DatabaseLib();
        private DataTable tb;
        private ErrorProvider errorProvider = new ErrorProvider();
        private long accNumber;
        private DateTime dt;
        private string sub;
        public Delete()
        {
            InitializeComponent();
            dt = databaseDate();
        }
        public int validateDelete()
        {
            int flag = 0;
            if (txtDelete.Text == "")
            {
                txtDelete.Focus();
                errorProvider.SetError(txtDelete, "Please, enter the account number!");
                flag = 1;
            }
            return flag;
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
        private void deleteAccount(long accNumber)
        {
            db.connect();
            db.delete(accNumber);
            db.getConnection.Close();
            tb = new DataTable();
            db.getDataAdapter.Fill(tb);
            sSMessage.Visible = true;
            tSSMessage.Text = "Customer account deleted successfully.";
        }
        private void closedAccount(long accNumber)
        {
            try
            {
                db.connect();
                db.closedAccount(accNumber, dt);
                db.getConnection.Close();
                tb = new DataTable();
                db.getDataAdapter.Fill(tb);
                sSMessage.Visible = true;
                tSSMessage.Text = "Customer account has been closed.";
            }
            catch (SqlException sql)
            {
                MessageBox.Show(sql.Message);
            }
        }
        private void openAccount(long accNumber)
        {
            try
            {
                db.connect();
                db.getClosedAccount(accNumber);
                db.getConnection.Close();
                tb = new DataTable();
                db.getDataAdapter.Fill(tb);
                long closedAccNumber = (long)tb.Rows[0]["AccountNumber"];

                if (accNumber == closedAccNumber)
                {
                    db.connect();
                    db.openAccount(accNumber);
                    db.getConnection.Close();
                    tb = new DataTable();
                    db.getDataAdapter.Fill(tb);
                    sSMessage.Visible = true;
                    tSSMessage.Text = "Customer account has been reopened.";
                }

            }
            catch (IndexOutOfRangeException idx)
            {
                MessageBox.Show("Account was never closed", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (validateDelete() == 0)
            {
                accNumber = long.Parse(txtDelete.Text);

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
                            try
                            {
                                db.connect();
                                db.balanceUpdate(accNumber);
                                db.getConnection.Close();
                                tb = new DataTable();
                                db.getDataAdapter.Fill(tb);
                                long accNumber2 = (long)tb.Rows[0]["AccountNumber"];
                                long balance = (long)tb.Rows[0]["Balance"];
                                if (accNumber == accNumber2)
                                {
                                    if (btnDelete.Text.Equals("Delete"))
                                    {
                                        if (MessageBox.Show("Are you sure you want to Delete this account?", "Delete Confirmation",
                                          MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                        {
                                            deleteAccount(accNumber);
                                        }
                                    }
                                    else if (btnDelete.Text.Equals("Open"))
                                    {
                                        openAccount(accNumber);
                                    }
                                    else
                                    {
                                        if (balance > 0)
                                        {
                                            MessageBox.Show("Sorry! Can't close this account, customer still have some money in the account.",
                                                "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                        else
                                        {
                                            try
                                            {
                                                db.connect();
                                                db.getClosedAccount(accNumber);
                                                db.getConnection.Close();
                                                tb = new DataTable();
                                                db.getDataAdapter.Fill(tb);
                                                long closedAccNumber = (long)tb.Rows[0]["AccountNumber"];

                                                if (accNumber == closedAccNumber)
                                                {
                                                    sSMessage.Visible = true;
                                                    tSSMessage.Text = "Account is already closed";
                                                }
                                            }
                                            catch (IndexOutOfRangeException idx)
                                            {
                                                if (MessageBox.Show("Are you sure you want to close this account?", "Close Account Confirmation",
                                                  MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                                {
                                                    closedAccount(accNumber);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            catch (IndexOutOfRangeException ex)
                            {
                                sSMessage.Visible = true;
                                tSSMessage.Text = "Invalid account number!";
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
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtDelete.Text = "";
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
        private void radClose_CheckedChanged(object sender, EventArgs e)
        {
            btnDelete.Text = "Close";
        }
        private void radDelete_CheckedChanged(object sender, EventArgs e)
        {
            btnDelete.Text = "Delete";
        }
        private void radOpenAccount_CheckedChanged(object sender, EventArgs e)
        {
            btnDelete.Text = "Open";
        }
    }
}
