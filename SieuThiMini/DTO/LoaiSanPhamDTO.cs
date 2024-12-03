using System;

namespace SieuThiMini.DTO
{
    class LoaiSanPhamDTO
    {
        public int ma_loai {  get; set; }
        public string ten_loai { get; set; }
        public int ma_ncc { get; set; }
        public string trang_thai { get; set; }

        public LoaiSanPhamDTO(int ma_loai, string ten_loai, int ma_ncc, string trang_thai)
        {
            this.ma_loai = ma_loai;
            this.ten_loai = ten_loai;
            this.ma_ncc = ma_ncc;
            this.trang_thai = trang_thai;
        }
    }
}
