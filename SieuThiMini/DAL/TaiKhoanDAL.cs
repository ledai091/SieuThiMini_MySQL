using System;
using System.Collections.Generic;
using System.Data;
using SieuThiMini.DTO;
namespace SieuThiMini.DAL
{
    class TaiKhoanDAL : DataConnection
    {
        public TaiKhoanDAL() { }
        public List<TaiKhoanDTO> SelectAll()
        {
            List<TaiKhoanDTO> dtoList = new List<TaiKhoanDTO>();
            string query = "SELECT * FROM tai_khoan WHERE trang_thai='1' AND phan_quyen!=0";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                int ma_tai_khoan = int.Parse(dr.ItemArray[0].ToString());
                string ten_tai_khoan = dr.ItemArray[1].ToString();
                string mat_khau = dr.ItemArray[2].ToString();
                int phan_quyen = int.Parse(dr.ItemArray[3].ToString());
                int trang_thai = Convert.ToInt32(dr.ItemArray[4]);
                TaiKhoanDTO dto = new TaiKhoanDTO(ma_tai_khoan, ten_tai_khoan, mat_khau, phan_quyen, trang_thai);
                dtoList.Add(dto);
            }
            return dtoList;
        }
        public DataTable SelectAllDeleted()
        {
            string query = "SELECT * FROM tai_khoan WHERE trang_thai='0' AND phan_quyen != '0'";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            return dt;
        }
        public List<TaiKhoanDTO> Timkiem(string timkiem)
        {
            List<TaiKhoanDTO> dtoList = new List<TaiKhoanDTO>();
            string query = $"SELECT * FROM tai_khoan WHERE trang_thai='1' AND phan_quyen != '0' AND (ten_tai_khoan LIKE '%{timkiem}%' OR ma_tai_khoan LIKE '%{timkiem}%')";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                int ma_tai_khoan = int.Parse(dr.ItemArray[0].ToString());
                string ten_tai_khoan = dr.ItemArray[1].ToString();
                string mat_khau = dr.ItemArray[2].ToString();
                int phan_quyen = int.Parse(dr.ItemArray[3].ToString());
                int trang_thai = Convert.ToInt32(dr.ItemArray[4]);
                TaiKhoanDTO dto = new TaiKhoanDTO(ma_tai_khoan, ten_tai_khoan, mat_khau, phan_quyen, trang_thai);
                dtoList.Add(dto);
            }
            return dtoList;
        }
        public List<TaiKhoanDTO> TimkiemDeleted(string timkiem)
        {
            List<TaiKhoanDTO> dtoList = new List<TaiKhoanDTO>();
            string query = $"SELECT * FROM tai_khoan WHERE trang_thai='0' AND phan_quyen != '0' AND (tentai_khoan LIKE '%{timkiem}%' OR ma_tai_khoan LIKE '%{timkiem}%')";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                int ma_tai_khoan = int.Parse(dr.ItemArray[0].ToString());
                string ten_tai_khoan = dr.ItemArray[1].ToString();
                string mat_khau = dr.ItemArray[2].ToString();
                int phan_quyen = int.Parse(dr.ItemArray[3].ToString());
                int trang_thai = int.Parse(dr.ItemArray[4].ToString());
                TaiKhoanDTO dto = new TaiKhoanDTO(ma_tai_khoan, ten_tai_khoan, mat_khau, phan_quyen, trang_thai);
                dtoList.Add(dto);
            }
            return dtoList;
        }
        public int Insert(TaiKhoanDTO target)
        {
            Moketnoi();
            string query = $"INSERT INTO tai_khoan VALUES ('', '{target.ten_tai_khoan}', '{target.mat_khau}', '{target.phan_quyen}', '{target.trang_thai}')";
            return DataProvider.Instance.ExecuteNonQuery(query);
        }
        public void Update(TaiKhoanDTO target)
        {
            Moketnoi();
            string query = "UPDATE tai_khoan SET ";
            query += $"ten_tai_khoan = '{target.ten_tai_khoan}', ";
            query += $"mat_khau = '{target.mat_khau}', ";
            query += $"phan_quyen = '{target.phan_quyen}' ";
            query += $"WHERE ma_tai_khoan = '{target.ma_tai_khoan}'";
            DataProvider.Instance.ExecuteNonQuery(query);

        }
        public void Delete(int id)
        {
            Moketnoi();
            string query = $"UPDATE tai_khoan SET trang_thai='0' WHERE ma_tai_khoan = '{id}'";
            DataProvider.Instance.ExecuteNonQuery(query);
        }
        public void Restore(int id)
        {
            Moketnoi();
            string query = $"UPDATE tai_khoan SET trang_thai='1' WHERE ma_tai_khoan = '{id}'";
            DataProvider.Instance.ExecuteNonQuery(query);
        }

        public List<TaiKhoanDTO> GetTKByMaTK(string ma_tai_khoan)
        {
            List<TaiKhoanDTO> dtoList = new List<TaiKhoanDTO>();
            string query = $"SELECT * FROM tai_khoan WHERE ma_tai_khoan = '{ma_tai_khoan}'";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                int ma_tai_khoan_ = int.Parse(dr.ItemArray[0].ToString());
                string ten_tai_khoan = dr.ItemArray[1].ToString();
                string mat_khau = dr.ItemArray[2].ToString();
                int phan_quyen = Convert.ToInt32(dr.ItemArray[3].ToString());
                int trang_thai = Convert.ToInt32(dr.ItemArray[4]);
                TaiKhoanDTO dto = new TaiKhoanDTO(ma_tai_khoan_, ten_tai_khoan, mat_khau, phan_quyen, trang_thai);
                dtoList.Add(dto);
            }
            return dtoList;
        }

        public List<TaiKhoanDTO> GetTKByQuyen(string quyen)
        {
            List<TaiKhoanDTO> dtoList = new List<TaiKhoanDTO>();
            string query = $"SELECT * FROM tai_khoan WHERE phan_quyen = '{quyen}'";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                int ma_tai_khoan = int.Parse(dr.ItemArray[0].ToString());
                string ten_tai_khoan = dr.ItemArray[1].ToString();
                string mat_khau = dr.ItemArray[2].ToString();
                int phan_quyen = int.Parse(dr.ItemArray[3].ToString());
                int trang_thai = int.Parse(dr.ItemArray[4].ToString());
                TaiKhoanDTO dto = new TaiKhoanDTO(ma_tai_khoan, ten_tai_khoan, mat_khau, phan_quyen, trang_thai);
                dtoList.Add(dto);
            }
            return dtoList;
        }
        public List<TaiKhoanDTO> GetTKByNameTK(string name)
        {
            List<TaiKhoanDTO> dtoList = new List<TaiKhoanDTO>();
            string query = $"SELECT * FROM tai_khoan WHERE ten_tai_khoan LIKE '%{name}%'";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                int ma_tai_khoan = int.Parse(dr.ItemArray[0].ToString());
                string ten_tai_khoan = dr.ItemArray[1].ToString();
                string mat_khau = dr.ItemArray[2].ToString();
                int phan_quyen = int.Parse(dr.ItemArray[3].ToString());
                int trang_thai = int.Parse(dr.ItemArray[4].ToString());
                TaiKhoanDTO dto = new TaiKhoanDTO(ma_tai_khoan, ten_tai_khoan, mat_khau, phan_quyen, trang_thai);
                dtoList.Add(dto);
            }
            return dtoList;
        }

        public List<TaiKhoanDTO> SignIn(string tentk, string mk)
        {
            List<TaiKhoanDTO> dtoList = new List<TaiKhoanDTO>();
            string query = $"SELECT * FROM tai_khoan WHERE ten_tai_khoan ='{tentk}' AND mat_khau = '{mk}'";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                int ma_tai_khoan = int.Parse(dr.ItemArray[0].ToString());
                string ten_tai_khoan = dr.ItemArray[1].ToString();
                string mat_khau = dr.ItemArray[2].ToString();
                int phan_quyen = Convert.ToInt32(dr.ItemArray[3].ToString());
                int trang_thai = Convert.ToInt32(dr.ItemArray[4]);
                TaiKhoanDTO dto = new TaiKhoanDTO(ma_tai_khoan, ten_tai_khoan, mat_khau, phan_quyen, trang_thai);
                dtoList.Add(dto);
            }
            return dtoList;
        }
    }
}

