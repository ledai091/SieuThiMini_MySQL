using System.Collections.Generic;
using System.Data;
using SieuThiMini.DTO;
namespace SieuThiMini.DAL
{
    class CTDonNhapHangDAL : DataConnection
    {
        public CTDonNhapHangDAL() { }
        public List<CTDonNhapHangDTO> SelectAll()
        {
            List<CTDonNhapHangDTO> dtoList = new List<CTDonNhapHangDTO>();
            string query = "SELECT * FROM chi_tiet_don_nhap_hang";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                int ma_don_nh = int.Parse(dr.ItemArray[0].ToString());
                int ma_san_pham = int.Parse(dr.ItemArray[1].ToString());
                string ten_san_pham = dr.ItemArray[2].ToString();
                int so_luong = int.Parse(dr.ItemArray[3].ToString());
                int gia = int.Parse(dr.ItemArray[4].ToString());
                int thanh_tien = int.Parse(dr.ItemArray[5].ToString());
                CTDonNhapHangDTO dto = new CTDonNhapHangDTO(ma_don_nh, ma_san_pham, ten_san_pham, so_luong, gia, thanh_tien);
                dtoList.Add(dto);
            }
            return dtoList;
        }
        public int Insert(CTDonNhapHangDTO dto)
        {
            Moketnoi();
            string query = $"INSERT INTO chi_tiet_don_nhap_hang VALUES('{dto.ma_don_nh}', '{dto.ma_san_pham}', '{dto.ten_san_pham}', '{dto.so_luong}','{dto.gia}', '{dto.thanh_tien}')";
            return DataProvider.Instance.ExecuteNonQuery(query);
        }
        public List<CTDonNhapHangDTO> GetCTDNHByMaDNH(int ma)
        {
            List<CTDonNhapHangDTO> dtoList = new List<CTDonNhapHangDTO>();
            string query = $"SELECT * FROM chi_tiet_don_nhap_hang WHERE ma_don_nh = '{ma}'";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                int ma_don_nh = int.Parse(dr.ItemArray[0].ToString());
                int ma_san_pham = int.Parse(dr.ItemArray[1].ToString());
                string ten_san_pham = dr.ItemArray[2].ToString();
                int so_luong = int.Parse(dr.ItemArray[3].ToString());
                int gia = int.Parse(dr.ItemArray[4].ToString());
                int thanh_tien = int.Parse(dr.ItemArray[5].ToString());
                CTDonNhapHangDTO dto = new CTDonNhapHangDTO(ma_don_nh, ma_san_pham, ten_san_pham, so_luong, gia, thanh_tien);
                dtoList.Add(dto);
            }
            return dtoList;
        }
    }
}
