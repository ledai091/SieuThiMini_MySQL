using System.Collections.Generic;
using SieuThiMini.DTO;
using SieuThiMini.DAL;
using System.Data;
namespace SieuThiMini.BLL
{
    class TaiKhoanBLL
    {
        private TaiKhoanDAL dal;
        private List<TaiKhoanDTO> dtoList;
        public TaiKhoanBLL()
        {
            this.dal = new TaiKhoanDAL();
        }
        public List<TaiKhoanDTO> SelectAll()
        {
            return this.dal.SelectAll();
        }
        public DataTable SelectAllDeleted()
        {
            return this.dal.SelectAllDeleted();
        }
        public List<TaiKhoanDTO> Timkiem(string timkiem)
        {
            return this.dal.Timkiem(timkiem);
        }
        public List<TaiKhoanDTO> TimkiemDeleted(string timkiem)
        {
            return this.dal.TimkiemDeleted(timkiem);
        }
        public int Insert(TaiKhoanDTO target)
        {
            return this.dal.Insert(target);
        }
        public void Update(TaiKhoanDTO target)
        {
            this.dal.Update(target);
        }
        public void Delete(int id)
        {
            this.dal.Delete(id);
        }
        public void Restore(int id)
        {
            this.dal.Restore(id);
        }
        public TaiKhoanDTO GetTKByMaTK(string ma_tai_khoan)
        {
            return this.dal.GetTKByMaTK(ma_tai_khoan)[0];
        }
        public List<TaiKhoanDTO> GetTKByQuyen(string quyen)
        {
            return this.dal.GetTKByQuyen(quyen);
        }
        public List<TaiKhoanDTO> GetTKByNameTK(string name)
        {
            return this.dal.GetTKByNameTK(name);
        }
        public TaiKhoanDTO SignIn(string tentk, string mk)
        {
            return this.dal.SignIn(tentk, mk)[0];
        }
    }
}
