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
using System.Data.SqlClient;

namespace SoftlightMF
{
    public partial class AccountSetup : Form
    {
        DatabaseLib db = new DatabaseLib();
        DataTable tb;
        string accountType, sub;
        float amount;
        public AccountSetup()
        {
            InitializeComponent();
            getAccountType();
        }
        private void radEdit_CheckedChanged(object sender, EventArgs e)
        {
            panComboAcctType.Visible = true;
            panAccountType.Visible = false;
            btnRegister.Enabled = true;
            btnRegister.Text= "Update";
            if(radEdit.Checked == false)
            {
                panComboAcctType.Visible = false;
                panAccountType.Visible = true;
                comboAccountType.Text = "";
            }
        }
        private void radDelete_CheckedChanged(object sender, EventArgs e)
        {
            panComboAcctType.Visible = true;
            panAccountType.Visible = false;
            btnRegister.Enabled = false;
            if (radDelete.Checked == false)
            {
                panComboAcctType.Visible = false;
                panAccountType.Visible = true;
                comboAccountType.Text = "";
            }
        }
        private void radRegister_CheckedChanged(object sender, EventArgs e)
        {
            panComboAcctType.Visible = false;
            panAccountType.Visible = true;
            btnRegister.Enabled = true;
            btnRegister.Text = "Register";
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtAccountType.Text = "";
            txtAmount.Text = "";
            if (comboAccountType.Visible == true)
            {
                comboAccountType.Text = "";
            }
        }
        private int validateAccountType()
        {
            int flag = 0;
            if (txtAccountType.Text.Length == 0)
            {
                txtAccountType.Focus();
                errorProvider.SetError(txtAccountType, "Please, enter the account type!");
                flag = 1;
            }
            if (txtAmount.Text == "")
            {
                txtAmount.Focus();
                errorProvider.SetError(txtAmount, "Please, enter the amount!");
                flag = 1;
            }
            return flag;
        }
        private void getAccountType()
        {
            db.connect();
            db.getAccountType();
            db.getConnection.Close();
            tb = new DataTable();
            db.getDataAdapter.Fill(tb);
            foreach(DataRow dr in tb.Rows)
            {
                comboAccountType.Items.Add(dr["AccountType"].ToString());
            }
        }
        private void register()
        {
            try
            {
                accountType = txtAccountType.Text.ToString();
                db.connect();
                db.getAccountTypeDetails(accountType);
                db.getConnection.Close();
                DataTable tb = new DataTable();
                db.getDataAdapter.Fill(tb);
                string dbAccountType = tb.Rows[0]["AccountType"].ToString();

                if (accountType.ToUpper().Equals(dbAccountType))
                {
                    sSMessage.Visible = true;
                    tSSMessage.Text = "Account type already exits!";
                }
            }
            catch (IndexOutOfRangeException idx)
            {
                accountType = txtAccountType.Text.ToUpper();
                amount = float.Parse(txtAmount.Text);
                db.connect();
                db.registerAccountType(accountType, amount);
                db.getConnection.Close();
                DataTable tb2 = new DataTable();
                db.getDataAdapter.Fill(tb2);
                sSMessage.Visible = true;
                tSSMessage.Text = "Account type registered successfully";
                comboAccountType.Items.Clear();
                getAccountType();
            }
            catch (FormatException fe)
            {
                txtAmount.Focus();
                errorProvider.SetError(txtAmount, "Only number required");
            }
            catch (SqlException sql)
            {
                MessageBox.Show(sql.Message);
            }
        }
        private void delete()
        {
            try
            {
                db.connect();
                db.deleteAccountType(comboAccountType.SelectedItem.ToString());
                db.getConnection.Close();
                tb = new DataTable();
                db.getDataAdapter.Fill(tb);
                sSMessage.Visible = true;
                tSSMessage.Text = "Account type deleted successfully";
                comboAccountType.Items.Clear();
                getAccountType();
            }
            catch(IndexOutOfRangeException idx)
            {
                sSMessage.Visible = true;
                tSSMessage.Text = "Invalid account type!";
            }
            catch(SqlException sql)
            {
                MessageBox.Show(sql.Message);
            }
        }
        private void edit()
        {
            try
            {
                accountType = txtAccountType.Text.ToUpper();
                amount = float.Parse(txtAmount.Text);
                db.connect();
                db.editAccountType(comboAccountType.SelectedItem.ToString(), accountType, amount);
                db.getConnection.Close();
                tb = new DataTable();
                db.getDataAdapter.Fill(tb);
                sSMessage.Visible = true;
                tSSMessage.Text = "Account type updated successfully";
                comboAccountType.Items.Clear();
                getAccountType();
            }
            catch (IndexOutOfRangeException idx)
            {
                sSMessage.Visible = true;
                tSSMessage.Text = "Invalid account type!";
            }
            catch(FormatException fe)
            {
                txtAmount.Focus();
                errorProvider.SetError(txtAmount, "Only number required");
            }
            catch(SqlException sql)
            {
                MessageBox.Show(sql.Message);
            }
        }
        private void btnRegister_Click(object sender, EventArgs e)
        {
            if(validateAccountType() == 0)
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
                            if (radEdit.Checked == true && comboAccountType.SelectedItem != "")
                            {
                                edit();
                            }
                            else
                            {
                                register();
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
        private void comboAccountType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radDelete.Checked != true)
            {
                try
                {
                    string dbAccountType, dbAmount;
                    db.connect();
                    db.getAccountTypeDetails(comboAccountType.SelectedItem.ToString());
                    db.getConnection.Close();
                    tb = new DataTable();
                    db.getDataAdapter.Fill(tb);
                    dbAccountType = tb.Rows[0]["AccountType"].ToString();
                    dbAmount = tb.Rows[0]["Amount"].ToString();

                    txtAccountType.Text = dbAccountType;
                    txtAmount.Text = dbAmount;
                    panAccountType.Visible = true;
                }
                catch(IndexOutOfRangeException idx)
                {
                    sSMessage.Visible = true;
                    tSSMessage.Text = "Invalid account type";
                }
                catch(SqlException sql)
                {
                    MessageBox.Show(sql.Message);
                }
            }
            else
            {
                panAccountType.Visible = false;
                if (btnRegister.Enabled == false && comboAccountType.SelectedItem != "")
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
                                if ((MessageBox.Show("Are you sure you want to delete?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                                {
                                    delete();
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
       
    }
}
