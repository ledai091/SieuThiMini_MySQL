using System;

namespace SieuThiMini.DTO
{
    class DonNhapHangDTO
    {
        public int ma_don_nh { get; set; }
        public int ma_ncc { get; set; }
        public int ma_nhan_vien { get; set; }
        public DateTime ngay_nhap {  get; set; }
        public int tong_tien_nhap { get; set; }
        public string trang_thai {  get; set; }

        public DonNhapHangDTO(int ma_don_nh, int ma_ncc, int ma_nhan_vien, DateTime ngay_nhap, int tong_tien_nhap, string trang_thai)
        {
            this.ma_don_nh = ma_don_nh;
            this.ma_ncc = ma_ncc;
            this.ma_nhan_vien = ma_nhan_vien;
            this.ngay_nhap = ngay_nhap;
            this.tong_tien_nhap = tong_tien_nhap;
            this.trang_thai = trang_thai;
        }
    }
}
