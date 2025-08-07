using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DatabaseLibrary
{
    public class DatabaseLib
    {
        private SqlConnection con;
        private SqlDataAdapter adapter;
        private SqlCommandBuilder cmdBuilder;
        private SqlCommand cmd;

        private string url, query;
        public SqlConnection getConnection => con;

        public SqlDataAdapter getDataAdapter => adapter;
        public void connect()
        {
            try
            {
                //url = ConfigurationManager.ConnectionStrings["Server1"].ConnectionString;
                //url = ConfigurationManager.ConnectionStrings["Server2"].ConnectionString;
                url = ConfigurationManager.ConnectionStrings["Softlight"].ConnectionString;
                con = new SqlConnection(url);
                con.Open();
            }
            catch (ArgumentException e)
            {

            }
        }
        //Demo testing
        public void cloudDemo(string appName, float price)
        {
            query = "insert Demo values('" + appName + "', '" + price + "')";
            adapter = new SqlDataAdapter(query, con);
            cmdBuilder = new SqlCommandBuilder(adapter);
        }
        public void alertStatus()
        {
            cmd = new SqlCommand("AlertStatusSP", con);
            cmd.CommandType = CommandType.StoredProcedure;
            adapter = new SqlDataAdapter(cmd);
        }
        public void alertCustomer()
        {
            cmd = new SqlCommand("AlertCustomerSP", con);
            cmd.CommandType = CommandType.StoredProcedure;
            adapter = new SqlDataAdapter(cmd);
        }
        public void manualAlert(long accNo)
        {
            query = "select c.Accountnumber, c.PhoneNumber, b.Balance from Customer c " +
            "join BalanceUpdate b on c.AccountNumber = b.AccountNumber where c.AccountNumber = '" + accNo + "'";
            adapter = new SqlDataAdapter(query, con);
        }
        public void getAlert(long accNo)
        {
            cmd = new SqlCommand("getAlertSP", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@accNo", accNo);
            adapter = new SqlDataAdapter(cmd);
        }
        public void updateAlert(long accNo, string date)
        {
            cmd = new SqlCommand("updateAlertSP", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@accNo", accNo);
            cmd.Parameters.AddWithValue("@date", date);
            adapter = new SqlDataAdapter(cmd);
            cmdBuilder = new SqlCommandBuilder(adapter);
        }
        public void insertAlert(long accNo, string date)
        {
            cmd = new SqlCommand("insertAlertSP", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@accNo", accNo);
            cmd.Parameters.AddWithValue("@date", date);
            adapter = new SqlDataAdapter(cmd);
            cmdBuilder = new SqlCommandBuilder(adapter);
        }
        public void getLogQuery(string user, string pass)
        {
            cmd = new SqlCommand("getLogQuerySP", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@User", user);
            cmd.Parameters.AddWithValue("@Pass", pass);
            adapter = new SqlDataAdapter(cmd);
        }
        public void getSub(int clientID)
        {
            // Bypass subscription check for cloud deployment
            adapter = new SqlDataAdapter("SELECT 'Active' as Status, 'Active' as MaintenanceStatus", con);
            
            /* Original code - commented out for cloud deployment
            adapter = new SqlDataAdapter("getSubSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@clientID", clientID);
            */
        }
        public void getSubMaintenance(int clientID)
        {
            // Bypass maintenance check for cloud deployment
            adapter = new SqlDataAdapter("SELECT 15 as SubDate, 15 as MainDate", con);
            
            /* Original code - commented out for cloud deployment
            adapter = new SqlDataAdapter("getSubMaintenanceSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@clientID", clientID);
            */
        }
        public void dbDate()
        {
            cmd = new SqlCommand("dbDateSP", con);
            cmd.CommandType = CommandType.StoredProcedure;
            adapter = new SqlDataAdapter(cmd);
        }
        //Password details
        public void forgotPassword(string empID)
        {
            cmd = new SqlCommand("forgotPasswordSP", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@empID", empID);
            adapter = new SqlDataAdapter(cmd);
        }
        public void passChange(string user)
        {
            cmd = new SqlCommand("passChangeSP", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@user", user);
            adapter = new SqlDataAdapter(cmd);
        }
        public void updatePass(string employeeID, string pass, string username)
        {
            cmd = new SqlCommand("updatePassSP", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@employeeID", employeeID);
            cmd.Parameters.AddWithValue("@pass", pass);
            cmd.Parameters.AddWithValue("@username", username);
            adapter = new SqlDataAdapter(cmd);
            cmdBuilder = new SqlCommandBuilder(adapter);
        }
        public void confirmCode(string empCode)
        {
            cmd = new SqlCommand("confirmCodeSP", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@empCode", empCode);
            adapter = new SqlDataAdapter(cmd);
        }
        public void freeze(long accountNo)
        {
            cmd = new SqlCommand("freezeSP", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@accNo", accountNo);
            adapter = new SqlDataAdapter(cmd);
        }
        public void insertFreeze(long accountNo, string description)
        {
            cmd = new SqlCommand("insertFreezeSP", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@accNo", accountNo);
            cmd.Parameters.AddWithValue("@Description", description);
            adapter = new SqlDataAdapter(cmd);
            cmdBuilder = new SqlCommandBuilder(adapter);
        }
        public void unFreeze(long accountNo)
        {
            cmd = new SqlCommand("unFreezeSP", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@accNo", accountNo);
            adapter = new SqlDataAdapter(cmd);
            cmdBuilder = new SqlCommandBuilder(adapter);
        }
        public void updateFreeze(long accNo, string description)
        {
            cmd = new SqlCommand("updateFreezeSP", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@accNo", accNo);
            cmd.Parameters.AddWithValue("@Description", description);
            adapter = new SqlDataAdapter(cmd);
            cmdBuilder = new SqlCommandBuilder(adapter);
        }
        public void balanceUpdate(long accountNo)
        {
            cmd = new SqlCommand("balanceUpdateSP", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@accNo", accountNo);
            adapter = new SqlDataAdapter(cmd);
        }
        public void getBalance(long accountNo)
        {
            cmd = new SqlCommand("getBalanceSP", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@accNo", accountNo);
            adapter = new SqlDataAdapter(cmd);
        }
        public void loanBalance(long accountNo)
        {
            cmd = new SqlCommand("loanBalanceSP", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@accNo", accountNo);
            adapter = new SqlDataAdapter(cmd);
        }
        public void convertMaturityDate(long accountNo)
        {
            cmd = new SqlCommand("convertMaturityDateSP", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@accNo", accountNo);
            adapter = new SqlDataAdapter(cmd);
        }
        public void getExtendLoan(long accountNo)
        {
            cmd = new SqlCommand("getExtendLoanSP", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@accNo", accountNo);
            adapter = new SqlDataAdapter(cmd);
        }
        public void pfVat(long accountNo)
        {
            cmd = new SqlCommand("pfVatSP", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@accNo", accountNo);
            adapter = new SqlDataAdapter(cmd);
        }
        public void custDetails(long accountNo)
        {
            cmd = new SqlCommand("custDetailsSP", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@accNo", accountNo);
            adapter = new SqlDataAdapter(cmd);
        }
        public void getCustDetails(long accountNo)
        {
            cmd = new SqlCommand("getCustDetailsSP", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@accNo", accountNo);
            adapter = new SqlDataAdapter(cmd);
        }
        public void getSpecificTransactionLog(long accountNo, string dateFrom, string dateTo)
        {
            cmd = new SqlCommand("getSpecificTransactionLogSP", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@accNo", accountNo);
            cmd.Parameters.AddWithValue("@dateFrom", dateFrom);
            cmd.Parameters.AddWithValue("@dateTo", dateTo);
            adapter = new SqlDataAdapter(cmd);
        }
        public void getSpecificCustomerStatement(long accountNo, string dateFrom, string dateTo)
        {
            cmd = new SqlCommand("getSpecificCustomerStatementSP", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@accNo", accountNo);
            cmd.Parameters.AddWithValue("@dateFrom", dateFrom);
            cmd.Parameters.AddWithValue("@dateTo", dateTo);
            adapter = new SqlDataAdapter(cmd);
        }
        public void getAllTransactionLog(long accountNo)
        {
            cmd = new SqlCommand("getAllTransactionLogSP", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@accNo", accountNo);
            adapter = new SqlDataAdapter(cmd);
        }
        public void getAllCustomerStatement(long accountNo)
        {
            cmd = new SqlCommand("getAllCustomerStatementSP", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@accNo", accountNo);
            adapter = new SqlDataAdapter(cmd);
        }
        public void editTransaction(long accountNo, string date, long amt)
        {
            cmd = new SqlCommand("editTransactionSP", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@accNo", accountNo);
            cmd.Parameters.AddWithValue("@date", date);
            cmd.Parameters.AddWithValue("@amount", amt);
            adapter = new SqlDataAdapter(cmd);
            cmdBuilder = new SqlCommandBuilder(adapter);
        }
        public void editCustSelection(long accountNo)
        {
            cmd = new SqlCommand("editCustSelectionSP", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@accNo", accountNo);
            adapter = new SqlDataAdapter(cmd);
        }
        public void editCustomer(string fName, string mName, string lName, string address,
            string phone, string gender, long accountNo, string accountType, string accountOfficer, string groupName)
        {
            cmd = new SqlCommand("editCustomerSP", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@fName", fName);
            cmd.Parameters.AddWithValue("@mName", mName);
            cmd.Parameters.AddWithValue("@lName", lName);
            cmd.Parameters.AddWithValue("@address", address);
            cmd.Parameters.AddWithValue("@phone", phone);
            cmd.Parameters.AddWithValue("@gender", gender);
            cmd.Parameters.AddWithValue("@accNo", accountNo);
            cmd.Parameters.AddWithValue("@accountType", accountType);
            cmd.Parameters.AddWithValue("@accountOfficer", accountOfficer);
            cmd.Parameters.AddWithValue("@groupName", groupName);
            adapter = new SqlDataAdapter(cmd);
            cmdBuilder = new SqlCommandBuilder(adapter);
        }
        //Get default customers
        public void getNotification()
        {
            adapter = new SqlDataAdapter("getNotificationSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        }
        //Disburse Loan
        public void transactionLog(string date, string time, string transactionType, long amt,
            int charges, long accountNo, long recipientAccNo, string accOfficer, string cashier,
            string hostName, string description)
        {
            cmd = new SqlCommand("transactionLogSP", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@date", date);
            cmd.Parameters.AddWithValue("@time", time);
            cmd.Parameters.AddWithValue("@transactionType", transactionType);
            cmd.Parameters.AddWithValue("@amt", amt);
            cmd.Parameters.AddWithValue("@charges", charges);
            cmd.Parameters.AddWithValue("@accNo", accountNo);
            cmd.Parameters.AddWithValue("@recipientAccNo", recipientAccNo);
            cmd.Parameters.AddWithValue("@accountOfficer", accOfficer);
            cmd.Parameters.AddWithValue("@cashier", cashier);
            cmd.Parameters.AddWithValue("@hostName", hostName);
            cmd.Parameters.AddWithValue("@description", description);
            adapter = new SqlDataAdapter(cmd);
            cmdBuilder = new SqlCommandBuilder(adapter);
        }
        public void disburseLoan(long accountNo, int duration, long totAmt,
            string termOfPay, string disDate, string matDate, string time, string loanStatus, long amt, long principal, string accountOfficer)
        {
            cmd = new SqlCommand("disburseLoanSP", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@accNo", accountNo);
            cmd.Parameters.AddWithValue("@duration", duration);
            cmd.Parameters.AddWithValue("@totAmtamt", totAmt);
            cmd.Parameters.AddWithValue("@termOfPay", termOfPay);
            cmd.Parameters.AddWithValue("@disDate", disDate);
            cmd.Parameters.AddWithValue("@matDate", matDate);
            cmd.Parameters.AddWithValue("@time", time);
            cmd.Parameters.AddWithValue("@loanStatus", loanStatus);
            cmd.Parameters.AddWithValue("@amt", amt);
            cmd.Parameters.AddWithValue("@principal", principal);
            cmd.Parameters.AddWithValue("@accountOfficer", accountOfficer);
            adapter = new SqlDataAdapter(cmd);
            cmdBuilder = new SqlCommandBuilder(adapter);
        }
        public void loanChecker(long accountNo)
        {
            cmd = new SqlCommand("loanCheckerSP", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@accNo", accountNo);
            adapter = new SqlDataAdapter(cmd);
        }
        public void balanceLoan(long accountNo, int waiverMonth)
        {
            cmd = new SqlCommand("balanceLoanSP", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@accNo", accountNo);
            cmd.Parameters.AddWithValue("@waiverMonth", waiverMonth);
            adapter = new SqlDataAdapter(cmd);
        }
        public void dateDiff(long accountNo)
        {
            cmd = new SqlCommand("dateDiffSP", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@accNo", accountNo);
            adapter = new SqlDataAdapter(cmd);
        }
        public void dateDay(long accountNo)
        {
            query = " ='" + accountNo + "'";
            adapter = new SqlDataAdapter(query, con);
        }
        //Guarantor Details
        public void guarantorDetails(long accountNo, string fName, string mName, string lName, string address,
            string phone, string gender)
        {
            cmd = new SqlCommand("guarantorDetailsSP", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@accNo", accountNo);
            cmd.Parameters.AddWithValue("@fName", fName);
            cmd.Parameters.AddWithValue("@mName", mName);
            cmd.Parameters.AddWithValue("@lName", lName);
            cmd.Parameters.AddWithValue("@address", address);
            cmd.Parameters.AddWithValue("@phone", phone);
            cmd.Parameters.AddWithValue("@gender", gender);
            adapter = new SqlDataAdapter(cmd);
            cmdBuilder = new SqlCommandBuilder(adapter);
        }
        public void exist(long accountNo)
        {
            cmd = new SqlCommand("existSP", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@accNo", accountNo);
            adapter = new SqlDataAdapter(cmd);
        }
        public void guarantorExist(long accountNo)
        {
            cmd = new SqlCommand("guarantorExistSP", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@accNo", accountNo);
            adapter = new SqlDataAdapter(cmd);
        }
        //Update for applicant and guarantor
        public void updateDisburseLoan(long accNo, int duration, long totAmt,
            string termOfPay, string disDate, string matDate, string time, string loanStatus, long amt, long principal, string accountOfficer)
        {
            cmd = new SqlCommand("updateDisburseLoanSP", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@accNo", accNo);
            cmd.Parameters.AddWithValue("@duration", duration);
            cmd.Parameters.AddWithValue("@totAmtamt", totAmt);
            cmd.Parameters.AddWithValue("@termOfPay", termOfPay);
            cmd.Parameters.AddWithValue("@disDate", disDate);
            cmd.Parameters.AddWithValue("@matDate", matDate);
            cmd.Parameters.AddWithValue("@time", time);
            cmd.Parameters.AddWithValue("@loanStatus", loanStatus);
            cmd.Parameters.AddWithValue("@amt", amt);
            cmd.Parameters.AddWithValue("@principal", principal);
            cmd.Parameters.AddWithValue("@accountOfficer", accountOfficer);
            adapter = new SqlDataAdapter(cmd);
            cmdBuilder = new SqlCommandBuilder(adapter);
        }

        //inserting extended loan
        public void extendLoan(long accNo, DateTime extendDate, float outstandingAmt)
        {
            cmd = new SqlCommand("extendLoanSP", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@accNo", accNo);
            cmd.Parameters.AddWithValue("@extendDate", extendDate);
            cmd.Parameters.AddWithValue("@outstandingAmt", outstandingAmt);
            adapter = new SqlDataAdapter(cmd);
            cmdBuilder = new SqlCommandBuilder(adapter);
        }
        //Updating the loan customer for extension
        public void updateExtendLoan(long accNo, DateTime extendDate, float outstandingAmt)
        {
            cmd = new SqlCommand("updateExtendLoanSP", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@accNo", accNo);
            cmd.Parameters.AddWithValue("@extendDate", extendDate);
            cmd.Parameters.AddWithValue("@outstandingAmt", outstandingAmt);
            adapter = new SqlDataAdapter(cmd);
            cmdBuilder = new SqlCommandBuilder(adapter);
        }
        public void updateGuarantor(long accountNo, string fName, string mName, string lName, string address,
            string phone, string gender)
        {
            cmd = new SqlCommand("updateGuarantorSP", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@accNo", accountNo);
            cmd.Parameters.AddWithValue("@fName", fName);
            cmd.Parameters.AddWithValue("@mName", mName);
            cmd.Parameters.AddWithValue("@lName", lName);
            cmd.Parameters.AddWithValue("@address", address);
            cmd.Parameters.AddWithValue("@phone", phone);
            cmd.Parameters.AddWithValue("@gender", gender);
            adapter = new SqlDataAdapter(cmd);
            cmdBuilder = new SqlCommandBuilder(adapter);
        }
        public void delete(long accountNo)
        {
            cmd = new SqlCommand("deleteSP", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@accNo", accountNo);
            adapter = new SqlDataAdapter(cmd);
            cmdBuilder = new SqlCommandBuilder(adapter);
        }
        public void getCodeGenerator(string code)
        {
            cmd = new SqlCommand("getCodeGeneratorSP", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@code", code);
            adapter = new SqlDataAdapter(cmd);
        }
        //Code Generator
        public void codeGenerator(string code)
        {
            cmd = new SqlCommand("codeGeneratorSP", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@code", code);
            adapter = new SqlDataAdapter(cmd);
            cmdBuilder = new SqlCommandBuilder(adapter);
        }
        //Customer Registration
        public void customerReg(string fName, string mName, string lName, string address, string phone,
            string gender, long accountNo, string accountType, string accOfficer, string date, string groupName)
        {
            cmd = new SqlCommand("customerRegSP", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@fName", fName);
            cmd.Parameters.AddWithValue("@mName", mName);
            cmd.Parameters.AddWithValue("@lName", lName);
            cmd.Parameters.AddWithValue("@address", address);
            cmd.Parameters.AddWithValue("@phone", phone);
            cmd.Parameters.AddWithValue("@gender", gender);
            cmd.Parameters.AddWithValue("@accNo", accountNo);
            cmd.Parameters.AddWithValue("@accountType", accountType);
            cmd.Parameters.AddWithValue("@accountOfficer", accOfficer);
            cmd.Parameters.AddWithValue("@date", date);
            cmd.Parameters.AddWithValue("@groupName", groupName);
            adapter = new SqlDataAdapter(cmd);
            cmdBuilder = new SqlCommandBuilder(adapter);
        }
        public void getDepartment()
        {
            cmd = new SqlCommand("getDepartmentSP", con);
            cmd.CommandType = CommandType.StoredProcedure;
            adapter = new SqlDataAdapter(cmd);
        }
        public void getDepartmentRole(string departmentID)
        {
            cmd = new SqlCommand("getDepartmentRoleSP", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@departmentID", departmentID);
            adapter = new SqlDataAdapter(cmd);
        }
        public void getDepartmentName(string departmentID)
        {
            cmd = new SqlCommand("getDepartmentNameSP", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@departmentID", departmentID);
            adapter = new SqlDataAdapter(cmd);
        }
        public void getDepartment(string departmentName)
        {
            cmd = new SqlCommand("DepartmentSP", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@departmentName", departmentName);
            adapter = new SqlDataAdapter(cmd);
        }
        public void createDepartment(string departmentID, string departmentName, string custReg, string statement, string freeze, string dashboard,
            string branchSetup, string deposit, string withdrawal, string depDate, string withDate, string balance, string accountSetup, string disburse,
            string balanceLoan, string deleteAccount, string department, string employee, string extendLoan, string generateCode, string delSuspendUser,
            string editTrans, string logoutUser, string callOver, string otherUsers, string report, string group, string workHour, string transReport,
            string accountReport, string loanPortfolio, string branchTransaction, string performance, string incomeOverview, string thresholdSetup,
            string transactionApproval, string expenditure)
        {
            cmd = new SqlCommand("createDepartmentSP", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@departmentID", departmentID);
            cmd.Parameters.AddWithValue("@departmentName", departmentName);
            cmd.Parameters.AddWithValue("@custReg", custReg);
            cmd.Parameters.AddWithValue("@statement", statement);
            cmd.Parameters.AddWithValue("@freeze", freeze);
            cmd.Parameters.AddWithValue("@dashboard", dashboard);
            cmd.Parameters.AddWithValue("@branchSetup", branchSetup);
            cmd.Parameters.AddWithValue("@deposit", deposit);
            cmd.Parameters.AddWithValue("@withdrawal", withdrawal);
            cmd.Parameters.AddWithValue("@depDate", depDate);
            cmd.Parameters.AddWithValue("@withDate", withDate);
            cmd.Parameters.AddWithValue("@balance", balance);
            cmd.Parameters.AddWithValue("@accountSetup", accountSetup);
            cmd.Parameters.AddWithValue("@disburse", disburse);
            cmd.Parameters.AddWithValue("@balanceLoan", balanceLoan);
            cmd.Parameters.AddWithValue("@deleteAccount", deleteAccount);
            cmd.Parameters.AddWithValue("@department", department);
            cmd.Parameters.AddWithValue("@employee", employee);
            cmd.Parameters.AddWithValue("@extendLoan", extendLoan);
            cmd.Parameters.AddWithValue("@generateCode", generateCode);
            cmd.Parameters.AddWithValue("@delSuspendUser", delSuspendUser);
            cmd.Parameters.AddWithValue("@editTrans", editTrans);
            cmd.Parameters.AddWithValue("@logoutUser", logoutUser);
            cmd.Parameters.AddWithValue("@callOver", callOver);
            cmd.Parameters.AddWithValue("@otherUsers", otherUsers);
            cmd.Parameters.AddWithValue("@report", report);
            cmd.Parameters.AddWithValue("@group", group);
            cmd.Parameters.AddWithValue("@workHour", workHour);
            cmd.Parameters.AddWithValue("@transReport", transReport);
            cmd.Parameters.AddWithValue("@accountReport", accountReport);
            cmd.Parameters.AddWithValue("@loanPortfolio", loanPortfolio);
            cmd.Parameters.AddWithValue("@branchTransaction", branchTransaction);
            cmd.Parameters.AddWithValue("@performance", performance);
            cmd.Parameters.AddWithValue("@incomeOverview", incomeOverview);
            cmd.Parameters.AddWithValue("@thresholdSetup", thresholdSetup);
            cmd.Parameters.AddWithValue("@transactionApproval", transactionApproval);
            cmd.Parameters.AddWithValue("@expenditure", expenditure);
            adapter = new SqlDataAdapter(cmd);
            cmdBuilder = new SqlCommandBuilder(adapter);
        }
        //New implementation...
        public void editDepartment(string departmentName)
        {
            adapter = new SqlDataAdapter("editDepartmentSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@departmentName", departmentName);
        }
        public void countEmployee(string departmentName)
        {
            adapter = new SqlDataAdapter("countEmployeeSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@departmentName", departmentName);
        }
        public void deleteDepartment(string departmentName)
        {
            adapter = new SqlDataAdapter("deleteDepartmentSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@departmentName", departmentName);
            cmdBuilder = new SqlCommandBuilder(adapter);
        }
        public void updateDepartment(string departmentName, string custReg, string statement, string freeze, string dashboard,
            string branchSetup, string deposit, string withdrawal, string depDate, string withDate, string balance, string accountSetup, string disburse,
            string balanceLoan, string deleteAccount, string department, string employee, string extendLoan, string generateCode, string delSuspendUser,
            string editTrans, string logoutUser, string callOver, string otherUsers, string report, string group, string workHour, string transReport,
            string accountReport, string loanPortfolio, string branchTransaction, string performance, string incomeOverview, string thresholdSetup,
            string transactionApproval, string expenditure)
        {
            cmd = new SqlCommand("updateDepartmentSP", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@departmentName", departmentName);
            cmd.Parameters.AddWithValue("@custReg", custReg);
            cmd.Parameters.AddWithValue("@statement", statement);
            cmd.Parameters.AddWithValue("@freeze", freeze);
            cmd.Parameters.AddWithValue("@dashboard", dashboard);
            cmd.Parameters.AddWithValue("@branchSetup", branchSetup);
            cmd.Parameters.AddWithValue("@deposit", deposit);
            cmd.Parameters.AddWithValue("@withdrawal", withdrawal);
            cmd.Parameters.AddWithValue("@depDate", depDate);
            cmd.Parameters.AddWithValue("@withDate", withDate);
            cmd.Parameters.AddWithValue("@balance", balance);
            cmd.Parameters.AddWithValue("@accountSetup", accountSetup);
            cmd.Parameters.AddWithValue("@disburse", disburse);
            cmd.Parameters.AddWithValue("@balanceLoan", balanceLoan);
            cmd.Parameters.AddWithValue("@deleteAccount", deleteAccount);
            cmd.Parameters.AddWithValue("@department", department);
            cmd.Parameters.AddWithValue("@employee", employee);
            cmd.Parameters.AddWithValue("@extendLoan", extendLoan);
            cmd.Parameters.AddWithValue("@generateCode", generateCode);
            cmd.Parameters.AddWithValue("@delSuspendUser", delSuspendUser);
            cmd.Parameters.AddWithValue("@editTrans", editTrans);
            cmd.Parameters.AddWithValue("@logoutUser", logoutUser);
            cmd.Parameters.AddWithValue("@callOver", callOver);
            cmd.Parameters.AddWithValue("@otherUsers", otherUsers);
            cmd.Parameters.AddWithValue("@report", report);
            cmd.Parameters.AddWithValue("@group", group);
            cmd.Parameters.AddWithValue("@workHour", workHour);
            cmd.Parameters.AddWithValue("@transReport", transReport);
            cmd.Parameters.AddWithValue("@accountReport", accountReport);
            cmd.Parameters.AddWithValue("@loanPortfolio", loanPortfolio);
            cmd.Parameters.AddWithValue("@branchTransaction", branchTransaction);
            cmd.Parameters.AddWithValue("@performance", performance);
            cmd.Parameters.AddWithValue("@incomeOverview", incomeOverview);
            cmd.Parameters.AddWithValue("@thresholdSetup", thresholdSetup);
            cmd.Parameters.AddWithValue("@transactionApproval", transactionApproval);
            cmd.Parameters.AddWithValue("@expenditure", expenditure);
            adapter = new SqlDataAdapter(cmd);
            cmdBuilder = new SqlCommandBuilder(adapter);
        }
        //Employee Details
        public void getAccountOfficer(string accountOfficer)
        {
            adapter = new SqlDataAdapter("getAccountOfficerSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@accountOfficer", accountOfficer);
        }
        public void getAccountOfficerName(string departmentName, string accountOfficer)
        {
            adapter = new SqlDataAdapter("getAccountOfficerNameSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@departmentName", departmentName);
            adapter.SelectCommand.Parameters.AddWithValue("@accountOfficer", accountOfficer);
        }
        public void getEmployeeDetails(string employeeID)
        {
            adapter = new SqlDataAdapter("getEmployeeDetailsSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@employeeID", employeeID);
        }
        public void updateEmployeeDetails(string employeeID, string departmentID, string firstName,
            string middleName, string lastName, string address, string phone, string gender, int branchCode)
        {
            adapter = new SqlDataAdapter("updateEmployeeDetailsSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@employeeID", employeeID);
            adapter.SelectCommand.Parameters.AddWithValue("@departmentID", departmentID);
            adapter.SelectCommand.Parameters.AddWithValue("@firstName", firstName);
            adapter.SelectCommand.Parameters.AddWithValue("@middleName", middleName);
            adapter.SelectCommand.Parameters.AddWithValue("@lastName", lastName);
            adapter.SelectCommand.Parameters.AddWithValue("@address", address);
            adapter.SelectCommand.Parameters.AddWithValue("@phone", phone);
            adapter.SelectCommand.Parameters.AddWithValue("@gender", gender);
            adapter.SelectCommand.Parameters.AddWithValue("@branchCode", branchCode);
            cmdBuilder = new SqlCommandBuilder(adapter);
        }
        public void deleteEmployee(string employeeID)
        {
            adapter = new SqlDataAdapter("deleteEmployeeSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@employeeID", employeeID);
            cmdBuilder = new SqlCommandBuilder(adapter);
        }
        public void updateEmployee(string empCode, string employeeID)
        {
            adapter = new SqlDataAdapter("updateEmployeeSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@empCode", empCode);
            adapter.SelectCommand.Parameters.AddWithValue("@employeeID", employeeID);
            cmdBuilder = new SqlCommandBuilder(adapter);
        }
        public void empDetails(string employeeID, string departmentID, string firstName,
            string middleName, string lastName, string address, string phone, string 
            gender, string empCode, int branchCode)
        {
            adapter = new SqlDataAdapter("empDetailsSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@employeeID", employeeID);
            adapter.SelectCommand.Parameters.AddWithValue("@departmentID", departmentID);
            adapter.SelectCommand.Parameters.AddWithValue("@firstName", firstName);
            adapter.SelectCommand.Parameters.AddWithValue("@middleName", middleName);
            adapter.SelectCommand.Parameters.AddWithValue("@lastName", lastName);
            adapter.SelectCommand.Parameters.AddWithValue("@address", address);
            adapter.SelectCommand.Parameters.AddWithValue("@phone", phone);
            adapter.SelectCommand.Parameters.AddWithValue("@gender", gender);
            adapter.SelectCommand.Parameters.AddWithValue("@empCode", empCode);
            adapter.SelectCommand.Parameters.AddWithValue("@branchCode", branchCode);
            cmdBuilder = new SqlCommandBuilder(adapter);
        }
        public void insertEmpPhoto(string empID, byte[] img)
        {
            adapter = new SqlDataAdapter("insertEmpPhotoSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@empID", empID);
            adapter.SelectCommand.Parameters.AddWithValue("@img", img);
            cmdBuilder = new SqlCommandBuilder(adapter);
        }
        public void updateEmpPhoto(string empID, byte[] img)
        {
            adapter = new SqlDataAdapter("updateEmpPhotoSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@empID", empID);
            adapter.SelectCommand.Parameters.AddWithValue("@img", img);
            cmdBuilder = new SqlCommandBuilder(adapter);
        }
        public void getEmpPhoto(string empID)
        {
            adapter = new SqlDataAdapter("getEmpPhotoSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@empID", empID);
        }
        public void getEmpIDPhoto(string empName)
        {
            adapter = new SqlDataAdapter("getEmpIDPhotoSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@empName", empName);
        }
        public void getEmpName()
        {
            adapter = new SqlDataAdapter("getEmpNameSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        }
        public void userLogin(string empID, string user, string pass, string suspend)
        {
            adapter = new SqlDataAdapter("userLoginSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@empID", empID);
            adapter.SelectCommand.Parameters.AddWithValue("@user", user);
            adapter.SelectCommand.Parameters.AddWithValue("@pass", pass);
            adapter.SelectCommand.Parameters.AddWithValue("@suspend", suspend);
            cmdBuilder = new SqlCommandBuilder(adapter);
        }
        public void deleteUser(string empID)
        {
            adapter = new SqlDataAdapter("deleteUserSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@empID", empID);
            cmdBuilder = new SqlCommandBuilder(adapter);
        }
        public void suspendAccount(string empID, string suspend)
        {
            adapter = new SqlDataAdapter("suspendAccountSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@empID", empID);
            adapter.SelectCommand.Parameters.AddWithValue("@suspend", suspend);
            cmdBuilder = new SqlCommandBuilder(adapter);
        }
        public void insertPhoto(long accountNo, byte[] img)
        {
            try
            {
                adapter = new SqlDataAdapter("insertPhotoSP", con);
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                adapter.SelectCommand.Parameters.AddWithValue("@accountNo", accountNo);
                adapter.SelectCommand.Parameters.AddWithValue("@img", img);
                cmdBuilder = new SqlCommandBuilder(adapter);
            }
            catch (SqlException sql)
            {

            }
        }
        public void insertSignature(long accountNo, byte[] img)
        {
            try
            {
                adapter = new SqlDataAdapter("insertSignatureSP", con);
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                adapter.SelectCommand.Parameters.AddWithValue("@accountNo", accountNo);
                adapter.SelectCommand.Parameters.AddWithValue("@img", img);
                cmdBuilder = new SqlCommandBuilder(adapter);
            }
            catch (SqlException sql)
            {

            }
        }
        public void insertGuarantorPhoto(long accountNo, byte[] img)
        {
            try
            {
                adapter = new SqlDataAdapter("insertGuarantorPhotoSP", con);
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                adapter.SelectCommand.Parameters.AddWithValue("@accountNo", accountNo);
                adapter.SelectCommand.Parameters.AddWithValue("@img", img);
                cmdBuilder = new SqlCommandBuilder(adapter);
            }
            catch (SqlException sql)
            {

            }
        }
        public void guarantorSignature(long accountNo, byte[] img)
        {
            try
            {
                adapter = new SqlDataAdapter("guarantorSignatureSP", con);
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                adapter.SelectCommand.Parameters.AddWithValue("@accountNo", accountNo);
                adapter.SelectCommand.Parameters.AddWithValue("@img", img);
                cmdBuilder = new SqlCommandBuilder(adapter);
            }
            catch (SqlException sql)
            {

            }
        }
        public void updatePhoto(long accountNo, byte[] img)
        {
            try
            {
                adapter = new SqlDataAdapter("updatePhotoSP", con);
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                adapter.SelectCommand.Parameters.AddWithValue("@accountNo", accountNo);
                adapter.SelectCommand.Parameters.AddWithValue("@img", img);
                cmdBuilder = new SqlCommandBuilder(adapter);
            }
            catch (SqlException sql)
            {

            }
        }
        public void updateSignature(long accountNo, byte[] img)
        {
            try
            {
                adapter = new SqlDataAdapter("updateSignatureSP", con);
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                adapter.SelectCommand.Parameters.AddWithValue("@accountNo", accountNo);
                adapter.SelectCommand.Parameters.AddWithValue("@img", img);
                cmdBuilder = new SqlCommandBuilder(adapter);
            }
            catch (SqlException sql)
            {

            }
        }
        public void updateGuarantorPhoto(long accountNo, byte[] img)
        {
            try
            {
                adapter = new SqlDataAdapter("updateGuarantorPhotoSP", con);
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                adapter.SelectCommand.Parameters.AddWithValue("@accountNo", accountNo);
                adapter.SelectCommand.Parameters.AddWithValue("@img", img);
                cmdBuilder = new SqlCommandBuilder(adapter);
            }
            catch (SqlException sql)
            {

            }
        }
        public void updateGuarantorSignature(long accountNo, byte[] img)//Implement in Made Easy and Skyfund
        {
            try
            {
                adapter = new SqlDataAdapter("updateGuarantorSignatureSP", con);
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                adapter.SelectCommand.Parameters.AddWithValue("@accountNo", accountNo);
                adapter.SelectCommand.Parameters.AddWithValue("@img", img);
                cmdBuilder = new SqlCommandBuilder(adapter);
            }
            catch (SqlException sql)
            {

            }
        }
        public void getPhoto(long accountNo)
        {
            adapter = new SqlDataAdapter("getPhotoSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@accountNo", accountNo);
        }
        public void getGuarantorPhoto(long accountNo)
        {
            adapter = new SqlDataAdapter("getGuarantorPhotoSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@accountNo", accountNo);
        }
        public void getSignature(long accountNo)
        {
            adapter = new SqlDataAdapter("getSignatureSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@accountNo", accountNo);
        }
        public void getGuarantorSignature(long accountNo)//Implement in Made Easy and Skyfund
        {
            adapter = new SqlDataAdapter("getGuarantorSignatureSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@accountNo", accountNo);
        }
        public void regFee(long accountNo, long amount)
        {
            try
            {
                adapter = new SqlDataAdapter("regFeeSP", con);
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                adapter.SelectCommand.Parameters.AddWithValue("@accountNo", accountNo);
                adapter.SelectCommand.Parameters.AddWithValue("@amount", amount);
                cmdBuilder = new SqlCommandBuilder(adapter);
            }
            catch (SqlException sql)
            {

            }
        }

        public void updateRegFee(long accountNo, long amount)
        {
            adapter = new SqlDataAdapter("updateRegFeeSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@accountNo", accountNo);
            adapter.SelectCommand.Parameters.AddWithValue("@amount", amount);
            cmdBuilder = new SqlCommandBuilder(adapter);
        }
        public void searchCustomer(string search)
        {
            adapter = new SqlDataAdapter("searchCustomerSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@search", search);
        }
        public void getTransID(long transID)
        {
            adapter = new SqlDataAdapter("getTransIDSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@transID", transID);
        }
        public void getTransLogID(long transID)
        {
            adapter = new SqlDataAdapter("getTransLogIDSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@transID", transID);
        }
        public void wrongPost(long transID)
        {
            adapter = new SqlDataAdapter("wrongPostSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@transID", transID);
            cmdBuilder = new SqlCommandBuilder(adapter);
        }
        public void overPost(long amount, long transID)
        {
            adapter = new SqlDataAdapter("overPostSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@amount", amount);
            adapter.SelectCommand.Parameters.AddWithValue("@transID", transID);
            cmdBuilder = new SqlCommandBuilder(adapter);
        }
        public void changeDate(long transID, string date)
        {
            adapter = new SqlDataAdapter("changeDateSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@transID", transID);
            adapter.SelectCommand.Parameters.AddWithValue("@date", date);
            cmdBuilder = new SqlCommandBuilder(adapter);
        }
        public void processingFee(long transID)
        {
            adapter = new SqlDataAdapter("processingFeeSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@transID", transID);
            cmdBuilder = new SqlCommandBuilder(adapter);
        }
        /*Admin Session
         * Charges
        */
        //Igando Charges
        public void igCharges(string date)
        {
            adapter = new SqlDataAdapter("igChargesSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@date", date);
        }
        //Egbeda Charges
        public void egCharges(string date)
        {
            adapter = new SqlDataAdapter("egChargesSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@date", date);
        }
        //Cooperative Charges
        public void coopCharges(string date)
        {
            adapter = new SqlDataAdapter("coopChargesSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@date", date);
        }
        //Registration
        //Igando Savings
        public void igandoSavReg(string date)
        {
            adapter = new SqlDataAdapter("igandoSavRegSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@date", date);
        }
        //Egbeda Savings
        public void egbedaSavReg(string date)
        {
            adapter = new SqlDataAdapter("egbedaSavRegSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@date", date);
        }
        //Igando Loan
        public void igandoLoanReg(string date)
        {
            adapter = new SqlDataAdapter("igandoLoanRegSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@date", date);
        }
        //Egbeda Loan
        public void egbedaLoanReg(string date)
        {
            adapter = new SqlDataAdapter("egbedaLoanRegSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@date", date);
        }
        //Cooperate Reg
        public void coopReg(string date)
        {
            adapter = new SqlDataAdapter("coopRegSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@date", date);
        }

        //Processing
        //Igando Processing
        public void igProcessingFee(string date)
        {
            adapter = new SqlDataAdapter("igProcessingFeeSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@date", date);
        }
        //Egbeda Processing
        public void egProcessingFee(string date)
        {
            adapter = new SqlDataAdapter("egProcessingFeeSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@date", date);
        }
        //Withdrawal 
        //Igando Withdrawal
        public void igandoWith(string date)
        {
            adapter = new SqlDataAdapter("igandoWithSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@date", date);
        }
        //Egbeda Withdrawal
        public void egbedaWith(string date)
        {
            adapter = new SqlDataAdapter("egbedaWithSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@date", date);
        }
        //Cooperative withdrawal
        public void coopWith(string date)
        {
            adapter = new SqlDataAdapter("coopWithSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@date", date);
        }
        //Cooperative deposit
        public void coopDep(string date)
        {
            adapter = new SqlDataAdapter("coopDepSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@date", date);
        }

        //Igando Deposit
        public void igandoDep(string date)
        {
            adapter = new SqlDataAdapter("IgandoDepSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@date", date);
        }
        //Egbeda Deposit
        public void egbedaDep(string date)
        {
            adapter = new SqlDataAdapter("egbedaDepSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@date", date);
        }
        //Igando Transfer
        public void igandoTrans(string date)
        {
            adapter = new SqlDataAdapter("igandoTransSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@date", date);
        }
        //Egbeda Transfer
        public void egbedaTrans(string date)
        {
            adapter = new SqlDataAdapter("egbedaTransSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@date", date);
        }
        //Cooperative Transfer
        public void coopTrans(string date)
        {
            adapter = new SqlDataAdapter("coopTransSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@date", date);
        }
        //Disbursement
        //Igando Disbursement
        public void igDisburse(string date)
        {
            adapter = new SqlDataAdapter("igDisburseSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@date", date);
        }
        //Egbeda Disbursement
        public void egDisburse(string date)
        {
            adapter = new SqlDataAdapter("egDisburseSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@date", date);
        }
        //Cooperative Disbursement
        public void coopDisburse(string date)
        {
            adapter = new SqlDataAdapter("coopDisburseSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@date", date);
        }
        //Cashier
        public void user()
        {
            adapter = new SqlDataAdapter("userSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        }
        //Account officer transaction details
        public void accOfficerDep(string date, string user, string accOfficer)
        {
            adapter = new SqlDataAdapter("accOfficerDepSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@date", date);
            adapter.SelectCommand.Parameters.AddWithValue("@user", user);
            adapter.SelectCommand.Parameters.AddWithValue("@accOfficer", accOfficer);
        }
        public void cashierWith(string date, string user)
        {
            adapter = new SqlDataAdapter("cashierWithSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@date", date);
            adapter.SelectCommand.Parameters.AddWithValue("@user", user);
        }
        public void cashierTrans(string date, string user)
        {
            adapter = new SqlDataAdapter("cashierTransSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@date", date);
            adapter.SelectCommand.Parameters.AddWithValue("@user", user);
        }
        //Count account officer transaction details
        public void countDep(string date, string user, string accOfficer)
        {
            adapter = new SqlDataAdapter("countDepSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@date", date);
            adapter.SelectCommand.Parameters.AddWithValue("@user", user);
            adapter.SelectCommand.Parameters.AddWithValue("@accOfficer", accOfficer);
        }
        //Counting processing fee
        public void countPf(string date, string user, string accOfficer)
        {
            adapter = new SqlDataAdapter("countPfSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@date", date);
            adapter.SelectCommand.Parameters.AddWithValue("@user", user);
            adapter.SelectCommand.Parameters.AddWithValue("@accOfficer", accOfficer);
        }
        //Getting processing fee
        public void getProcAmount(string date, string user, string accOfficer)
        {
            adapter = new SqlDataAdapter("getProcAmountSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@date", date);
            adapter.SelectCommand.Parameters.AddWithValue("@user", user);
            adapter.SelectCommand.Parameters.AddWithValue("@accOfficer", accOfficer);
        }
        //Counting registration
        public void countReg(string date, string accOfficer)
        {
            adapter = new SqlDataAdapter("countRegSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@date", date);
            adapter.SelectCommand.Parameters.AddWithValue("@accOfficer", accOfficer);
        }
        //Getting registration Amount
        public void getRegAmount(string date, string accOfficer)
        {
            adapter = new SqlDataAdapter("getRegAmountSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@date", date);
            adapter.SelectCommand.Parameters.AddWithValue("@accOfficer", accOfficer);
        }
        public void countWith(string date, string user)
        {
            adapter = new SqlDataAdapter("countWithSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@date", date);
            adapter.SelectCommand.Parameters.AddWithValue("@user", user);
        }
        public void countTrans(string date, string user)
        {
            adapter = new SqlDataAdapter("countTransSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@date", date);
            adapter.SelectCommand.Parameters.AddWithValue("@user", user);
        }
        public void notification(string user, string notification)
        {
            adapter = new SqlDataAdapter("notificationSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@user", user);
            adapter.SelectCommand.Parameters.AddWithValue("@notification", notification);
            cmdBuilder = new SqlCommandBuilder(adapter);
        }
        public void alert()
        {
            adapter = new SqlDataAdapter("alertSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        }
        //Account type session
        public void registerAccountType(string accountType, float amount)
        {
            adapter = new SqlDataAdapter("registerAccountTypeSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@accountType", accountType);
            adapter.SelectCommand.Parameters.AddWithValue("@amount", amount);
            cmdBuilder = new SqlCommandBuilder(adapter);
        }
        public void editAccountType(string accountTypeSelection, string accountType, float amount)
        {
            adapter = new SqlDataAdapter("editAccountTypeSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@accountTypeSelection", accountTypeSelection);
            adapter.SelectCommand.Parameters.AddWithValue("@accountType", accountType);
            adapter.SelectCommand.Parameters.AddWithValue("@amount", amount);
            cmdBuilder = new SqlCommandBuilder(adapter);
        }
        public void deleteAccountType(string accountType)
        {
            adapter = new SqlDataAdapter("deleteAccountTypeSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@accountType", accountType);
            cmdBuilder = new SqlCommandBuilder(adapter);
        }
        public void getAccountTypeDetails(string accountType)
        {
            adapter = new SqlDataAdapter("getAccountTypeDetailsSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@accountType", accountType);
        }
        public void getAccountTypeName(string accountType)
        {
            adapter = new SqlDataAdapter("getAccountTypeNameSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@accountType", accountType);
        }
        public void getAccountType()
        {
            adapter = new SqlDataAdapter("getAccountTypeSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        }
        //Brach Details
        public void getAutoGenerateDetails()
        {
            adapter = new SqlDataAdapter("getAutoGenerateDetailsSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        }
        public void getBranchDetails(string branchName)
        {
            adapter = new SqlDataAdapter("getBranchDetailsSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@branchName", branchName);
        }
        public void getBranchName(string branchName)
        {
            adapter = new SqlDataAdapter("getBranchNameSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@branchName", branchName);
        }
        public void getBranchCode(int branchCode)
        {
            adapter = new SqlDataAdapter("getBranchCodeSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@branchCode", branchCode);
        }
        public void updateAutoGeneratedAccount(string branchName, long accNo)
        {
            adapter = new SqlDataAdapter("updateAutoGeneratedAccountSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@branchName", branchName);
            adapter.SelectCommand.Parameters.AddWithValue("@accNo", accNo);
            cmdBuilder = new SqlCommandBuilder(adapter);
        }
        public void registerBranchDetails(string branchName, int branchCode, long accNo)
        {
            adapter = new SqlDataAdapter("registerBranchDetailsSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@branchName", branchName);
            adapter.SelectCommand.Parameters.AddWithValue("@branchCode", branchCode);
            adapter.SelectCommand.Parameters.AddWithValue("@accNo", accNo);
            cmdBuilder = new SqlCommandBuilder(adapter);
        }
        //Group Details
        public void insertGroup(string groupName, string leader, string secretary, string location)
        {
            adapter = new SqlDataAdapter("insertGroupSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@groupName", groupName);
            adapter.SelectCommand.Parameters.AddWithValue("@leader", leader);
            adapter.SelectCommand.Parameters.AddWithValue("@secretary", secretary);
            adapter.SelectCommand.Parameters.AddWithValue("@location", location);
            cmdBuilder = new SqlCommandBuilder(adapter);
        }
        public void updateGroup(string groupName, string leader, string secretary, string location)
        {
            adapter = new SqlDataAdapter("updateGroupSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@groupName", groupName);
            adapter.SelectCommand.Parameters.AddWithValue("@leader", leader);
            adapter.SelectCommand.Parameters.AddWithValue("@secretary", secretary);
            adapter.SelectCommand.Parameters.AddWithValue("@location", location);
            cmdBuilder = new SqlCommandBuilder(adapter);
        }
        public void getGroupName()
        {
            adapter = new SqlDataAdapter("getGroupNameSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        }
        public void existGroup(string groupName)
        {
            adapter = new SqlDataAdapter("existGroupSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@groupName", groupName);
        }
        public void getGroup(string groupName)
        {
            adapter = new SqlDataAdapter("getGroupSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@groupName", groupName);
        }
        public void deleteGroup(string groupName)
        {
            adapter = new SqlDataAdapter("deleteGroupSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@groupName", groupName);
            cmdBuilder = new SqlCommandBuilder(adapter);
        }
        public void closedAccount(long accountNo, DateTime date)
        {
            adapter = new SqlDataAdapter("closedAccountSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@accountNo", accountNo);
            adapter.SelectCommand.Parameters.AddWithValue("@date", date);
            cmdBuilder = new SqlCommandBuilder(adapter);
        }
        public void getClosedAccount(long accountNo)
        {
            adapter = new SqlDataAdapter("getClosedAccountSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@accountNo", accountNo);
        }
        public void openAccount(long accountNo)
        {
            adapter = new SqlDataAdapter("openAccountSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@accountNo", accountNo);
            cmdBuilder = new SqlCommandBuilder(adapter);
        }
        //Reporting session
        public void accountTypeDetails(string accountType)
        {
            adapter = new SqlDataAdapter("accountTypeDetailsSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@accountType", accountType);
        }
        public void loanPortfolio()
        {
            adapter = new SqlDataAdapter("loanPortfolioSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        }
        public void allOverdueLoanReport()
        {
            adapter = new SqlDataAdapter("allOverdueLoanReportSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        }
        public void branchOverdueLoanReport(string branch)
        {
            adapter = new SqlDataAdapter("branchOverdueLoanReportSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@branch", branch);
        }
        public void accountOfficerOverdueLoanReport(string accountOfficer)
        {
            adapter = new SqlDataAdapter("accountOfficerOverdueLoanReportSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@accountOfficer", accountOfficer);
        }
        public void getAllBalancedLoan()
        {
            adapter = new SqlDataAdapter("getAllBalancedLoanSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        }
        public void monthlyBalancedAccOfficer(string accountOfficer, string month)
        {
            adapter = new SqlDataAdapter("monthlyBalancedAccOfficerSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@accountOfficer", accountOfficer);
            adapter.SelectCommand.Parameters.AddWithValue("@month", month);
        }
        public void yearlyBalancedAccOfficer(string accountOfficer, int year)
        {
            adapter = new SqlDataAdapter("yearlyBalancedAccOfficerSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@accountOfficer", accountOfficer);
            adapter.SelectCommand.Parameters.AddWithValue("@year", year);
        }
        public void monthlyBalancedBranch(string brachName, string month)
        {
            adapter = new SqlDataAdapter("monthlyBalancedBranchSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@branchName", brachName);
            adapter.SelectCommand.Parameters.AddWithValue("@month", month);
        }
        public void yearlyBalancedBranch(string brachName, int year)
        {
            adapter = new SqlDataAdapter("yearlyBalancedBranchSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@branchName", brachName);
            adapter.SelectCommand.Parameters.AddWithValue("@year", year);
        }

        public void getAllUnbalancedLoan()
        {
            adapter = new SqlDataAdapter("getAllUnbalancedLoanSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        }
        public void monthlyUnbalancedAccOfficer(string accountOfficer, string month)
        {
            adapter = new SqlDataAdapter("monthlyUnbalancedAccOfficerSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@accountOfficer", accountOfficer);
            adapter.SelectCommand.Parameters.AddWithValue("@month", month);
        }
        public void yearlyUnbalancedAccOfficer(string accountOfficer, int year)
        {
            adapter = new SqlDataAdapter("yearlyUnbalancedAccOfficerSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@accountOfficer", accountOfficer);
            adapter.SelectCommand.Parameters.AddWithValue("@year", year);
        }
        public void monthlyUnbalancedBranch(string brachName, string month)
        {
            adapter = new SqlDataAdapter("monthlyUnbalancedBranchSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@branchName", brachName);
            adapter.SelectCommand.Parameters.AddWithValue("@month", month);
        }
        public void yearlyUnbalancedBranch(string brachName, int year)
        {
            adapter = new SqlDataAdapter("yearlyUnbalancedBranchSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@branchName", brachName);
            adapter.SelectCommand.Parameters.AddWithValue("@year", year);
        }
        //Transaction Report
        public void transactDepositReport(string user, string accountOfficer, string date)
        {
            adapter = new SqlDataAdapter("transactDepositReportSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@user", user);
            adapter.SelectCommand.Parameters.AddWithValue("@accountOfficer", accountOfficer);
            adapter.SelectCommand.Parameters.AddWithValue("@date", date);
        }
        public void transactMonthDepositReport(string user, string accountOfficer, string date)
        {
            adapter = new SqlDataAdapter("transactMonthDepositReportSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@user", user);
            adapter.SelectCommand.Parameters.AddWithValue("@accountOfficer", accountOfficer);
            adapter.SelectCommand.Parameters.AddWithValue("@date", date);
        }
        public void transactYearDepositReport(string user, string accountOfficer, int date)
        {
            adapter = new SqlDataAdapter("transactYearDepositReportSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@user", user);
            adapter.SelectCommand.Parameters.AddWithValue("@accountOfficer", accountOfficer);
            adapter.SelectCommand.Parameters.AddWithValue("@date", date);
        }
        public void transactWithdrawalReport(string user, string date)
        {
            adapter = new SqlDataAdapter("transactWithdrawalReportSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@user", user);
            adapter.SelectCommand.Parameters.AddWithValue("@date", date);
        }
        public void transactMonthWithdrawalReport(string user, string date)
        {
            adapter = new SqlDataAdapter("transactMonthWithdrawalReportSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@user", user);
            adapter.SelectCommand.Parameters.AddWithValue("@date", date);
        }
        public void transactYearWithdrawalReport(string user, int date)
        {
            adapter = new SqlDataAdapter("transactYearWithdrawalReportSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@user", user);
            adapter.SelectCommand.Parameters.AddWithValue("@date", date);
        }
        public void transactTransferReport(string user, string date)
        {
            adapter = new SqlDataAdapter("transactTransferReportSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@user", user);
            adapter.SelectCommand.Parameters.AddWithValue("@date", date);
        }
        public void transactMonthTransferReport(string user, string date)
        {
            adapter = new SqlDataAdapter("transactMonthTransferReportSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@user", user);
            adapter.SelectCommand.Parameters.AddWithValue("@date", date);
        }
        public void transactYearTransferReport(string user, int date)
        {
            adapter = new SqlDataAdapter("transactYearTransferReportSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@user", user);
            adapter.SelectCommand.Parameters.AddWithValue("@date", date);
        }
        public void transactPfReport(string user, string accountOfficer, string date)
        {
            adapter = new SqlDataAdapter("transactPfReportSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@user", user);
            adapter.SelectCommand.Parameters.AddWithValue("@accountOfficer", accountOfficer);
            adapter.SelectCommand.Parameters.AddWithValue("@date", date);
        }
        public void transactMonthPfReport(string user, string accountOfficer, string date)
        {
            adapter = new SqlDataAdapter("transactMonthPfReportSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@user", user);
            adapter.SelectCommand.Parameters.AddWithValue("@accountOfficer", accountOfficer);
            adapter.SelectCommand.Parameters.AddWithValue("@date", date);
        }
        public void transactYearPfReport(string user, string accountOfficer, int date)
        {
            adapter = new SqlDataAdapter("transactYearPfReportSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@user", user);
            adapter.SelectCommand.Parameters.AddWithValue("@accountOfficer", accountOfficer);
            adapter.SelectCommand.Parameters.AddWithValue("@date", date);
        }
        //Branch transaction report
        public void transactBranchDepositReport(string branch, string date)
        {
            adapter = new SqlDataAdapter("transactBranchDepositReportSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@branch", branch);
            adapter.SelectCommand.Parameters.AddWithValue("@date", date);
        }
        public void transactBranchMonthlyDepositReport(string branch, string month)
        {
            adapter = new SqlDataAdapter("transactBranchMonthlyDepositReportSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@branch", branch);
            adapter.SelectCommand.Parameters.AddWithValue("@month", month);
        }
        public void transactBranchYearlyDepositReport(string branch, int year)
        {
            adapter = new SqlDataAdapter("transactBranchYearlyDepositReportSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@branch", branch);
            adapter.SelectCommand.Parameters.AddWithValue("@year", year);
        }
        public void transactBranchWithdrawalReport(string branch, string date)
        {
            adapter = new SqlDataAdapter("transactBranchWithdrawalReportSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@branch", branch);
            adapter.SelectCommand.Parameters.AddWithValue("@date", date);
        }
        public void transactBranchMonthlyWithdrawalReport(string branch, string month)
        {
            adapter = new SqlDataAdapter("transactBranchMonthlyWithdrawalReportSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@branch", branch);
            adapter.SelectCommand.Parameters.AddWithValue("@month", month);
        }
        public void transactBranchYearlyWithdrawalReport(string branch, int year)
        {
            adapter = new SqlDataAdapter("transactBranchYearlyWithdrawalReportSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@branch", branch);
            adapter.SelectCommand.Parameters.AddWithValue("@year", year);
        }
        public void transactBranchPfReport(string branch, string date)
        {
            adapter = new SqlDataAdapter("transactBranchPfReportSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@branch", branch);
            adapter.SelectCommand.Parameters.AddWithValue("@date", date);
        }
        public void transactBranchMonthlyPfReport(string branch, string month)
        {
            adapter = new SqlDataAdapter("transactBranchMonthlyPfReportSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@branch", branch);
            adapter.SelectCommand.Parameters.AddWithValue("@month", month);
        }
        public void transactBranchYearlyPfReport(string branch, int year)
        {
            adapter = new SqlDataAdapter("transactBranchYearlyPfReportSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@branch", branch);
            adapter.SelectCommand.Parameters.AddWithValue("@year", year);
        }
        public void transactBranchTransferReport(string branch, string date)
        {
            adapter = new SqlDataAdapter("transactBranchTransferReportSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@branch", branch);
            adapter.SelectCommand.Parameters.AddWithValue("@date", date);
        }
        public void transactBranchMonthlyTransferReport(string branch, string month)
        {
            adapter = new SqlDataAdapter("transactBranchMonthlyTransferReportSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@branch", branch);
            adapter.SelectCommand.Parameters.AddWithValue("@month", month);
        }
        public void transactBranchYearlyTransferReport(string branch, int year)
        {
            adapter = new SqlDataAdapter("transactBranchYearlyTransferReportSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@branch", branch);
            adapter.SelectCommand.Parameters.AddWithValue("@year", year);
        }
        public void allTransactionReport(string user, string date)
        {
            adapter = new SqlDataAdapter("allTransactionReportSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@user", user);
            adapter.SelectCommand.Parameters.AddWithValue("@date", date);
        }
        public void customerRegReport()
        {
            adapter = new SqlDataAdapter("customerRegReportSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        }
        public void customerRegMonth(string month)
        {
            adapter = new SqlDataAdapter("customerRegMonthSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@month", month);
        }
        public void customerRegYear(int year)
        {
            adapter = new SqlDataAdapter("customerRegYearSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@year", year);
        }
        public void customerRegBranch(string month, string branch)
        {
            adapter = new SqlDataAdapter("customerRegBranchSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@month", month);
            adapter.SelectCommand.Parameters.AddWithValue("@branch", branch);
        }
        public void customerRegAccountOfficer(string month, string accountOFficer)
        {
            adapter = new SqlDataAdapter("customerRegAccountOfficerSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@month", month);
            adapter.SelectCommand.Parameters.AddWithValue("@accountOFficer", accountOFficer);
        }
        public void customerRegGroup(string month, string groupName)
        {
            adapter = new SqlDataAdapter("customerRegGroupSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@month", month);
            adapter.SelectCommand.Parameters.AddWithValue("@groupName", groupName);
        }
        public void monthlyClosedAccount(string month)
        {
            adapter = new SqlDataAdapter("monthlyClosedAccountSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@month", month);
        }
        public void yearlyClosedAccount(int year)
        {
            adapter = new SqlDataAdapter("yearlyClosedAccountSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@year", year);
        }
        public void loanQuickView(long @accNo)
        {
            adapter = new SqlDataAdapter("accountNumberLoanQuickViewSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@accNo", accNo);
        }
        public void loanQuickView(string accountOfficer)
        {
            adapter = new SqlDataAdapter("accountOfficerLoanQuickViewSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@accountOfficer", accountOfficer);
        }
        public void loanQuickView()
        {
            adapter = new SqlDataAdapter("allLoanQuickViewSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        }
        public void monthlyIncomeOverview(string month)
        {
            adapter = new SqlDataAdapter("monthlyIncomeOverviewSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@month", month);
        }
        public void yearlyIncomeOverview(int year)
        {
            adapter = new SqlDataAdapter("yearlyIncomeOverviewSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@year", year);
        }
        public void branchMonthlyIncomeOverview(string branch, string month)
        {
            adapter = new SqlDataAdapter("branchMonthlyIncomeOverviewSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@branch", branch);
            adapter.SelectCommand.Parameters.AddWithValue("@month", month);
        }
        public void branchYearlyIncomeOverview(string branch, int year)
        {
            adapter = new SqlDataAdapter("branchYearlyIncomeOverviewSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@branch", branch);
            adapter.SelectCommand.Parameters.AddWithValue("@year", year);
        }
        public void accountOfficerMonthlyPerformance(string accountOFficer, string month)
        {
            adapter = new SqlDataAdapter("accountOfficerMonthlyPerformanceSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@accountOFficer", accountOFficer);
            adapter.SelectCommand.Parameters.AddWithValue("@month", month);
        }
        public void accountOfficerYearlyPerformance(string accountOfficer, int year)
        {
            adapter = new SqlDataAdapter("accountOfficerYearlyPerformanceSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@accountOfficer", accountOfficer);
            adapter.SelectCommand.Parameters.AddWithValue("@year", year);
        }
        public void branchMonthlyPerformance(string branch, string month)
        {
            adapter = new SqlDataAdapter("branchMonthlyPerformanceSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@branch", branch);
            adapter.SelectCommand.Parameters.AddWithValue("@month", month);
        }
        public void branchYearlyPerformance(string branch, int year)
        {
            adapter = new SqlDataAdapter("branchYearlyPerformanceSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@branch", branch);
            adapter.SelectCommand.Parameters.AddWithValue("@year", year);
        }
        public void dayDisburseReport(string branch, string date)
        {
            adapter = new SqlDataAdapter("dayDisburseReportSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@branch", branch);
            adapter.SelectCommand.Parameters.AddWithValue("@date", date);
        }
        public void monthlyDisburseReport(string branch, string month)
        {
            adapter = new SqlDataAdapter("monthlyDisburseReportSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@branch", branch);
            adapter.SelectCommand.Parameters.AddWithValue("@month", month);
        }
        public void yearlyDisburseReport(string branch, int year)
        {
            adapter = new SqlDataAdapter("yearlyDisburseReportSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@branch", branch);
            adapter.SelectCommand.Parameters.AddWithValue("@year", year);
        }
        public void allDailyDisburseReport(string date)
        {
            adapter = new SqlDataAdapter("allDailyDisburseReportSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@date", date);
        }
        public void allMonthlyDisburseReport(string month)
        {
            adapter = new SqlDataAdapter("allMonthlyDisburseReportSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@month", month);
        }
        public void allYearlyDisburseReport(int year)
        {
            adapter = new SqlDataAdapter("allYearlyDisburseReportSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@year", year);
        }

        public void accountOfficerDayDefault(string accountOfficer, string date)
        {
            adapter = new SqlDataAdapter("accountOfficerDayDefaultSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@accountOfficer", accountOfficer);
            adapter.SelectCommand.Parameters.AddWithValue("@date", date);
        }
        public void accountOfficerWeekDefault(string accountOfficer, string week)
        {
            adapter = new SqlDataAdapter("accountOfficerWeekDefaultSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@accountOfficer", accountOfficer);
            adapter.SelectCommand.Parameters.AddWithValue("@week", week);
        }
        public void accountOfficerMonthDefault(string accountOfficer, string month)
        {
            adapter = new SqlDataAdapter("accountOfficerMonthDefaultSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@accountOfficer", accountOfficer);
            adapter.SelectCommand.Parameters.AddWithValue("@month", month);
        }
        public void branchDayDefault(string branch, string date)
        {
            adapter = new SqlDataAdapter("branchDayDefaultSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@branch", branch);
            adapter.SelectCommand.Parameters.AddWithValue("@date", date);
        }
        public void branchWeekDefault(string branch, string week)
        {
            adapter = new SqlDataAdapter("branchWeekDefaultSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@branch", branch);
            adapter.SelectCommand.Parameters.AddWithValue("@week", week);
        }
        public void branchMonthDefault(string branch, string month)
        {
            adapter = new SqlDataAdapter("branchMonthDefaultSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@branch", branch);
            adapter.SelectCommand.Parameters.AddWithValue("@month", month);
        }
        public void allDefault()
        {
            adapter = new SqlDataAdapter("allDefaultSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        }
        public void accountBalanceReport()
        {
            adapter = new SqlDataAdapter("accountBalanceReportSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        }
        public void groupLoanCustomerReport(string groupName)
        {
            adapter = new SqlDataAdapter("groupLoanCustomerReportSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@groupName", groupName);
        }
        public void bvnConfirmation(string bvn)
        {
            adapter = new SqlDataAdapter("bvnConfirmationSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@bvn", bvn);
        }
        public void getBvn(string bvn)
        {
            adapter = new SqlDataAdapter("getBvnSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@bvn", bvn);
        }
        public void logFile(string username, string status)
        {
            adapter = new SqlDataAdapter("logFileSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@username", username);
            adapter.SelectCommand.Parameters.AddWithValue("@status", status);
        }
        public void getTrans()
        {
            adapter = new SqlDataAdapter("getTransSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        }

        //Dual Control
        public void lockUser(string username, int unlockCode)
        {
            adapter = new SqlDataAdapter("lockUserSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@username", username);
            adapter.SelectCommand.Parameters.AddWithValue("@unlockCode", unlockCode);
            cmdBuilder = new SqlCommandBuilder(adapter);
        }
        public void unlockUser(string username, string status)
        {
            adapter = new SqlDataAdapter("unlockUserSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@username", username);
            adapter.SelectCommand.Parameters.AddWithValue("@status", status);
            cmdBuilder = new SqlCommandBuilder(adapter);
        }
        public void getUnlockCode(string username)
        {
            adapter = new SqlDataAdapter("getUnlockCodeSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@username", username);
        }
        public void getLogin(string username)
        {
            adapter = new SqlDataAdapter("getLoginSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@username", username);
        }
        public void getClientID(string name)
        {
            // Use direct query instead of stored procedure for cloud deployment
            adapter = new SqlDataAdapter("SELECT ClientID FROM Client WHERE ClientName = @name", con);
            adapter.SelectCommand.Parameters.AddWithValue("@name", name);
            
            /* Original stored procedure call - commented out for cloud deployment
            adapter = new SqlDataAdapter("getClientIDSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@name", name);
            */
        }
        public void insertSupport(int clientID, int ticketNumber, string username, string subject, string message)
        {
            adapter = new SqlDataAdapter("insertSupportSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@clientID", clientID);
            adapter.SelectCommand.Parameters.AddWithValue("@ticketNumber", ticketNumber);
            adapter.SelectCommand.Parameters.AddWithValue("@username", username);
            adapter.SelectCommand.Parameters.AddWithValue("@subject", subject);
            adapter.SelectCommand.Parameters.AddWithValue("@message", message);
            cmdBuilder = new SqlCommandBuilder(adapter);
        }
        public void getSupportResponse(int ticketNumber)
        {
            adapter = new SqlDataAdapter("getSupportResponseSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@ticketNumber", ticketNumber);
        }
        public void clearAmount(long accountNo, float amount, string user)
        {
            adapter = new SqlDataAdapter("clearAmountSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@accountNo", accountNo);
            adapter.SelectCommand.Parameters.AddWithValue("@amount", amount);
            adapter.SelectCommand.Parameters.AddWithValue("@user", user);
            cmdBuilder = new SqlCommandBuilder(adapter);
        }
        public void unreadMessage(string username)
        {
            adapter = new SqlDataAdapter("unreadMessageSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@username", username);
        }
        public void insertFeedback(int clientID, string username, string subject, string message)
        {
            adapter = new SqlDataAdapter("insertFeedbackSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@clientID", clientID);
            adapter.SelectCommand.Parameters.AddWithValue("@username", username);
            adapter.SelectCommand.Parameters.AddWithValue("@subject", subject);
            adapter.SelectCommand.Parameters.AddWithValue("@message", message);
            cmdBuilder = new SqlCommandBuilder(adapter);
        }
        public void getNews()
        {
            adapter = new SqlDataAdapter("getNewsSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            cmdBuilder = new SqlCommandBuilder(adapter);
        }
        public void dayCallOver(string user, string date)
        {
            adapter = new SqlDataAdapter("dayCallOverSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@user", user);
            adapter.SelectCommand.Parameters.AddWithValue("@date", date);
        }
        public void monthCallOver(string user, string date)
        {
            adapter = new SqlDataAdapter("monthCallOverSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@user", user);
            adapter.SelectCommand.Parameters.AddWithValue("@date", date);
        }
        public void yearCallOver(string user, int date)
        {
            adapter = new SqlDataAdapter("yearCallOverSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@user", user);
            adapter.SelectCommand.Parameters.AddWithValue("@date", date);
        }
        public void accountOfficerCallOver(string user, string accountOfficer, string date)
        {
            adapter = new SqlDataAdapter("accountOfficerCallOverSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@user", user);
            adapter.SelectCommand.Parameters.AddWithValue("@accountOfficer", accountOfficer);
            adapter.SelectCommand.Parameters.AddWithValue("@date", date);
        }
        public void dayDashboard(string branch, string date)
        {
            adapter = new SqlDataAdapter("dayDashboardSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@branch", branch);
            adapter.SelectCommand.Parameters.AddWithValue("@date", date);
        }
        public void monthDashboard(string branch, string date)
        {
            adapter = new SqlDataAdapter("monthDashboardSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@branch", branch);
            adapter.SelectCommand.Parameters.AddWithValue("@date", date);
        }
        public void yearDashboard(string branch, int date)
        {
            adapter = new SqlDataAdapter("yearDashboardSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@branch", branch);
            adapter.SelectCommand.Parameters.AddWithValue("@date", date);
        }
        public void allDayDashboard(string date)
        {
            adapter = new SqlDataAdapter("allDayDashboardSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@date", date);
        }
        public void allMonthDashboard(string date)
        {
            adapter = new SqlDataAdapter("allMonthDashboardSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@date", date);
        }
        public void allYearDashboard(int date)
        {
            adapter = new SqlDataAdapter("allYearDashboardSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@date", date);
        }
        public void dayCoverage(string accountOfficer, string date)
        {
            adapter = new SqlDataAdapter("dayCoverageSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@accountOfficer", accountOfficer);
            adapter.SelectCommand.Parameters.AddWithValue("@date", date);
        }
        public void monthCoverage(string accountOfficer, string date)
        {
            adapter = new SqlDataAdapter("monthCoverageSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@accountOfficer", accountOfficer);
            adapter.SelectCommand.Parameters.AddWithValue("@date", date);
        }
        public void branchDormantAccount(string branch)
        {
            adapter = new SqlDataAdapter("branchDormantAccountSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@branch", branch);
        }
        public void allDormantAccount()
        {
            adapter = new SqlDataAdapter("allDormantAccountSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        }
        //Threshold new implementatin
        public void setupThreshold(string departmentID, long deposit, long bulk, long withdrawal, long transfer)
        {
            adapter = new SqlDataAdapter("setupThresholdSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@departmentID", departmentID);
            adapter.SelectCommand.Parameters.AddWithValue("@deposit", deposit);
            adapter.SelectCommand.Parameters.AddWithValue("@bulk", bulk);
            adapter.SelectCommand.Parameters.AddWithValue("@withdrawal", withdrawal);
            adapter.SelectCommand.Parameters.AddWithValue("@transfer", transfer);
            cmdBuilder = new SqlCommandBuilder(adapter);
        }
        public void getThresholdDepartment()
        {
            adapter = new SqlDataAdapter("getThresholdDepartmentSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        }
        public void getThreshold(string departmentName)
        {
            adapter = new SqlDataAdapter("getThresholdSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@departmentName", departmentName);
        }
        public void getThresholdSetup(string departmentID)
        {
            adapter = new SqlDataAdapter("getThresholdSetupSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@departmentID", departmentID);
        }
        public void updateThreshold(string departmentID, long deposit, long bulk, long withdrawal, long transfer)
        {
            adapter = new SqlDataAdapter("updateThresholdSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@departmentID", departmentID);
            adapter.SelectCommand.Parameters.AddWithValue("@deposit", deposit);
            adapter.SelectCommand.Parameters.AddWithValue("@bulk", bulk);
            adapter.SelectCommand.Parameters.AddWithValue("@withdrawal", withdrawal);
            adapter.SelectCommand.Parameters.AddWithValue("@transfer", transfer);
            cmdBuilder = new SqlCommandBuilder(adapter);
        }
        public void countLedger()
        {
            adapter = new SqlDataAdapter("countLedgerSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        }
        public void transactionLedger(string date, string time, string transactionType, long amt,
            int charges, long accountNo, long recipientAccNo, string accOfficer, string cashier,
            string hostName, string description)
        {
            cmd = new SqlCommand("transactionLedgerSP", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@date", date);
            cmd.Parameters.AddWithValue("@time", time);
            cmd.Parameters.AddWithValue("@transactionType", transactionType);
            cmd.Parameters.AddWithValue("@amt", amt);
            cmd.Parameters.AddWithValue("@charges", charges);
            cmd.Parameters.AddWithValue("@accNo", accountNo);
            cmd.Parameters.AddWithValue("@recipientAccNo", recipientAccNo);
            cmd.Parameters.AddWithValue("@accountOfficer", accOfficer);
            cmd.Parameters.AddWithValue("@cashier", cashier);
            cmd.Parameters.AddWithValue("@hostName", hostName);
            cmd.Parameters.AddWithValue("@description", description);
            adapter = new SqlDataAdapter(cmd);
            cmdBuilder = new SqlCommandBuilder(adapter);
        }
        public void approveTransaction(long ledgerID)
        {
            adapter = new SqlDataAdapter("approveTransactionSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@ledgerID", ledgerID);
        }
        public void disapproveTransaction(long ledgerID)
        {
            adapter = new SqlDataAdapter("disapproveTransactionSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@ledgerID", ledgerID);
        }
        public void getLedgerID()
        {
            adapter = new SqlDataAdapter("getLedgerIDSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        }
        public void getLedgerUsername()
        {
            adapter = new SqlDataAdapter("getLedgerUsernameSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        }
        public void filterTransaction(string control, string username, long ledgerID)
        {
            cmd = new SqlCommand("filterTransactionSP", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@control", control);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@ledgerID", ledgerID);
            adapter = new SqlDataAdapter(cmd);
        }
        public void logTransactionApproval(string username, long ledgerID)
        {
            adapter = new SqlDataAdapter("logTransactionApprovalSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@username", username);
            adapter.SelectCommand.Parameters.AddWithValue("@ledgerID", ledgerID);
            cmdBuilder = new SqlCommandBuilder(adapter);
        }
        public void getApprovedTransaction()
        {
            adapter = new SqlDataAdapter("getApprovedTransactionSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        }
        //Expenditure
        public void registerItem(string itemName)
        {
            adapter = new SqlDataAdapter("registerItemSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@itemName", itemName);
            cmdBuilder = new SqlCommandBuilder(adapter);
        }
        public void logExpenditure(string itemName, string benefactor, string beneficiary, string description, long amount, string date, string time)
        {
            adapter = new SqlDataAdapter("logExpenditureSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@itemName", itemName);
            adapter.SelectCommand.Parameters.AddWithValue("@benefactor", benefactor);
            adapter.SelectCommand.Parameters.AddWithValue("@beneficiary", beneficiary);
            adapter.SelectCommand.Parameters.AddWithValue("@description", description);
            adapter.SelectCommand.Parameters.AddWithValue("@amount", amount);
            adapter.SelectCommand.Parameters.AddWithValue("@date", date);
            adapter.SelectCommand.Parameters.AddWithValue("@time", time);
            cmdBuilder = new SqlCommandBuilder(adapter);
        }
        public void getExpenditureItem()
        {
            adapter = new SqlDataAdapter("getExpenditureItemSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        }
        public void getExpenditureByItem(string itemName)
        {
            adapter = new SqlDataAdapter("getExpenditureByItemSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@itemName", itemName);
        }
        public void getExpenditureByInterval(string itemName, string interval, string date)
        {
            adapter = new SqlDataAdapter("getExpenditureByIntervalSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@itemName", itemName);
            adapter.SelectCommand.Parameters.AddWithValue("@interval", interval);
            adapter.SelectCommand.Parameters.AddWithValue("@date", date);
        }
        public void getExpenditureByDate(string interval, string date)
        {
            adapter = new SqlDataAdapter("getExpenditureByDateSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@interval", interval);
            adapter.SelectCommand.Parameters.AddWithValue("@date", date);
        }
        public void getWorkHourSubMessage(int clientID)
        {
            // Bypass work hour and subscription message check for cloud deployment
            adapter = new SqlDataAdapter("SELECT 0 as OpenHour, 24 as CloseHour, 'Welcome to Made Easy MF Cloud' as CloudMessage, 'System Active' as MaintenanceMessage", con);
            
            /* Original code - commented out for cloud deployment
            adapter = new SqlDataAdapter("getWorkHourSubMessageSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@clientID", clientID);
            */
        }
        public void getSession(string username)
        {
            adapter = new SqlDataAdapter("getSessionSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@username", username);
        }
        public void getOpeningBalance(long accNo)
        {
            adapter = new SqlDataAdapter("getOpeningBalanceSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@accNo", accNo);
        }
        public void getPassAutoExpire(string username)
        {
            adapter = new SqlDataAdapter("getPassAutoExpireSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@username", username);
        }
        public void setupPassAutoExpire(string username, string date, int interval)
        {
            adapter = new SqlDataAdapter("setupPassAutoExpireSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@username", username);
            adapter.SelectCommand.Parameters.AddWithValue("@date", date);
            adapter.SelectCommand.Parameters.AddWithValue("@interval", interval);
            cmdBuilder = new SqlCommandBuilder(adapter);
        }
        public void deletePassAutoExpire(string username)
        {
            adapter = new SqlDataAdapter("deletePassAutoExpireSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@username", username);
        }
        public void getNotificationTitle()
        {
            adapter = new SqlDataAdapter("getNotificationTitleSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        }
        public void readNotification(string title, string username)
        {
            adapter = new SqlDataAdapter("readNotificationSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@username", username);
            adapter.SelectCommand.Parameters.AddWithValue("@title", title);
            cmdBuilder = new SqlCommandBuilder(adapter);
        }
        public void countUnreadNotification(string username)
        {
            adapter = new SqlDataAdapter("countUnreadNotificationSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@username", username);
        }
        public void vaultBalance(string date, int branchCode)
        {
            adapter = new SqlDataAdapter("vaultBalanceSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@date", date);
            adapter.SelectCommand.Parameters.AddWithValue("@branchCode", branchCode);
        }
        public void creditVault(string date, int branchCode, long deposit, long withdrawal)
        {
            adapter = new SqlDataAdapter("creditVaultSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@date", date);
            adapter.SelectCommand.Parameters.AddWithValue("@branchCode", branchCode);
            adapter.SelectCommand.Parameters.AddWithValue("@deposit", deposit);
            adapter.SelectCommand.Parameters.AddWithValue("@withdrawal", withdrawal);
            cmdBuilder = new SqlCommandBuilder(adapter);
        }
        public void getVaultBranchCode(string branchName)
        {
            adapter = new SqlDataAdapter("getVaultBranchCodeSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@branchName", branchName);
        }
        public void getHeadOfficeVaultBalance()
        {
            adapter = new SqlDataAdapter("getHeadOfficeVaultBalanceSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        }
        public void depositVaultBalance(string date, int branchCode)
        {
            adapter = new SqlDataAdapter("depositVaultBalanceSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@date", date);
            adapter.SelectCommand.Parameters.AddWithValue("@branchCode", branchCode);
        }
        public void debitVaultBalance(string date, int branchCode, long deposit)
        {
            adapter = new SqlDataAdapter("debitVaultBalanceSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@date", date);
            adapter.SelectCommand.Parameters.AddWithValue("@branchCode", branchCode);
            adapter.SelectCommand.Parameters.AddWithValue("@deposit", deposit);
            cmdBuilder = new SqlCommandBuilder(adapter);
        }
        public void getHeadOfficeNumber()
        {
            adapter = new SqlDataAdapter("getHeadOfficeNumberSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        }
        public void creditHeadOffice(long amount)
        {
            adapter = new SqlDataAdapter("creditHeadOfficeSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@amount", amount);
            cmdBuilder = new SqlCommandBuilder(adapter);
        }
        public void vaultIntervalReport(string interval, string date)
        {
            adapter = new SqlDataAdapter("vaultIntervalReportSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@interval", interval);
            adapter.SelectCommand.Parameters.AddWithValue("@date", date);
        }
        public void vaultReport()
        {
            adapter = new SqlDataAdapter("vaultReportSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        }
        public void vaultDebit(int branchCode, long amount)
        {
            adapter = new SqlDataAdapter("vaultDebitSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@branchCode", branchCode);
            adapter.SelectCommand.Parameters.AddWithValue("@amount", amount);
            cmdBuilder = new SqlCommandBuilder(adapter);
        }
        public void branchName(int branchCode)
        {
            adapter = new SqlDataAdapter("branchNameSP", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@branchCode", branchCode);
            cmdBuilder = new SqlCommandBuilder(adapter);
        }
    }
}
