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
    public partial class frmThongKeTonKho : Form
    {
        private DatabaseHelper db = new DatabaseHelper();
        public frmThongKeTonKho()
        {
            InitializeComponent();
        }
        private void frmThongKeTonKho_Load(object sender, EventArgs e)
        {
            frmHelper.FullScreenForm(this);
            LoadData();
            Lock(true);
        }
        private void LoadData()
        {
            LoadDGV();
            LoadNam();
            LoadThang();
            LoadLoaiSP();
            LoadSP();
            LoadNCC();
            LoadKho();
        }
        private void LoadDGV()
        {
            string query = @"
            SELECT 
                YEAR(NH.NgayNhap) AS Nam,
                MONTH(NH.NgayNhap) AS Thang,
                SP.MaSP,
                SP.TenSP,
                LSP.TenLoaiSP,
                NCC.TenNCC,
                K.TenKho,
                SUM(CTNH.SoLuong) AS TongNhap,
                ISNULL(SUM(CTHD.SoLuong), 0) AS TongXuat,
                SUM(CTNH.SoLuong) - ISNULL(SUM(CTHD.SoLuong), 0) AS SoLuongTon
            FROM SanPham SP
            JOIN LoaiSanPham LSP ON SP.MaLoaiSP = LSP.MaLoaiSP
            JOIN NhaCungCap NCC ON SP.MaNCC = NCC.MaNCC
            JOIN ChiTietNhapHang CTNH ON SP.MaSP = CTNH.MaSP
            JOIN NhapHang NH ON CTNH.MaNhap = NH.MaNhap
            JOIN Kho K ON NH.MaKho = K.MaKho
            LEFT JOIN ChiTietHoaDon CTHD ON SP.MaSP = CTHD.MaSP
            LEFT JOIN HoaDon HD ON CTHD.MaHD = HD.MaHD
            GROUP BY 
                YEAR(NH.NgayNhap), MONTH(NH.NgayNhap),
                SP.MaSP, SP.TenSP, LSP.TenLoaiSP, NCC.TenNCC, K.TenKho";

            DataTable dt = db.ExecuteQuery(query);
            dgvTonKho.DataSource = dt;

            // Tuỳ chỉnh hiển thị cột
            dgvTonKho.Columns["Nam"].HeaderText = "Năm";
            dgvTonKho.Columns["Thang"].HeaderText = "Tháng";
            dgvTonKho.Columns["MaSP"].HeaderText = "Mã SP";
            dgvTonKho.Columns["TenSP"].HeaderText = "Tên SP";
            dgvTonKho.Columns["TenLoaiSP"].HeaderText = "Loại SP";
            dgvTonKho.Columns["TenNCC"].HeaderText = "Nhà cung cấp";
            dgvTonKho.Columns["TenKho"].HeaderText = "Kho";
            dgvTonKho.Columns["TongNhap"].HeaderText = "Tổng nhập";
            dgvTonKho.Columns["TongXuat"].HeaderText = "Tổng xuất";
            dgvTonKho.Columns["SoLuongTon"].HeaderText = "Tồn kho";

            dgvTonKho.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //Điểu chỉnh cột
            dgvTonKho.Columns["TenNCC"].Width = 210;
        }
        private void LoadNam()
        {
            cbxNam.Items.Clear();
            for (int year = 2020; year <= DateTime.Now.Year; year++)
            {
                cbxNam.Items.Add(year);
            }
            cbxNam.SelectedIndex = -1;

            cbxNam.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void LoadThang()
        {
            cbxThang.Items.Clear();
            for (int month = 1; month <= 12; month++)
            {
                cbxThang.Items.Add(month);
            }
            cbxThang.SelectedIndex = -1;

            cbxThang.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void LoadLoaiSP()
        {
            string queryLoaiSP = "SELECT MaLoaiSP, TenLoaiSP FROM LoaiSanPham";
            DataTable dtLoaiSP = db.ExecuteQuery(queryLoaiSP);
            cbxLoaiSP.DataSource = dtLoaiSP;
            cbxLoaiSP.DisplayMember = "TenLoaiSP";
            cbxLoaiSP.ValueMember = "MaLoaiSP";
            cbxLoaiSP.SelectedIndex = -1;

            cbxLoaiSP.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void LoadSP()
        {
            string querySP = "SELECT MaSP, TenSP FROM SanPham";
            DataTable dtSP = db.ExecuteQuery(querySP);
            cbxSP.DataSource = dtSP;
            cbxSP.DisplayMember = "TenSP";
            cbxSP.ValueMember = "MaSP";
            cbxSP.SelectedIndex = -1;

            cbxSP.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void LoadNCC()
        {
            string queryNCC = "SELECT MaNCC, TenNCC FROM NhaCungCap";
            DataTable dtNCC = db.ExecuteQuery(queryNCC);
            cbxNCC.DataSource = dtNCC;
            cbxNCC.DisplayMember = "TenNCC";
            cbxNCC.ValueMember = "MaNCC";
            cbxNCC.SelectedIndex = -1;

            cbxNCC.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void LoadKho()
        {
            string queryKho = "SELECT MaKho, TenKho FROM Kho";
            DataTable dtKho = db.ExecuteQuery(queryKho);
            cbxKho.DataSource = dtKho;
            cbxKho.DisplayMember = "TenKho";
            cbxKho.ValueMember = "MaKho";
            cbxKho.SelectedIndex = -1;

            cbxKho.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void Lock(bool locked)
        {
            // Luôn khóa
            txtTongNhap.Enabled = false;
            txtTongXuat.Enabled = false;
            txtTonKho.Enabled = false;

            cbxNam.Enabled = !locked;
            cbxThang.Enabled = !locked;
            cbxLoaiSP.Enabled = !locked;
            cbxSP.Enabled = !locked;
            cbxNCC.Enabled = !locked;
            cbxKho.Enabled = !locked;

            // Xóa dữ liệu
            cbxNam.SelectedIndex = -1;
            cbxThang.SelectedIndex = -1;
            cbxLoaiSP.SelectedIndex = -1;
            cbxSP.SelectedIndex = -1;
            cbxKho.SelectedIndex = -1;
            txtTongNhap.Text = "";
            txtTongXuat.Text = "";
            txtTonKho.Text = "";
        }
        private bool ValidateInput()
        {
            if ((cbxNam.SelectedIndex == -1) &&
                (cbxThang.SelectedIndex == -1) &&
                (cbxLoaiSP.SelectedIndex == -1) &&
                (cbxSP.SelectedIndex == -1) &&
                (cbxKho.SelectedIndex == -1))
            {
                MessageBox.Show("Vui lòng nhập ít nhất 1 thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            Lock(false);

            btnLuu.Enabled = true;
            btnTimKiem.Enabled = false;
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            StringBuilder query = new StringBuilder(@"
                SELECT 
                    YEAR(NH.NgayNhap) AS Nam,
                    MONTH(NH.NgayNhap) AS Thang,
                    SP.MaSP,
                    SP.TenSP,
                    LSP.TenLoaiSP,
                    NCC.TenNCC,
                    K.TenKho,
                    SUM(CTNH.SoLuong) AS TongNhap,
                    ISNULL(SUM(CTHD.SoLuong), 0) AS TongXuat,
                    SUM(CTNH.SoLuong) - ISNULL(SUM(CTHD.SoLuong), 0) AS SoLuongTon
                FROM SanPham SP
                JOIN LoaiSanPham LSP ON SP.MaLoaiSP = LSP.MaLoaiSP
                JOIN NhaCungCap NCC ON SP.MaNCC = NCC.MaNCC
                JOIN ChiTietNhapHang CTNH ON SP.MaSP = CTNH.MaSP
                JOIN NhapHang NH ON CTNH.MaNhap = NH.MaNhap
                JOIN Kho K ON NH.MaKho = K.MaKho
                LEFT JOIN ChiTietHoaDon CTHD ON SP.MaSP = CTHD.MaSP
                LEFT JOIN HoaDon HD ON CTHD.MaHD = HD.MaHD
                WHERE 1 = 1
            ");

            if (cbxNam.SelectedIndex != -1)
                query.Append(" AND YEAR(NH.NgayNhap) = " + cbxNam.SelectedItem);

            if (cbxThang.SelectedIndex != -1)
                query.Append(" AND MONTH(NH.NgayNhap) = " + cbxThang.SelectedItem);

            if (cbxLoaiSP.SelectedIndex != -1)
                query.Append(" AND LSP.MaLoaiSP = '" + cbxLoaiSP.SelectedValue + "'");

            if (cbxSP.SelectedIndex != -1)
                query.Append(" AND SP.MaSP = '" + cbxSP.SelectedValue + "'");

            if (cbxNCC.SelectedIndex != -1)
                query.Append(" AND NCC.MaNCC = '" + cbxNCC.SelectedValue + "'");

            if (cbxKho.SelectedIndex != -1)
                query.Append(" AND K.MaKho = '" + cbxKho.SelectedValue + "'");

            query.Append(@"
                GROUP BY 
                    YEAR(NH.NgayNhap), MONTH(NH.NgayNhap),
                    SP.MaSP, SP.TenSP, LSP.TenLoaiSP, NCC.TenNCC, K.TenKho
            ");

            DataTable dt = db.ExecuteQuery(query.ToString());
            dgvTonKho.DataSource = dt;

            if (dt.Rows.Count > 0)
            {
                int tongNhap = Convert.ToInt32(dt.Compute("SUM(TongNhap)", ""));
                int tongXuat = Convert.ToInt32(dt.Compute("SUM(TongXuat)", ""));
                int tonKho = Convert.ToInt32(dt.Compute("SUM(SoLuongTon)", ""));

                txtTongNhap.Text = tongNhap.ToString();
                txtTongXuat.Text = tongXuat.ToString();
                txtTonKho.Text = tonKho.ToString();
            }
            else
            {
                txtTongNhap.Text = "0";
                txtTongXuat.Text = "0";
                txtTonKho.Text = "0";
                MessageBox.Show("Không tìm thấy dữ liệu phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            Lock(true);
            btnLuu.Enabled = false;
            btnTimKiem.Enabled = true;
        }
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadData();

            btnTimKiem.Enabled = true;
            btnLuu.Enabled = false;

            Lock(true);
        }
        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvTonKho.Rows[e.RowIndex];

                cbxNam.Text = row.Cells["Nam"].Value.ToString();
                cbxThang.Text = row.Cells["Thang"].Value.ToString();
                cbxSP.Text = row.Cells["TenSP"].Value.ToString();
                cbxLoaiSP.Text = row.Cells["TenLoaiSP"].Value.ToString();
                cbxNCC.Text = row.Cells["TenNCC"].Value.ToString();
                cbxKho.Text = row.Cells["TenKho"].Value.ToString();

                txtTongNhap.Text = row.Cells["TongNhap"].Value.ToString();
                txtTongXuat.Text = row.Cells["TongXuat"].Value.ToString();
                txtTonKho.Text = row.Cells["SoLuongTon"].Value.ToString();
            }
        }
        private void btnCongLoaiSP_Click(object sender, EventArgs e)
        {
            frmLoaiSanPham frm = new frmLoaiSanPham();
            frm.Show();
        }
        private void btnCongNCC_Click(object sender, EventArgs e)
        {
            frmNhaCungCap frm = new frmNhaCungCap();
            frm.Show();
        }
        private void btnCongSP_Click(object sender, EventArgs e)
        {
            frmSanPham frm = new frmSanPham();
            frm.Show();
        }
        private void btnCongKho_Click(object sender, EventArgs e)
        {
            frmKho frm = new frmKho();
            frm.Show();
        }
    }
}
