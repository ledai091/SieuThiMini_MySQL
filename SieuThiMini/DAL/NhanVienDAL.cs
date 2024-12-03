using System;
using System.Collections.Generic;
using System.Data;
using SieuThiMini.DTO;

namespace SieuThiMini.DAL
{
    class NhanVienDAL : DataConnection
    {
        public NhanVienDAL() { }
        public List<NhanVienDTO> SelectAll()
        {
            List<NhanVienDTO> dtoList = new List<NhanVienDTO>();

            string queryStr = "SELECT nhan_vien.*, tai_khoan.phan_quyen FROM nhan_vien, tai_khoan WHERE nhan_vien.tai_khoan=tai_khoan.ma_tai_khoan AND tai_khoan.phan_quyen!=0";

            DataTable result = DataProvider.Instance.ExecuteQuery(queryStr);
            for (int i = 0; i < result.Rows.Count; i++)
            {
                DataRow datarow = result.Rows[i];

                int ma_nhan_vien = int.Parse(datarow.ItemArray[0].ToString());
                string ten_nhan_vien = datarow.ItemArray[1].ToString();
                DateTime ngay_sinh = (DateTime)datarow.ItemArray[2];

                string sdt = datarow.ItemArray[3].ToString();
                string mail = datarow.ItemArray[4].ToString();
                int tai_khoan = int.Parse(datarow.ItemArray[5].ToString());

                NhanVienDTO dto = new NhanVienDTO(ma_nhan_vien, ten_nhan_vien, ngay_sinh, sdt, mail, tai_khoan);
                dtoList.Add(dto);
            }

            return dtoList;
        }

        public DataTable GetNhanVien()
        {
            string query = "SELECT ma_nhan_vien, ten_nhan_vien, ngay_sinh, sdt, mail, tai_khoan from nhan_vien WHERE trang_thai='1'";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            return dt;
        }

        public DataTable GetDeletedNhanVien()
        {
            string query = "SELECT ma_nhan_vien, ten_nhan_vien, ngay_sinh, sdt, mail, tai_khoan from nhan_vien WHERE trang_thai='0'";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            return dt;
        }

        public DataTable GetDeletedNhanVienByKey(string key)
        {
            string query = $"SELECT * FROM nhan_vien WHERE trang_thai = '0' AND (ma_nhan_vien LIKE '%{key}%' OR ten_nhan_vien LIKE '%{key}%')";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            return dt;
        }

        public int Insert(NhanVienDTO target)
        {
            Moketnoi();
            string ngay_sinh = target.ngay_sinh.ToString("yyyy-MM-dd");
            string insertStr = $"INSERT INTO nhan_vien VALUES ('', '{target.ten_nhan_vien}', '{ngay_sinh}', " +
                                $"'{target.sdt}', '{target.mail}', '{target.tai_khoan}', '1')";
            return DataProvider.Instance.ExecuteNonQuery(insertStr);
        }

        public void Update(NhanVienDTO target)
        {
            Moketnoi();
            string ngay_sinh = target.ngay_sinh.ToString("yyyy-MM-dd");

            string updateStr = "UPDATE nhan_vien SET";
            updateStr += $"ten_nhan_vien = '{target.ten_nhan_vien}',";
            updateStr += $"ngay_sinh = '{target.ngay_sinh}',";
            updateStr += $"sdt = '{target.sdt}',";
            updateStr += $"mail = '{target.mail}',";
            updateStr += $"tai_khoan = '{target.tai_khoan}',";
            updateStr += $"WHERE ma_nhan_vien = '{target.ma_nhan_vien}'";

            DataProvider.Instance.ExecuteNonQuery(updateStr);
        }

        public int Delete(string id)
        {
            Moketnoi();
            string deleteStr = $"UPDATE nhan_vien SET trang_thai = '0' WHERE ma_nhan_vien = '{id}'";
            return DataProvider.Instance.ExecuteNonQuery(deleteStr);
        }

        public int Restore(string id)
        {
            Moketnoi();
            string resStr = $"UPDATE nhan_vien SET trang_thai = '1' WHERE ma_nhan_vien = '{id}'";
            return DataProvider.Instance.ExecuteNonQuery(resStr);
        }

        public DataTable TimKiem(string key)
        {
            Moketnoi();
            string query = $"SELECT * FROM nhan_vien WHERE trang_thai = '1' AND (ma_nhan_vien LIKE '%{key}%' OR ten_nhan_vien LIKE '%{key}%')";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public List<NhanVienDTO> GetNVByMaNV(string ma_nv)
        {
            List<NhanVienDTO> dtoList = new List<NhanVienDTO>();

            string queryStr = $"SELECT * FROM nhan_vien WHERE ma_nhan_vien='{ma_nv}'";

            DataTable result = DataProvider.Instance.ExecuteQuery(queryStr);
            for (int i = 0; i < result.Rows.Count; i++)
            {
                DataRow datarow = result.Rows[i];

                int ma_nhan_vien = int.Parse(datarow.ItemArray[0].ToString());
                string ten_nhan_vien = datarow.ItemArray[1].ToString();
                DateTime ngay_sinh = (DateTime)datarow.ItemArray[2];

                string std = datarow.ItemArray[3].ToString();
                string mail = datarow.ItemArray[4].ToString();
                int tai_khoan = int.Parse(datarow.ItemArray[5].ToString());

                NhanVienDTO dto = new NhanVienDTO(ma_nhan_vien, ten_nhan_vien, ngay_sinh, std, mail, tai_khoan);
                dtoList.Add(dto);
            }
            return dtoList;
        }

        public List<NhanVienDTO> getNVByNameNV(string ten_nv)
        {
            List<NhanVienDTO> dtoList = new List<NhanVienDTO>();
            string queryStr = $"SELECT * FROM nhan_vien WHERE ten_nhan_vien LIKE '%{ten_nv}%'";
            DataTable result = DataProvider.Instance.ExecuteQuery(queryStr);
            for (int i = 0; i < result.Rows.Count; i++)
            {
                DataRow datarow = result.Rows[i];

                int ma_nhan_vien = int.Parse(datarow.ItemArray[0].ToString());
                string ten_nhan_vien = datarow.ItemArray[1].ToString();
                DateTime ngay_sinh = (DateTime)datarow.ItemArray[2];

                string std = datarow.ItemArray[3].ToString();
                string mail = datarow.ItemArray[4].ToString();
                int tai_khoan = int.Parse(datarow.ItemArray[5].ToString());

                NhanVienDTO dto = new NhanVienDTO(ma_nhan_vien, ten_nhan_vien, ngay_sinh, std, mail, tai_khoan);
                dtoList.Add(dto);
            }
            return dtoList;
        }

        public List<NhanVienDTO> getNVByMaTK(int ma_tai_khoan)
        {
            List<NhanVienDTO> dtoList = new List<NhanVienDTO>();
            string queryStr = $"SELECT * FROM nhan_vien WHERE tai_khoan = '{ma_tai_khoan}'";
            DataTable result = DataProvider.Instance.ExecuteQuery(queryStr);
            for (int i = 0; i < result.Rows.Count; i++)
            {
                DataRow datarow = result.Rows[i];

                int ma_nhan_vien = int.Parse(datarow.ItemArray[0].ToString());
                string ten_nhan_vien = datarow.ItemArray[1].ToString();
                DateTime ngay_sinh = (DateTime)datarow.ItemArray[2];

                string std = datarow.ItemArray[3].ToString();
                string mail = datarow.ItemArray[4].ToString();
                int tai_khoan = int.Parse(datarow.ItemArray[5].ToString());

                NhanVienDTO dto = new NhanVienDTO(ma_nhan_vien, ten_nhan_vien, ngay_sinh, std, mail, tai_khoan);
                dtoList.Add(dto);
            }
            return dtoList;
        }

        public DataTable getTKByMaNV(string ma_nv)
        {
            string query = $"SELECT tai_khoan FROM nhan_vien WHERE ma_tai_khoan = '{ma_nv}'";
            return DataProvider.Instance.ExecuteQuery(query);
        }
    }
}
