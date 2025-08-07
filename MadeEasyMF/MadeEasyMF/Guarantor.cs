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
using System.IO;
using DatabaseLibrary;

namespace SoftlightMF
{
    public partial class Guarantor : Form
    {
        private DatabaseLib db = new DatabaseLib();
        private DataTable table;
        private DataSet dataSet;
        private string imgLoc = null;
        private long accNumber;
        private string gender, sub;
        private OpenFileDialog openPassport;
        private BinaryReader reader;
        private FileStream file;
        private byte[] img;
        public Guarantor()
        {
            InitializeComponent();
            openPassport = new OpenFileDialog();
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
        private void guarantorDetails()
        {
            try
            {
                db.connect();
                db.guarantorDetails(ExposeProperties.AccNumber, txtFName.Text, txtMName.Text, txtLName.Text,
                txtAddress.Text, txtPhone.Text, getGender(gender));
                db.getConnection.Close();
                table = new DataTable();
                db.getDataAdapter.Fill(table);

                insertPassport();
                insertSignature();
            }
            catch (SqlException ex)
            {

            }
        }
        private void updateGuarantor()
        {
            try
            {
                txtAccNo.Text = ExposeProperties.AccNumber.ToString();
                long accNo = long.Parse(txtAccNo.Text);
                db.connect();
                db.updateGuarantor(accNo, txtFName.Text, txtMName.Text, txtLName.Text,
                txtAddress.Text, txtPhone.Text, getGender(gender));
                db.getConnection.Close();
                dataSet = new DataSet();
                db.getDataAdapter.Fill(dataSet, "Guarantor");

                //Photo session
                updatePhoto(accNo);
                updateGuarantorSignature(accNo);
            }
            catch (SqlException ex)
            {

            }
        }
        private void insertPassport()
        {
            accNumber = Convert.ToInt64(ExposeProperties.AccNumber);
            byte[] img;
            try
            {
                if (picGuarantor.Image == null)
                {
                    imgLoc = "C:\\HP PC\\Pictures\\Softlight Logo.png";
                    file = new FileStream(imgLoc, FileMode.Open, FileAccess.Read);
                    reader = new BinaryReader(file);
                    img = reader.ReadBytes((int)file.Length);
                    db.connect();
                    db.insertGuarantorPhoto(accNumber, img);
                    db.getConnection.Close();
                    DataTable tb = new DataTable();
                    db.getDataAdapter.Fill(tb);
                }
                else
                {
                    imgLoc = openPassport.FileName;
                    picGuarantor.ImageLocation = imgLoc.ToString();
                    file = new FileStream(imgLoc, FileMode.Open, FileAccess.Read);
                    reader = new BinaryReader(file);
                    img = reader.ReadBytes((int)file.Length);
                    db.connect();
                    db.insertGuarantorPhoto(accNumber, img);
                    db.getConnection.Close();
                    table = new DataTable();
                    db.getDataAdapter.Fill(table);
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
        private void insertSignature()
        {
            try
            {
                long accountNo = Convert.ToInt64(txtAccNo.Text);
                if (picSignature.Image != null)
                {
                    imgLoc = open.FileName;
                    picSignature.ImageLocation = imgLoc.ToString();
                    file = new FileStream(imgLoc, FileMode.Open, FileAccess.Read);
                    reader = new BinaryReader(file);
                    img = (byte[])reader.ReadBytes((int)file.Length);
                    db.connect();
                    db.guarantorSignature(accountNo, img);
                    db.getConnection.Close();
                    DataTable tb2 = new DataTable();
                    db.getDataAdapter.Fill(tb2);
                }
                else
                {
                    imgLoc = "C:\\HP PC\\Pictures\\Softlight Logo.png";
                    file = new FileStream(imgLoc, FileMode.Open, FileAccess.Read);
                    reader = new BinaryReader(file);
                    img = reader.ReadBytes((int)file.Length);
                    db.connect();
                    db.guarantorSignature(accountNo, img);
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
        private void updatePhoto(long accNo)
        {
            try
            {
                accNo = Convert.ToInt64(txtAccNo.Text);
                byte[] img;

                db.connect();
                db.getPhoto(accNo);
                db.getConnection.Close();
                table = new DataTable();
                db.getDataAdapter.Fill(table);
                long accountNo2 = (long)table.Rows[0]["AccountNumber"];

                if (accNo == accountNo2)
                {
                    if (picGuarantor.Image == null)
                    {
                        img = null;
                        db.connect();
                        db.updateGuarantorPhoto(accNo, img);
                        db.getConnection.Close();
                        table = new DataTable();
                        db.getDataAdapter.Fill(table);
                    }
                    else
                    {
                        FileStream file = new FileStream(imgLoc, FileMode.Open, FileAccess.Read);
                        BinaryReader reader = new BinaryReader(file);
                        img = reader.ReadBytes((int)file.Length);
                        db.connect();
                        db.updateGuarantorPhoto(accNo, img);
                        db.getConnection.Close();
                        table = new DataTable();
                        db.getDataAdapter.Fill(table);
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
        }
        private void updateGuarantorSignature(long accNo)
        {
            try
            {
                long accountNo = Convert.ToInt64(txtAccNo.Text);
                db.connect();
                db.getGuarantorSignature(accountNo);
                db.getConnection.Close();
                table = new DataTable();
                db.getDataAdapter.Fill(table);
                long accountNo2 = (long)table.Rows[0]["AccountNumber"];

                if (accountNo == accountNo2)
                {
                    if (picSignature.Image != null)
                    {
                        imgLoc = open.FileName;
                        picSignature.ImageLocation = imgLoc.ToString();
                        file = new FileStream(imgLoc, FileMode.Open, FileAccess.Read);
                        reader = new BinaryReader(file);
                        img = (byte[])reader.ReadBytes((int)file.Length);
                        db.connect();
                        db.updateGuarantorSignature(accountNo, img);
                        db.getConnection.Close();
                        DataTable tb2 = new DataTable();
                        db.getDataAdapter.Fill(tb2);
                    }
                    else
                    {
                        imgLoc = "C:\\HP PC\\Pictures\\Softlight Logo.png";
                        file = new FileStream(imgLoc, FileMode.Open, FileAccess.Read);
                        reader = new BinaryReader(file);
                        img = reader.ReadBytes((int)file.Length);
                        db.connect();
                        db.updateGuarantorSignature(accountNo, img);
                        db.getConnection.Close();
                        DataTable tb = new DataTable();
                        db.getDataAdapter.Fill(tb);
                    }
                }
            }
            catch (SqlException sql)
            {
                //MessageBox.Show(sql.Message);
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
                db.getGuarantorPhoto(accountNo);
                db.getConnection.Close();
                table = new DataTable();
                db.getDataAdapter.Fill(table);
                byte[] img = (byte[])table.Rows[0]["Photo"];
                MemoryStream memory = new MemoryStream(img);
                picGuarantor.Image = Image.FromStream(memory);
            }
            catch (ArgumentException ex)
            {
                //MessageBox.Show(ex.Message);
            }

        }
        private void retrieveSignature(long accountNo)
        {
            try
            {
                db.connect();
                db.getGuarantorSignature(accountNo);
                db.getConnection.Close();
                table = new DataTable();
                db.getDataAdapter.Fill(table);
                byte[] img = (byte[])table.Rows[0]["Signature"];
                MemoryStream memory = new MemoryStream(img);
                picSignature.Image = Image.FromStream(memory);
            }
            catch (ArgumentException ex)
            {
                //MessageBox.Show(ex.Message);
            }

        }
        private void guarant(long accNumber)
        {
            string fName, mName, lName, address, phone, gender = null;
            try
            {
                //Guarantor connection
                db.connect();
                db.guarantorExist(accNumber);
                db.getConnection.Close();
                DataTable guarantor = new DataTable();
                db.getDataAdapter.Fill(guarantor);
                long accNo = (long)guarantor.Rows[0]["AccountNumber"];

                //Guarantor details
                if (accNumber == accNo)
                {
                    txtAccNo.Text = ExposeProperties.AccNumber.ToString();
                    txtAccNo.Enabled = false;
                    fName = guarantor.Rows[0]["FirstName"].ToString();
                    mName = guarantor.Rows[0]["MiddleName"].ToString();
                    lName = guarantor.Rows[0]["LastName"].ToString();
                    address = guarantor.Rows[0]["Address"].ToString();
                    phone = guarantor.Rows[0]["PhoneNumber"].ToString();
                    gender = guarantor.Rows[0]["Gender"].ToString();

                    //Forward details
                    txtFName.Text = fName;
                    txtMName.Text = mName;
                    txtLName.Text = lName;
                    txtAddress.Text = address;
                    txtPhone.Text = phone;
                    comboGender.Text = gender;

                    //Passport/Signature session
                    retrievePhoto(accNumber);
                }
            }
            catch (IndexOutOfRangeException idx)
            {
                MessageBox.Show("Please enter guarantor's details!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void btnDisburse_Click(object sender, EventArgs e)
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
                            txtAccNo.Text = ExposeProperties.AccNumber.ToString();
                            long accNo = long.Parse(txtAccNo.Text);
                            db.connect();
                            db.guarantorExist(accNo);
                            db.getConnection.Close();
                            dataSet = new DataSet();
                            db.getDataAdapter.Fill(dataSet, "Guarantor");
                            long accNumber2 = (long)dataSet.Tables["Guarantor"].Rows[0]["AccountNumber"];
                            if (ExposeProperties.AccNumber == accNumber2)
                            {
                                updateGuarantor();
                                new DisbursementDetails().Show();
                                Hide();
                            }
                        }
                        catch (IndexOutOfRangeException ex)
                        {
                            guarantorDetails();
                            new DisbursementDetails().Show();
                            Hide();
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
            txtFName.Text = "";
            txtAddress.Text = "";
            txtLName.Text = "";
            txtMName.Text = "";
            txtPhone.Text = "";
            comboGender.Text = "";
        }
        private void Guarantor_Load(object sender, EventArgs e)
        {
            guarant(ExposeProperties.AccNumber);
        }
        private void btnPassport_Click(object sender, EventArgs e)
        {
            openPassport.Title = "Select Customer Passport";
            openPassport.Filter = "JPG Files(*.jpg)|*.jpg|GIF Files(*.gif)|*.gif|All Files(*.*)|*.*";
            if (openPassport.ShowDialog() == DialogResult.OK)
            {
                imgLoc = openPassport.FileName;
                picGuarantor.ImageLocation = imgLoc.ToString();
            }
        }
        private void btnCheck_Click(object sender, EventArgs e)
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
                        accNumber = long.Parse(txtAccNo.Text);
                        guarant(accNumber);
                        txtAccNo.Enabled = true;
                        txtAccNo.Text = accNumber.ToString();

                        btnDisburse.Text = "Update";
                        if (btnDisburse.Text == "Update")
                        {
                            updateGuarantor();
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
        private void linkApp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Disbursement().Show();
            Hide();
        }

        private void btnSignature_Click(object sender, EventArgs e)
        {
            open.Title = "Select Guarantor's Signature";
            open.Filter = "JPG Files(*.jpg)|*.jpg|GIF Files(*.gif)|*.gif|All Files(*.*)|*.*";
            if (open.ShowDialog() == DialogResult.OK)
            {
                imgLoc = open.FileName;
                picSignature.ImageLocation = imgLoc.ToString();
            }
        }
    }
}
