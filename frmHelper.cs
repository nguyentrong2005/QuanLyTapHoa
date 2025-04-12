using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTH_BTNhom
{
    internal class frmHelper
    {
        public static void FullScreenForm(Form form)
        {
            Rectangle screen = Screen.PrimaryScreen.Bounds;

            // Đặt kích thước của form bằng kích thước màn hình
            form.Size = new Size(screen.Width, screen.Height);

            // Loại bỏ viền cửa sổ và thanh tiêu đề
            //form.FormBorderStyle = FormBorderStyle.None;

            // Đặt form ở chế độ tối đa
            form.WindowState = FormWindowState.Maximized;
        }
    }
}
