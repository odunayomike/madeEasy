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
    public partial class BulkTransaction : Form
    {
        private DatabaseLib db = new DatabaseLib();
        private ErrorProvider error = new ErrorProvider();
        private DataTable tb;
        private long accNumber, deposit;
        private string description;
        public BulkTransaction()
        {
            InitializeComponent();
        }
        private int validateDeposit()
        {
            int flag = 0;
            if (txtAccNo1.Text == "" && txtDep1.Text.Length > 0)
            {
                txtAccNo1.Focus();
                error.SetError(txtAccNo1, "Please enter the account number");
                flag = 1;
            }
            if (txtAccNo1.Text.Length > 0 && txtDep1.Text == "")
            {
                txtDep1.Focus();
                error.SetError(txtDep1, "Please enter the deposit amount");
                flag = 1;
            }
            if (txtAccNo2.Text == "" && txtDep2.Text.Length > 0)
            {
                txtAccNo2.Focus();
                error.SetError(txtAccNo2, "Please enter the account number");
                flag = 1;
            }
            if (txtAccNo2.Text.Length > 0 && txtDep2.Text == "")
            {
                txtDep2.Focus();
                error.SetError(txtDep2, "Please enter the deposit amount");
                flag = 1;
            }
            if (txtAccNo3.Text == "" && txtDep3.Text.Length > 0)
            {
                txtAccNo3.Focus();
                error.SetError(txtAccNo3, "Please enter the account number");
                flag = 1;
            }
            if (txtAccNo3.Text.Length > 0 && txtDep3.Text == "")
            {
                txtDep3.Focus();
                error.SetError(txtDep3, "Please enter the deposit amount");
                flag = 1;
            }
            if (txtAccNo4.Text == "" && txtDep4.Text.Length > 0)
            {
                txtAccNo4.Focus();
                error.SetError(txtAccNo4, "Please enter the account number");
                flag = 1;
            }
            if (txtAccNo4.Text.Length > 0 && txtDep4.Text == "")
            {
                txtDep4.Focus();
                error.SetError(txtDep4, "Please enter the deposit amount");
                flag = 1;
            }
            if (txtAccNo5.Text == "" && txtDep5.Text.Length > 0)
            {
                txtAccNo5.Focus();
                error.SetError(txtAccNo5, "Please enter the account number");
                flag = 1;
            }
            if (txtAccNo5.Text.Length > 0 && txtDep5.Text == "")
            {
                txtDep5.Focus();
                error.SetError(txtDep5, "Please enter the deposit amount");
                flag = 1;
            }
            if (txtAccNo6.Text == "" && txtDep6.Text.Length > 0)
            {
                txtAccNo6.Focus();
                error.SetError(txtAccNo6, "Please enter the account number");
                flag = 1;
            }
            if (txtAccNo6.Text.Length > 0 && txtDep6.Text == "")
            {
                txtDep6.Focus();
                error.SetError(txtDep6, "Please enter the deposit amount");
                flag = 1;
            }
            if (txtAccNo7.Text == "" && txtDep7.Text.Length > 0)
            {
                txtAccNo7.Focus();
                error.SetError(txtAccNo7, "Please enter the account number");
                flag = 1;
            }
            if (txtAccNo7.Text.Length > 0 && txtDep7.Text == "")
            {
                txtDep7.Focus();
                error.SetError(txtDep7, "Please enter the deposit amount");
                flag = 1;
            }
            if (txtAccNo8.Text == "" && txtDep8.Text.Length > 0)
            {
                txtAccNo8.Focus();
                error.SetError(txtAccNo8, "Please enter the account number");
                flag = 1;
            }
            if (txtAccNo8.Text.Length > 0 && txtDep8.Text == "")
            {
                txtDep8.Focus();
                error.SetError(txtDep8, "Please enter the deposit amount");
                flag = 1;
            }
            if (txtAccNo9.Text == "" && txtDep9.Text.Length > 0)
            {
                txtAccNo9.Focus();
                error.SetError(txtAccNo9, "Please enter the account number");
                flag = 1;
            }
            if (txtAccNo9.Text.Length > 0 && txtDep9.Text == "")
            {
                txtDep9.Focus();
                error.SetError(txtDep9, "Please enter the deposit amount");
                flag = 1;
            }
            if (txtAccNo10.Text == "" && txtDep10.Text.Length > 0)
            {
                txtAccNo10.Focus();
                error.SetError(txtAccNo10, "Please enter the account number");
                flag = 1;
            }
            if (txtAccNo10.Text.Length > 0 && txtDep10.Text == "")
            {
                txtDep10.Focus();
                error.SetError(txtDep10, "Please enter the deposit amount");
                flag = 1;
            }
            return flag;
        }
        private long totalDeposit()
        {
            deposit = 0;
            if (txtDep1.Text.Length > 0)
            {
                deposit += long.Parse(txtDep1.Text);
            }
            if (txtDep2.Text.Length > 0)
            {
                deposit += long.Parse(txtDep2.Text);
            }
            if (txtDep3.Text.Length > 0)
            {
                deposit += long.Parse(txtDep3.Text);
            }
            if (txtDep4.Text.Length > 0)
            {
                deposit += long.Parse(txtDep4.Text);
            }
            if (txtDep5.Text.Length > 0)
            {
                deposit += long.Parse(txtDep5.Text);
            }
            if (txtDep6.Text.Length > 0)
            {
                deposit += long.Parse(txtDep6.Text);
            }
            if (txtDep7.Text.Length > 0)
            {
                deposit += long.Parse(txtDep7.Text);
            }
            if (txtDep8.Text.Length > 0)
            {
                deposit += long.Parse(txtDep8.Text);
            }
            if (txtDep9.Text.Length > 0)
            {
                deposit += long.Parse(txtDep9.Text);
            }
            if (txtDep10.Text.Length > 0)
            {
                deposit += long.Parse(txtDep10.Text);
            }
            return deposit;
        }
        private long deposit1()
        {
            if (txtDep1.Text.Length > 0)
            {
                try
                {
                    accNumber = long.Parse(txtAccNo1.Text);
                    deposit = long.Parse(txtDep1.Text);
                    //if(richDesc1.Text.Length == 0)
                    //{
                    //    richDesc1.Text = "";
                    //    description = richDesc1.Text;
                    //}
                    //else
                    //{
                        description = richDesc1.Text;
                    //}

                    lblDep1.Visible = true;
                    lblDep1.Text = new Home().bulkDeposit(accNumber, deposit, description);
                }
                catch (FormatException fe)
                {
                    MessageBox.Show("numbers required!");
                }
            }
            return deposit;
        }
        private long deposit2()
        {
            if (txtDep2.Text.Length > 0)
            {
                try
                {
                    accNumber = long.Parse(txtAccNo2.Text);
                    deposit = long.Parse(txtDep2.Text);
                    description = richDesc2.Text;
                    lblDep2.Visible = true;
                    lblDep2.Text = new Home().bulkDeposit(accNumber, deposit, description);
                }
                catch (FormatException fe)
                {
                    MessageBox.Show("numbers required!");
                }
            }
            return deposit;
        }
        private long deposit3()
        {
            if (txtDep3.Text.Length > 0)
            {
                try
                {
                    accNumber = long.Parse(txtAccNo3.Text);
                    deposit = long.Parse(txtDep3.Text);
                    description = richDesc3.Text;
                    lblDep3.Visible = true;
                    lblDep3.Text = new Home().bulkDeposit(accNumber, deposit, description);
                }
                catch (FormatException fe)
                {
                   MessageBox.Show("numbers required!");
                }
            }
            return deposit;
        }
        private long deposit4()
        {
            if (txtDep4.Text.Length > 0)
            {
                try
                {
                    accNumber = long.Parse(txtAccNo4.Text);
                    deposit = long.Parse(txtDep4.Text);
                    description = richDesc4.Text;
                    lblDep4.Visible = true;
                    lblDep4.Text = new Home().bulkDeposit(accNumber, deposit, description);
                }
                catch (FormatException fe)
                {
                    MessageBox.Show("numbers required!");
                }
            }
            return deposit;
        }
        private long deposit5()
        {
            if (txtDep5.Text.Length > 0)
            {
                try
                {
                    accNumber = long.Parse(txtAccNo5.Text);
                    deposit = long.Parse(txtDep5.Text);
                    //if (richDesc1.Text.Length == 0)
                    //{
                    //    richDesc5.Text = "";
                    //    description = richDesc5.Text;
                    //}
                    //else
                    //{
                        description = richDesc5.Text;
                    //}

                    lblDep5.Visible = true;
                    lblDep5.Text = new Home().bulkDeposit(accNumber, deposit, description);
                }
                catch (FormatException fe)
                {
                    MessageBox.Show("numbers required!");
                }
            }
            return deposit;
        }
        private long deposit6()
        {
            if (txtDep6.Text.Length > 0)
            {
                try
                {
                    accNumber = long.Parse(txtAccNo6.Text);
                    deposit = long.Parse(txtDep6.Text);
                    description = richDesc6.Text;
                    lblDep6.Visible = true;
                    lblDep6.Text = new Home().bulkDeposit(accNumber, deposit, description);
                }
                catch (FormatException fe)
                {
                    MessageBox.Show("numbers required!");
                }
            }
            return deposit;
        }
        private long deposit7()
        {
            if (txtDep7.Text.Length > 0)
            {
                try
                {
                    accNumber = long.Parse(txtAccNo7.Text);
                    deposit = long.Parse(txtDep7.Text);
                    description = richDesc7.Text;
                    lblDep7.Visible = true;
                    lblDep7.Text = new Home().bulkDeposit(accNumber, deposit, description);
                }
                catch (FormatException fe)
                {
                    MessageBox.Show("numbers required!");
                }
            }
            return deposit;
        }
        private long deposit8()
        {
            if (txtDep8.Text.Length > 0)
            {
                try
                {
                    accNumber = long.Parse(txtAccNo8.Text);
                    deposit = long.Parse(txtDep8.Text);
                    description = richDesc8.Text;
                    lblDep8.Visible = true;
                    lblDep8.Text = new Home().bulkDeposit(accNumber, deposit, description);
                }
                catch (FormatException fe)
                {
                    MessageBox.Show("numbers required!");
                }
            }
            return deposit;
        }
        private long deposit9()
        {
            if (txtDep9.Text.Length > 0)
            {
                try
                {
                    accNumber = long.Parse(txtAccNo9.Text);
                    deposit = long.Parse(txtDep9.Text);
                    description = richDesc9.Text;
                    lblDep9.Visible = true;
                    lblDep9.Text = new Home().bulkDeposit(accNumber, deposit, description);
                }
                catch (FormatException fe)
                {
                    MessageBox.Show("numbers required!");
                }
            }
            return deposit;
        }
        private long deposit10()
        {
            if (txtDep10.Text.Length > 0)
            {
                try
                {
                    accNumber = long.Parse(txtAccNo10.Text);
                    deposit = long.Parse(txtDep10.Text);
                    description = richDesc10.Text;
                    lblDep10.Visible = true;
                    lblDep10.Text = new Home().bulkDeposit(accNumber, deposit, description);
                }
                catch (FormatException fe)
                {
                    MessageBox.Show("numbers required!");
                }
            }
            return deposit;
        }
        private void bulkDeposit()
        {
            if (validateDeposit() == 0)
            {
                deposit1(); deposit2(); deposit3(); deposit4(); deposit5(); deposit6(); deposit7(); deposit8(); deposit9(); deposit10();

                txtAccNo1.Text = ""; txtAccNo2.Text = ""; txtAccNo3.Text = ""; txtAccNo4.Text = ""; txtAccNo5.Text = ""; txtAccNo6.Text = "";
                txtAccNo7.Text = ""; txtAccNo8.Text = ""; txtAccNo9.Text = ""; txtAccNo10.Text = "";

                txtDep1.Text = ""; txtDep2.Text = ""; txtDep3.Text = ""; txtDep4.Text = ""; txtDep5.Text = ""; txtDep6.Text = "";
                txtDep7.Text = ""; txtDep8.Text = ""; txtDep9.Text = ""; txtDep10.Text = "";

                richDesc1.Text = ""; richDesc2.Text = ""; richDesc3.Text = ""; richDesc4.Text = ""; richDesc5.Text = ""; richDesc6.Text = "";
                richDesc7.Text = ""; richDesc8.Text = ""; richDesc9.Text = ""; richDesc10.Text = "";
            }
        }

        private void txtDep1_MouseHover(object sender, EventArgs e)
        {
            if (txtAccNo1.Text.Length != 0)
            {
                try
                {
                    accNumber = long.Parse(txtAccNo1.Text);
                    lblDep1.Visible = true;
                    lblDep1.Text = new Home().sendCustomerDepDetails(accNumber);
                }
                catch (FormatException fe)
                {
                    MessageBox.Show("numbers required!");
                }
            }
            else
            {
                lblDep1.Visible = true;
                lblDep1.Text = "Please enter the account number first!";
            }
        }
        private void txtDep2_MouseHover(object sender, EventArgs e)
        {
            if (txtAccNo2.Text.Length != 0)
            {
                try
                {
                    accNumber = long.Parse(txtAccNo2.Text);
                    lblDep2.Visible = true;
                    lblDep2.Text = new Home().sendCustomerDepDetails(accNumber);
                }
                catch (FormatException fe)
                {
                    MessageBox.Show("numbers required!");
                }
            }
            else
            {
                lblDep2.Visible = true;
                lblDep2.Text = "Please enter the account number first!";
            }
        }
        private void txtDep3_MouseHover(object sender, EventArgs e)
        {
            if (txtAccNo3.Text.Length != 0)
            {
                try
                {
                    accNumber = long.Parse(txtAccNo3.Text);
                    lblDep3.Visible = true;
                    lblDep3.Text = new Home().sendCustomerDepDetails(accNumber);
                }
                catch (FormatException fe)
                {
                    MessageBox.Show("numbers required!");
                }
            }
            else
            {
                lblDep3.Visible = true;
                lblDep3.Text = "Please enter the account number first!";
            }
        }
        private void txtDep4_MouseHover(object sender, EventArgs e)
        {
            if (txtAccNo4.Text.Length != 0)
            {
                try
                {
                    accNumber = long.Parse(txtAccNo4.Text);
                    lblDep4.Visible = true;
                    lblDep4.Text = new Home().sendCustomerDepDetails(accNumber);
                }
                catch (FormatException fe)
                {
                    MessageBox.Show("numbers required!");
                }
            }
            else
            {
                lblDep4.Visible = true;
                lblDep4.Text = "Please enter the account number first!";
            }
        }
        private void txtDep5_MouseHover(object sender, EventArgs e)
        {

            if (txtAccNo5.Text.Length != 0)
            {
                try
                {
                    accNumber = long.Parse(txtAccNo5.Text);
                    lblDep5.Visible = true;
                    lblDep5.Text = new Home().sendCustomerDepDetails(accNumber);
                }
                catch (FormatException fe)
                {
                    MessageBox.Show("numbers required!");
                }
            }
            else
            {
                lblDep5.Visible = true;
                lblDep5.Text = "Please enter the account number first!";
            }
        }
        private void txtDep6_MouseHover(object sender, EventArgs e)
        {
            if (txtAccNo6.Text.Length != 0)
            {
                try
                {
                    accNumber = long.Parse(txtAccNo6.Text);
                    lblDep6.Visible = true;
                    lblDep6.Text = new Home().sendCustomerDepDetails(accNumber);
                }
                catch (FormatException fe)
                {
                    MessageBox.Show("numbers required!");
                }
            }
            else
            {
                lblDep6.Visible = true;
                lblDep6.Text = "Please enter the account number first!";
            }
        }
        private void txtDep7_MouseHover(object sender, EventArgs e)
        {
            if (txtAccNo7.Text.Length != 0)
            {
                try
                {
                    accNumber = long.Parse(txtAccNo7.Text);
                    lblDep7.Visible = true;
                    lblDep7.Text = new Home().sendCustomerDepDetails(accNumber);
                }
                catch (FormatException fe)
                {
                    MessageBox.Show("numbers required!");
                }
            }
            else
            {
                lblDep7.Visible = true;
                lblDep7.Text = "Please enter the account number first!";
            }
        }
        private void txtDep8_MouseHover(object sender, EventArgs e)
        {
            if (txtAccNo8.Text.Length != 0)
            {
                try
                {
                    accNumber = long.Parse(txtAccNo8.Text);
                    lblDep8.Visible = true;
                    lblDep8.Text = new Home().sendCustomerDepDetails(accNumber);
                }
                catch (FormatException fe)
                {
                    MessageBox.Show("numbers required!");
                }
            }
            else
            {
                lblDep8.Visible = true;
                lblDep8.Text = "Please enter the account number first!";
            }
        }
        private void txtDep9_MouseHover(object sender, EventArgs e)
        {
            if (txtAccNo9.Text.Length != 0)
            {
                try
                {
                    accNumber = long.Parse(txtAccNo9.Text);
                    lblDep9.Visible = true;
                    lblDep9.Text = new Home().sendCustomerDepDetails(accNumber);
                }
                catch (FormatException fe)
                {
                    MessageBox.Show("numbers required!");
                }
            }
            else
            {
                lblDep9.Visible = true;
                lblDep9.Text = "Please enter the account number first!";
            }
        }
        private void txtDep10_MouseHover(object sender, EventArgs e)
        {
            if (txtAccNo10.Text.Length != 0)
            {
                try
                {
                    accNumber = long.Parse(txtAccNo10.Text);
                    lblDep10.Visible = true;
                    lblDep10.Text = new Home().sendCustomerDepDetails(accNumber);
                }
                catch (FormatException fe)
                {
                    MessageBox.Show("numbers required!");
                }
            }
            else
            {
                lblDep10.Visible = true;
                lblDep10.Text = "Please enter the account number first!";
            }
        }
        private void btnDep_Click(object sender, EventArgs e)
        {
            if (validateDeposit() == 0)
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
                        if(hour < open)
                        {
                            MessageBox.Show("Sorry, itsn't open hour yet", "Can't Connect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            new Login().Show();
                            Hide();
                        }
                        else if(hour >= close && minute >=1)
                        {
                            MessageBox.Show("Sorry, work hour is over", "Can't Connect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            new Login().Show();
                            Hide();
                        }
                        else
                        {
                            DateTime dt = new Home().databaseDate();
                            db.connect();// Vault transaction implementation 
                            db.vaultBalance(dt.ToShortDateString(), ExposeProperties.BranchCode);
                            db.getConnection.Close();
                            DataTable vault = new DataTable();
                            db.getDataAdapter.Fill(vault);
                            long vaultDepositBalance = (long)vault.Rows[0]["DepositBalance"];

                            if (totalDeposit() <= vaultDepositBalance)
                            {
                                bulkDeposit();
                            }
                            else
                            {
                                sSMessage.Visible = true;
                                tSSMessage.Text = "Insufficient vault balance";
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
            txtAccNo1.Text = ""; txtAccNo2.Text = ""; txtAccNo3.Text = ""; txtAccNo4.Text = ""; txtAccNo5.Text = ""; txtAccNo6.Text = "";
            txtAccNo7.Text = ""; txtAccNo8.Text = ""; txtAccNo9.Text = ""; txtAccNo10.Text = "";

            txtDep1.Text = ""; txtDep2.Text = ""; txtDep3.Text = ""; txtDep4.Text = ""; txtDep5.Text = ""; txtDep6.Text = "";
            txtDep7.Text = ""; txtDep8.Text = ""; txtDep9.Text = ""; txtDep10.Text = "";
        }

        private void linkLogout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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
    }
}
