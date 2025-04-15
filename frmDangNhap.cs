using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTH_BTNhom
{
    public partial class frmDangNhap : Form
    {
        DatabaseHelper db = new DatabaseHelper();
        public frmDangNhap()
        {
            InitializeComponent();
        }
        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            frmHelper.FullScreenForm(this);
            ConfigureColors();
        }
        private void ConfigureColors()
        {
            this.BackColor = ColorTranslator.FromHtml("#F5F5F5");
            labTitle.ForeColor = ColorTranslator.FromHtml("#32CD32");  // Màu chữ xanh lá cây
            panTitle.BackColor = ColorTranslator.FromHtml("#2F4F4F");  // Màu nền xám đậm
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string tenDangNhap = txtTenDangNhap.Text.Trim();
            string matKhau = txtMatKhau.Text.Trim();

            if (tenDangNhap == "" || matKhau == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "SELECT VaiTro FROM TaiKhoan WHERE TenDangNhap = @ten AND MatKhau = @matkhau";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ten", tenDangNhap),
                new SqlParameter("@matkhau", matKhau)
            };


            object result = db.ExecuteScalar(query, parameters);

            if (result != null)
            {
                bool laQuanTriVien = Convert.ToBoolean(result);
                MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Hide();

                frmMain mainForm = new frmMain(tenDangNhap, laQuanTriVien); // Giả sử frmMain có constructor nhận 2 tham số
                mainForm.Show();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
