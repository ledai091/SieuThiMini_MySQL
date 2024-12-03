using SieuThiMini.DAL;
using SieuThiMini.DTO;
using System.Collections.Generic;

namespace SieuThiMini.BLL
{
    class LoaiSanPhamBLL
    {
        private LoaiSanPhamDAL DAL;
        private List<LoaiSanPhamDTO> listDTO;


        public LoaiSanPhamBLL()
        {
            this.DAL = new LoaiSanPhamDAL();
        }

        public List<LoaiSanPhamDTO> GetList()
        {
            listDTO = new List<LoaiSanPhamDTO>();
            listDTO = this.DAL.SelectAll();

            return listDTO;
        }
        public List<LoaiSanPhamDTO> GetListDeleted()
        {
            listDTO = new List<LoaiSanPhamDTO>();
            listDTO = this.DAL.SelectAllDeleted();

            return listDTO;
        }
        public int Insert(LoaiSanPhamDTO dto)
        {
            return this.DAL.Insert(dto);
        }

        public void Update(LoaiSanPhamDTO dto)
        {
            this.DAL.Update(dto);
        }

        public int Delete(int dtoId)
        {
            return this.DAL.Delete(dtoId);
        }

        public void Restore(int id)
        {
            this.DAL.Restore(id);
        }

        public List<LoaiSanPhamDTO> GetLSPByNCC(int ma_ncc)
        {
            return this.DAL.GetLSPByNCC(ma_ncc);
        }
        public List<LoaiSanPhamDTO> TimKiem(string timkiem)
        {
            return this.DAL.TimKiem(timkiem);
        }
        public List<LoaiSanPhamDTO> TimKiemDeleted(string timkiem)
        {
            return this.DAL.TimKiemDeleted(timkiem);
        }
        public LoaiSanPhamDTO GetLSPByMaLSP(int ma_loai)
        {
            return this.DAL.GetLSPByMaLSP(ma_loai)[0];

        }

        public List<LoaiSanPhamDTO> GetLSPByName(string ten_loai_san_pham)
        {
            return this.DAL.GetLSPByName(ten_loai_san_pham);
        }
    }
}
