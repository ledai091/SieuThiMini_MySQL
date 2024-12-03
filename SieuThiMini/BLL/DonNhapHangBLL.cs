using SieuThiMini.DAL;
using SieuThiMini.DTO;
using System.Collections.Generic;

namespace SieuThiMini.BLL
{
    class DonNhapHangBLL
    {
        private DonNhapHangDAL DAL;
        private List<DonNhapHangDTO> listDTO;


        public DonNhapHangBLL()
        {
            this.DAL = new DonNhapHangDAL();
        }

        public List<DonNhapHangDTO> GetList()
        {
            listDTO = new List<DonNhapHangDTO>();
            listDTO = this.DAL.SelectAll();

            return listDTO;
        }
        public List<DonNhapHangDTO> GetListDeleted()
        {
            listDTO = new List<DonNhapHangDTO>();
            listDTO = this.DAL.SelectAllDeleted();

            return listDTO;
        }
        public int Insert(DonNhapHangDTO dto)
        {
            return this.DAL.Insert(dto);
        }

        public int Update(string maDonNh)
        {
            return this.DAL.Restore(maDonNh);
        }

        public int Delete(string dtoId)
        {
            return this.DAL.Delete(dtoId);
        }


        public DonNhapHangDTO GetDNHByMaDNH(string ma_don_nh)
        {
            return this.DAL.GetDNHByMaDNH(ma_don_nh)[0];

        }
    }
}
