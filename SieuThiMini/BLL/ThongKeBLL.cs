using SieuThiMini.DAL;
using System.Data;

namespace SieuThiMini.BLL
{
    class ThongKeBLL
    {
        private ThongKeDAL DAL;

        public ThongKeBLL()
        {
            this.DAL = new ThongKeDAL();
        }

        public int TongDoanhThuCacHoaDon()
        {
            return this.DAL.TongDoanhThuCacHoaDon();
        }
        public int TongDoanhThuTheoNam(int selectedYear)
        {
            return this.DAL.TongDoanhThuTheoNam(selectedYear);
        }
        public int TongDoanhThuTheoThang(int selectedMonth, int selectedYear)
        {
            return this.DAL.TongDoanhThuTheoThang(selectedMonth, selectedYear);
        }
        public int TongHoaDon()
        {
            return this.DAL.TongHoaDon();
        }
        public int TongHoaDonTheoNam(int selectedYear)
        {
            return this.DAL.TongHoaDonTheoNam(selectedYear);
        }
        public int TongHoaDonTheoThang(int selectedMonth, int selectedYear)
        {
            return this.DAL.TongHoaDonTheoThang(selectedMonth, selectedYear);
        }
        public int TongDonNH()
        {
            return this.DAL.TongDonNH();
        }
        public int TongDonNHTheoNam(int selectedYear)
        {
            return this.DAL.TongDonNHTheoNam(selectedYear);
        }
        public int TongDonNHTheoThang(int selectedMonth, int selectedYear)
        {
            return this.DAL.TongDonNHTheoThang(selectedMonth, selectedYear);
        }
        public int TongChiPhiNhapHang()
        {
            return this.DAL.TongChiPhiNhapHang();
        }
        public int TongChiPhiNhapHangTheoNam(int selectedYear)
        {
            return this.DAL.TongChiPhiNhapHangTheoNam(selectedYear);
        }
        public int TongChiPhiNhapHangTheoThang(int selectedMonth, int selectedYear)
        {
            return this.DAL.TongChiPhiNhapHangTheoThang(selectedMonth, selectedYear);
        }
        public int SoTaiKhoan()
        {
            return this.DAL.SoTaiKhoan();
        }
        public int TongSoSanPham()
        {
            return this.DAL.TongSoSanPham();
        }
        public int SoLuongNCC()
        {
            return this.DAL.SoLuongNCC();
        }
        public int SoLuongNV()
        {
            return this.DAL.SoLuongNV();
        }
        public DataTable TimMaNVCoTongTienLonNhatTheoNam(int selectedYear)
        {
            return this.DAL.TimMaNVCoTongTienLonNhatTheoNam(selectedYear);
        }
        public DataTable TimMaNVCoTongTienLonNhatTheoThang(int selectedMonth, int selectedYear)
        {
            return this.DAL.TimMaNVCoTongTienLonNhatTheoThang(selectedMonth, selectedYear);
        }
    }
}