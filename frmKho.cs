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
    public partial class frmKho : Form
    {
        private DatabaseHelper db = new DatabaseHelper();
        private string actionState = "";
        private bool isAdmin;

        public frmKho(bool isAdmin)
        {
            InitializeComponent();
            this.isAdmin = isAdmin;
            if (!isAdmin)
            {
                btnThem.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
            }
        }

        private void frmKho_Load(object sender, EventArgs e)
        {
            frmHelper.FullScreenForm(this);
            LoadData();
            LockTxtBox(true);
            txtMaKho.Enabled = false;
        }

        private void LoadData()
        {
            string query = "SELECT * FROM Kho";
            DataTable dt = db.ExecuteQuery(query);
            dgvKho.DataSource = dt;
            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            LoadNhanVien();
            LoadColor();
        }
        private void LoadColor()
        {
            btnThem.BackColor = Color.FromArgb(40, 167, 69); ;
            btnSua.BackColor = Color.FromArgb(253, 126, 20);
            btnXoa.BackColor = Color.FromArgb(220, 53, 69);
            btnLuu.BackColor = Color.FromArgb(0, 123, 255);
            btnTimKiem.BackColor = Color.FromArgb(108, 117, 125);
            btnLamMoi.BackColor = Color.FromArgb(32, 201, 151);

            // Màu chữ trắng cho tất cả
            btnThem.ForeColor = Color.White;
            btnSua.ForeColor = Color.White;
            btnXoa.ForeColor = Color.White;
            btnLuu.ForeColor = Color.White;
            btnTimKiem.ForeColor = Color.White;
            btnLamMoi.ForeColor = Color.White;
        }

        private void LoadNhanVien()
        {
            string query = "SELECT MaNV, TenNV FROM NhanVien";
            DataTable dt = db.ExecuteQuery(query);

            cbxNhanVien.DataSource = dt;
            cbxNhanVien.DisplayMember = "TenNV";
            cbxNhanVien.ValueMember = "MaNV";
            cbxNhanVien.SelectedIndex = -1;
        }

        private void LockTxtBox(bool locked)
        {
            txtTenKho.Enabled = !locked;
            cbxNhanVien.Enabled = !locked;
            rtxtDiaChi.Enabled = !locked;

            if (locked)
            {
                txtMaKho.Text = "";
                txtTenKho.Text = "";
                cbxNhanVien.SelectedIndex = -1;
                rtxtDiaChi.Text = "";
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            actionState = "Them";
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            LockTxtBox(false);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            actionState = "Sua";
            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            LockTxtBox(false);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvKho.SelectedRows.Count > 0)
            {
                string maKho = dgvKho.SelectedRows[0].Cells["MaKho"].Value.ToString();
                string query = "DELETE FROM Kho WHERE MaKho = @MaKho";
                SqlParameter[] parameters = { new SqlParameter("@MaKho", maKho) };
                db.ExecuteNonQuery(query, parameters);
                LoadData();
                LockTxtBox(true);
                MessageBox.Show("Xóa kho thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!(actionState == "TimKiem") && (string.IsNullOrWhiteSpace(txtTenKho.Text) || cbxNhanVien.SelectedIndex == -1 || string.IsNullOrWhiteSpace(rtxtDiaChi.Text)))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (actionState == "Them")
            {
                string query = "INSERT INTO Kho (TenKho, MaNV, DiaChi) VALUES (@TenKho, @MaNV, @DiaChi)";
                SqlParameter[] parameters = {
                    new SqlParameter("@TenKho", txtTenKho.Text),
                    new SqlParameter("@MaNV", cbxNhanVien.SelectedValue),
                    new SqlParameter("@DiaChi", rtxtDiaChi.Text)
                };
                db.ExecuteNonQuery(query, parameters);
                MessageBox.Show("Thêm kho thành công!");
            }
            else if (actionState == "Sua")
            {
                string query = "UPDATE Kho SET TenKho = @TenKho, MaNV = @MaNV, DiaChi = @DiaChi WHERE MaKho = @MaKho";
                SqlParameter[] parameters = {
                    new SqlParameter("@TenKho", txtTenKho.Text),
                    new SqlParameter("@MaNV", cbxNhanVien.SelectedValue),
                    new SqlParameter("@DiaChi", rtxtDiaChi.Text),
                    new SqlParameter("@MaKho", txtMaKho.Text)
                };
                db.ExecuteNonQuery(query, parameters);
                MessageBox.Show("Cập nhật kho thành công!");
            }
            else if (actionState == "TimKiem") // Nếu trước đó nhấn Tìm kiếm
            {
                List<string> conditions = new List<string>(); // Danh sách điều kiện
                List<SqlParameter> parameters = new List<SqlParameter>(); // Danh sách tham số

                if (!string.IsNullOrEmpty(txtTenKho.Text.Trim()))
                {
                    conditions.Add("TenKho LIKE @TenKho");
                    parameters.Add(new SqlParameter("@TenKho", $"%{txtTenKho.Text.Trim()}%"));
                }

                if (!string.IsNullOrEmpty(rtxtDiaChi.Text.Trim()))
                {
                    conditions.Add("DiaChi LIKE @DiaChi");
                    parameters.Add(new SqlParameter("@DiaChi", $"%{rtxtDiaChi.Text.Trim()}%"));
                }

                if (cbxNhanVien.SelectedItem != null && cbxNhanVien.SelectedIndex != -1)
                {
                    conditions.Add("MaNV = @MaNV");
                    parameters.Add(new SqlParameter("@MaNV", cbxNhanVien.SelectedValue));
                }

                // Ghép các điều kiện thành câu SQL
                string query = "SELECT * FROM Kho WHERE " + string.Join(" OR ", conditions);

                // Thực thi truy vấn
                DataTable dt = db.ExecuteQuery(query, parameters.ToArray());

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy kết quả phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                dgvKho.DataSource = dt;
            }

            // Sau khi lưu xong, reset form
            if (!(actionState == "TimKiem"))
                LoadData();
            LockTxtBox(true);
            btnLuu.Enabled = false;
            btnThem.Enabled = true;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            actionState = "TimKiem";
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnTimKiem.Enabled = false;

            //
            LockTxtBox(false);
            if (!isAdmin)
            {
                btnThem.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadData();
            actionState = "";
            btnThem.Enabled = true;
            btnTimKiem.Enabled = true;
            LockTxtBox(true);
            if (!isAdmin)
            {
                btnThem.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
            }
        }

        private void dgvKho_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuu.Enabled = false;
            btnThem.Enabled = false;
            btnTimKiem.Enabled = false;
            if (!isAdmin)
            {
                btnThem.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
            }

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvKho.Rows[e.RowIndex];
                txtMaKho.Text = row.Cells["MaKho"].Value.ToString();
                txtTenKho.Text = row.Cells["TenKho"].Value.ToString();
                rtxtDiaChi.Text = row.Cells["DiaChi"].Value.ToString();

                if (row.Cells["MaNV"].Value != null)
                {
                    cbxNhanVien.SelectedValue = row.Cells["MaNV"].Value.ToString();
                }
                else
                {
                    cbxNhanVien.SelectedIndex = -1;
                }
            }
        }
        private void btnCongNhanVien_Click(object sender, EventArgs e)
        {
            frmNhanVien frm = new frmNhanVien(isAdmin);
            frm.Show();
        }

        private void labNhanVien_Click(object sender, EventArgs e)
        {

        }
    }
}
