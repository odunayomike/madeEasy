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
    public partial class Department : Form
    {
        string departmentName, departmentID, customerReg, statement, freeze, dashboard, branchSetup, deposit,
            withdrawal, depDate, withDate, balance, accountSetup, disburse, balanceLoan, deleteAccount,
            department, employee, extendLoan, generateCode, delSuspendUser, editTrans, logoutUser, callOver,
            otherUsers, reportView, sub, groupReg, workHour, transReport, accountReport, loanPortfolio, branchTrans,
            performance, incomeOverview, thresholdSetup, transactionApproval, expenditure;
        DatabaseLib db;
        public Department()
        {
            InitializeComponent();
            db = new DatabaseLib();
            getDepartment();
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
        private void checkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            checkCustReg.Checked = true;
            checkStatement.Checked = true;
            checkFreeze.Checked = true;
            checkDashboard.Checked = true;
            checkBranchSetup.Checked = true;
            checkDeposit.Checked = true;
            checkWithdrawal.Checked = true;
            checkDepDate.Checked = true;
            checkWithDate.Checked = true;
            checkBalance.Checked = true;
            checkAccountSetup.Checked = true;
            checkDisburse.Checked = true;
            checkBalanceLoan.Checked = true;
            checkDeleteAccount.Checked = true;
            checkDepartment.Checked = true;
            checkEmployee.Checked = true;
            checkExtendLoan.Checked = true;
            checkGenerateCode.Checked = true;
            checkDelSuspendUser.Checked = true;
            checkEditTrans.Checked = true;
            checkLogoutUser.Checked = true;
            checkCallOver.Checked = true;
            checkOtherUsers.Checked = true;
            checkGroupReg.Checked = true;
            checkWorkHour.Checked = true;
            checkTransReport.Checked = true;
            checkAccountReport.Checked = true;
            checkLoanPortfolio.Checked = true;
            checkBranchTrans.Checked = true;
            checkPerformance.Checked = true;
            checkIncomeOverview.Checked = true;
            checkReport.Checked = true;
            checkThresholdSetup.Checked = true;
            checkTransactionApproval.Checked = true;
            checkExpenditure.Checked = true;
            if (checkSelectAll.Checked == false)
            {
                checkCustReg.Checked = false;
                checkStatement.Checked = false;
                checkFreeze.Checked = false;
                checkDashboard.Checked = false;
                checkBranchSetup.Checked = false;
                checkDeposit.Checked = false;
                checkWithdrawal.Checked = false;
                checkDepDate.Checked = false;
                checkWithDate.Checked = false;
                checkBalance.Checked = false;
                checkAccountSetup.Checked = false;
                checkDisburse.Checked = false;
                checkBalanceLoan.Checked = false;
                checkDeleteAccount.Checked = false;
                checkDepartment.Checked = false;
                checkEmployee.Checked = false;
                checkExtendLoan.Checked = false;
                checkGenerateCode.Checked = false;
                checkDelSuspendUser.Checked = false;
                checkEditTrans.Checked = false;
                checkLogoutUser.Checked = false;
                checkCallOver.Checked = false;
                checkOtherUsers.Checked = false;
                checkGroupReg.Checked = false;
                checkWorkHour.Checked = false;
                checkTransReport.Checked = false;
                checkAccountReport.Checked = false;
                checkLoanPortfolio.Checked = false;
                checkBranchTrans.Checked = false;
                checkPerformance.Checked = false;
                checkIncomeOverview.Checked = false;
                checkReport.Checked = false;
                checkThresholdSetup.Checked = false;
                checkTransactionApproval.Checked = false;
                checkExpenditure.Checked = false;
            }
        }
        private int validateDepartment()
        {
            int flag = 0;
            if (txtDepartment.Text.Length == 0)
            {
                txtDepartment.Focus();
                errorProvider.SetError(txtDepartment, "Please enter the department name!");
                flag = 1;
            }
            return flag;
        }
        private string custRegStatus()
        {
            string status = "false";
            if (checkCustReg.Checked == true)
            {
                status = "true";
            }
            else 
            {
                status = "false";
            }
            return status;
        }
        private string statementStatus()
        {
            string status = "false";
            if (checkStatement.Checked == true)
            {
                status = "true";
            }
            else
            {
                status = "false";
            }
            return status;
        }
        private string freezeStatus()
        {
            string status = "false";
            if (checkFreeze.Checked == true)
            {
                status = "true";
            }
            else
            {
                status = "false";
            }
            return status;
        }
        private string dashboardStatus()
        {
            string status = "false";
            if (checkDashboard.Checked == true)
            {
                status = "true";
            }
            else
            {
                status = "false";
            }
            return status;
        }  
        private string branchSetupStatus()
        {
            string status = "false";
            if (checkBranchSetup.Checked == true)
            {
                status = "true";
            }
            else
            {
                status = "false";
            }
            return status;
        }  
        private string depositStatus()
        {
            string status = "false";
            if (checkDeposit.Checked == true)
            {
                status = "true";
            }
            else
            {
                status = "false";
            }
            return status;
        }     
        private string withdrawalStatus()
        {
            string status = "false";
            if (checkWithdrawal.Checked == true)
            {
                status = "true";
            }
            else
            {
                status = "false";
            }
            return status;
        }     
        private string depDateStatus()
        {
            string status = "false";
            if (checkDepDate.Checked == true)
            {
                status = "true";
            }
            else
            {
                status = "false";
            }
            return status;
        }   
        private string withDateStatus()
        {
            string status = "false";
            if (checkWithDate.Checked == true)
            {
                status = "true";
            }
            else
            {
                status = "false";
            }
            return status;
        }   
        private string balanceStatus()
        {
            string status = "false";
            if (checkBalance.Checked == true)
            {
                status = "true";
            }
            else
            {
                status = "false";
            }
            return status;
        }  
        private string accountSetupStatus()
        {
            string status = "false";
            if (checkAccountSetup.Checked == true)
            {
                status = "true";
            }
            else
            {
                status = "false";
            }
            return status;
        }  
        private string disburseStatus()
        {
            string status = "false";
            if (checkDisburse.Checked == true)
            {
                status = "true";
            }
            else
            {
                status = "false";
            }
            return status;
        }  
        private string balanceLoanStatus()
        {
            string status = "false";
            if (checkBalanceLoan.Checked == true)
            {
                status = "true";
            }
            else
            {
                status = "false";
            }
            return status;
        }  
        private string deleteAccountStatus()
        {
            string status = "false";
            if (checkDeleteAccount.Checked == true)
            {
                status = "true";
            }
            else
            {
                status = "false";
            }
            return status;
        }  
        private string departmentStatus()
        {
            string status = "false";
            if (checkDepartment.Checked == true)
            {
                status = "true";
            }
            else
            {
                status = "false";
            }
            return status;
        }
        private string employeeStatus()
        {
            string status = "false";
            if (checkEmployee.Checked == true)
            {
                status = "true";
            }
            else
            {
                status = "false";
            }
            return status;
        }
        private string extendLoanStatus()
        {
            string status = "false";
            if (checkExtendLoan.Checked == true)
            {
                status = "true";
            }
            else
            {
                status = "false";
            }
            return status;
        }
        private string generateCodeStatus()
        {
            string status = "false";
            if (checkGenerateCode.Checked == true)
            {
                status = "true";
            }
            else
            {
                status = "false";
            }
            return status;
        }
        private string delSuspendUserStatus()
        {
            string status = "false";
            if (checkDelSuspendUser.Checked == true)
            {
                status = "true";
            }
            else
            {
                status = "false";
            }
            return status;
        }
        private string editTransStatus()
        {
            string status = "false";
            if (checkEditTrans.Checked == true)
            {
                status = "true";
            }
            else
            {
                status = "false";
            }
            return status;
        }
        private string logoutUserStatus()
        {
            string status = "false";
            if (checkLogoutUser.Checked == true)
            {
                status = "true";
            }
            else
            {
                status = "false";
            }
            return status;
        }
        private string callOverStatus()
        {
            string status = "false";
            if (checkCallOver.Checked == true)
            {
                status = "true";
            }
            else
            {
                status = "false";
            }
            return status;
        }
        private string otherUsersStatus()
        {
            string status = "false";
            if (checkOtherUsers.Checked == true)
            {
                status = "true";
            }
            else
            {
                status = "false";
            }
            return status;
        }
        private string reportStatus()
        {
            string status = "false";
            if (checkReport.Checked == true)
            {
                status = "true";
            }
            else
            {
                status = "false";
            }
            return status;
        }
        private string groupRegStatus()
        {
            string status = "false";
            if (checkGroupReg.Checked == true)
            {
                status = "true";
            }
            else
            {
                status = "false";
            }
            return status;
        }
        private string workHourStatus()
        {
            string status = "false";
            if (checkWorkHour.Checked == true)
            {
                status = "true";
            }
            else
            {
                status = "false";
            }
            return status;
        }
        private string transReportStatus()
        {
            string status = "false";
            if (checkTransReport.Checked == true)
            {
                status = "true";
            }
            else
            {
                status = "false";
            }
            return status;
        }
        private string accountReportStatus()
        {
            string status = "false";
            if (checkAccountReport.Checked == true)
            {
                status = "true";
            }
            else
            {
                status = "false";
            }
            return status;
        }
        private string loanPortfolioStatus()
        {
            string status = "false";
            if (checkLoanPortfolio.Checked == true)
            {
                status = "true";
            }
            else
            {
                status = "false";
            }
            return status;
        }
        private string branchTransStatus()
        {
            string status = "false";
            if (checkBranchTrans.Checked == true)
            {
                status = "true";
            }
            else
            {
                status = "false";
            }
            return status;
        }
        private string performanceStatus()
        {
            string status = "false";
            if (checkPerformance.Checked == true)
            {
                status = "true";
            }
            else
            {
                status = "false";
            }
            return status;
        }
        private string incomeOverviewStatus()
        {
            string status = "false";
            if (checkIncomeOverview.Checked == true)
            {
                status = "true";
            }
            else
            {
                status = "false";
            }
            return status;
        }
        private string thresholdSetupStatus()
        {
            string status = "false";
            if (checkThresholdSetup.Checked == true)
            {
                status = "true";
            }
            else
            {
                status = "false";
            }
            return status;
        }
        private string transactionApprovalStatus()
        {
            string status = "false";
            if (checkTransactionApproval.Checked == true)
            {
                status = "true";
            }
            else
            {
                status = "false";
            }
            return status;
        }
        private string expenditureStatus()
        {
            string status = "false";
            if (checkExpenditure.Checked == true)
            {
                status = "true";
            }
            else
            {
                status = "false";
            }
            return status;
        }
        private string autoGenerateID()
        {
            string second, minute, hour, day, month, autoID;
            second = DateTime.Now.Second.ToString();
            minute = DateTime.Now.Minute.ToString();
            hour = DateTime.Now.Hour.ToString();
            day = DateTime.Now.Day.ToString();
            month = DateTime.Now.Month.ToString();
            autoID = "DEP" + hour + day + minute + second + month;
            return autoID;
        }
        private void createDepartment()
        {
            try
            {
                departmentName = txtDepartment.Text.ToUpper();
                db.connect();
                db.getDepartment(departmentName);
                db.getConnection.Close();
                DataTable tb = new DataTable();
                db.getDataAdapter.Fill(tb);
                string dbDepartment = tb.Rows[0]["DepartmentName"].ToString();

                if (departmentName.Equals(dbDepartment))
                {
                    sSMessage.Visible = true;
                    tSSMessage.Text = "Sorry! Department already existed!";
                }
            }
            catch (IndexOutOfRangeException idx)
            {
                departmentID = autoGenerateID();
                db.connect();
                db.createDepartment(departmentID, departmentName, custRegStatus(), statementStatus(), freezeStatus(), dashboardStatus(),
                branchSetupStatus(), depositStatus(), withdrawalStatus(), depDateStatus(), withDateStatus(), balanceStatus(), accountSetupStatus(),
                disburseStatus(), balanceLoanStatus(), deleteAccountStatus(), departmentStatus(), employeeStatus(), extendLoanStatus(),
                generateCodeStatus(), delSuspendUserStatus(), editTransStatus(), logoutUserStatus(), callOverStatus(), otherUsersStatus(), reportStatus(),
                groupRegStatus(), workHourStatus(), transReportStatus(), accountReportStatus(), loanPortfolioStatus(), branchTransStatus(),
                performanceStatus(), incomeOverviewStatus(), thresholdSetupStatus(), transactionApprovalStatus(), expenditureStatus());
                db.getConnection.Close();
                DataTable tb2 = new DataTable();
                db.getDataAdapter.Fill(tb2);
                MessageBox.Show("Department created successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                autoGenerateID();
                new Department().Show();
                Dispose();
            }
        }
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
        private void editDepartment()
        {
            try
            {
                departmentName = comboEditDelete.SelectedItem.ToString();
                db.connect();
                db.editDepartment(departmentName);
                db.getConnection.Close();
                DataTable tb = new DataTable();
                db.getDataAdapter.Fill(tb);
                string dbDepartment = tb.Rows[0]["DepartmentName"].ToString();

                customerReg = tb.Rows[0]["CustomerRegistration"].ToString();
                statement = tb.Rows[0]["StatementOfAccount"].ToString();
                freeze = tb.Rows[0]["Freeze"].ToString();
                dashboard = tb.Rows[0]["Dashboard"].ToString();
                branchSetup = tb.Rows[0]["BranchSetup"].ToString();
                deposit = tb.Rows[0]["Deposit"].ToString();
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
                callOver = tb.Rows[0]["CallOver"].ToString();
                otherUsers = tb.Rows[0]["OtherUsers"].ToString();
                reportView = tb.Rows[0]["Report"].ToString();
                groupReg = tb.Rows[0]["GroupCreation"].ToString();
                workHour = tb.Rows[0]["WorkHour"].ToString();
                transReport = tb.Rows[0]["TransactionReport"].ToString();
                accountReport = tb.Rows[0]["AccountReport"].ToString();
                loanPortfolio = tb.Rows[0]["LoanPortfolio"].ToString();
                branchTrans = tb.Rows[0]["BranchTransaction"].ToString();
                performance = tb.Rows[0]["Performance"].ToString();
                incomeOverview = tb.Rows[0]["IncomeOverview"].ToString();
                thresholdSetup = tb.Rows[0]["ThresholdSetup"].ToString();
                transactionApproval = tb.Rows[0]["TransactionApproval"].ToString();
                expenditure = tb.Rows[0]["Expenditure"].ToString();
                if (departmentName.Equals(dbDepartment))
                {
                    panRoles.Visible = true;
                    txtDepartment.Text = dbDepartment;//Here...
                    checkCustReg.Checked = convert(customerReg);
                    checkStatement.Checked = convert(statement);
                    checkFreeze.Checked = convert(freeze);
                    checkDashboard.Checked = convert(dashboard);
                    checkBranchSetup.Checked = convert(branchSetup);
                    checkDeposit.Checked = convert(deposit);
                    checkWithdrawal.Checked = convert(withdrawal);
                    checkDepDate.Checked = convert(depDate);
                    checkWithDate.Checked = convert(withDate);
                    checkBalance.Checked = convert(balance);
                    checkAccountSetup.Checked = convert(accountSetup);
                    checkDisburse.Checked = convert(disburse);
                    checkBalanceLoan.Checked = convert(balanceLoan);
                    checkDeleteAccount.Checked = convert(deleteAccount);
                    checkDepartment.Checked = convert(department);
                    checkEmployee.Checked = convert(employee);
                    checkExtendLoan.Checked = convert(extendLoan);
                    checkGenerateCode.Checked = convert(generateCode);
                    checkDelSuspendUser.Checked = convert(delSuspendUser);
                    checkEditTrans.Checked = convert(editTrans);
                    checkLogoutUser.Checked = convert(logoutUser);
                    checkCallOver.Checked = convert(callOver);
                    checkOtherUsers.Checked = convert(otherUsers);
                    checkReport.Checked = convert(reportView);
                    checkGroupReg.Checked = convert(groupReg);
                    checkWorkHour.Checked = convert(workHour);
                    checkTransReport.Checked = convert(transReport);
                    checkAccountReport.Checked = convert(accountReport);
                    checkLoanPortfolio.Checked = convert(loanPortfolio);
                    checkBranchTrans.Checked = convert(branchTrans);
                    checkPerformance.Checked = convert(performance);
                    checkIncomeOverview.Checked = convert(incomeOverview);
                    checkThresholdSetup.Checked = convert(thresholdSetup);
                    checkTransactionApproval.Checked = convert(transactionApproval);
                    checkExpenditure.Checked = convert(expenditure);
                }
            }
            catch (IndexOutOfRangeException idx)
            {
                panRoles.Visible = false;
                sSMessage.Visible = true;
                tSSMessage.Text = "Sorry! Department does not exist!";
            }
        }
        private void updateDepartment()
        {
            db.connect();
            db.updateDepartment(departmentName, custRegStatus(), statementStatus(), freezeStatus(), dashboardStatus(),
                branchSetupStatus(), depositStatus(), withdrawalStatus(), depDateStatus(), withDateStatus(), balanceStatus(), accountSetupStatus(),
                disburseStatus(), balanceLoanStatus(), deleteAccountStatus(), departmentStatus(), employeeStatus(), extendLoanStatus(),
                generateCodeStatus(), delSuspendUserStatus(), editTransStatus(), logoutUserStatus(), callOverStatus(), otherUsersStatus(), reportStatus(),
                groupRegStatus(), workHourStatus(), transReportStatus(), accountReportStatus(), loanPortfolioStatus(), branchTransStatus(),
                performanceStatus(), incomeOverviewStatus(), thresholdSetupStatus(), transactionApprovalStatus(), expenditureStatus());
            db.getConnection.Close();
            DataTable tb2 = new DataTable();
            db.getDataAdapter.Fill(tb2);
            MessageBox.Show("Department updated successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void deleteDepartment()
        {
            if (MessageBox.Show("Are you sure you want to delete the department?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string departmentName = comboEditDelete.SelectedItem.ToString();
                db.connect();
                db.deleteDepartment(departmentName);
                db.getConnection.Close();
                DataTable tb = new DataTable();
                db.getDataAdapter.Fill(tb);
                MessageBox.Show("Department deleted successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                new Department().Show();
                Dispose();
            }
        }
        private void btnCreate_Click(object sender, EventArgs e)//Edited...
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
                        if (validateDepartment() == 0)
                        {
                            if (radCreate.Checked == true && btnCreate.Text.Equals("Create"))
                            {
                                createDepartment();
                                if (checkThreshold.Checked == true)
                                {
                                    db = new DatabaseLib();
                                    db.connect();
                                    db.setupThreshold(departmentID, 0, 0, 0, 0);
                                    db.getConnection.Close();
                                    DataTable tb = new DataTable();
                                    db.getDataAdapter.Fill(tb);
                                }
                            }
                            else if (radEdit.Checked == true && btnCreate.Text.Equals("Update"))
                            {
                                updateDepartment();
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
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtDepartment.Text = "";
            sSMessage.Visible = false;
            errorProvider.Clear();
            checkSelectAll.Checked = false;
        }
        private void getDepartment()//New implementation
        {
            db.connect();
            db.getDepartment();
            db.getConnection.Close();
            DataTable tb = new DataTable();
            db.getDataAdapter.Fill(tb);
            foreach (DataRow dr in tb.Rows)
            {
                comboEditDelete.Items.Add(dr["DepartmentName"].ToString());
            }
        }
        private void radEdit_CheckedChanged(object sender, EventArgs e)//New implementation...
        {
            comboEditDelete.Visible = true;
            panRoles.Visible = false;
            panCreate.Visible = false;
            if (radEdit.Checked == false)
            {
                comboEditDelete.Visible = false;
            }
        }
        private void radDelete_CheckedChanged(object sender, EventArgs e)//New implementation...
        {
            comboEditDelete.Visible = true;
            panRoles.Visible = false;
            panCreate.Visible = false;
            if (radDelete.Checked == false)
            {
                comboEditDelete.Visible = false;
                panRoles.Visible = true;
                panCreate.Visible = true;
            }
        }
        private void radCreate_CheckedChanged(object sender, EventArgs e)//New implementation...
        {
            panCreate.Visible = true;
            panRoles.Visible = true;
            btnCreate.Text = "Create";
            txtDepartment.Enabled = true;
            checkThreshold.Visible = true;
            if (radCreate.Checked == false)
            {
                comboEditDelete.Visible = true;
                panRoles.Visible = false;
                panCreate.Visible = false;
                txtDepartment.Enabled = false;
                checkThreshold.Visible = false;
            }
        }
        private void comboEditDelete_SelectedIndexChanged(object sender, EventArgs e)//New implementation...
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
                        string departmentName = comboEditDelete.SelectedItem.ToString();
                        if (radDelete.Checked == true)
                        {
                            db.connect();
                            db.countEmployee(departmentName);
                            db.getConnection.Close();
                            DataTable tb = new DataTable();
                            db.getDataAdapter.Fill(tb);
                            int noOfEmployee = (int)tb.Rows[0]["CountEmployee"];
                            if (noOfEmployee > 0)
                            {
                                if (noOfEmployee == 1)
                                {
                                    MessageBox.Show(noOfEmployee + " employee belongs to this department\nPlease transfer the employee to a new department before deleting", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show(noOfEmployee + " employees belong to this department\nPlease transfer the employees to a new department before deleting", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                            {
                                if (departmentName.Equals("ADMIN"))
                                {
                                    MessageBox.Show("Sorry, you can't delete the " + departmentName + " department", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    deleteDepartment();
                                }
                            }
                        }
                        else if (radEdit.Checked == true)
                        {
                            if (departmentName.Equals("ADMIN"))
                            {
                                MessageBox.Show("Sorry, you can't edit the " + departmentName + " department", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                panCreate.Visible = false;
                                txtDepartment.Enabled = false;
                                panRoles.Visible = false;
                            }
                            else
                            {
                                editDepartment();
                                btnCreate.Text = "Update";
                                panCreate.Visible = true;
                                txtDepartment.Enabled = false;
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
