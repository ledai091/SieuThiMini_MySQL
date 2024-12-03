using System;
using System.Collections.Generic;
using SieuThiMini.DTO;
using System.Data;
namespace SieuThiMini.DAL
{
    class HoaDonDAL : DataConnection
    {
        public HoaDonDAL() { }
        public List<HoaDonDTO> SelectAll()
        {
            List<HoaDonDTO> dtoList = new List<HoaDonDTO>();
            string query = "SELECT * FROM hoa_don WHERE trang_thai='1'";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];

                int ma_hoa_don = int.Parse(dr.ItemArray[0].ToString());
                DateTime ngayLap = DateTime.Parse(dr.ItemArray[1].ToString());
                int ma_nhan_vien = int.Parse(dr.ItemArray[2].ToString());
                int tong_tien = int.Parse(dr.ItemArray[3].ToString());
                string trang_thai = dr.ItemArray[4].ToString();

                HoaDonDTO dto = new HoaDonDTO(ma_hoa_don, ngayLap, ma_nhan_vien, tong_tien, trang_thai);
                dtoList.Add(dto);
            }
            return dtoList;
        }
        public List<HoaDonDTO> SelectAllDeleted()
        {
            List<HoaDonDTO> dtoList = new List<HoaDonDTO>();
            string query = "SELECT * FROM hoa_don WHERE trang_thai='0'";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];

                int ma_hoa_don = int.Parse(dr.ItemArray[0].ToString());
                DateTime ngay_xuat = DateTime.Parse(dr.ItemArray[1].ToString());
                int ma_nhan_vien = int.Parse(dr.ItemArray[2].ToString());
                int tong_tien = int.Parse(dr.ItemArray[3].ToString());
                string trang_thai = dr.ItemArray[4].ToString();

                HoaDonDTO dto = new HoaDonDTO(ma_hoa_don, ngay_xuat, ma_nhan_vien, tong_tien, trang_thai);
                dtoList.Add(dto);
            }
            return dtoList;
        }
        public int Insert(HoaDonDTO target)
        {
            string ngay_xuat = target.ngay_xuat.ToString("yyyy-MM-dd");
            Moketnoi();
            string query = $"INSERT INTO hoa_don VALUES('0','{ngay_xuat}', '{target.ma_nhan_vien}', '{target.tong_tien}', '1')";
            return DataProvider.Instance.ExecuteNonQuery(query);
        }
        public int Delete(string id)
        {
            Moketnoi();
            string query = $"UPDATE hoa_don SET trang_thai='0' WHERE ma_hoa_don='{id}'";
            return DataProvider.Instance.ExecuteNonQuery(query);
        }
        public int Restore(string id)
        {
            Moketnoi();
            string query = $"UPDATE hoa_don SET trang_thai='1' WHERE ma_hoa_don='{id}'";
            return DataProvider.Instance.ExecuteNonQuery(query);
        }
        public List<HoaDonDTO> GetHDByMaHD(int ma)
        {
            List<HoaDonDTO> dtoList = new List<HoaDonDTO>();
            string query = $"SELECT * FROM hoa_don WHERE ma_hoa_don = '{ma}'";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];

                int ma_hoa_don = int.Parse(dr.ItemArray[0].ToString());
                DateTime ngay_xuat = DateTime.Parse(dr.ItemArray[1].ToString());
                int ma_nhan_vien = int.Parse(dr.ItemArray[2].ToString());
                int tong_tien = int.Parse(dr.ItemArray[3].ToString());
                string trang_thai = dr.ItemArray[4].ToString();

                HoaDonDTO dto = new HoaDonDTO(ma_hoa_don, ngay_xuat, ma_nhan_vien, tong_tien, trang_thai);
                dtoList.Add(dto);
            }
            return dtoList;
        }
    }
}
