using System;
using System.Collections.Generic;
using System.Data;
using SieuThiMini.DTO;
namespace SieuThiMini.DAL
{
    class SanPhamDAL : DataConnection
    {
        public SanPhamDAL() { }
        public List<SanPhamDTO> SelectAll()
        {
            List<SanPhamDTO> dtoList = new List<SanPhamDTO>();
            string query = "SELECT * FROM san_pham WHERE trang_thai =  1";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                int ma_san_pham = int.Parse(dr.ItemArray[0].ToString());
                string ten_san_pham = dr.ItemArray[1].ToString();
                int so_luong = Convert.ToInt32(dr.ItemArray[2]);
                int gia = int.Parse(dr.ItemArray[3].ToString());
                int gia_nhap = int.Parse(dr.ItemArray[4].ToString());
                int ma_loai = int.Parse(dr.ItemArray[5].ToString());
                string trang_thai = dr.ItemArray[6].ToString();
                SanPhamDTO dto = new SanPhamDTO(ma_san_pham, ten_san_pham, so_luong, gia, gia_nhap, ma_loai, trang_thai);
                dtoList.Add(dto);
            }
            return dtoList;
        }
        public int Insert(SanPhamDTO target)
        {
            Moketnoi();
            string query = $"INSER INTO san_pham VALUES ('', '{target.ten_san_pham}', '{target.so_luong}', '{target.gia}', '{target.gia_nhap}', '{target.ma_loai}', '1')";
            return DataProvider.Instance.ExecuteNonQuery(query);
        }
        public void Update(SanPhamDTO target)
        {
            Moketnoi();
            string query = "UPDATE san_pham SET ";
            query += $"ten_san_pham = '{target.ten_san_pham}', ";
            query += $"so_luong = '{target.so_luong}', ";
            query += $"gia = '{target.gia}', ";
            query += $"gia_nhap = '{target.gia_nhap}', ";
            query += $"ma_loai = '{target.ma_loai}' ";
            query += $"WHERE ma_san_pham = '{target.ma_san_pham}'";
            DataProvider.Instance.ExecuteNonQuery(query);
        }

        public void UpdateSoLuong(int ma_san_pham, int so_luong)
        {
            Moketnoi();
            string query = $"UPDATE san_pham SET so_luong = '{so_luong}' WHERE ma_san_pham = '{ma_san_pham}'";
            DataProvider.Instance.ExecuteNonQuery(query);
        }
        public int Delete(int id)
        {
            Moketnoi();
            string query = $"UPDATE san_pham SET trang_thai = '0' WHERE ma_san_pham = '{id}'";
            return DataProvider.Instance.ExecuteNonQuery(query);
        }
        public int Restore(int id)
        {
            Moketnoi();
            string query = $"UPDATE san_pham SET trang_thai = '1' WHERE ma_san_pham = '{id}'";
            return DataProvider.Instance.ExecuteNonQuery(query);
        }
        public List<SanPhamDTO> getSPByLoaiSP(int ma)
        {
            List<SanPhamDTO> dtoList = new List<SanPhamDTO>();
            string query = $"SELECT * FROM san_pham WHERE ma_loai = '{ma}' AND trang_thai = '1'";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                int ma_san_pham = int.Parse(dr.ItemArray[0].ToString());
                string ten_san_pham = dr.ItemArray[1].ToString();
                int so_luong = int.Parse(dr.ItemArray[2].ToString());
                int gia = int.Parse(dr.ItemArray[3].ToString());
                int gia_nhap = int.Parse(dr.ItemArray[4].ToString());
                int ma_loai = int.Parse(dr.ItemArray[5].ToString());
                string trang_thai = dr.ItemArray[6].ToString();
                SanPhamDTO dto = new SanPhamDTO(ma_san_pham, ten_san_pham, so_luong, gia, gia_nhap, ma_loai, trang_thai);
                dtoList.Add(dto);
            }
            return dtoList;
        }
        public List<SanPhamDTO> getSPByMaSP(int ma)
        {
            List<SanPhamDTO> dtoList = new List<SanPhamDTO>();
            string query = $"SELECT * FROM san_pham WHERE ma_san_pham = '{ma}'";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                int ma_san_pham = int.Parse(dr.ItemArray[0].ToString());
                string ten_san_pham = dr.ItemArray[1].ToString();
                int so_luong = int.Parse(dr.ItemArray[2].ToString());
                int gia = int.Parse(dr.ItemArray[3].ToString());
                int gia_nhap = int.Parse(dr.ItemArray[4].ToString());
                int ma_loai = int.Parse(dr.ItemArray[5].ToString());
                string trang_thai = dr.ItemArray[6].ToString();
                SanPhamDTO dto = new SanPhamDTO(ma_san_pham, ten_san_pham, so_luong, gia, gia_nhap, ma_loai, trang_thai);
                dtoList.Add(dto);
            }
            return dtoList;
        }
        public List<SanPhamDTO> GetSPByNameSP(string name)
        {
            List<SanPhamDTO> dtoList = new List<SanPhamDTO>();
            string query = $"SELECT * FROM san_pham WHERE ten_san_pham LIKE '%{name}%'";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                int ma_san_pham = int.Parse(dr.ItemArray[0].ToString());
                string ten_san_pham = dr.ItemArray[1].ToString();
                int so_luong = int.Parse(dr.ItemArray[2].ToString());
                int gia = int.Parse(dr.ItemArray[3].ToString());
                int gia_nhap = int.Parse(dr.ItemArray[4].ToString());
                int ma_loai = int.Parse(dr.ItemArray[5].ToString());
                string trang_thai = dr.ItemArray[6].ToString();
                SanPhamDTO dto = new SanPhamDTO(ma_san_pham, ten_san_pham, so_luong, gia, gia_nhap, ma_loai, trang_thai);
                dtoList.Add(dto);
            }
            return dtoList;
        }
        public List<SanPhamDTO> TimKiem(string value)
        {
            List<SanPhamDTO> dtoList = new List<SanPhamDTO>();
            string query = $"SELECT * FROM san_pham WHERE ten_san_pham LIKE '%{value}%' OR ma_san_pham LIKE '%{value}%' OR ma_loai LIKE '%{value}%' AND trang_thai = 1";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                int ma_san_pham = int.Parse(dr.ItemArray[0].ToString());
                string ten_san_pham = dr.ItemArray[1].ToString();
                int so_luong = int.Parse(dr.ItemArray[2].ToString());
                int gia = int.Parse(dr.ItemArray[3].ToString());
                int gia_nhap = int.Parse(dr.ItemArray[4].ToString());
                int ma_loai = int.Parse(dr.ItemArray[5].ToString());
                string trang_thai = dr.ItemArray[6].ToString();
                SanPhamDTO dto = new SanPhamDTO(ma_san_pham, ten_san_pham, so_luong, gia, gia_nhap, ma_loai, trang_thai);
                dtoList.Add(dto);
            }
            return dtoList;
        }
    }
}
