using System.Collections.Generic;
using SieuThiMini.DTO;
using System.Data;
using System;

namespace SieuThiMini.DAL
{
    class LoaiSanPhamDAL : DataConnection
    {
        public LoaiSanPhamDAL() { }
        public List<LoaiSanPhamDTO> SelectAll()
        {
            List<LoaiSanPhamDTO> dtoList = new List<LoaiSanPhamDTO>();
            string query = "SELECT * FROM loai_san_pham WHERE trang_thai='1'";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow datarow = dt.Rows[i];
                int ma_loai = int.Parse(datarow.ItemArray[0].ToString());
                string ten_loai = datarow.ItemArray[1].ToString();
                int maNcc = int.Parse(datarow.ItemArray[2].ToString());
                string trang_thai = datarow.ItemArray[3].ToString();
                LoaiSanPhamDTO dto = new LoaiSanPhamDTO(ma_loai, ten_loai, maNcc, trang_thai);
                dtoList.Add(dto);
            }
            return dtoList;
        }
        public List<LoaiSanPhamDTO> SelectAllDeleted()
        {
            List<LoaiSanPhamDTO> dtoList = new List<LoaiSanPhamDTO>();
            string query = "SELECT * FROM loai_san_pham WHERE trang_thai='0'";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow datarow = dt.Rows[i];
                int ma_loai = int.Parse(datarow.ItemArray[0].ToString());
                string ten_loai = datarow.ItemArray[1].ToString();
                int ma_ncc = int.Parse(datarow.ItemArray[2].ToString());
                string trang_thai = datarow.ItemArray[3].ToString();
                LoaiSanPhamDTO dto = new LoaiSanPhamDTO(ma_loai, ten_loai, ma_ncc, trang_thai);
                dtoList.Add(dto);
            }
            return dtoList;
        }
        public int Insert(LoaiSanPhamDTO target)
        {
            Moketnoi();
            string query = $"INSERT INTO loai_san_pham VALUES ('', '{target.ten_loai}', '{target.ma_ncc}', '1')";
            return DataProvider.Instance.ExecuteNonQuery(query);
        }
        public void Update(LoaiSanPhamDTO target)
        {
            Moketnoi();
            string query = "UPDATE loai_san_pham SET ";
            query += $"ten_loai = '{target.ten_loai}', ";
            query += $"ma_ncc = '{target.ma_ncc}' ";
            query += $"WHERE ma_loai = '{target.ma_loai}'";
            DataProvider.Instance.ExecuteNonQuery(query);
        }
        public int Delete(int id)
        {
            Moketnoi();
            string query = $"UPDATE loai_san_pham SET trang_thai='0' WHERE ma_loai = '{id}'";
            return DataProvider.Instance.ExecuteNonQuery(query);
        }
        public int Restore(int id)
        {
            Moketnoi();
            string query = $"UPDATE loai_san_pham SET trang_thai='1' WHERE ma_loai = '{id}'";
            return DataProvider.Instance.ExecuteNonQuery(query);
        }
        public List<LoaiSanPhamDTO> GetLSPByMaLSP(int ma)
        {
            List<LoaiSanPhamDTO> dtoList = new List<LoaiSanPhamDTO>();

            string query = $"SELECT * FROM loai_san_pham WHERE ma_loai = '{ma}'";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];

                int ma_loai = int.Parse(dr.ItemArray[0].ToString());
                string ten_loai = dr.ItemArray[1].ToString();
                int ma_ncc = int.Parse(dr.ItemArray[2].ToString());
                string trang_thai = dr.ItemArray[3].ToString();

                LoaiSanPhamDTO dto = new LoaiSanPhamDTO(ma_loai, ten_loai, ma_ncc, trang_thai);

                dtoList.Add(dto);
            }
            return dtoList;
        }
        public List<LoaiSanPhamDTO> GetLSPByNCC(int mancc)
        {
            List<LoaiSanPhamDTO> dtoList = new List<LoaiSanPhamDTO>();
            string query = $"SELECT * FROM loai_san_pham WHERE ma_ncc='{mancc}'";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow datarow = dt.Rows[i];
                int ma_loai = int.Parse(datarow.ItemArray[0].ToString());
                string ten_loai = datarow.ItemArray[1].ToString();
                int ma_ncc = Convert.ToInt32(datarow.ItemArray[2]);
                string trang_thai = datarow.ItemArray[3].ToString();
                LoaiSanPhamDTO dto = new LoaiSanPhamDTO(ma_loai, ten_loai, ma_ncc, trang_thai);
                dtoList.Add(dto);
            }
            return dtoList;
        }

        public List<LoaiSanPhamDTO> GetLSPByName(string name)
        {
            List<LoaiSanPhamDTO> dtoList = new List<LoaiSanPhamDTO>();
            string query = $"SELECT * FROM loai_san_pham WHERE ten_loai LIKE '%{name}%'";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow datarow = dt.Rows[i];
                int ma_loai = int.Parse(datarow.ItemArray[0].ToString());
                string ten_loai = datarow.ItemArray[1].ToString();
                int ma_ncc = int.Parse(datarow.ItemArray[2].ToString());
                string trang_thai = datarow.ItemArray[3].ToString();
                LoaiSanPhamDTO dto = new LoaiSanPhamDTO(ma_loai, ten_loai, ma_ncc, trang_thai);
                dtoList.Add(dto);
            }
            return dtoList;
        }

        public List<LoaiSanPhamDTO> TimKiem(string timkiem)
        {
            List<LoaiSanPhamDTO> dtoList = new List<LoaiSanPhamDTO>();
            string query = $"SELECT * FROM loai_san_pham WHERE trang_thai='1' AND (ma_loai='{timkiem}' OR ten_loai LIKE '%{timkiem}%')";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow datarow = dt.Rows[i];
                int ma_loai = int.Parse(datarow.ItemArray[0].ToString());
                string ten_loai = datarow.ItemArray[1].ToString();
                int ma_ncc = int.Parse(datarow.ItemArray[2].ToString());
                string trang_thai = datarow.ItemArray[3].ToString();
                LoaiSanPhamDTO dto = new LoaiSanPhamDTO(ma_loai, ten_loai, ma_ncc, trang_thai);
                dtoList.Add(dto);
            }
            return dtoList;
        }
        public List<LoaiSanPhamDTO> TimKiemDeleted(string timkiem)
        {
            List<LoaiSanPhamDTO> dtoList = new List<LoaiSanPhamDTO>();
            string query = $"SELECT * FROM loai_san_pham WHERE trang_thai='0' AND (ma_loai='{timkiem}' OR ten_loai LIKE '%{timkiem}%')";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow datarow = dt.Rows[i];
                int ma_loai = int.Parse(datarow.ItemArray[0].ToString());
                string ten_loai = datarow.ItemArray[1].ToString();
                int ma_ncc = int.Parse(datarow.ItemArray[2].ToString());
                string trang_thai = datarow.ItemArray[3].ToString();
                LoaiSanPhamDTO dto = new LoaiSanPhamDTO(ma_loai, ten_loai, ma_ncc, trang_thai);
                dtoList.Add(dto);
            }
            return dtoList;
        }
    }
}
