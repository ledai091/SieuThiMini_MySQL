using System;
using System.Collections.Generic;
using System.Data;
using SieuThiMini.DTO;
namespace SieuThiMini.DAL
{
    class CTHoaDonDAL : DataConnection
    {
        public CTHoaDonDAL() { }
        public List<CTHoaDonDTO> SelectAll()
        {
            List<CTHoaDonDTO> dtoList = new List<CTHoaDonDTO>();
            string query = "SELECT * FROM chi_tiet_hoa_don";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                int ma_hoa_don = int.Parse(dr.ItemArray[0].ToString());
                int ma_san_pham = int.Parse(dr.ItemArray[1].ToString());
                string ten_san_pham = dr.ItemArray[2].ToString();
                int so_luong = int.Parse(dr.ItemArray[3].ToString());
                int gia_san_pham = int.Parse(dr.ItemArray[3].ToString());
                int thanh_tien = int.Parse(dr.ItemArray[3].ToString());

                CTHoaDonDTO hoaDonDTO = new CTHoaDonDTO(ma_hoa_don, ma_san_pham, ten_san_pham, so_luong, gia_san_pham, thanh_tien);
                dtoList.Add(hoaDonDTO);
            }
            return dtoList;
        }
        public int Insert(CTHoaDonDTO dto)
        {
            Moketnoi();
            string query = $"INSERT INTO chi_tiet_hoa_don VALUES('{dto.ma_hoa_don}', '{dto.ma_san_pham}', N'{dto.ten_san_pham}', '{dto.so_luong}', '{dto.gia_san_pham}', '{dto.thanh_tien}')";
            return DataProvider.Instance.ExecuteNonQuery(query);
        }
        public List<CTHoaDonDTO> GetCTHDByMaHD(int ma)
        {
            List<CTHoaDonDTO> dtoList = new List<CTHoaDonDTO>();
            string query = $"SELECT * FROM chi_tiet_hoa_don WHERE ma_hoa_don = '{ma}'";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                int ma_hoa_don = int.Parse(dr.ItemArray[0].ToString());
                int ma_san_pham = int.Parse(dr.ItemArray[1].ToString());
                string ten_san_pham = dr.ItemArray[2].ToString();
                int so_luong = int.Parse(dr.ItemArray[3].ToString());
                int gia_san_pham = int.Parse(dr.ItemArray[4].ToString());
                int thanh_tien = int.Parse(dr.ItemArray[5].ToString());

                CTHoaDonDTO hoaDonDTO = new CTHoaDonDTO(ma_hoa_don, ma_san_pham, ten_san_pham, so_luong, gia_san_pham, thanh_tien);
                dtoList.Add(hoaDonDTO);
            }
            return dtoList;
        }
    }
}
