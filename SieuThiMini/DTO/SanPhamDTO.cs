using System;

namespace SieuThiMini.DTO
{
    class SanPhamDTO
    {
        public int ma_san_pham { get; set; }
        public string ten_san_pham { get; set; }
        public int so_luong { get; set; }
        public int gia {  get; set; }
        public int gia_nhap { get; set; }
        public int ma_loai { get; set; }
        public string trang_thai { get; set; }

        public SanPhamDTO(int ma_san_pham, string ten_san_pham, int so_luong, int gia, int gia_nhap, int ma_loai, string trang_thai)
        {
            this.ma_san_pham = ma_san_pham;
            this.ten_san_pham = ten_san_pham;
            this.so_luong = so_luong;
            this.gia = gia;
            this.gia_nhap = gia_nhap;
            this.ma_loai = ma_loai;
            this.trang_thai = trang_thai;
        }
    }
}
