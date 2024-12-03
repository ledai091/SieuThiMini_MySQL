using System.Collections.Generic;
using SieuThiMini.DTO;
using SieuThiMini.DAL;
using System.Data;
namespace SieuThiMini.BLL
{
    class NhanVienBLL
    {
        private NhanVienDAL DAL;
        private List<NhanVienDTO> dtoList;
        
        public NhanVienBLL()
        {
            DAL = new NhanVienDAL();
        }
        public List<NhanVienDTO> GetList()
        {
            dtoList = new List<NhanVienDTO>();
            dtoList = this.DAL.SelectAll();
            return dtoList;
        }
        public DataTable GetNhanVien()
        {
            return this.DAL.GetNhanVien();
        }
        public DataTable GetDeletedNhanVien()
        {
            return this.DAL.GetDeletedNhanVien();
        }
        public DataTable GetDeletedNhanVienByKey(string key)
        {
            return this.DAL.GetDeletedNhanVienByKey(key);
        }
        public int Insert(NhanVienDTO dto)
        {
            return this.DAL.Insert(dto);
        }
        public void Update(NhanVienDTO dto)
        {
            this.DAL.Update(dto);
        }
        public int Delete(string id)
        {
            return this.DAL.Delete(id);
        }
        public void Restore(string id)
        {
            this.DAL.Restore(id);
        }
        public DataTable TimKiem(string key)
        {
            return this.DAL.TimKiem(key);
        }
        public NhanVienDTO GetNVByMaNV(string ma_nv)
        {
            return this.DAL.GetNVByMaNV(ma_nv)[0];
        }
        public List<NhanVienDTO> getNVByNameNV(string ten_nv)
        {
            return this.DAL.getNVByNameNV(ten_nv);
        }
        public List<NhanVienDTO> GetNVByMaTK(int ma_tai_khoan)
        {
            return this.DAL.getNVByMaTK(ma_tai_khoan);
        }
        public DataTable getTKByMaNV(string ma_nv)
        {
            return this.DAL.getTKByMaNV(ma_nv);
        }

    }
}
