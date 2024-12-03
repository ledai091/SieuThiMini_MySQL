using System;

namespace SieuThiMini.DTO
{
    class CTHoaDonDTO
    {
        public int ma_hoa_don {  get; set; }
        public int ma_san_pham { get; set; }
        public string ten_san_pham { get; set; }
        public int so_luong { get; set; }
        public int gia_san_pham { get; set; }
        public int thanh_tien { get; set; }

        public CTHoaDonDTO(int ma_hoa_don, int maSanpham, string ten_san_pham, int so_luong, int gia_san_pham, int thanh_tien) 
        {
            this.ma_hoa_don = ma_hoa_don;
            this.ma_san_pham = maSanpham;
            this.ten_san_pham = ten_san_pham;
            this.so_luong = so_luong;
            this.gia_san_pham = gia_san_pham;
            this.thanh_tien = thanh_tien;
        }
    }
}
