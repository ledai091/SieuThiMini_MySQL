using SieuThiMini.DAL;
using SieuThiMini.DTO;
using System.Collections.Generic;

namespace SieuThiMini.BLL
{
    class HoaDonBLL
    {
        private HoaDonDAL DAL;
        private List<HoaDonDTO> listDTO;


        public HoaDonBLL()
        {
            this.DAL = new HoaDonDAL();
        }

        public List<HoaDonDTO> GetList()
        {
            listDTO = new List<HoaDonDTO>();
            listDTO = this.DAL.SelectAll();

            return listDTO;
        }
        public List<HoaDonDTO> GetListDeleted()
        {
            listDTO = new List<HoaDonDTO>();
            listDTO = this.DAL.SelectAllDeleted();
            return listDTO;
        }
        public int Insert(HoaDonDTO dto)
        {
            return this.DAL.Insert(dto);
        }

        public int Delete(string dtoId)
        {
            return this.DAL.Delete(dtoId);
        }

        public int Update(string mahoadon)
        {
            return this.DAL.Restore(mahoadon);
        }
        public HoaDonDTO GetHDByMaHD(int ma_hoa_don)
        {
            return this.DAL.GetHDByMaHD(ma_hoa_don)[0];

        }



    }
}
