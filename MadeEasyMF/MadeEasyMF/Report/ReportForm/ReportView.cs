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

namespace SoftlightMF
{
    public partial class ReportView : Form
    {
        private DatabaseLib db = new DatabaseLib();
        private DataSet dataSet;
        private DateTime dt, monthDate;
        private string branchStatus, branchName, day, month, accOfficer, sub, username;
        private int year;
        private TextObject title, display, output;

        public ReportView()
        {
            InitializeComponent();
            getFilledAccountType();
            getBranchName();
            getAccountOfficer();
            getGroupName();
            dt = databaseDate();
            branchStatus = null;
            getRole();
            getUser();
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
                tSComboUserCallOver.Items.Add(dr["Username"].ToString());
            }
        }
        private void getUser()
        {
            if (ExposeProperties.OtherUsers != true)
            {
                tSComboUserCallOver.Items.Add(ExposeProperties.Username);
            }
            else
            {
                user();
            }
        }
        private void getRole()
        {
            accountTypeToolStripMenuItem.Enabled = ExposeProperties.AccountReport;
            loanToolStripMenuItem.Enabled = ExposeProperties.LoanPortfolio;
            branchTransactionToolStripMenuItem.Enabled = ExposeProperties.BranchTrans;
            performanceToolStripMenuItem.Enabled = ExposeProperties.Performance;
            incomeOverviewToolStripMenuItem.Enabled = ExposeProperties.IncomeOverview;
            callOverToolStripMenuItem.Enabled = ExposeProperties.CallOver;
            dashboardToolStripMenuItem.Enabled = ExposeProperties.Dashboard;
        }
        private DateTime databaseDate()
        {
            DateTime date = DateTime.Now;
            try
            {
                db.connect();
                db.dbDate();
                db.getConnection.Close();
                DataTable tb = new DataTable();
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
        private void getFilledAccountType()
        {
            db.connect();
            db.getAccountType();
            db.getConnection.Close();
            DataTable tb = new DataTable();
            db.getDataAdapter.Fill(tb);
            foreach (DataRow dr in tb.Rows)
            {
                tSComboAccountType.Items.Add(dr["AccountType"].ToString());
            }
        }
        private void getAccountOfficer()
        {
            try
            {
                string accountOfficer = "ACCOUNT OFFICER";
                db.connect();
                db.getAccountOfficer(accountOfficer);
                db.getConnection.Close();
                DataTable tb = new DataTable();
                db.getDataAdapter.Fill(tb);

                foreach (DataRow dr in tb.Rows)
                {
                    tSComboAccOffBalancedLoan.Items.Add(dr["FirstName"].ToString());
                    tSComboAccOffUnbalancedLoan.Items.Add(dr["FirstName"].ToString());
                    tSComboAccountOfficerReg.Items.Add(dr["FirstName"].ToString());
                    tSComboAccOfficerOverdue.Items.Add(dr["FirstName"].ToString());
                    tSComboAccOffMonthlyPerformance.Items.Add(dr["FirstName"].ToString());
                    tSComboAccOfficerDefault.Items.Add(dr["FirstName"].ToString());
                    tSComboAccOfficerCallOver.Items.Add(dr["FirstName"].ToString());
                    tSAccountOfficerCoverage.Items.Add(dr["FirstName"].ToString());
                }
            }
            catch (SqlException sql)
            {
                MessageBox.Show(sql.Message);
            }
        }
        private void getDayMonth()
        {
            string[] date = { "DAY", "MONTH", "YEAR" };
            foreach (string getDate in date)
            {
                tSComboMonthCallOver.Items.Add(getDate);
                tSComboMonthDashboard.Items.Add(getDate);
                tSComboAllMonthDashboard.Items.Add(getDate);
                tSComboMonthDeposit.Items.Add(getDate);
                tSComboMonthWithdrawal.Items.Add(getDate);
                tSComboMonthPf.Items.Add(getDate);
                tSComboMonthTransfer.Items.Add(getDate);
                tSComboMonthlyDisburse.Items.Add(getDate);
                tSComboAllMonthDisburse.Items.Add(getDate);
                tSComboCoverage.Items.Add(getDate);
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
                tSComboBranchBalancedLoan.Items.Add(dr["BranchName"].ToString());
                tSComboBranchUnbalancedLoan.Items.Add(dr["BranchName"].ToString());
                tSComboBranchReg.Items.Add(dr["BranchName"].ToString());
                tSComboBranchOverdue.Items.Add(dr["BranchName"].ToString());
                tSComboBranchDeposit.Items.Add(dr["BranchName"].ToString());
                tSComboBranchPf.Items.Add(dr["BranchName"].ToString());
                tSComboBranchTransfer.Items.Add(dr["BranchName"].ToString());
                tSComboBranchWithdrawal.Items.Add(dr["BranchName"].ToString());
                tSComboBranchPerformance.Items.Add(dr["BranchName"].ToString());
                tSComboDormantAccount.Items.Add(dr["BranchName"].ToString());
                tSComboBranchIncome.Items.Add(dr["BranchName"].ToString());
                tSComboBranchDisburse.Items.Add(dr["BranchName"].ToString());
                tSComboBranchDefault.Items.Add(dr["BranchName"].ToString());
                tSComboBranchDashboard.Items.Add(dr["BranchName"].ToString());
            }
        }
        private void getGroupName()
        {
            db.connect();
            db.getGroupName();
            db.getConnection.Close();
            DataTable tb = new DataTable();
            db.getDataAdapter.Fill(tb);

            foreach (DataRow dr in tb.Rows)
            {
                tSComboGroupReg.Items.Add(dr["GroupName"].ToString());
                tSComboLoanGroupName.Items.Add(dr["GroupName"].ToString());
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
        //Reporting session
        private void accountTypeDetails()
        {
            try
            {
                string accountType = tSComboAccountType.SelectedItem.ToString();
                db.connect();
                db.accountTypeDetails(accountType);
                db.getConnection.Close();
                dataSet = new DataSet();
                db.getDataAdapter.Fill(dataSet);

                Report.CrystalReport.AccountTypeReport accountTypeReport = new Report.CrystalReport.AccountTypeReport();
                accountTypeReport.Database.Tables["CountAccountType"].SetDataSource(dataSet.Tables[0]);
                accountTypeReport.Database.Tables["AccountTypeBalance"].SetDataSource(dataSet.Tables[1]);

                display = (TextObject)accountTypeReport.ReportDefinition.ReportObjects["display"];
                output = (TextObject)accountTypeReport.ReportDefinition.ReportObjects["lblDisplay"];
                display.Text = "ACCOUNT TYPE";
                output.Text = accountType.ToUpper();

                accountTypeViewer.Visible = true;
                accountTypeViewer.ReportSource = null;
                accountTypeViewer.ReportSource = accountTypeReport;
            }
            catch (NullReferenceException nre)
            {
                tSComboAccountType.Text = null;
            }
        }
        private void monthlyBalancedAccOfficer()
        {
            try
            {
                accOfficer = tSComboAccOffBalancedLoan.SelectedItem.ToString();
                monthDate = DateTime.Parse(datePicker.Text);
                int convertDate = monthDate.Month;
                month = datePicker.Text;
                db.connect();
                db.monthlyBalancedAccOfficer(accOfficer, month);
                db.getConnection.Close();
                dataSet = new DataSet();
                db.getDataAdapter.Fill(dataSet);
                Report.CrystalReport.AllBalancedLoanReport balancedLoan = new Report.CrystalReport.AllBalancedLoanReport();
                balancedLoan.Database.Tables["LoanPortfolio"].SetDataSource(dataSet.Tables[0]);

                display = (TextObject)balancedLoan.ReportDefinition.ReportObjects["display"];
                output = (TextObject)balancedLoan.ReportDefinition.ReportObjects["lblDisplay"];
                display.Text = "MONTH";
                output.Text = month.ToUpper() + ", " + accOfficer.ToUpper();

                accountTypeViewer.Visible = true;
                accountTypeViewer.ReportSource = null;
                accountTypeViewer.ReportSource = balancedLoan;
            }
            catch (SqlException sql)
            {
                MessageBox.Show(sql.Message);
            }
            catch (NullReferenceException nre)
            {

            }
        }
        private void yearlyBalancedAccOfficer()
        {
            try
            {
                accOfficer = tSComboAccOffBalancedLoan.SelectedItem.ToString();
                year = int.Parse(tSTxtAccOffYearBalancedLoan.Text);
                db.connect();
                db.yearlyBalancedAccOfficer(accOfficer, year);
                db.getConnection.Close();
                dataSet = new DataSet();
                db.getDataAdapter.Fill(dataSet);
                Report.CrystalReport.AllBalancedLoanReport balancedLoan = new Report.CrystalReport.AllBalancedLoanReport();
                balancedLoan.Database.Tables["LoanPortfolio"].SetDataSource(dataSet.Tables[0]);

                display = (TextObject)balancedLoan.ReportDefinition.ReportObjects["display"];
                output = (TextObject)balancedLoan.ReportDefinition.ReportObjects["lblDisplay"];
                display.Text = "YEAR";
                output.Text = year + ", " + accOfficer.ToUpper();

                accountTypeViewer.Visible = true;
                accountTypeViewer.ReportSource = null;
                accountTypeViewer.ReportSource = balancedLoan;
            }
            catch (SqlException sql)
            {
                MessageBox.Show(sql.Message);
            }
            catch (NullReferenceException nre)
            {

            }
        }
        private void monthlyBalancedBranch()
        {
            try
            {
                branchName = tSComboBranchBalancedLoan.SelectedItem.ToString();
                monthDate = DateTime.Parse(datePicker.Text);
                int convertDate = monthDate.Month;
                month = datePicker.Text;
                db.connect();
                db.monthlyBalancedBranch(branchName, month);
                db.getConnection.Close();
                dataSet = new DataSet();
                db.getDataAdapter.Fill(dataSet);
                Report.CrystalReport.AllBalancedLoanReport balancedLoan = new Report.CrystalReport.AllBalancedLoanReport();
                balancedLoan.Database.Tables["LoanPortfolio"].SetDataSource(dataSet.Tables[0]);

                display = (TextObject)balancedLoan.ReportDefinition.ReportObjects["display"];
                output = (TextObject)balancedLoan.ReportDefinition.ReportObjects["lblDisplay"];
                display.Text = "MONTH";
                output.Text = month.ToUpper() + ", " + branchName.ToUpper() + " " + "BRANCH";

                accountTypeViewer.Visible = true;
                accountTypeViewer.ReportSource = null;
                accountTypeViewer.ReportSource = balancedLoan;
            }
            catch (SqlException sql)
            {
                MessageBox.Show(sql.Message);
            }
            catch (NullReferenceException nre)
            {

            }
        }
        private void yearlyBalancedBranch()
        {
            try
            {
                branchName = tSComboBranchBalancedLoan.SelectedItem.ToString();
                year = int.Parse(tSTxtBranchYearBalancedLoan.Text);
                db.connect();
                db.yearlyBalancedBranch(branchName, year);
                db.getConnection.Close();
                dataSet = new DataSet();
                db.getDataAdapter.Fill(dataSet);
                Report.CrystalReport.AllBalancedLoanReport balancedLoan = new Report.CrystalReport.AllBalancedLoanReport();
                balancedLoan.Database.Tables["LoanPortfolio"].SetDataSource(dataSet.Tables[0]);

                display = (TextObject)balancedLoan.ReportDefinition.ReportObjects["display"];
                output = (TextObject)balancedLoan.ReportDefinition.ReportObjects["lblDisplay"];
                display.Text = "YEAR";
                output.Text = year + ", " + branchName.ToUpper() + " " + "BRANCH";

                accountTypeViewer.Visible = true;
                accountTypeViewer.ReportSource = null;
                accountTypeViewer.ReportSource = balancedLoan;
            }
            catch (SqlException sql)
            {
                MessageBox.Show(sql.Message);
            }
            catch (NullReferenceException nre)
            {

            }
        }
        private void monthlyUnbalancedAccOfficer()
        {
            try
            {
                accOfficer = tSComboAccOffUnbalancedLoan.SelectedItem.ToString();
                monthDate = DateTime.Parse(datePicker.Text);
                int convertDate = monthDate.Month;
                month = datePicker.Text;
                db.connect();
                db.monthlyUnbalancedAccOfficer(accOfficer, month);
                db.getConnection.Close();
                dataSet = new DataSet();
                db.getDataAdapter.Fill(dataSet);
                Report.CrystalReport.AllUnbalancedLoanReport unbalancedLoan = new Report.CrystalReport.AllUnbalancedLoanReport();
                unbalancedLoan.Database.Tables["LoanPortfolio"].SetDataSource(dataSet.Tables[0]);

                title = (TextObject)unbalancedLoan.ReportDefinition.ReportObjects["lblTitle"];
                display = (TextObject)unbalancedLoan.ReportDefinition.ReportObjects["display"];
                output = (TextObject)unbalancedLoan.ReportDefinition.ReportObjects["lblDisplay"];
                title.Text = "Unbalanced Loan Report";
                display.Text = "MONTH";
                output.Text = month.ToUpper() + ", " + accOfficer.ToUpper();

                accountTypeViewer.Visible = true;
                accountTypeViewer.ReportSource = null;
                accountTypeViewer.ReportSource = unbalancedLoan;
            }
            catch (SqlException sql)
            {
                MessageBox.Show(sql.Message);
            }
            catch (NullReferenceException nre)
            {

            }
        }
        private void yearlyUnbalancedAccOfficer()
        {
            try
            {
                accOfficer = tSComboAccOffUnbalancedLoan.SelectedItem.ToString();
                year = int.Parse(tSTxtAccOffYearUnbalancedLoan.Text);
                db.connect();
                db.yearlyUnbalancedAccOfficer(accOfficer, year);
                db.getConnection.Close();
                dataSet = new DataSet();
                db.getDataAdapter.Fill(dataSet);
                Report.CrystalReport.AllUnbalancedLoanReport unbalancedLoan = new Report.CrystalReport.AllUnbalancedLoanReport();
                unbalancedLoan.Database.Tables["LoanPortfolio"].SetDataSource(dataSet.Tables[0]);

                title = (TextObject)unbalancedLoan.ReportDefinition.ReportObjects["lblTitle"];
                display = (TextObject)unbalancedLoan.ReportDefinition.ReportObjects["display"];
                output = (TextObject)unbalancedLoan.ReportDefinition.ReportObjects["lblDisplay"];
                title.Text = "Unbalanced Loan Report";
                display.Text = "YEAR";
                output.Text = year + ", " + accOfficer.ToUpper();

                accountTypeViewer.Visible = true;
                accountTypeViewer.ReportSource = null;
                accountTypeViewer.ReportSource = unbalancedLoan;
            }
            catch (SqlException sql)
            {
                MessageBox.Show(sql.Message);
            }
            catch (NullReferenceException nre)
            {

            }
        }
        private void monthlyUnbalancedBranch()
        {
            try
            {
                branchName = tSComboBranchUnbalancedLoan.SelectedItem.ToString();
                monthDate = DateTime.Parse(datePicker.Text);
                int convertDate = monthDate.Month;
                month = datePicker.Text;
                db.connect();
                db.monthlyUnbalancedBranch(branchName, month);
                db.getConnection.Close();
                dataSet = new DataSet();
                db.getDataAdapter.Fill(dataSet);
                Report.CrystalReport.AllUnbalancedLoanReport unbalancedLoan = new Report.CrystalReport.AllUnbalancedLoanReport();
                unbalancedLoan.Database.Tables["LoanPortfolio"].SetDataSource(dataSet.Tables[0]);

                title = (TextObject)unbalancedLoan.ReportDefinition.ReportObjects["lblTitle"];
                display = (TextObject)unbalancedLoan.ReportDefinition.ReportObjects["display"];
                output = (TextObject)unbalancedLoan.ReportDefinition.ReportObjects["lblDisplay"];
                title.Text = "Unbalanced Loan Report";
                display.Text = "MONTH";
                output.Text = month.ToUpper() + ", " + branchName.ToUpper() + " " + "BRANCH";

                accountTypeViewer.Visible = true;
                accountTypeViewer.ReportSource = null;
                accountTypeViewer.ReportSource = unbalancedLoan;
            }
            catch (SqlException sql)
            {
                MessageBox.Show(sql.Message);
            }
            catch (NullReferenceException nre)
            {

            }
        }
        private void yearlyUnbalancedBranch()
        {
            try
            {
                branchName = tSComboBranchUnbalancedLoan.SelectedItem.ToString();
                year = int.Parse(tSTxtBranchYearUnbalancedLoan.Text);
                db.connect();
                db.yearlyUnbalancedBranch(branchName, year);
                db.getConnection.Close();
                dataSet = new DataSet();
                db.getDataAdapter.Fill(dataSet);
                Report.CrystalReport.AllUnbalancedLoanReport unbalancedLoan = new Report.CrystalReport.AllUnbalancedLoanReport();
                unbalancedLoan.Database.Tables["LoanPortfolio"].SetDataSource(dataSet.Tables[0]);

                title = (TextObject)unbalancedLoan.ReportDefinition.ReportObjects["lblTitle"];
                display = (TextObject)unbalancedLoan.ReportDefinition.ReportObjects["display"];
                output = (TextObject)unbalancedLoan.ReportDefinition.ReportObjects["lblDisplay"];
                title.Text = "Unbalanced Loan Report";
                display.Text = "YEAR";
                output.Text = year + ", " + branchName.ToUpper() + " " + "BRANCH";

                accountTypeViewer.Visible = true;
                accountTypeViewer.ReportSource = null;
                accountTypeViewer.ReportSource = unbalancedLoan;
            }
            catch (SqlException sql)
            {
                MessageBox.Show(sql.Message);
            }
            catch (NullReferenceException nre)
            {

            }
        }
        private void accountMonth()
        {
            try
            {
                monthDate = DateTime.Parse(datePicker.Text);
                int convertDate = monthDate.Month;
                month = datePicker.Text;
                db.connect();
                db.customerRegMonth(month);
                db.getConnection.Close();
                dataSet = new DataSet();
                db.getDataAdapter.Fill(dataSet);

                Report.CrystalReport.CustomerRegReport customerReport = new Report.CrystalReport.CustomerRegReport();
                customerReport.Database.Tables["CustomerReg"].SetDataSource(dataSet.Tables[0]);

                display = (TextObject)customerReport.ReportDefinition.ReportObjects["display"];
                output = (TextObject)customerReport.ReportDefinition.ReportObjects["lblDisplay"];
                display.Text = "MONTH";
                output.Text = month.ToUpper();

                accountTypeViewer.Visible = true;
                accountTypeViewer.ReportSource = null;
                accountTypeViewer.ReportSource = customerReport;
            }
            catch (NullReferenceException nre)
            {
                tSComboAccountType.Text = null;
            }
        }
        private void accountYear()
        {
            try
            {
                year = int.Parse(tSTxtYear.Text);
                db.connect();
                db.customerRegYear(year);
                db.getConnection.Close();
                dataSet = new DataSet();
                db.getDataAdapter.Fill(dataSet);

                Report.CrystalReport.CustomerRegReport customerReport = new Report.CrystalReport.CustomerRegReport();
                customerReport.Database.Tables["CustomerReg"].SetDataSource(dataSet.Tables[0]);

                display = (TextObject)customerReport.ReportDefinition.ReportObjects["display"];
                output = (TextObject)customerReport.ReportDefinition.ReportObjects["lblDisplay"];
                display.Text = "YEAR";
                output.Text = year.ToString();

                accountTypeViewer.Visible = true;
                accountTypeViewer.ReportSource = null;
                accountTypeViewer.ReportSource = customerReport;
            }
            catch (NullReferenceException nre)
            {
                tSComboAccountType.Text = null;
            }
        }
        private void branchReg()
        {
            try
            {
                branchName = tSComboBranchReg.SelectedItem.ToString();
                monthDate = DateTime.Parse(datePicker.Text);
                int convertDate = monthDate.Month;
                month = datePicker.Text;
                db.connect();
                db.customerRegBranch(month, branchName);
                db.getConnection.Close();
                dataSet = new DataSet();
                db.getDataAdapter.Fill(dataSet);

                Report.CrystalReport.CustomerRegReport customerReport = new Report.CrystalReport.CustomerRegReport();
                customerReport.Database.Tables["CustomerReg"].SetDataSource(dataSet.Tables[0]);

                display = (TextObject)customerReport.ReportDefinition.ReportObjects["display"];
                output = (TextObject)customerReport.ReportDefinition.ReportObjects["lblDisplay"];
                display.Text = "MONTH";
                output.Text = month.ToUpper() + "' " + branchName.ToUpper() + " " + "BRANCH";

                accountTypeViewer.Visible = true;
                accountTypeViewer.ReportSource = null;
                accountTypeViewer.ReportSource = customerReport;
            }
            catch (NullReferenceException nre)
            {
                MessageBox.Show("Please select the month before selecting the branch", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void accountOfficerReg()
        {
            try
            {
                accOfficer = tSComboAccountOfficerReg.SelectedItem.ToString();
                monthDate = DateTime.Parse(datePicker.Text);
                int convertDate = monthDate.Month;
                month = datePicker.Text;
                db.connect();
                db.customerRegAccountOfficer(month, accOfficer);
                db.getConnection.Close();
                dataSet = new DataSet();
                db.getDataAdapter.Fill(dataSet);

                Report.CrystalReport.CustomerRegReport customerReport = new Report.CrystalReport.CustomerRegReport();
                customerReport.Database.Tables["CustomerReg"].SetDataSource(dataSet.Tables[0]);

                display = (TextObject)customerReport.ReportDefinition.ReportObjects["display"];
                output = (TextObject)customerReport.ReportDefinition.ReportObjects["lblDisplay"];
                display.Text = "MONTH";
                output.Text = month.ToUpper() + "' " + accOfficer.ToUpper();

                accountTypeViewer.Visible = true;
                accountTypeViewer.ReportSource = null;
                accountTypeViewer.ReportSource = customerReport;
            }
            catch (NullReferenceException nre)
            {
                MessageBox.Show("Please select the month before selecting the branch", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void groupReg()
        {
            try
            {
                string groupName = tSComboGroupReg.SelectedItem.ToString();
                monthDate = DateTime.Parse(datePicker.Text);
                int convertDate = monthDate.Month;
                month = datePicker.Text;
                db.connect();
                db.customerRegGroup(month, groupName);
                db.getConnection.Close();
                dataSet = new DataSet();
                db.getDataAdapter.Fill(dataSet);

                Report.CrystalReport.CustomerRegReport customerReport = new Report.CrystalReport.CustomerRegReport();
                customerReport.Database.Tables["CustomerReg"].SetDataSource(dataSet.Tables[0]);

                display = (TextObject)customerReport.ReportDefinition.ReportObjects["display"];
                output = (TextObject)customerReport.ReportDefinition.ReportObjects["lblDisplay"];
                display.Text = "MONTH";
                output.Text = month.ToUpper() + "' " + groupName.ToUpper() + " " + "GROUP";

                accountTypeViewer.Visible = true;
                accountTypeViewer.ReportSource = null;
                accountTypeViewer.ReportSource = customerReport;
            }
            catch (NullReferenceException nre)
            {
                MessageBox.Show("Please select the month before selecting the branch", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void branchOverdueLoan()
        {
            try
            {
                branchName = tSComboBranchOverdue.SelectedItem.ToString();
                db.connect();
                db.branchOverdueLoanReport(branchName);
                db.getConnection.Close();
                dataSet = new DataSet();
                db.getDataAdapter.Fill(dataSet);
                Report.CrystalReport.AllOverdueLoanReport overdue = new Report.CrystalReport.AllOverdueLoanReport();
                overdue.Database.Tables["LoanPortfolio"].SetDataSource(dataSet);

                title = (TextObject)overdue.ReportDefinition.ReportObjects["lblTitle"];
                display = (TextObject)overdue.ReportDefinition.ReportObjects["display"];
                output = (TextObject)overdue.ReportDefinition.ReportObjects["lblDisplay"];
                title.Text = "Overdue Loan Report";
                display.Text = "BRANCH";
                output.Text = branchName.ToUpper();

                accountTypeViewer.Visible = true;
                accountTypeViewer.ReportSource = null;
                accountTypeViewer.ReportSource = overdue;
            }
            catch (SqlException sql)
            {
                MessageBox.Show(sql.Message);
            }
        }
        private void accountOfficerOverdueLoan()
        {
            try
            {
                accOfficer = tSComboAccOfficerOverdue.SelectedItem.ToString();
                db.connect();
                db.accountOfficerOverdueLoanReport(accOfficer);
                db.getConnection.Close();
                dataSet = new DataSet();
                db.getDataAdapter.Fill(dataSet);
                Report.CrystalReport.AllOverdueLoanReport overdue = new Report.CrystalReport.AllOverdueLoanReport();
                overdue.Database.Tables["LoanPortfolio"].SetDataSource(dataSet);

                title = (TextObject)overdue.ReportDefinition.ReportObjects["lblTitle"];
                display = (TextObject)overdue.ReportDefinition.ReportObjects["display"];
                output = (TextObject)overdue.ReportDefinition.ReportObjects["lblDisplay"];
                title.Text = "Overdue Loan Report";
                display.Text = "ACCOUNT OFFICER";
                output.Text = accOfficer.ToUpper();

                accountTypeViewer.Visible = true;
                accountTypeViewer.ReportSource = null;
                accountTypeViewer.ReportSource = overdue;
            }
            catch (IndexOutOfRangeException idx)
            {
                MessageBox.Show(idx.Message);
            }
            catch (SqlException sql)
            {
                MessageBox.Show(sql.Message);
            }
        }
        private void accountOfficerMonthlyPerformance()
        {
            try
            {
                accOfficer = tSComboAccOffMonthlyPerformance.SelectedItem.ToString();
                monthDate = DateTime.Parse(datePicker.Text);
                int convertDate = monthDate.Month;
                month = datePicker.Text;
                db.connect();
                db.accountOfficerMonthlyPerformance(accOfficer, month);
                db.getConnection.Close();
                dataSet = new DataSet();
                db.getDataAdapter.Fill(dataSet);
                Report.CrystalReport.PerformanceReport performance = new Report.CrystalReport.PerformanceReport();
                performance.Database.Tables["Performance"].SetDataSource(dataSet.Tables[0]);

                display = (TextObject)performance.ReportDefinition.ReportObjects["display"];
                output = (TextObject)performance.ReportDefinition.ReportObjects["lblDisplay"];
                display.Text = "MONTH";
                output.Text = month.ToUpper() + ", " + accOfficer.ToUpper();

                accountTypeViewer.Visible = true;
                accountTypeViewer.ReportSource = null;
                accountTypeViewer.ReportSource = performance;
            }
            catch (NullReferenceException nre)
            {
                MessageBox.Show("Please select the month and the account officer first", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (IndexOutOfRangeException idx)
            {
                MessageBox.Show(idx.Message);
            }
            catch (SqlException sql)
            {
                MessageBox.Show(sql.Message);
            }
        }
        private void accountOfficerYearlyPerformance()
        {
            try
            {
                accOfficer = tSComboAccOffMonthlyPerformance.SelectedItem.ToString();
                year = int.Parse(tSTxtAccOffYearPerformance.Text);
                db.connect();
                db.accountOfficerYearlyPerformance(accOfficer, year);
                db.getConnection.Close();
                dataSet = new DataSet();
                db.getDataAdapter.Fill(dataSet);
                Report.CrystalReport.PerformanceReport performance = new Report.CrystalReport.PerformanceReport();
                performance.Database.Tables["Performance"].SetDataSource(dataSet.Tables[0]);

                display = (TextObject)performance.ReportDefinition.ReportObjects["display"];
                output = (TextObject)performance.ReportDefinition.ReportObjects["lblDisplay"];
                display.Text = "YEAR";
                output.Text = year + ", " + accOfficer.ToUpper();

                accountTypeViewer.Visible = true;
                accountTypeViewer.ReportSource = null;
                accountTypeViewer.ReportSource = performance;
            }
            catch (NullReferenceException nre)
            {
                MessageBox.Show("Please enter the year and select the account officer first", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (IndexOutOfRangeException idx)
            {
                MessageBox.Show(idx.Message);
            }
            catch (SqlException sql)
            {
                MessageBox.Show(sql.Message);
            }
        }
        private void branchMonthlyPerformance()
        {
            //try
            //{
            branchName = tSComboBranchPerformance.SelectedItem.ToString();
            monthDate = DateTime.Parse(datePicker.Text);
            int convertDate = monthDate.Month;
            month = datePicker.Text;
            db.connect();
            db.branchMonthlyPerformance(branchName, month);
            db.getConnection.Close();
            dataSet = new DataSet();
            db.getDataAdapter.Fill(dataSet);
            Report.CrystalReport.PerformanceReport performance = new Report.CrystalReport.PerformanceReport();
            performance.Database.Tables["Performance"].SetDataSource(dataSet.Tables[0]);

            display = (TextObject)performance.ReportDefinition.ReportObjects["display"];
            output = (TextObject)performance.ReportDefinition.ReportObjects["lblDisplay"];
            display.Text = "MONTH";
            output.Text = month.ToUpper() + ", " + branchName.ToUpper() + " " + "BRANCH";

            accountTypeViewer.Visible = true;
            accountTypeViewer.ReportSource = null;
            accountTypeViewer.ReportSource = performance;
            //}
            //catch (NullReferenceException nre)
            //{
            //    MessageBox.Show("Please select the month and the branch first", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //catch (IndexOutOfRangeException idx)
            //{
            //    MessageBox.Show(idx.Message);
            //}
            //catch (SqlException sql)
            //{
            //    MessageBox.Show(sql.Message);
            //}
        }
        private void branchYearlyPerformance()
        {
            try
            {
                string branch = tSComboBranchPerformance.SelectedItem.ToString();
                int year = int.Parse(tSTxtBranchYearPerformance.Text);
                db.connect();
                db.branchYearlyPerformance(branch, year);
                db.getConnection.Close();
                dataSet = new DataSet();
                db.getDataAdapter.Fill(dataSet);
                Report.CrystalReport.PerformanceReport performance = new Report.CrystalReport.PerformanceReport();
                performance.Database.Tables["Performance"].SetDataSource(dataSet.Tables[0]);

                display = (TextObject)performance.ReportDefinition.ReportObjects["display"];
                output = (TextObject)performance.ReportDefinition.ReportObjects["lblDisplay"];
                display.Text = "YEAR";
                output.Text = year + ", " + branchName.ToUpper() + " " + "BRANCH";

                accountTypeViewer.Visible = true;
                accountTypeViewer.ReportSource = null;
                accountTypeViewer.ReportSource = performance;
            }
            catch (NullReferenceException nre)
            {
                MessageBox.Show("Please enter the year and select the branch first", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (IndexOutOfRangeException idx)
            {
                MessageBox.Show(idx.Message);
            }
            catch (SqlException sql)
            {
                MessageBox.Show(sql.Message);
            }
        }
        private void dayDisburse()
        {
            try
            {
                Report.CrystalReport.AllUnbalancedLoanReport disburse = new Report.CrystalReport.AllUnbalancedLoanReport();
                branchName = tSComboBranchDisburse.SelectedItem.ToString();
                day = datePicker.Text;

                db.connect();
                db.dayDisburseReport(branchName, day);
                db.getConnection.Close();
                DataTable dataSet = new DataTable();
                db.getDataAdapter.Fill(dataSet);
                disburse.Database.Tables["LoanPortfolio"].SetDataSource(dataSet);

                title = (TextObject)disburse.ReportDefinition.ReportObjects["lblTitle"];
                display = (TextObject)disburse.ReportDefinition.ReportObjects["display"];
                output = (TextObject)disburse.ReportDefinition.ReportObjects["lblDisplay"];
                title.Text = "Disbursed Loan Report";
                display.Text = "DAY";
                output.Text = day + ", " + branchName.ToUpper() + " " + " BRANCH";

                accountTypeViewer.Visible = true;
                accountTypeViewer.ReportSource = null;
                accountTypeViewer.ReportSource = disburse;
            }
            catch (NullReferenceException nre)
            {
                MessageBox.Show("Please select the branch name", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (IndexOutOfRangeException idx)
            {
                MessageBox.Show(idx.Message);
            }
            catch (SqlException sql)
            {
                MessageBox.Show(sql.Message);
            }
        }
        private void monthlyDisburse()
        {
            try
            {
                Report.CrystalReport.AllUnbalancedLoanReport disburse = new Report.CrystalReport.AllUnbalancedLoanReport();
                branchName = tSComboBranchDisburse.SelectedItem.ToString();
                monthDate = DateTime.Parse(datePicker.Text);
                int convertDate = monthDate.Month;
                month = datePicker.Text;

                db.connect();
                db.monthlyDisburseReport(branchName, month);
                db.getConnection.Close();
                DataTable dataSet = new DataTable();
                db.getDataAdapter.Fill(dataSet);
                disburse.Database.Tables["LoanPortfolio"].SetDataSource(dataSet);

                title = (TextObject)disburse.ReportDefinition.ReportObjects["lblTitle"];
                display = (TextObject)disburse.ReportDefinition.ReportObjects["display"];
                output = (TextObject)disburse.ReportDefinition.ReportObjects["lblDisplay"];
                title.Text = "Disbursed Loan Report";
                display.Text = "MONTH";
                output.Text = month.ToUpper() + ", " + branchName.ToUpper() + " " + " BRANCH";


                accountTypeViewer.Visible = true;
                accountTypeViewer.ReportSource = null;
                accountTypeViewer.ReportSource = disburse;
            }
            catch (NullReferenceException nre)
            {
                MessageBox.Show("Please select the branch name", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (IndexOutOfRangeException idx)
            {
                MessageBox.Show(idx.Message);
            }
            catch (SqlException sql)
            {
                MessageBox.Show(sql.Message);
            }
        }
        private void yearlyDisburse()
        {
            try
            {
                Report.CrystalReport.AllUnbalancedLoanReport disburse = new Report.CrystalReport.AllUnbalancedLoanReport();
                branchName = tSComboBranchDisburse.SelectedItem.ToString();
                year = int.Parse(tSTxtYearDisburse.Text);
                db.connect();
                db.yearlyDisburseReport(branchName, year);
                db.getConnection.Close();
                DataTable dataSet = new DataTable();
                db.getDataAdapter.Fill(dataSet);
                disburse.Database.Tables["LoanPortfolio"].SetDataSource(dataSet);

                title = (TextObject)disburse.ReportDefinition.ReportObjects["lblTitle"];
                display = (TextObject)disburse.ReportDefinition.ReportObjects["display"];
                output = (TextObject)disburse.ReportDefinition.ReportObjects["lblDisplay"];
                title.Text = "Disbursed Loan Report";
                display.Text = "YEAR";
                output.Text = year + ", " + branchName.ToUpper() + " " + " Branch";

                accountTypeViewer.Visible = true;
                accountTypeViewer.ReportSource = null;
                accountTypeViewer.ReportSource = disburse;
            }
            catch (NullReferenceException nre)
            {
                MessageBox.Show("Please select the branch name", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (IndexOutOfRangeException idx)
            {
                MessageBox.Show(idx.Message);
            }
            catch (SqlException sql)
            {
                MessageBox.Show(sql.Message);
            }
        }
        private void allDailyDisburse()
        {
            try
            {
                Report.CrystalReport.AllUnbalancedLoanReport disburse = new Report.CrystalReport.AllUnbalancedLoanReport();
                day = datePicker.Text;

                db.connect();
                db.allDailyDisburseReport(day);
                db.getConnection.Close();
                DataTable dataSet = new DataTable();
                db.getDataAdapter.Fill(dataSet);
                disburse.Database.Tables["LoanPortfolio"].SetDataSource(dataSet);

                title = (TextObject)disburse.ReportDefinition.ReportObjects["lblTitle"];
                display = (TextObject)disburse.ReportDefinition.ReportObjects["display"];
                output = (TextObject)disburse.ReportDefinition.ReportObjects["lblDisplay"];
                title.Text = "Disbursed Loan Report";
                display.Text = "DAY";
                output.Text = day + ", " + "ALL DISBURSEMENT";

                accountTypeViewer.Visible = true;
                accountTypeViewer.ReportSource = null;
                accountTypeViewer.ReportSource = disburse;
            }
            catch (IndexOutOfRangeException idx)
            {
                MessageBox.Show(idx.Message);
            }
            catch (SqlException sql)
            {
                MessageBox.Show(sql.Message);
            }
        }
        private void allMonthlyDisburse()
        {
            try
            {
                Report.CrystalReport.AllUnbalancedLoanReport disburse = new Report.CrystalReport.AllUnbalancedLoanReport();
                monthDate = DateTime.Parse(datePicker.Text);
                int convertDate = monthDate.Month;
                month = datePicker.Text;

                db.connect();
                db.allMonthlyDisburseReport(month);
                db.getConnection.Close();
                DataTable dataSet = new DataTable();
                db.getDataAdapter.Fill(dataSet);
                disburse.Database.Tables["LoanPortfolio"].SetDataSource(dataSet);

                title = (TextObject)disburse.ReportDefinition.ReportObjects["lblTitle"];
                display = (TextObject)disburse.ReportDefinition.ReportObjects["display"];
                output = (TextObject)disburse.ReportDefinition.ReportObjects["lblDisplay"];
                title.Text = "Disbursed Loan Report";
                display.Text = "MONTH";
                output.Text = month.ToUpper() + ", " + "ALL DISBURSEMENT";

                accountTypeViewer.Visible = true;
                accountTypeViewer.ReportSource = null;
                accountTypeViewer.ReportSource = disburse;
            }
            catch (IndexOutOfRangeException idx)
            {
                MessageBox.Show(idx.Message);
            }
            catch (SqlException sql)
            {
                MessageBox.Show(sql.Message);
            }
        }
        private void allYearlyDisburse()
        {
            try
            {
                Report.CrystalReport.AllUnbalancedLoanReport disburse = new Report.CrystalReport.AllUnbalancedLoanReport();
                year = int.Parse(tSTxtAllYearDisburse.Text);
                db.connect();
                db.allYearlyDisburseReport(year);
                db.getConnection.Close();
                DataTable dataSet = new DataTable();
                db.getDataAdapter.Fill(dataSet);
                disburse.Database.Tables["LoanPortfolio"].SetDataSource(dataSet);

                title = (TextObject)disburse.ReportDefinition.ReportObjects["lblTitle"];
                display = (TextObject)disburse.ReportDefinition.ReportObjects["display"];
                output = (TextObject)disburse.ReportDefinition.ReportObjects["lblDisplay"];
                title.Text = "Disbursed Loan Report";
                display.Text = "YEAR";
                output.Text = year + ", " + "ALL DISBURSEMENT";

                accountTypeViewer.Visible = true;
                accountTypeViewer.ReportSource = null;
                accountTypeViewer.ReportSource = disburse;
            }
            catch (IndexOutOfRangeException idx)
            {
                MessageBox.Show(idx.Message);
            }
            catch (SqlException sql)
            {
                MessageBox.Show(sql.Message);
            }
        }
        private void monthlyClosedAccount()
        {
            try
            {
                monthDate = DateTime.Parse(datePicker.Text);
                int convertDate = monthDate.Month;
                month = datePicker.Text;
                db.connect();
                db.monthlyClosedAccount(month);
                db.getConnection.Close();
                dataSet = new DataSet();
                db.getDataAdapter.Fill(dataSet);
                Report.CrystalReport.ClosedAccountReport closedAccount = new Report.CrystalReport.ClosedAccountReport();
                closedAccount.Database.Tables["ClosedAccount"].SetDataSource(dataSet.Tables[0]);

                display = (TextObject)closedAccount.ReportDefinition.ReportObjects["display"];
                output = (TextObject)closedAccount.ReportDefinition.ReportObjects["lblDisplay"];
                display.Text = "MONTH";
                output.Text = month.ToUpper();

                accountTypeViewer.Visible = true;
                accountTypeViewer.ReportSource = null;
                accountTypeViewer.ReportSource = closedAccount;
            }
            catch (SqlException sql)
            {
                MessageBox.Show(sql.Message);
            }
            catch (NullReferenceException nre)
            {

            }
        }
        private void yearlyClosedAccount()
        {
            try
            {
                year = int.Parse(tSTxtClosedAccount.Text);
                db.connect();
                db.yearlyClosedAccount(year);
                db.getConnection.Close();
                dataSet = new DataSet();
                db.getDataAdapter.Fill(dataSet);

                Report.CrystalReport.ClosedAccountReport closedAccount = new Report.CrystalReport.ClosedAccountReport();
                closedAccount.Database.Tables["CLosedAccount"].SetDataSource(dataSet.Tables[0]);

                display = (TextObject)closedAccount.ReportDefinition.ReportObjects["display"];
                output = (TextObject)closedAccount.ReportDefinition.ReportObjects["lblDisplay"];
                display.Text = "YEAR";
                output.Text = year.ToString();

                accountTypeViewer.Visible = true;
                accountTypeViewer.ReportSource = null;
                accountTypeViewer.ReportSource = closedAccount;
            }
            catch (NullReferenceException nre)
            {
                tSComboAccountType.Text = null;
            }
        }
        private void dayDeposit()
        {
            Report.CrystalReport.DepositTransactionReport deposit = new Report.CrystalReport.DepositTransactionReport();

            branchName = tSComboBranchDeposit.SelectedItem.ToString();
            day = datePicker.Text;

            db.connect();
            db.transactBranchDepositReport(branchName, day);
            db.getConnection.Close();
            DataTable dataSet = new DataTable();
            db.getDataAdapter.Fill(dataSet);
            deposit.Database.Tables["Transaction"].SetDataSource(dataSet);

            title = (TextObject)deposit.ReportDefinition.ReportObjects["lblTitle"];
            display = (TextObject)deposit.ReportDefinition.ReportObjects["display"];
            output = (TextObject)deposit.ReportDefinition.ReportObjects["lblDisplay"];
            title.Text = "Deposit Transanction Report";
            display.Text = "DAY";
            output.Text = day + ", " + branchName.ToUpper() + " " + "BRANCH";

            accountTypeViewer.Visible = true;
            accountTypeViewer.ReportSource = null;
            accountTypeViewer.ReportSource = deposit;
        }
        private void monthDeposit()
        {
            Report.CrystalReport.DepositTransactionReport deposit = new Report.CrystalReport.DepositTransactionReport();
            branchName = tSComboBranchDeposit.SelectedItem.ToString();
            monthDate = DateTime.Parse(datePicker.Text);
            int convertDate = monthDate.Month;
            month = datePicker.Text;

            db.connect();
            db.transactBranchMonthlyDepositReport(branchName, month);
            db.getConnection.Close();
            DataTable dataSet = new DataTable();
            db.getDataAdapter.Fill(dataSet);
            deposit.Database.Tables["Transaction"].SetDataSource(dataSet);

            title = (TextObject)deposit.ReportDefinition.ReportObjects["lblTitle"];
            display = (TextObject)deposit.ReportDefinition.ReportObjects["display"];
            output = (TextObject)deposit.ReportDefinition.ReportObjects["lblDisplay"];
            title.Text = "Deposit Transanction Report";
            display.Text = "MONTH";
            output.Text = month.ToUpper() + ", " + branchName.ToUpper() + " " + "BRANCH";

            accountTypeViewer.Visible = true;
            accountTypeViewer.ReportSource = null;
            accountTypeViewer.ReportSource = deposit;
        }
        private void yearDeposit()
        {
            Report.CrystalReport.DepositTransactionReport deposit = new Report.CrystalReport.DepositTransactionReport();
            branchName = tSComboBranchDeposit.SelectedItem.ToString();
            year = int.Parse(tSTxtYearDeposit.Text);

            db.connect();
            db.transactBranchYearlyDepositReport(branchName, year);
            db.getConnection.Close();
            DataTable dataSet = new DataTable();
            db.getDataAdapter.Fill(dataSet);
            deposit.Database.Tables["Transaction"].SetDataSource(dataSet);

            title = (TextObject)deposit.ReportDefinition.ReportObjects["lblTitle"];
            display = (TextObject)deposit.ReportDefinition.ReportObjects["display"];
            output = (TextObject)deposit.ReportDefinition.ReportObjects["lblDisplay"];
            title.Text = "Deposit Transanction Report";
            display.Text = "YEAR";
            output.Text = year + ", " + branchName.ToUpper() + " " + "BRANCH";

            accountTypeViewer.Visible = true;
            accountTypeViewer.ReportSource = null;
            accountTypeViewer.ReportSource = deposit;
        }
        private void dayWithdrawal()
        {
            Report.CrystalReport.WithdrawalTransactionReport withdrawal = new Report.CrystalReport.WithdrawalTransactionReport();
            branchName = tSComboBranchWithdrawal.SelectedItem.ToString();
            day = datePicker.Text;

            db.connect();
            db.transactBranchWithdrawalReport(branchName, day);
            db.getConnection.Close();
            DataTable dataSet = new DataTable();
            db.getDataAdapter.Fill(dataSet);
            withdrawal.Database.Tables["Transaction"].SetDataSource(dataSet);

            display = (TextObject)withdrawal.ReportDefinition.ReportObjects["display"];
            output = (TextObject)withdrawal.ReportDefinition.ReportObjects["lblDisplay"];
            display.Text = "DAY";
            output.Text = day + ", " + branchName.ToUpper() + " " + "BRANCH";

            accountTypeViewer.Visible = true;
            accountTypeViewer.ReportSource = null;
            accountTypeViewer.ReportSource = withdrawal;
        }
        private void monthWithdrawal()
        {
            Report.CrystalReport.WithdrawalTransactionReport withdrawal = new Report.CrystalReport.WithdrawalTransactionReport();
            branchName = tSComboBranchWithdrawal.SelectedItem.ToString();
            monthDate = DateTime.Parse(datePicker.Text);
            int convertDate = monthDate.Month;
            month = datePicker.Text;

            db.connect();
            db.transactBranchMonthlyWithdrawalReport(branchName, month);
            db.getConnection.Close();
            DataTable dataSet = new DataTable();
            db.getDataAdapter.Fill(dataSet);
            withdrawal.Database.Tables["Transaction"].SetDataSource(dataSet);

            display = (TextObject)withdrawal.ReportDefinition.ReportObjects["display"];
            output = (TextObject)withdrawal.ReportDefinition.ReportObjects["lblDisplay"];
            display.Text = "MONTH";
            output.Text = month.ToUpper() + ", " + branchName.ToUpper() + " " + "BRANCH";

            accountTypeViewer.Visible = true;
            accountTypeViewer.ReportSource = null;
            accountTypeViewer.ReportSource = withdrawal;
        }
        private void yearWithdrawal()
        {
            Report.CrystalReport.WithdrawalTransactionReport withdrawal = new Report.CrystalReport.WithdrawalTransactionReport();
            branchName = tSComboBranchWithdrawal.SelectedItem.ToString();
            year = int.Parse(tSTxtYearWithdrawal.Text);

            db.connect();
            db.transactBranchYearlyWithdrawalReport(branchName, year);
            db.getConnection.Close();
            DataTable dataSet = new DataTable();
            db.getDataAdapter.Fill(dataSet);
            withdrawal.Database.Tables["Transaction"].SetDataSource(dataSet);

            display = (TextObject)withdrawal.ReportDefinition.ReportObjects["display"];
            output = (TextObject)withdrawal.ReportDefinition.ReportObjects["lblDisplay"];
            display.Text = "YEAR";
            output.Text = year + ", " + branchName.ToUpper() + " " + "BRANCH";

            accountTypeViewer.Visible = true;
            accountTypeViewer.ReportSource = null;
            accountTypeViewer.ReportSource = withdrawal;
        }
        private void dayPf()
        {
            Report.CrystalReport.DepositTransactionReport pf = new Report.CrystalReport.DepositTransactionReport();
            branchName = tSComboBranchPf.SelectedItem.ToString();
            day = datePicker.Text;

            db.connect();
            db.transactBranchPfReport(branchName, day);
            db.getConnection.Close();
            DataTable dataSet = new DataTable();
            db.getDataAdapter.Fill(dataSet);
            pf.Database.Tables["Transaction"].SetDataSource(dataSet);

            title = (TextObject)pf.ReportDefinition.ReportObjects["lblTitle"];
            display = (TextObject)pf.ReportDefinition.ReportObjects["display"];
            output = (TextObject)pf.ReportDefinition.ReportObjects["lblDisplay"];
            title.Text = "PF Transanction Report";
            display.Text = "DAY";
            output.Text = day + ", " + branchName.ToUpper() + " " + "BRANCH";

            accountTypeViewer.Visible = true;
            accountTypeViewer.ReportSource = null;
            accountTypeViewer.ReportSource = pf;
        }
        private void monthPf()
        {
            Report.CrystalReport.DepositTransactionReport pf = new Report.CrystalReport.DepositTransactionReport();
            branchName = tSComboBranchPf.SelectedItem.ToString();
            monthDate = DateTime.Parse(datePicker.Text);
            int convertDate = monthDate.Month;
            month = datePicker.Text;

            db.connect();
            db.transactBranchMonthlyPfReport(branchName, month);
            db.getConnection.Close();
            DataTable dataSet = new DataTable();
            db.getDataAdapter.Fill(dataSet);
            pf.Database.Tables["Transaction"].SetDataSource(dataSet);

            title = (TextObject)pf.ReportDefinition.ReportObjects["lblTitle"];
            display = (TextObject)pf.ReportDefinition.ReportObjects["display"];
            output = (TextObject)pf.ReportDefinition.ReportObjects["lblDisplay"];
            title.Text = "PF Transanction Report";
            display.Text = "MONTH";
            output.Text = month.ToUpper() + ", " + branchName.ToUpper() + " " + "BRANCH";

            accountTypeViewer.Visible = true;
            accountTypeViewer.ReportSource = null;
            accountTypeViewer.ReportSource = pf;
        }
        private void yearPf()
        {
            Report.CrystalReport.DepositTransactionReport pf = new Report.CrystalReport.DepositTransactionReport();
            branchName = tSComboBranchPf.SelectedItem.ToString();
            year = int.Parse(tSTxtYearPf.Text);

            db.connect();
            db.transactBranchYearlyPfReport(branchName, year);
            db.getConnection.Close();
            DataTable dataSet = new DataTable();
            db.getDataAdapter.Fill(dataSet);
            pf.Database.Tables["Transaction"].SetDataSource(dataSet);

            title = (TextObject)pf.ReportDefinition.ReportObjects["lblTitle"];
            display = (TextObject)pf.ReportDefinition.ReportObjects["display"];
            output = (TextObject)pf.ReportDefinition.ReportObjects["lblDisplay"];
            title.Text = "PF Transanction Report";
            display.Text = "YEAR";
            output.Text = year + ", " + branchName.ToUpper() + " " + "BRANCH";

            accountTypeViewer.Visible = true;
            accountTypeViewer.ReportSource = null;
            accountTypeViewer.ReportSource = pf;
        }
        private void dayTransfer()
        {
            Report.CrystalReport.TransferTransactionReport transfer = new Report.CrystalReport.TransferTransactionReport();
            branchName = tSComboBranchTransfer.SelectedItem.ToString();
            day = datePicker.Text;

            db.connect();
            db.transactBranchTransferReport(branchName, day);
            db.getConnection.Close();
            DataTable dataSet = new DataTable();
            db.getDataAdapter.Fill(dataSet);
            transfer.Database.Tables["Transaction"].SetDataSource(dataSet);

            display = (TextObject)transfer.ReportDefinition.ReportObjects["display"];
            output = (TextObject)transfer.ReportDefinition.ReportObjects["lblDisplay"];
            display.Text = "DAY";
            output.Text = day + ", " + branchName.ToUpper() + " " + "BRANCH";

            accountTypeViewer.Visible = true;
            accountTypeViewer.ReportSource = null;
            accountTypeViewer.ReportSource = transfer;
        }
        private void monthTransfer()
        {
            Report.CrystalReport.TransferTransactionReport transfer = new Report.CrystalReport.TransferTransactionReport();
            branchName = tSComboBranchTransfer.SelectedItem.ToString();
            monthDate = DateTime.Parse(datePicker.Text);
            int convertDate = monthDate.Month;
            month = datePicker.Text;

            db.connect();
            db.transactBranchMonthlyTransferReport(branchName, month);
            db.getConnection.Close();
            DataTable dataSet = new DataTable();
            db.getDataAdapter.Fill(dataSet);
            transfer.Database.Tables["Transaction"].SetDataSource(dataSet);

            display = (TextObject)transfer.ReportDefinition.ReportObjects["display"];
            output = (TextObject)transfer.ReportDefinition.ReportObjects["lblDisplay"];
            display.Text = "MONTH";
            output.Text = month.ToUpper() + ", " + branchName.ToUpper() + " " + "BRANCH";

            accountTypeViewer.Visible = true;
            accountTypeViewer.ReportSource = null;
            accountTypeViewer.ReportSource = transfer;
        }
        private void yearTransfer()
        {
            Report.CrystalReport.TransferTransactionReport transfer = new Report.CrystalReport.TransferTransactionReport();
            branchName = tSComboBranchTransfer.SelectedItem.ToString();
            year = int.Parse(tSTxtYearTransfer.Text);

            db.connect();
            db.transactBranchYearlyTransferReport(branchName, year);
            db.getConnection.Close();
            DataTable dataSet = new DataTable();
            db.getDataAdapter.Fill(dataSet);
            transfer.Database.Tables["Transaction"].SetDataSource(dataSet);

            display = (TextObject)transfer.ReportDefinition.ReportObjects["display"];
            output = (TextObject)transfer.ReportDefinition.ReportObjects["lblDisplay"];
            display.Text = "YEAR";
            output.Text = year + ", " + branchName.ToUpper() + "BRANCH";

            accountTypeViewer.Visible = true;
            accountTypeViewer.ReportSource = null;
            accountTypeViewer.ReportSource = transfer;
        }
        private void monthlyIncome()
        {
            Report.CrystalReport.IncomeOverviewReport income = new Report.CrystalReport.IncomeOverviewReport();
            monthDate = DateTime.Parse(datePicker.Text);
            int convertDate = monthDate.Month;
            month = datePicker.Text;

            db.connect();
            db.monthlyIncomeOverview(month);
            dataSet = new DataSet();
            db.getDataAdapter.Fill(dataSet);
            income.Database.Tables["Income"].SetDataSource(dataSet.Tables[0]);

            display = (TextObject)income.ReportDefinition.ReportObjects["display"];
            output = (TextObject)income.ReportDefinition.ReportObjects["lblDisplay"];
            display.Text = "MONTH";
            output.Text = month.ToUpper();

            accountTypeViewer.Visible = true;
            accountTypeViewer.ReportSource = null;
            accountTypeViewer.ReportSource = income;
        }
        private void yearlyIncome()
        {
            Report.CrystalReport.IncomeOverviewReport income = new Report.CrystalReport.IncomeOverviewReport();
            year = int.Parse(tSTxtYearIncome.Text);

            db.connect();
            db.yearlyIncomeOverview(year);
            dataSet = new DataSet();
            db.getDataAdapter.Fill(dataSet);
            income.Database.Tables["Income"].SetDataSource(dataSet.Tables[0]);

            display = (TextObject)income.ReportDefinition.ReportObjects["display"];
            output = (TextObject)income.ReportDefinition.ReportObjects["lblDisplay"];
            display.Text = "YEAR";
            output.Text = year.ToString();

            accountTypeViewer.Visible = true;
            accountTypeViewer.ReportSource = null;
            accountTypeViewer.ReportSource = income;
        }
        private void branchMonthlyIncome()
        {
            Report.CrystalReport.IncomeOverviewReport income = new Report.CrystalReport.IncomeOverviewReport();
            branchName = tSComboBranchIncome.SelectedItem.ToString();
            monthDate = DateTime.Parse(datePicker.Text);
            int convertDate = monthDate.Month;
            month = datePicker.Text;

            db.connect();
            db.branchMonthlyIncomeOverview(branchName, month);
            dataSet = new DataSet();
            db.getDataAdapter.Fill(dataSet);
            income.Database.Tables["Income"].SetDataSource(dataSet.Tables[0]);

            display = (TextObject)income.ReportDefinition.ReportObjects["display"];
            output = (TextObject)income.ReportDefinition.ReportObjects["lblDisplay"];
            display.Text = "MONTH";
            output.Text = month.ToUpper() + ", " + branchName.ToUpper() + " " + "BRANCH";

            accountTypeViewer.Visible = true;
            accountTypeViewer.ReportSource = null;
            accountTypeViewer.ReportSource = income;
        }
        private void branchYearlyIncome()
        {
            Report.CrystalReport.IncomeOverviewReport income = new Report.CrystalReport.IncomeOverviewReport();
            branchName = tSComboBranchIncome.SelectedItem.ToString();
            year = int.Parse(tSTxtBranchYearIncome.Text);

            db.connect();
            db.branchYearlyIncomeOverview(branchName, year);
            dataSet = new DataSet();
            db.getDataAdapter.Fill(dataSet);
            income.Database.Tables["Income"].SetDataSource(dataSet.Tables[0]);

            display = (TextObject)income.ReportDefinition.ReportObjects["display"];
            output = (TextObject)income.ReportDefinition.ReportObjects["lblDisplay"];
            display.Text = "YEAR";
            output.Text = year + ", " + branchName.ToUpper() + " " + "BRANCH";

            accountTypeViewer.Visible = true;
            accountTypeViewer.ReportSource = null;
            accountTypeViewer.ReportSource = income;
        }
        private void accountOfficerDayDefault()
        {
            Report.CrystalReport.DefaultReport defaultReport = new Report.CrystalReport.DefaultReport();
            accOfficer = tSComboAccOfficerDefault.SelectedItem.ToString();
            day = tSComboAccountOfficerPaymentTerms.SelectedItem.ToString();

            db.connect();
            db.accountOfficerDayDefault(accOfficer, day);
            db.getConnection.Close();
            DataTable dataSet = new DataTable();
            db.getDataAdapter.Fill(dataSet);
            defaultReport.Database.Tables["Default"].SetDataSource(dataSet);

            display = (TextObject)defaultReport.ReportDefinition.ReportObjects["display"];
            output = (TextObject)defaultReport.ReportDefinition.ReportObjects["lblDisplay"];
            display.Text = "DAY";
            output.Text = day + ", " + accOfficer.ToUpper();

            accountTypeViewer.Visible = true;
            accountTypeViewer.ReportSource = null;
            accountTypeViewer.ReportSource = defaultReport;
        }
        private void accountOfficerWeekDefault()
        {
            Report.CrystalReport.DefaultReport defaultReport = new Report.CrystalReport.DefaultReport();
            accOfficer = tSComboAccOfficerDefault.SelectedItem.ToString();
            string week = tSComboAccountOfficerPaymentTerms.SelectedItem.ToString();

            db.connect();
            db.accountOfficerWeekDefault(accOfficer, week);
            dataSet = new DataSet();
            db.getDataAdapter.Fill(dataSet);
            defaultReport.Database.Tables["Default"].SetDataSource(dataSet.Tables[0]);

            display = (TextObject)defaultReport.ReportDefinition.ReportObjects["display"];
            output = (TextObject)defaultReport.ReportDefinition.ReportObjects["lblDisplay"];
            display.Text = "WEEK";
            output.Text = week + ", " + accOfficer.ToUpper();

            accountTypeViewer.Visible = true;
            accountTypeViewer.ReportSource = null;
            accountTypeViewer.ReportSource = defaultReport;
        }
        private void accountOfficerMonthDefault()
        {
            Report.CrystalReport.DefaultReport defaultReport = new Report.CrystalReport.DefaultReport();
            accOfficer = tSComboAccOfficerDefault.SelectedItem.ToString();
            monthDate = DateTime.Parse(datePicker.Text);
            int convertDate = monthDate.Month;
            month = datePicker.Text;

            db.connect();
            db.accountOfficerMonthDefault(accOfficer, month);
            db.getConnection.Close();
            DataTable dataSet = new DataTable();
            db.getDataAdapter.Fill(dataSet);
            defaultReport.Database.Tables["Default"].SetDataSource(dataSet);

            display = (TextObject)defaultReport.ReportDefinition.ReportObjects["display"];
            output = (TextObject)defaultReport.ReportDefinition.ReportObjects["lblDisplay"];
            display.Text = "MONTH";
            output.Text = month.ToUpper() + ", " + accOfficer.ToUpper();

            accountTypeViewer.Visible = true;
            accountTypeViewer.ReportSource = null;
            accountTypeViewer.ReportSource = defaultReport;
        }
        private void accountOfficerPaymentTerms()
        {
            if (tSComboAccountOfficerPaymentTerms.SelectedItem.ToString().Equals("Daily"))
            {
                accountOfficerDayDefault();
            }
            else if (tSComboAccountOfficerPaymentTerms.SelectedItem.ToString().Equals("Weekly"))
            {
                accountOfficerWeekDefault();
            }
            else
            {
                accountOfficerMonthDefault();
            }
        }
        private void branchDayDefault()
        {
            Report.CrystalReport.DefaultReport defaultReport = new Report.CrystalReport.DefaultReport();
            branchName = tSComboBranchDefault.SelectedItem.ToString();
            day = tSComboBranchPaymentTerms.SelectedItem.ToString();

            db.connect();
            db.branchDayDefault(branchName, day);
            db.getConnection.Close();
            DataTable dataSet = new DataTable();
            db.getDataAdapter.Fill(dataSet);
            defaultReport.Database.Tables["Default"].SetDataSource(dataSet);

            display = (TextObject)defaultReport.ReportDefinition.ReportObjects["display"];
            output = (TextObject)defaultReport.ReportDefinition.ReportObjects["lblDisplay"];
            display.Text = "DAY";
            output.Text = day + ", " + branchName.ToUpper() + " " + "BRANCH";

            accountTypeViewer.Visible = true;
            accountTypeViewer.ReportSource = null;
            accountTypeViewer.ReportSource = defaultReport;
        }
        private void branchWeekDefault()
        {
            Report.CrystalReport.DefaultReport defaultReport = new Report.CrystalReport.DefaultReport();
            branchName = tSComboBranchDefault.SelectedItem.ToString();
            string week = tSComboBranchPaymentTerms.SelectedItem.ToString();

            db.connect();
            db.branchWeekDefault(branchName, week);
            dataSet = new DataSet();
            db.getDataAdapter.Fill(dataSet);
            defaultReport.Database.Tables["Default"].SetDataSource(dataSet.Tables[0]);

            display = (TextObject)defaultReport.ReportDefinition.ReportObjects["display"];
            output = (TextObject)defaultReport.ReportDefinition.ReportObjects["lblDisplay"];
            display.Text = "WEEK";
            output.Text = week + ", " + branchName.ToUpper() + " " + "BRANCH";

            accountTypeViewer.Visible = true;
            accountTypeViewer.ReportSource = null;
            accountTypeViewer.ReportSource = defaultReport;
        }
        private void branchMonthDefault()
        {
            Report.CrystalReport.DefaultReport defaultReport = new Report.CrystalReport.DefaultReport();
            branchName = tSComboBranchDefault.SelectedItem.ToString();
            monthDate = DateTime.Parse(datePicker.Text);
            int convertDate = monthDate.Month;
            month = datePicker.Text;

            db.connect();
            db.branchMonthDefault(branchName, month);
            db.getConnection.Close();
            DataTable dataSet = new DataTable();
            db.getDataAdapter.Fill(dataSet);
            defaultReport.Database.Tables["Default"].SetDataSource(dataSet);

            display = (TextObject)defaultReport.ReportDefinition.ReportObjects["display"];
            output = (TextObject)defaultReport.ReportDefinition.ReportObjects["lblDisplay"];
            display.Text = "MONTH";
            output.Text = month.ToUpper() + ", " + branchName.ToUpper() + " " + "BRANCH";

            accountTypeViewer.Visible = true;
            accountTypeViewer.ReportSource = null;
            accountTypeViewer.ReportSource = defaultReport;
        }
        private void branchPaymentTerms()
        {
            if (tSComboBranchPaymentTerms.SelectedItem.ToString().Equals("Daily"))
            {
                branchDayDefault();
            }
            else if (tSComboBranchPaymentTerms.SelectedItem.ToString().Equals("Weekly"))
            {
                branchWeekDefault();
            }
            else
            {
                branchMonthDefault();
            }
        }
        private void groupLoan()
        {
            try
            {
                string groupName = tSComboLoanGroupName.SelectedItem.ToString();
                db.connect();
                db.groupLoanCustomerReport(groupName);
                db.getConnection.Close();
                dataSet = new DataSet();
                db.getDataAdapter.Fill(dataSet);

                Report.CrystalReport.GroupLoanReport groupLoanReport = new Report.CrystalReport.GroupLoanReport();
                groupLoanReport.Database.Tables["GroupLoan"].SetDataSource(dataSet.Tables[0]);

                display = (TextObject)groupLoanReport.ReportDefinition.ReportObjects["display"];
                output = (TextObject)groupLoanReport.ReportDefinition.ReportObjects["lblDisplay"];
                display.Text = "GROUP NAME";
                output.Text = groupName.ToUpper();

                accountTypeViewer.Visible = true;
                accountTypeViewer.ReportSource = null;
                accountTypeViewer.ReportSource = groupLoanReport;
            }
            catch (NullReferenceException nre)
            {
                tSComboLoanGroupName.Text = null;
            }
        }
        private void dayCallOver()
        {
            Report.CrystalReport.CallOverReport callOver = new Report.CrystalReport.CallOverReport();
            username = tSComboUserCallOver.SelectedItem.ToString();
            day = datePicker.Text;

            db.connect();
            db.dayCallOver(username, day);
            db.getConnection.Close();
            DataTable dataSet = new DataTable();
            db.getDataAdapter.Fill(dataSet);
            callOver.Database.Tables["CallOver"].SetDataSource(dataSet);

            display = (TextObject)callOver.ReportDefinition.ReportObjects["display"];
            output = (TextObject)callOver.ReportDefinition.ReportObjects["lblDisplay"];
            display.Text = "DAY";
            output.Text = username.ToUpper() + ", " + day;

            accountTypeViewer.Visible = true;
            accountTypeViewer.ReportSource = null;
            accountTypeViewer.ReportSource = callOver;
        }
        private void monthCallOver()
        {
            Report.CrystalReport.CallOverReport callOver = new Report.CrystalReport.CallOverReport();
            username = tSComboUserCallOver.SelectedItem.ToString();
            monthDate = DateTime.Parse(datePicker.Text);
            int convertDate = monthDate.Month;
            month = datePicker.Text;

            db.connect();
            db.monthCallOver(username, month);
            db.getConnection.Close();
            DataTable dataSet = new DataTable();
            db.getDataAdapter.Fill(dataSet);
            callOver.Database.Tables["CallOver"].SetDataSource(dataSet);

            display = (TextObject)callOver.ReportDefinition.ReportObjects["display"];
            output = (TextObject)callOver.ReportDefinition.ReportObjects["lblDisplay"];
            display.Text = "MONTH";
            output.Text = username.ToUpper() + ", " + month;

            accountTypeViewer.Visible = true;
            accountTypeViewer.ReportSource = null;
            accountTypeViewer.ReportSource = callOver;
        }
        private void yearCallOver()
        {
            Report.CrystalReport.CallOverReport callOver = new Report.CrystalReport.CallOverReport();
            username = tSComboUserCallOver.SelectedItem.ToString();
            year = int.Parse(tSTxtYearCallOver.Text);

            db.connect();
            db.yearCallOver(username, year);
            db.getConnection.Close();
            DataTable dataSet = new DataTable();
            db.getDataAdapter.Fill(dataSet);
            callOver.Database.Tables["CallOver"].SetDataSource(dataSet);

            display = (TextObject)callOver.ReportDefinition.ReportObjects["display"];
            output = (TextObject)callOver.ReportDefinition.ReportObjects["lblDisplay"];
            display.Text = "YEAR";
            output.Text = username.ToUpper() + ", " + year;

            accountTypeViewer.Visible = true;
            accountTypeViewer.ReportSource = null;
            accountTypeViewer.ReportSource = callOver;
        }
        private void accountOfficerCallOver()
        {
            Report.CrystalReport.AccountOfficerCallOverReport accOfficerCallOver = new Report.CrystalReport.AccountOfficerCallOverReport();
            username = tSComboUserCallOver.SelectedItem.ToString();
            accOfficer = tSComboAccOfficerCallOver.SelectedItem.ToString();
            day = datePicker.Text;

            db.connect();
            db.accountOfficerCallOver(username, accOfficer, day);
            db.getConnection.Close();
            DataTable dataSet = new DataTable();
            db.getDataAdapter.Fill(dataSet);
            accOfficerCallOver.Database.Tables["AccountOfficerCallOver"].SetDataSource(dataSet);

            display = (TextObject)accOfficerCallOver.ReportDefinition.ReportObjects["display"];
            output = (TextObject)accOfficerCallOver.ReportDefinition.ReportObjects["lblDisplay"];
            display.Text = "ACCOUNT OFFICER";
            output.Text = accOfficer.ToUpper() + ", " + day;

            accountTypeViewer.Visible = true;
            accountTypeViewer.ReportSource = null;
            accountTypeViewer.ReportSource = accOfficerCallOver;
        }
        private void dayDashboard()
        {
            Report.CrystalReport.DashboardReport dashboard = new Report.CrystalReport.DashboardReport();
            branchName = tSComboBranchDashboard.SelectedItem.ToString();
            day = datePicker.Text;

            db.connect();
            db.dayDashboard(branchName, day);
            db.getConnection.Close();
            DataTable dataSet = new DataTable();
            db.getDataAdapter.Fill(dataSet);
            dashboard.Database.Tables["Dashboard"].SetDataSource(dataSet);

            display = (TextObject)dashboard.ReportDefinition.ReportObjects["display"];
            output = (TextObject)dashboard.ReportDefinition.ReportObjects["lblDisplay"];
            display.Text = "DAY";
            output.Text = branchName.ToUpper() + ", " + day;

            accountTypeViewer.Visible = true;
            accountTypeViewer.ReportSource = null;
            accountTypeViewer.ReportSource = dashboard;
        }
        private void monthDashboard()
        {
            Report.CrystalReport.DashboardReport dashboard = new Report.CrystalReport.DashboardReport();
            branchName = tSComboBranchDashboard.SelectedItem.ToString();
            monthDate = DateTime.Parse(datePicker.Text);
            int convertDate = monthDate.Month;
            month = datePicker.Text;

            db.connect();
            db.monthDashboard(branchName, month);
            db.getConnection.Close();
            DataTable dataSet = new DataTable();
            db.getDataAdapter.Fill(dataSet);
            dashboard.Database.Tables["Dashboard"].SetDataSource(dataSet);

            display = (TextObject)dashboard.ReportDefinition.ReportObjects["display"];
            output = (TextObject)dashboard.ReportDefinition.ReportObjects["lblDisplay"];
            display.Text = "MONTH";
            output.Text = branchName.ToUpper() + ", " + month;

            accountTypeViewer.Visible = true;
            accountTypeViewer.ReportSource = null;
            accountTypeViewer.ReportSource = dashboard;
        }
        private void yearDashboard()
        {
            Report.CrystalReport.DashboardReport dashboard = new Report.CrystalReport.DashboardReport();
            branchName = tSComboBranchDashboard.SelectedItem.ToString();
            year = int.Parse(tSTxtYearDashboard.Text);

            db.connect();
            db.yearDashboard(branchName, year);
            db.getConnection.Close();
            DataTable dataSet = new DataTable();
            db.getDataAdapter.Fill(dataSet);
            dashboard.Database.Tables["Dashboard"].SetDataSource(dataSet);

            display = (TextObject)dashboard.ReportDefinition.ReportObjects["display"];
            output = (TextObject)dashboard.ReportDefinition.ReportObjects["lblDisplay"];
            display.Text = "YEAR";
            output.Text = branchName.ToUpper() + ", " + year;

            accountTypeViewer.Visible = true;
            accountTypeViewer.ReportSource = null;
            accountTypeViewer.ReportSource = dashboard;
        }
        private void allDayDashboard()
        {
            Report.CrystalReport.DashboardReport allDashboard = new Report.CrystalReport.DashboardReport();
            day = datePicker.Text;

            db.connect();
            db.allDayDashboard(day);
            db.getConnection.Close();
            DataTable dataSet = new DataTable();
            db.getDataAdapter.Fill(dataSet);
            allDashboard.Database.Tables["Dashboard"].SetDataSource(dataSet);

            display = (TextObject)allDashboard.ReportDefinition.ReportObjects["display"];
            output = (TextObject)allDashboard.ReportDefinition.ReportObjects["lblDisplay"];
            display.Text = "DAY";
            output.Text = "All " + day;

            accountTypeViewer.Visible = true;
            accountTypeViewer.ReportSource = null;
            accountTypeViewer.ReportSource = allDashboard;
        }
        private void allMonthDashboard()
        {
            Report.CrystalReport.DashboardReport dashboard = new Report.CrystalReport.DashboardReport();
            monthDate = DateTime.Parse(datePicker.Text);
            int convertDate = monthDate.Month;
            month = datePicker.Text;

            db.connect();
            db.allMonthDashboard(month);
            db.getConnection.Close();
            DataTable dataSet = new DataTable();
            db.getDataAdapter.Fill(dataSet);
            dashboard.Database.Tables["Dashboard"].SetDataSource(dataSet);

            display = (TextObject)dashboard.ReportDefinition.ReportObjects["display"];
            output = (TextObject)dashboard.ReportDefinition.ReportObjects["lblDisplay"];
            display.Text = "MONTH";
            output.Text = "All " + month;

            accountTypeViewer.Visible = true;
            accountTypeViewer.ReportSource = null;
            accountTypeViewer.ReportSource = dashboard;
        }
        private void allYearDashboard()
        {
            Report.CrystalReport.DashboardReport dashboard = new Report.CrystalReport.DashboardReport();
            year = int.Parse(tSTxtYearDashboard.Text);

            db.connect();
            db.allYearDashboard(year);
            db.getConnection.Close();
            DataTable dataSet = new DataTable();
            db.getDataAdapter.Fill(dataSet);
            dashboard.Database.Tables["Dashboard"].SetDataSource(dataSet);

            display = (TextObject)dashboard.ReportDefinition.ReportObjects["display"];
            output = (TextObject)dashboard.ReportDefinition.ReportObjects["lblDisplay"];
            display.Text = "YEAR";
            output.Text = "All " + year;

            accountTypeViewer.Visible = true;
            accountTypeViewer.ReportSource = null;
            accountTypeViewer.ReportSource = dashboard;
        }
        private void dayCoverage()
        {
            Report.CrystalReport.CoverageReport coverage = new Report.CrystalReport.CoverageReport();
            accOfficer = tSAccountOfficerCoverage.SelectedItem.ToString();
            day = datePicker.Text;

            db.connect();
            db.dayCoverage(accOfficer, day);
            db.getConnection.Close();
            DataTable dataSet = new DataTable();
            db.getDataAdapter.Fill(dataSet);
            coverage.Database.Tables["Coverage"].SetDataSource(dataSet);

            display = (TextObject)coverage.ReportDefinition.ReportObjects["display"];
            output = (TextObject)coverage.ReportDefinition.ReportObjects["lblDisplay"];
            display.Text = "DAY";
            output.Text = accOfficer.ToUpper() + ", " + day;

            accountTypeViewer.Visible = true;
            accountTypeViewer.ReportSource = null;
            accountTypeViewer.ReportSource = coverage;
        }
        private void monthCoverage()
        {
            Report.CrystalReport.CoverageReport coverage = new Report.CrystalReport.CoverageReport();
            accOfficer = tSAccountOfficerCoverage.SelectedItem.ToString();
            month = datePicker.Text;

            db.connect();
            db.monthCoverage(accOfficer, month);
            db.getConnection.Close();
            DataTable dataSet = new DataTable();
            db.getDataAdapter.Fill(dataSet);
            coverage.Database.Tables["Coverage"].SetDataSource(dataSet);

            display = (TextObject)coverage.ReportDefinition.ReportObjects["display"];
            output = (TextObject)coverage.ReportDefinition.ReportObjects["lblDisplay"];
            display.Text = "MONTH";
            output.Text = accOfficer.ToUpper() + ", " + month;

            accountTypeViewer.Visible = true;
            accountTypeViewer.ReportSource = null;
            accountTypeViewer.ReportSource = coverage;
        }
        private void branchDormantAccount()
        {
            branchName = tSComboDormantAccount.SelectedItem.ToString();
            db.connect();
            db.branchDormantAccount(branchName);
            db.getConnection.Close();
            DataTable dataSet = new DataTable();
            db.getDataAdapter.Fill(dataSet);
            Report.CrystalReport.DormantAccountReport dormant = new Report.CrystalReport.DormantAccountReport();
            dormant.Database.Tables["Dormant"].SetDataSource(dataSet);

            title = (TextObject)dormant.ReportDefinition.ReportObjects["lblTitle"];
            display = (TextObject)dormant.ReportDefinition.ReportObjects["display"];
            output = (TextObject)dormant.ReportDefinition.ReportObjects["lblDisplay"];
            title.Text = "Branch Dormant Report";
            display.Text = "BRANCH";
            output.Text = branchName.ToUpper() + " " + "BRANCH";

            accountTypeViewer.Visible = true;
            accountTypeViewer.ReportSource = null;
            accountTypeViewer.ReportSource = dormant;
        }
        private void tSAllDormantAccount_Click(object sender, EventArgs e)
        {
            db.connect();
            db.allDormantAccount();
            db.getConnection.Close();
            DataTable dataSet = new DataTable();
            db.getDataAdapter.Fill(dataSet);
            Report.CrystalReport.DormantAccountReport dormant = new Report.CrystalReport.DormantAccountReport();
            dormant.Database.Tables["Dormant"].SetDataSource(dataSet);

            title = (TextObject)dormant.ReportDefinition.ReportObjects["lblTitle"];
            display = (TextObject)dormant.ReportDefinition.ReportObjects["display"];
            output = (TextObject)dormant.ReportDefinition.ReportObjects["lblDisplay"];
            title.Text = "All Dormant Report";
            display.Text = "";
            output.Text = "";

            accountTypeViewer.Visible = true;
            accountTypeViewer.ReportSource = null;
            accountTypeViewer.ReportSource = dormant;
        }
        private void tSAllDefault_Click(object sender, EventArgs e)
        {
            try
            {
                Report.CrystalReport.DefaultReport defaultReport = new Report.CrystalReport.DefaultReport();
                db.connect();
                db.allDefault();
                db.getConnection.Close();
                dataSet = new DataSet();
                db.getDataAdapter.Fill(dataSet);

                defaultReport.Database.Tables["Default"].SetDataSource(dataSet.Tables[0]);

                display = (TextObject)defaultReport.ReportDefinition.ReportObjects["display"];
                output = (TextObject)defaultReport.ReportDefinition.ReportObjects["lblDisplay"];
                display.Text = "";
                output.Text = "";

                accountTypeViewer.Visible = true;
                accountTypeViewer.ReportSource = null;
                accountTypeViewer.ReportSource = defaultReport;
            }
            catch (SqlException sql)
            {
                MessageBox.Show(sql.Message);
            }
        }
        private void tSAccountBalance_Click(object sender, EventArgs e)
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
                            Report.CrystalReport.AccountBalanceReport accountBalanceReport = new Report.CrystalReport.AccountBalanceReport();
                            db.connect();
                            db.accountBalanceReport();
                            db.getConnection.Close();
                            dataSet = new DataSet();
                            db.getDataAdapter.Fill(dataSet);

                            accountBalanceReport.Database.Tables["AccountBalance"].SetDataSource(dataSet.Tables[0]);

                            display = (TextObject)accountBalanceReport.ReportDefinition.ReportObjects["display"];
                            output = (TextObject)accountBalanceReport.ReportDefinition.ReportObjects["lblDisplay"];
                            display.Text = "";
                            output.Text = "";

                            accountTypeViewer.Visible = true;
                            accountTypeViewer.ReportSource = null;
                            accountTypeViewer.ReportSource = accountBalanceReport;
                        }
                        catch (SqlException sql)
                        {
                            MessageBox.Show(sql.Message);
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
        private void allTSMenuItemBalancedLoan_Click(object sender, EventArgs e)
        {
            try
            {
                db.connect();
                db.getAllBalancedLoan();
                db.getConnection.Close();
                dataSet = new DataSet();
                db.getDataAdapter.Fill(dataSet);
                Report.CrystalReport.AllBalancedLoanReport balancedLoan = new Report.CrystalReport.AllBalancedLoanReport();
                balancedLoan.Database.Tables["LoanPortfolio"].SetDataSource(dataSet.Tables[0]);

                title = (TextObject)balancedLoan.ReportDefinition.ReportObjects["lblTitle"];
                display = (TextObject)balancedLoan.ReportDefinition.ReportObjects["display"];
                output = (TextObject)balancedLoan.ReportDefinition.ReportObjects["lblDisplay"];
                title.Text = "All Balanced Loan Report";
                display.Text = "";
                output.Text = "";

                accountTypeViewer.Visible = true;
                accountTypeViewer.ReportSource = null;
                accountTypeViewer.ReportSource = balancedLoan;
            }
            catch (SqlException sql)
            {
                MessageBox.Show(sql.Message);
            }
        }
        private void allTSMenuItemUnbalancedLoan_Click(object sender, EventArgs e)
        {
            try
            {
                db.connect();
                db.getAllUnbalancedLoan();
                db.getConnection.Close();
                dataSet = new DataSet();
                db.getDataAdapter.Fill(dataSet);
                Report.CrystalReport.AllUnbalancedLoanReport unbalancedLoan = new Report.CrystalReport.AllUnbalancedLoanReport();
                unbalancedLoan.Database.Tables["LoanPortfolio"].SetDataSource(dataSet.Tables[0]);

                title = (TextObject)unbalancedLoan.ReportDefinition.ReportObjects["lblTitle"];
                display = (TextObject)unbalancedLoan.ReportDefinition.ReportObjects["display"];
                output = (TextObject)unbalancedLoan.ReportDefinition.ReportObjects["lblDisplay"];
                title.Text = "All Unbalanced Loan Report";
                display.Text = "";
                output.Text = "";

                accountTypeViewer.Visible = true;
                accountTypeViewer.ReportSource = null;
                accountTypeViewer.ReportSource = unbalancedLoan;
            }
            catch (SqlException sql)
            {
                MessageBox.Show(sql.Message);
            }
        }
        private void loanSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                db.connect();
                db.loanPortfolio();
                db.getConnection.Close();
                dataSet = new DataSet();
                db.getDataAdapter.Fill(dataSet);
                Report.CrystalReport.AllUnbalancedLoanReport portfolio = new Report.CrystalReport.AllUnbalancedLoanReport();
                portfolio.Database.Tables["LoanPortfolio"].SetDataSource(dataSet.Tables[0]);

                title = (TextObject)portfolio.ReportDefinition.ReportObjects["lblTitle"];
                display = (TextObject)portfolio.ReportDefinition.ReportObjects["display"];
                output = (TextObject)portfolio.ReportDefinition.ReportObjects["lblDisplay"];
                title.Text = "Loan Summary Report";
                display.Text = "";
                output.Text = "";

                accountTypeViewer.Visible = true;
                accountTypeViewer.ReportSource = null;
                accountTypeViewer.ReportSource = portfolio;
            }
            catch (SqlException sql)
            {
                MessageBox.Show(sql.Message);
            }
        }
        private void tSAllAccount_Click(object sender, EventArgs e)
        {
            try
            {
                db.connect();
                db.customerRegReport();
                db.getConnection.Close();
                dataSet = new DataSet();
                db.getDataAdapter.Fill(dataSet);

                Report.CrystalReport.CustomerRegReport customerReport = new Report.CrystalReport.CustomerRegReport();
                customerReport.Database.Tables["CustomerReg"].SetDataSource(dataSet.Tables[0]);

                title = (TextObject)customerReport.ReportDefinition.ReportObjects["lblTitle"];
                display = (TextObject)customerReport.ReportDefinition.ReportObjects["display"];
                output = (TextObject)customerReport.ReportDefinition.ReportObjects["lblDisplay"];
                title.Text = "All Customer Registration";
                display.Text = "";
                output.Text = "";

                accountTypeViewer.Visible = true;
                accountTypeViewer.ReportSource = null;
                accountTypeViewer.ReportSource = customerReport;
            }
            catch (NullReferenceException nre)
            {
                tSComboAccountType.Text = null;
            }
        }
        private void allTSMenuItemOverdue_Click(object sender, EventArgs e)
        {
            try
            {
                db.connect();
                db.allOverdueLoanReport();
                db.getConnection.Close();
                DataTable dataSet = new DataTable();
                db.getDataAdapter.Fill(dataSet);
                Report.CrystalReport.AllOverdueLoanReport overdue = new Report.CrystalReport.AllOverdueLoanReport();
                overdue.Database.Tables["LoanPortfolio"].SetDataSource(dataSet);

                title = (TextObject)overdue.ReportDefinition.ReportObjects["lblTitle"];
                display = (TextObject)overdue.ReportDefinition.ReportObjects["display"];
                output = (TextObject)overdue.ReportDefinition.ReportObjects["lblDisplay"];
                title.Text = "All Overdue Loan Report";
                display.Text = "";
                output.Text = "";

                accountTypeViewer.Visible = true;
                accountTypeViewer.ReportSource = null;
                accountTypeViewer.ReportSource = overdue;
            }
            catch (IndexOutOfRangeException idx)
            {
                MessageBox.Show(idx.Message);
            }
            catch (SqlException sql)
            {
                MessageBox.Show(sql.Message);
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
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
                        if (btnSearch.Text.Equals("AM Bal"))
                        {
                            monthlyBalancedAccOfficer();
                        }
                        else if (btnSearch.Text.Equals("AY Bal"))
                        {
                            yearlyBalancedAccOfficer();
                        }
                        else if (btnSearch.Text.Equals("BM Bal"))
                        {
                            monthlyBalancedBranch();
                        }
                        else if (btnSearch.Text.Equals("BY Bal"))
                        {
                            yearlyBalancedBranch();
                        }
                        else if (btnSearch.Text.Equals("AM Unbal"))
                        {
                            monthlyUnbalancedAccOfficer();
                        }
                        else if (btnSearch.Text.Equals("AY Unbal"))
                        {
                            yearlyUnbalancedAccOfficer();
                        }
                        else if (btnSearch.Text.Equals("BM Unbal"))
                        {
                            monthlyUnbalancedBranch();
                        }
                        else if (btnSearch.Text.Equals("BY Unbal"))
                        {
                            yearlyUnbalancedBranch();
                        }
                        else if (btnSearch.Text.Equals("Month"))
                        {
                            accountMonth();
                        }
                        else if (btnSearch.Text.Equals("Year"))
                        {
                            accountYear();
                        }
                        else if (btnSearch.Text.Equals("A Reg"))
                        {
                            accountOfficerReg();
                        }
                        else if (btnSearch.Text.Equals("B Reg"))
                        {
                            branchReg();
                        }
                        else if (btnSearch.Text.Equals("A Overdue"))
                        {
                            accountOfficerOverdueLoan();
                        }
                        else if (btnSearch.Text.Equals("B Overdue"))
                        {
                            branchOverdueLoan();
                        }
                        else if (btnSearch.Text.Equals("Group"))
                        {
                            groupReg();
                        }
                        else if (btnSearch.Text.Equals("M Close"))
                        {
                            monthlyClosedAccount();
                        }
                        else if (btnSearch.Text.Equals("Y Close"))
                        {
                            yearlyClosedAccount();
                        }
                        else if (btnSearch.Text.Equals("AM Perform"))
                        {
                            accountOfficerMonthlyPerformance();
                        }
                        else if (btnSearch.Text.Equals("AY Perform"))
                        {
                            accountOfficerYearlyPerformance();
                        }
                        else if (btnSearch.Text.Equals("BM Perform"))
                        {
                            branchMonthlyPerformance();
                        }
                        else if (btnSearch.Text.Equals("BY Perform"))
                        {
                            branchYearlyPerformance();
                        }
                        else if (btnSearch.Text.Equals("D Dep"))
                        {
                            dayDeposit();
                        }
                        else if (btnSearch.Text.Equals("M Dep"))
                        {
                            monthDeposit();
                        }
                        else if (btnSearch.Text.Equals("Y Dep"))
                        {
                            yearDeposit();
                        }
                        else if (btnSearch.Text.Equals("D Pf"))
                        {
                            dayPf();
                        }
                        else if (btnSearch.Text.Equals("M Pf"))
                        {
                            monthPf();
                        }
                        else if (btnSearch.Text.Equals("Y Pf"))
                        {
                            yearPf();
                        }
                        else if (btnSearch.Text.Equals("D Trans"))
                        {
                            dayTransfer();
                        }
                        else if (btnSearch.Text.Equals("M Trans"))
                        {
                            monthTransfer();
                        }
                        else if (btnSearch.Text.Equals("Y Trans"))
                        {
                            yearTransfer();
                        }
                        else if (btnSearch.Text.Equals("D With"))
                        {
                            dayWithdrawal();
                        }
                        else if (btnSearch.Text.Equals("M With"))
                        {
                            monthWithdrawal();
                        }
                        else if (btnSearch.Text.Equals("Y With"))
                        {
                            yearWithdrawal();
                        }
                        else if (btnSearch.Text.Equals("M Income"))
                        {
                            monthlyIncome();
                        }
                        else if (btnSearch.Text.Equals("Y Income"))
                        {
                            yearlyIncome();
                        }
                        else if (btnSearch.Text.Equals("BM Income"))
                        {
                            branchMonthlyIncome();
                        }
                        else if (btnSearch.Text.Equals("BY Income"))
                        {
                            branchYearlyIncome();
                        }
                        else if (btnSearch.Text.Equals("D Disburse"))
                        {
                            dayDisburse();
                        }
                        else if (btnSearch.Text.Equals("M Disburse"))
                        {
                            monthlyDisburse();
                        }
                        else if (btnSearch.Text.Equals("Y Disburse"))
                        {
                            yearlyDisburse();
                        }
                        else if (btnSearch.Text.Equals("AD Disburse"))
                        {
                            allDailyDisburse();
                        }
                        else if (btnSearch.Text.Equals("AM Disburse"))
                        {
                            allMonthlyDisburse();
                        }
                        else if (btnSearch.Text.Equals("AY Disburse"))
                        {
                            allYearlyDisburse();
                        }
                        else if (btnSearch.Text.Equals("A Terms"))
                        {
                            accountOfficerPaymentTerms();
                        }
                        else if (btnSearch.Text.Equals("B Terms"))
                        {
                            branchPaymentTerms();
                        }
                        else if (btnSearch.Text.Equals("G Loan"))
                        {
                            groupLoan();
                        }
                        else if (btnSearch.Text.Equals("D Call"))
                        {
                            dayCallOver();
                        }
                        else if (btnSearch.Text.Equals("M Call"))
                        {
                            monthCallOver();
                        }
                        else if (btnSearch.Text.Equals("Y Call"))
                        {
                            yearCallOver();
                        }
                        else if (btnSearch.Text.Equals("D Dash"))
                        {
                            dayDashboard();
                        }
                        else if (btnSearch.Text.Equals("M Dash"))
                        {
                            monthDashboard();
                        }
                        else if (btnSearch.Text.Equals("Y Dash"))
                        {
                            yearDashboard();
                        }
                        else if (btnSearch.Text.Equals("All D Dash"))
                        {
                            allDayDashboard();
                        }
                        else if (btnSearch.Text.Equals("All M Dash"))
                        {
                            allMonthDashboard();
                        }
                        else if (btnSearch.Text.Equals("All Y Dash"))
                        {
                            allYearDashboard();
                        }
                        else if (btnSearch.Text.Equals("Acc Call"))
                        {
                            accountOfficerCallOver();
                        }
                        else if (btnSearch.Text.Equals("D Cov"))
                        {
                            dayCoverage();
                        }
                        else if (btnSearch.Text.Equals("M Cov"))
                        {
                            monthCoverage();
                        }
                        else if (btnSearch.Text.Equals("B Dom"))
                        {
                            branchDormantAccount();
                        }
                        else
                        {
                            accountTypeDetails();
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
        private void tSComboAccountType_Click(object sender, EventArgs e)
        {
            btnSearch.Visible = true;
            btnSearch.Text = "Account";
        }
        private void tSComboAccOfficerBal_Click(object sender, EventArgs e)
        {
            btnSearch.Visible = true;
            btnSearch.Text = "Search";
        }
        private void tSComboBranchBal_Click(object sender, EventArgs e)
        {
            btnSearch.Visible = true;
            btnSearch.Text = "Branch";
        }
        private void tSComboAccOfficerUnbal_Click(object sender, EventArgs e)
        {
            btnSearch.Visible = true;
            btnSearch.Text = "Search2";
        }
        private void tSComboBranchUnbal_Click(object sender, EventArgs e)
        {
            btnSearch.Visible = true;
            btnSearch.Text = "Branch2";
        }
        private void tSComboMonth_Click(object sender, EventArgs e)
        {
            datePicker.Visible = true;
            btnSearch.Visible = true;
            btnSearch.Text = "Month";
        }
        private void tSTxtYear_Click(object sender, EventArgs e)
        {
            btnSearch.Visible = true;
            btnSearch.Text = "Year";
        }
        private void tSComboBranchReg_Click(object sender, EventArgs e)
        {
            btnSearch.Visible = true;
            btnSearch.Text = "B Reg";
        }
        private void tSComboAccountOfficerReg_Click(object sender, EventArgs e)
        {
            btnSearch.Visible = true;
            btnSearch.Text = "A Reg";
        }
        private void tSComboGroupReg_Click(object sender, EventArgs e)
        {
            btnSearch.Visible = true;
            btnSearch.Text = "Group";
        }
        private void tSComboBranchOverdue_Click(object sender, EventArgs e)
        {
            btnSearch.Visible = true;
            btnSearch.Text = "B Overdue";
        }
        private void tSComboAccOfficerOverdue_Click(object sender, EventArgs e)
        {
            btnSearch.Visible = true;
            btnSearch.Text = "A Overdue";
        }
        private void tSComboClosedAccount_Click(object sender, EventArgs e)
        {
            datePicker.Visible = true;
            btnSearch.Visible = true;
            btnSearch.Text = "M Close";
        }
        private void tSTxtClosedAccount_Click(object sender, EventArgs e)
        {
            btnSearch.Visible = true;
            btnSearch.Text = "Y Close";
        }
        private void tSComboAccOffMonthPerformance_Click(object sender, EventArgs e)
        {
            datePicker.Visible = true;
            btnSearch.Visible = true;
            btnSearch.Text = "AM Perform";
        }

        private void tSTxtAccOffYearPerformance_Click(object sender, EventArgs e)
        {
            btnSearch.Visible = true;
            btnSearch.Text = "AY Perform";
        }

        private void tSComboBranchMonthlyPerformance_Click(object sender, EventArgs e)
        {
            datePicker.Visible = true;
            btnSearch.Visible = true;
            btnSearch.Text = "BM Perform";
        }

        private void tSTxtBranchYearPerformance_Click(object sender, EventArgs e)
        {
            btnSearch.Visible = true;
            btnSearch.Text = "BY Perform";
        }
        private void tSComboMonthDeposit_Click(object sender, EventArgs e)
        {
            datePicker.Visible = true;
        }
        private void tSTxtYearDeposit_Click(object sender, EventArgs e)
        {
            datePicker.Visible = true;
            btnSearch.Visible = true;
            btnSearch.Text = "Y Dep";
        }
        private void tSComboBranchDeposit_Click(object sender, EventArgs e)
        {
            btnSearch.Visible = true;
            string month = tSComboMonthDeposit.Text;
            if (month.Equals("SELECT INTERVAL"))
            {
                MessageBox.Show("Please select the interval", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (tSComboMonthDeposit.SelectedItem.Equals("DAY"))
                {
                    btnSearch.Text = "D Dep";
                }
                else if (tSComboMonthDeposit.SelectedItem.Equals("MONTH"))
                {
                    btnSearch.Text = "M Dep";
                }
            }
        }
        private void tSComboMonthPf_Click(object sender, EventArgs e)
        {
            datePicker.Visible = true;
        }
        private void tSTxtYearPf_Click(object sender, EventArgs e)
        {
            datePicker.Visible = true;
            btnSearch.Visible = true;
            btnSearch.Text = "Y Pf";
        }
        private void tSComboBranchPf_Click(object sender, EventArgs e)
        {
            btnSearch.Visible = true;
            string month = tSComboMonthPf.Text;
            if (month.Equals("SELECT INTERVAL"))
            {
                MessageBox.Show("Please select the interval", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (tSComboMonthPf.SelectedItem.Equals("DAY"))
                {
                    btnSearch.Text = "D Pf";
                }
                else if (tSComboMonthPf.SelectedItem.Equals("MONTH"))
                {
                    btnSearch.Text = "M Pf";
                }
            }
        }
        private void tSComboMonthTransfer_Click(object sender, EventArgs e)
        {
            datePicker.Visible = true;
        }
        private void tSTxtYearTransfer_Click(object sender, EventArgs e)
        {
            datePicker.Visible = true;
            btnSearch.Visible = true;
            btnSearch.Text = "Y Trans";
        }
        private void tSComboBranchTransfer_Click(object sender, EventArgs e)
        {
            btnSearch.Visible = true;
            string month = tSComboMonthTransfer.Text;
            if (month.Equals("SELECT INTERVAL"))
            {
                MessageBox.Show("Please select the interval", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (tSComboMonthTransfer.SelectedItem.Equals("DAY"))
                {
                    btnSearch.Text = "D Trans";
                }
                else if (tSComboMonthTransfer.SelectedItem.Equals("MONTH"))
                {
                    btnSearch.Text = "M Trans";
                }
            }
        }
        private void tSComboMonthWithdrawal_Click(object sender, EventArgs e)
        {
            datePicker.Visible = true;
        }
        private void tSTxtYearWithdrawal_Click(object sender, EventArgs e)
        {
            datePicker.Visible = true;
            btnSearch.Visible = true;
            btnSearch.Text = "Y With";
        }
        private void tSComboBranchWithdrawal_Click(object sender, EventArgs e)
        {
            btnSearch.Visible = true;
            string month = tSComboMonthWithdrawal.Text;
            if (month.Equals("SELECT INTERVAL"))
            {
                MessageBox.Show("Please select the interval", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (tSComboMonthWithdrawal.SelectedItem.Equals("DAY"))
                {
                    btnSearch.Text = "D With";
                }
                else if (tSComboMonthWithdrawal.SelectedItem.Equals("MONTH"))
                {
                    btnSearch.Text = "M With";
                }
            }
        }
        private void tSComboBranchMonthIncome_Click(object sender, EventArgs e)
        {
            datePicker.Visible = true;
            btnSearch.Visible = true;
            btnSearch.Text = "BM Income";
        }
        private void tSTxtBranchYearIncome_Click(object sender, EventArgs e)
        {
            btnSearch.Visible = true;
            btnSearch.Text = "BY Income";
        }
        private void tSComboMonthIncome_Click(object sender, EventArgs e)
        {
            datePicker.Visible = true;
            btnSearch.Visible = true;
            btnSearch.Text = "M Income";
        }
        private void tSTxtYearIncome_Click(object sender, EventArgs e)
        {
            btnSearch.Visible = true;
            btnSearch.Text = "Y Income";
        }
        private void tSComboMonthlyDisburse_Click(object sender, EventArgs e)
        {
            datePicker.Visible = true;
        }
        private void tSTxtYearDisburse_Click(object sender, EventArgs e)
        {
            datePicker.Visible = true;
            btnSearch.Visible = true;
            btnSearch.Text = "Y Disburse";
        }
        private void tSComboBranchDisburse_Click(object sender, EventArgs e)
        {
            datePicker.Visible = true;
            btnSearch.Visible = true;
            string month = tSComboMonthlyDisburse.Text;
            if (month.Equals("SELECT INTERVAL"))
            {
                MessageBox.Show("Please select the interval", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (tSComboMonthlyDisburse.SelectedItem.Equals("DAY"))
                {
                    btnSearch.Text = "D Disburse";
                }
                else if (tSComboMonthlyDisburse.SelectedItem.Equals("MONTH"))
                {
                    btnSearch.Text = "M Disburse";
                }
            }
        }
        private void tSComboAllMonthDisburse_Click(object sender, EventArgs e)
        {
            datePicker.Visible = true;
        }
        private void tSTxtAllYearDisburse_Click(object sender, EventArgs e)
        {
            datePicker.Visible = true;
            btnSearch.Visible = true;
            btnSearch.Text = "AY Disburse";
        }
        private void tSAllDisbursementShow_Click(object sender, EventArgs e)
        {
            btnSearch.Visible = true;
            string month = tSComboAllMonthDisburse.Text;
            if (month.Equals("SELECT INTERVAL"))
            {
                MessageBox.Show("Please select the interval", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (tSComboAllMonthDisburse.SelectedItem.Equals("DAY"))
                {
                    btnSearch.Text = "AD Disburse";
                }
                else if (tSComboAllMonthDisburse.SelectedItem.Equals("MONTH"))
                {
                    btnSearch.Text = "AM Disburse";
                }
            }
        }
        private void tSComboAccOffMonthBalancedLoan_Click(object sender, EventArgs e)
        {
            datePicker.Visible = true;
            btnSearch.Visible = true;
            btnSearch.Text = "AM Bal";
        }

        private void tSTxtAccOffYearBalancedLoan_Click(object sender, EventArgs e)
        {
            datePicker.Visible = false;
            btnSearch.Visible = true;
            btnSearch.Text = "AY Bal";
        }
        private void tSComboBranchMonthBalancedLoan_Click(object sender, EventArgs e)
        {
            datePicker.Visible = true;
            btnSearch.Visible = true;
            btnSearch.Text = "BM Bal";
        }

        private void tSTxtBranchYearBalancedLoan_Click(object sender, EventArgs e)
        {
            datePicker.Visible = false;
            btnSearch.Visible = true;
            btnSearch.Text = "BY Bal";
        }
        private void tSComboAccOffMonthUnbalancedLoan_Click(object sender, EventArgs e)
        {
            datePicker.Visible = true;
            btnSearch.Visible = true;
            btnSearch.Text = "AM Unbal";
        }

        private void tSTxtAccOffYearUnbalancedLoan_Click(object sender, EventArgs e)
        {
            datePicker.Visible = false;
            btnSearch.Visible = true;
            btnSearch.Text = "AY Unbal";
        }

        private void tSComboBranchMonthUnbalancedLoan_Click(object sender, EventArgs e)
        {
            datePicker.Visible = true;
            btnSearch.Visible = true;
            btnSearch.Text = "BM Unbal";
        }

        private void tSTxtBranchYearUnbalancedLoan_Click(object sender, EventArgs e)
        {
            datePicker.Visible = false;
            btnSearch.Visible = true;
            btnSearch.Text = "BY Unbal";
        }
        private void tSComboAccountOfficerPaymentTerms_Click(object sender, EventArgs e)
        {
            datePicker.Visible = false;
            btnSearch.Visible = true;
            btnSearch.Text = "A Terms";
        }
        private void tSComboBranchPaymentTerms_Click(object sender, EventArgs e)
        {
            datePicker.Visible = false;
            btnSearch.Visible = true;
            btnSearch.Text = "B Terms";
        }

        private void tSComboLoanGroupName_Click(object sender, EventArgs e)
        {
            datePicker.Visible = false;
            btnSearch.Visible = true;
            btnSearch.Text = "G Loan";
        }
        private void tSComboMonthCallOver_Click(object sender, EventArgs e)
        {
            datePicker.Visible = true;
        }

        private void tSTxtYearCallOver_Click(object sender, EventArgs e)
        {
            datePicker.Visible = true;
            btnSearch.Visible = true;
            btnSearch.Text = "Y Call";
        }
        private void tSComboAccOfficerCallOver_Click(object sender, EventArgs e)
        {
            datePicker.Visible = true;
            branchStatus = "Acc Call";
        }
        private void tSComboUserCallOver_Click(object sender, EventArgs e)
        {
            string month = tSComboMonthCallOver.Text;
            if (month.Equals("SELECT INTERVAL") && tSComboAccOfficerCallOver.Text.Equals("Account Officer"))
            {
                MessageBox.Show("Please select the interval", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (month.Equals("SELECT INTERVAL") && tSComboAccOfficerCallOver.Text != "Account Officer")
            {
                MessageBox.Show("Please select the interval", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (month != "SELECT INTERVAL" && tSComboAccOfficerCallOver.Text != "Account Officer")
            {
                btnSearch.Visible = true;
                btnSearch.Text = branchStatus;
            }
            else
            {
                btnSearch.Visible = true;
                if (tSComboMonthCallOver.SelectedItem.Equals("DAY"))
                {
                    btnSearch.Text = "D Call";
                }
                else if (tSComboMonthCallOver.SelectedItem.Equals("MONTH"))
                {
                    btnSearch.Text = "M Call";
                }
            }
        }
        private void tSComboMonthDashboard_Click(object sender, EventArgs e)
        {
            datePicker.Visible = true;
        }

        private void tSTxtYearDashboard_Click(object sender, EventArgs e)
        {
            datePicker.Visible = true;
            btnSearch.Visible = true;
            btnSearch.Text = "Y Dash";
        }
        private void tSComboBranchDashboard_Click(object sender, EventArgs e)
        {
            btnSearch.Visible = true;
            string month = tSComboMonthDashboard.Text;
            if (month.Equals("SELECT INTERVAL"))
            {
                MessageBox.Show("Please select the interval", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (tSComboMonthDashboard.SelectedItem.Equals("DAY"))
                {
                    btnSearch.Text = "D Dash";
                }
                else if (tSComboMonthDashboard.SelectedItem.Equals("MONTH"))
                {
                    btnSearch.Text = "M Dash";
                }
            }
        }
        private void tSComboAllMonthDashboard_Click(object sender, EventArgs e)
        {
            datePicker.Visible = true;
        }
        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnSearch.Visible = true;
            string month = tSComboAllMonthDashboard.Text;
            if (month.Equals("SELECT INTERVAL"))
            {
                MessageBox.Show("Please select the interval", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (tSComboAllMonthDashboard.SelectedItem.Equals("DAY"))
                {
                    btnSearch.Text = "All D Dash";
                }
                else if (tSComboAllMonthDashboard.SelectedItem.Equals("MONTH"))
                {
                    btnSearch.Text = "All M Dash";
                }
            }
        }
        private void tSComboCoverage_Click(object sender, EventArgs e)
        {
            datePicker.Visible = true;
        }
        private void tSAccountOfficerCoverage_Click(object sender, EventArgs e)
        {
            btnSearch.Visible = true;
            string month = tSComboCoverage.Text;
            if (month.Equals("SELECT INTERVAL"))
            {
                MessageBox.Show("Please select the interval", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (tSComboCoverage.SelectedItem.Equals("DAY"))
                {
                    btnSearch.Text = "D Cov";
                }
                else if (tSComboCoverage.SelectedItem.Equals("MONTH"))
                {
                    btnSearch.Text = "M Cov";
                }
            }
        }
        private void tSTxtAllYearDashboard_Click(object sender, EventArgs e)
        {
            datePicker.Visible = true;
            btnSearch.Visible = true;
            btnSearch.Text = "All Y Dash";
        }
        private void tSComboBranchMonthReg_Click(object sender, EventArgs e)
        {
            datePicker.Visible = true;
        }
        private void tSComboAccountOfficerMonthReg_Click(object sender, EventArgs e)
        {
            datePicker.Visible = true;
        }
        private void tSComboGroupMonthReg_Click(object sender, EventArgs e)
        {
            datePicker.Visible = true;
        }
        private void tSComboDormantAccount_Click(object sender, EventArgs e)
        {
            btnSearch.Visible = true;
            btnSearch.Text = "B Dom";
        }
        private void ReportView_Load(object sender, EventArgs e)
        {
            getDayMonth();
        }
    }
}
