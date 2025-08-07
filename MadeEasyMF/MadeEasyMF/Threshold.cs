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
    public partial class Threshold : Form
    {
        private DatabaseLib db;
        private DataTable tb;
        private string departmentID, departmentName, sub;
        private long deposit, bulk, withdrawal, transfer;
        public Threshold()
        {
            InitializeComponent();
        }
        private void radCreate_CheckedChanged(object sender, EventArgs e)
        {
            btnSetup.Text = "Setup";
            comboDepartment.Text = "Department";
            getDepartment();
            panSetupAmount.Visible = true;
            if(radCreate.Checked == false)
            {
                comboDepartment.Items.Clear();
                panSetupAmount.Visible = false;
            }
        }
        private void getDepartment()
        {
            db = new DatabaseLib();
            db.connect();
            db.getDepartment();
            db.getConnection.Close();
            tb = new DataTable();
            db.getDataAdapter.Fill(tb);
            foreach (DataRow dr in tb.Rows)
            {
                comboDepartment.Items.Add(dr["DepartmentName"].ToString());
            }
        }
        private void radEdit_CheckedChanged(object sender, EventArgs e)
        {
            btnSetup.Text = "Update";
            comboDepartment.Text = "Department";
            getThresholdDepartment();
            if (radEdit.Checked == false)
            {
                comboDepartment.Items.Clear();
                panSetupAmount.Visible = false;
                txtDeposit.Text = "";
                txtBulk.Text = "";
                txtWithdrawal.Text = "";
                txtTransfer.Text = "";
            }
        }
        private string getDepartmentID(string departmentName)
        {
            string depID = null;
            db = new DatabaseLib();
            db.connect();
            db.getDepartment(departmentName);
            db.getConnection.Close();
            tb = new DataTable();
            db.getDataAdapter.Fill(tb);
            depID = tb.Rows[0]["DepartmentID"].ToString();
            return depID;
        }
        private void setupThreshold()
        {
            if (comboDepartment.Text.Equals("Department"))
            {
                comboDepartment.Focus();
                errorProvider.SetError(comboDepartment, "Please select a department!");
            }
            else
            {
                errorProvider.Clear();
                if(txtDeposit.Text.Equals(""))
                {
                    txtDeposit.Text = 0.ToString();
                }
                if (txtBulk.Text.Equals(""))
                {
                    txtBulk.Text = 0.ToString();
                }
                if (txtWithdrawal.Text.Equals(""))
                {
                    txtWithdrawal.Text = 0.ToString();
                }
                if (txtTransfer.Text.Equals(""))
                {
                    txtTransfer.Text = 0.ToString();
                }

                departmentName = comboDepartment.SelectedItem.ToString();
                departmentID = getDepartmentID(departmentName);
                deposit = long.Parse(txtDeposit.Text);
                bulk = long.Parse(txtBulk.Text);
                withdrawal = long.Parse(txtWithdrawal.Text);
                transfer = long.Parse(txtTransfer.Text);

                db = new DatabaseLib();
                db.connect();
                db.setupThreshold(departmentID, deposit, bulk, withdrawal, transfer);
                db.getConnection.Close();
                tb = new DataTable();
                db.getDataAdapter.Fill(tb);
                int status = (int)tb.Rows[0]["Status"];
                
                if(status == 0)
                {
                    sSMessage.Visible = true;
                    tSSMessage.Text = "Threshold is successfully setup";
                }
                else
                {
                    sSMessage.Visible = false;
                    MessageBox.Show("Sorry! Threshold already existed for this department,\n"
                    +"please consider editing instead", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void getThresholdDepartment()
        {
            db = new DatabaseLib();
            db.connect();
            db.getThresholdDepartment();
            db.getConnection.Close();
            tb = new DataTable();
            db.getDataAdapter.Fill(tb);
            foreach (DataRow dr in tb.Rows)
            {
                comboDepartment.Items.Add(dr["DepartmentName"].ToString());
            }
        }
        private void updateThreshold()
        {
            departmentID = getDepartmentID(departmentName);
            deposit = long.Parse(txtDeposit.Text);
            bulk = long.Parse(txtBulk.Text);
            withdrawal = long.Parse(txtWithdrawal.Text);
            transfer = long.Parse(txtTransfer.Text);
            db = new DatabaseLib();
            db.connect();
            db.updateThreshold(departmentID, deposit, bulk, withdrawal, transfer);
            db.getConnection.Close();
            tb = new DataTable();
            db.getDataAdapter.Fill(tb);
            int status = (int)tb.Rows[0]["Status"];

            if (status == 0)
            {
                sSMessage.Visible = true;
                tSSMessage.Text = "Threshold successfully updated";
            }
            else
            {
                sSMessage.Visible = false;
                MessageBox.Show("Sorry, threshold couldn't be updated", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnSetup_Click(object sender, EventArgs e)
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
                        if (btnSetup.Text.Equals("Setup"))
                        {
                            setupThreshold();
                        }
                        else
                        {
                            updateThreshold();
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
        private void comboDepartment_SelectedIndexChanged(object sender, EventArgs e)
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
                        if (radEdit.Checked == true)
                        {
                            if (!comboDepartment.Text.Equals("Department"))
                            {
                                try
                                {
                                    panSetupAmount.Visible = true;
                                    departmentName = comboDepartment.SelectedItem.ToString();
                                    db = new DatabaseLib();
                                    db.connect();
                                    db.getThreshold(departmentName);
                                    db.getConnection.Close();
                                    tb = new DataTable();
                                    db.getDataAdapter.Fill(tb);
                                    deposit = (long)tb.Rows[0]["Deposit"];
                                    bulk = (long)tb.Rows[0]["BulkDeposit"];
                                    withdrawal = (long)tb.Rows[0]["Withdrawal"];
                                    transfer = (long)tb.Rows[0]["Transfer"];

                                    txtDeposit.Text = deposit.ToString();
                                    txtBulk.Text = bulk.ToString();
                                    txtWithdrawal.Text = withdrawal.ToString();
                                    txtTransfer.Text = transfer.ToString();
                                }
                                catch (IndexOutOfRangeException idx)
                                {
                                    sSMessage.Visible = true;
                                    tSSMessage.Text = "Sorry, department id doesn't exist";
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
    }
}
