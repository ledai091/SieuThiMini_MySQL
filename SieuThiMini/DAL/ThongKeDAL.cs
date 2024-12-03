using NPOI.SS.Formula.Functions;
using System;
using System.Data;

namespace SieuThiMini.DAL
{
    class ThongKeDAL : DataConnection
    {
        public ThongKeDAL() { }
        public int TongDoanhThuCacHoaDon()
        {
            int tong_doanh_thu = 0;
            string query = "SELECT SUM(tong_tien) FROM hoa_don WHERE trang_thai = '1'";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            if (dt.Rows.Count > 0)
            {
                tong_doanh_thu = int.Parse(dt.Rows[0].ItemArray[0].ToString());
            }
            return tong_doanh_thu;
        }
        public int TongDoanhThuTheoNam(int selectedYear)
        {
            int tong_doanh_thu = 0;
            string query = $"SELECT SUM(tong_tien) FROM hoa_don WHERE trang_thai = '1' AND YEAR(ngay_xuat) = '{selectedYear}'";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            if (dt.Rows.Count > 0)
            {
                tong_doanh_thu = int.Parse(dt.Rows[0].ItemArray[0].ToString());
            }
            return tong_doanh_thu;
        }
        public int TongDoanhThuTheoThang(int selectedMonth, int selectedYear)
        {
            int tong_doanh_thu = 0;
            string query = $"SELECT SUM(tong_tien) FROM hoa_don WHERE trang_thai = '1' AND MONTH(ngay_xuat) = '{selectedMonth}' AND YEAR(ngay_xuat) = '{selectedYear}'";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            if (dt.Rows.Count > 0 && dt.Rows[0][0] != DBNull.Value && dt.Rows[0][0] != null)
            {
                decimal value = Convert.ToDecimal(dt.Rows[0].ItemArray[0].ToString());
                return Convert.ToInt32(value);
            }
            return tong_doanh_thu;
        }
        public int TongHoaDon()
        {
            int tong_hoa_don = 0;
            string query = "SELECT COUNT(ma_hoa_don) FROM hoa_don WHERE trang_thai = '1'";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            if (dt.Rows.Count > 0)
            {
                tong_hoa_don = int.Parse(dt.Rows[0].ItemArray[0].ToString());
            }
            return tong_hoa_don;
        }
        public int TongHoaDonTheoNam(int selectedYear)
        {
            int tong_hoa_don = 0;
            string query = $"SELECT COUNT(ma_hoa_don) FROM hoa_don WHERE trang_thai = '1' AND YEAR(ngay_xuat) = '{selectedYear}'";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            if (dt.Rows.Count > 0)
            {
                tong_hoa_don = int.Parse(dt.Rows[0].ItemArray[0].ToString());
            }
            return tong_hoa_don;
        }
        public int TongHoaDonTheoThang(int selectedMonth, int selectedYear)
        {
            int tong_hoa_don = 0;
            string query = $"SELECT COUNT(ma_hoa_don) FROM hoa_don WHERE trang_thai = '1' AND MONTH(ngay_xuat) = '{selectedMonth}' AND YEAR(ngay_xuat) = '{selectedYear}'";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            if (dt.Rows.Count > 0)
            {
                tong_hoa_don = int.Parse(dt.Rows[0].ItemArray[0].ToString());
            }
            return tong_hoa_don;
        }
        public int TongDonNH()
        {
            int tong_hoa_nh = 0;
            string query = "SELECT COUNT(ma_don_nh) FROM don_nhap_hang WHERE trang_thai = '1'";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            if (dt.Rows.Count > 0)
            {
                tong_hoa_nh = int.Parse(dt.Rows[0].ItemArray[0].ToString());
            }
            return tong_hoa_nh;
        }
        public int TongDonNHTheoNam(int selectedYear)
        {
            int tong_don_nh = 0;
            string query = $"SELECT COUNT(ma_don_nh) FROM don_nhap_hang WHERE trang_thai = '1' AND YEAR(ngay_nhap) = '{selectedYear}'";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            if (dt.Rows.Count > 0)
            {
                tong_don_nh = int.Parse(dt.Rows[0].ItemArray[0].ToString());
            }
            return tong_don_nh;
        }
        public int TongDonNHTheoThang(int selectedMonth, int selectedYear)
        {
            int tong_don_nh = 0;
            string query = $"SELECT COUNT(ma_don_nh) FROM don_nhap_hang WHERE trang_thai = '1' AND MONTH(ngay_nhap) = '{selectedMonth}' AND YEAR(ngay_nhap) = '{selectedYear}'";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            if (dt.Rows.Count > 0)
            {
                tong_don_nh = int.Parse(dt.Rows[0].ItemArray[0].ToString());
            }
            return tong_don_nh;
        }
        public int TongChiPhiNhapHang()
        {
            int tong_chi_phi_nhap_hang = 0;
            string query = "SELECT SUM(tong_tien_nhap) FROM don_nhap_hang WHERE trang_thai = '1'";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            if (dt.Rows.Count > 0)
            {
                tong_chi_phi_nhap_hang = int.Parse(dt.Rows[0].ItemArray[0].ToString());
            }
            return tong_chi_phi_nhap_hang;
        }
        public int TongChiPhiNhapHangTheoNam(int selectedYear)
        {
            int tong_chi_phi_nhap_hang = 0;
            string query = $"SELECT SUM(tong_tien_nhap) FROM don_nhap_hang WHERE trang_thai = '1' AND YEAR(ngay_nhap) = '{selectedYear}'";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            if (dt.Rows.Count > 0 && dt.Rows[0][0] != DBNull.Value && dt.Rows[0][0] != null)
            {
                decimal value = Convert.ToDecimal(dt.Rows[0].ItemArray[0].ToString());
                return Convert.ToInt32(value);
            }
            return tong_chi_phi_nhap_hang;
        }
        public int TongChiPhiNhapHangTheoThang(int selectedMonth, int selectedYear)
        {
            string query = $"SELECT SUM(tong_tien_nhap) FROM don_nhap_hang WHERE trang_thai = '1' AND MONTH(ngay_nhap) = '{selectedMonth}' AND YEAR(ngay_nhap) = '{selectedYear}'";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            if (dt.Rows.Count > 0 && dt.Rows[0][0] != DBNull.Value && dt.Rows[0][0] != null)
            {
                decimal value = Convert.ToDecimal(dt.Rows[0].ItemArray[0].ToString());
                return Convert.ToInt32(value);
            }
            return 0;
        }
        public int SoTaiKhoan()
        {
            int so_tai_khoan = 0;
            string query = "SELECT COUNT(ma_tai_khoan) FROM tai_khoan";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            if (dt.Rows.Count > 0)
            {
                so_tai_khoan = int.Parse(dt.Rows[0].ItemArray[0].ToString());
            }
            return so_tai_khoan;
        }
        public int TongSoSanPham()
        {
            int tong_so_san_pham = 0;
            string query = "SELECT COUNT(so_luong) FROM san_pham WHERE trang_thai = '1'";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            if (dt.Rows.Count > 0)
            {
                tong_so_san_pham = int.Parse(dt.Rows[0].ItemArray[0].ToString());
            }
            return tong_so_san_pham;
        }
        public int SoLuongNCC()
        {
            int so_luong_ncc = 0;
            string query = "SELECT COUNT(ma_ncc) FROM nha_cung_cap WHERE trang_thai='1'";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            if (dt.Rows.Count > 0)
            {
                so_luong_ncc = int.Parse(dt.Rows[0].ItemArray[0].ToString());
            }
            return so_luong_ncc;
        }
        public int SoLuongNV()
        {
            int so_luong_nv = 0;
            string query = "SELECT COUNT(ma_nhan_vien) FROM nhan_vien WHERE trang_thai='1'";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            if (dt.Rows.Count > 0)
            {
                so_luong_nv = int.Parse(dt.Rows[0].ItemArray[0].ToString());
            }
            return so_luong_nv;
        }
        public DataTable TimMaNVCoTongTienLonNhatTheoNam(int selectedYear)
        {
            string query = $"SELECT nhan_vien.ten_nhan_vien, nhan_vien.ma_nhan_vien, SUM(tong_tien) AS TongTienLonNhat " +
                           $"FROM hoa_don " +
                           $"JOIN nhan_vien ON hoa_don.ma_nhan_vien = nhan_vien.ma_nhan_vien " +
                           $"WHERE hoa_don.trang_thai = '1' " +
                           $"AND YEAR(ngay_xuat) = '{selectedYear}' " +
                           $"GROUP BY ma_nhan_vien " +
                           $"ORDER BY SUM(tong_tien) DESC " +
                           $"LIMIT 1";  // Nếu bạn sử dụng SQL Server, thay bằng "TOP 1" ở trên
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable TimMaNVCoTongTienLonNhatTheoThang(int selectedMonth, int selectedYear)
        {
            string query = $"SELECT nhan_vien.ten_nhan_vien, hoa_don.ma_nhan_vien, SUM(hoa_don.tong_tien) AS TongTienLonNhat " +
                           $"FROM hoa_don " +
                           $"JOIN nhan_vien ON hoa_don.ma_nhan_vien = nhan_vien.ma_nhan_vien " +
                           $"WHERE hoa_don.trang_thai = '1' " +
                           $"AND MONTH(ngay_xuat) = '{selectedMonth}' " +
                           $"AND YEAR(ngay_xuat) = '{selectedYear}' " +
                           $"GROUP BY hoa_don.ma_nhan_vien, nhan_vien.ten_nhan_vien " +
                           $"ORDER BY SUM(hoa_don.tong_tien) DESC " +
                           $"LIMIT 1";  // Nếu sử dụng SQL Server, thay bằng "TOP 1" ở trên
            return DataProvider.Instance.ExecuteQuery(query);
        }

    }
}
