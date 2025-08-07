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
    public partial class Disbursement : Form
    {
        private DatabaseLib db = new DatabaseLib();
        private DataSet dataSet, dataSet2;
        private DataTable tb;
        private string sub;
        private ErrorProvider errorProvider = new ErrorProvider();
        static long accNumber, amount, principal;
        static int duration;
        private static string termsOfPayment;
        public Disbursement()
        {
            InitializeComponent();
            getAccountOfficer();
            datePicker.Text = databaseDate().ToShortDateString();
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
        private void getAccountOfficer()
        {
            try
            {
                string accountOfficer = "ACCOUNT OFFICER";
                db.connect();
                db.getAccountOfficer(accountOfficer);
                db.getConnection.Close();
                tb = new DataTable();
                db.getDataAdapter.Fill(tb);

                foreach (DataRow dr in tb.Rows)
                {
                    comboAccOff.Items.Add(dr["FirstName"].ToString());
                }
            }
            catch (SqlException sql)
            {
                MessageBox.Show(sql.Message);
            }
        }
        private string termsOfPaymentCheck()
        {
            if (radDaily.Checked == true)
            {
                termsOfPayment = radDaily.Text;
            }
            else if (radWeekly.Checked == true)
            {
                termsOfPayment = radWeekly.Text;
            }
            else
            {
                termsOfPayment = radMonthly.Text;
            }
            return termsOfPayment;
        }
        private long getAmount()
        {
            try
            {
                accNumber = Convert.ToInt64(txtAccNumber.Text);
                db.connect();
                db.custDetails(accNumber);
                db.getConnection.Close();
                DataTable table = new DataTable();
                db.getDataAdapter.Fill(table);
                string accountType = table.Rows[0]["AccountType"].ToString();

                if (radDaily.Checked == true)
                {
                    if (accountType.Equals("Ajo"))
                    {
                        amount = (long)(ExposeProperties.TotAmount / 20);
                    }
                    else
                    {
                        amount = (long)(ExposeProperties.TotAmount / (duration * 20));
                    }
                }
                else if (radWeekly.Checked == true)
                {
                    if (accountType.Equals("Ajo"))
                    {
                        amount = (long)(ExposeProperties.TotAmount / 4);
                    }
                    else
                    {
                        amount = (long)(ExposeProperties.TotAmount / (duration * 4));
                    }
                }
                else
                {
                    if (accountType.Equals("Ajo"))
                    {
                        amount = (long)(ExposeProperties.TotAmount / 1);
                    }
                    else
                    {
                        amount = (long)(ExposeProperties.TotAmount / duration);
                    }
                }
            }
            catch (DivideByZeroException dze)
            {
                MessageBox.Show("Sorry! You can't divide any number by zero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return amount;
        }
        private void converter()
        {
            try
            {
                accNumber = Convert.ToInt64(txtAccNumber.Text);
                principal = Convert.ToInt64(txtPrincipal.Text);
                duration = Convert.ToInt32(txtDuration.Text);
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Please, enter number(s) only", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            }
        }
        private float getPercent()
        {
            float percentFormula = 0.05f;
            duration = int.Parse(txtDuration.Text);
            principal = long.Parse(txtPrincipal.Text);

            ExposeProperties.Percent = (float)(percentFormula * principal * duration);

            return ExposeProperties.Percent;
        }
        private float interestConverter()
        {
            float percentInput = float.Parse(txtPercent.Text);
            float percentFormula = percentInput / 100, percent = 0.0f;
            accNumber = long.Parse(txtAccNumber.Text);
            duration = int.Parse(txtDuration.Text);
            principal = long.Parse(txtPrincipal.Text);

            if (percentInput == 0)
            {
                percent = 0;
                ExposeProperties.Percent = percent;
            }
            else
            {
                percent = (percentFormula * principal * duration);
                ExposeProperties.Percent = percent;
            }

            return percent;
        }
        //Extend loan 
        private float extendPercent()
        {
            float percent = 0.0f;
            try
            {
                float percentInput = float.Parse(txtPercent.Text);
                float percentFormula = percentInput / 100;
                accNumber = long.Parse(txtAccNumber.Text);
                duration = int.Parse(txtDuration.Text);

                db.connect();
                db.loanBalance(accNumber);
                db.getConnection.Close();
                tb = new DataTable();
                db.getDataAdapter.Fill(tb);

                long loan = (long)tb.Rows[0]["Principal"];

                percent = (float)(percentFormula * loan * duration);

            }
            catch (FormatException fe)
            {
                percent = 6;
            }
            return percent;
        }
        private void extendLoan()
        {
            try
            {
                DateTime ExtendDate, convert, date;
                accNumber = long.Parse(txtAccNumber.Text);
                long loan;
                int duration = int.Parse(txtDuration.Text);
                //Getting loan amount
                db.connect();
                db.loanBalance(accNumber);
                db.getConnection.Close();
                tb = new DataTable();
                db.getDataAdapter.Fill(tb);
                loan = (long)tb.Rows[0]["Principal"];
                string dbDate = tb.Rows[0]["MaturityDate"].ToString();
                convert = DateTime.Parse(dbDate);
                ExtendDate = convert.AddMonths(duration);
                float amt = loan + extendPercent();
                string reConvertDate = ExtendDate.ToString("yyyy-MM-dd");
                date = DateTime.Parse(reConvertDate);
                try
                {
                    db.connect();
                    db.getExtendLoan(accNumber);
                    db.getConnection.Close();
                    DataTable tb2 = new DataTable();
                    db.getDataAdapter.Fill(tb2);
                    long accNo = (long)tb2.Rows[0]["AccountNumber"];

                    if (accNumber == accNo)
                    {
                        if (extendPercent() == 6)
                        {
                            MessageBox.Show("Please check the percent checkbox and enter the percentage value",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            //Extending customer's loan
                            db.connect();
                            db.updateExtendLoan(accNumber, date, amt);
                            tb = new DataTable();
                            db.getDataAdapter.Fill(tb);

                            sSMessage.Visible = true;
                            tSSMessage.Text = " Loan has been extended!";
                        }
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    if (extendPercent() == 6)
                    {
                        MessageBox.Show("Please check the percent checkbox and enter the percentage value",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        db.connect();
                        db.extendLoan(accNumber, date, amt);
                        db.getConnection.Close();
                        tb = new DataTable();
                        db.getDataAdapter.Fill(tb);

                        sSMessage.Visible = true;
                        tSSMessage.Text = " Loan has been extended!";
                    }
                }

            }
            catch (FormatException fe)
            {
                MessageBox.Show("Please fill the text boxe(s) with the respective information!",
                       "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (SqlException sql)
            {

            }
        }
        private void getDisburseLoan()
        {
            ExposeProperties.DisburseDate = datePicker.Text;
            db.connect();
            db.disburseLoan(ExposeProperties.AccNumber, ExposeProperties.Duration, ExposeProperties.TotAmount, ExposeProperties.TermsOfPayment,
            ExposeProperties.DisburseDate, ExposeProperties.MaturityDate, ExposeProperties.Time, "Not Balanced", ExposeProperties.Amount, ExposeProperties.Principal, ExposeProperties.AccountOfficer);
            db.getConnection.Close();
            dataSet = new DataSet();
            db.getDataAdapter.Fill(dataSet, "LoanCustomer");

            db.connect();// Vault transaction implementation 
            db.vaultDebit(ExposeProperties.BranchCode, ExposeProperties.Principal);
            db.getConnection.Close();
            DataTable tb2 = new DataTable();
            db.getDataAdapter.Fill(tb2);
        }
        private void updateDisburseLoan()
        {
            ExposeProperties.DisburseDate = datePicker.Text;
            db.connect();
            db.updateDisburseLoan(ExposeProperties.AccNumber, ExposeProperties.Duration, ExposeProperties.TotAmount, ExposeProperties.TermsOfPayment,
            ExposeProperties.DisburseDate, ExposeProperties.MaturityDate, ExposeProperties.Time, "Not Balanced", ExposeProperties.Amount, ExposeProperties.Principal, ExposeProperties.AccountOfficer);
            db.getConnection.Close();
            dataSet = new DataSet();
            db.getDataAdapter.Fill(dataSet, "LoanCustomer");

            db.connect();// Vault transaction implementation 
            db.vaultDebit(ExposeProperties.BranchCode, ExposeProperties.Principal);
            db.getConnection.Close();
            DataTable tb2 = new DataTable();
            db.getDataAdapter.Fill(tb2);
        }
        private int validateLoan()
        {
            int flag = 0;
            if (txtAccNumber.Text == "")
            {
                txtAccNumber.Focus();
                errorProvider.SetError(txtAccNumber, "Please, enter the account number!");
                flag = 1;
            }
            if (txtDuration.Text == "")
            {
                txtDuration.Focus();
                errorProvider.SetError(txtDuration, "Please, enter loan duration!");
                flag = 1;
            }
            if (txtPrincipal.Text == "")
            {
                txtPrincipal.Focus();
                errorProvider.SetError(txtPrincipal, "Please, enter loan amount!");
                flag = 1;
            }
            if (comboAccOff.Text.Equals(""))
            {
                comboAccOff.Focus();
                errorProvider.SetError(comboAccOff, "Please select an account officer!");
                flag = 1;
            }
            return flag;
        }
        private void customerLoanDetails()
        {
            try
            {
                accNumber = Convert.ToInt64(txtAccNumber.Text);
                string fName, mName, lName;
                db.connect();
                db.custDetails(accNumber);
                db.getConnection.Close();
                tb = new DataTable();
                db.getDataAdapter.Fill(tb);

                //Initializing the string variables
                lblNames.Visible = true;
                fName = tb.Rows[0]["FirstName"].ToString();
                mName = tb.Rows[0]["MiddleName"].ToString();
                lName = tb.Rows[0]["LastName"].ToString();
                lblNames.Text = fName + " " + mName + " " + lName;
            }
            catch (FormatException e)
            {
                MessageBox.Show(e.Message);
            }
            catch (IndexOutOfRangeException e)
            {
                lblNames.Visible = true;
                lblNames.Text = "Account number is invalid!";
            }
        }
        private void extend()
        {
            if (Home.SendNotification == "Extension")
            {
                this.btnExtend.Location = new System.Drawing.Point(192, 250);

                lblTitle.Text = "Loan Extension";
                linkGuarantor.Enabled = false;
                groupTermOfPay.Enabled = false;
                btnDisburse.Visible = false;
                btnExtend.Visible = true;
                checkGuarantor.Enabled = false;
                lblPrincipal.Visible = false;
                txtPrincipal.Visible = false;
                asterisksPrincipal.Visible = false;
                datePicker.Enabled = false;
                comboAccOff.Visible = false;
                lblAccOfficer.Visible = false;
                asteriskAccOfficer.Visible = false;
            }
            else
            {
                lblTitle.Text = "Loan Disbursement";
                linkGuarantor.Enabled = true;
                groupTermOfPay.Enabled = true;
                btnDisburse.Text = "Disburse";
                btnExtend.Visible = false;
                checkGuarantor.Enabled = true;
                lblPrincipal.Visible = true;
                txtPrincipal.Visible = true;
                asterisksPrincipal.Visible = true;
                comboAccOff.Visible = true;
                lblAccOfficer.Visible = true;
                asteriskAccOfficer.Visible = true;
            }
        }
        private void Disbursement_Load(object sender, EventArgs e)
        {
            extend();
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
        private void txtAccNumber_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }
        private void txtPrincipal_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }
        private void txtDuration_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtAccNumber.Text = "";
            txtDuration.Text = "";
            txtPercent.Text = "";
            txtPrincipal.Text = "";
        }
        private void checkGuarantor_CheckedChanged(object sender, EventArgs e)
        {
            btnDisburse.Text = "Continue";
            if (checkGuarantor.Checked == false)
            {
                btnDisburse.Text = "Disburse";
            }
        }
        private void checkPercent_CheckedChanged(object sender, EventArgs e)
        {
            pan.Visible = true;

            if (checkPercent.Checked == false)
            {
                pan.Visible = false;
            }
        }
        private void btnDisburse_Click(object sender, EventArgs e)
        {
            if (validateLoan() == 0)
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
                                accNumber = Convert.ToInt64(txtAccNumber.Text);
                                principal = Convert.ToInt64(txtPrincipal.Text);
                                duration = Convert.ToInt32(txtDuration.Text);

                                db.connect();
                                db.balanceUpdate(accNumber);
                                db.getConnection.Close();
                                dataSet = new DataSet();
                                db.getDataAdapter.Fill(dataSet, "BalanceUpdate");
                                long accNumber2 = (long)dataSet.Tables["BalanceUpdate"].Rows[0]["AccountNumber"];
                                if (accNumber == accNumber2)
                                {
                                    db.connect();
                                    db.custDetails(accNumber);
                                    db.getConnection.Close();
                                    DataTable table = new DataTable();
                                    db.getDataAdapter.Fill(table);
                                    string accountType = table.Rows[0]["AccountType"].ToString();

                                    if ((accountType == "SAVINGS") || (accountType == "TARGET"))
                                    {
                                        MessageBox.Show("The account number you entered is not a loan account!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                    else
                                    {
                                        ExposeProperties.AccNumber = accNumber;
                                        ExposeProperties.Principal = principal;
                                        if (accountType.Equals("AJO"))
                                        {
                                            ExposeProperties.Duration = 1;
                                        }
                                        else
                                        {
                                            ExposeProperties.Duration = duration;
                                        }
                                        //String values
                                        ExposeProperties.TermsOfPayment = termsOfPaymentCheck();
                                        ExposeProperties.DisburseDate = datePicker.Text;
                                        ExposeProperties.MaturityDate = datePicker.Value.AddMonths(ExposeProperties.Duration).ToString("yyyy-MM-dd");
                                        ExposeProperties.Time = databaseDate().ToLongTimeString().ToString();
                                        if (checkPercent.Checked == true)
                                        {
                                            ExposeProperties.Percent = interestConverter();
                                        }
                                        else
                                        {
                                            ExposeProperties.Percent = (float)getPercent();
                                        }
                                        ExposeProperties.TotAmount = (long)(ExposeProperties.Principal + ExposeProperties.Percent);
                                        ExposeProperties.Amount = getAmount();
                                        ExposeProperties.AccountOfficer = comboAccOff.SelectedItem.ToString();
                                        DateTime sysDate, dbDate;

                                        sysDate = DateTime.Parse(datePicker.Value.ToShortDateString());
                                        dbDate = DateTime.Parse(new Home().databaseDate().ToShortDateString());

                                        int compareDate = (DateTime.Compare(sysDate, dbDate));
                                        if (compareDate >= 1)
                                        {
                                            MessageBox.Show("Sorry, no future date is allowed", "Error",
                                            MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                        }
                                        else
                                        {
                                            try
                                            {
                                                db.exist(accNumber);
                                                db.getConnection.Close();
                                                dataSet2 = new DataSet();
                                                db.getDataAdapter.Fill(dataSet2, "LoanCustomer");
                                                long accNo = (long)dataSet2.Tables["LoanCustomer"].Rows[0]["AccountNumber"];
                                                if (accNumber == accNo)
                                                {
                                                    try
                                                    {
                                                        db.connect();
                                                        db.loanChecker(ExposeProperties.AccNumber);
                                                        db.getConnection.Close();
                                                        DataTable tb = new DataTable();
                                                        db.getDataAdapter.Fill(tb);
                                                        long accountNumer = (long)tb.Rows[0]["AccountNumber"];

                                                        if (ExposeProperties.AccNumber == accountNumer)
                                                        {
                                                            MessageBox.Show("Please balance the initial loan before redisbursing!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                        }
                                                    }
                                                    catch (IndexOutOfRangeException idx)
                                                    {
                                                        DateTime dt = new Home().databaseDate();
                                                        db.connect();// Vault transaction implementation 
                                                        db.vaultBalance(dt.ToShortDateString(), ExposeProperties.BranchCode);
                                                        db.getConnection.Close();
                                                        DataTable vault = new DataTable();
                                                        db.getDataAdapter.Fill(vault);
                                                        long vaultwithdrawalBalance = (long)vault.Rows[0]["WithdrawalBalance"];

                                                        if (principal <= vaultwithdrawalBalance)
                                                        {
                                                            if (btnDisburse.Text == "Continue")
                                                            {
                                                                updateDisburseLoan();
                                                                new Guarantor().Show();
                                                                Hide();
                                                            }
                                                            else
                                                            {
                                                                updateDisburseLoan();
                                                                new DisbursementDetails().Show();
                                                                Hide();
                                                            }
                                                        }
                                                        else
                                                        {
                                                            MessageBox.Show("Insufficient vault balance", "Balance",
                                                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                        }
                                                    }
                                                }
                                            }

                                            catch (IndexOutOfRangeException ex)
                                            {
                                                DateTime dt = new Home().databaseDate();
                                                db.connect();// Vault transaction implementation 
                                                db.vaultBalance(dt.ToShortDateString(), ExposeProperties.BranchCode);
                                                db.getConnection.Close();
                                                DataTable vault = new DataTable();
                                                db.getDataAdapter.Fill(vault);
                                                long vaultwithdrawalBalance = (long)vault.Rows[0]["WithdrawalBalance"];

                                                if (principal <= vaultwithdrawalBalance)
                                                {
                                                    if (btnDisburse.Text == "Continue")
                                                    {
                                                        getDisburseLoan();
                                                        new Guarantor().Show();
                                                        Hide();
                                                    }
                                                    else
                                                    {
                                                        getDisburseLoan();
                                                        new DisbursementDetails().Show();
                                                        Hide();
                                                    }
                                                }
                                                else
                                                {
                                                    MessageBox.Show("Insufficient vault balance", "Balance",
                                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            catch (IndexOutOfRangeException ex)
                            {
                                sSMessage.Visible = true;
                                tSSMessage.Text = "Account number doesn't exist";
                            }
                            catch (FormatException ex)
                            {
                                MessageBox.Show("Number required!", "Invalid Input", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                            }
                            catch (ArgumentOutOfRangeException aore)
                            {

                            }
                            catch (NullReferenceException ex)
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
        private void btnExtend_Click(object sender, EventArgs e)
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
                        extendLoan();
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
        private void linkGuarantor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Guarantor().Show();
            Hide();
        }
        private void txtPrincipal_MouseHover(object sender, EventArgs e)
        {
            if (txtAccNumber.Text.Length != 0)
            {
                customerLoanDetails();
            }
            else
            {
                lblNames.Visible = true;
                lblNames.Text = "Please enter the account number first!";
            }
        }
    }
}
