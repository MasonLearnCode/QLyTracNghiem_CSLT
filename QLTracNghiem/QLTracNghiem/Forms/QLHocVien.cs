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
            txtHoLot.Text = "";
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
                MessageBox.Show("Mã học viên không được để trống!");
                txtMaHV.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtHoLot.Text))
            {
                MessageBox.Show("Tên học viên không được để trống!");
                txtHoLot.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtSDTHV.Text))
            {
                MessageBox.Show("Số điện thoại không được để trống!");
                txtSDTHV.Focus();
                return;
            }

            // Thêm mã sau các câu lệnh kiểm tra trường thông tin
            string maHV = txtMaHV.Text;
            string hoLot = txtHoLot.Text;
            string tenHV = txtTenHV.Text;
            string sdtHV = txtSDTHV.Text;
            string gioiTinh = rbtnNam.Checked ? "Nam" : "Nữ";

            // Thực hiện lưu thông tin học viên vào cơ sở dữ liệu
            // (Bạn cần thay đổi đoạn mã này để phù hợp với cấu trúc cơ sở dữ liệu của bạn)
            string query = "INSERT INTO HocVien(MaHV, HoLot, TenHV, SDTHV, Phai) VALUES(@MaHV, @HoLot, @Ten, @SDTHV, @Phai)";
            SqlCommand command = new SqlCommand(query, connect);
            command.Parameters.AddWithValue("@MaHV", maHV);
            command.Parameters.AddWithValue("@HoLot", hoLot);
            command.Parameters.AddWithValue("@Ten", tenHV);
            command.Parameters.AddWithValue("@SDTHV", sdtHV);
            command.Parameters.AddWithValue("@Phai", gioiTinh);

            int result = command.ExecuteNonQuery();
            if (result > 0)
            {
                MessageBox.Show("Thêm học viên thành công!");
            }
            else
            {
                MessageBox.Show("Thêm học viên thất bại!");
            }
        }
    }
}
