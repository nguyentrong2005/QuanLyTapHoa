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
    public partial class frmChiTietNhapHang : Form
    {
        private string maNhap;
        private DatabaseHelper db = new DatabaseHelper();
        private string actionState = "";
        private string oldMaSP;
        private bool isAdmin;
        public frmChiTietNhapHang(string maNhap, bool isAdmin)
        {
            InitializeComponent();
            this.maNhap = maNhap;
            this.isAdmin = isAdmin;

            if (!isAdmin)
            {
                btnThem.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
            }
        }
        private void frmChiTietNhapHang_Load(object sender, EventArgs e)
        {
            frmHelper.FullScreenForm(this);
            LoadData();
            LockTxtBox(true);

            // Luôn khóa
            txtMaNhap.Enabled = false;
            txtMaNhap.Text = maNhap;
            numGiaNhap.Enabled = false;
        }
        private void LoadData()
        {
            string query = "SELECT * FROM ChiTietNhapHang WHERE MaNhap = @MaNhap";
            DataTable dt = db.ExecuteQuery(query, new SqlParameter[] { new SqlParameter("@MaNhap", maNhap) });

            dgvChiTietNhapHang.DataSource = dt;

            // Vô hiệu các nút ban đầu
            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            LoadSanPham();
            LoadColor();
            cbxSanPham.SelectedIndexChanged += cbxSanPham_SelectedIndexChanged;
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
        private void LoadSanPham()
        {
            string query = "SELECT MaSP, TenSP FROM SanPham";
            DataTable dt = db.ExecuteQuery(query);

            cbxSanPham.DataSource = dt;
            cbxSanPham.DisplayMember = "TenSP";
            cbxSanPham.ValueMember = "MaSP";
            cbxSanPham.SelectedIndex = -1;
        }

        private void LockTxtBox(bool locked)
        {
            cbxSanPham.Enabled = !locked;
            numSoLuong.Enabled = !locked;

            // Nếu khóa thì xóa dữ liệu
            if (locked)
            {
                cbxSanPham.SelectedIndex = -1;
                numSoLuong.Value = 0;
                numGiaNhap.Value = 0;
            }
        }
        private bool ValidateInput()
        {
            if (cbxSanPham.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (numSoLuong.Value < 0)
            {
                MessageBox.Show("Số lượng không thể nhỏ hơn 0!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (numGiaNhap.Value < 0)
            {
                MessageBox.Show("Giá nhập không thể nhỏ hơn 0!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
        private void cbxSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxSanPham.SelectedValue != null)
            {
                string maSP = cbxSanPham.SelectedValue.ToString();
                string query = "SELECT GiaNhap FROM SanPham WHERE MaSP = @MaSP";
                DataTable dt = db.ExecuteQuery(query, new SqlParameter[] { new SqlParameter("@MaSP", maSP) });

                if (dt.Rows.Count > 0)
                {
                    numGiaNhap.Value = Convert.ToDecimal(dt.Rows[0]["GiaNhap"]);
                }
            }
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
            if (dgvChiTietNhapHang.SelectedRows.Count > 0)
            {
                string maSP = dgvChiTietNhapHang.SelectedRows[0].Cells["MaSP"].Value.ToString();
                string tenSP = dgvChiTietNhapHang.SelectedRows[0].Cells["TenSP"].Value.ToString();

                // Hiển thị hộp thoại xác nhận
                DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa sản phẩm \"{tenSP}\" không?",
                                                      "Xác nhận xóa",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Warning);

                if (result == DialogResult.Yes) // Nếu người dùng nhấn "Yes"
                {
                    string query = "DELETE FROM ChiTietNhapHang WHERE MaSP = @MaSP";
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
                string query = "INSERT INTO ChiTietNhapHang (MaNhap, MaSP, SoLuong, GiaNhap) VALUES (@MaNhap, @MaSP, @SoLuong, @GiaNhap)";
                SqlParameter[] parameters = {
                    new SqlParameter("@MaNhap", txtMaNhap.Text),
                    new SqlParameter("@MaSP", cbxSanPham.SelectedValue),
                    new SqlParameter("@SoLuong", numSoLuong.Value),
                    new SqlParameter("@GiaNhap", numGiaNhap.Value)
                };

                string message = "Tham số:\n";
                foreach (var param in parameters)
                {
                    message += $"{param.ParameterName}: {param.Value}\n";
                }
                MessageBox.Show(message);

                db.ExecuteNonQuery(query, parameters);
                MessageBox.Show("Thêm sản phẩm thành công!");
            }
            else if (actionState == "Sua") // Nếu trước đó nhấn Sửa
            {
                string query = "UPDATE ChiTietNhapHang SET MaSP = @NewMaSP, SoLuong = @SoLuong, GiaNhap = @GiaNhap WHERE MaNhap = @MaNhap AND MaSP = @OldMaSP";

                SqlParameter[] parameters = {
                    new SqlParameter("@MaNhap", txtMaNhap.Text),
                    new SqlParameter("@NewMaSP", cbxSanPham.SelectedValue),
                    new SqlParameter("@SoLuong", numSoLuong.Value),
                    new SqlParameter("@GiaNhap", numGiaNhap.Value),
                    new SqlParameter("@OldMaSP", oldMaSP)
                };

                db.ExecuteNonQuery(query, parameters);

                string updateSanPham = "UPDATE SanPham SET GiaNhap = @GiaNhap WHERE MaSP = @NewMaSP";
                SqlParameter[] paramSanPham = {
                    new SqlParameter("@GiaNhap", numGiaNhap.Value),
                    new SqlParameter("@NewMaSP", cbxSanPham.SelectedValue)
                };

                db.ExecuteNonQuery(updateSanPham, paramSanPham);
                MessageBox.Show("Cập nhật sản phẩm thành công!");
            }
            else if (actionState == "TimKiem") // Nếu trước đó nhấn Tìm kiếm
            {
                List<string> conditions = new List<string>(); // Danh sách điều kiện
                List<SqlParameter> parameters = new List<SqlParameter>(); // Danh sách tham số

                parameters.Add(new SqlParameter("@MaNhap", txtMaNhap.Text));

                if (!string.IsNullOrWhiteSpace(cbxSanPham.Text))
                {
                    conditions.Add("MaSP = @MaSP");
                    parameters.Add(new SqlParameter("@MaSP", cbxSanPham.SelectedValue));
                }

                if (numSoLuong.Value > 0)
                {
                    conditions.Add("SoLuong >= @SoLuong");
                    parameters.Add(new SqlParameter("@SoLuong", numSoLuong.Value));
                }

                // Ghép các điều kiện thành câu SQL
                string query = "SELECT * FROM ChiTietNhapHang WHERE MaNhap = @MaNhap";

                if (conditions.Count > 0)
                {
                    query += " AND (" + string.Join(" OR ", conditions) + ")";
                }

                // Thực thi truy vấn
                DataTable dt = db.ExecuteQuery(query, parameters.ToArray());
                dgvChiTietNhapHang.DataSource = dt;

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
        private void dgvChiTietNhapHang_CellClick(object sender, DataGridViewCellEventArgs e)
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
                DataGridViewRow row = dgvChiTietNhapHang.Rows[e.RowIndex];

                oldMaSP = row.Cells["MaSP"].Value.ToString();

                // Gán dữ liệu từ DataGridView vào TextBox
                txtMaNhap.Text = row.Cells["MaNhap"].Value.ToString();
                cbxSanPham.SelectedValue = row.Cells["MaSP"].Value;
                numSoLuong.Value = Convert.ToDecimal(row.Cells["SoLuong"].Value);
                numGiaNhap.Value = Convert.ToDecimal(row.Cells["GiaNhap"].Value);
            }
        }
        private void btnCongSP_Click(object sender, EventArgs e)
        {
            frmSanPham frm = new frmSanPham(isAdmin);
            frm.Show();
        }
    }
}
