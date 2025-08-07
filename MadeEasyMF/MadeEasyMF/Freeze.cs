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
    public partial class Freeze : Form
    {
        private DatabaseLib db = new DatabaseLib();
        private DataTable table = new DataTable();
        long accNumber;
        private string description, sub;
        public Freeze()
        {
            InitializeComponent();
        }
        private void freeze(long accNumber)
        {
            try
            {
                description = richTxtDescription.Text;
                db.connect();
                db.balanceUpdate(accNumber);
                db.getConnection.Close();
                DataTable table2 = new DataTable();
                db.getDataAdapter.Fill(table2);
                long accNo = (long)table2.Rows[0]["AccountNumber"];

                if (accNumber == accNo)
                {
                    db.connect();
                    db.insertFreeze(accNumber, description);
                    db.getConnection.Close();
                    table = new DataTable();
                    db.getDataAdapter.Fill(table);
                    sSMessage.Visible = true;
                    tSSMessage.Text = "Account has been frozen.";
                }
            }
            catch (IndexOutOfRangeException e)
            {
                sSMessage.Visible = true;
                tSSMessage.Text = "Account number is invalid!";
            }
            catch (SqlException ex)
            {

            }
        }
        private void unFreeze(long accNumber)
        {
            try
            {
                db.connect();
                db.balanceUpdate(accNumber);
                db.getConnection.Close();
                DataTable table2 = new DataTable();
                db.getDataAdapter.Fill(table2);
                long accNo = (long)table2.Rows[0]["AccountNumber"];

                if (accNumber == accNo)
                {
                    db.connect();
                    db.unFreeze(accNumber);
                    db.getConnection.Close();
                    table = new DataTable();
                    db.getDataAdapter.Fill(table);
                    sSMessage.Visible = true;
                    tSSMessage.Text = "Account has been unfrozen!.";
                }
            }
            catch (IndexOutOfRangeException e)
            {
                sSMessage.Visible = true;
                tSSMessage.Text = "Account number is invalid!";
            }
        }
        private void updateFreeze(long accNumber)
        {
            try
            {
                description = richTxtDescription.Text;
                db.connect();
                db.balanceUpdate(accNumber);
                db.getConnection.Close();
                DataTable table2 = new DataTable();
                db.getDataAdapter.Fill(table2);
                long accNo = (long)table2.Rows[0]["AccountNumber"];

                if (accNumber == accNo)
                {
                    db.connect();
                    db.updateFreeze(accNumber, description);
                    db.getConnection.Close();
                    table = new DataTable();
                    db.getDataAdapter.Fill(table);
                    sSMessage.Visible = true;
                    tSSMessage.Text = "Frozen account updated successfully";
                }
            }
            catch (IndexOutOfRangeException e)
            {
                sSMessage.Visible = true;
                tSSMessage.Text = "Account number is invalid!";
            }
            catch (SqlException ex)
            {

            }
        }
        private int validateFreeze()
        {
            int flag = 0;
            if (txtAccNo.Text == "")
            {
                txtAccNo.Focus();
                errorProvider.SetError(txtAccNo, "Please, enter the account number!");
                flag = 1;
            }
            return flag;
        }
        private void btnFreeze_Click(object sender, EventArgs e)
        {
            accNumber = Convert.ToInt64(txtAccNo.Text);
            if (validateFreeze() == 0)
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
                            if (btnFreeze.Text == "Freeze")
                            {
                                freeze(accNumber);
                            }
                            else
                            {
                                updateFreeze(accNumber);
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
        private void btnUnFreeze_Click(object sender, EventArgs e)
        {
            accNumber = Convert.ToInt64(txtAccNo.Text);
            if (validateFreeze() == 0)
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
                            unFreeze(accNumber);
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
        private void linkLogout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login log = new Login();
            ExposeProperties exp = new ExposeProperties();
            log.logFile(exp.getUser, "Offline");
            new Login().Show();
            Hide();
        }
        private void checkEdit_CheckedChanged(object sender, EventArgs e)
        {
            if (txtAccNo.Text.Length == 0)
            {
                txtAccNo.Focus();
                errorProvider.SetError(txtAccNo, "Please enter account number first!");
            }
            else
            {
                errorProvider.Clear();
                btnFreeze.Text = "Update";
                try
                {
                    accNumber = Convert.ToInt64(txtAccNo.Text);
                    db.connect();
                    db.freeze(accNumber);
                    db.getConnection.Close();
                    DataSet dataSet1 = new DataSet();
                    db.getDataAdapter.Fill(dataSet1, "Freeze");
                    long accNo = (long)dataSet1.Tables["Freeze"].Rows[0]["AccountNumber"];
                    string description = dataSet1.Tables["Freeze"].Rows[0]["Description"].ToString();

                    if (accNumber == accNo)
                    {
                        richTxtDescription.Text = description;
                    }
                }
                catch(IndexOutOfRangeException idx)
                {
                    sSMessage.Visible = true;
                    tSSMessage.Text = "Account number is invalid!";
                }
            }
            if(checkEdit.Checked == false)
            {
                btnFreeze.Text = "Freeze";
                txtAccNo.Text = "";
                richTxtDescription.Text = "";
            }
        }
        private void linkGroup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Group().Show();
            Hide();
        }                 
    }
}
