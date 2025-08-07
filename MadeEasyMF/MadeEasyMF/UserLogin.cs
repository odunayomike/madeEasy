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
    public partial class UserLogin : Form
    {
        //private ExposeProperties cl = new ExposeProperties();
        private DatabaseLib db = new DatabaseLib();
        private DataTable tb;
        private Login log = new Login();
        private string firstName, lastName, departmentID, employeeID, dbCode, dbEmpID, suspend, sub;
        public UserLogin()
        {
            InitializeComponent();
        }
        private void getConnection()
        {
            try
            {
                db.connect();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void userLogin()
        {
            try
            {
                string suspend = "false";
                db.connect();
                db.userLogin(txtEmpID.Text, txtUser.Text, txtPass.Text, suspend);
                db.getConnection.Close();
                tb = new DataTable();
                db.getDataAdapter.Fill(tb);

                updateEmployee();

                db.connect();
                db.getEmployeeDetails(txtEmpID.Text);
                db.getConnection.Close();
                DataTable tb2 = new DataTable();
                db.getDataAdapter.Fill(tb2);

                firstName = tb2.Rows[0]["FirstName"].ToString();
                departmentID = tb2.Rows[0]["DepartmentID"].ToString();

                ExposeProperties cl = new ExposeProperties();
                cl.FirstName = firstName;
                cl.getUser = txtUser.Text;
                ExposeProperties.DepartmentID = departmentID;

                new Home().Show();
                Hide();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void forgotPassword()
        {
            try
            {
                string empID = txtEmpCode.Text;
                db.connect();
                db.forgotPassword(empID);
                db.getConnection.Close();
                tb = new DataTable();
                db.getDataAdapter.Fill(tb);
                dbCode = tb.Rows[0]["EmpCode"].ToString();
                dbEmpID = tb.Rows[0]["EmployeeID"].ToString();
                if (empID == dbEmpID)
                {
                    ExposeProperties.UserLogin = "Employee Code";
                    ExposeProperties.EmployeeCode = dbCode;
                    ExposeProperties.EmpID = dbEmpID;
                    new UserLogin().Show();
                    Hide();
                }
            }
            catch (IndexOutOfRangeException ex)
            {
                EmpTabDetails.Visible = false;
                btnReg.Visible = false;
                btnDepClear.Visible = false;
                sSMessage.Visible = true;
                tSSMessage.Text = "Employee ID does not exist!";
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void action()
        {
            try
            {
                string code = txtEmpCode.Text;
                db.connect();
                db.getCodeGenerator(code);
                db.getConnection.Close();
                tb = new DataTable();
                db.getDataAdapter.Fill(tb);
                dbCode = tb.Rows[0]["EmpCode"].ToString();
                if (code == dbCode)
                {
                    try
                    {
                        db.connect();
                        db.confirmCode(code);
                        db.getConnection.Close();
                        DataTable tb2 = new DataTable();
                        db.getDataAdapter.Fill(tb2);
                        string dbCode2 = tb2.Rows[0]["EmpCode"].ToString();

                        if (code == dbCode2)
                        {
                            EmpTabDetails.Visible = false;
                            btnReg.Visible = false;
                            btnDepClear.Visible = false;
                            sSMessage.Visible = true;
                            tSSMessage.Text = "Sorry! security code has been used by another employee.";
                        }
                    }

                    catch (IndexOutOfRangeException ex)
                    {
                        EmpTabDetails.Visible = true;
                        btnReg.Visible = true;
                        btnDepClear.Visible = true;
                        sSMessage.Visible = false;
                    }
                }
            }
            catch (IndexOutOfRangeException ex)
            {
                EmpTabDetails.Visible = false;
                btnReg.Visible = false;
                btnDepClear.Visible = false;
                sSMessage.Visible = true;
                tSSMessage.Text = "Security code does not exist.";
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private int validateUserLogin()
        {
            int flag = 0;
            if (txtUser.Text == "")
            {
                txtUser.Focus();
                errorProvider.SetError(txtUser, "Please, enter your username!");
                flag = 1;
            }
            else
            {
                txtUser.Focus();
                errorProvider.Clear();
            }
            if (txtEmpID.Text == "")
            {
                txtPass.Focus();
                errorProvider.SetError(txtEmpID, "Please, enter your employee's ID!");
                flag = 1;
            }
            else
            {
                txtEmpID.Focus();
                errorProvider.Clear();
            }
            if (txtPass.Text == "")
            {
                txtPass.Focus();
                errorProvider.SetError(txtPass, "Please, enter your password!");
                flag = 1;
            }
            else
            {
                txtPass.Focus();
                errorProvider.Clear();
            }
            if (txtConfirmPass.Text == "")
            {
                txtConfirmPass.Focus();
                errorProvider.SetError(txtConfirmPass, "Please, re-enter your password!");
                flag = 1;
            }
            else
            {
                txtConfirmPass.Focus();
                errorProvider.Clear();
            }
            return flag;
        }
        private int validateCode()
        {
            int flag = 0;

            if (txtEmpCode.Text == "")
            {
                txtEmpCode.Focus();
                errorProvider.SetError(txtEmpCode, "Please, enter the code!");
                flag = 1;
            }
            return flag;
        }
        private void updateEmployee()
        {
            db.connect();
            db.updateEmployee(txtEmpCode.Text, txtEmpID.Text);
            db.getConnection.Close();
            tb = new DataTable();
            db.getDataAdapter.Fill(tb);
        }
        private void linkLogout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ExposeProperties exp = new ExposeProperties();
            if (exp.getUser.Equals(""))
            {
                new Login().logFile(exp.getUser, "Offline");
                new Login().Show();
                Hide();
            }
            else
            {
                new Login().Show();
                Hide();
            }
        }
        private void linkHome_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Home().Show();
            Hide();
        }
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (validateCode() == 0)
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
                        if(hour < open)
                        {
                            MessageBox.Show("Sorry, itsn't open hour yet", "Can't Connect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            new Login().Show();
                            Hide();
                        }
                        else if(hour >= close && minute >=1)
                        {
                            MessageBox.Show("Sorry, work hour is over", "Can't Connect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            new Login().Show();
                            Hide();
                        }
                        else
                        {
                    if (lblCode.Text.Equals("Employee ID"))
                    {
                        forgotPassword();
                    }
                    else if (lblCode.Text.Equals("Security Code"))
                    {
                        action();
                    }
                    else if (lblCode.Text.Equals("User Employee ID"))
                    {
                        deleteUser();
                    }
                    else if (lblCode.Text.Equals("Suspend"))
                    {
                        employeeID = txtEmpCode.Text;
                        if (checkUnsuspend.Checked != true)
                        {
                            suspend = "true";
                            suspendAccount(employeeID, suspend);
                            sSMessage.Visible = true;
                            tSSMessage.Text = "Account has been suspended";
                        }
                        else
                        {
                            suspend = "false";
                            lblCode.Text = "Unsuspend";
                            suspendAccount(employeeID, suspend);
                            sSMessage.Visible = true;
                            tSSMessage.Text = "Account has been unsuspended";
                        }
                    }
                    else
                    {
                        if (ExposeProperties.EmployeeCode.Equals(txtEmpCode.Text))
                        {
                            ExposeProperties.UserLogin = "forgotPassword";
                            new Settings().Show();
                            Hide();
                        }
                        else
                        {
                            sSMessage.Visible = true;
                            tSSMessage.Text = "Invalid security code!";
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
        private void btnReg_Click(object sender, EventArgs e)
        {
            if (validateUserLogin() == 0)
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
                        if(hour < open)
                        {
                            MessageBox.Show("Sorry, itsn't open hour yet", "Can't Connect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            new Login().Show();
                            Hide();
                        }
                        else if(hour >= close && minute >=1)
                        {
                            MessageBox.Show("Sorry, work hour is over", "Can't Connect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            new Login().Show();
                            Hide();
                        }
                        else
                        {
                    try
                    {
                        string localEmpID = txtEmpID.Text;
                        db.connect();
                        db.getEmployeeDetails(localEmpID);
                        db.getConnection.Close();
                        tb = new DataTable();
                        db.getDataAdapter.Fill(tb);

                        employeeID = tb.Rows[0]["EmployeeID"].ToString();
                        firstName = tb.Rows[0]["FirstName"].ToString();
                        lastName = tb.Rows[0]["LastName"].ToString();
                        if (localEmpID.Equals(employeeID))
                        {
                            if ((txtConfirmPass.Text == txtPass.Text) && ((txtUser.Text != firstName) && (txtUser.Text != lastName)))
                            {
                                userLogin();
                                sSMessage.Visible = false;
                            }
                            else if ((txtConfirmPass.Text != txtPass.Text))
                            {
                                sSMessage.Visible = true;
                                tSSMessage.Text = "Sorry, password did not match!";
                            }
                            else
                            {
                                sSMessage.Visible = true;
                                tSSMessage.Text = "Sorry, username must not contain any of your names!";
                            }
                        }
                    }
                    catch (IndexOutOfRangeException idx)
                    {
                        sSMessage.Visible = true;
                        tSSMessage.Text = "Sorry, employee's ID is invalid!";
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

        private void btnDepClear_Click(object sender, EventArgs e)
        {
            txtEmpCode.Text = "";
            txtEmpID.Text = "";
            txtUser.Text = "";
            txtPass.Text = "";
        }
        private void deleteUser()
        {
            try
            {
                string dbEmpID, empID = txtEmpCode.Text;
                db.connect();
                db.getEmployeeDetails(empID);
                db.getConnection.Close();
                tb = new DataTable();
                db.getDataAdapter.Fill(tb);
                dbEmpID = tb.Rows[0]["EmployeeID"].ToString();
                if (empID.Equals(dbEmpID))
                {
                    db.connect();
                    db.deleteUser(txtEmpCode.Text);
                    db.getConnection.Close();
                    tb = new DataTable();
                    db.getDataAdapter.Fill(tb);
                    sSMessage.Visible = true;
                    tSSMessage.Text = "User account deleted successfully";
                }
            }
            catch (IndexOutOfRangeException idx)
            {
                sSMessage.Visible = true;
                tSSMessage.Text = "Invalid employee ID!";
            }
        }
        private void suspendAccount(string empID, string suspend)
        {
            try
            {
                string dbEmpID;
                empID = txtEmpCode.Text;
                db.connect();
                db.getEmployeeDetails(empID);
                db.getConnection.Close();
                tb = new DataTable();
                db.getDataAdapter.Fill(tb);
                dbEmpID = tb.Rows[0]["EmployeeID"].ToString();
                if (empID.Equals(dbEmpID))
                {
                    db.connect();
                    db.suspendAccount(empID, suspend);
                    db.getConnection.Close();
                    tb = new DataTable();
                    db.getDataAdapter.Fill(tb);
                }
            }
            catch (IndexOutOfRangeException idx)
            {
                sSMessage.Visible = true;
                tSSMessage.Text = "Invalid employee ID!";
            }
        }
        private void comboSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboSelect.SelectedItem.Equals("Security Code"))
            {
                lblCode.Text = "Security Code";
                btnConfirm.Text = "Confirm";
                txtEmpCode.Text = "";
                checkUnsuspend.Visible = false;
            }
            else if (comboSelect.SelectedItem.Equals("Delete User"))
            {
                lblCode.Text = "User Employee ID";
                btnConfirm.Text = "Delete";
                checkUnsuspend.Visible = false;
            }
            else if (comboSelect.SelectedItem.Equals("Suspend Account"))
            {
                lblCode.Text = "Suspend";
                btnConfirm.Text = "Suspend";
                checkUnsuspend.Visible = true;
            }
            else
            {
                MessageBox.Show("Invalid selection", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                checkUnsuspend.Visible = false;
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
        private void UserLogin_Load(object sender, EventArgs e)
        {
            try
            {
                if (ExposeProperties.DepartmentStatus == false)
                {
                    comboSelect.Visible = false;
                    checkUnsuspend.Visible = false;
                    if (ExposeProperties.UserLogin.Equals("forgotPassword"))
                    {
                        lblCode.Text = "Employee ID";
                    }
                    else if (ExposeProperties.UserLogin.Equals("loginAccount"))
                    {
                        lblCode.Text = "Security Code";
                    }
                    else
                    {
                        lblCode.Text = ExposeProperties.UserLogin;
                    }
                }
                else
                {
                    db.connect();
                    db.getDepartmentRole(ExposeProperties.DepartmentID);
                    db.getConnection.Close();
                    DataTable tb = new DataTable();
                    db.getDataAdapter.Fill(tb);
                    string departmentName = tb.Rows[0]["CustomerRegistration"].ToString();

                    if (convert(departmentName) == true)
                    {
                        comboSelect.Visible = true;
                        linkHome.Visible = true;
                        linkDivide.Visible = true;
                        checkUnsuspend.Visible = true;
                    }
                }
            }
            catch (IndexOutOfRangeException idx)
            {
                comboSelect.Visible = false;
                checkUnsuspend.Visible = false;
                if (ExposeProperties.UserLogin.Equals("forgotPassword"))
                {
                    lblCode.Text = "Employee ID";
                }
                else if (ExposeProperties.UserLogin.Equals("loginAccount"))
                {
                    lblCode.Text = "Security Code";
                }
                else
                {
                    lblCode.Text = ExposeProperties.UserLogin;
                }
            }
        }
    }
}
