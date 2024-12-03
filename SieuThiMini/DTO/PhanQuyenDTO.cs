using System;

namespace SieuThiMini.DTO
{
    class PhanQuyenDTO
    {
        public int ma_quyen {  get; set; }
        public string ten_quyen { get; set; }
        public PhanQuyenDTO(int ma_quyen, string ten_quyen)
        {
            this.ma_quyen = ma_quyen;
            this.ten_quyen = ten_quyen;
        }
    }
}
