namespace QLTH_BTNhom
{
    partial class frmThongKeDoanhThu
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.labNam = new System.Windows.Forms.Label();
            this.labThang = new System.Windows.Forms.Label();
            this.cbxNam = new System.Windows.Forms.ComboBox();
            this.cbxThang = new System.Windows.Forms.ComboBox();
            this.cbxHTTT = new System.Windows.Forms.ComboBox();
            this.labHTTT = new System.Windows.Forms.Label();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.labTongDoanhThu = new System.Windows.Forms.Label();
            this.txtTongDoanhThu = new System.Windows.Forms.TextBox();
            this.btnLuu = new System.Windows.Forms.Button();
            this.qltH_btNhomDataSet1 = new QLTH_BTNhom.QLTH_btNhomDataSet();
            this.chartDoanhThu = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.qltH_btNhomDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThu)).BeginInit();
            this.SuspendLayout();
            // 
            // labNam
            // 
            this.labNam.AutoSize = true;
            this.labNam.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labNam.Location = new System.Drawing.Point(12, 9);
            this.labNam.Name = "labNam";
            this.labNam.Size = new System.Drawing.Size(86, 38);
            this.labNam.TabIndex = 0;
            this.labNam.Text = "Năm";
            // 
            // labThang
            // 
            this.labThang.AutoSize = true;
            this.labThang.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labThang.Location = new System.Drawing.Point(12, 98);
            this.labThang.Name = "labThang";
            this.labThang.Size = new System.Drawing.Size(109, 38);
            this.labThang.TabIndex = 1;
            this.labThang.Text = "Tháng";
            // 
            // cbxNam
            // 
            this.cbxNam.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxNam.FormattingEnabled = true;
            this.cbxNam.Location = new System.Drawing.Point(107, 12);
            this.cbxNam.Name = "cbxNam";
            this.cbxNam.Size = new System.Drawing.Size(183, 46);
            this.cbxNam.TabIndex = 2;
            // 
            // cbxThang
            // 
            this.cbxThang.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxThang.FormattingEnabled = true;
            this.cbxThang.Location = new System.Drawing.Point(132, 95);
            this.cbxThang.Name = "cbxThang";
            this.cbxThang.Size = new System.Drawing.Size(158, 46);
            this.cbxThang.TabIndex = 3;
            // 
            // cbxHTTT
            // 
            this.cbxHTTT.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxHTTT.FormattingEnabled = true;
            this.cbxHTTT.Location = new System.Drawing.Point(725, 12);
            this.cbxHTTT.Name = "cbxHTTT";
            this.cbxHTTT.Size = new System.Drawing.Size(355, 46);
            this.cbxHTTT.TabIndex = 4;
            // 
            // labHTTT
            // 
            this.labHTTT.AutoSize = true;
            this.labHTTT.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labHTTT.Location = new System.Drawing.Point(364, 15);
            this.labHTTT.Name = "labHTTT";
            this.labHTTT.Size = new System.Drawing.Size(317, 38);
            this.labHTTT.TabIndex = 5;
            this.labHTTT.Text = "Hình thức thanh toán";
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLamMoi.Location = new System.Drawing.Point(583, 219);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(177, 60);
            this.btnLamMoi.TabIndex = 6;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnThongKe
            // 
            this.btnThongKe.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThongKe.Location = new System.Drawing.Point(19, 219);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(202, 60);
            this.btnThongKe.TabIndex = 7;
            this.btnThongKe.Text = "Thống kê";
            this.btnThongKe.UseVisualStyleBackColor = true;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // labTongDoanhThu
            // 
            this.labTongDoanhThu.AutoSize = true;
            this.labTongDoanhThu.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labTongDoanhThu.Location = new System.Drawing.Point(428, 95);
            this.labTongDoanhThu.Name = "labTongDoanhThu";
            this.labTongDoanhThu.Size = new System.Drawing.Size(253, 38);
            this.labTongDoanhThu.TabIndex = 8;
            this.labTongDoanhThu.Text = "Tổng doanh  thu";
            // 
            // txtTongDoanhThu
            // 
            this.txtTongDoanhThu.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongDoanhThu.Location = new System.Drawing.Point(725, 95);
            this.txtTongDoanhThu.Name = "txtTongDoanhThu";
            this.txtTongDoanhThu.Size = new System.Drawing.Size(609, 45);
            this.txtTongDoanhThu.TabIndex = 9;
            // 
            // btnLuu
            // 
            this.btnLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.Location = new System.Drawing.Point(352, 219);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(100, 60);
            this.btnLuu.TabIndex = 10;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // qltH_btNhomDataSet1
            // 
            this.qltH_btNhomDataSet1.DataSetName = "QLTH_btNhomDataSet";
            this.qltH_btNhomDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // chartDoanhThu
            // 
            chartArea1.Name = "ChartArea1";
            this.chartDoanhThu.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartDoanhThu.Legends.Add(legend1);
            this.chartDoanhThu.Location = new System.Drawing.Point(12, 321);
            this.chartDoanhThu.Name = "chartDoanhThu";
            this.chartDoanhThu.Size = new System.Drawing.Size(1893, 842);
            this.chartDoanhThu.TabIndex = 11;
            this.chartDoanhThu.Text = "chart1";
            // 
            // frmThongKeDoanhThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1175);
            this.Controls.Add(this.chartDoanhThu);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.txtTongDoanhThu);
            this.Controls.Add(this.labTongDoanhThu);
            this.Controls.Add(this.btnThongKe);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.labHTTT);
            this.Controls.Add(this.cbxHTTT);
            this.Controls.Add(this.cbxThang);
            this.Controls.Add(this.cbxNam);
            this.Controls.Add(this.labThang);
            this.Controls.Add(this.labNam);
            this.Name = "frmThongKeDoanhThu";
            this.Text = "frmThongKeDoanhThu";
            this.Load += new System.EventHandler(this.frmThongKeDoanhThu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qltH_btNhomDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labNam;
        private System.Windows.Forms.Label labThang;
        private System.Windows.Forms.ComboBox cbxNam;
        private System.Windows.Forms.ComboBox cbxThang;
        private System.Windows.Forms.ComboBox cbxHTTT;
        private System.Windows.Forms.Label labHTTT;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.Label labTongDoanhThu;
        private System.Windows.Forms.TextBox txtTongDoanhThu;
        private System.Windows.Forms.Button btnLuu;
        private QLTH_btNhomDataSet qltH_btNhomDataSet1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDoanhThu;
    }
}