using System.Collections.Generic;
using SieuThiMini.DTO;
using System.Data;
namespace SieuThiMini.DAL
{
    class NhaCungCapDAL : DataConnection
    {
        public NhaCungCapDAL() { }
        public List<NhaCungCapDTO> SelectAll()
        {
            List<NhaCungCapDTO> dtoList = new List<NhaCungCapDTO>();
            string query = "SELECT * FROM nha_cung_cap WHERE trang_thai='1'";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow datarow = dt.Rows[i];
                int ma_ncc = int.Parse(datarow.ItemArray[0].ToString());
                string ten_ncc = datarow.ItemArray[1].ToString();
                string dia_chi = datarow.ItemArray[2].ToString();
                string trang_thai = datarow.ItemArray[3].ToString();
                NhaCungCapDTO dto = new NhaCungCapDTO(ma_ncc, ten_ncc, dia_chi, trang_thai);
                dtoList.Add(dto);
            }
            return dtoList;
        }

        public List<NhaCungCapDTO> SelectAllDeleted()
        {
            List<NhaCungCapDTO> dtoList = new List<NhaCungCapDTO>();
            string query = "SELECT * FROM nha_cung_cap WHERE trang_thai='0'";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow datarow = dt.Rows[i];
                int ma_ncc = int.Parse(datarow.ItemArray[0].ToString());
                string ten_ncc = datarow.ItemArray[1].ToString();
                string dia_chi = datarow.ItemArray[2].ToString();
                string trang_thai = datarow.ItemArray[3].ToString();
                NhaCungCapDTO dto = new NhaCungCapDTO(ma_ncc, ten_ncc, dia_chi, trang_thai);
                dtoList.Add(dto);
            }
            return dtoList;
        }
        public int Insert(NhaCungCapDTO target)
        {
            Moketnoi();
            string query = $"INSERT INTO nha_cung_cap VALUES ('', '{target.ten_ncc}', '{target.dia_chi}', '{target.trang_thai}')";
            return DataProvider.Instance.ExecuteNonQuery(query);
        }

        public int Restore(int id)
        {
            Moketnoi();
            string query = $"UPDATE nha_cung_cap SET trang_thai='1' WHERE ma_ncc = '{id}'";
            return DataProvider.Instance.ExecuteNonQuery(query);
        }
        public void Update(NhaCungCapDTO target)
        {
            Moketnoi();
            string query = "UPDATE nha_cung_cap SET ";
            query += $"ten_ncc = '{target.ten_ncc}', ";
            query += $"dia_chi = '{target.dia_chi}' ";
            query += $"WHERE ma_ncc = '{target.ma_ncc}'";
            DataProvider.Instance.ExecuteNonQuery(query);
        }

        public int Delete(int id)
        {
            Moketnoi();
            string query = $"UPDATE nha_cung_cap SET trang_thai='0' WHERE ma_ncc = '{id}'";
            return DataProvider.Instance.ExecuteNonQuery(query);
        }
        public List<NhaCungCapDTO> GetNCCByMaNCC(string ma)
        {
            List<NhaCungCapDTO> dtoList = new List<NhaCungCapDTO>();
            string query = $"SELECT * FROM nha_cung_cap WHERE ma_ncc = '{ma}'";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                int ma_ncc = int.Parse(dr.ItemArray[0].ToString());
                string ten_ncc = dr.ItemArray[1].ToString();
                string dia_chi = dr.ItemArray[2].ToString();
                string trang_thai = dr.ItemArray[3].ToString();
                NhaCungCapDTO dto = new NhaCungCapDTO(ma_ncc, ten_ncc, dia_chi, trang_thai);
                dtoList.Add(dto);
            }
            return dtoList;
        }
        public List<NhaCungCapDTO> GetNCCByName(string name)
        {
            List<NhaCungCapDTO> dtoList = new List<NhaCungCapDTO>();
            string query = $"SELECT * FROM nha_cung_cap WHERE ten_ncc LIKE '%{name}%'";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                int ma_ncc = int.Parse(dr.ItemArray[0].ToString());
                string ten_ncc = dr.ItemArray[1].ToString();
                string dia_chi = dr.ItemArray[2].ToString();
                string trang_thai = dr.ItemArray[3].ToString();
                NhaCungCapDTO dto = new NhaCungCapDTO(ma_ncc, ten_ncc, dia_chi, trang_thai);
                dtoList.Add(dto);
            }
            return dtoList;
        }
    }
}
