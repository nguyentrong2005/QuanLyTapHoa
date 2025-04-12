namespace QLTH_BTNhom
{
    partial class frmSanPham
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.labMaSP = new System.Windows.Forms.Label();
            this.labTenSP = new System.Windows.Forms.Label();
            this.labMaLoaiSP = new System.Windows.Forms.Label();
            this.labMaNCC = new System.Windows.Forms.Label();
            this.labGiaNhap = new System.Windows.Forms.Label();
            this.labGiaBan = new System.Windows.Forms.Label();
            this.labSoLuongTon = new System.Windows.Forms.Label();
            this.labNgayHetHan = new System.Windows.Forms.Label();
            this.txtMaSP = new System.Windows.Forms.TextBox();
            this.txtTenSP = new System.Windows.Forms.TextBox();
            this.cbxLoaiSP = new System.Windows.Forms.ComboBox();
            this.cbxNCC = new System.Windows.Forms.ComboBox();
            this.numGiaBan = new System.Windows.Forms.NumericUpDown();
            this.numSoLuongTon = new System.Windows.Forms.NumericUpDown();
            this.numGiaNhap = new System.Windows.Forms.NumericUpDown();
            this.dtpNgayHetHan = new System.Windows.Forms.DateTimePicker();
            this.btnCongLoaiSP = new System.Windows.Forms.Button();
            this.btnCongNCC = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.dgvSanPham = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.numGiaBan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuongTon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGiaNhap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).BeginInit();
            this.SuspendLayout();
            // 
            // labMaSP
            // 
            this.labMaSP.AutoSize = true;
            this.labMaSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labMaSP.Location = new System.Drawing.Point(25, 31);
            this.labMaSP.Name = "labMaSP";
            this.labMaSP.Size = new System.Drawing.Size(222, 39);
            this.labMaSP.TabIndex = 0;
            this.labMaSP.Text = "Mã sản phẩm";
            // 
            // labTenSP
            // 
            this.labTenSP.AutoSize = true;
            this.labTenSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labTenSP.Location = new System.Drawing.Point(25, 120);
            this.labTenSP.Name = "labTenSP";
            this.labTenSP.Size = new System.Drawing.Size(234, 39);
            this.labTenSP.TabIndex = 1;
            this.labTenSP.Text = "Tên sản phẩm";
            // 
            // labMaLoaiSP
            // 
            this.labMaLoaiSP.AutoSize = true;
            this.labMaLoaiSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labMaLoaiSP.Location = new System.Drawing.Point(479, 31);
            this.labMaLoaiSP.Name = "labMaLoaiSP";
            this.labMaLoaiSP.Size = new System.Drawing.Size(240, 39);
            this.labMaLoaiSP.TabIndex = 2;
            this.labMaLoaiSP.Text = "Loại sản phẩm";
            // 
            // labMaNCC
            // 
            this.labMaNCC.AutoSize = true;
            this.labMaNCC.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labMaNCC.Location = new System.Drawing.Point(1147, 31);
            this.labMaNCC.Name = "labMaNCC";
            this.labMaNCC.Size = new System.Drawing.Size(227, 39);
            this.labMaNCC.TabIndex = 3;
            this.labMaNCC.Text = "Nhà cung cấp";
            // 
            // labGiaNhap
            // 
            this.labGiaNhap.AutoSize = true;
            this.labGiaNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labGiaNhap.Location = new System.Drawing.Point(688, 120);
            this.labGiaNhap.Name = "labGiaNhap";
            this.labGiaNhap.Size = new System.Drawing.Size(155, 39);
            this.labGiaNhap.TabIndex = 4;
            this.labGiaNhap.Text = "Giá nhập";
            // 
            // labGiaBan
            // 
            this.labGiaBan.AutoSize = true;
            this.labGiaBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labGiaBan.Location = new System.Drawing.Point(1137, 115);
            this.labGiaBan.Name = "labGiaBan";
            this.labGiaBan.Size = new System.Drawing.Size(136, 39);
            this.labGiaBan.TabIndex = 5;
            this.labGiaBan.Text = "Giá bán";
            // 
            // labSoLuongTon
            // 
            this.labSoLuongTon.AutoSize = true;
            this.labSoLuongTon.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labSoLuongTon.Location = new System.Drawing.Point(25, 209);
            this.labSoLuongTon.Name = "labSoLuongTon";
            this.labSoLuongTon.Size = new System.Drawing.Size(208, 39);
            this.labSoLuongTon.TabIndex = 6;
            this.labSoLuongTon.Text = "Số lượng tồn";
            // 
            // labNgayHetHan
            // 
            this.labNgayHetHan.AutoSize = true;
            this.labNgayHetHan.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labNgayHetHan.Location = new System.Drawing.Point(500, 209);
            this.labNgayHetHan.Name = "labNgayHetHan";
            this.labNgayHetHan.Size = new System.Drawing.Size(219, 39);
            this.labNgayHetHan.TabIndex = 7;
            this.labNgayHetHan.Text = "Ngày hết hạn";
            // 
            // txtMaSP
            // 
            this.txtMaSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaSP.Location = new System.Drawing.Point(267, 28);
            this.txtMaSP.Name = "txtMaSP";
            this.txtMaSP.Size = new System.Drawing.Size(137, 45);
            this.txtMaSP.TabIndex = 8;
            // 
            // txtTenSP
            // 
            this.txtTenSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenSP.Location = new System.Drawing.Point(267, 118);
            this.txtTenSP.Name = "txtTenSP";
            this.txtTenSP.Size = new System.Drawing.Size(330, 45);
            this.txtTenSP.TabIndex = 9;
            // 
            // cbxLoaiSP
            // 
            this.cbxLoaiSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxLoaiSP.FormattingEnabled = true;
            this.cbxLoaiSP.Location = new System.Drawing.Point(740, 28);
            this.cbxLoaiSP.Name = "cbxLoaiSP";
            this.cbxLoaiSP.Size = new System.Drawing.Size(274, 46);
            this.cbxLoaiSP.TabIndex = 10;
            // 
            // cbxNCC
            // 
            this.cbxNCC.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxNCC.FormattingEnabled = true;
            this.cbxNCC.Location = new System.Drawing.Point(1380, 28);
            this.cbxNCC.Name = "cbxNCC";
            this.cbxNCC.Size = new System.Drawing.Size(332, 46);
            this.cbxNCC.TabIndex = 11;
            // 
            // numGiaBan
            // 
            this.numGiaBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numGiaBan.Location = new System.Drawing.Point(1293, 115);
            this.numGiaBan.Maximum = new decimal(new int[] {
            -1530494976,
            232830,
            0,
            0});
            this.numGiaBan.Name = "numGiaBan";
            this.numGiaBan.Size = new System.Drawing.Size(199, 45);
            this.numGiaBan.TabIndex = 12;
            // 
            // numSoLuongTon
            // 
            this.numSoLuongTon.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numSoLuongTon.Location = new System.Drawing.Point(266, 208);
            this.numSoLuongTon.Maximum = new decimal(new int[] {
            276447232,
            23283,
            0,
            0});
            this.numSoLuongTon.Name = "numSoLuongTon";
            this.numSoLuongTon.Size = new System.Drawing.Size(199, 45);
            this.numSoLuongTon.TabIndex = 13;
            // 
            // numGiaNhap
            // 
            this.numGiaNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numGiaNhap.Location = new System.Drawing.Point(849, 115);
            this.numGiaNhap.Maximum = new decimal(new int[] {
            -1530494976,
            232830,
            0,
            0});
            this.numGiaNhap.Name = "numGiaNhap";
            this.numGiaNhap.Size = new System.Drawing.Size(218, 45);
            this.numGiaNhap.TabIndex = 14;
            // 
            // dtpNgayHetHan
            // 
            this.dtpNgayHetHan.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayHetHan.Location = new System.Drawing.Point(740, 208);
            this.dtpNgayHetHan.Name = "dtpNgayHetHan";
            this.dtpNgayHetHan.Size = new System.Drawing.Size(568, 45);
            this.dtpNgayHetHan.TabIndex = 15;
            // 
            // btnCongLoaiSP
            // 
            this.btnCongLoaiSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCongLoaiSP.Location = new System.Drawing.Point(1033, 28);
            this.btnCongLoaiSP.Name = "btnCongLoaiSP";
            this.btnCongLoaiSP.Size = new System.Drawing.Size(46, 46);
            this.btnCongLoaiSP.TabIndex = 16;
            this.btnCongLoaiSP.Text = "+";
            this.btnCongLoaiSP.UseVisualStyleBackColor = true;
            this.btnCongLoaiSP.Click += new System.EventHandler(this.btnCongLoaiSP_Click);
            // 
            // btnCongNCC
            // 
            this.btnCongNCC.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCongNCC.Location = new System.Drawing.Point(1727, 27);
            this.btnCongNCC.Name = "btnCongNCC";
            this.btnCongNCC.Size = new System.Drawing.Size(46, 46);
            this.btnCongNCC.TabIndex = 17;
            this.btnCongNCC.Text = "+";
            this.btnCongNCC.UseVisualStyleBackColor = true;
            this.btnCongNCC.Click += new System.EventHandler(this.btnCongNCC_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.Location = new System.Drawing.Point(765, 288);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(118, 50);
            this.btnLuu.TabIndex = 18;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem.Location = new System.Drawing.Point(989, 287);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(219, 50);
            this.btnTimKiem.TabIndex = 19;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLamMoi.Location = new System.Drawing.Point(1314, 287);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(214, 50);
            this.btnLamMoi.TabIndex = 20;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnSua
            // 
            this.btnSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.Location = new System.Drawing.Point(292, 288);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(127, 50);
            this.btnSua.TabIndex = 22;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Location = new System.Drawing.Point(32, 288);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(154, 50);
            this.btnThem.TabIndex = 23;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Location = new System.Drawing.Point(525, 288);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(134, 50);
            this.btnXoa.TabIndex = 24;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // dgvSanPham
            // 
            this.dgvSanPham.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSanPham.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSanPham.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSanPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSanPham.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSanPham.Location = new System.Drawing.Point(23, 382);
            this.dgvSanPham.Name = "dgvSanPham";
            this.dgvSanPham.RowHeadersWidth = 51;
            this.dgvSanPham.RowTemplate.Height = 24;
            this.dgvSanPham.Size = new System.Drawing.Size(1871, 763);
            this.dgvSanPham.TabIndex = 25;
            this.dgvSanPham.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSanPham_CellClick);
            // 
            // frmSanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1175);
            this.Controls.Add(this.dgvSanPham);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnCongNCC);
            this.Controls.Add(this.btnCongLoaiSP);
            this.Controls.Add(this.dtpNgayHetHan);
            this.Controls.Add(this.numGiaNhap);
            this.Controls.Add(this.numSoLuongTon);
            this.Controls.Add(this.numGiaBan);
            this.Controls.Add(this.cbxNCC);
            this.Controls.Add(this.cbxLoaiSP);
            this.Controls.Add(this.txtTenSP);
            this.Controls.Add(this.txtMaSP);
            this.Controls.Add(this.labNgayHetHan);
            this.Controls.Add(this.labSoLuongTon);
            this.Controls.Add(this.labGiaBan);
            this.Controls.Add(this.labGiaNhap);
            this.Controls.Add(this.labMaNCC);
            this.Controls.Add(this.labMaLoaiSP);
            this.Controls.Add(this.labTenSP);
            this.Controls.Add(this.labMaSP);
            this.Name = "frmSanPham";
            this.Text = "frmSanPham";
            this.Load += new System.EventHandler(this.frmSanPham_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numGiaBan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuongTon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGiaNhap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labMaSP;
        private System.Windows.Forms.Label labTenSP;
        private System.Windows.Forms.Label labMaLoaiSP;
        private System.Windows.Forms.Label labMaNCC;
        private System.Windows.Forms.Label labGiaNhap;
        private System.Windows.Forms.Label labGiaBan;
        private System.Windows.Forms.Label labSoLuongTon;
        private System.Windows.Forms.Label labNgayHetHan;
        private System.Windows.Forms.TextBox txtMaSP;
        private System.Windows.Forms.TextBox txtTenSP;
        private System.Windows.Forms.ComboBox cbxLoaiSP;
        private System.Windows.Forms.ComboBox cbxNCC;
        private System.Windows.Forms.NumericUpDown numGiaBan;
        private System.Windows.Forms.NumericUpDown numSoLuongTon;
        private System.Windows.Forms.NumericUpDown numGiaNhap;
        private System.Windows.Forms.DateTimePicker dtpNgayHetHan;
        private System.Windows.Forms.Button btnCongLoaiSP;
        private System.Windows.Forms.Button btnCongNCC;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.DataGridView dgvSanPham;
    }
}