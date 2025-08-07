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
    public partial class BalanceLoan : Form
    {
        DatabaseLib db = new DatabaseLib();
        DataSet dataSet;
        long accNumber;
        string sub;
        public BalanceLoan()
        {
            InitializeComponent();
        }
        private int validateBalanceLoan()
        {
            int flag = 0;
            if (txtAccNo.Text == "")
            {
                txtAccNo.Focus();
                errorProvider.SetError(txtAccNo, "Please, enter the code!");
                flag = 1;
            }
            return flag;
        }
        private void btnBalance_Click(object sender, EventArgs e)
        {
            if (validateBalanceLoan() == 0)
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
                            try
                            {
                                db.connect();
                                accNumber = Convert.ToInt64(txtAccNo.Text);
                                db.loanChecker(accNumber);
                                db.getConnection.Close();
                                dataSet = new DataSet();
                                db.getDataAdapter.Fill(dataSet, "LoanChecker");
                                long accNo = (long)dataSet.Tables["LoanChecker"].Rows[0]["AccountNumber"];
                                if (accNumber == accNo)
                                {
                                    sSMessage.Visible = true;
                                    int waiverMonth, waiverStatus;
                                    if (checkWaiver.Checked == false)
                                    {
                                        waiverMonth = 0;
                                    }
                                    else
                                    {
                                        waiverMonth = Convert.ToInt16(numMonthWaiver.Value);
                                    }

                                    db.connect();
                                    db.balanceLoan(accNumber, waiverMonth);
                                    db.getConnection.Close();
                                    DataTable tb = new DataTable();
                                    db.getDataAdapter.Fill(tb);
                                    waiverStatus = (int)tb.Rows[0]["WaiverStatus"];

                                    if (waiverMonth <= 0)
                                    {
                                        if (waiverStatus == 0)
                                        {
                                            tSSMessage.Text = "Loan has been balanced";
                                        }
                                        else
                                        {
                                            tSSMessage.Text = "Can't balance loan! Customer is still owing";
                                        }
                                    }
                                    else
                                    {
                                        if (waiverMonth == 1 && waiverStatus == 0)
                                        {
                                            tSSMessage.Text = "Loan has been balanced with " + waiverMonth + " month waived";
                                        }
                                        else if (waiverMonth > 1 && waiverStatus == 0)
                                        {
                                            tSSMessage.Text = "Loan has been balanced with " + waiverMonth + " months waived";
                                        }
                                        else
                                        {
                                            tSSMessage.Text = "Sorry! Customer did not meet the waive requirements";
                                        }
                                    }
                                }
                            }
                            catch (FormatException fe)
                            {
                                MessageBox.Show("Only number required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            catch (IndexOutOfRangeException ex)
                            {
                                sSMessage.Visible = true;
                                tSSMessage.Text = "Customer is currently not on loan!";
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
            txtAccNo.Text = "";
            numMonthWaiver.Value = 0;
            sSMessage.Visible = false;
        }
        private void linkLogout_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login log = new Login();
            ExposeProperties exp = new ExposeProperties();
            log.logFile(exp.getUser, "Offline");
            new Login().Show();
            Hide();
        }

        private void linkHome_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Home().Show();
            Hide();
        }

        private void checkWaiver_CheckedChanged(object sender, EventArgs e)
        {
            numMonthWaiver.Visible = true;
            if (checkWaiver.Checked == false)
            {
                numMonthWaiver.Visible = true;
            }
        }
    }
}
