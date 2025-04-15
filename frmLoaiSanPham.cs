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
    public partial class frmLoaiSanPham : Form
    {
        private DatabaseHelper db = new DatabaseHelper();
        private string actionState = "";
        private bool isAdmin;

        public frmLoaiSanPham(bool isAdmin)
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

        private void frmLoaiSanPham_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadColor();
            LockTxtBox(true);

            // Luôn khóa maKH
            txtMaLoaiSP.Enabled = false;
            frmHelper.FullScreenForm(this);
        }

        private void LoadData()
        {
            string query = "SELECT * FROM LoaiSanPham";
            DataTable dt = db.ExecuteQuery(query);
            dgvLoaiSP.DataSource = dt;

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
            txtTenLoaiSP.Enabled = !locked;

            // Nếu khóa thì xóa dữ liệu
            if (locked)
            {
                txtMaLoaiSP.Text = "";
                txtTenLoaiSP.Text = "";
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtTenLoaiSP.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
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
            if (dgvLoaiSP.SelectedRows.Count > 0)
            {
                string maLoaiSP = dgvLoaiSP.SelectedRows[0].Cells["MaLoaiSP"].Value.ToString();
                string tenLoaiSP = dgvLoaiSP.SelectedRows[0].Cells["TenLoaiSP"].Value.ToString();

                // Hiển thị hộp thoại xác nhận
                DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa loại sản phẩm \"{tenLoaiSP}\" không?",
                                                      "Xác nhận xóa",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Warning);

                if (result == DialogResult.Yes) // Nếu người dùng nhấn "Yes"
                {
                    string query = "DELETE FROM LoaiSanPham WHERE MaLoaiSP = @MaLoaiSP";
                    SqlParameter[] parameters = { new SqlParameter("@MaLoaiSP", maLoaiSP) };

                    db.ExecuteNonQuery(query, parameters);
                    LoadData();
                    LockTxtBox(true);
                    MessageBox.Show("Xóa loại sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn loại sản phẩm cần xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            // Nếu trước đó nhấn Thêm
            if (actionState == "Them")
            {
                string query = "INSERT INTO LoaiSanPham (TenLoaiSP) VALUES (@TenLoaiSP)";
                SqlParameter[] parameters = {
                    new SqlParameter("@TenLoaiSP", txtTenLoaiSP.Text)
                };

                db.ExecuteNonQuery(query, parameters);
                MessageBox.Show("Thêm loại sản phẩm thành công!");
            }
            else if (actionState == "Sua") // Nếu trước đó nhấn Sửa
            {
                string query = "UPDATE LoaiSanPham SET TenLoaiSP = @TenLoaiSP WHERE MaLoaiSP = @MaLoaiSP";
                SqlParameter[] parameters = {
                    new SqlParameter("@TenLoaiSP", txtTenLoaiSP.Text),
                    new SqlParameter("@MaLoaiSP", txtMaLoaiSP.Text)
                };

                db.ExecuteNonQuery(query, parameters);
                MessageBox.Show("Cập nhật loại sản phẩm thành công!");
            }
            else if (actionState == "TimKiem")
            {
                List<string> conditions = new List<string>(); // Danh sách điều kiện
                List<SqlParameter> parameters = new List<SqlParameter>(); // Danh sách tham số

                if (!string.IsNullOrEmpty(txtTenLoaiSP.Text.Trim()))
                {
                    conditions.Add("TenLoaiSP LIKE @TenLoaiSP");
                    parameters.Add(new SqlParameter("@TenLoaiSP", $"%{txtTenLoaiSP.Text.Trim()}%"));
                }


                // Ghép các điều kiện thành câu SQL
                string query = "SELECT * FROM LoaiSanPham WHERE " + string.Join(" OR ", conditions);

                // Thực thi truy vấn
                DataTable dt = db.ExecuteQuery(query, parameters.ToArray());

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy kết quả phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                dgvLoaiSP.DataSource = dt;
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
        private void dgvLoaiSP_CellClick(object sender, DataGridViewCellEventArgs e)
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
                DataGridViewRow row = dgvLoaiSP.Rows[e.RowIndex];

                // Gán dữ liệu từ DataGridView vào TextBox
                txtMaLoaiSP.Text = row.Cells["MaLoaiSP"].Value.ToString();
                txtTenLoaiSP.Text = row.Cells["TenLoaiSP"].Value.ToString();
            }
        }

        private void dgvLoaiSP_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
