using System;

namespace SieuThiMini.DTO
{
    class TaiKhoanDTO
    {
        public int ma_tai_khoan {  get; set; }
        public string ten_tai_khoan { get; set; }
        public string mat_khau {  get; set; }
        public int phan_quyen { get; set; }
        public int trang_thai { get; set; }

        public TaiKhoanDTO(int ma_tai_khoan, string ten_tai_khoan, string mat_khau, int phan_quyen, int trang_thai)
        {
            this.ma_tai_khoan = ma_tai_khoan;
            this.ten_tai_khoan = ten_tai_khoan;
            this.mat_khau = mat_khau;
            this.phan_quyen = phan_quyen;
            this.trang_thai = trang_thai;
        }
    }
}
