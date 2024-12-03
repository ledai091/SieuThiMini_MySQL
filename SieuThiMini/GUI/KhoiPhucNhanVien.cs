using SieuThiMini.BLL;
using System;
using System.Data;
using System.Windows.Forms;

namespace SieuThiMini.GUI
{
    public partial class KhoiPhucNhanVien : Form
    {
        NhanVienBLL nvBLL = new NhanVienBLL();
        public KhoiPhucNhanVien()
        {
            InitializeComponent();
        }

        private void KhoiPhucNhanVien_Load(object sender, EventArgs e)
        {
            DataTable dt = nvBLL.GetDeletedNhanVien();
            grid_NV.DataSource = dt;
        }

        private void textBox_TimNV_TextChanged(object sender, EventArgs e)
        {
            grid_NV.DataSource = nvBLL.GetDeletedNhanVienByKey(textBox_TimNV.Text);
        }

        private void btn_Reload_Click(object sender, EventArgs e)
        {
            grid_NV.DataSource = nvBLL.GetDeletedNhanVien();
        }

        private void btn_KhoiPhuc_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn khôi phục nhân viên này?", "Thông báo", MessageBoxButtons.YesNo);
            if(result == DialogResult.Yes)
            {
                nvBLL.Restore(grid_NV.SelectedRows[0].Cells[0].Value.ToString());
                grid_NV.DataSource = nvBLL.GetDeletedNhanVien();
            }
            else
            {
                return;
            }
        }
    }
}
