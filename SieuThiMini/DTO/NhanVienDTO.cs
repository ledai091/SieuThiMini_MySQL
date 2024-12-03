using System;

namespace SieuThiMini.DTO
{
    class NhanVienDTO
    {
        public int ma_nhan_vien { get; set; }
        public string ten_nhan_vien { get; set; }
        public DateTime ngay_sinh { get; set; }
        public string sdt { get; set; }
        public string mail { get; set; }
        public int tai_khoan { get; set; }
        public string trang_thai { get; set; }

        public NhanVienDTO(int ma_nhan_vien, string ten_nhan_vien, DateTime ngay_sinh, string sdt, string mail, int tai_khoan)
        {
            this.ma_nhan_vien = ma_nhan_vien;
            this.ten_nhan_vien = ten_nhan_vien;
            this.ngay_sinh = ngay_sinh;
            this.sdt = sdt;
            this.mail = mail;
            this.tai_khoan = tai_khoan;
        }
    }
}
