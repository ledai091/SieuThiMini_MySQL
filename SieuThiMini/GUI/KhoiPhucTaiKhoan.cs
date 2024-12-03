using SieuThiMini.BLL;
using System;
using System.Data;
using System.Windows.Forms;

namespace SieuThiMini.GUI
{
    public partial class KhoiPhucTaiKhoan : Form
    {
        TaiKhoanBLL tkBLL = new TaiKhoanBLL();
        public KhoiPhucTaiKhoan()
        {
            InitializeComponent();
        }

        private void KhoiPhucTaiKhoan_Load(object sender, EventArgs e)
        {
            DataTable dt = tkBLL.SelectAllDeleted();
            grid_TK.DataSource = dt;
        }

        private void btn_KhoiPhuc_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Khôi phục tài khoản này?", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                tkBLL.Restore(int.Parse(grid_TK.SelectedRows[0].Cells[0].Value.ToString()));
                grid_TK.DataSource = tkBLL.SelectAllDeleted();
            }
            else
            {
                return;
            }
        }
        private void btn_Reload_Click(object sender, EventArgs e)
        {
            grid_TK.DataSource = tkBLL.SelectAllDeleted();
        }
        private void textBox_TimTK_TextChanged(object sender, EventArgs e)
        {
            grid_TK.DataSource = tkBLL.TimkiemDeleted(textBox_TimTK.Text);
        }
    }
}
