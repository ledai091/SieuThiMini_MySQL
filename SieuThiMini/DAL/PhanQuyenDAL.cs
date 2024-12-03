using System;
using System.Collections.Generic;
using System.Data;
using SieuThiMini.DTO;
namespace SieuThiMini.DAL
{
    class PhanQuyenDAL : DataConnection
    {
        public PhanQuyenDAL() { }
        public List<PhanQuyenDTO> SelectAll()
        {
            List<PhanQuyenDTO> dtoList = new List<PhanQuyenDTO>();

            string query = "SELECT * FROM phan_quyen";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow datarow = dt.Rows[i];
                int ma_quyen = int.Parse(datarow.ItemArray[0].ToString());
                string ten_quyen = datarow.ItemArray[1].ToString();
                PhanQuyenDTO dto = new PhanQuyenDTO(ma_quyen, ten_quyen);
                dtoList.Add(dto);
            }
            return dtoList;
        }
        public int Insert(PhanQuyenDTO target)
        {
            Moketnoi();
            string query = $"INSERT INTO phan_quyen VALUES ('', '{target.ten_quyen}')";
            return DataProvider.Instance.ExecuteNonQuery(query);
        }

        public void Update(PhanQuyenDTO target)
        {
            Moketnoi();
            string query = "UPDATE phan_quyen SET";
            query += $"ten_quyen = '{target.ten_quyen}'";
            query += $"WHERE ma_quyen = '{target.ma_quyen}'";
            DataProvider.Instance.ExecuteNonQuery(query);
        }

        public int Delete(string id)
        {
            Moketnoi();
            string query = $"DELETE FROM phan_quyen WHERE ma_quyen = '{id}'";
            return DataProvider.Instance.ExecuteNonQuery(query);
        }
        public List<PhanQuyenDTO> GetPQByMaPQ(string ma_phan_quyen)
        {
            List<PhanQuyenDTO> dtoList = new List<PhanQuyenDTO>();

            string query = $"SELECT * FROM phan_quyen WHERE ma_phan_quyen = '{ma_phan_quyen}'";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i] ;

                int ma_quyen = int.Parse(dr.ItemArray[0].ToString());
                string ten_quyen = dr.ItemArray[1].ToString();

                PhanQuyenDTO dto = new PhanQuyenDTO(ma_quyen, ten_quyen);

                dtoList.Add(dto);
            }
            return dtoList;
        }
        public List<PhanQuyenDTO> GetPQByNamePQ(string name)
        {
            List<PhanQuyenDTO> dtoList = new List<PhanQuyenDTO>();
            string query = $"SELECT * FROM phan_quyen WHERE ten_quyen = '{name}'";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                int ma_quyen = int.Parse (dr.ItemArray[0].ToString());
                string ten_quyen = dr.ItemArray [1].ToString();

                PhanQuyenDTO dto = new PhanQuyenDTO(ma_quyen, ten_quyen);
                dtoList.Add(dto);
            }
            return dtoList;
        }
    }
}