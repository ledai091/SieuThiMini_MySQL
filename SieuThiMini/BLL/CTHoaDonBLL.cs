using SieuThiMini.DAL;
using SieuThiMini.DTO;
using System.Collections.Generic;

namespace SieuThiMini.BLL
{
    class CTHoaDonBLL
    {
        private CTHoaDonDAL DAL;
        private List<CTHoaDonDTO> listDTO;


        public CTHoaDonBLL()
        {
            this.DAL = new CTHoaDonDAL();
        }

        public List<CTHoaDonDTO> GetList()
        {
            listDTO = new List<CTHoaDonDTO>();
            listDTO = this.DAL.SelectAll();

            return listDTO;
        }

        public int Insert(CTHoaDonDTO dto)
        {
            return this.DAL.Insert(dto);
        }

        public List<CTHoaDonDTO> GetCTHDByMaHD(int ma_hoa_don)
        {
            return this.DAL.GetCTHDByMaHD(ma_hoa_don);
        }


    }
}
