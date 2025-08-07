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
using System.IO;
using DatabaseLibrary;
using System.Globalization;

namespace SoftlightMF
{
    public partial class AccountStatement : Form
    {
        ExposeProperties log = new ExposeProperties();
        DatabaseLib db = new DatabaseLib();
        long accNumber;
        DataTable tb;
        string sub;
        public AccountStatement()
        {
            InitializeComponent();
            datePickerFrom.Value = new Home().databaseDate();
            datePickerTo.Value = new Home().databaseDate();
            checkAllRecords.Checked = true;
        }
        private void bvn()
        {
            try
            {
                string bvn = txtAccNo.Text, dbBvn;
                db.connect();
                db.getBvn(bvn);
                db.getConnection.Close();
                DataTable getBvn = new DataTable();
                db.getDataAdapter.Fill(getBvn);
                dbBvn = getBvn.Rows[0]["Bvn"].ToString();

                db.connect();
                db.bvnConfirmation(bvn);
                db.getConnection.Close();
                tb = new DataTable();
                db.getDataAdapter.Fill(tb);

                if (dbBvn.Equals(bvn))
                {
                    pan.Visible = false;
                    dataGridView.Visible = true;
                    dataGridView.DataSource = tb;
                    btnPrint.Visible = false;
                }
            }
            catch (FormatException fe)
            {
                sSMessage.Visible = true;
                tSSMessage.Text = "Wrong input! Number required.";
            }
            catch (OverflowException ofe)
            {
                MessageBox.Show(ofe.Message);
            }
            catch (IndexOutOfRangeException idx)
            {
                dataGridView.Visible = false;
                pan.Visible = false;
                pan2.Visible = false;
                btnPrint.Visible = false;
                sSMessage.Visible = true;
                tSSMessage.Text = "Bvn number does not exist";
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void transID()
        {
            try
            {
                long transID = long.Parse(txtAccNo.Text), dbTransID;
                db.connect();
                db.getTransLogID(transID);
                db.getConnection.Close();
                DataTable tbTransID = new DataTable();
                db.getDataAdapter.Fill(tbTransID);
                dbTransID = (long)tbTransID.Rows[0]["TransLogID"];

                if (transID == dbTransID)
                {
                    pan.Visible = false;
                    dataGridView.Visible = true;
                    dataGridView.DataSource = tbTransID;
                    btnPrint.Visible = false;
                    sSMessage.Visible = false;
                }
            }
            catch (FormatException fe)
            {
                sSMessage.Visible = true;
                tSSMessage.Text = "Wrong input! Number required.";
            }
            catch (OverflowException ofe)
            {
                MessageBox.Show(ofe.Message);
            }
            catch (IndexOutOfRangeException idx)
            {
                dataGridView.Visible = false;
                pan.Visible = false;
                pan2.Visible = false;
                btnPrint.Visible = false;
                sSMessage.Visible = true;
                tSSMessage.Text = "Transaction ID does not exist";
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void getAllRecords(long accNo)
        {
            try
            {
                ExposeProperties.TransactionType = "All";

                db.connect();
                db.getAllTransactionLog(accNo);
                db.getConnection.Close();
                tb = new DataTable();
                db.getDataAdapter.Fill(tb);

                dataGridView.Visible = true;
                dataGridView.DataSource = tb;
                pan.Visible = true;
                pan2.Visible = true;
                btnPrint.Visible = true;

                if (txtAccNo.Text == "")
                {
                    dataGridView.Visible = false;
                    pan.Visible = false;
                    pan2.Visible = false;
                    btnPrint.Visible = false;
                }
            }
            catch (FormatException fe)
            {
                sSMessage.Visible = true;
                tSSMessage.Text = "Wrong input! Number required.";
            }
            catch (OverflowException ofe)
            {
                MessageBox.Show(ofe.Message);
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void getPassport(long accNo)
        {
            try
            {
                db.connect();
                db.getPhoto(accNo);
                db.getConnection.Close();
                DataTable tbPhoto = new DataTable();
                db.getDataAdapter.Fill(tbPhoto);
                byte[] img = (byte[])tbPhoto.Rows[0]["Photo"];
                picCustomer.Visible = true;
                picCustomer.Image = Image.FromStream(new MemoryStream(img));
            }
            catch (InvalidCastException ice)
            {
                picCustomer.Image = null;
            }
            catch (ArgumentException ae)
            {
                picCustomer.Image = null;
            }
            catch (IndexOutOfRangeException idx)
            {
                picCustomer.Image = null;
            }
        }
        private void getCustDetails(long accNum)
        {

            string fName, mName, lName, address, phone, gender, dob, accNo, accType;

            //Getting customer's details
            db.connect();
            db.custDetails(accNum);
            db.getConnection.Close();
            tb = new DataTable();
            db.getDataAdapter.Fill(tb);

            //Initializing the string variables
            fName = tb.Rows[0]["FirstName"].ToString();
            mName = tb.Rows[0]["MiddleName"].ToString();
            lName = tb.Rows[0]["LastName"].ToString();
            address = tb.Rows[0]["Address"].ToString();
            phone = tb.Rows[0]["PhoneNumber"].ToString();
            gender = tb.Rows[0]["Gender"].ToString();
            accNo = tb.Rows[0]["AccountNumber"].ToString();
            accType = tb.Rows[0]["AccountType"].ToString();
            getPassport(accNum);

            //Assigning values to labels
            lblFullName.Text = fName + " " + mName + " " + lName;
            lblAddress.Text = address;
            lblPhone.Text = phone;
            lblGender.Text = gender;
            lblAccNo.Text = accNo;
            ExposeProperties.AccountTypeReport = accType;
            lblAccType.Text = accType;
            ExposeProperties.FullName = lblFullName.Text;
        }
        private int validateStatement()
        {
            ErrorProvider errorProvider = new ErrorProvider();
            int flag = 0;
            if (txtAccNo.Text == "")
            {
                txtAccNo.Focus();
                errorProvider.SetError(txtAccNo, "Please, enter the account number!");
                flag = 1;
            }
            else
            {
                txtAccNo.Focus();
                errorProvider.Clear();
            }
            return flag;
        }
        private void getSpecificRecords(long accNo)
        {
            try
            {
                ExposeProperties.TransactionType = "Spec";
                string dateFrom = datePickerFrom.Text;
                string dateTo = datePickerTo.Text;

                ExposeProperties.FromDate = dateFrom;
                ExposeProperties.ToDate = dateTo;
                db.connect();
                db.getSpecificTransactionLog(accNo, dateFrom, dateTo);
                db.getConnection.Close();
                tb = new DataTable();
                db.getDataAdapter.Fill(tb);

                dataGridView.Visible = true;
                dataGridView.DataSource = tb;
                pan.Visible = true;
                pan2.Visible = true;
                btnPrint.Visible = true;

                if (txtAccNo.Text == "")
                {
                    dataGridView.Visible = false;
                    pan.Visible = false;
                    pan2.Visible = false;
                    btnPrint.Visible = false;
                }
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
            catch (FormatException fe)
            {
                txtAccNo.Focus();
                errorProvider.SetError(txtAccNo, "Wrong input! Number required.");
            }
            catch (OverflowException ofe)
            {
                MessageBox.Show(ofe.Message);
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (validateStatement() == 0)
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
                                if (checkAllRecords.Checked == true && checkBvn.Checked == false && checkTransID.Checked == false)
                                {
                                    accNumber = Convert.ToInt64(txtAccNo.Text);
                                    getAllRecords(accNumber);
                                    getCustDetails(accNumber);
                                    getPassport(accNumber);
                                    sSMessage.Visible = false;
                                }
                                else if (checkAllRecords.Checked == false && checkBvn.Checked == false && checkTransID.Checked == false)
                                {
                                    accNumber = Convert.ToInt64(txtAccNo.Text);
                                    getSpecificRecords(accNumber);
                                    getCustDetails(accNumber);
                                    getPassport(accNumber);
                                    sSMessage.Visible = false;
                                }
                                else if (checkBvn.Checked == true && checkTransID.Checked == false)
                                {
                                    bvn();
                                }
                                else if (checkBvn.Checked == false && checkTransID.Checked == true)
                                {
                                    transID();
                                }
                                else
                                {
                                    dataGridView.Visible = false;
                                    sSMessage.Visible = false;
                                }
                            }
                            catch (FormatException fe)
                            {
                                txtAccNo.Focus();
                                errorProvider.SetError(txtAccNo, "Wrong input! Number required.");
                            }
                            catch (IndexOutOfRangeException ex)
                            {
                                dataGridView.Visible = false;
                                pan.Visible = false;
                                pan2.Visible = false;
                                btnPrint.Visible = false;
                                sSMessage.Visible = true;
                                tSSMessage.Text = "Account number does not exist!";
                            }
                            catch (SqlException ex)
                            {
                                MessageBox.Show(ex.Message);
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
        private void checkSearch_CheckedChanged(object sender, EventArgs e)
        {
            pan2.Visible = false;
            btnSearch.Visible = false;
            picCustomer.Visible = false;
            btnPrint.Visible = false;
            lblSearch.Text = "Search Customer:";
            if (checkSearch.Checked == false)
            {
                lblSearch.Text = "Account Number:";
                btnSearch.Visible = true;
                dataGridView.Visible = false;
            }
        }
        private void checkAllRecords_Checked(object sender, EventArgs e)
        {
            panDate.Visible = false;
            if (checkAllRecords.Checked == false)
            {
                panDate.Visible = true;
                picCustomer.Visible = false;
                dataGridView.Visible = false;
            }
        }
        private void txtAccNo_TextChanged(object sender, EventArgs e)
        {
            if (txtAccNo.Text == "")
            {
                dataGridView.Visible = false;
                pan.Visible = false;
                pan2.Visible = false;
            }
            if (checkSearch.Checked == true)
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
                                string search = txtAccNo.Text, middleName;
                                db.connect();
                                db.searchCustomer(search);
                                db.getConnection.Close();
                                tb = new DataTable();
                                db.getDataAdapter.Fill(tb);
                                middleName = tb.Rows[0]["MiddleName"].ToString();
                                sSMessage.Visible = false;
                                if (middleName == "" && txtAccNo.Text == "")
                                {
                                    dataGridView.Visible = false;
                                }
                                else
                                {
                                    dataGridView.Visible = true;
                                    dataGridView.DataSource = tb;
                                }
                            }
                            catch (IndexOutOfRangeException idx)
                            {
                                sSMessage.Visible = true;
                                tSSMessage.Text = "Sorry, name(s) doesn't exist";
                                dataGridView.Visible = false;
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
        private void btnPrint_Click(object sender, EventArgs e)
        {
            long accNo = long.Parse(txtAccNo.Text);
            string val = accNo.ToString();
            if (val.StartsWith(1.ToString()))
            {
                ExposeProperties.BranchName = "Ikotun";
            }
            else if (val.StartsWith(2.ToString()))
            {
                ExposeProperties.BranchName = "Egbeda";
            }
            else
            {
                ExposeProperties.BranchName = "Igando";
            }
            ExposeProperties.AccNumber = accNo;
            ExposeProperties.TransactionTypeStatus = "accountStatement";
            new Report.ReportForm.AccountStatementReportForm().Show();
        }
        private void checkBvn_CheckedChanged(object sender, EventArgs e)
        {
            pan2.Visible = false;
            if (checkBvn.Checked == false)
            {
                dataGridView.Visible = false;
                pan.Visible = false;
                pan2.Visible = false;
                btnPrint.Visible = false;
            }
        }
        private void checkTransID_CheckedChanged(object sender, EventArgs e)
        {
            lblSearch.Text = "Transaction ID";
            pan2.Visible = false;
            if (checkTransID.Checked == false)
            {
                lblSearch.Text = "Account Number";
                dataGridView.Visible = false;
                pan.Visible = false;
                pan2.Visible = false;
                btnPrint.Visible = false;
            }
        }
    }
}
