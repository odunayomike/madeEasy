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
using CrystalDecisions.ReportSource;
using CrystalDecisions.CrystalReports.Engine;

namespace SoftlightMF.Report.ReportForm
{
    public partial class AccountStatementReportForm : Form
    {
        DatabaseLib db = new DatabaseLib();
        DataTable tb;
        DataSet dataSet;
        TextObject title, display, output, accountName, branchName, accountNumber, accountTypeReport, currency, openingBalance;
        public AccountStatementReportForm()
        {
            InitializeComponent();
        }

        private void AccountStatementReportForm_Load(object sender, EventArgs e)
        {
            string transactionTypeStatus = ExposeProperties.TransactionTypeStatus;
            long accNumber = ExposeProperties.AccNumber;
            string accOfficer = ExposeProperties.AccountOfficer;
            string loanQuickViewStatus = ExposeProperties.LoanQuickView;

            if (transactionTypeStatus.Equals("accountType"))
            {
                accountType();
            }
            else if (transactionTypeStatus.Equals("loanQuickView"))
            {
                if (loanQuickViewStatus.Equals("AccountNumber"))
                {
                    loanQuickView(accNumber);
                }
                else if (loanQuickViewStatus.Equals("AccountOfficer"))
                {
                    loanQuickView(accOfficer);
                }
                else
                {
                    loanQuickView();
                }
            }
            else if(transactionTypeStatus.Equals("vault"))//Vault implementation
            {
                if (ExposeProperties.TransactionType.Equals("Vault"))
                {
                    vaultReport();
                }
                else
                {
                    vaultIntervalReport();
                }
            }
            else
            {
                accountStatement();
            }
        }
        private void dayDeposit(string user, string accountOfficer, string date)
        {
            Report.CrystalReport.DepositTransactionReport deposit = new CrystalReport.DepositTransactionReport();

            db.connect();
            db.transactDepositReport(user, accountOfficer, date);
            db.getConnection.Close();
            DataTable dataSet = new DataTable();
            db.getDataAdapter.Fill(dataSet);
            deposit.Database.Tables["Transaction"].SetDataSource(dataSet);

            title = (TextObject)deposit.ReportDefinition.ReportObjects["lblTitle"];
            display = (TextObject)deposit.ReportDefinition.ReportObjects["display"];
            output = (TextObject)deposit.ReportDefinition.ReportObjects["lblDisplay"];
            title.Text = "Deposit Transanction Report";
            display.Text = "DAY";
            output.Text = date + ", " + accountOfficer.ToUpper();

            accountStatementViewer.ReportSource = null;
            accountStatementViewer.ReportSource = deposit;
        }
        private void monthDeposit(string user, string accountOfficer, string date)
        {
            Report.CrystalReport.DepositTransactionReport deposit = new CrystalReport.DepositTransactionReport();

            db.connect();
            db.transactMonthDepositReport(user, accountOfficer, date);
            db.getConnection.Close();
            DataTable dataSet = new DataTable();
            db.getDataAdapter.Fill(dataSet);
            deposit.Database.Tables["Transaction"].SetDataSource(dataSet);

            title = (TextObject)deposit.ReportDefinition.ReportObjects["lblTitle"];
            display = (TextObject)deposit.ReportDefinition.ReportObjects["display"];
            output = (TextObject)deposit.ReportDefinition.ReportObjects["lblDisplay"];
            title.Text = "Deposit Transanction Report";
            display.Text = "MONTH";
            output.Text = date.ToUpper() + ", " + accountOfficer.ToUpper();

            accountStatementViewer.ReportSource = null;
            accountStatementViewer.ReportSource = deposit;
        }
        private void yearDeposit(string user, string accountOfficer, int date)
        {
            Report.CrystalReport.DepositTransactionReport deposit = new CrystalReport.DepositTransactionReport();

            db.connect();
            db.transactYearDepositReport(user, accountOfficer, date);
            db.getConnection.Close();
            DataTable dataSet = new DataTable();
            db.getDataAdapter.Fill(dataSet);
            deposit.Database.Tables["Transaction"].SetDataSource(dataSet);

            title = (TextObject)deposit.ReportDefinition.ReportObjects["lblTitle"];
            display = (TextObject)deposit.ReportDefinition.ReportObjects["display"];
            output = (TextObject)deposit.ReportDefinition.ReportObjects["lblDisplay"];
            title.Text = "Deposit Transanction Report";
            display.Text = "YEAR";
            output.Text = date + ", " + accountOfficer.ToUpper();

            accountStatementViewer.ReportSource = null;
            accountStatementViewer.ReportSource = deposit;
        }
        private void dayWithdrawal(string user, string date)
        {
            Report.CrystalReport.WithdrawalTransactionReport withdrawal = new CrystalReport.WithdrawalTransactionReport();

            db.connect();
            db.transactWithdrawalReport(user, date);
            db.getConnection.Close();
            DataTable dataSet = new DataTable();
            db.getDataAdapter.Fill(dataSet);
            withdrawal.Database.Tables["Transaction"].SetDataSource(dataSet);

            title = (TextObject)withdrawal.ReportDefinition.ReportObjects["lblTitle"];
            display = (TextObject)withdrawal.ReportDefinition.ReportObjects["display"];
            output = (TextObject)withdrawal.ReportDefinition.ReportObjects["lblDisplay"];
            title.Text = "Withdrawal Transanction Report";
            display.Text = "DAY";
            output.Text = date;

            accountStatementViewer.ReportSource = null;
            accountStatementViewer.ReportSource = withdrawal;
        }
        private void monthWithdrawal(string user, string date)
        {
            Report.CrystalReport.WithdrawalTransactionReport withdrawal = new CrystalReport.WithdrawalTransactionReport();

            db.connect();
            db.transactMonthWithdrawalReport(user, date);
            db.getConnection.Close();
            DataTable dataSet = new DataTable();
            db.getDataAdapter.Fill(dataSet);
            withdrawal.Database.Tables["Transaction"].SetDataSource(dataSet);

            display = (TextObject)withdrawal.ReportDefinition.ReportObjects["display"];
            output = (TextObject)withdrawal.ReportDefinition.ReportObjects["lblDisplay"];
            display.Text = "MONTH";
            output.Text = date.ToUpper();

            accountStatementViewer.ReportSource = null;
            accountStatementViewer.ReportSource = withdrawal;
        }
        private void yearWithdrawal(string user, int date)
        {
            Report.CrystalReport.WithdrawalTransactionReport withdrawal = new CrystalReport.WithdrawalTransactionReport();

            db.connect();
            db.transactYearWithdrawalReport(user, date);
            db.getConnection.Close();
            DataTable dataSet = new DataTable();
            db.getDataAdapter.Fill(dataSet);
            withdrawal.Database.Tables["Transaction"].SetDataSource(dataSet);

            display = (TextObject)withdrawal.ReportDefinition.ReportObjects["display"];
            output = (TextObject)withdrawal.ReportDefinition.ReportObjects["lblDisplay"];
            display.Text = "YEAR";
            output.Text = date.ToString();

            accountStatementViewer.ReportSource = null;
            accountStatementViewer.ReportSource = withdrawal;
        }
        private void dayTransfer(string user, string date)
        {
            Report.CrystalReport.TransferTransactionReport transfer = new CrystalReport.TransferTransactionReport();

            db.connect();
            db.transactTransferReport(user, date);
            db.getConnection.Close();
            DataTable dataSet = new DataTable();
            db.getDataAdapter.Fill(dataSet);
            transfer.Database.Tables["Transaction"].SetDataSource(dataSet);

            display = (TextObject)transfer.ReportDefinition.ReportObjects["display"];
            output = (TextObject)transfer.ReportDefinition.ReportObjects["lblDisplay"];
            display.Text = "DAY";
            output.Text = date;

            accountStatementViewer.ReportSource = null;
            accountStatementViewer.ReportSource = transfer;
        }
        private void monthTransfer(string user, string date)
        {
            Report.CrystalReport.TransferTransactionReport transfer = new CrystalReport.TransferTransactionReport();

            db.connect();
            db.transactMonthTransferReport(user, date);
            db.getConnection.Close();
            DataTable dataSet = new DataTable();
            db.getDataAdapter.Fill(dataSet);
            transfer.Database.Tables["Transaction"].SetDataSource(dataSet);

            display = (TextObject)transfer.ReportDefinition.ReportObjects["display"];
            output = (TextObject)transfer.ReportDefinition.ReportObjects["lblDisplay"];
            display.Text = "MONTH";
            output.Text = date.ToUpper();

            accountStatementViewer.ReportSource = null;
            accountStatementViewer.ReportSource = transfer;
        }
        private void yearTransfer(string user, int date)
        {
            Report.CrystalReport.TransferTransactionReport transfer = new CrystalReport.TransferTransactionReport();

            db.connect();
            db.transactYearTransferReport(user, date);
            db.getConnection.Close();
            DataTable dataSet = new DataTable();
            db.getDataAdapter.Fill(dataSet);
            transfer.Database.Tables["Transaction"].SetDataSource(dataSet);

            display = (TextObject)transfer.ReportDefinition.ReportObjects["display"];
            output = (TextObject)transfer.ReportDefinition.ReportObjects["lblDisplay"];
            display.Text = "YEAR";
            output.Text = date.ToString();

            accountStatementViewer.ReportSource = null;
            accountStatementViewer.ReportSource = transfer;
        }
        private void dayPf(string user, string accountOfficer, string date)
        {
            Report.CrystalReport.DepositTransactionReport pf = new CrystalReport.DepositTransactionReport();

            db.connect();
            db.transactPfReport(user, accountOfficer, date);
            db.getConnection.Close();
            DataTable dataSet = new DataTable();
            db.getDataAdapter.Fill(dataSet);
            pf.Database.Tables["Transaction"].SetDataSource(dataSet);

            title = (TextObject)pf.ReportDefinition.ReportObjects["lblTitle"];
            display = (TextObject)pf.ReportDefinition.ReportObjects["display"];
            output = (TextObject)pf.ReportDefinition.ReportObjects["lblDisplay"];
            title.Text = "PF Transanction Report";
            display.Text = "DAY";
            output.Text = date;

            accountStatementViewer.ReportSource = null;
            accountStatementViewer.ReportSource = pf;
        }
        private void monthPf(string user, string accountOfficer, string date)
        {
            Report.CrystalReport.DepositTransactionReport pf = new CrystalReport.DepositTransactionReport();

            db.connect();
            db.transactMonthPfReport(user, accountOfficer, date);
            db.getConnection.Close();
            DataTable dataSet = new DataTable();
            db.getDataAdapter.Fill(dataSet);
            pf.Database.Tables["Transaction"].SetDataSource(dataSet);

            title = (TextObject)pf.ReportDefinition.ReportObjects["lblTitle"];
            display = (TextObject)pf.ReportDefinition.ReportObjects["display"];
            output = (TextObject)pf.ReportDefinition.ReportObjects["lblDisplay"];
            title.Text = "PF Transanction Report";
            display.Text = "MONTH";
            output.Text = date.ToUpper();

            accountStatementViewer.ReportSource = null;
            accountStatementViewer.ReportSource = pf;
        }
        private void yearPf(string user, string accountOfficer, int date)
        {
            Report.CrystalReport.DepositTransactionReport pf = new CrystalReport.DepositTransactionReport();

            db.connect();
            db.transactYearPfReport(user, accountOfficer, date);
            db.getConnection.Close();
            DataTable dataSet = new DataTable();
            db.getDataAdapter.Fill(dataSet);
            pf.Database.Tables["Transaction"].SetDataSource(dataSet);

            title = (TextObject)pf.ReportDefinition.ReportObjects["lblTitle"];
            display = (TextObject)pf.ReportDefinition.ReportObjects["display"];
            output = (TextObject)pf.ReportDefinition.ReportObjects["lblDisplay"];
            title.Text = "PF Transanction Report";
            display.Text = "YEAR";
            output.Text = date.ToString();

            accountStatementViewer.ReportSource = null;
            accountStatementViewer.ReportSource = pf;
        }
        private void accountType()
        {
            string transactionType = ExposeProperties.TransactionType;
            string user = ExposeProperties.UserLogin.ToString();
            string date = ExposeProperties.Date;
            string month = ExposeProperties.ReportMonth;
            int year = ExposeProperties.ReportYear;
            string accountOfficer = ExposeProperties.AccountOfficer;

            if (transactionType.Equals("Deposit"))
            {
                if (date.Equals("M"))
                {

                    monthDeposit(user, accountOfficer, month);
                }
                else if (date.Equals("Y"))
                {
                    yearDeposit(user, accountOfficer, year);
                }
                else
                {
                    dayDeposit(user, accountOfficer, date);
                }
            }
            else if (transactionType.Equals("Withdrawal"))
            {
                if (date.Equals("M"))
                {
                    monthWithdrawal(user, month);
                }
                else if (date.Equals("Y"))
                {
                    yearWithdrawal(user, year);
                }
                else
                {
                    dayWithdrawal(user, date);
                }
            }
            else if (transactionType.Equals("Transfer"))
            {
                if (date.Equals("M"))
                {
                    monthTransfer(user, month);
                }
                else if (date.Equals("Y"))
                {
                    yearTransfer(user, year);
                }
                else
                {
                    dayTransfer(user, date);
                }
            }
            else if (transactionType.Equals("Pf"))
            {
                if (date.Equals("M"))
                {

                    monthPf(user, accountOfficer, month);
                }
                else if (date.Equals("Y"))
                {
                    yearPf(user, accountOfficer, year);
                }
                else
                {
                    dayPf(user, accountOfficer, date);
                }
            }
            else
            {
                Report.CrystalReport.AllTransactionReport all = new CrystalReport.AllTransactionReport();
                db.connect();
                db.allTransactionReport(user, date);
                db.getConnection.Close();
                dataSet = new DataSet();
                db.getDataAdapter.Fill(dataSet);
                all.Database.Tables["Transaction"].SetDataSource(dataSet.Tables[0]);

                accountStatementViewer.ReportSource = null;
                accountStatementViewer.ReportSource = all;
            }
        }
        private long getOpeningBalance()
        {
            long openingBalance = 0;

            db.connect();
            db.getOpeningBalance(ExposeProperties.AccNumber);
            db.getConnection.Close();
            tb = new DataTable();
            db.getDataAdapter.Fill(tb);
            openingBalance = long.Parse(tb.Rows[0]["OpeningBalance"].ToString());

            return openingBalance;
        }
        private void accountStatement()
        {
            try
            {
                Report.CrystalReport.AccountStatementReport custReport = null;

                if (ExposeProperties.TransactionType.Equals("All"))
                {
                    custReport = new CrystalReport.AccountStatementReport();
                    db.connect();
                    db.getAllCustomerStatement(ExposeProperties.AccNumber);
                    db.getConnection.Close();
                    tb = new DataTable();
                    db.getDataAdapter.Fill(tb);
                    custReport.Database.Tables["TransactionLog"].SetDataSource(tb);

                    accountName = (TextObject)custReport.ReportDefinition.ReportObjects["accountName"];
                    output = (TextObject)custReport.ReportDefinition.ReportObjects["lblDisplay"];
                    branchName = (TextObject)custReport.ReportDefinition.ReportObjects["branchName"];
                    accountNumber = (TextObject)custReport.ReportDefinition.ReportObjects["accountNumber"];
                    accountTypeReport = (TextObject)custReport.ReportDefinition.ReportObjects["accountTypeReport"];
                    currency = (TextObject)custReport.ReportDefinition.ReportObjects["currency"];
                    openingBalance = (TextObject)custReport.ReportDefinition.ReportObjects["openingBalance"];

                    output.Text = "All Statement";
                    accountName.Text = ExposeProperties.FullName.ToUpper();
                    branchName.Text = "";//ExposeProperties.BranchName.ToUpper();
                    accountNumber.Text = ExposeProperties.AccNumber.ToString();
                    accountTypeReport.Text = ExposeProperties.AccountTypeReport.ToUpper();
                    currency.Text = "Naira";
                    openingBalance.Text = getOpeningBalance().ToString();

                    accountStatementViewer.ReportSource = null;
                    accountStatementViewer.ReportSource = custReport;
                }
                else
                {
                    custReport = new CrystalReport.AccountStatementReport();
                    db.connect();
                    db.getSpecificCustomerStatement(ExposeProperties.AccNumber, ExposeProperties.FromDate, ExposeProperties.ToDate);
                    db.getConnection.Close();
                    tb = new DataTable();
                    db.getDataAdapter.Fill(tb);
                    custReport.Database.Tables["TransactionLog"].SetDataSource(tb);

                    accountName = (TextObject)custReport.ReportDefinition.ReportObjects["accountName"];
                    output = (TextObject)custReport.ReportDefinition.ReportObjects["lblDisplay"];
                    branchName = (TextObject)custReport.ReportDefinition.ReportObjects["branchName"];
                    accountNumber = (TextObject)custReport.ReportDefinition.ReportObjects["accountNumber"];
                    accountTypeReport = (TextObject)custReport.ReportDefinition.ReportObjects["accountTypeReport"];
                    currency = (TextObject)custReport.ReportDefinition.ReportObjects["currency"];
                    openingBalance = (TextObject)custReport.ReportDefinition.ReportObjects["openingBalance"];

                    output.Text = "Peroid: From " + ExposeProperties.FromDate + " To " + ExposeProperties.ToDate;
                    accountName.Text = ExposeProperties.FullName.ToUpper();
                    branchName.Text = "";//ExposeProperties.BranchName.ToUpper();
                    accountNumber.Text = ExposeProperties.AccNumber.ToString();
                    accountTypeReport.Text = ExposeProperties.AccountTypeReport.ToUpper();
                    currency.Text = "Naira";
                    openingBalance.Text = getOpeningBalance().ToString();

                    accountStatementViewer.ReportSource = null;
                    accountStatementViewer.ReportSource = custReport;
                }
            }
            catch (System.Runtime.InteropServices.COMException rics)
            {
                MessageBox.Show(rics.Message);
            }
        }
        private void loanQuickView(long accNumber)
        {
            Report.CrystalReport.LoanQuickViewReport loanQuickView = new CrystalReport.LoanQuickViewReport();
            db.connect();
            db.loanQuickView(accNumber);
            db.getConnection.Close();
            dataSet = new DataSet();
            db.getDataAdapter.Fill(dataSet);
            db.connect();
            loanQuickView.Database.Tables["LoanQuickView"].SetDataSource(dataSet.Tables[0]);

            display = (TextObject)loanQuickView.ReportDefinition.ReportObjects["display"];
            output = (TextObject)loanQuickView.ReportDefinition.ReportObjects["lblDisplay"];
            display.Text = "Account Number";
            output.Text = accNumber.ToString();

            accountStatementViewer.ReportSource = null;
            accountStatementViewer.ReportSource = loanQuickView;
        }
        private void loanQuickView(string accountOfficer)
        {
            Report.CrystalReport.LoanQuickViewReport loanQuickView = new CrystalReport.LoanQuickViewReport();
            db.connect();
            db.loanQuickView(accountOfficer);
            db.getConnection.Close();
            dataSet = new DataSet();
            db.getDataAdapter.Fill(dataSet);
            db.connect();
            loanQuickView.Database.Tables["LoanQuickView"].SetDataSource(dataSet.Tables[0]);

            display = (TextObject)loanQuickView.ReportDefinition.ReportObjects["display"];
            output = (TextObject)loanQuickView.ReportDefinition.ReportObjects["lblDisplay"];
            display.Text = "Account Officer";
            output.Text = accountOfficer.ToUpper();

            accountStatementViewer.ReportSource = null;
            accountStatementViewer.ReportSource = loanQuickView;
        }
        private void loanQuickView()
        {
            Report.CrystalReport.LoanQuickViewReport loanQuickView = new CrystalReport.LoanQuickViewReport();
            db.connect();
            db.loanQuickView();
            db.getConnection.Close();
            dataSet = new DataSet();
            db.getDataAdapter.Fill(dataSet);
            db.connect();
            loanQuickView.Database.Tables["LoanQuickView"].SetDataSource(dataSet.Tables[0]);

            display = (TextObject)loanQuickView.ReportDefinition.ReportObjects["display"];
            output = (TextObject)loanQuickView.ReportDefinition.ReportObjects["lblDisplay"];
            display.Text = "";
            output.Text = "All quick view report".ToUpper();

            accountStatementViewer.ReportSource = null;
            accountStatementViewer.ReportSource = loanQuickView;
        }
        private void vaultIntervalReport()//Vault implementation
        {
            Report.CrystalReport.VaultReport vault = new CrystalReport.VaultReport();
            db.connect();
            db.vaultIntervalReport(ExposeProperties.TransactionType, ExposeProperties.Date);
            db.getConnection.Close();
            dataSet = new DataSet();
            db.getDataAdapter.Fill(dataSet);
            db.connect();
            vault.Database.Tables["Vault"].SetDataSource(dataSet.Tables[0]);

            display = (TextObject)vault.ReportDefinition.ReportObjects["display"];
            output = (TextObject)vault.ReportDefinition.ReportObjects["lblDisplay"];
            display.Text = ExposeProperties.TransactionType;
            output.Text = "Date formant (YYYY-MM-DD) "+ExposeProperties.Date;

            accountStatementViewer.ReportSource = null;
            accountStatementViewer.ReportSource = vault;
        }
        private void vaultReport()//Vault implementation
        {
            Report.CrystalReport.VaultReport vault = new CrystalReport.VaultReport();
            db.connect();
            db.vaultReport();
            db.getConnection.Close();
            dataSet = new DataSet();
            db.getDataAdapter.Fill(dataSet);
            db.connect();
            vault.Database.Tables["Vault"].SetDataSource(dataSet.Tables[0]);

            accountStatementViewer.ReportSource = null;
            accountStatementViewer.ReportSource = vault;
        }
    }
}
