using SieuThiMini.BLL;
using SieuThiMini.DAL;
using SieuThiMini.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace SieuThiMini.GUI
{
    public partial class LoaiSanPham : Form
    {
        private DataProvider dp = new DataProvider();
        private DataTable dt;
        LoaiSanPhamBLL bll = new LoaiSanPhamBLL();
        public LoaiSanPham()
        {
            InitializeComponent();
            dt = dp.ExecuteQuery("SELECT ma_ncc FROM nha_cung_cap ORDER BY ma_ncc");
            foreach (DataRow dr in dt.Rows)
            {
                cb_MaNCC.Items.Add(dr["ma_ncc"]);
            }
        }

        private void LoaiSanPham_Load(object sender, EventArgs e)
        {
            List<LoaiSanPhamDTO> list = bll.GetList();
            grid_LoaiSanPham.DataSource = list;
            grid_LoaiSanPham.Columns["trang_thai"].Visible = false;
            grid_LoaiSanPham.Columns["ma_loai"].HeaderText = "Mã Loại";
            grid_LoaiSanPham.Columns["ten_loai"].HeaderText = "Tên Loại";
            grid_LoaiSanPham.Columns["ma_ncc"].HeaderText = "Mã nhà cung cấp";

            grid_LoaiSanPham.Columns["ma_loai"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grid_LoaiSanPham.Columns["ten_loai"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grid_LoaiSanPham.Columns["ma_ncc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            var datGridViewArgs = new DataGridViewCellEventArgs(0, 0);
            grid_LoaiSanPham_CellContentClick(sender, datGridViewArgs);
        }

        private void grid_LoaiSanPham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox_MaLSP.Enabled = false;
            textBox_TenLoaiSanPham.Enabled = false;
            cb_MaNCC.Enabled = false;
            btn_Save.Visible = false;
            btn_Huy.Visible = false;

            if (e.RowIndex == -1) return;
            DataGridViewRow row = new DataGridViewRow();
            row = grid_LoaiSanPham.Rows[e.RowIndex];
            textBox_MaLSP.Text = Convert.ToString(row.Cells["ma_loai"].Value);
            textBox_TenLoaiSanPham.Text = Convert.ToString(row.Cells["ten_loai"].Value);
            cb_MaNCC.Text = Convert.ToString(row.Cells["ma_ncc"].Value);
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            int ma_ncc;
            string tenLoai = textBox_TenLoaiSanPham.Text;
            int maloai = int.Parse(textBox_MaLSP.Text);
            if (cb_MaNCC.Text != "")
            {
                ma_ncc = int.Parse(cb_MaNCC.Text);
            }
            else
            {
                ma_ncc = 0;
            }
            if (tenLoai != "" && ma_ncc > 0)
            {
                LoaiSanPhamDTO lsp = new LoaiSanPhamDTO(maloai, tenLoai, ma_ncc, "1");
                bll.Update(lsp);
                textBox_TenLoaiSanPham.Enabled = false;
                cb_MaNCC.Enabled = false;
                btn_Save.Visible = false;
                btn_Huy.Visible = false;
                MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                List<LoaiSanPhamDTO> list = bll.GetList();
                grid_LoaiSanPham.DataSource = list;
            }
            else
            {
                MessageBox.Show("Các hạn chế gồm:\n \n1. Không được bỏ trống bất cứ thông tin nào \n2. Giá bán và giá nhập phải lớn hơn 0", "Thông tin không hợp lệ! Hãy kiểm tra lại", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_ThemSanPham_Click(object sender, EventArgs e)
        {
            ThemLoaiSanPham themlsp = new ThemLoaiSanPham();
            themlsp.ShowDialog();
        }

        private void btn_SuaSanPham_Click(object sender, EventArgs e)
        {
            if (textBox_MaLSP.Text == "")
            {
                MessageBox.Show("Chọn loại sản phẩm cần sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                textBox_TenLoaiSanPham.Enabled = true;
                cb_MaNCC.Enabled = true;
                btn_Save.Visible = true;
                btn_Huy.Visible = true;
            }
        }

        private void btn_Reload_Click(object sender, EventArgs e)
        {
            List<LoaiSanPhamDTO> list = bll.GetList();
            grid_LoaiSanPham.DataSource = list;
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            int index = grid_LoaiSanPham.SelectedRows[0].Index;
            var dataGridViewArgs = new DataGridViewCellEventArgs(0, index);
            grid_LoaiSanPham_CellContentClick(sender, dataGridViewArgs);
        }

        private void textBox_TimSanPham_TextChanged(object sender, EventArgs e)
        {
            string timkiem = textBox_TimSanPham.Text;
            LoaiSanPhamBLL bll = new LoaiSanPhamBLL();
            List<LoaiSanPhamDTO> list = bll.TimKiem(timkiem);
            grid_LoaiSanPham.DataSource = list;
        }

        private void btn_XoaSP_Click(object sender, EventArgs e)
        {
            if (textBox_MaLSP.Text != "")
            {
                int maLoai = int.Parse(textBox_MaLSP.Text.ToString());
                SanPhamBLL spbll = new SanPhamBLL();
                List<SanPhamDTO> list = spbll.getSPByLoaiSP(maLoai);
                if (list.Count != 0)
                {
                    string message = "Danh sách sản phẩm thuộc loại sản phẩm này:\n";
                    foreach (var sp in list)
                    {
                        message += $"ID: {sp.ma_san_pham}, Tên: {sp.ten_san_pham}, Trang thai: {sp.trang_thai}\n"; // Thay các thuộc tính phù hợp với SanPhamDTO
                    }
                    MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                else
                {
                    bll.Delete(maLoai);
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btn_Reload_Click(null, null);
                    var dataGridViewArgs = new DataGridViewCellEventArgs(0, 0);
                    grid_LoaiSanPham_CellContentClick(sender, dataGridViewArgs);
                }
            }
            else
            {
                MessageBox.Show("Chọn loại sản phẩm cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_KhoiPhuc_Click(object sender, EventArgs e)
        {
            KhoiPhucLoaiSanPham kplsp = new KhoiPhucLoaiSanPham();
            kplsp.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void grid_LoaiSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            if (e.RowIndex == -1) return;

            row = grid_LoaiSanPham.Rows[e.RowIndex];
            textBox_MaLSP.Text = Convert.ToString(row.Cells["ma_loai"].Value);
            textBox_TenLoaiSanPham.Text = Convert.ToString(row.Cells["ten_loai"].Value);
            cb_MaNCC.Text = Convert.ToString(row.Cells["ma_ncc"].Value);
        }
    }
}
