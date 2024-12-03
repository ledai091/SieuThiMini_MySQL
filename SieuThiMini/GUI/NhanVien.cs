using System;
using System.Data;
using System.Windows.Forms;
using SieuThiMini.BLL;
using SieuThiMini.DAL;
using SieuThiMini.DTO;
namespace SieuThiMini.GUI
{
    public partial class NhanVien : Form
    {
        DataProvider dp = new DataProvider();
        DataTable dt;
        NhanVienBLL nvBLL = new NhanVienBLL();
        public NhanVien()
        {
            InitializeComponent();
        }
        private void cb_TK_Load()
        {
            dt = dp.ExecuteQuery("SELECT ma_tai_khoan FROM tai_khoan WHERE trang_thai = '1'");
            cb_TK.DisplayMember = "ma_tai_khoan";
            cb_TK.DataSource = dt;
        }

        private void NhanVien_Load(object sender, EventArgs e)
        {
            cb_TK_Load();
            grid_NV.DataSource = nvBLL.GetNhanVien();
            grid_NV.Columns["ma_nhan_vien"].HeaderText = "Mã nhân viên";
            grid_NV.Columns["ten_nhan_vien"].HeaderText = "Tên nhân viên";
            grid_NV.Columns["ngay_sinh"].HeaderText = "Ngày sinh";
            grid_NV.Columns["sdt"].HeaderText = "Số điện thoại";
            grid_NV.Columns["mail"].HeaderText = "Email";
            grid_NV.Columns["tai_khoan"].HeaderText = "Mã tài khoản";

            grid_NV.Columns["ma_nhan_vien"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grid_NV.Columns["ten_nhan_vien"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grid_NV.Columns["ngay_sinh"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grid_NV.Columns["sdt"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grid_NV.Columns["mail"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grid_NV.Columns["tai_khoan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            grid_NV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grid_NV.Columns["ma_nhan_vien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grid_NV.Columns["ten_nhan_vien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grid_NV.Columns["ngay_sinh"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grid_NV.Columns["sdt"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grid_NV.Columns["mail"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grid_NV.Columns["tai_khoan"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            var datGridViewArgs = new DataGridViewCellEventArgs(0, 0);
            grid_NV_CellClick(sender, datGridViewArgs);
        }

        private void grid_NV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox_MaNV.Enabled = false;
            textBox_TenNV.Enabled = false;
            dateTimePicker_Birth.Enabled = false;
            textBox_SDT.Enabled = false;
            textBox_Email.Enabled = false;
            cb_TK.Enabled = false;
            btn_Huy.Visible = false;
            btn_Save.Visible = false;

            DataGridViewRow row = new DataGridViewRow();
            if (e.RowIndex == -1) return;
            row = grid_NV.Rows[e.RowIndex];
            textBox_MaNV.Text = Convert.ToString(row.Cells["ma_nhan_vien"].Value);
            textBox_TenNV.Text = Convert.ToString(row.Cells["ten_nhan_vien"].Value);
            dateTimePicker_Birth.Text = Convert.ToString(row.Cells["ngay_sinh"].Value);
            textBox_SDT.Text = Convert.ToString(row.Cells["sdt"].Value);
            textBox_Email.Text = Convert.ToString(row.Cells["mail"].Value);
            cb_TK.Text = Convert.ToString(row.Cells["tai_khoan"].Value);
        }

        private void btn_Reload_Click(object sender, EventArgs e)
        {
            cb_TK_Load();
            grid_NV.DataSource = nvBLL.GetNhanVien();
        }

        private void btn_ThemNV_Click(object sender, EventArgs e)
        {
            ThemNhanVien themNV = new ThemNhanVien();
            themNV.ShowDialog();
        }

        private void btn_SuaNV_Click(object sender, EventArgs e)
        {
            if (textBox_MaNV.Text == "")
            {
                MessageBox.Show("Chọn nhân viên cần sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                textBox_TenNV.Enabled = true;
                dateTimePicker_Birth.Enabled = true;
                textBox_SDT.Enabled = true;
                textBox_Email.Enabled = true;
                cb_TK.Enabled = true;
                btn_Huy.Visible = true;
                btn_Save.Visible = true;
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            string maNV = textBox_MaNV.Text;
            string tenNV = textBox_TenNV.Text;
            DateTime birth = DateTime.Parse(dateTimePicker_Birth.Text);
            string sdt = textBox_SDT.Text;
            string email = textBox_Email.Text;
            string maTK = cb_TK.Text;

            if (maNV != "" && tenNV != "" && Convert.ToString(birth) != "" && sdt != "" && email != "")
            {
                NhanVienDTO nv = new NhanVienDTO(int.Parse(maNV), tenNV, birth, sdt, email, int.Parse(maTK));
                NhanVienBLL nvBLL = new NhanVienBLL();
                nvBLL.Update(nv);
                cb_TK_Load();

                textBox_TenNV.Enabled = false;
                cb_TK.Enabled = false;
                dateTimePicker_Birth.Enabled = false;
                textBox_SDT.Enabled = false;
                textBox_Email.Enabled = false;
                btn_Huy.Visible = false;
                btn_Save.Visible = false;
                MessageBox.Show("Sửa thông tin nhân viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Thông tin không hợp lệ hãy kiểm tra lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            textBox_TenNV.Enabled = false;
            cb_TK.Enabled = false;
            dateTimePicker_Birth.Enabled = false;
            textBox_SDT.Enabled = false;
            textBox_Email.Enabled = false;
            btn_Huy.Visible = false;
            btn_Save.Visible = false;
        }

        private void btn_XoaNV_Click(object sender, EventArgs e)
        {
            string maNV = textBox_MaNV.Text;
            NhanVienBLL nvBLL = new NhanVienBLL();
            if(cb_TK.Text == "0")
            {
                nvBLL.Delete(maNV);
                MessageBox.Show("Xóa nhân viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Nhân viên đang còn tài khoản sử dụng, hãy chuyển sang tài khoản mã = 0 nếu muốn xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_KhoiPhuc_Click(object sender, EventArgs e)
        {
            KhoiPhucNhanVien kp = new KhoiPhucNhanVien();
            kp.ShowDialog();
        }

        private void TimKiem(object sender, EventArgs e)
        {
            string input = textBox_TimNV.Text.ToString();
            grid_NV.DataSource = nvBLL.TimKiem(input);
        }

        private void grid_NV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
