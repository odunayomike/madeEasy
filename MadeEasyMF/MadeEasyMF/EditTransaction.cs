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
    public partial class EditTransaction : Form
    {
        private ExposeProperties log = new ExposeProperties();
        private DatabaseLib db = new DatabaseLib();
        private DataTable tb;
        private ErrorProvider error;
        private long accNumber, transID;
        private string sub;
        public EditTransaction()
        {
            InitializeComponent();
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
        private bool validateConfirm()
        {
            error = new ErrorProvider();
            bool flag = false;
            if (txtTransID.Text.Length == 0)
            {
                txtTransID.Focus();
                error.SetError(txtTransID, "Please, enter the transaction ID!");
                error.BlinkRate = 250;
                flag = true;
            }
            if(ExposeProperties.DepartmentStatus == true)
            {
                if (txtTransID.Text.Length == 0)
                {
                    txtTransID.Focus();
                    error.SetError(txtTransID, "Please, enter the account number");
                    error.BlinkRate = 250;
                    flag = true;
                }
            }
            return flag;
        }
        private void reverseTransaction()
        {
            long transID2, amount, balance;
            try
            {
                transID = Convert.ToInt64(txtTransID.Text);
                long pfBalance;
                db.connect();
                db.getTransID(transID);
                db.getConnection.Close();
                tb = new DataTable();
                db.getDataAdapter.Fill(tb);
                transID2 = (long)tb.Rows[0]["TransLogID"];
                amount = (long)tb.Rows[0]["Amount"];
                pfBalance = (long)tb.Rows[0]["Balance"];

                if (transID == transID2)
                {
                    db.connect();
                    db.getBalance(ExposeProperties.AccNumber);
                    db.getConnection.Close();
                    DataSet dataSet = new DataSet();
                    db.getDataAdapter.Fill(dataSet, "BalanceUpdate");
                    balance = (long)dataSet.Tables["BalanceUpdate"].Rows[0]["Balance"];

                    if (pfBalance == 0)
                    {
                        if (amount <= balance)
                        {
                            if (MessageBox.Show("Are you sure you want to delete this transaction", "Confirm Reversal",
                                 MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                db.connect();
                                db.wrongPost(transID);
                                db.getConnection.Close();
                                tb = new DataTable();
                                db.getDataAdapter.Fill(tb);

                                sSMessage.Visible = true;
                                tSSMessage.Text = "Transaction reversed successfully.";
                            }
                        }
                        else
                        {
                            sSMessage.Visible = true;
                            tSSMessage.Text = "Sorry! Amount is greater than the balance";
                        }
                    }
                    else if (pfBalance == 1)//Withdrawal reversal
                    {
                        if (MessageBox.Show("Are you sure you want to delete this transaction", "Confirm Reversal",
                                 MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            db.connect();
                            db.wrongPost(transID);
                            db.getConnection.Close();
                            tb = new DataTable();
                            db.getDataAdapter.Fill(tb);

                            sSMessage.Visible = true;
                            tSSMessage.Text = "Transaction reversed successfully.";
                        }
                    }
                    else
                    {
                        if (amount <= pfBalance)
                        {
                            if (MessageBox.Show("Are you sure you want to delete this transaction", "Confirm Reversal",
                                 MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                db.connect();
                                db.wrongPost(transID);
                                db.getConnection.Close();
                                tb = new DataTable();
                                db.getDataAdapter.Fill(tb);

                                sSMessage.Visible = true;
                                tSSMessage.Text = "Transaction reversed successfully.";
                            }
                        }
                        else
                        {
                            sSMessage.Visible = true;
                            tSSMessage.Text = "Sorry! Amount is greater than the balance";
                        }
                    }
                }
            }
            catch (IndexOutOfRangeException idx)
            {
                sSMessage.Visible = true;
                tSSMessage.Text = "Transaction ID is invalid!";
                lblShowAccNo.Visible = false;
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
        private void btnReverse_Click(object sender, EventArgs e)
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
                        reverseTransaction();
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
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtTransID.Text = "";
            sSMessage.Visible = false;
            lblShowAccNo.Visible = false;
        }
        private string getCustDetails(long accNumber)
        {
            string fName, mName, lName, sender;

            //Getting customer's details
            db.connect();
            db.custDetails(accNumber);
            db.getConnection.Close();
            tb = new DataTable();
            db.getDataAdapter.Fill(tb);

            //Initializing the string variables
            fName = tb.Rows[0]["FirstName"].ToString();
            mName = tb.Rows[0]["MiddleName"].ToString();
            lName = tb.Rows[0]["LastName"].ToString();

            //Assigning values to labels
            sender = fName + " " + mName + " " + lName;
            return sender;
        }
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (validateConfirm() == false)
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
                            try
                            {
                                long transID2, transID = Convert.ToInt64(txtTransID.Text);
                                db.connect();
                                db.getTransID(transID);
                                db.getConnection.Close();
                                tb = new DataTable();
                                db.getDataAdapter.Fill(tb);
                                accNumber = (long)tb.Rows[0]["accountNumber"];
                                transID2 = (long)tb.Rows[0]["TransLogID"];
                                ExposeProperties.AccNumber = accNumber;

                                if (transID == transID2)
                                {
                                    lblShowAccNo.Visible = true;
                                    lblShowAccNo.Text = accNumber.ToString() + " - " + getCustDetails(accNumber);
                                    btnReverse.Visible = true;
                                    btnClear.Visible = true;
                                    sSMessage.Visible = false;
                                    error.Clear();
                                }
                            }
                            catch (FormatException fe)
                            {
                                sSMessage.Visible = false;
                                lblShowAccNo.Visible = false;
                                MessageBox.Show("Sorry, number expected!");
                            }
                            catch (IndexOutOfRangeException idx)
                            {
                                sSMessage.Visible = true;
                                tSSMessage.Text = "Transaction ID is invalid!";
                                lblShowAccNo.Visible = false;
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
        private void comboCat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboCat.SelectedItem.Equals("Reverse Transaction"))
            {
                pan.Visible = true;
                lblTransID.Visible = true;
                txtTransID.Visible = true;
                btnConfirm.Visible = true;
            }
        }
        private void EditTransaction_Load(object sender, EventArgs e)
        {
            if (ExposeProperties.DepartmentStatus == true)
            {
                pan.Visible = true;
                comboCat.Visible = false;
                lblTransID.Visible = true;
                txtTransID.Visible = true;
                btnConfirm.Visible = true;
            }
        }
    }
}
