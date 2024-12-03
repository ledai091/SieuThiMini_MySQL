using SieuThiMini.BLL;
using SieuThiMini.DAL;
using SieuThiMini.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace SieuThiMini.GUI
{
    public partial class SanPham : Form
    {
        private DataProvider dp = new DataProvider();
        private DataTable dt;
        public SanPham()
        {
            InitializeComponent();
            dt = dp.ExecuteQuery("SELECT ma_loai FROM loai_san_pham ORDER BY ma_loai ASC");
            foreach(DataRow dr in dt.Rows)
            {
                cb_MaLoai.Items.Add(dr["ma_loai"]);
            }
        }

        private void SanPham_Load(object sender, EventArgs e)
        {
            SanPhamBLL spBLL = new SanPhamBLL();
            List<SanPhamDTO> listSP = spBLL.GetList();
            grid_SanPham.DataSource = listSP;

            grid_SanPham.Columns["ma_san_pham"].HeaderText = "Mã sản phẩm";
            grid_SanPham.Columns["ten_san_pham"].HeaderText = "Tên sản phẩm";
            grid_SanPham.Columns["ma_loai"].HeaderText = "Mã loại";
            grid_SanPham.Columns["so_luong"].HeaderText = "Số lượng";
            grid_SanPham.Columns["gia"].HeaderText = "Giá";
            grid_SanPham.Columns["gia_nhap"].HeaderText = "Giá nhập";

            grid_SanPham.Columns["trang_thai"].Visible = false;
            grid_SanPham.Columns["ma_san_pham"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grid_SanPham.Columns["ten_san_pham"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grid_SanPham.Columns["ma_loai"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grid_SanPham.Columns["so_luong"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grid_SanPham.Columns["gia"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grid_SanPham.Columns["gia_nhap"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            grid_SanPham.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grid_SanPham.Columns["ma_san_pham"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grid_SanPham.Columns["ma_loai"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grid_SanPham.Columns["so_luong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grid_SanPham.Columns["gia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grid_SanPham.Columns["gia_nhap"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            var dataGridViewArgs = new DataGridViewCellEventArgs(0, 0);
            grid_SanPham_CellContentClick(sender, dataGridViewArgs);
        }

        private void grid_SanPham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox_MaSP.Enabled = false;
            textBox_SoLuong.Enabled = false;
            textBox_TenSanPham.Enabled = false;
            textBox_GiaNhap.Enabled = false;
            textBox_Gia.Enabled = false;
            btn_Save.Visible = false;
            btn_Huy.Visible = false;
            cb_MaLoai.Enabled = false;
        }

        private void btn_ThemSanPham_Click(object sender, EventArgs e)
        {
            ThemSanPham themSP = new ThemSanPham();
            themSP.ShowDialog();
        }

        private void btn_SuaSanPham_Click(object sender, EventArgs e)
        {
            if (textBox_MaSP.Text == "")
            {
                MessageBox.Show("Hãy chọn 1 sản phẩm để sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                textBox_TenSanPham.Enabled = true;
                textBox_Gia.Enabled = true;
                textBox_GiaNhap.Enabled = true;
                cb_MaLoai.Enabled = true;
                btn_Save.Enabled = true;
                btn_Huy.Enabled = true;
                textBox_SoLuong.Enabled = true;
                textBox_MaSP.Enabled = true;
                btn_Huy.Visible = true;
                btn_Save.Visible = true;
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            int maLoai = Convert.ToInt32(cb_MaLoai.Text);
            int maSP = Convert.ToInt32(textBox_MaSP.Text);
            string tenSP = textBox_TenSanPham.Text;
            int soLuong = Convert.ToInt32(textBox_SoLuong.Text);
            int gia;
            int gianhap;
            if(textBox_Gia.Text != "" && textBox_GiaNhap.Text != "")
            {
                gia = Convert.ToInt32(textBox_Gia.Text);
                gianhap = Convert.ToInt32(textBox_GiaNhap.Text);
            }
            else
            {
                gia = 0;
                gianhap = 0;
            }
            if (tenSP != "" && gia > 0 && gianhap > 0)
            {
                SanPhamDTO spDTO = new SanPhamDTO(maSP, tenSP, soLuong, gia, gianhap, maLoai, "1");
                SanPhamBLL spBLL = new SanPhamBLL();
                spBLL.Update(spDTO);
                textBox_MaSP.Enabled = false;
                textBox_SoLuong.Enabled = false;
                textBox_TenSanPham.Enabled = false;
                textBox_GiaNhap.Enabled = false;
                textBox_Gia.Enabled = false;
                btn_Save.Visible = false;
                btn_Huy.Visible = false;
                cb_MaLoai.Enabled = false;
                MessageBox.Show("Sửa thông tin sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SanPham_Load(null, null);
            }
            else
            {
                MessageBox.Show("Các hạn chế gồm:\n \n1. Không được bỏ trống bất cứ thông tin nào \n2. Giá bán và giá nhập phải lớn hơn 0", "Thông tin không hợp lệ! Hãy kiểm tra lại", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            textBox_MaSP.Enabled = false;
            textBox_SoLuong.Enabled = false;
            textBox_TenSanPham.Enabled = false;
            textBox_GiaNhap.Enabled = false;
            textBox_Gia.Enabled = false;
            btn_Save.Visible = false;
            btn_Huy.Visible = false;
            cb_MaLoai.Enabled = false;
        }

        private void btn_XoaSP_Click(object sender, EventArgs e)
        {
            int maSP = int.Parse(textBox_MaSP.Text);
            int soLuong = int.Parse(textBox_SoLuong.Text);
            if (soLuong == 0)
            {
                SanPhamBLL spBLL = new SanPhamBLL();
                spBLL.Delete(maSP);
                MessageBox.Show("Xóa sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Không thể xóa sản phẩm này vì còn hàng trong kho!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void textBox_TimSanPham_TextChanged(object sender, EventArgs e)
        {
            string value = textBox_TimSanPham.Text;
            SanPhamBLL spBLL = new SanPhamBLL();
            List<SanPhamDTO> listSP = spBLL.TimKiem(value);
            grid_SanPham.DataSource = listSP;
        }
        private void btn_Reload_Click(object sender, EventArgs e)
        {
            SanPhamBLL spBLL = new SanPhamBLL();
            grid_SanPham.DataSource = spBLL.GetList();
        }

        private void btn_KhoiPhuc_Click(object sender, EventArgs e)
        {
            KhoiPhucSanPham kpsp = new KhoiPhucSanPham();
            kpsp.ShowDialog();
        }

        private void grid_SanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox_MaSP.Enabled = false;
            textBox_SoLuong.Enabled = false;
            textBox_TenSanPham.Enabled = false;
            textBox_GiaNhap.Enabled = false;
            textBox_Gia.Enabled = false;
            btn_Save.Visible = false;
            btn_Huy.Visible = false;
            cb_MaLoai.Enabled = false;

            if (e.RowIndex == -1) return;
            DataGridViewRow row = new DataGridViewRow();
            row = grid_SanPham.Rows[e.RowIndex];
            textBox_MaSP.Text = Convert.ToString(row.Cells["ma_san_pham"].Value);
            cb_MaLoai.Text = Convert.ToString(row.Cells["ma_loai"].Value);
            textBox_TenSanPham.Text = Convert.ToString(row.Cells["ten_san_pham"].Value);
            textBox_SoLuong.Text = Convert.ToString(row.Cells["so_luong"].Value);
            textBox_Gia.Text = Convert.ToString(row.Cells["gia"].Value);
            textBox_GiaNhap.Text = Convert.ToString(row.Cells["gia_nhap"].Value);
        }
    }
}
