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
using SpeechLib;
using System.IO;
using DatabaseLibrary;
using System.Net;
using System.Globalization;

namespace SoftlightMF
{
    public partial class Home : Form
    {
        private ExposeProperties cl = new ExposeProperties();
        private DatabaseLib db = new DatabaseLib();
        private SpVoice voice = new SpVoice();
        CultureInfo provider;
        private static string sendNotification;
        private string hostName, sub;
        bool departmentStatus = true;
        string customerReg, statement, freeze, dashboard, branchSetup,
            withdrawal, depDate, withDate, balance, accountSetup, disburse, balanceLoan, deleteAccount,
            department, employee, extendLoan, generateCode, delSuspendUser, editTrans, logoutUser, report,
             changeDate, reportMonth, transType, close, groupReg, workHour, transReport, accountReport, loanPortfolio, branchTrans,
            performance, incomeOverview, callOver, otherUsers, thresholdSetup, transactionApproval, control, expenditure;
        public static string SendNotification
        {
            get { return sendNotification; }
            set { sendNotification = value; }
        }

        //Declaring and innitializing Data classes
        private DataTable tb, table2;
        private DataSet dataSet;
        long accNumber;
        public string accountNo, description;
        string transactionType, date, time;
        private long withdraw, deposit, transfer;
        private int charges = 0;
        private DateTime dt;
        int reminder;
        public Home()
        {
            InitializeComponent();
            getAccountOfficer();
            //linkNotify.Text = linkNotify.Text + getNotification();
            if (cl.getUser != null)
            {
                if (unreadMessage() > 0)
                {
                    lblCount.Text = unreadMessage().ToString();
                }
                else
                {
                    lblCount.Visible = false;
                }
            }
        }
        private int unreadMessage()
        {
            int countUnreadMessage = 0;
            try
            {
                db.connect();
                db.unreadMessage(cl.getUser);
                db.getConnection.Close();
                tb = new DataTable();
                db.getDataAdapter.Fill(tb);
                countUnreadMessage = (int)tb.Rows[0]["UnreadMessage"];
            }
            catch (IndexOutOfRangeException idx)
            {
                countUnreadMessage = 0;
            }
            return countUnreadMessage;
        }
        private int countLedger()
        {
            int countledger = 0;
            try
            {
                db.connect();
                db.countLedger();
                db.getConnection.Close();
                tb = new DataTable();
                db.getDataAdapter.Fill(tb);
                countledger = (int)tb.Rows[0]["CountLedger"];
            }
            catch (IndexOutOfRangeException idx)
            {
                countledger = 0;
            }
            return countledger;
        }
        private int getNotification()
        {
            DateTime convertMaturity;
            //try
            //{
            //    db.connect();
            //    db.notification();
            //    db.getConnection.Close();
            //    tb = new DataTable();
            //    db.getDataAdapter.Fill(tb);
            //    //string maturity = tb.Rows[0]["MaturityDate"].ToString();
            //    //convertMaturity = Convert.ToDateTime(maturity);
            //    foreach (DataRow k in tb.Rows)
            //    {
            //        // comboAccOff.Items.Add(k);
            //        //if ((dt.Year == convertMaturity.Year) && (dt.Month == convertMaturity.Month) && (dt.Day == convertMaturity.Day))
            //        //{
            //        // reminder = 4;
            //        //}
            //        //if ((dt.Year == comboAccOff.sele) && (dt.Month == convertMaturity.Month) && (dt.Day == convertMaturity.Day))
            //        //{
            //        //    // reminder = 4;
            //        //}

            //        //db.connect();
            //        //db.getNotification(convertMaturity.AddDays(-5));
            //        //db.getConnection.Close();
            //        //tb = new DataTable();
            //        //db.getDataAdapter.Fill(tb);
            //        //int countDefaultLoan = (int)tb.Rows[0]["DefaultLoan"];

            //        //if (dt == countDefaultLoan)

            //        //return countDefaultLoan;
            //    }
            //}
            //catch (IndexOutOfRangeException idx)
            //{
            //    linkNotify.Text = linkNotify.Text;
            //}
            return reminder;
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
                    comboDepAccOff.Items.Add(dr["FirstName"].ToString());
                    comboReportAccOfficer.Items.Add(dr["FirstName"].ToString());
                    comboQuickViewAccOfficer.Items.Add(dr["FirstName"].ToString());
                }
            }
            catch (SqlException sql)
            {
                MessageBox.Show(sql.Message);
            }
        }
        private void getVaultAccOfficer()//Vault implementation
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
                    comboDepAccOff.Items.Add(dr["FirstName"].ToString());
                }
            }
            catch (SqlException sql)
            {
                MessageBox.Show(sql.Message);
            }
        }
        private void getBranchName()
        {
            db.connect();
            db.getAutoGenerateDetails();
            db.getConnection.Close();
            DataTable tb = new DataTable();
            db.getDataAdapter.Fill(tb);
            foreach (DataRow dr in tb.Rows)
            {
                comboDepAccOff.Items.Add(dr["BranchName"].ToString());
            }
        }//Vault implementation
        private bool convert(string value)
        {
            bool converter = false;
            if (value.Equals("true"))
            {
                converter = true;
            }
            else
            {
                converter = false;
            }
            return converter;
        }
        private void getRole()//Edited
        {
            db.connect();
            db.getDepartmentRole(ExposeProperties.DepartmentID);
            db.getConnection.Close();
            DataTable tb = new DataTable();
            db.getDataAdapter.Fill(tb);

            customerReg = tb.Rows[0]["CustomerRegistration"].ToString();
            statement = tb.Rows[0]["StatementOfAccount"].ToString();
            freeze = tb.Rows[0]["Freeze"].ToString();
            dashboard = tb.Rows[0]["Dashboard"].ToString();
            branchSetup = tb.Rows[0]["BranchSetup"].ToString();
            string deposit = tb.Rows[0]["Deposit"].ToString();
            withdrawal = tb.Rows[0]["Withdrawal"].ToString();
            depDate = tb.Rows[0]["DepositDate"].ToString();
            withDate = tb.Rows[0]["WithdrawalDate"].ToString();
            balance = tb.Rows[0]["Balance"].ToString();
            accountSetup = tb.Rows[0]["AccountSetup"].ToString();
            disburse = tb.Rows[0]["Disburse"].ToString();
            balanceLoan = tb.Rows[0]["BalanceLoan"].ToString();
            deleteAccount = tb.Rows[0]["DeleteAccount"].ToString();
            department = tb.Rows[0]["Department"].ToString();
            employee = tb.Rows[0]["Employee"].ToString();
            extendLoan = tb.Rows[0]["ExtendLoan"].ToString();
            generateCode = tb.Rows[0]["GenerateCode"].ToString();
            delSuspendUser = tb.Rows[0]["DeleteSuspendUser"].ToString();
            editTrans = tb.Rows[0]["EditTransaction"].ToString();
            logoutUser = tb.Rows[0]["LogoutUser"].ToString();
            report = tb.Rows[0]["Report"].ToString();
            groupReg = tb.Rows[0]["GroupCreation"].ToString();
            workHour = tb.Rows[0]["WorkHour"].ToString();
            transReport = tb.Rows[0]["TransactionReport"].ToString();
            accountReport = tb.Rows[0]["AccountReport"].ToString();
            loanPortfolio = tb.Rows[0]["LoanPortfolio"].ToString();
            branchTrans = tb.Rows[0]["BranchTransaction"].ToString();
            performance = tb.Rows[0]["Performance"].ToString();
            incomeOverview = tb.Rows[0]["IncomeOverview"].ToString();
            callOver = tb.Rows[0]["CallOver"].ToString();
            otherUsers = tb.Rows[0]["OtherUsers"].ToString();
            thresholdSetup = tb.Rows[0]["ThresholdSetup"].ToString();
            transactionApproval = tb.Rows[0]["TransactionApproval"].ToString();
            expenditure = tb.Rows[0]["Expenditure"].ToString();

            linkCustReg.Enabled = convert(customerReg);
            linkAccStatement.Enabled = convert(statement);
            linkFreezeAcc.Enabled = convert(freeze);
            //linkFeedback.Enabled = convert(dashboard);
            //linkBranchSetup.Enabled = convert(branchSetup);
            btnDep.Enabled = convert(deposit);
            btnWith.Enabled = convert(withdrawal);
            datePicker.Enabled = convert(depDate);
            dateTransPicker.Enabled = convert(withDate);
            btnBal.Enabled = convert(balance);
            linkAccountSetup.Enabled = convert(accountSetup);
            linkDisLoan.Enabled = convert(disburse);
            linkBalanceLoan.Enabled = convert(balanceLoan);
            linkDelAcc.Enabled = convert(deleteAccount);
            linkDepartment.Enabled = convert(department);
            linkEmployee.Enabled = convert(employee);
            linkExtend.Enabled = convert(extendLoan);
            linkGenerateOTP.Enabled = convert(generateCode);
            linkDeleteUser.Enabled = convert(delSuspendUser);
            linkReverseTrans.Enabled = convert(editTrans);
            linkLogoutUser.Enabled = convert(logoutUser);
            linkReport.Enabled = convert(report);
            linkGroupReg.Enabled = convert(groupReg);
            tSTransReport.Enabled = convert(transReport);
            linkThreshold.Enabled = convert(thresholdSetup);
            linkTransactionApproval.Enabled = convert(transactionApproval);
            linkExpenditure.Enabled = convert(expenditure);
            ExposeProperties.ThresholdSetup = convert(thresholdSetup);
            ExposeProperties.AccountReport = convert(accountReport);
            ExposeProperties.LoanPortfolio = convert(loanPortfolio);
            ExposeProperties.BranchTrans = convert(branchTrans);
            ExposeProperties.Performance = convert(performance);
            ExposeProperties.IncomeOverview = convert(incomeOverview);
            ExposeProperties.CallOver = convert(callOver);
            ExposeProperties.OtherUsers = convert(otherUsers);
            ExposeProperties.Dashboard = convert(dashboard);

        }
        public string sendCustomerDepDetails(long accNumber)
        {
            string display = null;
            try
            {
                string fName, mName, lName;
                db.connect();
                db.custDetails(accNumber);
                db.getConnection.Close();
                tb = new DataTable();
                db.getDataAdapter.Fill(tb);

                //Initializing the string variables
                fName = tb.Rows[0]["FirstName"].ToString();
                mName = tb.Rows[0]["MiddleName"].ToString();
                lName = tb.Rows[0]["LastName"].ToString();
                display = fName + " " + mName + " " + lName;
            }
            catch (FormatException e)
            {
                display = e.Message;
            }
            catch (IndexOutOfRangeException e)
            {
                display = "Account number is invalid!";
            }
            return display;
        }
        private void customerDepDetails()
        {
            try
            {
                accNumber = Convert.ToInt64(txtDepAccNo.Text);
                string fName, mName, lName;
                db.connect();
                db.custDetails(accNumber);
                db.getConnection.Close();
                tb = new DataTable();
                db.getDataAdapter.Fill(tb);

                //Initializing the string variables
                lblDepCust.Visible = true;
                fName = tb.Rows[0]["FirstName"].ToString();
                mName = tb.Rows[0]["MiddleName"].ToString();
                lName = tb.Rows[0]["LastName"].ToString();
                lblDepCust.Text = fName + " " + mName + " " + lName;
            }
            catch (FormatException e)
            {
                MessageBox.Show(e.Message);
            }
            catch (IndexOutOfRangeException e)
            {
                lblDepCust.Visible = true;
                lblDepCust.Text = "Account number is invalid!";
            }
        }
        private void formVat()
        {
            transactionType = "Pf/Vat";
            hostName = Dns.GetHostName();
            try
            {
                accNumber = Convert.ToInt64(txtDepAccNo.Text);
                txtRecipientAccNo.Text = 0.ToString();
                long repAccNumber = Convert.ToInt64(txtRecipientAccNo.Text);
                deposit = Convert.ToInt64(txtDepAmt.Text);
                description = richDepositDescription.Text;

                if (deposit > 0)
                {
                    db.connect();
                    db.transactionLog(datePicker.Text, time, transactionType, deposit, charges, +
                    accNumber, repAccNumber, comboDepAccOff.Text, cl.getUser, hostName, description);
                    db.getConnection.Close();
                    tb = new DataTable();
                    db.getDataAdapter.Fill(tb);

                    db.connect();
                    db.getTrans();
                    db.getConnection.Close();
                    DataTable transID = new DataTable();
                    db.getDataAdapter.Fill(transID);
                    long dbTransID = (long)transID.Rows[0]["TransLogID"];

                    sSMessage.Visible = true;
                    tSSMessage.Text = " Posted N" + string.Format("{0:n}", deposit) + " as processing fee and Trans ID is " + dbTransID;
                    txtDepAccNo.Text = "";
                    txtDepAmt.Text = "";
                    richDepositDescription.Text = "";
                    checkPFVat.Checked = false;
                }
                else
                {
                    sSMessage.Visible = true;
                    tSSMessage.Text = " Cannot post N" + string.Format("{0:n}", deposit);
                }
            }
            catch (FormatException e)
            {
                MessageBox.Show("number(s) needed!");
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }//copying starts here
        private bool alertStatus()
        {
            bool status = false;
            try
            {
                db.connect();
                db.alertStatus();
                db.getConnection.Close();
                DataTable tb = new DataTable();
                db.getDataAdapter.Fill(tb);
                string dbStatus = tb.Rows[0]["Status"].ToString();

                if (dbStatus == "Activated")
                {
                    status = true;
                }
                else
                {
                    status = false;
                }
            }
            catch (IndexOutOfRangeException idx)
            {
                MessageBox.Show("Please check sms alert status", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException sql)
            {
                MessageBox.Show(sql.Message, "Error");
            }
            return status;
        }
        public string thresholdBulkDeposit(long accNumber, long deposit, string description)
        {
            string message = null;

            transactionType = "Deposit";
            hostName = Dns.GetHostName();
            dt = databaseDate();
            time = dt.ToString();
            date = dt.ToString("yyyy-MM-dd");
            txtRecipientAccNo.Text = 0.ToString();
            long repAccNumber = Convert.ToInt64(txtRecipientAccNo.Text);

            if (deposit > 0)
            {
                db.connect();
                db.transactionLog(date, time, transactionType, deposit, charges,
                accNumber, repAccNumber, ExposeProperties.AccountOfficer, cl.getUser, hostName, description);
                db.getConnection.Close();
                tb = new DataTable();
                db.getDataAdapter.Fill(tb);

                db.connect();
                db.getBalance(accNumber);
                db.getConnection.Close();
                dataSet = new DataSet();
                db.getDataAdapter.Fill(dataSet, "BalanceUpdate");
                long balance = (long)dataSet.Tables["BalanceUpdate"].Rows[0]["Balance"];

                if (alertStatus() == true)
                {
                    getAlert(accNumber, deposit, balance);
                }

                db.connect();
                db.getTrans();
                db.getConnection.Close();
                DataTable transID = new DataTable();
                db.getDataAdapter.Fill(transID);
                long dbTransID = (long)transID.Rows[0]["TransLogID"];

                message = "(" + accNumber + ") Deposited: N" + string.Format("{0:n}", deposit) + " | Balance: N" + string.Format("{0:n}", balance) +
                " and Trans ID is " + dbTransID;
            }
            else
            {
                message = " Cannot deposit N" + string.Format("{0:n}", deposit);
            }
            //}
            //catch (SqlException e)
            //{
            //    message = e.Message;
            //}
            return message;
        }
        private string bulkTransactionLedger(long accNumber, long deposit, string description)//description param to be added
        {
            string message = null;
            transactionType = "Deposit";
            hostName = Dns.GetHostName();
            dt = databaseDate();
            time = dt.ToString();
            date = dt.ToString("yyyy-MM-dd");

            txtRecipientAccNo.Text = 0.ToString();
            long repAccNumber = Convert.ToInt64(txtRecipientAccNo.Text);

            db.connect();
            db.transactionLedger(datePicker.Text, time, transactionType, deposit, charges,
            accNumber, repAccNumber, comboDepAccOff.Text, cl.getUser, hostName, description);
            db.getConnection.Close();
            tb = new DataTable();
            db.getDataAdapter.Fill(tb);
            message = "N" + string.Format("{0:n}", deposit) + " Bulk deposit transaction sent for approval";
            txtDepAccNo.Text = "";
            txtDepAmt.Text = "";
            sSMessage.Visible = false;

            return message;
        }
        public string bulkDeposit(long accNumber, long deposit, string description)
        {
            string message = null;
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
                    message = "Sorry! Account is closed";
                }
            }
            catch (IndexOutOfRangeException idx)
            {
                bool thresholdSetup = ExposeProperties.ThresholdSetup;
                try
                {
                    db.connect();
                    db.getThresholdSetup(ExposeProperties.DepartmentID);
                    db.getConnection.Close();
                    DataTable tb = new DataTable();
                    db.getDataAdapter.Fill(tb);
                    long dbDeposit = (long)tb.Rows[0]["BulkDeposit"];
                    string departmentID = tb.Rows[0]["DepartmentID"].ToString();

                    if (ExposeProperties.DepartmentID.Equals(departmentID))
                    {
                        //thresholdSetup == false && 
                        if (deposit <= dbDeposit)
                        {
                            message = thresholdBulkDeposit(accNumber, deposit, description);
                        }
                        else
                        {
                            message = bulkTransactionLedger(accNumber, deposit, description);
                        }
                    }
                }
                catch (IndexOutOfRangeException ioe)
                {
                    if (thresholdSetup == true)
                    {
                        thresholdBulkDeposit(accNumber, deposit, description);
                    }
                }
            }
            return message;
        }
        private void thresholdDeposit()
        {
            transactionType = "Deposit";
            hostName = Dns.GetHostName();
            try
            {
                txtRecipientAccNo.Text = 0.ToString();
                long repAccNumber = Convert.ToInt64(txtRecipientAccNo.Text);
                deposit = Convert.ToInt64(txtDepAmt.Text);
                description = richDepositDescription.Text;

                if (deposit > 0)
                {
                    db.connect();
                    db.transactionLog(datePicker.Text, time, transactionType, deposit, charges,
                    accNumber, repAccNumber, comboDepAccOff.Text, cl.getUser, hostName, description);
                    db.getConnection.Close();
                    tb = new DataTable();
                    db.getDataAdapter.Fill(tb);

                    db.connect();
                    db.getBalance(accNumber);
                    db.getConnection.Close();
                    dataSet = new DataSet();
                    db.getDataAdapter.Fill(dataSet, "BalanceUpdate");
                    long balance = (long)dataSet.Tables["BalanceUpdate"].Rows[0]["Balance"];

                    if (alertStatus() == true)
                    {
                        getAlert(accNumber, deposit, balance);
                    }

                    db.connect();
                    db.getTrans();
                    db.getConnection.Close();
                    DataTable transID = new DataTable();
                    db.getDataAdapter.Fill(transID);
                    long dbTransID = (long)transID.Rows[0]["TransLogID"];

                    sSMessage.Visible = true;
                    tSSMessage.Text = "Deposited N" + string.Format("{0:n}", deposit) + ", current balance is N" +
                        string.Format("{0:n}", balance) + " and Trans ID is " + dbTransID;
                    txtDepAccNo.Text = "";
                    txtDepAmt.Text = "";
                    richDepositDescription.Text = "";
                }
                else
                {
                    sSMessage.Visible = true;
                    tSSMessage.Text = " Cannot deposit N" + string.Format("{0:n}", deposit);
                }
            }
            catch (FormatException e)
            {
                //MessageBox.Show("number(s) needed!");
            }
            catch (SqlException e)
            {
                //MessageBox.Show(e.Message);
            }
        }
        private void depositTransactionLedger()
        {
            transactionType = "Deposit";
            hostName = Dns.GetHostName();

            txtRecipientAccNo.Text = 0.ToString();
            long repAccNumber = Convert.ToInt64(txtRecipientAccNo.Text);
            deposit = Convert.ToInt64(txtDepAmt.Text);
            description = richDepositDescription.Text;

            db.connect();
            db.transactionLedger(datePicker.Text, time, transactionType, deposit, charges,
            accNumber, repAccNumber, comboDepAccOff.Text, cl.getUser, hostName, description);
            db.getConnection.Close();
            tb = new DataTable();
            db.getDataAdapter.Fill(tb);
            MessageBox.Show("N" + string.Format("{0:n}", deposit) + " deposit transaction sent for approval", "Info",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtDepAccNo.Text = "";
            txtDepAmt.Text = "";
            richDepositDescription.Text = "";
            sSMessage.Visible = false;
        }
        private void withdrawalTransactionLedger()
        {
            transactionType = "Withdrawal";
            string accNo = 0.ToString();
            comboDepAccOff.Text = "";
            hostName = Dns.GetHostName();

            charges = Convert.ToInt32(txtWithCharges.Text);
            withdraw = Convert.ToInt64(txtWithAmt.Text);
            long accNumber1 = Convert.ToInt64(accNo);
            description = richWithTransDesc.Text;

            db.connect();
            db.transactionLedger(dateTransPicker.Text, time, transactionType, withdraw, charges, +
            accNumber, accNumber1, comboDepAccOff.Text, cl.getUser, hostName, description);
            db.getConnection.Close();
            dataSet = new DataSet();
            db.getDataAdapter.Fill(dataSet, "TransactionLedger");

            MessageBox.Show("N" + string.Format("{0:n}", withdraw) + " withdrawal transaction sent for approval",
                "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

            txtWithAccNo.Text = "";
            txtRecipientAccNo.Text = "";
            txtWithAmt.Text = "";
            txtWithCharges.Text = "";
            sSMessage.Visible = false;
        }
        private void transferTransactionLedger()
        {
            transactionType = "Transfer";
            comboDepAccOff.Text = "";
            hostName = Dns.GetHostName();

            long accNumber = Convert.ToInt64(txtWithAccNo.Text);
            long recipientAccNo = Convert.ToInt64(txtRecipientAccNo.Text);
            charges = Convert.ToInt32(txtWithCharges.Text);
            transfer = Convert.ToInt64(txtWithAmt.Text);
            description = richWithTransDesc.Text;
            db.connect();
            db.transactionLedger(dateTransPicker.Text, time, transactionType, transfer, charges, +
            accNumber, recipientAccNo, comboDepAccOff.Text, cl.getUser, hostName, description);
            db.getConnection.Close();
            dataSet = new DataSet();
            db.getDataAdapter.Fill(dataSet, "TransactionLog");

            MessageBox.Show("N" + string.Format("{0:n}", transfer) + " transfer transaction sent for approval",
               "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

            db.connect();
            db.balanceUpdate(recipientAccNo);
            db.getConnection.Close();

            txtWithAccNo.Text = "";
            txtRecipientAccNo.Text = "";
            txtWithAmt.Text = "";
            txtWithCharges.Text = "";
            sSMessage.Visible = false;
        }
        private void checkDeposit()
        {
            accNumber = Convert.ToInt64(txtDepAccNo.Text);
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
                    MessageBox.Show("Sorry! Account is closed", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (IndexOutOfRangeException idx)
            {
                try
                {
                    db.connect();
                    db.getThresholdSetup(ExposeProperties.DepartmentID);
                    db.getConnection.Close();
                    DataTable tb = new DataTable();
                    db.getDataAdapter.Fill(tb);
                    long dbDeposit = (long)tb.Rows[0]["Deposit"];
                    string departmentID = tb.Rows[0]["DepartmentID"].ToString();
                    deposit = Convert.ToInt64(txtDepAmt.Text);

                    if (convert(thresholdSetup) == false && ExposeProperties.DepartmentID.Equals(departmentID))
                    {
                        if (deposit <= dbDeposit)
                        {
                            thresholdDeposit();
                        }
                        else
                        {
                            depositTransactionLedger();
                        }
                    }
                }
                catch (IndexOutOfRangeException ioe)
                {
                    if (convert(thresholdSetup) == true)
                    {
                        thresholdDeposit();
                    }
                }
            }
        }
        private void transferFund()
        {
            try
            {
                transactionType = "Transfer";
                comboDepAccOff.Text = "";
                hostName = Dns.GetHostName();

                long recipientAccNo = Convert.ToInt64(txtRecipientAccNo.Text);
                db.connect();
                db.getBalance(recipientAccNo);
                db.getConnection.Close();
                dataSet = new DataSet();
                db.getDataAdapter.Fill(dataSet, "BalanceUpdate");
                long dbAccNumber = (long)dataSet.Tables["BalanceUpdate"].Rows[0]["AccountNumber"];
                if (recipientAccNo == dbAccNumber)
                {
                    try
                    {
                        db.connect();
                        db.getClosedAccount(recipientAccNo);
                        db.getConnection.Close();
                        tb = new DataTable();
                        db.getDataAdapter.Fill(tb);
                        long closedAccNumber = (long)tb.Rows[0]["AccountNumber"];

                        if (recipientAccNo == closedAccNumber)
                        {
                            close = "closed";
                            sSMessage.Visible = false;
                            tSSMessage.Text = "";
                        }
                    }
                    catch (IndexOutOfRangeException idx)
                    {
                        try
                        {
                            charges = Convert.ToInt32(txtWithCharges.Text);
                            long transfer = Convert.ToInt64(txtWithAmt.Text);
                            description = richWithTransDesc.Text;
                            db.connect();
                            db.transactionLog(dateTransPicker.Text, time, transactionType, transfer, charges, +
                            accNumber, recipientAccNo, comboDepAccOff.Text, cl.getUser, hostName, description);
                            db.getConnection.Close();
                            dataSet = new DataSet();
                            db.getDataAdapter.Fill(dataSet, "TransactionLog");

                            db.connect();
                            db.balanceUpdate(recipientAccNo);
                            db.getConnection.Close();
                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
            catch (IndexOutOfRangeException idx)
            {
                sSMessage.Visible = true;
                tSSMessage.Text = "Recipient account number is invalid";
            }
        }
        private void withdrawFund()
        {
            transactionType = "Withdrawal";
            string accNo = 0.ToString();
            comboDepAccOff.Text = "";
            hostName = Dns.GetHostName();
            try
            {
                charges = Convert.ToInt32(txtWithCharges.Text);
                withdraw = Convert.ToInt64(txtWithAmt.Text);
                long accNumber1 = Convert.ToInt64(accNo);
                description = richWithTransDesc.Text;
                db.connect();
                db.transactionLog(dateTransPicker.Text, time, transactionType, withdraw, charges, +
                accNumber, accNumber1, comboDepAccOff.Text, cl.getUser, hostName, description);
                db.getConnection.Close();
                dataSet = new DataSet();
                db.getDataAdapter.Fill(dataSet, "TransactionLog");
            }
            catch (FormatException e)
            {

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void confirmWithdrawal()
        {
            if (checkTrans.Checked == true)
            {
                try
                {
                    db.connect();
                    db.getThresholdSetup(ExposeProperties.DepartmentID);
                    db.getConnection.Close();
                    DataTable tb = new DataTable();
                    db.getDataAdapter.Fill(tb);
                    long dbTransfer = (long)tb.Rows[0]["Transfer"];
                    string departmentID = tb.Rows[0]["DepartmentID"].ToString();
                    long transfer = Convert.ToInt64(txtWithAmt.Text);

                    if (convert(thresholdSetup) == false && ExposeProperties.DepartmentID.Equals(departmentID))
                    {
                        if (transfer <= dbTransfer)
                        {
                            control = "transfer";
                            transferFund();
                        }
                        else
                        {
                            control = "ledger";
                            transferTransactionLedger();
                        }
                    }
                }
                catch (IndexOutOfRangeException ioe)
                {
                    if (convert(thresholdSetup) == true)
                    {
                        control = "transfer";
                        transferFund();
                    }
                }
            }
            else
            {
                db.connect();// Vault transaction implementation 
                db.vaultBalance(dt.ToShortDateString(), ExposeProperties.BranchCode);
                db.getConnection.Close();
                DataTable vault = new DataTable();
                db.getDataAdapter.Fill(vault);
                long vaultWithBalance = (long)vault.Rows[0]["WithdrawalBalance"];
                long withdrawal = long.Parse(txtWithAmt.Text);

                if (withdrawal <= vaultWithBalance)
                {
                    try
                    {
                        db.connect();
                        db.getThresholdSetup(ExposeProperties.DepartmentID);
                        db.getConnection.Close();
                        DataTable tb = new DataTable();
                        db.getDataAdapter.Fill(tb);
                        long dbWithdrawal = (long)tb.Rows[0]["Withdrawal"];
                        string departmentID = tb.Rows[0]["DepartmentID"].ToString();
                        withdraw = Convert.ToInt64(txtWithAmt.Text);

                        if (convert(thresholdSetup) == false && ExposeProperties.DepartmentID.Equals(departmentID))
                        {
                            if (withdraw <= dbWithdrawal)
                            {
                                control = "withdraw";
                                withdrawFund();
                            }
                            else
                            {
                                control = "ledger";
                                withdrawalTransactionLedger();
                            }
                        }
                    }
                    catch (IndexOutOfRangeException ioe)
                    {
                        if (convert(thresholdSetup) == true)
                        {
                            control = "withdraw";
                            withdrawFund();
                        }
                    }
                }
                else
                {
                   //Insufficient vault balance
                }
            }
        }//copying ends here
        private void proceed()
        {
            accNumber = Convert.ToInt64(txtWithAccNo.Text);
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
                    MessageBox.Show("Sorry! Account is closed", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (IndexOutOfRangeException idx)
            {
                groupWith.Visible = true;
                confirmWithdrawal();
                long balCheck;

                panCustomer.Visible = false;
                panSignature.Visible = false;
                panCustName.Visible = false;
                txtWithAccNo.Text = "";
                sSMessage.Visible = true;
                if (checkTrans.Checked == true)
                {
                    try
                    {
                        db.connect();
                        db.getBalance(accNumber);
                        db.getConnection.Close();
                        dataSet = new DataSet();
                        db.getDataAdapter.Fill(dataSet, "BalanceUpdate");
                        balCheck = (long)dataSet.Tables["BalanceUpdate"].Rows[0]["Balance"];

                        try
                        {
                            if (close.Equals("closed"))
                            {
                                MessageBox.Show("Sorry! Recipient account is closed!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                sSMessage.Visible = false;
                                tSSMessage.Text = "";
                            }
                        }
                        catch (NullReferenceException)
                        {
                            if (control.Equals("transfer"))
                            {
                                db.connect();
                                db.getTrans();
                                db.getConnection.Close();
                                DataTable transID = new DataTable();
                                db.getDataAdapter.Fill(transID);
                                long dbTransID = (long)transID.Rows[0]["TransLogID"];
                                tSSMessage.Text = "N" + string.Format("{0:n}", transfer) + " transferred, " + "N" + charges +
                                " charged, current balance is N" + string.Format("{0:n}", balCheck) + " and Trans ID is " + dbTransID;
                                txtWithAmt.Text = "";
                                txtWithCharges.Text = "";
                                richWithTransDesc.Text = "";
                                txtRecipientAccNo.Text = "";
                                charges = 0;
                                sSMessage.Visible = true;
                            }
                            else
                            {
                                sSMessage.Visible = false;
                            }
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {
                        sSMessage.Visible = true;
                        tSSMessage.Text = "Invalid account number!";
                    }
                }
                else
                {
                    try
                    {
                        if (control.Equals("withdraw"))
                        {
                            db.connect();
                            db.getBalance(accNumber);
                            db.getConnection.Close();
                            dataSet = new DataSet();
                            db.getDataAdapter.Fill(dataSet, "BalanceUpdate");
                            balCheck = (long)dataSet.Tables["BalanceUpdate"].Rows[0]["Balance"];

                            db.connect();
                            db.getTrans();
                            db.getConnection.Close();
                            DataTable transID = new DataTable();
                            db.getDataAdapter.Fill(transID);
                            long dbTransID = (long)transID.Rows[0]["TransLogID"];

                            tSSMessage.Text = "N" + string.Format("{0:n}", withdraw) + " withdrawn, " + "N" + charges +
                            " charged, current balance is N" + string.Format("{0:n}", balCheck) + " and Trans ID is " + dbTransID;
                            txtWithAmt.Text = "";
                            txtWithCharges.Text = "";
                            richWithTransDesc.Text = "";
                            txtRecipientAccNo.Text = "";
                            charges = 0;
                            sSMessage.Visible = true;
                        }
                        else
                        {
                            sSMessage.Visible = false;
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {
                        sSMessage.Visible = true;
                        tSSMessage.Text = "Invalid account number!";
                    }
                    catch (NullReferenceException)
                    {
                        sSMessage.Visible = true;
                        tSSMessage.Text = "Insufficient vault balance!";
                    }
                }
            }
        }
        private long getWithTransBalance(long witTransbalance)
        {
            return witTransbalance;
        }
        private void customerDetails(long accNo)
        {
            this.accNumber = accNo;
            string fName, mName, lName;
            db.connect();
            db.custDetails(accNumber);
            db.getConnection.Close();
            tb = new DataTable();
            db.getDataAdapter.Fill(tb);

            //Initializing the customer names
            fName = tb.Rows[0]["FirstName"].ToString();
            mName = tb.Rows[0]["MiddleName"].ToString();
            lName = tb.Rows[0]["LastName"].ToString();
            lblCustName.Text = fName + " " + mName + " " + lName;
        }
        private bool checkLoan(long accNo)
        {
            bool status = false;
            db.connect();
            db.loanBalance(accNo);
            db.getConnection.Close();
            DataTable tb = new DataTable();
            db.getDataAdapter.Fill(tb);
            string loanStatus = tb.Rows[0]["LoanStatus"].ToString();
            if (loanStatus == "Not Balanced")
            {
                status = true;
            }
            return status;
        }
        private void getPfVat()
        {
            try
            {
                db.connect();
                accNumber = Convert.ToInt64(txtBalAccNo.Text);
                db.pfVat(accNumber);
                db.getConnection.Close();
                tb = new DataTable();
                db.getDataAdapter.Fill(tb);
                long amount = (long)tb.Rows[0]["Amount"];
                long accNo = (long)tb.Rows[0]["AccountNumber"];
                if (accNumber == accNo && amount > 0)
                {
                    lblPfVat.Visible = true;
                    lblPfAmt.Visible = true;
                    lblPfAmt.Text = string.Format("{0:n}", amount);
                }
            }
            catch (IndexOutOfRangeException idx)
            {
                lblPfVat.Visible = false;
                lblPfAmt.Visible = false;
            }
            catch (FormatException idx)
            {
                MessageBox.Show("Please enter number only!", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void guarant(long accNumber)
        {
            ExposeProperties exp;
            string fName, mName, lName, address, phone, gender = null;
            byte[] gPhoto, gSignature;
            try
            {
                //Guarantor connection
                string guarantPhone;
                db.connect();
                db.guarantorExist(accNumber);
                db.getConnection.Close();
                DataTable guarantor = new DataTable();
                db.getDataAdapter.Fill(guarantor);
                long accNo = (long)guarantor.Rows[0]["AccountNumber"];

                //Guarantor details
                if (accNumber == accNo)
                {
                    linkGuarantor.Visible = true;
                    guarantPhone = guarantor.Rows[0]["PhoneNumber"].ToString();
                    linkGuarantor.Text = guarantPhone;

                    fName = guarantor.Rows[0]["FirstName"].ToString();
                    mName = guarantor.Rows[0]["MiddleName"].ToString();
                    lName = guarantor.Rows[0]["LastName"].ToString();
                    address = guarantor.Rows[0]["Address"].ToString();
                    phone = guarantor.Rows[0]["PhoneNumber"].ToString();
                    gender = guarantor.Rows[0]["Gender"].ToString();
                    gPhoto = retrieveGuarantorPhoto(accNumber);
                    gSignature = retrieveGuarantorSignature(accNumber);

                    //Forward details
                    exp = new ExposeProperties();
                    exp.GuarantName = fName + " " + mName + " " + lName;
                    exp.Address = address;
                    exp.Phone = phone;
                    exp.Gender = gender;
                    exp.GuarantorPhoto = gPhoto;
                    exp.GuarantorSignature = gSignature;
                }
            }
            catch (IndexOutOfRangeException idx)
            {
                linkGuarantor.Visible = true;
                linkGuarantor.Text = "No details";
                linkGuarantor.Enabled = false;
            }
        }
        private void equity(long accNo)
        {
            try
            {
                db.connect();
                db.loanChecker(accNo);
                db.getConnection.Close();
                DataTable table = new DataTable();
                db.getDataAdapter.Fill(table);
                string deposit = table.Rows[0]["Deposit"].ToString();
                float convertDeposit = float.Parse(deposit);
                lblEquity.Visible = true;
                lblEquityAmt.Visible = true;
                lblEquityAmt.Text = string.Format("{0:n}", convertDeposit);
            }
            catch (InvalidCastException ice)
            {

            }
        }
        private float outstandingAmount(long accNo)
        {
            float amount = 0.0f;
            try
            {
                db.connect();
                db.getExtendLoan(accNo);
                db.getConnection.Close();
                DataTable tb = new DataTable();
                db.getDataAdapter.Fill(tb);
                long accountNo = (long)tb.Rows[0]["AccountNumber"];
                string amt = tb.Rows[0]["OutstandingAmount"].ToString();

                if (accNo == accountNo)
                {
                    amount = float.Parse(amt);
                }
            }
            catch (IndexOutOfRangeException)
            {

            }
            catch (InvalidCastException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return amount;
        }
        private bool extendDateStatus(long accNo)
        {
            bool status = false;
            try
            {
                db.connect();
                db.getExtendLoan(accNo);
                db.getConnection.Close();
                DataTable tb = new DataTable();
                db.getDataAdapter.Fill(tb);
                long accountNo = (long)tb.Rows[0]["AccountNumber"];
                string dbDate = tb.Rows[0]["ExtendDate"].ToString();

                if (accNo == accountNo)
                {
                    status = true;
                }
            }
            catch (IndexOutOfRangeException idx)
            {
                status = false;
            }

            return status;
        }
        private DateTime extendDate(long accNo)
        {
            DateTime localDate = databaseDate();
            try
            {
                db.connect();
                db.getExtendLoan(accNo);
                db.getConnection.Close();
                DataTable tb = new DataTable();
                db.getDataAdapter.Fill(tb);
                long accountNo = (long)tb.Rows[0]["AccountNumber"];
                string dbDate = tb.Rows[0]["ExtendDate"].ToString();

                if (accNo == accountNo)
                {
                    localDate = DateTime.Parse(dbDate);
                }
            }
            catch (IndexOutOfRangeException idx)
            {

            }
            return localDate;
        }
        private DateTime expire(long accNo)
        {
            provider = CultureInfo.InvariantCulture;
            string expire = null;
            try
            {
                db.connect();
                db.loanBalance(accNumber);
                db.getConnection.Close();
                DataTable maturityDateTable = new DataTable();
                db.getDataAdapter.Fill(maturityDateTable);
                expire = maturityDateTable.Rows[0]["MaturityDate"].ToString();

            }
            catch (FormatException fe)
            {
                MessageBox.Show("Printing...");//Printing...
            }
            catch (SqlException sql)
            {
                MessageBox.Show("Customer is currently not on loan", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return DateTime.ParseExact(expire, "yyyy-MM-dd", provider);
        }
        private void checkBalance()
        {
            try
            {
                accNumber = Convert.ToInt64(txtBalAccNo.Text);
                db.connect();
                db.getBalance(accNumber);
                db.getConnection.Close();
                table2 = new DataTable();
                db.getDataAdapter.Fill(table2);

                db.connect();
                db.custDetails(accNumber);
                db.getConnection.Close();
                DataTable table = new DataTable();
                db.getDataAdapter.Fill(table);

                long getAcc = (long)table.Rows[0]["AccountNumber"];
                string fName, mName, lName, address, phone;
                fName = table.Rows[0]["FirstName"].ToString();
                mName = table.Rows[0]["MiddleName"].ToString();
                lName = table.Rows[0]["LastName"].ToString();
                address = table.Rows[0]["Address"].ToString();
                phone = table.Rows[0]["PhoneNumber"].ToString();
                string getAccType = table.Rows[0]["AccountType"].ToString();

                if (accNumber == getAcc)
                {
                    try
                    {
                        string dtDb = table.Rows[0]["Date"].ToString();
                        lblRegDate.Text = dtDb;
                    }
                    catch (InvalidCastException e)
                    {

                    }
                    if (lblRegDate.Text == null)
                    {
                        lblRegDate.Text = null;
                    }

                    lblBalance.Visible = true;
                    panSavBal.Visible = true;
                    lblName.Text = lName + " " + fName + " " + mName;
                    long savingBalance = (long)table2.Rows[0]["Balance"];
                    lblBalance.Text = string.Format("{0:n}", savingBalance);
                    txtRecipientAccNo.Text = "";
                    sSMessage.Visible = false;

                    try
                    {
                        db.connect();
                        db.loanBalance(accNumber);
                        db.getConnection.Close();
                        DataTable tb = new DataTable();
                        db.getDataAdapter.Fill(tb);

                        long getAccNo = (long)tb.Rows[0]["AccountNumber"];
                        double loan = (long)tb.Rows[0]["TotalAmount"];
                        string disburse = tb.Rows[0]["DisbursmentDate"].ToString();
                        string duration = tb.Rows[0]["Duration"].ToString();

                        string loanStatus = tb.Rows[0]["LoanStatus"].ToString();
                        long principal = (long)tb.Rows[0]["Principal"];

                        if (accNumber == getAccNo)
                        {
                            lblBalRepayment.Text = "Repayment";
                            //guarantor details
                            guarant(accNumber);

                            lblDisburse.Text = disburse;
                            //Charges on default
                            DateTime expCharInc = expire(accNumber).AddDays(14);

                            panSavBal.Visible = true;

                            lblName.Text = lName + " " + fName + " " + mName;
                            long loanBalance = (long)table2.Rows[0]["Balance"];

                            lblPhone.Text = phone;
                            lblBalance.Text = string.Format("{0:n}", loanBalance);

                            if (loanStatus == "Balanced")
                            {
                                lblLoanAmt.Text = "Balanced";
                                lblDebt.Text = 0 + ".00".ToString();
                                lblExpire.Visible = false;
                                lblShowExpire.Visible = false;
                                lblChar.Visible = false;
                                lblDefault.Visible = false;
                                lblEquity.Visible = false;
                                lblEquityAmt.Visible = false;
                            }
                            else
                            {
                                lblLoanAmt.Text = string.Format("{0:n}", loan);
                                lblDebt.Text = string.Format("{0:n}", loan - loanBalance);
                            }

                            //Expiration
                            if (databaseDate() >= expire(accNumber) && databaseDate() < expCharInc && extendDateStatus(accNumber) == false)
                            {
                                lblDefault.Visible = false;
                                lblChar.Visible = false;
                                lblExpire.Visible = false;
                                lblShowExpire.Text = "Expired!";
                                equity(accNumber);
                            }
                            else if (databaseDate() >= expire(accNumber) && extendDateStatus(accNumber) == true && databaseDate() < extendDate(accNumber))
                            {
                                try
                                {
                                    lblDefault.Visible = false;
                                    lblChar.Visible = false;
                                    lblExpire.Visible = true;
                                    loan += (double)((outstandingAmount(accNumber) - principal) - loanBalance);
                                    lblDebt.Text = string.Format("{0:n}", loan);
                                    lblDisburse.Text = disburse;
                                    lblShowExpire.Text = "Extended";
                                    lblExpire.Text = extendDate(accNumber).ToString("yyyy-MM-dd");
                                    //Equity deposit
                                    equity(accNumber);
                                }
                                catch (FormatException nfe)
                                {

                                }
                            }
                            else if (databaseDate() >= expire(accNumber) && extendDateStatus(accNumber) == true && databaseDate() > extendDate(accNumber))
                            {
                                try
                                {
                                    lblDefault.Visible = false;
                                    lblChar.Visible = false;
                                    lblExpire.Visible = true;
                                    loan += (double)((outstandingAmount(accNumber) - principal) - loanBalance);
                                    lblDebt.Text = string.Format("{0:n}", loan);
                                    lblDisburse.Text = disburse;
                                    lblShowExpire.Text = "Extended";
                                    lblExpire.Text = "Expired!";
                                    //Equity deposit
                                    equity(accNumber);
                                }
                                catch (FormatException nfe)
                                {

                                }
                            }
                            else if (databaseDate() >= expCharInc && extendDateStatus(accNumber) == false)
                            {
                                try
                                {
                                    lblDefault.Visible = true;
                                    lblChar.Visible = true;
                                    lblChar.Text = "Charges";
                                    int debt = int.Parse(lblDebt.Text);
                                    lblDefault.Text = string.Format("{0:n}", (debt * 0.04));
                                    int debt2 = int.Parse(lblDefault.Text);

                                    lblDebt.Text = string.Format("{0:n}", debt + debt2);
                                    lblExpire.Visible = false;
                                    lblDisburse.Text = disburse;
                                    lblShowExpire.Text = "Expired!";
                                    //Equity deposit
                                    equity(accNumber);
                                }
                                catch (FormatException nfe)
                                {

                                }
                            }
                            else
                            {
                                lblDefault.Visible = true;
                                //lblDefault.Visible = false;
                                lblChar.Visible = false;
                                lblShowExpire.Visible = true;
                                lblExpire.Visible = true;
                                lblShowExpire.Text = "Expires";
                                lblExpire.Text = expire(accNumber).ToString("yyyy-MM-dd");
                                lblDisburse.Text = disburse;
                                //Equity deposit
                                equity(accNumber);
                            }
                            panLoanBal.Visible = true;
                            panDebt.Visible = true;
                            txtAddress.Text = address;
                        }

                    }
                    catch (IndexOutOfRangeException sql)
                    {
                        fName = table.Rows[0]["FirstName"].ToString();
                        mName = table.Rows[0]["MiddleName"].ToString();
                        lName = table.Rows[0]["LastName"].ToString();
                        lblPhone.Text = table.Rows[0]["PhoneNumber"].ToString();

                        lblBalance.Visible = true;
                        panSavBal.Visible = true;
                        lblName.Text = lName + " " + fName + " " + mName;
                        savingBalance = (long)table2.Rows[0]["Balance"];
                        lblBalance.Text = string.Format("{0:n}", savingBalance);
                        lblAccOfficer.Text = table.Rows[0]["AccountOfficer"].ToString();
                        panLoanBal.Visible = false;
                        panDebt.Visible = false;
                        txtRecipientAccNo.Text = "";
                        sSMessage.Visible = false;
                    }

                }
            }
            catch (IndexOutOfRangeException e)
            {
                panSavBal.Visible = false;
                panLoanBal.Visible = false;
                panDebt.Visible = false;
                sSMessage.Visible = true;
                tSSMessage.Text = "Account number does not exist!";
            }
        }
        private void loanNotification()
        {
            try
            {
                db.connect();
                db.getNotification();
                db.getConnection.Close();
                DataTable tb = new DataTable();
                db.getDataAdapter.Fill(tb);
                long getAccNo = (long)tb.Rows[0]["AccountNumber"];
                long loan = (long)tb.Rows[0]["TotalAmount"];
                string disburse = tb.Rows[0]["DisbursmentDate"].ToString();
                string expire = tb.Rows[0]["MaturityDate"].ToString();

                //Date converter
                DateTime expChar = DateTime.Parse(expire);

                //Expiration
                if ((databaseDate() == expChar.AddDays(-5)) && (databaseDate() < expChar))
                {
                    try
                    {
                        notify.Icon = SystemIcons.Application;
                        notify.Text = "loan expires in less than 5 days!";
                        notify.ShowBalloonTip(1000);
                    }
                    catch (ArgumentException)
                    {

                    }
                }
                else if (databaseDate() == expChar)
                {
                    notify.Icon = SystemIcons.Application;
                    notify.Text = "loan has expired!";
                    notify.ShowBalloonTip(1000);
                }
            }
            catch (FormatException e)
            {

            }
            catch (IndexOutOfRangeException sql)
            {

            }
            catch (SqlException sql)
            {

            }
        }
        private int validateDeposit()
        {
            int flag = 0;
            if (txtDepAccNo.Text == "")
            {
                txtDepAccNo.Focus();
                errorProvider.SetError(txtDepAccNo, "Please, enter the account number !");
                flag = 1;
            }
            if (txtDepAmt.Text == "")
            {
                txtDepAmt.Focus();
                errorProvider.SetError(txtDepAmt, "Please, enter the amount to be deposited!");
                flag = 1;
            }
            if (comboDepAccOff.Text == "")
            {
                comboDepAccOff.Focus();
                errorProvider.SetError(comboDepAccOff, "Please, select the account officer's name!");
                flag = 1;
            }
            if (comboDepAccOff.Text != "")
            {
                try
                {
                    string departmentName = "ACCOUNT OFFICER", accountOfficer = comboDepAccOff.Text;
                    db.connect();
                    db.getAccountOfficerName(departmentName, accountOfficer);
                    db.getConnection.Close();
                    tb = new DataTable();
                    db.getDataAdapter.Fill(tb);
                    string dbAccountOfficer = tb.Rows[0]["FirstName"].ToString();
                    if (accountOfficer.Equals(dbAccountOfficer))
                    {
                        flag = 0;
                    }
                }
                catch (IndexOutOfRangeException idx)
                {
                    comboDepAccOff.Focus();
                    errorProvider.SetError(comboDepAccOff, "Sorry! account officer's name doesn't exist");
                    flag = 1;
                }
            }
            return flag;
        }
        private int validateWithTrans()
        {
            int flag = 0;
            if (checkTrans.Checked == true)
            {
                if (txtWithAccNo.Text == "")
                {
                    txtWithAccNo.Focus();
                    errorProvider.SetError(txtWithAccNo, "Please, enter the  sender's account number !");
                    flag = 1;
                }
                else
                {
                    txtWithAccNo.Focus();
                    errorProvider.Clear();
                }
                if (txtWithAmt.Text == "")
                {
                    txtWithAmt.Focus();
                    errorProvider.SetError(txtWithAmt, "Please, enter amount to be transferred!");
                    flag = 1;
                }

                if (txtRecipientAccNo.Text == "")
                {
                    txtRecipientAccNo.Focus();
                    errorProvider.SetError(txtRecipientAccNo, "Please, enter the recipient's account number!");
                    flag = 1;
                }
            }
            else
            {
                if (txtWithAccNo.Text == "")
                {
                    txtWithAccNo.Focus();
                    errorProvider.SetError(txtWithAccNo, "Please, enter the account number !");
                    flag = 1;
                }
                if (txtWithAmt.Text == "")
                {
                    txtWithAmt.Focus();
                    errorProvider.SetError(txtWithAmt, "Please, enter amount to be withdrawn!");
                    flag = 1;
                }
            }
            return flag;
        }
        private int validateBalance()
        {
            int flag = 0;
            if (txtBalAccNo.Text == "")
            {
                txtBalAccNo.Focus();
                errorProvider.SetError(txtBalAccNo, "Please, enter the accont number!");
                flag = 1;
            }
            return flag;
        }
        private int validateQuickViewReport()
        {
            int flag = 0;
            if (txtAccNo.Text == "" && radAccOfficer.Checked == false && radAll.Checked == false)
            {
                txtAccNo.Focus();
                errorProvider.SetError(txtAccNo, "Please, enter the account number!");
                flag = 1;
            }
            else if (txtAccNo.Text == "" && radAccOfficer.Checked == true && comboQuickViewAccOfficer.SelectedIndex == 0)
            {
                comboQuickViewAccOfficer.Focus();
                errorProvider.SetError(comboQuickViewAccOfficer, "Please, select the account officer!");
                flag = 1;
            }
            return flag;
        }
        public DateTime databaseDate()
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
        private string phoneNumber(string phone)
        {
            string phoneNo = null;
            if (phone.Length == 11)
            {
                phoneNo = phone.Substring(1, 10);
            }
            else
            {
                phoneNo = phone;
            }
            return phoneNo;
        }
        private string getPhone(long accNo)
        {
            string phone = null;
            try
            {
                db.connect();
                db.custDetails(accNo);
                db.getConnection.Close();
                tb = new DataTable();
                db.getDataAdapter.Fill(tb);

                string dbPhone = tb.Rows[0]["PhoneNumber"].ToString();
                phone = phoneNumber(dbPhone);
            }
            catch (IndexOutOfRangeException)
            {
                phone = null;
            }
            return phone;
        }
        private void getAlert(long accNumber, long deposit, long balance)
        {
            string date = dt.AddDays(6).ToShortDateString();
            try
            {
                DateTime convertDbDate, convertCurrentDate;
                db.connect();
                db.getAlert(accNumber);
                db.getConnection.Close();
                DataTable tb = new DataTable();
                db.getDataAdapter.Fill(tb);
                long accNo = (long)tb.Rows[0]["AccountNumber"];
                DateTime dbDate = DateTime.Parse(tb.Rows[0]["Date"].ToString());

                convertCurrentDate = dt;
                convertDbDate = dbDate;

                if ((accNumber == accNo) && (convertDbDate.DayOfWeek == convertCurrentDate.DayOfWeek) && (convertDbDate.Month == convertCurrentDate.Month) &&
                    (convertDbDate.Year == convertCurrentDate.Year))
                //if ((convertDbDate.Day <= convertCurrentDate.Day) && (convertDbDate.Year <= convertCurrentDate.Year))
                {
                    db.connect();
                    db.updateAlert(accNumber, date);
                    db.getConnection.Close();
                    DataTable tb2 = new DataTable();
                    db.getDataAdapter.Fill(tb2);
                    sendEstoreMessage(accNumber, deposit, balance);
                }
                else if ((accNumber == accNo) && (convertDbDate.Day >= convertCurrentDate.Day) && (convertDbDate.Month < convertCurrentDate.Month) &&
                        (convertDbDate.Year == convertCurrentDate.Year))
                {
                    db.connect();
                    db.updateAlert(accNumber, date);
                    db.getConnection.Close();
                    DataTable tb2 = new DataTable();
                    db.getDataAdapter.Fill(tb2);
                    sendEstoreMessage(accNumber, deposit, balance);
                }

            }
            //catch (FormatException fme)
            //{

            //}
            catch (IndexOutOfRangeException idx)
            {
                db.connect();
                db.insertAlert(accNumber, date);
                db.getConnection.Close();
                DataTable tb3 = new DataTable();
                db.getDataAdapter.Fill(tb3);
                sendEstoreMessage(accNumber, deposit, balance);
            }
        }
        private void sendEstoreMessage(long accNo, long deposit, long balance)
        {
            try
            {
                String result;
                string sender = "MadeEasy";
                string number = getPhone(accNo); // in a comma seperated list
                string message = "Made Easy\nAccNo: " + accNo + "\nDeposited: " + string.Format("{0:n}", deposit) + " \nAvail Bal: " + string.Format("{0:n}", balance);
                String url = "http://www.estoresms.com/smsapi.php?username=dProgrammer&password=Ma3caka2ya&sender=" + sender +
                        "&recipient=234" + number + "&message=" + message + "&";

                //String url = "http://www.estoresms.com/smsapi.php?username=MadeEasy&password=Finance1990&sender=" + sender +
                        //"&recipient=234" + number + "&message=" + message + "&";

                StreamWriter myWriter = null;
                HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(url);

                objRequest.Method = "POST";
                objRequest.ContentLength = Encoding.UTF8.GetByteCount(url);
                try
                {
                    myWriter = new StreamWriter(objRequest.GetRequestStream());
                    myWriter.Write(url);
                }
                catch (NullReferenceException nre)
                {
                    //MessageBox.Show(nre.Message);
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                }
                finally
                {
                    myWriter.Close();
                }

                HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
                using (StreamReader sr = new StreamReader(objResponse.GetResponseStream()))
                {
                    result = sr.ReadToEnd();
                    // Close and clean up the StreamReader
                    //sr.Close();
                }
            }
            catch (WebException web)
            {
                MessageBox.Show(web.Message);
            }
        }
        private void getPhoto(long accNo)
        {
            try
            {
                db.connect();
                db.getPhoto(accNo);
                db.getConnection.Close();
                DataTable tbPhoto = new DataTable();
                db.getDataAdapter.Fill(tbPhoto);

                byte[] img = (byte[])tbPhoto.Rows[0]["Photo"];

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
            panCustomer.Visible = true;
            panSignature.Visible = true;
            panCustName.Visible = true;
            customerDetails(accNo);
            groupWith.Visible = false;
            sSMessage.Visible = false;

        }
        private void retrieveSignature(long accountNo)
        {
            try
            {
                db.connect();
                db.getSignature(accountNo);
                db.getConnection.Close();
                tb = new DataTable();
                db.getDataAdapter.Fill(tb);
                byte[] img = (byte[])tb.Rows[0]["Signature"];
                MemoryStream memory = new MemoryStream(img);
                picCustSignature.Image = Image.FromStream(memory);
            }
            catch (Exception ex)
            {

            }
        }
        private byte[] retrieveGuarantorPhoto(long accountNo)
        {
            byte[] img = null;
            try
            {
                db.connect();
                db.getGuarantorPhoto(accountNo);
                db.getConnection.Close();
                tb = new DataTable();
                db.getDataAdapter.Fill(tb);
                img = (byte[])tb.Rows[0]["Photo"];
            }
            catch (ArgumentException ex)
            {
                //MessageBox.Show(ex.Message);
            }
            return img;
        }
        private byte[] retrieveGuarantorSignature(long accountNo)
        {
            byte[] img = null;
            try
            {
                db.connect();
                db.getGuarantorSignature(accountNo);
                db.getConnection.Close();
                tb = new DataTable();
                db.getDataAdapter.Fill(tb);
                img = (byte[])tb.Rows[0]["Signature"];
            }
            catch (Exception ex)
            {

            }
            return img;
        }
        private void linkLogout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login log = new Login();
            ExposeProperties exp = new ExposeProperties();
            log.logFile(exp.getUser, "Offline");
            new Login().Show();
            Hide();
        }
        private void btnDepClear_Click(object sender, EventArgs e)
        {
            txtDepAccNo.Text = "";
            txtDepAmt.Text = "";
        }
        private void btnProceed_Click(object sender, EventArgs e)
        {
            if (getSession() < 0)//Session implementation
            {
                MessageBox.Show("Sorry, session expired. Please click OK and re-login", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                new Login().Show();
                Hide();
            }
            else
            {
                proceed();
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            tabWith.Show();
            groupWith.Visible = true;
            panCustomer.Visible = false;
            panSignature.Visible = false;
            panCustName.Visible = false;
        }
        private void btnWithClear_Click(object sender, EventArgs e)
        {
            txtWithAccNo.Text = "";
            txtWithAmt.Text = "";
            txtWithCharges.Text = "";
            txtRecipientAccNo.Text = "";
        }
        private void linkSet_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ExposeProperties.TransactionTypeStatus = ExposeProperties.UserLogin;
            ExposeProperties.UserLogin = "changePassword";
            new Settings().Show();
            Hide();
        }

        private void linkCustReg_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new CustomerRegistration().Show();
            Hide();
        }
        private void linkFreezeAcc_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Freeze().Show();
            Hide();
        }
        private void linkGroupReg_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Group().Show();
            Hide();
        }

        private void checkTrans_CheckedChanged(object sender, EventArgs e)
        {
            lblRecipient.Visible = true;
            txtRecipientAccNo.Visible = true;
            lblWitAccNo.Text = "Sender's Account Number";
            btnWith.Text = "Transfer";
            lblWithTransAmt.Text = "Transfer Amount";
            lblWitTrans.Text = "Transfer Form";
            groupWith.Text = "Transfer Data Entry";
            lblWitAccNo.Location = new Point(69, 28);
            lblWithTransAmt.Location = new Point(135, 55);
            lblTransCust.Visible = true;
            if (checkTrans.Checked == false)
            {
                lblTransCust.Visible = false;
                lblWitAccNo.Location = new Point(135, 28);
                lblWithTransAmt.Location = new Point(117, 54);
                lblRecipient.Visible = false;
                txtRecipientAccNo.Visible = false;
                txtRecipientAccNo.Text = "";
                lblWitAccNo.Text = "Account Number";
                btnWith.Text = "Withdrawal";
                lblWithTransAmt.Text = "Withdrawal Amount";
                lblWitTrans.Text = "Withdrawal Form";
                groupWith.Text = "Withdrawal Data Entry";
                txtRecipientAccNo.Text = "";
            }
        }

        private void linkAccStatement_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new AccountStatement().Show();
            Hide();
        }

        private void linkAccountSetup_LinkChecked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new AccountSetup().Show();
            Hide();
        }
        private void linkDisLoan_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Sending disburse message to the disburse class
            sendNotification = "Disburse";
            new Disbursement().Show();
            Hide();
        }

        private void linkBalanceLoan_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new BalanceLoan().Show();
            Hide();
        }

        private void linkDelAcc_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Delete().Show();
            Hide();
        }

        private void linkDepartment_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Department().Show();
            Hide();
        }
        
        private void linkEmployee_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Employee().Show();
            Hide();
        }

        private void linkExtend_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Sending extension message to the disburse class
            sendNotification = "Extension";
            new Disbursement().Show();
            Hide();
        }

        private void linkEditTrans_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new EditTransaction().Show();
            Hide();
        }

        private void linkFeedback_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Feedback().Show();
            Hide();
        }
        private int getSession()
        {
            string dbDate = null, getDate = null, sysData = null;
            DateTime convertDate = DateTime.Now, convertGetDate, convertSysDate;
            int difference;
            db.connect();
            db.getSession(cl.getUser);
            db.getConnection.Close();
            tb= new DataTable();
            db.getDataAdapter.Fill(tb);
            dbDate = tb.Rows[0]["DateTime"].ToString();
            convertDate = DateTime.Parse(dbDate);
            getDate = convertDate.ToShortDateString();
            convertGetDate = DateTime.Parse(getDate);
            sysData = databaseDate().ToShortDateString();
            convertSysDate = DateTime.Parse(sysData);
            difference = convertGetDate.CompareTo(convertSysDate);
            return difference;
        }
        private void btnWith_Click(object sender, EventArgs e)
        {
            accNumber = Convert.ToInt64(txtWithAccNo.Text);
            if (validateWithTrans() == 0)
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
                            errorProvider.Clear();
                            if (txtWithCharges.Text == "")
                            {
                                int charges = 0;
                                txtWithCharges.Text = charges.ToString();
                            }
                            try
                            {
                                /*long accRecipient = Convert.ToInt64(txtRecipientAccNo.Text);
                                checkLoan();*/
                                db.connect();
                                db.getBalance(accNumber);
                                db.getConnection.Close();
                                dataSet = new DataSet();
                                db.getDataAdapter.Fill(dataSet, "BalanceUpdate");
                                long bal = (long)dataSet.Tables["BalanceUpdate"].Rows[0]["Balance"];
                                long accNo2 = (long)dataSet.Tables["BalanceUpdate"].Rows[0]["AccountNumber"];

                                if (accNumber == accNo2)
                                {
                                    try
                                    {
                                        db.connect();
                                        db.freeze(accNumber);
                                        db.getConnection.Close();
                                        DataSet dataSet1 = new DataSet();
                                        db.getDataAdapter.Fill(dataSet1, "Freeze");
                                        long accNo = (long)dataSet1.Tables["Freeze"].Rows[0]["AccountNumber"];
                                        string description = dataSet1.Tables["Freeze"].Rows[0]["Description"].ToString();

                                        if (accNumber == accNo)
                                        {
                                            MessageBox.Show(description, "Account is Frozen", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }

                                    }
                                    catch (IndexOutOfRangeException idx)
                                    {
                                        charges = Convert.ToInt32(txtWithCharges.Text);
                                        withdraw = Convert.ToInt64(txtWithAmt.Text);

                                        long sumChaWith = (withdraw + charges);

                                        //if(checkTrans.Checked == true)
                                        //{
                                        //    if (accRecipient != accNumber2)
                                        //    {
                                        //        sSMessage.Visible = true;
                                        //        tSSMessage.Text = "Recipient account number is invalid!";
                                        //    }
                                        //}
                                        //else
                                        //{
                                        //accNumber = 0;

                                        //checkLoan();

                                        //}

                                        if (bal > 0 && sumChaWith <= bal)
                                        {
                                            if (checkLoan(accNumber) == true)
                                            {
                                                MessageBox.Show("Sorry! Customer is currently on loan!", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                                                groupWith.Visible = true;
                                            }
                                            else
                                            {
                                                getPhoto(accNumber);
                                                retrieveSignature(accNumber);
                                            }
                                        }
                                        else
                                        {
                                            groupWith.Visible = true;
                                            panCustomer.Visible = false;
                                            panSignature.Visible = false;
                                            panCustName.Visible = false;
                                            sSMessage.Visible = true;
                                            tSSMessage.Text = " Insufficient fund!";
                                        }

                                    }
                                }
                            }
                            catch (IndexOutOfRangeException ex)
                            {
                                try
                                {
                                    getPhoto(accNumber);
                                    retrieveSignature(accNumber);
                                }
                                catch (IndexOutOfRangeException idx)
                                {
                                    sSMessage.Visible = true;
                                    tSSMessage.Text = " Account number does not exist!";
                                }

                            }
                            catch (FormatException ex)
                            {
                                MessageBox.Show("Wrong input, number required!");
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
        private void creditVault()//Vault implementation
        {
            int flag = 0;
            if(txtDepAccNo.Text.Length == 0)
            {
                txtDepAccNo.Focus();
                errorProvider.SetError(txtDepAccNo, "Please enter the vault deposit");
                flag = 1;
            }
            if (txtDepAmt.Text.Length == 0)
            {
                txtDepAmt.Focus();
                errorProvider.SetError(txtDepAmt, "Please enter the vault witdrawal");
                flag = 1;
            }
            if(comboDepAccOff.Text.Equals("SELECT"))
            {
                comboDepAccOff.Focus();
                errorProvider.SetError(comboDepAccOff, "Please select a branch");
                flag = 1;
            }
            if(flag == 0)
            {
                long deposit, withdrawal, totalAmount;
                db.connect();// Vault transaction implementation 
                db.getHeadOfficeVaultBalance();
                db.getConnection.Close();
                DataTable headOfficeVault = new DataTable();
                db.getDataAdapter.Fill(headOfficeVault);
                long vaultDepositBalance = (long)headOfficeVault.Rows[0]["Balance"];
                deposit = long.Parse(txtDepAccNo.Text);
                withdrawal = long.Parse(txtDepAmt.Text);
                totalAmount = deposit + withdrawal;

                if (totalAmount <= vaultDepositBalance)
                {
                    errorProvider.Clear();
                    db.connect();// Vault transaction implementation 
                    db.creditVault(dt.ToShortDateString(), ExposeProperties.BranchCode, deposit, withdrawal);
                    db.getConnection.Close();
                    tb = new DataTable();
                    db.getDataAdapter.Fill(tb);
                    sSMessage.Visible = true;
                    tSSMessage.Text = "Credited N" + string.Format("{0:n}", deposit) + " as vault deposit and N" + 
                        string.Format("{0:n}", withdrawal) + " as vault withdrawal";
                }
                else
                {
                    sSMessage.Visible = true;
                    tSSMessage.Text = "Insufficient Head Office vault balance";
                }
            }
        }
        private void backdatedTransaction()
        {
            if (validateDeposit() == 0)
            {
                errorProvider.Clear();
                try
                {
                    db.connect();
                    accNumber = Convert.ToInt64(txtDepAccNo.Text);
                    db.balanceUpdate(accNumber);
                    db.getConnection.Close();
                    dataSet = new DataSet();
                    db.getDataAdapter.Fill(dataSet, "BalanceUpdate");
                    long accNo = (long)dataSet.Tables["BalanceUpdate"].Rows[0]["AccountNumber"];
                    if (accNumber == accNo)
                    {
                        db.connect();// Vault transaction implementation 
                        db.depositVaultBalance(datePicker.Value.ToShortDateString(), ExposeProperties.BranchCode);
                        db.getConnection.Close();
                        DataTable vault = new DataTable();
                        db.getDataAdapter.Fill(vault);
                        long vaultDepositBalance = (long)vault.Rows[0]["DepositBalance"];

                        if (vaultDepositBalance > 0)
                        {
                            long deposit = long.Parse(txtDepAmt.Text);
                            db.connect();// Vault transaction implementation 
                            db.debitVaultBalance(datePicker.Value.ToShortDateString(), ExposeProperties.BranchCode, deposit);
                            db.getConnection.Close();
                            DataTable depositVaultBalance = new DataTable();
                            db.getDataAdapter.Fill(depositVaultBalance);

                            customerDetails(accNumber);
                            if (checkPFVat.Checked == true && checkVault.Checked == false &&
                                checkBulkTransaction.Checked == false && checkHeadOffice.Checked == false)
                            {
                                formVat();
                            }
                            else
                            {
                                checkDeposit();
                            }
                        }
                        else
                        {
                            sSMessage.Visible = true;
                            tSSMessage.Text = "Insufficient backdated vault balance";
                        }
                    }
                }
                catch (IndexOutOfRangeException ex)
                {
                    sSMessage.Visible = true;
                    tSSMessage.Text = "Account number doesn't exist";
                }
            }
            else
            {
                sSMessage.Visible = false;
            }
        }
        private void btnDep_Click(object sender, EventArgs e)
        {
            try
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
                            if (checkBulkTransaction.Checked == true && checkPFVat.Checked == false && 
                                checkHeadOffice.Checked == false && checkVault.Checked == false)//Vault implementation
                            {
                                if (comboDepAccOff.SelectedIndex < 0)
                                {
                                    comboDepAccOff.Focus();
                                    errorProvider.SetError(comboDepAccOff, "Please select an account officer's name");
                                }
                                else
                                {
                                    ExposeProperties.AccountOfficer = comboDepAccOff.Text;
                                    new BulkTransaction().Show();
                                    Hide();
                                }
                            }
                            else
                            {
                                if(getSession() < 0)//Session implementation
                                {
                                    MessageBox.Show("Sorry, session expired. Please click OK and re-login", "Info",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    new Login().Show();
                                    Hide();
                                }
                                else
                                {
                                    if (checkHeadOffice.Checked == true && checkPFVat.Checked == false &&
                                        checkBulkTransaction.Checked == false && checkVault.Checked == false)//Vault implementation
                                    {
                                        creditHeadOffice();
                                    }
                                    else if (checkVault.Checked == true && checkPFVat.Checked == false &&
                                        checkBulkTransaction.Checked == false && checkHeadOffice.Checked == false)//Vault implementation
                                    {
                                        creditVault();
                                    }
                                    else
                                    {
                                        DateTime sysDate, dbDate;

                                        sysDate = DateTime.Parse(datePicker.Value.ToShortDateString());
                                        dbDate = DateTime.Parse(dt.ToShortDateString());
                                       
                                        int compareDate = (DateTime.Compare(sysDate, dbDate));
                                        if(compareDate >= 1)
                                        {
                                                MessageBox.Show("Sorry, no future date is allowed", "Error",
                                            MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                        }
                                        else
                                        {
                                            if(!datePicker.Value.ToShortDateString().Equals(dt.ToShortDateString()))
                                            {
                                                backdatedTransaction();
                                            }
                                            else
                                            {
                                                if (validateDeposit() == 0)
                                                {
                                                    errorProvider.Clear();
                                                    try
                                                    {
                                                        db.connect();
                                                        accNumber = Convert.ToInt64(txtDepAccNo.Text);
                                                        db.balanceUpdate(accNumber);
                                                        db.getConnection.Close();
                                                        dataSet = new DataSet();
                                                        db.getDataAdapter.Fill(dataSet, "BalanceUpdate");
                                                        long accNo = (long)dataSet.Tables["BalanceUpdate"].Rows[0]["AccountNumber"];
                                                        if (accNumber == accNo)
                                                        {
                                                            db.connect();// Vault transaction implementation 
                                                            db.vaultBalance(dt.ToShortDateString(), ExposeProperties.BranchCode);
                                                            db.getConnection.Close();
                                                            DataTable vault = new DataTable();
                                                            db.getDataAdapter.Fill(vault);
                                                            long vaultDepositBalance = (long)vault.Rows[0]["DepositBalance"];
                                                            long deposit = long.Parse(txtDepAmt.Text);

                                                            if (deposit <= vaultDepositBalance)
                                                            {
                                                                customerDetails(accNumber);
                                                                if (checkPFVat.Checked == true && checkVault.Checked == false && 
                                                                    checkBulkTransaction.Checked == false && checkHeadOffice.Checked == false)
                                                                {
                                                                    formVat();
                                                                }
                                                                else
                                                                {
                                                                    checkDeposit();
                                                                }
                                                            }
                                                            else
                                                            {
                                                                sSMessage.Visible = true;
                                                                tSSMessage.Text = "Insufficient vault balance";
                                                            }
                                                        }
                                                    }
                                                    catch (IndexOutOfRangeException ex)
                                                    {
                                                        sSMessage.Visible = true;
                                                        tSSMessage.Text = "Account number doesn't exist";
                                                    }
                                                }
                                                else
                                                {
                                                    sSMessage.Visible = false;
                                                }
                                            }
                                        }
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void checkPFVat_CheckedChanged(object sender, EventArgs e)
        {
            if (checkPFVat.Checked == true)
            {
                lblDep.Text = "P.F";
                btnDep.Text = "Post";
            }
            else
            {
                lblDep.Text = "Deposit Amount";
                btnDep.Text = "Deposit";
            }
        }
        private void btnBal_Click(object sender, EventArgs e)
        {
            if (checkHeadOffice.Checked == true)//Vault implementation
            {
                txtBalAccNo.Text = 0.ToString();
                db.connect();
                db.getBalance(getHeadOfficerNumber());
                db.getConnection.Close();
                tb = new DataTable();
                db.getDataAdapter.Fill(tb);
                long headOfficeBalance = (long)tb.Rows[0]["Balance"];
                panSavBal.Visible = true;
                lblNm.Visible = false;
                lblName.Visible = false;
                panHeadOffice.Visible = false;
                lblBalance.Text = string.Format("{0:n}", headOfficeBalance);
                txtRecipientAccNo.Text = "";
                sSMessage.Visible = false;
            }
            else
            {
                if (validateBalance() == 0)
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
                                errorProvider.Clear();
                                checkBalance();
                                getPfVat();
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
        private void btnBalClear_Click(object sender, EventArgs e)
        {
            txtBalAccNo.Text = "";
            sSMessage.Visible = false;
        }

        private void Home_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = "Welcome, "+ cl.FirstName;
            //voice.Speak(lblWelcome.Text, SpeechVoiceSpeakFlags.SVSFlagsAsync);
            if(ExposeProperties.DepartmentName.Equals("ADMIN"))
            {
                checkHeadOffice.Enabled = true;
                checkVault.Enabled = true;
                checkVaultReport.Enabled = true;
                checkInterval.Enabled = true;
            }
            else if(ExposeProperties.DepartmentName.Equals("SUB ADMIN"))
            {
                checkVault.Enabled = true;
                checkVaultReport.Enabled = true;
                checkInterval.Enabled = true;
            }
            getRole();
            if (countLedger() > 0 && linkTransactionApproval.Enabled == true)
            {
                lblCountTransaction.Text = countLedger().ToString();
            }
            else
            {
                lblCountTransaction.Visible = false;
            }    
            getUser();
            //loanNotification();
            dt = databaseDate();
            try
            {
                time = dt.ToString();
                datePicker.Text = dt.ToShortDateString();
                dateTransPicker.Text = dt.ToShortDateString();
                this.MaximizeBox = false;
            }
            catch (FormatException fe)
            {
                MessageBox.Show("Error");
            }
        }
        private void linkNotify_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //new Notification().Show();
        }

        private void linkAccountSetup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new AccountSetup().Show();
            Hide();
        }

        private void linkDisLoan_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Sending disburse message to the disburse class
            sendNotification = "Disburse";
            new Disbursement().Show();
            Hide();
        }
        private void linkBalanceLoan_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new BalanceLoan().Show();
            Hide();
        }

        private void linkDelAcc_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Delete().Show();
            Hide();
        }

        private void linkDepartment_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Department().Show();
            Hide();
        }

        private void linkEmployee_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Employee().Show();
            Hide();
        }

        private void linkExtend_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Sending extension message to the disburse class
            sendNotification = "Extension";
            new Disbursement().Show();
            Hide();
        }
        private void linkDeleteUser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ExposeProperties.DepartmentStatus = departmentStatus;
            new UserLogin().Show();
            Hide();
        }
        private void linkEditTrans_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ExposeProperties.DepartmentStatus = false;
            new EditTransaction().Show();
            Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ExposeProperties.DepartmentStatus = departmentStatus;
            new UserLogin().Show();
            Hide();
        }

        private void linkGuarantor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new GuarantorDetails().Show();
            Hide();
        }
        private void txtDepAmt_MouseHover(object sender, EventArgs e)
        {
            if (txtDepAccNo.Text.Length != 0)
            {
                customerDepDetails();
            }
            else
            {
                lblDepCust.Visible = true;
                lblDepCust.Text = "Please enter the account number first!";
            }
        }
        //Reporting Session
        private void linkReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new ReportView().Show();
            Hide();
        }
        private void user()
        {
            db.connect();
            db.user();
            db.getConnection.Close();
            DataTable tb = new DataTable();
            db.getDataAdapter.Fill(tb);
            foreach (DataRow dr in tb.Rows)
            {
                comboUser.Items.Add(dr["Username"].ToString());
            }
        }
        private void getUser()
        {
            if (ExposeProperties.OtherUsers != true)
            {
                comboUser.Items.Add(cl.getUser);
            }
            else
            {
                user();
            }
        }
        private void comboUser_SelectedIndexChanged(object sender, EventArgs e)
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
                        if (changeDate.Equals("D"))
                        {
                            ExposeProperties.Date = datePickerReport.Text;
                        }
                        else
                        {
                            ExposeProperties.Date = changeDate;
                        }
                        ExposeProperties.TransactionTypeStatus = "accountType";
                        string user = comboUser.SelectedItem.ToString();
                        ExposeProperties.UserLogin = user;
                        ExposeProperties.TransactionType = transType;
                        new Report.ReportForm.AccountStatementReportForm().Show();
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
        private void comboReportAccOfficer_SelectedIndexChanged(object sender, EventArgs e)
        {
            string accountOfficer = comboReportAccOfficer.SelectedItem.ToString();
            ExposeProperties.AccountOfficer = accountOfficer;
        }
        private void comboMonthReport_SelectedIndexChanged(object sender, EventArgs e)
        {
            string month = comboMonthReport.SelectedItem.ToString();
            ExposeProperties.ReportMonth = month;
        }
        private void txtYearReport_SelectedIndexChanged(object sender, EventArgs e)
        {
            int year = int.Parse(txtYearReport.Text);
            ExposeProperties.ReportYear = year;
        }
        private void tSDepositDay_Click(object sender, EventArgs e)
        {
            changeDate = "D";
            transType = "Deposit";
            lblDay.Visible = true;
            lblMonth.Visible = false;
            lblYear.Visible = false;
            lblTellerReport.Visible = true;
            lblAccOfficerReport.Visible = true;
            datePickerReport.Visible = true;
            comboUser.Visible = true;
            comboReportAccOfficer.Visible = true;
            comboMonthReport.Visible = false;
            txtYearReport.Visible = false;
        }
        private void tSDepositMonth_Click(object sender, EventArgs e)
        {
            changeDate = "M";
            transType = "Deposit";
            lblDay.Visible = false;
            lblMonth.Visible = true;
            lblYear.Visible = false;
            lblTellerReport.Visible = true;
            lblAccOfficerReport.Visible = true;
            datePickerReport.Visible = false;
            comboUser.Visible = true;
            comboReportAccOfficer.Visible = true;
            comboMonthReport.Visible = true;
            txtYearReport.Visible = false;
        }
        private void tSDepositYear_Click(object sender, EventArgs e)
        {
            changeDate = "Y";
            transType = "Deposit";
            lblDay.Visible = false;
            lblMonth.Visible = false;
            lblYear.Visible = true;
            lblTellerReport.Visible = true;
            lblAccOfficerReport.Visible = true;
            datePickerReport.Visible = false;
            comboUser.Visible = true;
            comboReportAccOfficer.Visible = true;
            comboMonthReport.Visible = false;
            txtYearReport.Visible = true;
        }
        private void tSWithdrawalDay_Click(object sender, EventArgs e)
        {
            changeDate = "D";
            transType = "Withdrawal";
            lblDay.Visible = true;
            lblMonth.Visible = false;
            lblYear.Visible = false;
            lblTellerReport.Visible = true;
            lblAccOfficerReport.Visible = false;
            datePickerReport.Visible = true;
            comboUser.Visible = true;
            comboReportAccOfficer.Visible = false;
            comboMonthReport.Visible = false;
            txtYearReport.Visible = false;
        }
        private void tSWithdrawalMonth_Click(object sender, EventArgs e)
        {
            changeDate = "M";
            transType = "Withdrawal";
            lblDay.Visible = false;
            lblMonth.Visible = true;
            lblYear.Visible = false;
            lblTellerReport.Visible = true;
            lblAccOfficerReport.Visible = false;
            datePickerReport.Visible = false;
            comboUser.Visible = true;
            comboReportAccOfficer.Visible = false;
            comboMonthReport.Visible = true;
            txtYearReport.Visible = false;
        }
        private void tSWithdrawalYear_Click(object sender, EventArgs e)
        {
            changeDate = "Y";
            transType = "Withdrawal";
            lblDay.Visible = false;
            lblMonth.Visible = false;
            lblYear.Visible = true;
            lblTellerReport.Visible = true;
            lblAccOfficerReport.Visible = false;
            datePickerReport.Visible = false;
            comboUser.Visible = true;
            comboReportAccOfficer.Visible = false;
            comboMonthReport.Visible = false;
            txtYearReport.Visible = true;
        }
        private void tSTransferDay_Click(object sender, EventArgs e)
        {
            changeDate = "D";
            transType = "Transfer";
            lblDay.Visible = true;
            lblMonth.Visible = false;
            lblYear.Visible = false;
            lblTellerReport.Visible = true;
            lblAccOfficerReport.Visible = false;
            datePickerReport.Visible = true;
            comboUser.Visible = true;
            comboReportAccOfficer.Visible = false;
            comboMonthReport.Visible = false;
            txtYearReport.Visible = false;
        }
        private void tSTransferMonth_Click(object sender, EventArgs e)
        {
            changeDate = "M";
            transType = "Transfer";
            lblDay.Visible = false;
            lblMonth.Visible = true;
            lblYear.Visible = false;
            lblTellerReport.Visible = true;
            lblAccOfficerReport.Visible = false;
            datePickerReport.Visible = false;
            comboUser.Visible = true;
            comboReportAccOfficer.Visible = false;
            comboMonthReport.Visible = true;
            txtYearReport.Visible = false;
        }
        private void tSTransferYear_Click(object sender, EventArgs e)
        {
            changeDate = "Y";
            transType = "Transfer";
            lblDay.Visible = false;
            lblMonth.Visible = false;
            lblYear.Visible = true;
            lblTellerReport.Visible = true;
            lblAccOfficerReport.Visible = false;
            datePickerReport.Visible = false;
            comboUser.Visible = true;
            comboReportAccOfficer.Visible = false;
            comboMonthReport.Visible = false;
            txtYearReport.Visible = true;
        }
        private void tSPfDay_Click(object sender, EventArgs e)
        {
            changeDate = "D";
            transType = "Pf";
            lblDay.Visible = true;
            lblMonth.Visible = false;
            lblYear.Visible = false;
            lblTellerReport.Visible = true;
            lblAccOfficerReport.Visible = true;
            datePickerReport.Visible = true;
            comboUser.Visible = true;
            comboReportAccOfficer.Visible = true;
            comboMonthReport.Visible = false;
            txtYearReport.Visible = false;
        }
        private void tSPfMonth_Click(object sender, EventArgs e)
        {
            changeDate = "M";
            transType = "Pf";
            lblDay.Visible = false;
            lblMonth.Visible = true;
            lblYear.Visible = false;
            lblTellerReport.Visible = true;
            lblAccOfficerReport.Visible = true;
            datePickerReport.Visible = false;
            comboUser.Visible = true;
            comboReportAccOfficer.Visible = true;
            comboMonthReport.Visible = true;
            txtYearReport.Visible = false;
        }
        private void tSPfYear_Click(object sender, EventArgs e)
        {
            changeDate = "Y";
            transType = "Pf";
            lblDay.Visible = false;
            lblMonth.Visible = false;
            lblYear.Visible = true;
            lblTellerReport.Visible = true;
            lblAccOfficerReport.Visible = true;
            datePickerReport.Visible = false;
            comboUser.Visible = true;
            comboReportAccOfficer.Visible = true;
            comboMonthReport.Visible = false;
            txtYearReport.Visible = true;
        }
        private void tSBranchDay_Click(object sender, EventArgs e)
        {
            changeDate = "D";
            transType = "Branch";
            lblDay.Visible = true;
            lblMonth.Visible = false;
            lblYear.Visible = false;
            lblTellerReport.Visible = false;
            lblAccOfficerReport.Visible = false;
            datePickerReport.Visible = true;
            comboUser.Visible = false;
            comboReportAccOfficer.Visible = false;
            comboMonthReport.Visible = false;
            txtYearReport.Visible = false;
        }
        private void tSBranchMonth_Click(object sender, EventArgs e)
        {
            changeDate = "M";
            transType = "Branch";
            lblDay.Visible = false;
            lblMonth.Visible = true;
            lblYear.Visible = false;
            lblTellerReport.Visible = false;
            lblAccOfficerReport.Visible = false;
            datePickerReport.Visible = false;
            comboUser.Visible = false;
            comboReportAccOfficer.Visible = false;
            comboMonthReport.Visible = true;
            txtYearReport.Visible = false;
        }
        private void tSBranchYear_Click(object sender, EventArgs e)
        {
            changeDate = "Y";
            transType = "Branch";
            lblDay.Visible = false;
            lblMonth.Visible = false;
            lblYear.Visible = true;
            lblTellerReport.Visible = false;
            lblAccOfficerReport.Visible = false;
            datePickerReport.Visible = false;
            comboUser.Visible = false;
            comboReportAccOfficer.Visible = false;
            comboMonthReport.Visible = false;
            txtYearReport.Visible = true;
        }
        private void btnView_Click(object sender, EventArgs e)
        {
            if (validateQuickViewReport() == 0)
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
                            if (txtAccNo.Text.Length > 0)
                            {
                                try
                                {
                                    accNumber = Convert.ToInt64(txtAccNo.Text);
                                    db.connect();
                                    db.getBalance(accNumber);
                                    db.getConnection.Close();
                                    tb = new DataTable();
                                    db.getDataAdapter.Fill(tb);
                                    long accNo = (long)tb.Rows[0]["AccountNumber"];
                                    if (accNumber == accNo)
                                    {
                                        ExposeProperties.TransactionTypeStatus = "loanQuickView";
                                        ExposeProperties.LoanQuickView = "AccountNumber";
                                        ExposeProperties.AccNumber = accNumber;
                                        new Report.ReportForm.AccountStatementReportForm().Show();
                                    }
                                }
                                catch (IndexOutOfRangeException idx)
                                {
                                    sSMessage.Visible = true;
                                    tSSMessage.Text = "Invalid account number!";
                                }
                            }
                            else if (radAccOfficer.Checked == true)
                            {
                                ExposeProperties.TransactionTypeStatus = "loanQuickView";
                                ExposeProperties.LoanQuickView = "AccountOfficer";
                                ExposeProperties.AccountOfficer = comboQuickViewAccOfficer.SelectedItem.ToString();
                                new Report.ReportForm.AccountStatementReportForm().Show();
                            }
                            else
                            {
                                ExposeProperties.TransactionTypeStatus = "loanQuickView";
                                ExposeProperties.LoanQuickView = "All";
                                new Report.ReportForm.AccountStatementReportForm().Show();
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
        private void btnClearView_Click(object sender, EventArgs e)
        {
            txtAccNo.Text = "";
            sSMessage.Visible = false;
        }

        private void txtAccNo_TextChanged(object sender, EventArgs e)
        {
            groupQuickViewOption.Visible = false;
            groupAccOfficer.Visible = false;
            if (txtAccNo.Text.Length == 0)
            {
                groupQuickViewOption.Visible = true;
            }
        }
        private void radAccOfficer_CheckedChanged(object sender, EventArgs e)
        {
            groupAccOfficer.Visible = true;
            if (radAccOfficer.Checked == false)
            {
                groupAccOfficer.Visible = false;
            }
        }
        private void checkBulkTransaction_CheckedChanged(object sender, EventArgs e)
        {
            btnDep.Text = "Bulk";

            if (checkBulkTransaction.Checked == false)
            {
                btnDep.Text = "Deposit";
            }
        }
        private void linkSupport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Support().Show();
            Hide();
        }

        private void linkNews_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new News().Show();
            Hide();
        }

        private void linkGenerateOTP_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ExposeProperties.TransactionTypeStatus = "Home";
            new OTP().Show();
        }
        private void linkExpenditure_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Expenditure().Show();
            Hide();
        }
        private void linkThreshold_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Threshold().Show();
            Hide();
        }

        private void linkTransactionApproval_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new TransactionApproval().Show();
            Hide();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            new Home().Show();
            Hide();
        }
        private void checkVault_CheckedChanged(object sender, EventArgs e)//Vault implementation
        {
            comboDepAccOff.Items.Clear();
            getBranchName();
            groupBranchName.Text = "Branch Name";
            lblAccountNumber.Text = "Vault Inflow";
            lblDep.Text = "Vault Outflow";
            comboDepAccOff.Text = "SELECT";
            if (checkVault.Checked == false)
            {
                comboDepAccOff.Items.Clear();
                getVaultAccOfficer();
                groupBranchName.Text = "Account Officer";
                lblAccountNumber.Text = "Account Number";
                lblDep.Text = "Deposit Amount";
            }
        }
        private long getHeadOfficerNumber()//Vault implementation
        {
            long accNumber = 0;
            db.connect();
            db.getHeadOfficeNumber();
            db.getConnection.Close();
            tb = new DataTable();
            db.getDataAdapter.Fill(tb);
            accNumber = (long)tb.Rows[0]["AccountNumber"];
            return accNumber;
        }
        private void checkHeadOffice_CheckedChanged(object sender, EventArgs e)//Vault implementation
        {
            getHeadOfficerNumber();
        }
        private void creditHeadOffice()//Vault implementation
        {
            int flag = 0;
            if(txtDepAccNo.Text.Length == 0)
            {
                flag = 0;
            }
            if(txtDepAmt.Text.Length == 0)
            {
                txtDepAmt.Focus();
                errorProvider.SetError(txtDepAmt, "Please enter the amount to credit Head Office");
                flag = 1;
            }
            if(flag == 0)
            {
                long amount = long.Parse(txtDepAmt.Text);
                db.connect();
                db.creditHeadOffice(amount);
                db.getConnection.Close();
                tb = new DataTable();
                db.getDataAdapter.Fill(tb);
                sSMessage.Visible = true;
                tSSMessage.Text = "N" + string.Format("{0:n}", amount) + " credited to Head Office vault" ;
            }
        }
        private void checkVaultReport_CheckedChanged(object sender, EventArgs e)
        {
            panVaultReport.Visible = true;
            if(checkVaultReport.Checked == false)
            {
                panVaultReport.Visible = false;
            }
        }
        private void btnVaultReport_Click(object sender, EventArgs e)
        {
            ExposeProperties.TransactionTypeStatus = "vault";
            if (checkVaultReport.Checked == true && checkInterval.Checked == true)
            {
                int flag = 0;
                if(comboInterval.Text.Equals("INTERVAL"))
                {
                    comboInterval.Focus();
                    errorProvider.SetError(comboInterval, "Please select the interval");
                    flag = 1;
                }
                if (flag == 0)
                {
                    ExposeProperties.TransactionType = comboInterval.SelectedItem.ToString();
                    string date = datePickerVaultReport.Value.ToString("yyyy-MM-dd");
                    ExposeProperties.Date = date;
                    new Report.ReportForm.AccountStatementReportForm().Show();
                }
            }
            else
            {
                ExposeProperties.TransactionType = "Vault";
                new Report.ReportForm.AccountStatementReportForm().Show();
            }
        }
        private void txtWithAmt_MouseHover(object sender, EventArgs e)
        {
            try
            { 
                accNumber = long.Parse(txtRecipientAccNo.Text);
                if (txtRecipientAccNo.Text.Length != 0)
                {
                    lblTransCust.Visible = true;
                    lblTransCust.Text = sendCustomerDepDetails(accNumber);
                }
            }
            catch(FormatException fe)
            {
                if (checkTrans.Checked == true)
                {
                    lblTransCust.Visible = true;
                    lblTransCust.Text = "Recipient account number required!";
                }
            }
        }
    }
}
