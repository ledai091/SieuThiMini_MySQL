using System.Collections.Generic;
using SieuThiMini.DTO;
using SieuThiMini.DAL;
namespace SieuThiMini.BLL
{
    class PhanQuyenBLL
    {
        private PhanQuyenDAL dal;
        private List<PhanQuyenDTO> dtoList;
        public PhanQuyenBLL()
        {
            this.dal = new PhanQuyenDAL();
        }
        public List<PhanQuyenDTO> SelectAll()
        {
            return this.dal.SelectAll();
        }
        public int Insert(PhanQuyenDTO target)
        {
            return this.dal.Insert(target);
        }
        public void Update(PhanQuyenDTO target)
        {
            this.dal.Update(target);
        }
        public int Delete(string id)
        {
            return this.dal.Delete(id);
        }
        public List<PhanQuyenDTO> GetPQByMaPQ(string ma_phan_quyen)
        {
            return this.dal.GetPQByMaPQ(ma_phan_quyen);
        }
        public List<PhanQuyenDTO> GetPQByNamePQ(string name)
        {
            return this.dal.GetPQByNamePQ(name);
        }
    }
}
