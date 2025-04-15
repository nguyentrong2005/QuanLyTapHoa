using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTH_BTNhom
{
    public partial class frmMain : Form
    {
        private string currentUsername;
        private bool isAdmin;
        public frmMain(string username, bool laQuanTriVien)
        {
            InitializeComponent();
            currentUsername = username;
            isAdmin = laQuanTriVien;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            frmHelper.FullScreenForm(this);
            InitComboBoxDoanhThu();
            ConfigureColors();

            labXinChao.Text = "Xin chào, " + currentUsername;
        }

        private void ConfigureColors()
        {
            this.BackColor = ColorTranslator.FromHtml("#F5F5F5");
            labTitle.ForeColor = ColorTranslator.FromHtml("#32CD32");  // Màu chữ xanh lá cây
            panTitle.BackColor = ColorTranslator.FromHtml("#2F4F4F");  // Màu nền xám đậm
        }

        private void InitComboBoxDoanhThu()
        {
            cbxDoanhThu.Items.Clear();
            cbxDoanhThu.Items.Add("Tháng này");
            cbxDoanhThu.Items.Add("Tháng trước");
            cbxDoanhThu.SelectedIndex = 0;
            cbxDoanhThu.DropDownStyle = ComboBoxStyle.DropDownList;

            cbxDoanhThu.SelectedIndexChanged += cbxDoanhThu_SelectedIndexChanged;

            cbxDoanhThu.SelectedIndex = 0;
            cbxDoanhThu_SelectedIndexChanged(cbxDoanhThu, EventArgs.Empty);
        }

        private void cbxDoanhThu_SelectedIndexChanged(object sender, EventArgs e)
        {
            int thang, nam;

            if (cbxDoanhThu.SelectedItem.ToString() == "Tháng này")
            {
                labDoanhThu.Text = "Doanh thu thuần tháng này";
                thang = DateTime.Now.Month;
                nam = DateTime.Now.Year;
            }
            else // "Tháng trước"
            {
                DateTime thangTruoc = DateTime.Now.AddMonths(-1);
                labDoanhThu.Text = "Doanh thu thuần tháng trước";
                thang = thangTruoc.Month;
                nam = thangTruoc.Year;
            }

            DoanhThuChartHelper.LoadDoanhThuChart(chartDoanhThu, thang, nam);
        }

        private void sảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSanPham frm = new frmSanPham(isAdmin);
            frm.Show();
        }

        private void loạiSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLoaiSanPham frm = new frmLoaiSanPham(isAdmin);
            frm.Show();
        }

        private void nhậpHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNhapHang frm = new frmNhapHang(isAdmin);
            frm.Show();
        }

        private void hóaĐơnBánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHoaDon frm = new frmHoaDon(isAdmin);
            frm.Show();
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKhachHang frm = new frmKhachHang(isAdmin);
            frm.Show();
        }

        private void nhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNhaCungCap frm = new frmNhaCungCap(isAdmin);
            frm.Show();
        }

        private void thốngKêDoanhThuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThongKeDoanhThu frm = new frmThongKeDoanhThu(isAdmin);
            frm.Show();
        }
        private void thốngKêTồnKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThongKeTonKho frm = new frmThongKeTonKho(isAdmin);
            frm.Show();
        }

        private void panTitle_Paint(object sender, PaintEventArgs e)
        {

        }

        private void khoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKho frm = new frmKho(isAdmin);
            frm.Show();
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNhanVien frm = new frmNhanVien(isAdmin);
            frm.Show();
        }
    }
}
