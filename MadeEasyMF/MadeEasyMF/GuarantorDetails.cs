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
using System.IO;

namespace SoftlightMF
{
    public partial class GuarantorDetails : Form
    {
        private DatabaseLib db = new DatabaseLib();
        public GuarantorDetails()
        {
            InitializeComponent();
        }
        private void details()
        {
            ExposeProperties exp = new ExposeProperties();
            lblName.Text = exp.GuarantName;
            txtAddress.Text = exp.Address;
            lblPhone.Text = exp.Phone;
            lblGender.Text = exp.Gender;
            MemoryStream memory = new MemoryStream(exp.GuarantorPhoto);
            picGuarantor.Image = Image.FromStream(memory);
            MemoryStream memory2 = new MemoryStream(exp.GuarantorSignature);
            picSignature.Image = Image.FromStream(memory2);
        }

        private void GuarantorDetails_Load(object sender, EventArgs e)
        {
            details();
        }

        private void linkHome_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            new Home().Show();
            Hide();
        }

        private void linkLogout_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            Login log = new Login();
            ExposeProperties exp = new ExposeProperties();
            log.logFile(exp.getUser, "Offline");
            new Login().Show();
            Hide();
        }
    }
}
