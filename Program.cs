using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTH_BTNhom
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            DatabaseHelper db = new DatabaseHelper();
            bool isConnected = db.TestConnection();

            if (isConnected)
            {
                MessageBox.Show(" Kết nối thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Run(new frmDangNhap());
            }
            else
            {
                MessageBox.Show(" Kết nối thất bại! Kiểm tra lại server và database.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
