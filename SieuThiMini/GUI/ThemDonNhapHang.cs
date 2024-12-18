using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using SieuThiMini.BLL;
using SieuThiMini.DAL;
using SieuThiMini.DTO;

namespace SieuThiMini.GUI
{
    public partial class ThemDonNhapHang : Form
    {
        private DataProvider dp = new DataProvider();
        private DataTable dt;
        int maNV;
        public ThemDonNhapHang(int maNV)
        {
            InitializeComponent();
            this.maNV = maNV;
        }

        private void ThemDonNhapHang_Load(object sender, EventArgs e)
        {
            cbo_NCC.Items.Add(" ");
            cbo_NCC.SelectedIndex = 0;
            dt = dp.ExecuteQuery("SELECT ten_ncc FROM nha_cung_cap");
            foreach (DataRow dr in dt.Rows)
            {
                cbo_NCC.Items.Add(dr["ten_ncc"].ToString());
            }
            dt = dp.ExecuteQuery("SELECT ma_san_pham, ten_san_pham, so_luong, gia, thanh_tien FROM chi_tiet_don_nhap_hang");
            dt.Clear();
            grid_DonNhapHang.DataSource = dt;
            grid_DonNhapHang.Columns["ma_san_pham"].HeaderText = "Mã sản phẩm";
            grid_DonNhapHang.Columns["ten_san_pham"].HeaderText = "Tên sản phẩm";
            grid_DonNhapHang.Columns["so_luong"].HeaderText = "Số lượng";
            grid_DonNhapHang.Columns["gia"].HeaderText = "Giá";
            grid_DonNhapHang.Columns["thanh_tien"].HeaderText = "Thành tiền";

        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            cbo_NCC.Enabled = false;
            if (grid_SanPham.CurrentCell == null)
            {
                MessageBox.Show("Chưa chọn sản phẩm");
                return;
            }
            dt = (DataTable)grid_SanPham.DataSource;
            DataGridViewRow selectedRow = grid_SanPham.Rows[grid_SanPham.CurrentRow.Index];

            foreach (DataGridViewRow dr in grid_DonNhapHang.Rows)
            {
                if (Convert.ToInt32(dr.Cells["ma_san_pham"].Value) == Convert.ToInt32(selectedRow.Cells["ma_san_pham"].Value))
                {
                    dr.Cells["so_luong"].Value = Convert.ToInt32(dr.Cells["so_luong"].Value) + ud_SoLuong.Value;
                    dr.Cells["thanh_tien"].Value = Convert.ToDecimal(dr.Cells["gia"].Value) * Convert.ToInt32(dr.Cells["so_luong"].Value);
                    grid_DonNhapHang.CurrentRow.Selected = false;
                    return;
                }
            }
            dt = (DataTable)grid_DonNhapHang.DataSource;
            int maSanPham = Convert.ToInt32(selectedRow.Cells["ma_san_pham"].Value);
            string tenSanPham = selectedRow.Cells["ten_san_pham"].Value.ToString();
            int soLuong = Convert.ToInt32(ud_SoLuong.Value);
            decimal gia_nhap = Convert.ToDecimal(selectedRow.Cells["gia_nhap"].Value);
            decimal total = ud_SoLuong.Value * gia_nhap;

            dt.Rows.Add(maSanPham, tenSanPham, soLuong, gia_nhap, total);

            grid_DonNhapHang.DataSource = dt;

            decimal totalGia = 0;
            foreach (DataGridViewRow dr in grid_DonNhapHang.Rows)
            {
                totalGia += Convert.ToDecimal(dr.Cells["thanh_tien"].Value);
            }

            label_TT.Text = totalGia.ToString();

            grid_DonNhapHang.CurrentRow.Selected = false;
            return;
        }

        private void cbo_NCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_NCC.SelectedIndex != 0)
            {
                string nccSelected = cbo_NCC.GetItemText(cbo_NCC.SelectedItem);
                dt = dp.ExecuteQuery($"SELECT ma_san_pham, ncc.ma_ncc, ten_san_pham, gia_nhap " +
                $"FROM san_pham sp, loai_san_pham lsp, nha_cung_cap ncc " +
                $"WHERE sp.ma_loai = lsp.ma_loai AND ncc.ma_ncc = lsp.ma_ncc AND ncc.ten_ncc = '" + nccSelected + "'");
                grid_SanPham.DataSource = dt;
                grid_SanPham.CurrentCell.Selected = false;
            }
            else
            {
                dt = dp.ExecuteQuery("SELECT ma_san_pham, ten_san_pham, gia_nhap FROM san_pham");
                dt.Clear();
                grid_SanPham.DataSource = dt;
            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            if (grid_DonNhapHang.CurrentCell == null)
            {
                MessageBox.Show("Chưa chọn sản phẩm");
                return;
            }
            if (grid_DonNhapHang.Rows.Count == 1)
            {
                cbo_NCC.Enabled = true;
            }
            grid_DonNhapHang.Rows.Remove(grid_DonNhapHang.Rows[grid_DonNhapHang.CurrentRow.Index]);
            grid_SanPham.CurrentRow.Selected = false;
        }

        private void grid_DonNhapHang_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == grid_DonNhapHang.Columns["thanh_tien"].Index)
            {
                decimal totalGia = 0;
                foreach (DataGridViewRow dr in grid_DonNhapHang.Rows)
                {
                    totalGia += Convert.ToDecimal(dr.Cells["thanh_tien"].Value);
                }
                label_TT.Text = totalGia.ToString();
            }
        }

        private void btn_ThanhToan_Click(object sender, EventArgs e)
        {
            if (grid_DonNhapHang == null)
            {
                MessageBox.Show("Bảng đơn nhập hàng chưa được khởi tạo.");
                return;
            }

            if (grid_DonNhapHang.Rows.Count == 0)
            {
                MessageBox.Show("Chưa chọn sản phẩm");
                return;
            }
            else if (cbo_NCC.SelectedItem == null)
            {
                MessageBox.Show("Chưa chọn nhà cung cấp");
                return;
            }

            DateTime ngayNhap = DateTime.Now;
            object selectedValue = cbo_NCC.SelectedItem;
            string nccSelected = null;

            if (selectedValue != null)
            {
                nccSelected = selectedValue.ToString();
            }

            NhaCungCapBLL bll = new NhaCungCapBLL();
            List<NhaCungCapDTO> nhaCungCapDTOs = bll.GetNCCByName(nccSelected);
            int maNCC = 0;

            foreach (var ncc in nhaCungCapDTOs)
            {
                maNCC = ncc.ma_ncc;
            }

            DonNhapHangBLL donNhapHangBLL = new DonNhapHangBLL();
            List<DonNhapHangDTO> donNhapHangDTOs = donNhapHangBLL.GetList();
            DonNhapHangDTO donNhapHangDTO = donNhapHangDTOs[donNhapHangDTOs.Count - 1];

            int maDonNhap = donNhapHangDTO.ma_don_nh + 1;

            CTDonNhapHangBLL ctDonNhapHangBLL = new CTDonNhapHangBLL();

            SanPhamBLL sanPhamBLL = new SanPhamBLL();
            DonNhapHangDTO donNhapHang = new DonNhapHangDTO(0, maNCC, maNV, ngayNhap, Convert.ToInt32(label_TT.Text), "1");
            donNhapHangBLL.Insert(donNhapHang);

            foreach (DataGridViewRow dr in grid_DonNhapHang.Rows)
            {
                CTDonNhapHangDTO ctdnhDTO = new CTDonNhapHangDTO(
                    maDonNhap,
                    Convert.ToInt32(dr.Cells["ma_san_pham"].Value),
                    dr.Cells["ten_san_pham"].Value.ToString(),
                    Convert.ToInt32(dr.Cells["so_luong"].Value),
                    Convert.ToInt32(dr.Cells["gia"].Value),
                    Convert.ToInt32(dr.Cells["thanh_tien"].Value)
                );
                ctDonNhapHangBLL.Insert(ctdnhDTO);
                SanPhamDTO sanPhamDTO = sanPhamBLL.getSPByMaSP(Convert.ToInt32(dr.Cells["ma_san_pham"].Value));
                sanPhamBLL.UpdateSoLuong(Convert.ToInt32(dr.Cells["ma_san_pham"].Value), sanPhamDTO.so_luong + Convert.ToInt32(dr.Cells["so_luong"].Value));
            }

            dt = dp.ExecuteQuery("SELECT ma_san_pham, ten_san_pham, so_luong, gia_nhap FROM chi_tiet_don_nhap_hang");
            dt.Clear();
            grid_DonNhapHang.DataSource = dt;
            MessageBox.Show("Thanh toán thành công.");
        }
    }
}
