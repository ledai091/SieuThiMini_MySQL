using SieuThiMini.BLL;
using SieuThiMini.DAL;
using SieuThiMini.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace SieuThiMini.GUI
{
    public partial class TaiKhoan : Form
    {
        private DataProvider dp = new DataProvider();
        private DataTable dt = new DataTable();
        TaiKhoanBLL tkBLL = new TaiKhoanBLL();
        public TaiKhoan()
        {
            InitializeComponent();
        }
        public void cb_PhanQuyen_Load()
        {
            dt = dp.ExecuteQuery("SELECT ma_quyen FROM phan_quyen");
            cb_PhanQuyen.DisplayMember = "ma_quyen";
            cb_PhanQuyen.DataSource = dt;
        }
        public void TaiKhoan_Load(object sender, EventArgs e)
        {
            cb_PhanQuyen_Load();
            List<TaiKhoanDTO> listTK = tkBLL.SelectAll();
            DataTable dt = new DataTable();
            dt.Columns.Add("ma_tai_khoan");
            dt.Columns.Add("ten_tai_khoan");
            dt.Columns.Add("mat_khau");
            dt.Columns.Add("phan_quyen");

            foreach (TaiKhoanDTO tk in listTK)
            {
                dt.Rows.Add(tk.ma_tai_khoan, tk.ten_tai_khoan, tk.mat_khau, tk.phan_quyen);
            }

            grid_TK.DataSource = dt;
            grid_TK.Columns["ma_tai_khoan"].HeaderText = "Mã tài khoản";
            grid_TK.Columns["ten_tai_khoan"].HeaderText = "Tên tài khoản";
            grid_TK.Columns["mat_khau"].HeaderText = "Mật khẩu";
            grid_TK.Columns["phan_quyen"].HeaderText = "Phân quyền";

            grid_TK.Columns["ma_tai_khoan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grid_TK.Columns["ten_tai_khoan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grid_TK.Columns["mat_khau"].AutoSizeMode= DataGridViewAutoSizeColumnMode.Fill;
            grid_TK.Columns["phan_quyen"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            grid_TK.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grid_TK.Columns["ma_tai_khoan"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grid_TK.Columns["mat_khau"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grid_TK.Columns["phan_quyen"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            var datGridViewArgs = new DataGridViewCellEventArgs(0, 0);
            grid_TK_CellContentClick(sender, datGridViewArgs);
        }

        private void grid_TK_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox_MaTK.Enabled = false;
            textBox_MK.Enabled = false;
            textBox_TenTK.Enabled = false;
            btn_Huy.Visible = false;
            btn_Save.Visible = false;
            cb_PhanQuyen.Enabled = false;
            DataGridViewRow row = new DataGridViewRow();
            if (e.RowIndex == -1) return;
            row = grid_TK.Rows[e.RowIndex];
            textBox_MaTK.Text = Convert.ToString(row.Cells["ma_tai_khoan"].Value);
            textBox_TenTK.Text = Convert.ToString(row.Cells["ten_tai_khoan"].Value);
            textBox_MK.Text = Convert.ToString(row.Cells["mat_khau"].Value);
            cb_PhanQuyen.Text = Convert.ToString(row.Cells["phan_quyen"].Value);
        }
        private void grid_TaiKhoan_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (grid_TK.Columns[e.ColumnIndex].Index == 2)
            {
                if (e.Value != null)
                {
                    e.Value = new string('*', e.Value.ToString().Length);
                    e.FormattingApplied = true;
                }
            }
        }
        private void btn_Reload_Click(object sender, EventArgs e)
        {
            cb_PhanQuyen_Load();
            grid_TK.DataSource = tkBLL.SelectAll();
        }

        private void btn_ThemTK_Click(object sender, EventArgs e)
        {
            ThemTaiKhoan themtk = new ThemTaiKhoan();
            themtk.ShowDialog();
        }

        private void btn_SuaTK_Click(object sender, EventArgs e)
        {
            if(textBox_MaTK.Text == "")
            {
                MessageBox.Show("Chọn tài khoản cần sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                textBox_TenTK.Enabled = true;
                textBox_MK.Enabled = true;
                cb_PhanQuyen.Enabled = true;
                btn_Save.Visible = true;
                btn_Huy.Visible = true;
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            string matk = textBox_MaTK.Text;
            string tentk = textBox_TenTK.Text;
            string mk = textBox_MK.Text;
            string phanquyen = cb_PhanQuyen.Text;

            if(matk != "" && tentk != "" && mk != "" && phanquyen != "")
            {
                tkBLL.Update(new TaiKhoanDTO(int.Parse(matk), tentk, mk, int.Parse(phanquyen), 1));
                MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TaiKhoan_Load(null, null);
                textBox_TenTK.Enabled = false;
                textBox_MK.Enabled = false;
                cb_PhanQuyen.Enabled = false;
                btn_Save.Visible = false;
                btn_Huy.Visible = false;
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btn_Huy_Click(object sender, EventArgs e)
        {
            textBox_TenTK.Enabled = false;
            textBox_MK.Enabled = false;
            cb_PhanQuyen.Enabled = false;
            btn_Save.Visible = false;
            btn_Huy.Visible = false;
        }

        private void btn_XoaTK_Click(object sender, EventArgs e)
        {
            string matk = textBox_MaTK.Text;
            NhanVienBLL nvBLL = new NhanVienBLL();
            if (matk != "" && matk !="1" && nvBLL.GetNVByMaTK(Convert.ToInt32(matk)) != null)
            {
                tkBLL.Delete(int.Parse(matk));
                MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TaiKhoan_Load(null, null);
            }
            else
            {
                MessageBox.Show("Không thể xóa tài khoản này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_KhoiPhuc_Click(object sender, EventArgs e)
        {
            KhoiPhucTaiKhoan kp = new KhoiPhucTaiKhoan();
            kp.ShowDialog();
        }

        private void textBox_TimTK_TextChanged(object sender, EventArgs e)
        {
            string input = textBox_TimTK.Text;
            grid_TK.DataSource = tkBLL.Timkiem(input);
        }

        private void grid_TK_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            if (e.RowIndex == -1) return;

            row = grid_TK.Rows[e.RowIndex];
            textBox_MaTK.Text = Convert.ToString(row.Cells["ma_tai_khoan"].Value);
            textBox_TenTK.Text = Convert.ToString(row.Cells["ten_tai_khoan"].Value);
            textBox_MK.Text = Convert.ToString(row.Cells["mat_khau"].Value);
            cb_PhanQuyen.Text = Convert.ToString(row.Cells["phan_quyen"].Value);
        }
    }
}
