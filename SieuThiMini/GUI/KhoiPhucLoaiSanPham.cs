using SieuThiMini.BLL;
using SieuThiMini.DAL;
using System;
using System.Data;
using System.Windows.Forms;

namespace SieuThiMini.GUI
{
    public partial class KhoiPhucLoaiSanPham : Form
    {
        private DataProvider dp = new DataProvider();
        private DataTable dt;
        public KhoiPhucLoaiSanPham()
        {
            InitializeComponent();
        }

        private void KhoiPhucLoaiSanPham_Load(object sender, EventArgs e)
        {
            dt = dp.ExecuteQuery("SELECT ma_loai, ma_ncc, ten_loai FROM loai_san_pham WHERE trang_thai = 0");
            grid_LoaiSanPham.DataSource = dt;

            grid_LoaiSanPham.Columns["ma_loai"].HeaderText = "Mã loại";
            grid_LoaiSanPham.Columns["ma_ncc"].HeaderText = "Mã nhà cung cấp";
            grid_LoaiSanPham.Columns["ten_loai"].HeaderText = "Tên loại";

            grid_LoaiSanPham.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grid_LoaiSanPham.Columns["ma_loai"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grid_LoaiSanPham.Columns["ma_ncc"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grid_LoaiSanPham.Columns["ten_loai"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grid_LoaiSanPham.Columns["ma_loai"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grid_LoaiSanPham.Columns["ma_ncc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grid_LoaiSanPham.Columns["ten_loai"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }
        private void btn_Reload_Click(object sender, EventArgs e)
        {
            dt = dp.ExecuteQuery("SELECT ma_loai, ma_ncc, ten_loai FROM loai_san_pham WHERE trang_thai = 0");
            grid_LoaiSanPham.DataSource = dt;
        }

        private void btn_KhoiPhuc_Click(object sender, EventArgs e)
        {
            if (grid_LoaiSanPham.SelectedRows.Count > 0)
            {
                int selectedRowIndex = grid_LoaiSanPham.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = grid_LoaiSanPham.Rows[selectedRowIndex];
                int maLoai = int.Parse(selectedRow.Cells["ma_loai"].Value.ToString());

                LoaiSanPhamBLL bll = new LoaiSanPhamBLL();
                bll.Restore(maLoai);

                MessageBox.Show("Khôi phục thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btn_Reload_Click(null, null);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn loại sản phẩm cần khôi phục", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void textBox_TimLoaiSanPham_TextChanged(object sender, EventArgs e)
        {
            string query = textBox_TimLoaiSanPham.Text;
            if (query != "")
            {
                dt = dp.ExecuteQuery($"SELECT ma_loai, ma_ncc, ten_loai FROM loai_san_pham WHERE (ma_loai = '{query}' OR ma_ncc = '{query}' OR ten_loai LIKE '%{query}%' AND trang_thai = 0");
                grid_LoaiSanPham.DataSource = dt;
            }
            else
            {
                dt = dp.ExecuteQuery("SELECT ma_loai, ma_ncc, ten_loai FROM loai_san_pham WHERE trang_thai = 0");
                grid_LoaiSanPham.DataSource = dt;
            }
        }
    }
}
