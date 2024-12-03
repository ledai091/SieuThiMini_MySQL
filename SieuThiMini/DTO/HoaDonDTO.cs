using System;

namespace SieuThiMini.DTO
{
    class HoaDonDTO
    {
        public int ma_hoa_don {  get; set; }
        public DateTime ngay_xuat { get; set; }
        public int ma_nhan_vien { get; set; }
        public int tong_tien { get; set; }
        public string trang_thai {  get; set; }

        public HoaDonDTO(int ma_hoa_don, DateTime ngay_xuat, int ma_nhan_vien, int tong_tien, string trang_thai) 
        {
            this.ma_hoa_don = ma_hoa_don;
            this.ma_nhan_vien = ma_nhan_vien;
            this.ngay_xuat = ngay_xuat;
            this.tong_tien = tong_tien;
            this.trang_thai = trang_thai;
        }  
    }
}
