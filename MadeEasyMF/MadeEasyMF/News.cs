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
    public partial class News : Form
    {
        private DatabaseLib db = new DatabaseLib();
        private DataTable tb;
        private string news1, news2, news3, dateTime1, dateTime2, dateTime3, headLine1, headLine2, headLine3;
        public News()
        {
            InitializeComponent();
        }
        private void news()
        {
            try
            {
                db.connect();
                db.getNews();
                db.getConnection.Close();
                tb = new DataTable();
                db.getDataAdapter.Fill(tb);
                dateTime1 = tb.Rows[0]["DateTime1"].ToString();
                dateTime2 = tb.Rows[0]["DateTime2"].ToString();
                dateTime3 = tb.Rows[0]["DateTime3"].ToString();
                headLine1 = tb.Rows[0]["HeadLine1"].ToString();
                headLine2 = tb.Rows[0]["HeadLine2"].ToString();
                headLine3 = tb.Rows[0]["HeadLine3"].ToString();
                news1 = tb.Rows[0]["News1"].ToString();
                news2 = tb.Rows[0]["News2"].ToString();
                news3 = tb.Rows[0]["News3"].ToString();

                lblDateTime1.Text = dateTime1;
                lblDateTime2.Text = dateTime2;
                lblDateTime3.Text = dateTime3;
                lblHeadLine1.Text = headLine1;
                lblHeadLine2.Text = headLine2;
                lblHeadLine3.Text = headLine3;
                richNews1.Text = news1;
                richNews2.Text = news2;
                richNews3.Text = news3;
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void News_Load(object sender, EventArgs e)
        {
            news();
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
