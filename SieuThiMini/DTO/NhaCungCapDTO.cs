using System;

namespace SieuThiMini.DTO
{
    class NhaCungCapDTO
    {
        public int ma_ncc {  get; set; }
        public string ten_ncc { get; set; }
        public string dia_chi { get; set; }
        public string trang_thai {  get; set; }

        public NhaCungCapDTO(int ma_ncc, string ten_ncc, string dia_chi, string trang_thai)
        {
            this.ma_ncc = ma_ncc;
            this.ten_ncc= ten_ncc;
            this.dia_chi = dia_chi;
            this.trang_thai = trang_thai;
        }
    }
}
