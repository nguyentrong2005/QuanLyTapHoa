namespace QLTH_BTNhom
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.labTitle = new System.Windows.Forms.Label();
            this.panTitle = new System.Windows.Forms.Panel();
            this.msMenu = new System.Windows.Forms.MenuStrip();
            this.danhMụcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sảnPhẩmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loạiSảnPhẩmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.khoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.giaoDịchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nhậpHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hóaĐơnBánToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.báoCáoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kháchHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nhàCungCấpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.báoCáoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.thốngKêDoanhThuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thốngKêTồnKhoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nhânViênToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panMenu = new System.Windows.Forms.Panel();
            this.chartDoanhThu = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.labDoanhThu = new System.Windows.Forms.Label();
            this.cbxDoanhThu = new System.Windows.Forms.ComboBox();
            this.labXinChao = new System.Windows.Forms.Label();
            this.panTitle.SuspendLayout();
            this.msMenu.SuspendLayout();
            this.panMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThu)).BeginInit();
            this.SuspendLayout();
            // 
            // labTitle
            // 
            this.labTitle.AutoSize = true;
            this.labTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 40.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labTitle.Location = new System.Drawing.Point(563, 30);
            this.labTitle.Name = "labTitle";
            this.labTitle.Size = new System.Drawing.Size(865, 76);
            this.labTitle.TabIndex = 0;
            this.labTitle.Text = "Phần mềm Quản Lý tạp hóa";
            this.labTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panTitle
            // 
            this.panTitle.Controls.Add(this.labTitle);
            this.panTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTitle.Location = new System.Drawing.Point(0, 0);
            this.panTitle.Name = "panTitle";
            this.panTitle.Size = new System.Drawing.Size(1924, 138);
            this.panTitle.TabIndex = 1;
            this.panTitle.Paint += new System.Windows.Forms.PaintEventHandler(this.panTitle_Paint);
            // 
            // msMenu
            // 
            this.msMenu.Dock = System.Windows.Forms.DockStyle.None;
            this.msMenu.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.msMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.msMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.danhMụcToolStripMenuItem,
            this.giaoDịchToolStripMenuItem,
            this.báoCáoToolStripMenuItem,
            this.báoCáoToolStripMenuItem1,
            this.nhânViênToolStripMenuItem});
            this.msMenu.Location = new System.Drawing.Point(9, 22);
            this.msMenu.Name = "msMenu";
            this.msMenu.Size = new System.Drawing.Size(830, 53);
            this.msMenu.TabIndex = 2;
            this.msMenu.Text = "menuStrip1";
            // 
            // danhMụcToolStripMenuItem
            // 
            this.danhMụcToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sảnPhẩmToolStripMenuItem,
            this.loạiSảnPhẩmToolStripMenuItem,
            this.khoToolStripMenuItem});
            this.danhMụcToolStripMenuItem.Name = "danhMụcToolStripMenuItem";
            this.danhMụcToolStripMenuItem.Size = new System.Drawing.Size(183, 49);
            this.danhMụcToolStripMenuItem.Text = "Danh mục";
            // 
            // sảnPhẩmToolStripMenuItem
            // 
            this.sảnPhẩmToolStripMenuItem.Name = "sảnPhẩmToolStripMenuItem";
            this.sảnPhẩmToolStripMenuItem.Size = new System.Drawing.Size(325, 50);
            this.sảnPhẩmToolStripMenuItem.Text = "Sản phẩm";
            this.sảnPhẩmToolStripMenuItem.Click += new System.EventHandler(this.sảnPhẩmToolStripMenuItem_Click);
            // 
            // loạiSảnPhẩmToolStripMenuItem
            // 
            this.loạiSảnPhẩmToolStripMenuItem.Name = "loạiSảnPhẩmToolStripMenuItem";
            this.loạiSảnPhẩmToolStripMenuItem.Size = new System.Drawing.Size(325, 50);
            this.loạiSảnPhẩmToolStripMenuItem.Text = "Loại sản phẩm";
            this.loạiSảnPhẩmToolStripMenuItem.Click += new System.EventHandler(this.loạiSảnPhẩmToolStripMenuItem_Click);
            // 
            // khoToolStripMenuItem
            // 
            this.khoToolStripMenuItem.Name = "khoToolStripMenuItem";
            this.khoToolStripMenuItem.Size = new System.Drawing.Size(325, 50);
            this.khoToolStripMenuItem.Text = "Kho";
            this.khoToolStripMenuItem.Click += new System.EventHandler(this.khoToolStripMenuItem_Click);
            // 
            // giaoDịchToolStripMenuItem
            // 
            this.giaoDịchToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nhậpHàngToolStripMenuItem,
            this.hóaĐơnBánToolStripMenuItem});
            this.giaoDịchToolStripMenuItem.Name = "giaoDịchToolStripMenuItem";
            this.giaoDịchToolStripMenuItem.Size = new System.Drawing.Size(171, 49);
            this.giaoDịchToolStripMenuItem.Text = "Giao dịch";
            // 
            // nhậpHàngToolStripMenuItem
            // 
            this.nhậpHàngToolStripMenuItem.Name = "nhậpHàngToolStripMenuItem";
            this.nhậpHàngToolStripMenuItem.Size = new System.Drawing.Size(304, 50);
            this.nhậpHàngToolStripMenuItem.Text = "Nhập hàng";
            this.nhậpHàngToolStripMenuItem.Click += new System.EventHandler(this.nhậpHàngToolStripMenuItem_Click);
            // 
            // hóaĐơnBánToolStripMenuItem
            // 
            this.hóaĐơnBánToolStripMenuItem.Name = "hóaĐơnBánToolStripMenuItem";
            this.hóaĐơnBánToolStripMenuItem.Size = new System.Drawing.Size(304, 50);
            this.hóaĐơnBánToolStripMenuItem.Text = "Hóa đơn bán";
            this.hóaĐơnBánToolStripMenuItem.Click += new System.EventHandler(this.hóaĐơnBánToolStripMenuItem_Click);
            // 
            // báoCáoToolStripMenuItem
            // 
            this.báoCáoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kháchHàngToolStripMenuItem,
            this.nhàCungCấpToolStripMenuItem});
            this.báoCáoToolStripMenuItem.Name = "báoCáoToolStripMenuItem";
            this.báoCáoToolStripMenuItem.Size = new System.Drawing.Size(136, 49);
            this.báoCáoToolStripMenuItem.Text = "Đối tác";
            // 
            // kháchHàngToolStripMenuItem
            // 
            this.kháchHàngToolStripMenuItem.Name = "kháchHàngToolStripMenuItem";
            this.kháchHàngToolStripMenuItem.Size = new System.Drawing.Size(316, 50);
            this.kháchHàngToolStripMenuItem.Text = "Khách hàng";
            this.kháchHàngToolStripMenuItem.Click += new System.EventHandler(this.kháchHàngToolStripMenuItem_Click);
            // 
            // nhàCungCấpToolStripMenuItem
            // 
            this.nhàCungCấpToolStripMenuItem.Name = "nhàCungCấpToolStripMenuItem";
            this.nhàCungCấpToolStripMenuItem.Size = new System.Drawing.Size(316, 50);
            this.nhàCungCấpToolStripMenuItem.Text = "Nhà cung cấp";
            this.nhàCungCấpToolStripMenuItem.Click += new System.EventHandler(this.nhàCungCấpToolStripMenuItem_Click);
            // 
            // báoCáoToolStripMenuItem1
            // 
            this.báoCáoToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thốngKêDoanhThuToolStripMenuItem,
            this.thốngKêTồnKhoToolStripMenuItem});
            this.báoCáoToolStripMenuItem1.Name = "báoCáoToolStripMenuItem1";
            this.báoCáoToolStripMenuItem1.Size = new System.Drawing.Size(149, 49);
            this.báoCáoToolStripMenuItem1.Text = "Báo cáo";
            // 
            // thốngKêDoanhThuToolStripMenuItem
            // 
            this.thốngKêDoanhThuToolStripMenuItem.Name = "thốngKêDoanhThuToolStripMenuItem";
            this.thốngKêDoanhThuToolStripMenuItem.Size = new System.Drawing.Size(409, 50);
            this.thốngKêDoanhThuToolStripMenuItem.Text = "Thống kê doanh thu";
            this.thốngKêDoanhThuToolStripMenuItem.Click += new System.EventHandler(this.thốngKêDoanhThuToolStripMenuItem_Click);
            // 
            // thốngKêTồnKhoToolStripMenuItem
            // 
            this.thốngKêTồnKhoToolStripMenuItem.Name = "thốngKêTồnKhoToolStripMenuItem";
            this.thốngKêTồnKhoToolStripMenuItem.Size = new System.Drawing.Size(409, 50);
            this.thốngKêTồnKhoToolStripMenuItem.Text = "Thống kê tồn kho";
            this.thốngKêTồnKhoToolStripMenuItem.Click += new System.EventHandler(this.thốngKêTồnKhoToolStripMenuItem_Click);
            // 
            // nhânViênToolStripMenuItem
            // 
            this.nhânViênToolStripMenuItem.Name = "nhânViênToolStripMenuItem";
            this.nhânViênToolStripMenuItem.Size = new System.Drawing.Size(183, 49);
            this.nhânViênToolStripMenuItem.Text = "Nhân viên";
            this.nhânViênToolStripMenuItem.Click += new System.EventHandler(this.nhânViênToolStripMenuItem_Click);
            // 
            // panMenu
            // 
            this.panMenu.Controls.Add(this.labXinChao);
            this.panMenu.Controls.Add(this.msMenu);
            this.panMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panMenu.Location = new System.Drawing.Point(0, 138);
            this.panMenu.Name = "panMenu";
            this.panMenu.Size = new System.Drawing.Size(1924, 100);
            this.panMenu.TabIndex = 3;
            // 
            // chartDoanhThu
            // 
            chartArea2.Name = "ChartArea1";
            this.chartDoanhThu.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartDoanhThu.Legends.Add(legend2);
            this.chartDoanhThu.Location = new System.Drawing.Point(19, 347);
            this.chartDoanhThu.Name = "chartDoanhThu";
            this.chartDoanhThu.Size = new System.Drawing.Size(1893, 805);
            this.chartDoanhThu.TabIndex = 4;
            this.chartDoanhThu.Text = "chart1";
            // 
            // labDoanhThu
            // 
            this.labDoanhThu.AutoSize = true;
            this.labDoanhThu.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labDoanhThu.Location = new System.Drawing.Point(12, 265);
            this.labDoanhThu.Name = "labDoanhThu";
            this.labDoanhThu.Size = new System.Drawing.Size(409, 38);
            this.labDoanhThu.TabIndex = 5;
            this.labDoanhThu.Text = "Doanh thu thuần tháng này";
            // 
            // cbxDoanhThu
            // 
            this.cbxDoanhThu.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxDoanhThu.FormattingEnabled = true;
            this.cbxDoanhThu.Location = new System.Drawing.Point(1662, 258);
            this.cbxDoanhThu.Name = "cbxDoanhThu";
            this.cbxDoanhThu.Size = new System.Drawing.Size(250, 46);
            this.cbxDoanhThu.TabIndex = 6;
            // 
            // labXinChao
            // 
            this.labXinChao.AutoSize = true;
            this.labXinChao.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labXinChao.Location = new System.Drawing.Point(1504, 36);
            this.labXinChao.Name = "labXinChao";
            this.labXinChao.Size = new System.Drawing.Size(0, 39);
            this.labXinChao.TabIndex = 3;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1924, 1175);
            this.Controls.Add(this.cbxDoanhThu);
            this.Controls.Add(this.labDoanhThu);
            this.Controls.Add(this.chartDoanhThu);
            this.Controls.Add(this.panMenu);
            this.Controls.Add(this.panTitle);
            this.MainMenuStrip = this.msMenu;
            this.Name = "frmMain";
            this.Text = "frmMain";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.panTitle.ResumeLayout(false);
            this.panTitle.PerformLayout();
            this.msMenu.ResumeLayout(false);
            this.msMenu.PerformLayout();
            this.panMenu.ResumeLayout(false);
            this.panMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labTitle;
        private System.Windows.Forms.Panel panTitle;
        private System.Windows.Forms.MenuStrip msMenu;
        private System.Windows.Forms.ToolStripMenuItem danhMụcToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sảnPhẩmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loạiSảnPhẩmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem giaoDịchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nhậpHàngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hóaĐơnBánToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem báoCáoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kháchHàngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nhàCungCấpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem báoCáoToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem thốngKêDoanhThuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thốngKêTồnKhoToolStripMenuItem;
        private System.Windows.Forms.Panel panMenu;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDoanhThu;
        private System.Windows.Forms.Label labDoanhThu;
        private System.Windows.Forms.ComboBox cbxDoanhThu;
        private System.Windows.Forms.ToolStripMenuItem khoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nhânViênToolStripMenuItem;
        private System.Windows.Forms.Label labXinChao;
    }
}