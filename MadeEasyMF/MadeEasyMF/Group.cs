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
    public partial class Group : Form
    {
        private DatabaseLib db = new DatabaseLib();
        private string groupName, leaderName, Secretary, location, sub;
        public Group()
        {
            InitializeComponent();
            getGroupName();
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
        private void createGroup()
        {
            try
            {
                groupName = txtGroupName.Text;
                db.connect();
                db.existGroup(groupName);
                db.getConnection.Close();
                DataTable tbExist = new DataTable();
                db.getDataAdapter.Fill(tbExist);
                string dbGroupName = tbExist.Rows[0]["GroupName"].ToString();

                if (groupName.Equals(dbGroupName))
                {
                    sSMessage.Visible = true;
                    tSSMessage.Text = "Sorry, group name already existed";
                }
            }
            catch (IndexOutOfRangeException idx)
            {
                groupName = txtGroupName.Text.ToUpper();
                leaderName = txtLeaderName.Text.ToUpper();
                Secretary = txtSecretaryName.Text.ToUpper();
                location = richTxtLocation.Text.ToUpper();
                db.connect();
                db.insertGroup(groupName, leaderName, Secretary, location);
                db.getConnection.Close();
                DataTable tb = new DataTable();
                db.getDataAdapter.Fill(tb);

                MessageBox.Show("Group created successfully", "Info",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                new Group().Show();
                Hide();
            }
        }
        private void updateGroup()
        {
            txtGroupName.Enabled = false;
            groupName = txtGroupName.Text;
            leaderName = txtLeaderName.Text.ToUpper();
            Secretary = txtSecretaryName.Text.ToUpper();
            location = richTxtLocation.Text.ToUpper();
            db.connect();
            db.updateGroup(groupName, leaderName, Secretary, location);
            db.getConnection.Close();
            DataTable tb = new DataTable();
            db.getDataAdapter.Fill(tb);
            MessageBox.Show("Group details updated successfully", "Info", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            new Group().Show();
            Hide();
        }
        private int validateGroup()
        {
            int flag = 0;
            if (txtGroupName.Text.Equals(""))
            {
                txtGroupName.Focus();
                errorProvider.SetError(txtGroupName, "Please, enter the group name!");
                flag = 1;
            }
            if (txtLeaderName.Text.Equals(""))
            {
                txtLeaderName.Focus();
                errorProvider.SetError(txtLeaderName, "Please, enter the leader's name!");
                flag = 1;
            }
            if (txtSecretaryName.Text.Equals(""))
            {
                txtSecretaryName.Focus();
                errorProvider.SetError(txtSecretaryName, "Please, enter the secretary's name!");
                flag = 1;
            }
            if (richTxtLocation.Text.Equals(""))
            {
                richTxtLocation.Focus();
                errorProvider.SetError(richTxtLocation, "Please, enter the group location!");
                flag = 1;
            }
            return flag;
        }
        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (validateGroup() == 0)
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
                            if (btnCreate.Text == "Create")
                            {
                                createGroup();
                            }
                            else
                            {
                                updateGroup();
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
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtGroupName.Text = "";
            txtLeaderName.Text = "";
            txtSecretaryName.Text = "";
            richTxtLocation.Text = "";
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
        private void loadGroupDetails(string groupName)
        {
            try
            {
                btnCreate.Text = "Update";
                db.connect();
                db.existGroup(groupName);
                db.getConnection.Close();
                DataTable tb = new DataTable();
                db.getDataAdapter.Fill(tb);
                string dbGroupName = tb.Rows[0]["GroupName"].ToString();
                leaderName = tb.Rows[0]["Leader"].ToString();
                Secretary = tb.Rows[0]["Secretary"].ToString();
                location = tb.Rows[0]["Location"].ToString();

                if (groupName.Equals(dbGroupName))
                {
                    pan.Visible = true;
                    txtGroupName.Text = groupName;
                    txtLeaderName.Text = leaderName;
                    txtSecretaryName.Text = Secretary;
                    richTxtLocation.Text = location;
                }
            }
            catch (IndexOutOfRangeException idx)
            {
                sSMessage.Visible = true;
                tSSMessage.Text = "Group name is invalid!";
            }
            if (comboEditDelete.SelectionLength < 0)
            {
                pan.Visible = true;
                btnCreate.Text = "Create";
                txtGroupName.Text = "";
                txtLeaderName.Text = "";
                txtSecretaryName.Text = "";
                richTxtLocation.Text = "";
                sSMessage.Visible = false;
            }
        }
        private void deleteGroupDetails(string groupName)
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
                            db.connect();
                            db.deleteGroup(groupName);
                            db.getConnection.Close();
                            DataTable tb = new DataTable();
                            db.getDataAdapter.Fill(tb);

                            MessageBox.Show("Group deleted successfully", "Info",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                            pan.Visible = false;
                            comboGroupName.Items.Clear();
                            comboGroupName.Text = "Select Group Name";
                            getGroupName();
                        }
                        catch (IndexOutOfRangeException idx)
                        {
                            sSMessage.Visible = true;
                            tSSMessage.Text = "Group does not exist!";
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
        private void comboGroupName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!comboGroupName.Text.Equals("Select Group Name"))
            {
                string groupName = comboGroupName.SelectedItem.ToString();
                if (comboEditDelete.SelectedItem.Equals("Edit Details"))
                {
                    loadGroupDetails(groupName);
                }
                else if(comboEditDelete.SelectedItem.Equals("Register Details"))
                {
                    btnCreate.Text = "Create";
                }
                else
                {
                    if (MessageBox.Show("Are you sure you want to delete this group?", "Delete Group", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        deleteGroupDetails(groupName);
                    }
                }
            }
        }
        private void comboEditDelete_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!comboEditDelete.Text.Equals("Select Option"))
            {
                if (comboEditDelete.SelectedItem.Equals("Register Details"))
                {
                    pan.Visible = true;
                    comboGroupName.Visible = false;
                    txtGroupName.Enabled = true;
                    txtGroupName.Text = "";
                    txtLeaderName.Text = "";
                    txtSecretaryName.Text = "";
                    richTxtLocation.Text = "";
                }
                else
                {
                    comboGroupName.Visible = true;
                    pan.Visible = false;
                }
            }
        }
    }
}
