using System;
using System.Data;
using System.Windows.Forms;
using SieuThiMini.BLL;
using SieuThiMini.DAL;
namespace SieuThiMini.GUI
{
    public partial class KhoiPhucSanPham : Form
    {
        private DataProvider dp = new DataProvider();
        private DataTable dt;
        public KhoiPhucSanPham()
        {
            InitializeComponent();
        }

        private void KhoiPhucSanPham_Load(object sender, EventArgs e)
        {
            dt = dp.ExecuteQuery("SELECT * FROM san_pham WHERE trang_thai = 0");
            grid_SanPham.DataSource = dt;

            grid_SanPham.Columns["ma_san_pham"].HeaderText = "Mã sản phẩm";
            grid_SanPham.Columns["ten_san_pham"].HeaderText = "Tên sản phẩm";
            grid_SanPham.Columns["ma_loai"].HeaderText = "Mã loại";
            grid_SanPham.Columns["so_luong"].HeaderText = "Số lượng";
            grid_SanPham.Columns["gia"].HeaderText = "Giá";
            grid_SanPham.Columns["gia_nhap"].HeaderText = "Giá nhập";

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
        }

        private void btn_Reload_Click(object sender, EventArgs e)
        {
            dt = dp.ExecuteQuery("SELECT * FROM san_pham WHERE trang_thai = 0");
            grid_SanPham.DataSource = dt;
        }

        private void btn_KhoiPhuc_Click(object sender, EventArgs e)
        {
            if(grid_SanPham.SelectedRows.Count > 0)
            {
                int selectedRowIndex = grid_SanPham.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = grid_SanPham.Rows[selectedRowIndex];
                int maSP = int.Parse(selectedRow.Cells["ma_san_pham"].Value.ToString());

                SanPhamBLL spBLL = new SanPhamBLL();
                spBLL.Restore(maSP);
                MessageBox.Show("Khôi phục sản phẩm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btn_Reload_Click(null, null);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần khôi phục", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void textBox_TimSanPham_TextChanged(object sender, EventArgs e)
        {
            string valueQuery = textBox_TimSanPham.Text;
            if (valueQuery != "")
            {
                dt = dp.ExecuteQuery($"SELECT * FROM san_pham WHERE (ma_san_pham = '{valueQuery}' OR ma_loai = '{valueQuery}' OR ten_san_pham LIKE '%{valueQuery}%') AND trang_thai = 0");
                grid_SanPham.DataSource = dt;
            }
        }
    }
}
