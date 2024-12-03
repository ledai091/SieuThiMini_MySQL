using System.Collections.Generic;
using SieuThiMini.DTO;
using SieuThiMini.DAL;
namespace SieuThiMini.BLL
{
    class SanPhamBLL
    {
        private SanPhamDAL DAL;
        private List<SanPhamDTO> dtoList;

        public SanPhamBLL()
        {
            DAL = new SanPhamDAL();
            dtoList = new List<SanPhamDTO>();
        }
        public List<SanPhamDTO> GetList()
        {
            dtoList = new List<SanPhamDTO>();
            dtoList = this.DAL.SelectAll();
            return dtoList;
        }
        public int Insert(SanPhamDTO dto)
        {
            return this.DAL.Insert(dto);
        }
        public void Update(SanPhamDTO dto) 
        {
            this.DAL.Update(dto);
        }
        public void UpdateSoLuong(int ma_san_pham, int so_luong)
        {
            this.DAL.UpdateSoLuong(ma_san_pham, so_luong);
        }
        public void Delete(int ma_san_pham)
        {
            this.DAL.Delete(ma_san_pham);
        }
        public void Restore(int ma_san_pham)
        {
            this.DAL.Restore(ma_san_pham);
        }
        public SanPhamDTO getSPByMaSP(int ma)
        {
            return this.DAL.getSPByMaSP(ma)[0];
        }
        public List<SanPhamDTO> getSPByLoaiSP(int ma)
        {
            return this.DAL.getSPByMaSP(ma);
        }
        public List<SanPhamDTO> GetSPByNameSP(string name)
        {
            return this.DAL.GetSPByNameSP(name);
        }
        public List<SanPhamDTO> TimKiem(string value)
        {
            return this.DAL.TimKiem(value);
        }
    }
}
