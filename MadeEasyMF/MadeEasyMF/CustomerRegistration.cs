using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using DatabaseLibrary;
using System.Net;
using System.Data.SqlClient;

namespace SoftlightMF
{
    public partial class CustomerRegistration : Form
    {
        private DatabaseLib db = new DatabaseLib();
        private DataTable table;
        private FileStream file;
        private BinaryReader reader;
        private DataTable tb;
        private OpenFileDialog openPassport;

        private string accountType, gender = null, sub;
        private long accountNo;
        private string imgLoc = null;
        private byte[] img;
        private DateTime dt;
        private string day, hour, minute, second, month, year, autoAccountNo;
        public CustomerRegistration()
        {
            InitializeComponent();
            dt = databaseDate();
            getAccountOfficer();
            getFilledAccountType();
            getGroupName();
            openPassport = new OpenFileDialog();
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
        private void getFilledAccountType()
        {
            db.connect();
            db.getAccountType();
            db.getConnection.Close();
            DataTable tb = new DataTable();
            db.getDataAdapter.Fill(tb);
            foreach (DataRow dr in tb.Rows)
            {
                comboAccountType.Items.Add(dr["AccountType"].ToString());
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
                table = new DataTable();
                db.getDataAdapter.Fill(table);

                foreach(DataRow dr in table.Rows)
                {
                    comboAccOff.Items.Add(dr["FirstName"].ToString());
                }
            }
            catch(SqlException sql)
            {
                MessageBox.Show(sql.Message);
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
                comboGroupName.Items.Add(dr["GroupName"].ToString());
            }
        }
        private string getGender(string gender)
        {
            if ((string)comboGender.SelectedItem == "Male")
            {
                gender = "Male";
            }
            else
            {
                gender = "Female";
            }
            return gender;
        }
        private string getAccountType()
        {
            accountType = comboAccountType.SelectedItem.ToString();
            return accountType;
        }
        private string accountTypeMessage()
        {
            string message = null;
            if (comboAccountType.SelectedItem != "")
            {
                if (comboAccountType.Text.Equals("COOPERATIVE"))
                {
                    message = "Welcome to Made Easy Cooperative, your account is fully opened. " +
                                "Your account number is " + txtAccNumber.Text + ". Fund your account to enjoy the benefits of cooperative.";

                }
                else if (comboAccountType.Text == "HOMES")
                {

                    message = "Welcome to Made Easy Homes and Properties, your account is fully opened. " +
                                "Your account number is " + txtAccNumber.Text + ".";

                }
                else
                {
                    message = "Welcome to Made Easy Fund Nig. Ltd. Your " + comboAccountType.SelectedItem + " account is fully opened. " +
                                     "Your account number is " + txtAccNumber.Text;
                }
            }
            else
            {
                comboAccountType.Focus();
                errorProvider.SetError(comboAccountType, "Please select account type!");
            }
            return message;
        }
        private void sendTextlocalMessge(string phone)
        {
            string message = accountTypeMessage();//refer to parameters to complete correct url string
            String result;
            string apiKey = "OWyTMbi63GQ-ZaoniypUXRbOuqLx8b4sKWpw5rzQME";
            string phoneNumber = phone; // in a comma seperated list

            string senderName = "MadeEasy";//txtSender.Text;

            String url = "https://api.txtlocal.com/send/?apikey=" + apiKey + "&numbers=234" + phoneNumber + "&message=" + message + "&sender=" + senderName;
            //refer to parameters to complete correct url string

            StreamWriter myWriter = null;
            HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(url);

            objRequest.Method = "POST";
            objRequest.ContentLength = Encoding.UTF8.GetByteCount(url);//objRequest.ContentType = "application/x-www-form-urlencoded";
            try
            {
                myWriter = new StreamWriter(objRequest.GetRequestStream());
                myWriter.Write(url);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                sr.Close();
            }
        }
        private void sendAlertMessage()
        {
            string message = accountTypeMessage(); //refer to parameters to complete correct url string
            String result;
            string numbers = txtPhone.Text; // in a comma seperated list
            string sender = "MadeEasy";

            String url = "http://www.estoresms.com/smsapi.php?username=MadeEasy&password=Ma3caka2ya&sender=" + sender +
                    "&recipient=234" + numbers + "&message=" + message + "&";

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
                MessageBox.Show(nre.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
        private void insertCustDetails()
        {
            try
            {
                long amount = Convert.ToInt64(txtRegAmt.Text);
                string dbAmount = null;
                /*db.connect();
                db.getAccountTypeDetails(comboAccountType.Text.ToString());
                db.getConnection.Close();
                DataTable tb = new DataTable();
                db.getDataAdapter.Fill(tb);
                string dbAmount = tb.Rows[0]["Amount"].ToString();*/

                if(checkBranch.Checked == true)
                {
                    accountNo = long.Parse(getBranchDetails());
                    dbAmount = 0.ToString();
                }
                else
                {
                    accountNo = Convert.ToInt64(txtAccNumber.Text);
                    db.connect();
                    db.getAccountTypeDetails(comboAccountType.Text.ToString());
                    db.getConnection.Close();
                    DataTable tb = new DataTable();
                    db.getDataAdapter.Fill(tb);
                    dbAmount = tb.Rows[0]["Amount"].ToString();
                }
                if (amount != float.Parse(dbAmount))
                {
                    sSMessage.Visible = true;
                    tSSMessage.Text = "Registration amount must be N" + dbAmount;
                }
                else
                {
                    string date, groupName;
                    date = datePicker.Value.ToString("yyyy-MM-dd");
                    groupName = comboGroupName.Text;
                    if (groupName.Equals(""))
                    {
                        groupName = "";
                    }
                    else
                    {
                        groupName = comboGroupName.SelectedItem.ToString();
                    }
                    db.connect();
                    db.customerReg(txtFName.Text, txtMName.Text, txtLName.Text, txtAddress.Text, txtPhone.Text,
                    getGender(gender), accountNo, getAccountType(), comboAccOff.Text, date, groupName);
                    db.getConnection.Close();
                    table = new DataTable();
                    db.getDataAdapter.Fill(table);

                    db.connect();
                    db.regFee(accountNo, amount);
                    db.getConnection.Close();
                    DataTable table2 = new DataTable();
                    db.getDataAdapter.Fill(table2);

                    //insert passport and signature
                    insertPassport();
                    insertSignature();

                    if (checkBranch.Checked == true)
                    {
                        MessageBox.Show("Branch account registered successfully", "Registration",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        errorProvider.Clear();
                        sSMessage.Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("Account( " + accountNo + " ) registered successfully", "Registration",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        errorProvider.Clear();
                        sSMessage.Visible = false;
                    }
                    if (checkAlert.Checked == true)
                    {
                        sendAlertMessage();
                    }
                }
            }
            catch (IndexOutOfRangeException idx)
            {
                MessageBox.Show(idx.Message);
            }
            catch (FormatException fe)
            {
                txtRegAmt.Focus();
                errorProvider.SetError(txtRegAmt, "Please enter the amount");
            }
            //catch (NullReferenceException fe)
            //{
            //    comboGroupName.Text = "";
            //}
        }
        private void confirmAccount()
        {
            if (validateCustDetails() == 0)
            {
                if (checkBranch.Checked == false)
                {
                    try
                    {
                        db.connect();
                        long accountNumber = Convert.ToInt64(txtAccNumber.Text);
                        db.getBalance(accountNumber);
                        db.getConnection.Close();
                        table = new DataTable();
                        db.getDataAdapter.Fill(table);
                        long accNumber = (long)table.Rows[0]["AccountNumber"];

                        if (accountNumber == accNumber)
                        {
                            sSMessage.Visible = true;
                            tSSMessage.Text = "Account already existed!";
                        }
                    }
                    catch (FormatException ex)
                    {
                        txtAccNumber.Focus();
                        errorProvider.SetError(txtAccNumber, "Only number required");
                    }
                    catch (IndexOutOfRangeException e)
                    {
                        insertCustDetails();
                    }
                    catch (SqlException sql)
                    {

                    }
                }
                else
                {
                    insertCustDetails();
                }
            }
        }
        private int validateCustDetails()
        {
            int flag = 0;
            /*if (checkAccNumber.Checked == true && txtAccNumber.Text.Length == 0)
            {
                txtAccNumber.Focus();
                errorProvider.SetError(txtAccNumber, "Please, enter the account number!");
                flag = 1;
            }*/
            if (checkBranch.Checked == true)
            {
                if(comboBranchName.Text == "")
                {
                    comboBranchName.Focus();
                    errorProvider.SetError(comboBranchName, "Please select the branch name!");
                    flag = 1;
                }
            }
            else
            {
                if (txtAccNumber.Text.Length == 0)
                {
                    txtAccNumber.Focus();
                    errorProvider.SetError(txtAccNumber, "Please, enter the account number!");
                    flag = 1;
                }
            }
            if (txtFName.Text == "")
            {
                txtFName.Focus();
                errorProvider.SetError(txtFName, "Please, enter the first name!");
                flag = 1;
            }

            if (txtLName.Text == "")
            {
                txtLName.Focus();
                errorProvider.SetError(txtLName, "Please, enter the last name!");
                flag = 1;
            }

            if (comboGender.Text == "")
            {
                comboGender.Focus();
                errorProvider.SetError(comboGender, "Please, select the gender!");
                flag = 1;
            }
            if (txtRegAmt.Text == "" && btnReg.Text != "Update" && checkBranch.Checked == false)
            {
                txtRegAmt.Focus();
                errorProvider.SetError(txtRegAmt, "Please, enter the registration fee!");
                flag = 1;
            }
            if (txtPhone.Text != "" && txtPhone.TextLength != 10)
            {
                txtPhone.Focus();
                errorProvider.SetError(txtPhone, "Phone number must be 10 digits, please enter the correct phone number!");
                flag = 1;
            }
            if (comboAccOff.Text == "")
            {
                comboAccOff.Focus();
                errorProvider.SetError(comboAccOff, "Please select the account officer's name!");
                flag = 1;
            }
            if (comboAccOff.Text != "")
            {
                try
                {
                    string departmentName = "ACCOUNT OFFICER", accountOfficer = comboAccOff.Text;
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
                    comboAccOff.Focus();
                    errorProvider.SetError(comboAccOff, "Sorry! Account officer's name doesn't exist");
                    flag = 1;
                }
            }
            if (comboAccountType.Text == "")
            {
                comboAccountType.Focus();
                errorProvider.SetError(comboAccountType, "Please select the account type!");
                flag = 1;
            }
            if (comboAccountType.Text != "")
            {
                if (checkBranch.Checked == true)
                {
                    flag = 0;
                }
                else
                {
                    try
                    {
                        string dbAccountType = null, accountType = comboAccountType.Text;
                        db.connect();
                        db.getAccountTypeName(accountType);
                        db.getConnection.Close();
                        tb = new DataTable();
                        db.getDataAdapter.Fill(tb);
                        dbAccountType = tb.Rows[0]["AccountType"].ToString();
                        if (accountType.Equals(dbAccountType))
                        {
                            flag = 0;
                        }
                    }
                    catch (IndexOutOfRangeException idx)
                    {
                        comboAccountType.Focus();
                        errorProvider.SetError(comboAccountType, "Sorry! Account type doesn't exist");
                        flag = 1;
                    }
                }
            }
            /*if (comboBranchName.Text == "")
            {
                comboBranchName.Focus();
                errorProvider.SetError(comboBranchName, "Please select the branch name!");
                flag = 1;
            }
            if (comboBranchName.Text != "")
            {
                try
                {
                    string dbBrachName = null, brachName = comboBranchName.Text;
                    db.connect();
                    db.getBranchName(brachName);
                    db.getConnection.Close();
                    tb = new DataTable();
                    db.getDataAdapter.Fill(tb);
                    dbBrachName = tb.Rows[0]["BranchName"].ToString();
                    if (brachName.Equals(dbBrachName))
                    {
                        flag = 0;
                    }
                }
                catch (IndexOutOfRangeException idx)
                {
                    comboBranchName.Focus();
                    errorProvider.SetError(comboBranchName, "Sorry! Branch name doesn't exist");
                    txtAccNumber.Visible = false;
                    flag = 1;
                }
            }*/
            if (checkGroup.Checked == true && comboGroupName.Text.Equals(""))
            {
                comboGroupName.Focus();
                errorProvider.SetError(comboGroupName, "Please select the group name");
                flag = 1;
            }
            if (comboGroupName.Text != "")
            {
                try
                {
                    string dbGroupName = null, groupName = comboGroupName.Text;
                    db.connect();
                    db.getGroup(groupName);
                    db.getConnection.Close();
                    tb = new DataTable();
                    db.getDataAdapter.Fill(tb);
                    dbGroupName = tb.Rows[0]["GroupName"].ToString();
                    if (groupName.Equals(dbGroupName))
                    {
                        flag = 0;
                    }
                }
                catch (IndexOutOfRangeException idx)
                {
                    comboGroupName.Focus();
                    errorProvider.SetError(comboGroupName, "Sorry! Group name doesn't exist");
                    txtAccNumber.Visible = false;
                    flag = 1;
                }
            }
            if (btnReg.Text == "Update" && txtRegAmt.Text == "")
            {
                flag = 0;
                errorProvider.Clear();
            }
            return flag;
        }
        //Passport session
        private void insertPassport()
        {
            if(checkBranch.Checked == true)
            {
                accountNo = long.Parse(getBranchDetails());
            }
            else
            {
                accountNo = Convert.ToInt64(txtAccNumber.Text);
            }
            try
            {
                if (picCustomer.Image == null)
                {
                    file = new FileStream(picCustomer.Image.ToString(), FileMode.Create, FileAccess.Write);
                    reader = new BinaryReader(file);
                    img = reader.ReadBytes((int)file.Length);
                    db.connect();
                    db.insertPhoto(accountNo, img);
                    db.getConnection.Close();
                    tb = new DataTable();
                    db.getDataAdapter.Fill(tb);
                }
                else
                {
                    imgLoc = openPassport.FileName;
                    picCustomer.ImageLocation = imgLoc.ToString();
                    file = new FileStream(imgLoc, FileMode.Open, FileAccess.Read);
                    reader = new BinaryReader(file);
                    img = reader.ReadBytes((int)file.Length);
                    db.connect();
                    db.insertPhoto(accountNo, img);
                    db.getConnection.Close();
                    tb = new DataTable();
                    db.getDataAdapter.Fill(tb);
                }
            }
            catch (SqlException sql)
            {
                MessageBox.Show(sql.Message);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }
        private void updatePhoto(long accountNo)
        {
            try
            {
                accountNo = Convert.ToInt64(txtAccNumber.Text);

                db.connect();
                db.getPhoto(accountNo);
                db.getConnection.Close();
                table = new DataTable();
                db.getDataAdapter.Fill(table);
                long accountNo2 = (long)table.Rows[0]["AccountNumber"];

                if (accountNo == accountNo2)
                {
                    if (picCustomer.Image == null)
                    {
                        imgLoc = "C:\\HP PC\\Pictures\\Softlight Logo.png";
                        file = new FileStream(imgLoc, FileMode.Open, FileAccess.Read);
                        reader = new BinaryReader(file);
                        img = reader.ReadBytes((int)file.Length);
                        db.connect();
                        db.updatePhoto(accountNo, img);
                        db.getConnection.Close();
                        tb = new DataTable();
                        db.getDataAdapter.Fill(tb);
                    }
                    else
                    {
                        imgLoc = openPassport.FileName;
                        picCustomer.ImageLocation = imgLoc.ToString();
                        FileStream file = new FileStream(imgLoc, FileMode.Open, FileAccess.Read);
                        BinaryReader reader = new BinaryReader(file);
                        img = reader.ReadBytes((int)file.Length);
                        db.connect();
                        db.updatePhoto(accountNo, img);
                        db.getConnection.Close();
                        DataTable tb2 = new DataTable();
                        db.getDataAdapter.Fill(tb2);
                    }
                }
            }
            catch (IndexOutOfRangeException idx)
            {
                insertPassport();
            }
            catch (ArgumentException ae)
            {

            }
            catch (SqlException sql)
            {

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }
        private void updateSignature(long accountNo)
        {
            try
            {
                accountNo = Convert.ToInt64(txtAccNumber.Text);

                db.connect();
                db.getSignature(accountNo);
                db.getConnection.Close();
                table = new DataTable();
                db.getDataAdapter.Fill(table);
                long accountNo2 = (long)table.Rows[0]["AccountNumber"];

                if (accountNo == accountNo2)
                {
                    if (picSign.Image == null)
                    {
                        imgLoc = "C:\\HP PC\\Pictures\\Softlight Logo.png";
                        file = new FileStream(imgLoc, FileMode.Open, FileAccess.Read);
                        reader = new BinaryReader(file);
                        img = reader.ReadBytes((int)file.Length);
                        db.connect();
                        db.updateSignature(accountNo, img);
                        db.getConnection.Close();
                        tb = new DataTable();
                        db.getDataAdapter.Fill(tb);
                    }
                    else
                    {
                        imgLoc = open.FileName;
                        picSign.ImageLocation = imgLoc.ToString();
                        FileStream file = new FileStream(imgLoc, FileMode.Open, FileAccess.Read);
                        BinaryReader reader = new BinaryReader(file);
                        img = reader.ReadBytes((int)file.Length);
                        db.connect();
                        db.updateSignature(accountNo, img);
                        db.getConnection.Close();
                        DataTable tb2 = new DataTable();
                        db.getDataAdapter.Fill(tb2);
                    }
                }
            }
            catch (IndexOutOfRangeException idx)
            {
                insertSignature();
            }
            catch (ArgumentException ae)
            {

            }
            catch (SqlException sql)
            {

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }
        private void retrievePhoto(long accountNo)
        {
            try
            {
                db.connect();
                db.getPhoto(accountNo);
                db.getConnection.Close();
                table = new DataTable();
                db.getDataAdapter.Fill(table);
                img = (byte[])table.Rows[0]["Photo"];
                MemoryStream memory = new MemoryStream(img);
                picCustomer.Image = Image.FromStream(memory);
            }
            catch (Exception ex)
            {

            }

        }
        //Signature session
        private void insertSignature()
        {
            try
            {
                if (checkBranch.Checked == true)
                {
                    accountNo = long.Parse(getBranchDetails());
                }
                else
                {
                    accountNo = Convert.ToInt64(txtAccNumber.Text);
                }
                if (picSign.Image != null)
                {
                    imgLoc = open.FileName;
                    picSign.ImageLocation = imgLoc.ToString();
                    file = new FileStream(imgLoc, FileMode.Open, FileAccess.Read);
                    reader = new BinaryReader(file);
                    img = (byte[])reader.ReadBytes((int)file.Length);
                    db.connect();
                    db.insertSignature(accountNo, img);
                    db.getConnection.Close();
                    tb = new DataTable();
                    db.getDataAdapter.Fill(tb);
                }
                else
                {
                    imgLoc = open.FileName;
                    file = new FileStream(imgLoc, FileMode.Open, FileAccess.Read);
                    reader = new BinaryReader(file);
                    img = reader.ReadBytes((int)file.Length);
                    db.connect();
                    db.insertSignature(accountNo, img);
                    db.getConnection.Close();
                    DataTable tb = new DataTable();
                    db.getDataAdapter.Fill(tb);
                }
            }
            catch (SqlException sql)
            {
                MessageBox.Show(sql.Message);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
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
                img = (byte[])tb.Rows[0]["Signature"];
                MemoryStream memory = new MemoryStream(img);
                picSign.Image = Image.FromStream(memory);
            }
            catch (Exception ex)
            {

            }
        }
        private void btnReg_Click(object sender, EventArgs e)
        {
            if (validateCustDetails() == 0)
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
                            if (btnReg.Text == "Register")
                            {
                                confirmAccount();
                            }
                            else
                            {
                                try
                                {
                                    long accountNo = Convert.ToInt64(txtAccNumber.Text);

                                    string fName = txtFName.Text, mName = txtMName.Text, lName = txtLName.Text;
                                    string address = txtAddress.Text, phone = txtPhone.Text, accOfficer = comboAccOff.Text, groupName;
                                    groupName = comboGroupName.Text;
                                    if (groupName.Equals(""))
                                    {
                                        groupName = "";
                                    }
                                    else
                                    {
                                        groupName = comboGroupName.SelectedItem.ToString();
                                    }
                                    db.connect();
                                    db.editCustomer(fName, mName, lName, address, phone, getGender(gender), accountNo, getAccountType(), accOfficer, groupName);
                                    db.getConnection.Close();
                                    table = new DataTable();
                                    db.getDataAdapter.Fill(table);
                                    updatePhoto(accountNo);
                                    updateSignature(accountNo);

                                    sSMessage.Visible = true;
                                    tSSMessage.Text = "Customer details updated!";
                                    if (checkAlert.Checked == true)
                                    {
                                        sendAlertMessage();
                                    }
                                }
                                catch (FormatException ex)
                                {
                                    MessageBox.Show("Number required!");
                                }
                                catch (NullReferenceException nre)
                                {

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
        private void btnDepClear_Click(object sender, EventArgs e)
        {
            txtAccNumber.Text = "";
            txtAddress.Text = "";
            txtFName.Text = "";
            txtLName.Text = "";
            txtMName.Text = "";
            txtPhone.Text = "";
            accountType = "";
            txtRegAmt.Text = "";
            comboAccOff.Text = "";
            comboGroupName.Text = "";
            picCustomer.Image = null;
            errorProvider.Clear();
        }
        private void btnPassport_Click(object sender, EventArgs e)
        {
            openPassport.Title = "Select Customer's Passport";
            openPassport.Filter = "JPG Files(*.jpg)|*.jpg|GIF Files(*.gif)|*.gif|All Files(*.*)|*.*";
            if (openPassport.ShowDialog() == DialogResult.OK)
            {
                imgLoc = openPassport.FileName;
                picCustomer.ImageLocation = imgLoc.ToString();
            }
        }
        private void btnSign_Click(object sender, EventArgs e)
        {
            open.Title = "Select Customer's Signature";
            open.Filter = "JPG Files(*.jpg)|*.jpg|GIF Files(*.gif)|*.gif|All Files(*.*)|*.*";
            if (open.ShowDialog() == DialogResult.OK)
            {
                imgLoc = open.FileName;
                picSign.ImageLocation = imgLoc.ToString();
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
                        try
                        {
                            string fName, mName, lName, address, phone, gender, accountTypedb, accOfficer, groupName;
                            long accountNo;
                            accountNo = Convert.ToInt64(txtAccSearch.Text);
                            db.connect();
                            db.editCustSelection(accountNo);
                            db.getConnection.Close();
                            table = new DataTable();
                            db.getDataAdapter.Fill(table);

                            fName = table.Rows[0]["FirstName"].ToString();
                            mName = table.Rows[0]["MiddleName"].ToString();
                            lName = table.Rows[0]["LastName"].ToString();
                            address = table.Rows[0]["Address"].ToString();
                            phone = table.Rows[0]["PhoneNumber"].ToString();
                            gender = table.Rows[0]["Gender"].ToString();
                            accountTypedb = table.Rows[0]["AccountType"].ToString();
                            accOfficer = table.Rows[0]["AccountOfficer"].ToString();
                            long accountNo2 = (long)table.Rows[0]["AccountNumber"];
                            groupName = table.Rows[0]["GroupName"].ToString();

                            if (accountNo == accountNo2)
                            {
                                if (accountTypedb.Equals("BRANCH") || accountTypedb.Equals("HEAD OFFICE"))
                                {
                                    MessageBox.Show("Sorry, you can't edit this account", "Can't Edit",
                                        MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                }
                                else
                                {
                                    txtFName.Text = fName;
                                    txtMName.Text = mName;
                                    txtLName.Text = lName;
                                    txtAddress.Text = address;
                                    txtPhone.Text = phone;
                                    comboGender.Text = gender;
                                    txtAccNumber.Text = accountNo.ToString();
                                    comboAccOff.Text = accOfficer;
                                    comboAccountType.Text = accountTypedb.ToUpper();
                                    comboGroupName.Text = groupName;

                                    retrievePhoto(accountNo);
                                    retrieveSignature(accountNo);

                                    panAccNo.Visible = false;
                                    tableLayoutPanel.Visible = true;
                                    panel2.Visible = true;
                                    btnReg.Visible = true;
                                    btnDepClear.Visible = true;
                                    btnPassport.Visible = true;
                                    pan.Visible = true;
                                    panGroup.Visible = true;
                                    checkGroup.Visible = true;
                                }
                            }
                            sSMessage.Visible = false;
                        }
                        catch (FormatException ex)
                        {
                            txtAccSearch.Focus();
                            errorProvider.SetError(txtAccSearch, "Only number required");
                        }
                        catch (ArgumentException ae)
                        {
                            MessageBox.Show(ae.Message);
                        }
                        catch (IndexOutOfRangeException ex)
                        {
                            sSMessage.Visible = true;
                            tSSMessage.Text = "Invalid account number!";
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
        private void editCustomer_CheckedChanged(object sender, EventArgs e)
        {
            btnReg.Text = "Update";
            regEdit.Text = "Edit Customer";
            lblDate.Visible = false;
            datePicker.Visible = false;
            panAccNo.Visible = true;
            tableLayoutPanel.Visible = false;
            panel2.Visible = false;
            btnReg.Visible = false;
            btnDepClear.Visible = false;
            btnPassport.Visible = false;
            pan.Visible = false;
            checkAlert.Checked = false;
            panGroup.Visible = false;
            checkGroup.Visible = false;
            checkBranch.Visible = false;
            comboBranchName.Visible = false;
            lblLName.Text = "Last Name";
            txtLName.Enabled = true;

            if (editCustomer.Checked == false)
            {
                btnReg.Text = "Register";
                regEdit.Text = "Customer Registratrion";
                txtAccNumber.Text = "";
                txtAddress.Text = "";
                txtFName.Text = "";
                txtLName.Text = "";
                txtMName.Text = "";
                txtPhone.Text = "";
                comboGender.Text = "";
                lblDate.Visible = true;
                datePicker.Visible = true;
                picCustomer.Image = null;
                picSign.Image = null;

                errorProvider.Clear();

                panAccNo.Visible = false;
                tableLayoutPanel.Visible = true;
                panel2.Visible = true;
                btnReg.Visible = true;
                btnDepClear.Visible = true;
                btnPassport.Visible = true;
                pan.Visible = true;
                panGroup.Visible = true;
                if(ExposeProperties.DepartmentName.Equals("ADMIN"))
                {
                    checkBranch.Visible = true;
                }
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
        /*private void comboBranchName_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtAccNumber.Text = getBranchDetails();

            if (comboBranchName.SelectedItem.Equals(""))
            {
                lblAccountNumber.Visible = false;
                txtAccNumber.Visible = false;
            }
        }*/
        private void checkGroup_CheckedChanged(object sender, EventArgs e)
        {
            groupName.Visible = true;
            if (checkGroup.Checked == false)
            {
                groupName.Visible = false;
            }
        }
        private void CustomerRegistration_Load(object sender, EventArgs e)
        {
            datePicker.Value = dt;
            if(ExposeProperties.DepartmentName.Equals("ADMIN"))
            {
                checkBranch.Visible = true;
                getBranchName();
            }
        }
        private string getBranchDetails()
        {
            string accountNo = null, sendAccountNo = null;
            DateTime dt = databaseDate();
            day = dt.Day.ToString();
            hour = dt.Hour.ToString();
            minute = dt.Minute.ToString();
            second = dt.Second.ToString();
            month = dt.Month.ToString();
            year = dt.Year.ToString();
            autoAccountNo = month + minute + hour + second + day;
            try
            {
                db.connect();
                db.getBranchDetails(comboBranchName.SelectedItem.ToString());
                db.getConnection.Close();
                DataTable tb = new DataTable();
                db.getDataAdapter.Fill(tb);
                string branchCode = tb.Rows[0]["BranchCode"].ToString();

                if (autoAccountNo.Length == 10 && branchCode.Length == 1)
                {
                    accountNo = autoAccountNo.Remove(1, 1);
                }
                else if (autoAccountNo.Length == 10 && branchCode.Length == 2)
                {
                    accountNo = autoAccountNo.Remove(1, 2);
                }
                else if (autoAccountNo.Length == 10 && branchCode.Length == 3)
                {
                    accountNo = autoAccountNo.Remove(0, 3);
                }
                else if (autoAccountNo.Length == 9 && branchCode.Length == 1)
                {
                    accountNo = autoAccountNo;
                }
                else if (autoAccountNo.Length == 9 && branchCode.Length == 2)
                {
                    accountNo = autoAccountNo.Remove(0, 1);
                }
                else if (autoAccountNo.Length == 9 && branchCode.Length == 3)
                {
                    accountNo = autoAccountNo.Remove(2, 2);
                }
                else if (autoAccountNo.Length == 8 && branchCode.Length == 1)
                {
                    accountNo = autoAccountNo + "9";
                }
                else if (autoAccountNo.Length == 8 && branchCode.Length == 2)
                {
                    accountNo = autoAccountNo;
                }
                else if (autoAccountNo.Length == 8 && branchCode.Length == 3)
                {
                    accountNo = autoAccountNo.Remove(1, 1);
                }
                else if (autoAccountNo.Length == 7 && branchCode.Length == 1)
                {
                    accountNo = autoAccountNo + "13";
                }
                else if (autoAccountNo.Length == 7 && branchCode.Length == 2)
                {
                    accountNo = autoAccountNo + "0";
                }
                else if (autoAccountNo.Length == 7 && branchCode.Length == 3)
                {
                    accountNo = autoAccountNo;
                }
                else if (autoAccountNo.Length == 6 && branchCode.Length == 1)
                {
                    accountNo = autoAccountNo + "802";
                }
                else if (autoAccountNo.Length == 6 && branchCode.Length == 2)
                {
                    accountNo = autoAccountNo + "01";
                }
                else if (autoAccountNo.Length == 6 && branchCode.Length == 3)
                {
                    accountNo = autoAccountNo + "5";
                }
                if (autoAccountNo.Length == 5 && branchCode.Length == 1)
                {
                    accountNo = autoAccountNo + year;
                }
                if (autoAccountNo.Length == 5 && branchCode.Length == 2)
                {
                    accountNo = autoAccountNo + "391";
                }
                else if (autoAccountNo.Length == 5 && branchCode.Length == 3)
                {
                    accountNo = autoAccountNo + "67";
                }
                sendAccountNo = (branchCode + accountNo).ToString();
            }
            catch (IndexOutOfRangeException idx)
            {
                sSMessage.Visible = true;
                tSSMessage.Text = "Please, create a branch before registering a customer";
            }
            return sendAccountNo;
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
                comboBranchName.Items.Add(dr["BranchName"].ToString());
            }
        }
        private void checkBranch_CheckedChanged(object sender, EventArgs e)
        {
            comboBranchName.Visible = true;
            checkGroup.Enabled = false;
            panGroup.Visible = false;
            comboAccountType.Items.Clear();
            comboAccountType.Items.Add("BRANCH");
            lblAccountNumber.Visible = false;
            txtAccNumber.Visible = false;
            lblLName.Text = "Branch Name";
            txtLName.Enabled = false;
            if(checkBranch.Checked == false)
            {
                comboAccountType.Items.Clear();
                getFilledAccountType();
                comboBranchName.Visible = false;
                lblAccountNumber.Visible = true;
                txtAccNumber.Visible = true;
                checkGroup.Enabled = true;
                panGroup.Visible = true;
                lblLName.Text = "Last Name";
                txtLName.Enabled = true;
            }
        }
        private void comboBranchName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!comboBranchName.Text.Equals(""))
            {
                txtLName.Text = comboBranchName.SelectedItem.ToString();
            }
        }
        /*private void checkAccNumber_CheckedChanged(object sender, EventArgs e)
        {
            txtAccNumber.Enabled = true;
            if (checkAccNumber.Checked == false)
            {
                txtAccNumber.Enabled = false;
            }
        }*/
    }
}
