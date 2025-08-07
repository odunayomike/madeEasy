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
using System.Configuration;
using DatabaseLibrary;
using SpeechLib;

namespace SoftlightMF
{
    public partial class Login : Form
    {
        private DatabaseLib db = new DatabaseLib();
        ExposeProperties cl;
        private Home home = new Home();
        private DataTable tb;
        private string user, pass, departmentID, departmentName = "NON ADMIN", suspend,
            subStatus, mainStatus, comUser, comPass, firstName, notification;
        private int duration, count = 3, branchCode;//Vault implementation
        private int subDate, mainDate, clientID;
        SpVoice speech = new SpVoice();
        public Login()
        {
            InitializeComponent();
        }
        public void logFile(string username, string status)
        {
            if (username != null)
            {
                db.connect();
                db.logFile(username, status);
                db.getConnection.Close();
                tb = new DataTable();
                db.getDataAdapter.Fill(tb);
            }
        }
        private int getClientID()
        {
            // Temporary fix: Return default client ID for cloud deployment
            // This bypasses the Client table lookup until proper licensing table is set up
            return 1;
            
            /* Original code - commented out for cloud deployment
            int clientID = 0;
            try
            {
                db.connect();
                db.getClientID("Made Easy");
                db.getConnection.Close();
                DataTable client = new DataTable();
                db.getDataAdapter.Fill(client);
                clientID = (int)client.Rows[0]["ClientID"];
            }
            catch (IndexOutOfRangeException idx)
            {
                clientID = 0;
            }
            return clientID;
            */
        }
        public int generateCode()
        {
            string hour, minute, second, day;
            hour = DateTime.Now.Hour.ToString();
            minute = DateTime.Now.Minute.ToString();
            second = DateTime.Now.Second.ToString();
            day = DateTime.Now.Day.ToString();
            string  generateCode;
            generateCode = (second + hour + day + minute).ToString();

            int code = int.Parse(generateCode);
            return code;
        }
        private string getPassAutoExpire(string user)
        {
            string passwordStatus = null;
            db.connect();
            db.getPassAutoExpire(user);
            db.getConnection.Close();
            tb = new DataTable();
            db.getDataAdapter.Fill(tb);
            passwordStatus = tb.Rows[0]["Status"].ToString();

            return passwordStatus;
        }
        private void connect()
        {
            try
            {
                string cloudMessage = null, maintenanceMsg = null;
                user = txtUser.Text;
                pass = txtPass.Text;
                db.connect();
                db.getLogQuery(user, pass);
                db.getConnection.Close();
                tb = new DataTable();
                db.getDataAdapter.Fill(tb);

                db.connect();
                db.getSub(clientID);
                db.getConnection.Close();
                DataTable sub = new DataTable();
                db.getDataAdapter.Fill(sub);
                
                subStatus = sub.Rows[0]["Status"].ToString();
                mainStatus = sub.Rows[0]["MaintenanceStatus"].ToString();
                comUser = tb.Rows[0]["Username"].ToString();
                comPass = tb.Rows[0]["Password"].ToString();
                firstName = tb.Rows[0]["FirstName"].ToString();
                departmentID = tb.Rows[0]["DepartmentID"].ToString();
                departmentName = tb.Rows[0]["DepartmentName"].ToString();
                suspend = tb.Rows[0]["Suspend"].ToString();
                notification = tb.Rows[0]["Notification"].ToString();
                branchCode = (int)tb.Rows[0]["BranchCode"];

                ExposeProperties.Username = comUser;
                string passwordStatus = getPassAutoExpire(user);
                if (passwordStatus.Equals("Reset"))
                {
                    btnSub.Enabled = false;
                    MessageBox.Show("Your password has expired, Please click forgot password to change your password",
                       "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if ((user.Equals(comUser)) && (pass.Equals(comPass)))
                    {
                        if (!notification.Equals("0"))
                        {
                            if (MessageBox.Show(notification, "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                db.connect();
                                db.notification(user, "0");
                                db.getConnection.Close();
                                DataTable notify = new DataTable();
                                db.getDataAdapter.Fill(notify);
                            }
                        }
                        db.connect();
                        db.getWorkHourSubMessage(clientID);
                        db.getConnection.Close();
                        DataTable workHourSubMsg = new DataTable();
                        db.getDataAdapter.Fill(workHourSubMsg);
                        int open = (int)workHourSubMsg.Rows[0]["OpenHour"];
                        int close = (int)workHourSubMsg.Rows[0]["CloseHour"];
                        cloudMessage = workHourSubMsg.Rows[0]["CloudMessage"].ToString();
                        maintenanceMsg = workHourSubMsg.Rows[0]["MaintenanceMessage"].ToString();

                        if (mainStatus != "Expired")
                        {
                            int hour = int.Parse(new Home().databaseDate().Hour.ToString());
                            int minute = int.Parse(new Home().databaseDate().Minute.ToString());
                            if (hour < open)
                            {
                                MessageBox.Show("Sorry, itsn't open hour yet", "Can't Connect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else if (hour >= close && minute >= 1)
                            {
                                MessageBox.Show("Sorry, work hour is over", "Can't Connect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                db.connect();
                                db.getSubMaintenance(clientID);
                                db.getConnection.Close();
                                DataTable subMain = new DataTable();
                                db.getDataAdapter.Fill(subMain);

                                subDate = int.Parse(subMain.Rows[0]["SubDate"].ToString());
                                mainDate = (int)subMain.Rows[0]["MainDate"];

                                if (mainDate < 6 && mainDate > 1)
                                {
                                    MessageBox.Show(maintenanceMsg, "Maintenance Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else if (mainDate == 1)
                                {
                                    MessageBox.Show(maintenanceMsg, "Maintenance Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }

                                if (subStatus != "Expired")
                                {
                                    if (subDate < 6 && subDate > 1)
                                    {
                                        MessageBox.Show(cloudMessage, "Cloud Subscription Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else if (subDate == 1)
                                    {
                                        MessageBox.Show(cloudMessage, "Cloud Subscription Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    if (suspend == "false")
                                    {
                                        try
                                        {
                                            int dbUnlockCode;
                                            db.connect();
                                            db.getUnlockCode(user);
                                            db.getConnection.Close();
                                            DataTable tbUser = new DataTable();
                                            db.getDataAdapter.Fill(tbUser);
                                            dbUnlockCode = (int)tbUser.Rows[0]["Login"];
                                            if (dbUnlockCode == 0)
                                            {
                                                cl = new ExposeProperties();
                                                cl.FirstName = firstName;
                                                cl.getUser = comUser;
                                                ExposeProperties.DepartmentID = departmentID;
                                                ExposeProperties.UserLogin = comUser;
                                                ExposeProperties.DepartmentName = departmentName;
                                                ExposeProperties.BranchCode = branchCode;
                                                logFile(comUser, "Online");
                                                new Home().Show();
                                                Hide();
                                                count = 2;
                                            }
                                            else
                                            {
                                                //departmentName = "ADMIN";
                                                sSMessage.Visible = true;
                                                tSSMessage.Text = "Your account is locked! Please contact the admin";
                                            }
                                        }
                                        catch (IndexOutOfRangeException idx)
                                        {
                                            cl = new ExposeProperties();
                                            cl.FirstName = firstName;
                                            cl.getUser = comUser;
                                            ExposeProperties.DepartmentID = departmentID;
                                            ExposeProperties.UserLogin = comUser;
                                            ExposeProperties.DepartmentName = departmentName;
                                            ExposeProperties.BranchCode = branchCode;
                                            logFile(comUser, "Online");
                                            new Home().Show();
                                            Hide();
                                            count = 2;
                                        }
                                    }
                                    else
                                    {
                                        sSMessage.Visible = true;
                                        tSSMessage.Text = "Your account has been suspended, please contact the admin";
                                    }
                                }
                                else
                                {
                                    MessageBox.Show(cloudMessage, "Can't Connect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    new Login().Show();
                                    Hide();
                                }
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
            catch (IndexOutOfRangeException e)
            {
                sSMessage.Visible = true;
                if (count > 0)
                {
                    ExposeProperties.Username = txtUser.Text;
                    if (count > 1)
                    {
                        tSSMessage.Text = "Incorrect username or password! " + count + " more attempts";
                    }
                    else
                    {
                        tSSMessage.Text = "Incorrect username or password! " + count + " more attempt";
                    }
                    count--;
                }
                else
                {
                    try
                    {
                        string userLogin = txtUser.Text;
                        db.connect();
                        db.getLogin(userLogin);
                        db.getConnection.Close();
                        DataTable getuser = new DataTable();
                        db.getDataAdapter.Fill(getuser);
                        string dbUser = getuser.Rows[0]["Username"].ToString();
                        if (userLogin.Equals(dbUser))
                        {
                            db.connect();
                            db.lockUser(userLogin, generateCode());
                            db.getConnection.Close();
                            DataTable unlock = new DataTable();
                            db.getDataAdapter.Fill(unlock);
                            sSMessage.Visible = true;
                            tSSMessage.Text = "Your account has been locked! Please contact the admin";
                        }
                    }
                    catch (IndexOutOfRangeException idx)
                    {
                        tSSMessage.Text = "Try back in 3 minutes later!";
                        speech.Speak(tSSMessage.Text, SpeechVoiceSpeakFlags.SVSFlagsAsync);
                        btnSub.Enabled = false;
                        timer.Enabled = true;
                        timer.Start();
                        count = 3;
                    }
                }
            }
            catch (NullReferenceException e)
            {

            }
            catch (TimeoutException te)
            {
                sSMessage.Visible = true;
                tSSMessage.Text = "Please, reconnect or close and rerun the application!";
            }

            catch (SqlException e)
            {
                MessageBox.Show("Oops! The server was not found or was inaccessible");
            }

        }
        private int validateLogin()
        {
            int flag = 0;
            if (txtUser.Text == "")
            {
                txtUser.Focus();
                errorProvider.SetError(txtUser, "Please, enter your username!");
                flag = 1;
            }
            if (txtPass.Text == "")
            {
                txtPass.Focus();
                errorProvider.SetError(txtPass, "Please, enter your password!");
                flag = 1;
            }
            return flag;
        }

        private void btnSub_Click(object sender, EventArgs e)
        {
            if (validateLogin() == 0)
            {
                errorProvider.Clear();
                connect();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUser.Text = "";
            txtPass.Text = "";
            sSMessage.Visible = false;
        }

        private void linkReg_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string loginAccount = "loginAccount";
            bool departmentStatus = false;
            ExposeProperties.UserLogin = loginAccount;
            ExposeProperties.DepartmentStatus = departmentStatus;
            new UserLogin().Show();
            Hide();
        }

        private void btnSub_MouseDown(object sender, MouseEventArgs e)
        {
            sSMessage.Visible = true;
            tSSMessage.Text = "Confirming your credential...";
        }
        private void linkForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string forgotPassword = "forgotPassword";
            ExposeProperties.UserLogin = forgotPassword;
            new UserLogin().Show();
            Hide();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            duration++;

            sSMessage.Visible = true;
            if (duration > 1)
            {
                tSSMessage.Text = duration.ToString() + " minutes";
            }
            else
            {
                tSSMessage.Text = duration.ToString() + " minute";
            }
            if (duration == 3)
            {
                btnSub.Enabled = true;
                timer.Stop();
                duration = 0;
                sSMessage.Visible = false;
            }
        }

        private void lblOTP_Click(object sender, EventArgs e)
        {
            ExposeProperties.DepartmentName = "NON ADMIN";
            ExposeProperties.TransactionTypeStatus = "OTP";
            new OTP().Show();
        }
        private int validateUnlock()
        {
            int flag = 0;
            if (txtUser.Text.Equals(""))
            {
                txtUser.Focus();
                errorProvider.SetError(txtUser, "Please enter your username!");
                flag = 1;
            }
            return flag;
        }
        private void checkUnlock_CheckedChanged(object sender, EventArgs e)
        {
            if (checkUnlock.Checked == true)
            {
                if (validateUnlock() == 0)
                {
                    if (departmentName.Equals("ADMIN"))
                    {
                        if (txtUser.Text.Equals(comUser) && txtPass.Text.Equals(comPass) && checkUnlock.Checked == true)
                        {
                            ExposeProperties.TransactionTypeStatus = "Login";
                            ExposeProperties.UserLogin = txtUser.Text;
                            ExposeProperties.DepartmentName = departmentName;
                            errorProvider.Clear();
                            new OTP().Show();
                        }
                    }
                    else
                    {
                        ExposeProperties.TransactionTypeStatus = "Login";
                        ExposeProperties.UserLogin = txtUser.Text;
                        ExposeProperties.DepartmentName = "NON ADMIN";
                        errorProvider.Clear();
                        new OTP().Show();
                    }
                }
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            ExposeProperties.ClientID = getClientID();
            clientID = getClientID();
        }
    }
}
