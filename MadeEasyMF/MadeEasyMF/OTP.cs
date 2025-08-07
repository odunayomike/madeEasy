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
using System.Data.SqlClient;

namespace SoftlightMF
{
    public partial class OTP : Form
    {
        DatabaseLib db = new DatabaseLib();
        DataTable tb;
        string sub;
        string day, hour, minute, second, departmentName, username;
        int dbUnlockCode;
        public OTP()
        {
            InitializeComponent();
            day = DateTime.Now.Day.ToString();
            hour = DateTime.Now.Hour.ToString();
            minute = DateTime.Now.Minute.ToString();
            second = DateTime.Now.Second.ToString();
            username = ExposeProperties.UserLogin;
            departmentName = ExposeProperties.DepartmentName;
            if (ExposeProperties.TransactionTypeStatus != null && ExposeProperties.TransactionTypeStatus.Equals("Home"))
            {
                user();
                comboOTPType.Visible = true;
                comboUser.Visible = true;
                lblTitle.Text = "Generate OTP";
                lblCode.Visible = false;
                txtOTP.Visible = false;
            }
            else
            {
                comboOTPType.Visible = false;
                comboUser.Visible = false;
                lblTitle.Text = "OTP";
                lblCode.Visible = true;
                txtOTP.Visible = true;
                linkClearAmount.Visible = false;
            }
            if (departmentName.Equals("ADMIN") && !ExposeProperties.TransactionTypeStatus.Equals("Home"))
            {
                db.connect();
                db.getUnlockCode(username);
                db.getConnection.Close();
                DataTable user = new DataTable();
                db.getDataAdapter.Fill(user);
                dbUnlockCode = (int)user.Rows[0]["Login"];
                txtOTP.Text = dbUnlockCode.ToString();
            }
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
        private void login()
        {
            try
            {
                string status = null;
                int dbUnlockCode, unlockCode = int.Parse(txtOTP.Text);
                db.connect();
                db.getUnlockCode(username);
                db.getConnection.Close();
                DataTable user = new DataTable();
                db.getDataAdapter.Fill(user);
                dbUnlockCode = (int)user.Rows[0]["Login"];

                if (departmentName.Equals("ADMIN"))
                {
                    status = "Login";
                    db.connect();
                    db.unlockUser(username, status);
                    db.getConnection.Close();
                    DataTable unlock = new DataTable();
                    db.getDataAdapter.Fill(unlock);
                    MessageBox.Show("Your account has been unlocked.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Hide();
                }
                else
                {
                    if (unlockCode == dbUnlockCode)
                    {
                        status = "Login";
                        db.connect();
                        db.unlockUser(username, status);
                        db.getConnection.Close();
                        DataTable unlock = new DataTable();
                        db.getDataAdapter.Fill(unlock);
                        MessageBox.Show("Your account has been unlocked.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Hide();
                    }
                    else
                    {
                        sSMessage.Visible = true;
                        tSSMessage.Text = "Invalid code.";
                    }
                }
            }
            catch (IndexOutOfRangeException idx)
            {
                sSMessage.Visible = true;
                tSSMessage.Text = "Invalid username!";
            }
        }
        private void workHour()
        {

        }
        private void editCustomer()
        {

        }
        private int validate()
        {
            int flag = 0;
            if (txtOTP.Text.Length == 0 && comboUser.Visible == false && comboOTPType.Visible == false)
            {
                errorProvider = new ErrorProvider();
                txtOTP.Focus();
                errorProvider.SetError(txtOTP, "Please enter the code.");
                flag = 1;
            }
            return flag;
        }
        private void securityCode()
        {
            string otp = minute + hour + second + day;
            string code = null;
            if (otp.Length == 8)
            {
                code = otp.Remove(2, 2);
            }
            else
            {
                code = otp.Remove(2, 1);
            }
            try
            {
                db.connect();
                db.getCodeGenerator(code);
                db.getConnection.Close();
                tb = new DataTable();
                db.getDataAdapter.Fill(tb);
                string dbCode = tb.Rows[0]["Code"].ToString();

                if (code == dbCode)
                {
                    sSMessage.Visible = true;
                    tSSMessage.Text = "Sorry! Security code is already existing!.";
                }
            }
            catch (IndexOutOfRangeException e)
            {
                try
                {
                    db.connect();
                    db.codeGenerator(code);
                    db.getConnection.Close();
                    tb = new DataTable();
                    db.getDataAdapter.Fill(tb);
                    sSMessage.Visible = true;
                    tSSMessage.Text = "Security code is " + code;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }
        private void confirmOTP()
        {
            if (ExposeProperties.TransactionTypeStatus.Equals("Login"))
            {
                login();
            }
            else if (ExposeProperties.TransactionTypeStatus.Equals("Work Hour"))
            {
                workHour();
            }
            else
            {
                editCustomer();
            }
        }
        private void getLoginOTP()
        {
            try
            {
                db.connect();
                db.getUnlockCode(comboUser.Text);
                db.getConnection.Close();
                tb = new DataTable();
                db.getDataAdapter.Fill(tb);
                int dbCode = (int)tb.Rows[0]["Login"];
                if (dbCode > 0)
                {
                    sSMessage.Visible = true;
                    tSSMessage.Text = "The generated OTP is " + dbCode.ToString();
                }
                else
                {
                    sSMessage.Visible = true;
                    tSSMessage.Text = "There is no generated OTP for " + comboUser.Text;
                }
            }
            catch (IndexOutOfRangeException idx)
            {
                sSMessage.Visible = true;
                tSSMessage.Text = "There is no generated OTP";
            }
        }
        private void getEditCustomerOTP()
        {

        }
        private void getWorkHourOTP()
        {

        }
        private void getOTPType()
        {
            if (comboOTPType.Text.Equals("Login"))
            {
                getLoginOTP();
            }
            else if (comboOTPType.Text.Equals("Edit Customer"))
            {
                getEditCustomerOTP();
            }
            else if (comboOTPType.Text.Equals("Work Hour"))
            {
                getWorkHourOTP();
            }
            else
            {
                securityCode();
            }
        }
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (validate() == 0)
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
                            if (comboUser.Visible == true && comboOTPType.Visible == true)
                            {
                                getOTPType();
                            }
                            else
                            {
                                confirmOTP();
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
        private void linkClearAmount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ExposeProperties.DepartmentStatus = true;
            new EditTransaction().Show();
            Hide();
        }
    }
}
