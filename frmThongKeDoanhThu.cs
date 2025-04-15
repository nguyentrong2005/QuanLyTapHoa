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
    public partial class frmThongKeDoanhThu : Form
    {
        private bool isAdmin;
        public frmThongKeDoanhThu(bool isAdmin)
        {
            InitializeComponent();
            this.isAdmin = isAdmin;
        }

        private void frmThongKeDoanhThu_Load(object sender, EventArgs e)
        {
            frmHelper.FullScreenForm(this);
            InitComboBoxThangNam();
            InitComboBoxHTTT();
            LockCBX(true);

            txtTongDoanhThu.Enabled = false;
        }

        private void InitComboBoxThangNam()
        {
            int currentYear = DateTime.Now.Year;
            for (int year = currentYear - 5; year <= currentYear; year++)
                cbxNam.Items.Add(year);

            for (int month = 1; month <= 12; month++)
                cbxThang.Items.Add(month);

            cbxNam.SelectedIndex = cbxNam.Items.Count - 1;
            cbxThang.SelectedIndex = DateTime.Now.Month - 1;
        }

        private void InitComboBoxHTTT()
        {
            cbxHTTT.Items.Add("Tiền mặt");
            cbxHTTT.Items.Add("Thẻ");
            cbxHTTT.Items.Add("Chuyển khoản");
            cbxHTTT.Items.Add("Momo");
            cbxHTTT.Items.Add("ZaloPay");
            cbxHTTT.Items.Add("Khác");

            cbxHTTT.SelectedIndex = 0;
        }

        private void LockCBX(bool locked)
        {
            cbxHTTT.Enabled = !locked;
            cbxNam.Enabled = !locked;
            cbxThang.Enabled = !locked;
        }

        private bool ValidateInput()
        {
            if (cbxNam.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn NĂM để thống kê.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbxNam.Focus();
                return false;
            }

            if (cbxThang.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn THÁNG để thống kê theo ngày.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbxThang.Focus();
                return false;
            }

            if (cbxHTTT.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn HÌNH THỨC THANH TOÁN.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbxHTTT.Focus();
                return false;
            }

            return true;
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            LockCBX(false);
            btnLuu.Enabled = true;
            btnThongKe.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            int nam = Convert.ToInt32(cbxNam.SelectedItem);
            int thang = Convert.ToInt32(cbxThang.SelectedItem);
            string httt = cbxHTTT.SelectedItem.ToString();

            DoanhThuChartHelper.LoadDoanhThuChart(chartDoanhThu, thang, nam, httt);
            double tong = DoanhThuChartHelper.GetTongDoanhThu(thang, nam, httt);
            txtTongDoanhThu.Text = tong.ToString("N0") + " đ";
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LockCBX(true);
            btnThongKe.Enabled = true;
            btnLuu.Enabled = false;
            txtTongDoanhThu.Text = "";
            cbxNam.SelectedIndex = cbxNam.Items.Count - 1;
            cbxThang.SelectedIndex = DateTime.Now.Month - 1;
        }
    }
}
