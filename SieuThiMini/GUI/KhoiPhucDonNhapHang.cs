using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SieuThiMini.BLL;
using SieuThiMini.DTO;
namespace SieuThiMini.GUI
{
    public partial class KhoiPhucDonNhapHang : Form
    {
        public KhoiPhucDonNhapHang()
        {
            InitializeComponent();
        }

        private void textFind_TextChanged(object sender, EventArgs e)
        {
            string searchText = textFind.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(searchText))
            {
                DonNhapHangBLL bll = new DonNhapHangBLL();
                List<DonNhapHangDTO> ds = bll.GetListDeleted();
                grid_DNHDeleted.DataSource = ds;
            }
            else
            {
                DonNhapHangBLL bll = new DonNhapHangBLL();
                List<DonNhapHangDTO> ds = bll.GetList();
                List<DonNhapHangDTO> result = new List<DonNhapHangDTO>();
                foreach (DonNhapHangDTO item in ds)
                {
                    if (item.ma_don_nh.ToString().Contains(searchText) || item.ma_ncc.ToString().Contains(searchText) || item.ma_nhan_vien.ToString().Contains(searchText) || item.ngay_nhap.ToString().Contains(searchText) || item.tong_tien_nhap.ToString().Contains(searchText) || item.trang_thai.ToString().Contains(searchText))
                    {
                        result.Add(item);
                    }
                }
                grid_DNHDeleted.DataSource = result;

            }
        }

        private void KhoiPhucDonNhapHang_Load(object sender, EventArgs e)
        {
            DonNhapHangBLL donNhapHangBLL = new DonNhapHangBLL();
            List<DonNhapHangDTO> danhSachDonNhapHang = donNhapHangBLL.GetListDeleted();

            grid_DNHDeleted.DataSource = danhSachDonNhapHang;

            grid_DNHDeleted.Columns["ma_don_nh"].HeaderText = "Mã Đơn Nhập";
            grid_DNHDeleted.Columns["ma_ncc"].HeaderText = "Mã Nhà Cung Cấp";
            grid_DNHDeleted.Columns["ma_nhan_vien"].HeaderText = "Mã Nhân Viên";
            grid_DNHDeleted.Columns["ngay_nhap"].HeaderText = "Ngày Nhập";
            grid_DNHDeleted.Columns["tong_tien_nhap"].HeaderText = "Tổng Tiền Nhập";
            grid_DNHDeleted.Columns["trang_thai"].HeaderText = "Trạng Thái";

            grid_DNHDeleted.Columns["ma_don_nh"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grid_DNHDeleted.Columns["ma_ncc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grid_DNHDeleted.Columns["ma_nhan_vien"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grid_DNHDeleted.Columns["ngay_nhap"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grid_DNHDeleted.Columns["tong_tien_nhap"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grid_DNHDeleted.Columns["trang_thai"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }

        private void btn_Restore_Click(object sender, EventArgs e)
        {
            if(grid_DNHDeleted.SelectedRows.Count > 0)
            {
                int selectedRowIndex = grid_DNHDeleted.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = grid_DNHDeleted.Rows[selectedRowIndex];
                string maDNH = selectedRow.Cells["ma_don_nh"].Value.ToString();
                DonNhapHangBLL donNhapHangBLL = new DonNhapHangBLL();
                donNhapHangBLL.Update(maDNH);

                List<DonNhapHangDTO> ds = donNhapHangBLL.GetListDeleted();
                grid_DNHDeleted.DataSource = ds;
            }
        }
    }
}
