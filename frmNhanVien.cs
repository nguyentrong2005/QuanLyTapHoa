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
    public partial class frmNhanVien : Form
    {
        private DatabaseHelper db = new DatabaseHelper();
        private string actionState = "";
        private bool isAdmin;
        public frmNhanVien(bool isAdmin)
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

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            frmHelper.FullScreenForm(this);
            LoadData();
            LoadColor();
            LockTxtBox(true);

            // Luôn khóa maNV
            txtMaNV.Enabled = false;
        }

        private void LoadData()
        {
            string query = "SELECT * FROM NhanVien";
            DataTable dt = db.ExecuteQuery(query);
            dgvNhanVien.DataSource = dt;

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
            txtTenNV.Enabled = !locked;
            rtxtDiaChi.Enabled = !locked;
            txtSDT.Enabled = !locked;
            txtEmail.Enabled = !locked;
            numLuongCoBan.Enabled = !locked;
            numPhuCap.Enabled = !locked;

            // Nếu khóa thì xóa dữ liệu
            if (locked)
            {
                txtMaNV.Text = "";
                txtTenNV.Text = "";
                rtxtDiaChi.Text = "";
                txtSDT.Text = "";
                txtEmail.Text = "";
                numLuongCoBan.Value = 0;
                numPhuCap.Value = 0;
            }
        }

        private bool ValidateInput()
        {
            if (!(actionState == "TimKiem"))
            {
                if (string.IsNullOrWhiteSpace(txtTenNV.Text) ||
                    string.IsNullOrWhiteSpace(rtxtDiaChi.Text) ||
                    string.IsNullOrWhiteSpace(txtSDT.Text) ||
                    string.IsNullOrWhiteSpace(txtEmail.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (numLuongCoBan.Value <= 0)
                {
                    MessageBox.Show("Lương cơ bản phải lớn hơn 0!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (numPhuCap.Value < 0)
                {
                    MessageBox.Show("Phụ cấp không thể nhỏ hơn 0!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            if (dgvNhanVien.SelectedRows.Count > 0)
            {
                string maNV = dgvNhanVien.SelectedRows[0].Cells["MaNV"].Value.ToString();
                string tenNV = dgvNhanVien.SelectedRows[0].Cells["TenNV"].Value.ToString();

                // Hiển thị hộp thoại xác nhận
                DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa nhân viên \"{tenNV}\" không?",
                                                      "Xác nhận xóa",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Warning);

                if (result == DialogResult.Yes) // Nếu người dùng nhấn "Yes"
                {
                    string query = "DELETE FROM NhanVien WHERE MaNV = @MaNV";
                    SqlParameter[] parameters = { new SqlParameter("@MaNV", maNV) };

                    db.ExecuteNonQuery(query, parameters);
                    LoadData();
                    LockTxtBox(true);
                    MessageBox.Show("Xóa nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            // Nếu trước đó nhấn Thêm
            if (actionState == "Them")
            {
                string query = "INSERT INTO NhanVien (TenNV, DiaChi, SoDienThoai, Email, LuongCoBan, PhuCap) VALUES (@TenKH, @DiaChi, @SoDienThoai, @Email, @LuongCoBan, @PhuCap)";
                SqlParameter[] parameters = {
                    new SqlParameter("@TenNV", txtTenNV.Text),
                    new SqlParameter("@DiaChi", rtxtDiaChi.Text),
                    new SqlParameter("@SoDienThoai", txtSDT.Text),
                    new SqlParameter("@Email", txtEmail.Text),
                    new SqlParameter("@LuongCoBan", numLuongCoBan.Value),
                    new SqlParameter("@PhuCap", numPhuCap.Value)
                };

                db.ExecuteNonQuery(query, parameters);
                MessageBox.Show("Thêm nhân viên thành công!");
            }
            else if (actionState == "Sua") // Nếu trước đó nhấn Sửa
            {
                string query = "UPDATE NhanVien SET TenNV = @TenNV, DiaChi = @DiaChi, SoDienThoai = @SoDienThoai, Email = @Email, LuongCoBan = @LuongCoBan, PhuCap = @PhuCap WHERE MaNV = @MaNV";
                SqlParameter[] parameters = {
                    new SqlParameter("@TenNV", txtTenNV.Text),
                    new SqlParameter("@DiaChi", rtxtDiaChi.Text),
                    new SqlParameter("@SoDienThoai", txtSDT.Text),
                    new SqlParameter("@Email", txtEmail.Text),
                    new SqlParameter("@MaNV", txtMaNV.Text),
                    new SqlParameter("@LuongCoBan", numLuongCoBan.Value),
                    new SqlParameter("@PhuCap", numPhuCap.Value)
                };

                db.ExecuteNonQuery(query, parameters);
                MessageBox.Show("Cập nhật nhân viên thành công!");
            }
            else if (actionState == "TimKiem") // Nếu trước đó nhấn Tìm kiếm
            {
                List<string> conditions = new List<string>(); // Danh sách điều kiện
                List<SqlParameter> parameters = new List<SqlParameter>(); // Danh sách tham số

                if (!string.IsNullOrEmpty(txtTenNV.Text.Trim()))
                {
                    conditions.Add("TenNV LIKE @TenNV");
                    parameters.Add(new SqlParameter("@TenNV", $"%{txtTenNV.Text.Trim()}%"));
                }

                if (!string.IsNullOrEmpty(txtSDT.Text.Trim()))
                {
                    conditions.Add("SoDienThoai LIKE @SoDienThoai");
                    parameters.Add(new SqlParameter("@SoDienThoai", $"%{txtSDT.Text.Trim()}%"));
                }

                if (!string.IsNullOrEmpty(rtxtDiaChi.Text.Trim()))
                {
                    conditions.Add("DiaChi LIKE @DiaChi");
                    parameters.Add(new SqlParameter("@DiaChi", $"%{rtxtDiaChi.Text.Trim()}%"));
                }

                if (!string.IsNullOrEmpty(txtEmail.Text.Trim()))
                {
                    conditions.Add("Email LIKE @Email");
                    parameters.Add(new SqlParameter("@Email", $"%{txtEmail.Text.Trim()}%"));
                }

                if (numLuongCoBan.Value > 0)
                {
                    conditions.Add("LuongCoBan >= @LuongCoBan");
                    parameters.Add(new SqlParameter("@LuongCoBan", numLuongCoBan.Value));
                }

                if (numPhuCap.Value > 0)
                {
                    conditions.Add("PhuCap >= @PhuCap");
                    parameters.Add(new SqlParameter("@PhuCap", numPhuCap.Value));
                }

                // Ghép các điều kiện thành câu SQL
                string query = "SELECT * FROM NhanVien WHERE " + string.Join(" OR ", conditions);

                // Thực thi truy vấn
                DataTable dt = db.ExecuteQuery(query, parameters.ToArray());

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy kết quả phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                dgvNhanVien.DataSource = dt;
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
        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
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
                DataGridViewRow row = dgvNhanVien.Rows[e.RowIndex];

                // Gán dữ liệu từ DataGridView vào TextBox
                txtMaNV.Text = row.Cells["MaNV"].Value.ToString();
                txtTenNV.Text = row.Cells["TenNV"].Value.ToString();
                rtxtDiaChi.Text = row.Cells["DiaChi"].Value.ToString();
                txtSDT.Text = row.Cells["SoDienThoai"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                numLuongCoBan.Value = Convert.ToDecimal(row.Cells["LuongCoBan"].Value);
                numPhuCap.Value = Convert.ToDecimal(row.Cells["PhuCap"].Value);
            }
        }
    }
}
