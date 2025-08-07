using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoftlightMF
{
    public partial class DisbursementDetails : Form
    {
        private int duration;
        private float percent;
        private long principal;
        public DisbursementDetails()
        {
            InitializeComponent();
        }
        private void converter()
        {
            try
            {
                principal = Convert.ToInt64(lblPrincipal.Text);
                duration = Convert.ToInt32(lblDuration.Text);
                percent = float.Parse(lblInterest.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Number(s) required!");
            }
        }

        private void DisburseDetails()
        {
            lblAccNo.Text = ExposeProperties.AccNumber.ToString();
            lblPrincipal.Text = string.Format("{0:n}", ExposeProperties.Principal);
            lblDuration.Text = ExposeProperties.Duration.ToString();
            lblInterest.Text = string.Format("{0:n}", ExposeProperties.Percent);
            lblAmount.Text = string.Format("{0:n}", ExposeProperties.Amount);
            lblTotAmount.Text = string.Format("{0:n}", ExposeProperties.TotAmount);
            lblTermsOfPay.Text = ExposeProperties.TermsOfPayment;
            lblDisburseDate.Text = ExposeProperties.DisburseDate;
            lblMaturityDate.Text = ExposeProperties.MaturityDate;
            lblTime.Text = ExposeProperties.Time;
            lblAccOfficer.Text = ExposeProperties.AccountOfficer;

            sSMessage.Visible = true;
            tSSMessage.Text = "Loan successfully disbursed";
        }

        private void DisbursementDetails_Load(object sender, EventArgs e)
        {
            DisburseDetails();
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
        private void linkApplicant_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            new Disbursement().Show();
            Hide();
        }
    }
}
