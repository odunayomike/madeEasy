using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftlightMF
{
    class ExposeProperties
    {
        private static int reportYear;
        public static int ReportYear
        {
            get { return ExposeProperties.reportYear; }
            set { ExposeProperties.reportYear = value; }
        }
        private static int duration, clientID, branchCode;
        public static int BranchCode
        {
            get { return ExposeProperties.branchCode; }
            set { ExposeProperties.branchCode = value; }
        }

        public static int ClientID
        {
            get { return ExposeProperties.clientID; }
            set { ExposeProperties.clientID = value; }
        }
        private static float percent;

        private static long principal, amount, totAmount, accNumber;

        private static string termsOfPayment, disburseDate, maturityDate, time,
            guarantName, address, phone, gender, username, departmentID, userLogin,
            employeeCode, empID, accountOfficer, transactionType, date, reportMonth, transactionTypeStatus,
            fullName, fromDate, toDate, accountName, branchName, accountTypeReport, loanQuickView, hostName, departmentName;


        private static bool workHour, accountReport, loanPortfolio, branchTrans,
            performance, incomeOverview, callOver, otherUsers, dashboard, thresholdSetup;
        public static bool ThresholdSetup
        {
            get { return ExposeProperties.thresholdSetup; }
            set { ExposeProperties.thresholdSetup = value; }
        }

        public static string DepartmentName
        {
            get { return ExposeProperties.departmentName; }
            set { ExposeProperties.departmentName = value; }
        }
        public static string Username
        {
            get { return ExposeProperties.username; }
            set { ExposeProperties.username = value; }
        }
        public static bool Dashboard
        {
            get { return ExposeProperties.dashboard; }
            set { ExposeProperties.dashboard = value; }
        }

        public static bool OtherUsers
        {
            get { return ExposeProperties.otherUsers; }
            set { ExposeProperties.otherUsers = value; }
        }

        public static bool CallOver
        {
            get { return ExposeProperties.callOver; }
            set { ExposeProperties.callOver = value; }
        }

        public static bool IncomeOverview
        {
            get { return ExposeProperties.incomeOverview; }
            set { ExposeProperties.incomeOverview = value; }
        }

        public static bool Performance
        {
            get { return ExposeProperties.performance; }
            set { ExposeProperties.performance = value; }
        }

        public static bool BranchTrans
        {
            get { return ExposeProperties.branchTrans; }
            set { ExposeProperties.branchTrans = value; }
        }

        public static bool LoanPortfolio
        {
            get { return ExposeProperties.loanPortfolio; }
            set { ExposeProperties.loanPortfolio = value; }
        }

        public static bool AccountReport
        {
            get { return ExposeProperties.accountReport; }
            set { ExposeProperties.accountReport = value; }
        }
        public static bool WorkHour
        {
            get { return ExposeProperties.workHour; }
            set { ExposeProperties.workHour = value; }
        }
        public static string AccountTypeReport
        {
            get { return ExposeProperties.accountTypeReport; }
            set { ExposeProperties.accountTypeReport = value; }
        }
        public static string BranchName
        {
            get { return ExposeProperties.branchName; }
            set { ExposeProperties.branchName = value; }
        }

        public static string AccountName
        {
            get { return ExposeProperties.accountName; }
            set { ExposeProperties.accountName = value; }
        }
        public static string LoanQuickView
        {
            get { return ExposeProperties.loanQuickView; }
            set { ExposeProperties.loanQuickView = value; }
        }

        public static string ToDate
        {
            get { return ExposeProperties.toDate; }
            set { ExposeProperties.toDate = value; }
        }

        public static string FromDate
        {
            get { return ExposeProperties.fromDate; }
            set { ExposeProperties.fromDate = value; }
        }
        public static string FullName
        {
            get { return ExposeProperties.fullName; }
            set { ExposeProperties.fullName = value; }
        }
        public static string TransactionTypeStatus
        {
            get { return ExposeProperties.transactionTypeStatus; }
            set { ExposeProperties.transactionTypeStatus = value; }
        }
        public static string ReportMonth
        {
            get { return ExposeProperties.reportMonth; }
            set { ExposeProperties.reportMonth = value; }
        }
        public static string Date
        {
            get { return ExposeProperties.date; }
            set { ExposeProperties.date = value; }
        }

        public static string TransactionType
        {
            get { return ExposeProperties.transactionType; }
            set { ExposeProperties.transactionType = value; }
        }
        public static string AccountOfficer
        {
            get { return ExposeProperties.accountOfficer; }
            set { ExposeProperties.accountOfficer = value; }
        }

        public static string EmpID
        {
            get { return ExposeProperties.empID; }
            set { ExposeProperties.empID = value; }
        }
        private static bool departmentStatus;
        private static byte[] guarantorPhoto, guarantorSignature;
        public byte[] GuarantorSignature
        {
            get { return guarantorSignature; }
            set { guarantorSignature = value; }
        }

        public byte[] GuarantorPhoto
        {
            get { return guarantorPhoto; }
            set { guarantorPhoto = value; }
        }
        public static bool DepartmentStatus
        {
            get { return departmentStatus; }
            set { departmentStatus = value; }
        }
        public static string EmployeeCode
        {
            get { return ExposeProperties.employeeCode; }
            set { ExposeProperties.employeeCode = value; }
        }
        //Loan disbursement details
        public static long TotAmount
        {
            get { return totAmount; }
            set { totAmount = value; }
        }

        public static long Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        public static float Percent
        {
            get { return percent; }
            set { percent = value; }
        }

        public static int Duration
        {
            get { return duration; }
            set { duration = value; }
        }

        public static long Principal
        {
            get { return principal; }
            set { principal = value; }
        }

        public static long AccNumber
        {
            get { return accNumber; }
            set { accNumber = value; }
        }
        public static string Time
        {
            get { return time; }
            set { time = value; }
        }

        public static string MaturityDate
        {
            get { return maturityDate; }
            set { maturityDate = value; }
        }

        public static string DisburseDate
        {
            get { return disburseDate; }
            set { disburseDate = value; }
        }

        public static string TermsOfPayment
        {
            get { return termsOfPayment; }
            set { termsOfPayment = value; }
        }
        public string GuarantName
        {
            get { return guarantName; }
            set { guarantName = value; }
        }

        public static string DepartmentID
        {
            get { return ExposeProperties.departmentID; }
            set { ExposeProperties.departmentID = value; }
        }
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        public string firstName;
        public string getUser
        {
            get { return username; }
            set { username = value; }
        }
        
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }
        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }
        public static string UserLogin
        {
            get { return userLogin; }
            set { userLogin = value; }
        }
    }
}
