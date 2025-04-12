using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace QLTH_BTNhom
{
    public static class DoanhThuChartHelper
    {
        public static void LoadDoanhThuChart(Chart chart, int thang, int nam, string httt = null)
        {
            string query = @"
                SELECT 
                    DAY(HoaDon.NgayLap) AS Ngay,
                    SUM(ChiTietHoaDon.SoLuong * ChiTietHoaDon.GiaBan) AS DoanhThu
                FROM 
                    HoaDon
                JOIN 
                    ChiTietHoaDon ON HoaDon.MaHD = ChiTietHoaDon.MaHD
                WHERE 
                    MONTH(HoaDon.NgayLap) = @Thang
                    AND YEAR(HoaDon.NgayLap) = @Nam";

            if (!string.IsNullOrEmpty(httt))
                query += " AND HoaDon.HinhThucThanhToan = @HTTT";

            query += @"
                GROUP BY 
                    DAY(HoaDon.NgayLap)
                ORDER BY Ngay;";

            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@Thang", thang),
                new SqlParameter("@Nam", nam)
            };

            if (!string.IsNullOrEmpty(httt))
                parameters.Add(new SqlParameter("@HTTT", httt));

            DatabaseHelper db = new DatabaseHelper();
            DataTable dt = db.ExecuteQuery(query, parameters.ToArray());

            chart.Series.Clear();

            var series = new Series("Doanh thu theo ngày")
            {
                ChartType = SeriesChartType.Column,
                IsValueShownAsLabel = true
            };

            Dictionary<int, double> doanhThuTheoNgay = new Dictionary<int, double>();
            foreach (DataRow row in dt.Rows)
            {
                int ngay = Convert.ToInt32(row["Ngay"]);
                double doanhThu = Convert.ToDouble(row["DoanhThu"]);
                doanhThuTheoNgay[ngay] = doanhThu;
            }

            int soNgay = DateTime.DaysInMonth(nam, thang);
            double tong = 0;
            for (int ngay = 1; ngay <= soNgay; ngay++)
            {
                double doanhThu = doanhThuTheoNgay.ContainsKey(ngay) ? doanhThuTheoNgay[ngay] : 0;
                series.Points.AddXY(ngay, doanhThu);
                tong += doanhThu;
            }

            chart.Series.Add(series);
            chart.ChartAreas[0].AxisX.Title = "Ngày";
            chart.ChartAreas[0].AxisY.Title = "Doanh thu (VNĐ)";

            ConfigureChartXAxis(chart, thang, nam);

            int maxDoanhThu = (int)(series.Points.Count > 0 ? series.Points.Max(p => p.YValues[0]) : 0);
            ConfigureChartYAxis(chart, maxDoanhThu);
        }

        private static int GetMaxDoanhThuTrongThang(int thang, int nam)
        {
            string query = @"
                SELECT 
                    MAX(DailyTotal) AS MaxDoanhThu
                FROM (
                    SELECT 
                        SUM(ChiTietHoaDon.SoLuong * ChiTietHoaDon.GiaBan) AS DailyTotal
                    FROM 
                        HoaDon
                    JOIN 
                        ChiTietHoaDon ON HoaDon.MaHD = ChiTietHoaDon.MaHD
                    WHERE 
                        MONTH(HoaDon.NgayLap) = @Thang AND YEAR(HoaDon.NgayLap) = @Nam
                    GROUP BY 
                        DAY(HoaDon.NgayLap)
                ) AS DailySums;";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Thang", SqlDbType.Int) { Value = thang },
                new SqlParameter("@Nam", SqlDbType.Int) { Value = nam }
            };

            DatabaseHelper db = new DatabaseHelper();
            object result = db.ExecuteScalar(query, parameters);
            return result != DBNull.Value ? Convert.ToInt32(result) : 0;
        }

        private static void ConfigureChartXAxis(Chart chart, int thang, int nam)
        {
            var axisX = chart.ChartAreas[0].AxisX;
            axisX.Interval = 1;
            axisX.Minimum = 0;
            axisX.Maximum = DateTime.DaysInMonth(nam, thang) + 1;
            axisX.Title = "Ngày trong tháng";
            axisX.LabelStyle.Angle = 0;
        }

        private static void ConfigureChartYAxis(Chart chart, int maxDoanhThu)
        {
            var axisY = chart.ChartAreas[0].AxisY;

            axisY.Minimum = 0;

            int interval = 200000;
            int roundedMax = ((maxDoanhThu + interval - 1) / interval) * interval;
            axisY.Maximum = roundedMax + interval;

            axisY.Interval = interval;
            axisY.LabelStyle.Format = "";
            axisY.CustomLabels.Clear();

            for (double val = axisY.Minimum; val <= axisY.Maximum; val += axisY.Interval)
            {
                string labelText = "";

                if (val == 0)
                {
                    labelText = "0";
                }
                else if (val < 1000000)
                {
                    labelText = $"{val / 1000:0}k";
                }
                else
                {
                    labelText = $"{val / 1000000:0.#} tr";
                }

                axisY.CustomLabels.Add(val - axisY.Interval / 2, val + axisY.Interval / 2, labelText);
            }
        }

        public static double GetTongDoanhThu(int thang, int nam, string httt = null)
        {
            string query = @"
            SELECT 
                SUM(ChiTietHoaDon.SoLuong * ChiTietHoaDon.GiaBan) AS TongDoanhThu
            FROM 
                HoaDon
            JOIN 
                ChiTietHoaDon ON HoaDon.MaHD = ChiTietHoaDon.MaHD
            WHERE 
            MONTH(HoaDon.NgayLap) = @Thang
            AND YEAR(HoaDon.NgayLap) = @Nam";

            if (!string.IsNullOrEmpty(httt))
                query += " AND HoaDon.HinhThucThanhToan = @HTTT";

            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@Thang", thang),
                new SqlParameter("@Nam", nam)
            };

            if (!string.IsNullOrEmpty(httt))
                parameters.Add(new SqlParameter("@HTTT", httt));

            DatabaseHelper db = new DatabaseHelper();
            object result = db.ExecuteScalar(query, parameters.ToArray());

            return result != DBNull.Value ? Convert.ToDouble(result) : 0;
        }
    }
}
