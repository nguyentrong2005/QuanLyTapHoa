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
    public partial class frmSanPham : Form
    {
        private DatabaseHelper db = new DatabaseHelper();
        private string actionState = "";
        private bool isAdmin;

        public frmSanPham(bool isAdmin)
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

        private void frmSanPham_Load(object sender, EventArgs e)
        {
            frmHelper.FullScreenForm(this);
            LockTxtBox(true);
            LoadData();
            LoadColor();

            // Luôn khóa
            txtMaSP.Enabled = false;
            numSoLuongTon.Enabled = false;
            dtpNgayHetHan.ShowCheckBox = true;
            dtpNgayHetHan.Checked = false;
        }

        private void LoadData()
        {
            // Load dữ liệu cho DataGridView
            string querySP = "SELECT * FROM SanPham";
            DataTable dtSP = db.ExecuteQuery(querySP);
            dgvSanPham.DataSource = dtSP;

            // Load dữ liệu cho ComboBox Loại Sản Phẩm
            string queryLoaiSP = "SELECT MaLoaiSP, TenLoaiSP FROM LoaiSanPham";
            DataTable dtLoaiSP = db.ExecuteQuery(queryLoaiSP);
            cbxLoaiSP.DataSource = dtLoaiSP;
            cbxLoaiSP.DisplayMember = "TenLoaiSP";
            cbxLoaiSP.ValueMember = "MaLoaiSP";
            cbxLoaiSP.SelectedIndex = -1;

            // Load dữ liệu cho ComboBox Nhà Cung Cấp
            string queryNCC = "SELECT MaNCC, TenNCC FROM NhaCungCap";
            DataTable dtNCC = db.ExecuteQuery(queryNCC);
            cbxNCC.DataSource = dtNCC;
            cbxNCC.DisplayMember = "TenNCC";
            cbxNCC.ValueMember = "MaNCC";
            cbxNCC.SelectedIndex = -1;

            // Vô hiệu các nút ban đầu
            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
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

        private void LockTxtBox(bool locked)
        {
            txtTenSP.Enabled = !locked;
            cbxLoaiSP.Enabled = !locked;
            cbxNCC.Enabled = !locked;
            numGiaNhap.Enabled = !locked;
            numGiaBan.Enabled = !locked;
            dtpNgayHetHan.Enabled = !locked;

            // Nếu khóa thì xóa dữ liệu
            if (locked)
            {
                txtMaSP.Text = "";
                txtTenSP.Text = "";
                cbxLoaiSP.SelectedIndex = -1;
                cbxNCC.SelectedIndex = -1;
                numSoLuongTon.Value = 0;
                numGiaBan.Value = 0;
                numGiaNhap.Value = 0;
                dtpNgayHetHan.Value = DateTime.Now;
            }
        }

        private bool ValidateInput()
        {
            if (!(actionState == "TimKiem"))
            {
                if (string.IsNullOrWhiteSpace(txtTenSP.Text) ||
                    (cbxLoaiSP.SelectedIndex == -1) ||
                    (cbxNCC.SelectedIndex == -1))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (numSoLuongTon.Value < 0)
                {
                    MessageBox.Show("Số lượng tồn không thể nhỏ hơn 0!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (numGiaBan.Value <= 0)
                {
                    MessageBox.Show("Giá bán phải lớn hơn 0", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (numGiaNhap.Value <= 0)
                {
                    MessageBox.Show("Giá nhập phải lớn hơn 0", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (dtpNgayHetHan.Value <= DateTime.Now)
                {
                    MessageBox.Show("Ngày hết hạn phải lớn hơn ngày hiện tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            actionState = "Them";
            btnTimKiem.Enabled = false;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;

            //
            LockTxtBox(false);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            actionState = "Sua";
            btnLuu.Enabled = true;
            btnSua.Enabled = false;

            //
            LockTxtBox(false);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvSanPham.SelectedRows.Count > 0)
            {
                string maSP = dgvSanPham.SelectedRows[0].Cells["MaSP"].Value.ToString();
                string tenSP = dgvSanPham.SelectedRows[0].Cells["TenSP"].Value.ToString();

                // Hiển thị hộp thoại xác nhận
                DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa sản phẩm \"{tenSP}\" không?",
                                                      "Xác nhận xóa",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Warning);

                if (result == DialogResult.Yes) // Nếu người dùng nhấn "Yes"
                {
                    string query = "DELETE FROM SanPham WHERE MaSP = @MaSP";
                    SqlParameter[] parameters = { new SqlParameter("@MaSP", maSP) };

                    db.ExecuteNonQuery(query, parameters);
                    LoadData();
                    LockTxtBox(true);
                    MessageBox.Show("Xóa sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            // Nếu trước đó nhấn Thêm
            if (actionState == "Them")
            {
                string query = "INSERT INTO SanPham (TenSP, MaLoaiSP, MaNCC, GiaNhap, GiaBan, NgayHetHan) VALUES (@TenSP, @MaLoaiSP, @MaNCC, @GiaNhap, @GiaBan, @NgayHetHan)";
                SqlParameter[] parameters = {
                    new SqlParameter("@TenSP", txtTenSP.Text),
                    new SqlParameter("@MaLoaiSP", cbxLoaiSP.SelectedValue),
                    new SqlParameter("@MaNCC", cbxNCC.SelectedValue),
                    new SqlParameter("@GiaNhap", numGiaNhap.Value),
                    new SqlParameter("@GiaBan", numGiaBan.Value),
                    new SqlParameter("@NgayHetHan", dtpNgayHetHan.Value)
                };

                // Hiển thị các giá trị của parameters trong MessageBox
                //StringBuilder sb = new StringBuilder();
                //foreach (var param in parameters)
                //{
                //    sb.AppendLine($"{param.ParameterName}: {param.Value}");
                //}

                //MessageBox.Show(sb.ToString(), "Giá trị của các tham số");

                db.ExecuteNonQuery(query, parameters);
                MessageBox.Show("Thêm sản phẩm thành công!");
            }
            else if (actionState == "Sua") // Nếu trước đó nhấn Sửa
            {
                string query = "UPDATE SanPham SET TenSP = @TenSP, MaLoaiSP = @MaLoaiSP, MaNCC = @MaNCC, GiaNhap = @GiaNhap, GiaBan = @GiaBan, NgayHetHan = @NgayHetHan WHERE MaSP = @MaSP";
                SqlParameter[] parameters = {
                    new SqlParameter("@MaSP", txtMaSP.Text),
                    new SqlParameter("@TenSP", txtTenSP.Text),
                    new SqlParameter("@MaLoaiSP", cbxLoaiSP.SelectedValue),
                    new SqlParameter("@MaNCC", cbxNCC.SelectedValue),
                    new SqlParameter("@GiaNhap", numGiaNhap.Value),
                    new SqlParameter("@GiaBan", numGiaBan.Value),
                    new SqlParameter("@NgayHetHan", dtpNgayHetHan.Value)
                };

                db.ExecuteNonQuery(query, parameters);
                MessageBox.Show("Cập nhật sản phẩm thành công!");
            }
            else if (actionState == "TimKiem")
            {
                List<string> conditions = new List<string>();
                List<SqlParameter> parameters = new List<SqlParameter>();

                if (!string.IsNullOrEmpty(txtTenSP.Text.Trim()))
                {
                    conditions.Add("TenSP LIKE @TenSP");
                    parameters.Add(new SqlParameter("@TenSP", $"%{txtTenSP.Text.Trim()}%"));
                }

                if (cbxLoaiSP.SelectedIndex != -1)
                {
                    conditions.Add("MaLoaiSP = @MaLoaiSP");
                    parameters.Add(new SqlParameter("@MaLoaiSP", cbxLoaiSP.SelectedValue));
                }

                if (cbxNCC.SelectedIndex != -1)
                {
                    conditions.Add("MaNCC = @MaNCC");
                    parameters.Add(new SqlParameter("@MaNCC", cbxNCC.SelectedValue));
                }

                if (numSoLuongTon.Value > 0)
                {
                    conditions.Add("SoLuongTon >= @SoLuongTon");
                    parameters.Add(new SqlParameter("@SoLuongTon", numSoLuongTon.Value));
                }

                if (numGiaNhap.Value > 0)
                {
                    conditions.Add("GiaNhap >= @GiaNhap");
                    parameters.Add(new SqlParameter("@GiaNhap", numGiaNhap.Value));
                }

                if (numGiaBan.Value > 0)
                {
                    conditions.Add("GiaBan >= @GiaBan");
                    parameters.Add(new SqlParameter("@GiaBan", numGiaBan.Value));
                }

                if (dtpNgayHetHan.Checked) // Chỉ khi người dùng chọn ngày mới dùng
                {
                    conditions.Add("CAST(NgayHetHan AS DATE) = @NgayHetHan");
                    parameters.Add(new SqlParameter("@NgayHetHan", dtpNgayHetHan.Value.Date));
                }

                string query = "SELECT * FROM SanPham";

                if (conditions.Count > 0)
                {
                    query += " WHERE " + string.Join(" AND ", conditions);
                }

                DataTable dt = db.ExecuteQuery(query, parameters.ToArray());

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy kết quả phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                dgvSanPham.DataSource = dt;
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

            //
            btnThem.Enabled = true;
            btnTimKiem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = false;

            //
            LockTxtBox(true);
            if (!isAdmin)
            {
                btnThem.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
            }
        }
        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuu.Enabled = false;
            btnThem.Enabled = false;
            btnTimKiem.Enabled = false;
            LockTxtBox(true);
            if (!isAdmin)
            {
                btnThem.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
            }


            if (e.RowIndex >= 0) // Đảm bảo không click vào tiêu đề cột
            {
                DataGridViewRow row = dgvSanPham.Rows[e.RowIndex];

                // Gán dữ liệu từ DataGridView vào TextBox
                txtMaSP.Text = row.Cells["MaSP"].Value.ToString();
                txtTenSP.Text = row.Cells["TenSP"].Value.ToString();
                cbxLoaiSP.SelectedValue = row.Cells["MaLoaiSP"].Value.ToString();
                cbxNCC.SelectedValue = row.Cells["MaNCC"].Value.ToString();
                numGiaNhap.Value = Convert.ToDecimal(row.Cells["GiaNhap"].Value);
                numGiaBan.Value = Convert.ToDecimal(row.Cells["GiaBan"].Value);
                dtpNgayHetHan.Value = Convert.ToDateTime(row.Cells["NgayHetHan"].Value);
            }
        }

        private void btnCongLoaiSP_Click(object sender, EventArgs e)
        {
            frmLoaiSanPham frm = new frmLoaiSanPham(isAdmin);
            frm.Show();
        }

        private void btnCongNCC_Click(object sender, EventArgs e)
        {
            frmNhaCungCap frm = new frmNhaCungCap(isAdmin);
            frm.Show();
        }
    }
}
