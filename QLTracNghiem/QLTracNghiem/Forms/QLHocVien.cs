using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTracNghiem.Forms
{
    public partial class QLHocVien : Form
    {

        string strConnect = @"Data Source=Lil-Mason-lap;Initial Catalog=QLTracNghiem;Integrated Security=True";
        SqlConnection connect = null;

        public QLHocVien()
        {
            InitializeComponent();
        }

        private void btnThoatHV_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTiepTucHV_Click(object sender, EventArgs e)
        {
            txtMaHV.Text = "";
            txtDiaChiHV.Text = "";
            txtSDTHV.Text = "";
            txtTenHV.Text = "";
            txtMaHV.Focus();
        }

        private void QLHocVien_Load(object sender, EventArgs e)
        {
            if (connect == null)
            {
                connect = new SqlConnection(strConnect);

            }
            if (connect.State == ConnectionState.Closed)
            {
                connect.Open();
            }
        }

        private void btnThemHV_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaHV.Text))
            {
                MessageBox.Show("Ma lop khong duoc de trong!");
                txtMaHV.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtTenHV.Text))
            {
                MessageBox.Show("Ten lop khong duoc de trong!");
                txtTenHV.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtSDTHV.Text))
            {
                MessageBox.Show("Ten giao vien khong duoc de trong!");
                txtSDTHV.Focus();
                return;
            }
        }
    }
}
