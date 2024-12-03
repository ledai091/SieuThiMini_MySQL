using System;

namespace SieuThiMini.DTO
{
    class CTDonNhapHangDTO
    {
        public int ma_don_nh {  get; set; }
        public int ma_san_pham { get; set; }
        public string ten_san_pham { get; set; }
        public int so_luong { get; set; }
        public int gia { get; set; }
        public int thanh_tien { get; set; }

        public CTDonNhapHangDTO(int ma_don_nh, int ma_san_pham, string ten_san_pham, int so_luong, int gia, int thanh_tien)
        {
            this.ma_don_nh = ma_don_nh;
            this.ma_san_pham = ma_san_pham;
            this.ten_san_pham= ten_san_pham;
            this.so_luong = so_luong;
            this.gia = gia;
            this.thanh_tien = thanh_tien;
        }
    }
}
