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
    public partial class frmNhapHang : Form
    {
        private DatabaseHelper db = new DatabaseHelper();
        private string actionState = "";
        private bool isAdmin;

        public frmNhapHang(bool isAdmin)
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

        private void frmNhapHang_Load(object sender, EventArgs e)
        {
            frmHelper.FullScreenForm(this);
            LoadData();
            LoadColor();
            LockTxtBox(true);

            // Luôn khóa
            txtMaNhap.Enabled = false;
            dtpNgayNhap.ShowCheckBox = true;
            dtpNgayNhap.Enabled = false;
            dtpNgayNhap.Checked = false;
        }

        private void LoadData()
        {
            string query = "SELECT * FROM NhapHang";
            DataTable dt = db.ExecuteQuery(query);
            dgvNhapHang.DataSource = dt;
            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnChiTiet.Enabled = false;

            LoadNhanVien();
            LoadNhaCungCap();
            LoadKho();
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

        private void LoadNhaCungCap()
        {
            string query = "SELECT MaNCC, TenNCC FROM NhaCungCap";
            DataTable dt = db.ExecuteQuery(query);

            cbxNhaCungCap.DataSource = dt;
            cbxNhaCungCap.DisplayMember = "TenNCC";
            cbxNhaCungCap.ValueMember = "MaNCC";
            cbxNhaCungCap.SelectedIndex = -1;
        }

        private void LoadKho()
        {
            string query = "SELECT MaKho, TenKho FROM Kho";
            DataTable dt = db.ExecuteQuery(query);

            cbxKho.DataSource = dt;
            cbxKho.DisplayMember = "TenKho";
            cbxKho.ValueMember = "MaKho";
            cbxKho.SelectedIndex = -1;
        }

        private void LockTxtBox(bool locked)
        {
            cbxNhaCungCap.Enabled = !locked;
            cbxNhanVien.Enabled = !locked;
            cbxKho.Enabled = !locked;
            if(actionState == "TimKiem")
            {
                dtpNgayNhap.Enabled = true;
            }
            dtpNgayNhap.Enabled = !locked;

            if (locked)
            {
                cbxNhaCungCap.SelectedIndex = -1;
                cbxNhanVien.SelectedIndex = -1;
                cbxKho.SelectedIndex = -1;
                txtMaNhap.Text = "";
                dtpNgayNhap.Value = DateTime.Now;
                dtpNgayNhap.Checked = false;
            }
        }

        private bool ValidateInput()
        {
            if (!(actionState == "TimKiem")) 
            { 
                if ((cbxNhaCungCap.SelectedIndex == -1) ||
                    (cbxNhanVien.SelectedIndex == -1) ||
                    (cbxKho.SelectedIndex == -1))
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
            if (dgvNhapHang.SelectedRows.Count > 0)
            {
                string maNhap = dgvNhapHang.SelectedRows[0].Cells["MaNhap"].Value.ToString();

                // Hiển thị hộp thoại xác nhận
                DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa phiếu nhập hàng \"{maNhap}\" không?",
                                                      "Xác nhận xóa",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Warning);

                if (result == DialogResult.Yes) // Nếu người dùng nhấn "Yes"
                {
                    string query = "DELETE FROM NhapHang WHERE MaNhap = @MaNhap";
                    SqlParameter[] parameters = { new SqlParameter("@MaNhap", maNhap) };

                    db.ExecuteNonQuery(query, parameters);
                    LoadData();
                    LockTxtBox(true);
                    MessageBox.Show("Xóa phiếu nhập hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn phiếu nhập hàng cần xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            // Nếu trước đó nhấn Thêm
            if (actionState == "Them")
            {
                string query = "INSERT INTO NhapHang (MaNCC, MaNV, MaKho, NgayNhap) VALUES (@MaNCC, @MaNV, @MaKho, @NgayNhap)";
                SqlParameter[] parameters = {
                    new SqlParameter("@MaNCC", cbxNhaCungCap.SelectedValue),
                    new SqlParameter("@MaNV", cbxNhanVien.SelectedValue),
                    new SqlParameter("@MaKho", cbxKho.SelectedValue),
                    new SqlParameter("@NgayNhap", dtpNgayNhap.Value)
                };

                // Hiển thị các tham số
                //string message = "Tham số:\n";
                //foreach (var param in parameters)
                //{
                //    message += $"{param.ParameterName}: {param.Value}\n";
                //}
                //MessageBox.Show(message);

                db.ExecuteNonQuery(query, parameters);
                MessageBox.Show("Thêm phiếu nhập thành công!");
            }
            // Nếu trước đó nhấn Sửa
            else if (actionState == "Sua") 
            {
                string query = "UPDATE NhapHang SET MaNCC = @MaNCC, MaNV = @MaNV, MaKho = @MaKho, NgayNhap = @NgayNhap WHERE MaNhap = @MaNhap";
                SqlParameter[] parameters = {
                    new SqlParameter("@MaNCC", cbxNhaCungCap.SelectedValue),
                    new SqlParameter("@MaNV", cbxNhanVien.SelectedValue),
                    new SqlParameter("@MaKho", cbxKho.SelectedValue),
                    new SqlParameter("@NgayNhap", dtpNgayNhap.Value),
                    new SqlParameter("@MaNhap", txtMaNhap.Text),
                };

                db.ExecuteNonQuery(query, parameters);
                MessageBox.Show("Cập nhật phiếu nhập thành công!");
            }
            // Nếu trước đó nhấn Tìm kiếm
            else if (actionState == "TimKiem")
            {
                List<string> conditions = new List<string>();
                List<SqlParameter> parameters = new List<SqlParameter>();

                if (cbxNhaCungCap.SelectedIndex != -1)
                {
                    conditions.Add("MaNCC = @MaNCC");
                    parameters.Add(new SqlParameter("@MaNCC", cbxNhaCungCap.SelectedValue));
                }

                if (cbxNhanVien.SelectedIndex != -1)
                {
                    conditions.Add("MaNV = @MaNV");
                    parameters.Add(new SqlParameter("@MaNV", cbxNhanVien.SelectedValue));
                }

                if (cbxKho.SelectedIndex != -1)
                {
                    conditions.Add("MaKho = @MaKho");
                    parameters.Add(new SqlParameter("@MaKho", cbxKho.SelectedValue));
                }

                if (dtpNgayNhap.Checked)
                {
                    conditions.Add("CAST(NgayNhap AS DATE) = @NgayNhap");
                    parameters.Add(new SqlParameter("@NgayNhap", dtpNgayNhap.Value.Date));
                }

                string query = "SELECT * FROM NhapHang";
                if (conditions.Count > 0)
                    query += " WHERE " + string.Join(" AND ", conditions);

                DataTable dt = db.ExecuteQuery(query, parameters.ToArray());

                if (dt.Rows.Count == 0)
                    MessageBox.Show("Không tìm thấy kết quả phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                dgvNhapHang.DataSource = dt;
            }

            // Sau khi lưu xong, reset form
            if (!(actionState == "TimKiem"))
                LoadData();
            LockTxtBox(true);
            btnLuu.Enabled = false;
            btnThem.Enabled = true;
            btnTimKiem.Enabled = true;
            if (!isAdmin)
            {
                btnThem.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
            }
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

        private void dgvNhapHang_CellClick(object sender, DataGridViewCellEventArgs e)
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
                DataGridViewRow row = dgvNhapHang.Rows[e.RowIndex];
                txtMaNhap.Text = row.Cells["MaNhap"].Value.ToString();

                if (row.Cells["MaNCC"].Value != null)
                {
                    cbxNhaCungCap.SelectedValue = row.Cells["MaNCC"].Value.ToString();
                }
                else
                {
                    cbxNhaCungCap.SelectedIndex = -1;
                }

                if (row.Cells["MaNV"].Value != null)
                {
                    cbxNhanVien.SelectedValue = row.Cells["MaNV"].Value.ToString();
                }
                else
                {
                    cbxNhanVien.SelectedIndex = -1;
                }

                if (row.Cells["MaKho"].Value != null)
                {
                    cbxKho.SelectedValue = row.Cells["MaKho"].Value.ToString();
                }
                else
                {
                    cbxKho.SelectedIndex = -1;
                }

                if (row.Cells["NgayNhap"].Value != null && DateTime.TryParse(row.Cells["NgayNhap"].Value.ToString(), out DateTime ngayNhap))
                {
                    dtpNgayNhap.Value = ngayNhap;
                }
                else
                {
                    dtpNgayNhap.Value = DateTime.Now;
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
            string maNhap = dgvNhapHang.SelectedRows[0].Cells["MaNhap"].Value.ToString();
            frmChiTietNhapHang frm = new frmChiTietNhapHang(maNhap, isAdmin);
            frm.ShowDialog();
        }

        private void btnCongNCC_Click(object sender, EventArgs e)
        {
            frmNhaCungCap frm = new frmNhaCungCap(isAdmin);
            frm.Show();
        }

        private void btnCongKho_Click(object sender, EventArgs e)
        {
            frmKho frm = new frmKho(isAdmin);
            frm.Show();
        }
    }
}
