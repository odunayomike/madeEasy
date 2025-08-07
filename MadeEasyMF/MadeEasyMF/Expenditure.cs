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
using CrystalDecisions.ReportSource;
using CrystalDecisions.CrystalReports.Engine;

namespace SoftlightMF
{
    public partial class Expenditure : Form
    {
        private DatabaseLib db;
        private DataTable tb;
        private int success;
        private string itemName, benefactor, beneficiary, desc, date, time, interval;
        private long amount;
        TextObject title, display, output;
        public Expenditure()
        {
            InitializeComponent();
            radLogExpenditure.Checked = true;
            getExpenditureItem();
            dateTimeLogExpenditure.Text = new Home().databaseDate().ToString();
        }
        private void radLogExpenditure_CheckedChanged(object sender, EventArgs e)
        {
            comboItem.Visible = true;
            panExpense.Visible = true;
            this.Size = new Size(529, 330);
            panGridView.Visible = false;
            panNavigate.Location = new Point(400, 9);
            lblTitle.Location = new Point(167, 3);
            if(radLogExpenditure.Checked == false)
            {
                comboItem.Visible = false;
                comboInterval.Visible = false;
                dateTimePicker.Visible = false;
                btnSearch.Visible = false;
                panExpense.Visible = false;
                panAdmin.Visible = false;
                panGridView.Visible = false;
            }
        }
        private void radRegisterItem_CheckedChanged(object sender, EventArgs e)
        {
            panAdmin.Visible = true;
            this.Size = new Size(529, 330);
            panNavigate.Location = new Point(400, 9);
            lblTitle.Location = new Point(167, 3);
            panGridView.Visible = false;
            if (radRegisterItem.Checked == false)
            {
                comboItem.Visible = false;
                comboInterval.Visible = false;
                dateTimePicker.Visible = false;
                btnSearch.Visible = false;
                panExpense.Visible = false;
                panAdmin.Visible = false;
                panGridView.Visible = false;
            }
        }
        private void radItem_CheckedChanged(object sender, EventArgs e)
        {
            comboItem.Visible = true;
            comboInterval.Visible = true;
            dateTimePicker.Visible = true;
            panGridView.Location = new Point(12, 97);
            panGridView.Size = new Size(801, 388);
            expenditureViewer.Size = new Size(801, 388);
            this.Size = new Size(845, 527);
            panNavigate.Location = new Point(700, 9);
            lblTitle.Location = new Point(335, 3);
            btnSearch.Visible = true;
            comboInterval.Items.Remove("All");
            comboInterval.Text = "SELECT INTERVAL";
            errorProvider.Clear();
            //this.StartPosition = FormStartPosition.CenterScreen;
            if(radItem.Checked == false)
            {
                comboItem.Visible = false;
                comboInterval.Visible = false;
                dateTimePicker.Visible = false;
                panGridView.Visible = false;
                panGridView.Location =  new Point(13, 219);
                this.Size = new Size(529, 330);
                btnSearch.Visible = false;
                comboInterval.Items.Add("All");
                comboItem.Text = "SELECT ITEM";
                comboInterval.Text = "SELECT INTERVAL";
            }
        }
        private void radDate_CheckedChanged(object sender, EventArgs e)
        {
            comboInterval.Visible = true;
            dateTimePicker.Visible = true;
            panGridView.Location = new Point(12, 97);
            panGridView.Size = new Size(801, 388);
            expenditureViewer.Size = new Size(801, 388);
            this.Size = new Size(845, 527);
            panNavigate.Location = new Point(700, 9);
            lblTitle.Location = new Point(335, 3);
            btnSearch.Visible = true;
            errorProvider.Clear();
            if (radDate.Checked == false)
            {
                comboItem.Visible = false;
                comboInterval.Visible = false;
                dateTimePicker.Visible = false;
                panGridView.Location = new Point(13, 219);
                this.Size = new Size(529, 330);
                btnSearch.Visible = false;
                comboItem.Text = "SELECT ITEM";
                comboInterval.Text = "SELECT INTERVAL";
            }
        }
        private int validateRegisterItem()
        {
            int flag = 0;
            if(txtItem.Text.Length == 0)
            {
                txtItem.Focus();
                errorProvider.SetError(txtItem, "Please enter expenditure name!");
                flag = 1;
            }
            return flag;
        }
        private int validateLogExpenditure()
        {
            int flag = 0;
            if (comboItem.Text.Equals("SELECT ITEM"))
            {
                comboItem.Focus();
                errorProvider.SetError(comboItem, "Please select expenditure name!");
                flag = 1;
            }
            if (txtBenefactor.Text.Length == 0)
            {
                txtBenefactor.Focus();
                errorProvider.SetError(txtBenefactor, "Please enter beneficiary name!");
                flag = 1;
            }
            if (txtDescription.Text.Length == 0)
            {
                txtDescription.Focus();
                errorProvider.SetError(txtDescription, "Please enter expenditure description!");
                flag = 1;
            }
            if (txtAmount.Text.Length == 0)
            {
                txtAmount.Focus();
                errorProvider.SetError(txtAmount, "Please enter expenditure amount!");
                flag = 1;
            }
            return flag;
        }
        private void registerItem()
        {
            if(validateRegisterItem() == 0)
            {
                errorProvider.Clear();
                db = new DatabaseLib();
                db.connect();
                db.registerItem(txtItem.Text);
                db.getConnection.Close();
                tb = new DataTable();
                db.getDataAdapter.Fill(tb);
                success = (int)tb.Rows[0]["Status"];
                if(success == 0)
                {
                    MessageBox.Show("Expenditure item registered successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtItem.Text = "";
                    comboItem.Items.Clear();
                    getExpenditureItem();
                }
                else
                {
                    MessageBox.Show("Unsuccessful registration, please try again", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void logExpenditure()
        {
            if (validateLogExpenditure() == 0)
            {
                errorProvider.Clear();
                itemName = comboItem.SelectedItem.ToString();
                benefactor = txtBenefactor.Text;
                beneficiary = txtBeneficiary.Text;
                desc = txtDescription.Text;
                amount = long.Parse(txtAmount.Text);
                date = dateTimeLogExpenditure.Value.ToShortDateString();
                time = new Home().databaseDate().ToLongTimeString();
                db = new DatabaseLib();
                db.connect();
                db.logExpenditure(itemName, benefactor, beneficiary, desc, amount, date, time);
                db.getConnection.Close();
                tb = new DataTable();
                db.getDataAdapter.Fill(tb);
                success = (int)tb.Rows[0]["Status"];
                if (success == 0)
                {
                    db.connect();// Vault transaction implementation 
                    db.vaultDebit(ExposeProperties.BranchCode, amount);
                    db.getConnection.Close();
                    DataTable tb2 = new DataTable();
                    db.getDataAdapter.Fill(tb2);

                    MessageBox.Show("Expenditure logged successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    comboItem.Text = "SELECT ITEM";
                    txtBenefactor.Text = "";
                    txtBeneficiary.Text = "";
                    txtDescription.Text = "";
                    txtAmount.Text ="";
                    dateTimeLogExpenditure.Text = new Home().databaseDate().ToString();
                }
                else
                {
                    MessageBox.Show("Unsuccessful log, please try again", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void getExpenditureItem()
        {
            db = new DatabaseLib();
            db.connect();
            db.getExpenditureItem();
            db.getConnection.Close();
            tb = new DataTable();
            db.getDataAdapter.Fill(tb);
            
            foreach(DataRow dr in tb.Rows)
            {
                comboItem.Items.Add(dr["ItemName"]);
            }
        }
        private void getExpenditureByItem()
        {
            Report.CrystalReport.ExpenditureReport expenditure = new Report.CrystalReport.ExpenditureReport();
            db = new DatabaseLib();
            db.connect();
            db.getExpenditureByItem(comboItem.SelectedItem.ToString());
            db.getConnection.Close();
            tb = new DataTable();
            db.getDataAdapter.Fill(tb);
            expenditure.Database.Tables["Expenditure"].SetDataSource(tb);

            title = (TextObject)expenditure.ReportDefinition.ReportObjects["lblTitle"];
            display = (TextObject)expenditure.ReportDefinition.ReportObjects["display"];
            output = (TextObject)expenditure.ReportDefinition.ReportObjects["lblDisplay"];
            title.Text = "Expenditure Report";
            display.Text = "Item";
            
            output.Text = comboItem.Text;

            expenditureViewer.ReportSource = null;
            expenditureViewer.ReportSource = expenditure;
        }
        private void getExpenditureByInterval()
        {
            Report.CrystalReport.ExpenditureReport expenditure = new Report.CrystalReport.ExpenditureReport();
            itemName = comboItem.SelectedItem.ToString();
            interval = comboInterval.SelectedItem.ToString();
            date = dateTimePicker.Value.ToShortDateString();
            db = new DatabaseLib();
            db.connect();
            db.getExpenditureByInterval(itemName, interval, date);
            db.getConnection.Close();
            tb = new DataTable();
            db.getDataAdapter.Fill(tb);
            expenditure.Database.Tables["Expenditure"].SetDataSource(tb);


            title = (TextObject)expenditure.ReportDefinition.ReportObjects["lblTitle"];
            display = (TextObject)expenditure.ReportDefinition.ReportObjects["display"];
            output = (TextObject)expenditure.ReportDefinition.ReportObjects["lblDisplay"];
            title.Text = "Expenditure Report";
            display.Text = comboInterval.Text;
            output.Text = "(MM/DD/YYYY) " + date;

            expenditureViewer.ReportSource = null;
            expenditureViewer.ReportSource = expenditure;
        }
        private void getExpenditureByDate()
        {
            Report.CrystalReport.ExpenditureReport expenditure = new Report.CrystalReport.ExpenditureReport();
            interval = comboInterval.SelectedItem.ToString();
            date = dateTimePicker.Value.ToShortDateString();
            db = new DatabaseLib();
            db.connect();
            db.getExpenditureByDate(interval, date);
            db.getConnection.Close();
            tb = new DataTable();
            db.getDataAdapter.Fill(tb);
            expenditure.Database.Tables["Expenditure"].SetDataSource(tb);

            title = (TextObject)expenditure.ReportDefinition.ReportObjects["lblTitle"];
            display = (TextObject)expenditure.ReportDefinition.ReportObjects["display"];
            output = (TextObject)expenditure.ReportDefinition.ReportObjects["lblDisplay"];
            title.Text = "Expenditure Report";
            display.Text = comboInterval.Text;
            output.Text = "(MM/DD/YYYY) "+ date;

            expenditureViewer.ReportSource = null;
            expenditureViewer.ReportSource = expenditure;
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            db.connect();
            db.getSub(ExposeProperties.ClientID);
            db.getConnection.Close();
            DataTable subMsg = new DataTable();
            db.getDataAdapter.Fill(subMsg);
            string status = subMsg.Rows[0]["Status"].ToString();
            string maintenance = subMsg.Rows[0]["MaintenanceStatus"].ToString();

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
                        if (radLogExpenditure.Checked == true)
                        {
                            DateTime sysDate, dbDate;

                            sysDate = DateTime.Parse(dateTimeLogExpenditure.Value.ToShortDateString());
                            dbDate = DateTime.Parse(new Home().databaseDate().ToShortDateString());

                            int compareDate = (DateTime.Compare(sysDate, dbDate));
                            if (compareDate >= 1)
                            {
                                MessageBox.Show("Sorry, no future date is allowed", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            }
                            else
                            {
                                amount = long.Parse(txtAmount.Text);
                                DateTime dt = new Home().databaseDate();
                                db.connect();// Vault transaction implementation 
                                db.vaultBalance(dt.ToShortDateString(), ExposeProperties.BranchCode);
                                db.getConnection.Close();
                                DataTable vault = new DataTable();
                                db.getDataAdapter.Fill(vault);
                                long vaultwithdrawalBalance = (long)vault.Rows[0]["WithdrawalBalance"];

                                if (amount <= vaultwithdrawalBalance)
                                {
                                    logExpenditure();
                                }
                                else
                                {
                                    MessageBox.Show("Insufficient vault balance", "Balance",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
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
        private void btnRegister_Click(object sender, EventArgs e)
        {
            db.connect();
            db.getSub(ExposeProperties.ClientID);
            db.getConnection.Close();
            DataTable subMsg = new DataTable();
            db.getDataAdapter.Fill(subMsg);
            string status = subMsg.Rows[0]["Status"].ToString();
            string maintenance = subMsg.Rows[0]["MaintenanceStatus"].ToString();

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
                        if (radRegisterItem.Checked == true)
                        {
                            registerItem();
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
        private void btnSearch_Click(object sender, EventArgs e)
        {
            db.connect();
            db.getSub(ExposeProperties.ClientID);
            db.getConnection.Close();
            DataTable subMsg = new DataTable();
            db.getDataAdapter.Fill(subMsg);
            string status = subMsg.Rows[0]["Status"].ToString();
            string maintenance = subMsg.Rows[0]["MaintenanceStatus"].ToString();

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
                        if (radItem.Checked == true)
                        {
                            if (!comboItem.Text.Equals("SELECT ITEM") && comboInterval.Text.Equals("SELECT INTERVAL"))
                            {
                                panGridView.Visible = true;
                                getExpenditureByItem();
                            }
                            else if (!comboItem.Text.Equals("SELECT ITEM") && !comboInterval.Text.Equals("SELECT INTERVAL"))
                            {
                                panGridView.Visible = true;
                                getExpenditureByInterval();
                            }
                            else
                            {
                                MessageBox.Show("Please select the interval and or item first!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else if (radDate.Checked == true)
                        {
                            if (!comboInterval.Text.Equals("SELECT INTERVAL"))
                            {
                                panGridView.Visible = true;
                                getExpenditureByDate();
                            }
                            else
                            {
                                MessageBox.Show("Please select interval first!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void btnPrintExport_Click(object sender, EventArgs e)
        {
            db.getConnection.Close();
            DataTable subMsg = new DataTable();
            db.getDataAdapter.Fill(subMsg);
            string status = subMsg.Rows[0]["Status"].ToString();
            string maintenance = subMsg.Rows[0]["MaintenanceStatus"].ToString();

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
                       //Implementation goes here
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
        private void linkHome_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Home().Show();
            Hide();
        }
        private void linkLogout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Login().Show();
            Hide();
        }
    }
}