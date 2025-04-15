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
    public partial class frmHoaDon : Form
    {
        private DatabaseHelper db = new DatabaseHelper();
        private string actionState = "";
        private bool isAdmin;
        public frmHoaDon(bool isAdmin)
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
        private void frmHoaDon_Load(object sender, EventArgs e)
        {
            frmHelper.FullScreenForm(this);
            LoadData();
            LockTxtBox(true);

            // Luôn khóa
            txtMaHD.Enabled = false;
            dtpNgayLap.Enabled = false;
        }
        private void LoadData()
        {
            string query = "SELECT * FROM HoaDon";
            dtpNgayLap.Value = DateTime.Now;
            DataTable dt = db.ExecuteQuery(query);
            dgvHoaDon.DataSource = dt;
            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnChiTiet.Enabled = false;

            LoadNhanVien();
            LoadKhachHang();
            LoadHinhThucThanhToan();
            LoadColor();
            dtpNgayLap.ShowCheckBox = true;
            dtpNgayLap.Checked = false;
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
        private void LoadKhachHang()
        {
            string query = "SELECT MaKH, TenKH FROM KhachHang";
            DataTable dt = db.ExecuteQuery(query);

            cbxKhachHang.DataSource = dt;
            cbxKhachHang.DisplayMember = "TenKH";
            cbxKhachHang.ValueMember = "MaKH";
            cbxKhachHang.SelectedIndex = -1;
        }
        private void LoadHinhThucThanhToan()
        {
            cbxHTTT.Items.Clear();

            cbxHTTT.Items.Add("Tiền mặt");
            cbxHTTT.Items.Add("Thẻ");
            cbxHTTT.Items.Add("Chuyển khoản");
            cbxHTTT.Items.Add("Momo");
            cbxHTTT.Items.Add("ZaloPay");
            cbxHTTT.Items.Add("Khác");

            cbxHTTT.SelectedIndex = -1;
        }
        private void LockTxtBox(bool locked)
        {
            cbxKhachHang.Enabled = !locked;
            cbxNhanVien.Enabled = !locked;
            cbxHTTT.Enabled = !locked;
            if (locked)
            {
                cbxKhachHang.SelectedIndex = -1;
                cbxNhanVien.SelectedIndex = -1;
                cbxHTTT.SelectedIndex = -1;
                txtMaHD.Text = "";
            }
        }
        private bool ValidateInput()
        {
            if (!(actionState == "TimKiem"))
            {
                if ((cbxKhachHang.SelectedIndex == -1) ||
                (cbxNhanVien.SelectedIndex == -1) ||
                (cbxHTTT.SelectedIndex == -1))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
           
            return true;
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
            if (dgvHoaDon.SelectedRows.Count > 0)
            {
                string maHD = dgvHoaDon.SelectedRows[0].Cells["MaHD"].Value.ToString();

                // Hiển thị hộp thoại xác nhận
                DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa hóa đơn \"{maHD}\" không?",
                                                      "Xác nhận xóa",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Warning);

                if (result == DialogResult.Yes) // Nếu người dùng nhấn "Yes"
                {
                    string query = "DELETE FROM HoaDon WHERE MaHD = @MaHD";
                    SqlParameter[] parameters = { new SqlParameter("@MaHD", maHD) };

                    db.ExecuteNonQuery(query, parameters);
                    LoadData();
                    LockTxtBox(true);
                    MessageBox.Show("Xóa hóa đơn hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn hóa đơn cần xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            // Nếu trước đó nhấn Thêm
            if (actionState == "Them")
            {
                string query = "INSERT INTO HoaDon (MaKH, MaNV, HinhThucThanhToan, NgayLap) VALUES (@MaKH, @MaNV, @HinhThucThanhToan, @NgayLap)";
                SqlParameter[] parameters = {
                    new SqlParameter("@MaKH", cbxKhachHang.SelectedValue),
                    new SqlParameter("@MaNV", cbxNhanVien.SelectedValue),
                    new SqlParameter("@HinhThucThanhToan", cbxHTTT.SelectedItem.ToString()),
                    new SqlParameter("@NgayLap", dtpNgayLap.Value)
                };

                //Hiển thị các tham số
                string message = "Tham số:\n";
                foreach (var param in parameters)
                {
                    message += $"{param.ParameterName}: {param.Value}\n";
                }
                MessageBox.Show(message);

                db.ExecuteNonQuery(query, parameters);
                MessageBox.Show("Thêm hóa đơn thành công!");
            }
            else if (actionState == "Sua") // Nếu trước đó nhấn Sửa
            {
                string query = "UPDATE HoaDon SET MaKH = @MaKH, MaNV = @MaNV, HinhThucThanhToan = @HinhThucThanhToan, NgayLap = @NgayLap WHERE MaHD = @MaHD";
                SqlParameter[] parameters = {
                    new SqlParameter("@MaKH", cbxKhachHang.SelectedValue),
                    new SqlParameter("@MaNV", cbxNhanVien.SelectedValue),
                    new SqlParameter("@HinhThucThanhToan", cbxHTTT.SelectedItem.ToString()),
                    new SqlParameter("@NgayLap", dtpNgayLap.Value),
                    new SqlParameter("@MaHD", txtMaHD.Text)
                };

                db.ExecuteNonQuery(query, parameters);
                MessageBox.Show("Cập nhật hóa đơn thành công!");
            }
            else if (actionState == "TimKiem") // Nếu trước đó nhấn Tìm kiếm
            {
                List<string> conditions = new List<string>();
                List<SqlParameter> parameters = new List<SqlParameter>();

                if (cbxKhachHang.SelectedValue != null && cbxKhachHang.SelectedIndex != -1)
                {
                    conditions.Add("MaKH = @MaKH");
                    parameters.Add(new SqlParameter("@MaKH", cbxKhachHang.SelectedValue));
                }

                if (cbxNhanVien.SelectedValue != null && cbxNhanVien.SelectedIndex != -1)
                {
                    conditions.Add("MaNV = @MaNV");
                    parameters.Add(new SqlParameter("@MaNV", cbxNhanVien.SelectedValue));
                }

                if (cbxHTTT.SelectedItem != null && cbxHTTT.SelectedIndex != -1)
                {
                    conditions.Add("HinhThucThanhToan = @HinhThucThanhToan");
                    parameters.Add(new SqlParameter("@HinhThucThanhToan", cbxHTTT.SelectedItem.ToString()));
                }

                if (dtpNgayLap.Checked)
                {
                    conditions.Add("CONVERT(date, NgayLap) = @NgayLap");
                    parameters.Add(new SqlParameter("@NgayLap", dtpNgayLap.Value.Date));
                }

                string query = "SELECT * FROM HoaDon";

                if (conditions.Count > 0)
                {
                    query += " WHERE " + string.Join(" AND ", conditions);
                }

                DataTable dt = db.ExecuteQuery(query, parameters.ToArray());
                dgvHoaDon.DataSource = dt;

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy kết quả phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            // Sau khi lưu xong, reset form
            if (!(actionState == "TimKiem"))
                LoadData();
            LockTxtBox(true);
            btnLuu.Enabled = false;
            btnThem.Enabled = true;
            btnTimKiem.Enabled = true;
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
            dtpNgayLap.Enabled = true;
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
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnChiTiet.Enabled = false;
            LockTxtBox(true);
            if (!isAdmin)
            {
                btnThem.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
            }
        }
        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuu.Enabled = false;
            btnThem.Enabled = false;
            btnChiTiet.Enabled = true;
            btnTimKiem.Enabled = false;
            if (!isAdmin)
            {
                btnThem.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
            }


            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvHoaDon.Rows[e.RowIndex];
                txtMaHD.Text = row.Cells["MaHD"].Value.ToString();

                if (row.Cells["MaKH"].Value != null)
                {
                    cbxKhachHang.SelectedValue = row.Cells["MaKH"].Value.ToString();
                }
                else
                {
                    cbxKhachHang.SelectedIndex = -1;
                }

                if (row.Cells["MaNV"].Value != null)
                {
                    cbxNhanVien.SelectedValue = row.Cells["MaNV"].Value.ToString();
                }
                else
                {
                    cbxNhanVien.SelectedIndex = -1;
                }

                if (row.Cells["HinhThucThanhToan"].Value != null)
                {
                    cbxHTTT.SelectedItem = row.Cells["HinhThucThanhToan"].Value.ToString();
                }
                else
                {
                    cbxHTTT.SelectedIndex = -1;
                }

                if (row.Cells["NgayLap"].Value != null && DateTime.TryParse(row.Cells["NgayLap"].Value.ToString(), out DateTime ngayNhap))
                {
                    dtpNgayLap.Value = ngayNhap;
                }
                else
                {
                    dtpNgayLap.Value = DateTime.Now;
                }
            }
        }
        private void btnCongNhanVien_Click(object sender, EventArgs e)
        {
            frmNhanVien frm = new frmNhanVien(isAdmin);
            frm.Show();
        }
        private void btnChiTiet_Click(object sender, EventArgs e)
        {
            string maHD = dgvHoaDon.SelectedRows[0].Cells["MaHD"].Value.ToString();
            frmChiTietHoaDon frm = new frmChiTietHoaDon(maHD, isAdmin);
            frm.ShowDialog();
        }
        private void btnCongKH_Click(object sender, EventArgs e)
        {
            frmKhachHang frm = new frmKhachHang(isAdmin);
            frm.Show();
        }
    }
}
