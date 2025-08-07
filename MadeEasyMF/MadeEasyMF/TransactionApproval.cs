using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DatabaseLibrary;

namespace SoftlightMF
{
    public partial class TransactionApproval : Form
    {
        private DatabaseLib db;
        private DataTable tb;
        private string control = "default", username;
        private long ledgerID;

        public TransactionApproval()
        {
            InitializeComponent();
            getLedger();
            comboFilter.Text = "Filter";
            comboLedgerID.Text = "Ledger ID";
        }
        private void getLedger()
        {
            db = new DatabaseLib();
            db.connect();
            db.getLedgerID();
            db.getConnection.Close();
            tb = new DataTable();
            db.getDataAdapter.Fill(tb);

            foreach (DataRow dr in tb.Rows)
            {
                comboLedgerID.Items.Add(dr["LedgerID"].ToString());
            }

            DatabaseLib db2 = new DatabaseLib();
            db2.connect();
            db2.getLedgerUsername();
            db2.getConnection.Close();
            DataTable tb2 = new DataTable();
            db2.getDataAdapter.Fill(tb2); 

            foreach (DataRow dr in tb2.Rows)
            {
                comboFilter.Items.Add(dr["Cashier"].ToString());
            }
        }
        private int approveTransaction()
        {
            int status = 0;
            long ledgerID = long.Parse(comboLedgerID.SelectedItem.ToString());

            DatabaseLib db2 = new DatabaseLib();
            db2.connect();
            db2.logTransactionApproval(ExposeProperties.Username, ledgerID);
            db2.getConnection.Close();
            DataTable tb2 = new DataTable();
            db2.getDataAdapter.Fill(tb2);

            db = new DatabaseLib();
            db.connect();
            db.approveTransaction(ledgerID);
            db.getConnection.Close();
            tb = new DataTable();
            db.getDataAdapter.Fill(tb);
            status = (int)tb.Rows[0]["Status"];

            return status;
        }
        private int disapproveTransaction()
        {
            int status = 0;
            long ledgerID = long.Parse(comboLedgerID.SelectedItem.ToString());

            db = new DatabaseLib();
            db.connect();
            db.disapproveTransaction(ledgerID);
            db.getConnection.Close();
            tb = new DataTable();
            db.getDataAdapter.Fill(tb);
            status = (int)tb.Rows[0]["Status"];

            return status;
        }
        private void filterTransaction(string control, string username, long ledgerID)
        {
            db = new DatabaseLib();
            db.connect();
            db.filterTransaction(control, username, ledgerID);
            db.getConnection.Close();
            tb = new DataTable();
            db.getDataAdapter.Fill(tb);
            dataGridLedger.DataSource = tb;
        }
        private void btnApprove_Click(object sender, EventArgs e)
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
                        if (checkApprovedTransaction.Checked == true)
                        {
                            MessageBox.Show("Please uncheck the show approved transaction(s) first", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (checkApprovedTransaction.Checked == false && comboFilter.Text.Equals("Filter") && comboLedgerID.Text.Equals("Ledger ID"))
                        {
                            MessageBox.Show("Please select ledger id to approve transaction", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            if (control.Equals("default"))
                            {
                                MessageBox.Show("Please select Ledger ID first", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else if (control.Equals("approved") && checkApprovedTransaction.Checked == false)
                            {
                                MessageBox.Show("Please select Ledger ID first", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else if (control.Equals("filter") && checkApprovedTransaction.Checked == false)
                            {
                                MessageBox.Show("Please select Ledger ID first", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                if (MessageBox.Show("Are you sure you want to approve this transaction?", "Approve",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    int getStatus = approveTransaction();
                                    sSMessage.Visible = true;
                                    if (getStatus == 0)
                                    {
                                        comboLedgerID.Items.Clear();
                                        comboFilter.Items.Clear();
                                        comboFilter.Text = "Filter";
                                        comboLedgerID.Text = "Ledger ID";
                                        getLedger();
                                        dataGridLedger.Visible = false;
                                        tSSMessage.Text = "Transaction approved";
                                    }
                                    else if(getStatus == 2)
                                    {
                                        tSSMessage.Text = "Insufficient vault balance";
                                    }
                                    else
                                    {
                                        tSSMessage.Text = "Transaction not approved";
                                    }   
                                }
                                else
                                {
                                    sSMessage.Visible = true;
                                    tSSMessage.Text = "Transaction not approved";
                                }
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
        private void btnDisapprove_Click(object sender, EventArgs e)
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
                        if (checkApprovedTransaction.Checked == true)
                        {
                            MessageBox.Show("Please uncheck the show approved transaction(s) first", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (checkApprovedTransaction.Checked == false && comboLedgerID.Text.Equals("Ledger ID"))
                        {
                            MessageBox.Show("Please select ledger id to approve transaction", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            if (MessageBox.Show("Are you sure you want to disapprove this transaction?", "Disapprove",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                int getStatus = disapproveTransaction();
                                sSMessage.Visible = true;
                                if (getStatus == 0)
                                {
                                    comboLedgerID.Items.Clear();
                                    comboFilter.Items.Clear();
                                    comboFilter.Text = "Filter";
                                    comboLedgerID.Text = "Ledger ID";
                                    getLedger();
                                    dataGridLedger.Visible = false;
                                    tSSMessage.Text = "Transaction disapproved";
                                }
                                else
                                {
                                    tSSMessage.Text = "Transaction not disapproved";
                                }
                            }
                            else
                            {
                                sSMessage.Visible = true;
                                tSSMessage.Text = "Transaction disapproval canceled";
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
        private void comboLedgerID_SelectedIndexChanged(object sender, EventArgs e)
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
                        comboFilter.Text = "Filter";
                        dataGridLedger.Visible = true;
                        control = "ledger";
                        ledgerID = long.Parse(comboLedgerID.SelectedItem.ToString());
                        username = "Filter";
                        filterTransaction(control, username, ledgerID);
                        if (comboLedgerID.Text.Equals("Ledger ID"))
                        {
                            dataGridLedger.Visible = false;
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
        private void comboFilter_SelectedIndexChanged(object sender, EventArgs e)
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
                        comboLedgerID.Text = "Ledger ID";
                        dataGridLedger.Visible = true;
                        control = "filter";
                        username = comboFilter.SelectedItem.ToString();
                        ledgerID = 0;
                        filterTransaction(control, username, ledgerID);
                        if (comboFilter.Text.Equals("Filter"))
                        {
                            dataGridLedger.Visible = false;
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
        private void checkApprovedTransaction_CheckedChanged(object sender, EventArgs e)
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
                        if (checkApprovedTransaction.Checked == true)
                        {
                            db = new DatabaseLib();
                            db.connect();
                            db.getApprovedTransaction();
                            db.getConnection.Close();
                            tb = new DataTable();
                            db.getDataAdapter.Fill(tb);
                            dataGridLedger.DataSource = tb;

                            if (dataGridLedger.RowCount > 0)
                            {
                                sSMessage.Visible = false;
                                dataGridLedger.Visible = true;
                            }
                            else
                            {
                                sSMessage.Visible = false;
                                dataGridLedger.Visible = false;
                                MessageBox.Show("No record found!", "Info",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            control = "approved";
                            sSMessage.Visible = false;
                            dataGridLedger.Visible = false;
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
