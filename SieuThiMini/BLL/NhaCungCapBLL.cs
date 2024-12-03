using System.Collections.Generic;
using SieuThiMini.DTO;
using SieuThiMini.DAL;
namespace SieuThiMini.BLL
{
    class NhaCungCapBLL
    {
        private NhaCungCapDAL dal;
        public NhaCungCapBLL()
        {
            dal = new NhaCungCapDAL();
        }
        public List<NhaCungCapDTO> SelectAll()
        {
            return dal.SelectAll();
        }
        public List<NhaCungCapDTO> SelectAllDeleted()
        {
            return dal.SelectAllDeleted();
        }
        public int Insert(NhaCungCapDTO target)
        {
            return dal.Insert(target);
        }
        public int Restore(int id)
        {
            return dal.Restore(id);
        }
        public void Update(NhaCungCapDTO target)
        {
            dal.Update(target);
        }
        public int Delete(int id)
        {
            return dal.Delete(id);
        }
        public List<NhaCungCapDTO> GetNCCByMaNCC(string ma)
        {
            return this.dal.GetNCCByMaNCC(ma);
        }
        public List<NhaCungCapDTO> GetNCCByName(string name)
        {
            return this.dal.GetNCCByName(name);
        }
    }
}
