using System;
using System.Collections.Generic;
using SieuThiMini.DTO;
using System.Data;
namespace SieuThiMini.DAL
{
    class DonNhapHangDAL : DataConnection
    {
        public DonNhapHangDAL() { }
        public List<DonNhapHangDTO> SelectAll()
        {
            List<DonNhapHangDTO> dtoList = new List<DonNhapHangDTO>();
            string query = "SELECT * FROM don_nhap_hang WHERE trang_thai='1'";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];

                int ma_don_nh = int.Parse(dr.ItemArray[0].ToString());
                int ma_ncc = int.Parse(dr.ItemArray[1].ToString());
                int ma_nhan_vien = int.Parse(dr.ItemArray[2].ToString());
                DateTime ngay_nhap = DateTime.Parse(dr.ItemArray[3].ToString());
                int tong_tien_nhap = int.Parse(dr.ItemArray[4].ToString());
                string trang_thai = dr.ItemArray[5].ToString();

                DonNhapHangDTO dto = new DonNhapHangDTO(ma_don_nh, ma_ncc, ma_nhan_vien, ngay_nhap, tong_tien_nhap, trang_thai);
                dtoList.Add(dto);
            }
            return dtoList;
        }
        public List<DonNhapHangDTO> SelectAllDeleted()
        {
            List<DonNhapHangDTO> dtoList = new List<DonNhapHangDTO>();
            string query = "SELECT * FROM don_nhap_hang WHERE trang_thai='0'";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];

                int ma_don_nh = int.Parse(dr.ItemArray[0].ToString());
                int ma_ncc = int.Parse(dr.ItemArray[1].ToString());
                int ma_nhan_vien = int.Parse(dr.ItemArray[2].ToString());
                DateTime ngay_nhap = DateTime.Parse(dr.ItemArray[3].ToString());
                int tong_tien_nhap = int.Parse(dr.ItemArray[4].ToString());
                string trang_thai = dr.ItemArray[5].ToString();

                DonNhapHangDTO dto = new DonNhapHangDTO(ma_don_nh, ma_ncc, ma_nhan_vien, ngay_nhap, tong_tien_nhap, trang_thai);
                dtoList.Add(dto);
            }
            return dtoList;
        }
        public int Insert(DonNhapHangDTO target)
        {
            string ngay_nhap = target.ngay_nhap.ToString("yyyy-MM-dd");
            Moketnoi();
            string query = $"INSERT INTO don_nhap_hang VALUES('0','{target.ma_ncc}', '{target.ma_nhan_vien}', '{ngay_nhap}', '{target.tong_tien_nhap}', '1')";
            return DataProvider.Instance.ExecuteNonQuery(query);
        }
        public int Delete(string id)
        {
            Moketnoi();
            string query = $"UPDATE don_nhap_hang SET trang_thai='0' WHERE ma_don_nh='{id}'";
            return DataProvider.Instance.ExecuteNonQuery(query);
        }
        public int Restore(string id)
        {
            Moketnoi();
            string query = $"UPDATE don_nhap_hang SET trang_thai='1' WHERE ma_don_nh='{id}'";
            return DataProvider.Instance.ExecuteNonQuery(query);
        }
        public List<DonNhapHangDTO> GetDNHByMaDNH(string ma)
        {
            List<DonNhapHangDTO> dtoList = new List<DonNhapHangDTO>();
            string query = $"SELECT * FROM don_nhap_hang WHERE ma_don_nh = '{ma}'";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];

                int ma_don_nh = int.Parse(dr.ItemArray[0].ToString());
                int ma_ncc = int.Parse(dr.ItemArray[1].ToString());
                int ma_nhan_vien = int.Parse(dr.ItemArray[2].ToString());
                DateTime ngay_nhap = DateTime.Parse(dr.ItemArray[3].ToString());
                int tong_tien_nhap = int.Parse(dr.ItemArray[4].ToString());
                string trang_thai = dr.ItemArray[5].ToString();

                DonNhapHangDTO dto = new DonNhapHangDTO(ma_don_nh, ma_ncc, ma_nhan_vien, ngay_nhap, tong_tien_nhap, trang_thai);
                dtoList.Add(dto);
            }
            return dtoList;
        }
    }
}
