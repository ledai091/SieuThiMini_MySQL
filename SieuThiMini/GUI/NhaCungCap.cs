using SieuThiMini.BLL;
using SieuThiMini.DAL;
using SieuThiMini.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SieuThiMini.GUI
{
    public partial class NhaCungCap : Form
    {
        DataTable dt;
        DataProvider dp = new DataProvider();
        NhaCungCapBLL bll = new NhaCungCapBLL();
        public NhaCungCap()
        {
            InitializeComponent();
        }

        private void NhaCungCap_Load(object sender, EventArgs e)
        {
            List<NhaCungCapDTO> nhaCungCapDTOs = bll.SelectAll();

            grid_NCC.DataSource = nhaCungCapDTOs;

            grid_NCC.Columns["ma_ncc"].HeaderText = "Mã nhà cung cấp";
            grid_NCC.Columns["ten_ncc"].HeaderText = "Tên nhà cung cấp";
            grid_NCC.Columns["dia_chi"].HeaderText = "Địa chỉ";
            grid_NCC.Columns["trang_thai"].Visible = false;

            grid_NCC.Columns["ma_ncc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grid_NCC.Columns["ten_ncc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grid_NCC.Columns["dia_chi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            var dataGridViewArgs = new DataGridViewCellEventArgs(0, 0);
            grid_NCC_CellClick(null, dataGridViewArgs);
        }

        private void grid_NCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox_MaNCC.Enabled = false;
            textBox_NCC.Enabled = false;
            textBox_DiaChi.Enabled = false;
            btn_Huy.Visible = false;
            btn_Save.Visible = false;

            if (e.RowIndex == -1) return;
            DataGridViewRow row = new DataGridViewRow();
            row = grid_NCC.Rows[e.RowIndex];
            textBox_MaNCC.Text = Convert.ToString(row.Cells["ma_ncc"].Value);
            textBox_NCC.Text = Convert.ToString(row.Cells["ten_ncc"].Value);
            textBox_DiaChi.Text = Convert.ToString(row.Cells["dia_chi"].Value);
        }

        private void btn_ThemNCC_Click(object sender, EventArgs e)
        {
            ThemNhaCungCap them = new ThemNhaCungCap();
            them.ShowDialog();
        }

        private void btn_SuaNCC_Click(object sender, EventArgs e)
        {
            if(textBox_MaNCC.Text == "")
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp cần sửa");
            }
            else
            {
                textBox_NCC.Enabled = true;
                textBox_DiaChi.Enabled = true;
                btn_Huy.Visible = true;
                btn_Save.Visible = true;
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            int mancc = int.Parse(textBox_MaNCC.Text);
            string tenncc = textBox_NCC.Text;
            string diachi = textBox_DiaChi.Text;
            string trangthai = "1";
            if (tenncc != "" && diachi != "")
            {
                NhaCungCapDTO ncc = new NhaCungCapDTO(mancc, tenncc, diachi, trangthai);
                bll.Update(ncc);
                textBox_NCC.Enabled = false;
                textBox_DiaChi.Enabled = false;
                btn_Huy.Visible = false;
                btn_Save.Visible = false;
                MessageBox.Show("Sửa thành công");
                List<NhaCungCapDTO> nhaCungCapDTOs = bll.SelectAll();
                grid_NCC.DataSource = nhaCungCapDTOs;
            }
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            textBox_MaNCC.Enabled = false;
            textBox_NCC.Enabled = false;
            textBox_DiaChi.Enabled = false;
            btn_Huy.Visible = false;
            btn_Save.Visible = false;
        }

        private void textBox_TimNCC_TextChanged(object sender, EventArgs e)
        {
            string search = textBox_TimNCC.Text;
            if (string.IsNullOrEmpty(search))
            {
                List<NhaCungCapDTO> nhaCungCapDTOs = bll.SelectAll();
                grid_NCC.DataSource = nhaCungCapDTOs;
            }
            else
            {
                NhaCungCapBLL bll = new NhaCungCapBLL();
                List<NhaCungCapDTO> nhaCungCapDTOs = bll.SelectAll();
                var filterdRows = nhaCungCapDTOs.AsEnumerable()
                    .Where(row => row.ma_ncc.ToString().ToLower().Contains(search)
                    || row.ten_ncc.ToString().ToLower().Contains(search)).ToList();
                grid_NCC.DataSource = filterdRows;
            }
            
        }

        private void btn_Reload_Click(object sender, EventArgs e)
        {
            NhaCungCapBLL bll = new NhaCungCapBLL();
            List<NhaCungCapDTO> nhaCungCapDTOs = bll.SelectAll();
            grid_NCC.DataSource = nhaCungCapDTOs;
        }

        private void btn_XoaNCC_Click(object sender, EventArgs e)
        {
            if(textBox_MaNCC.Text != "")
            {
                int mancc = Convert.ToInt32(textBox_MaNCC.Text.ToString());
                LoaiSanPhamBLL loaiSanPhamBLL = new LoaiSanPhamBLL();
                List<LoaiSanPhamDTO> list = loaiSanPhamBLL.GetLSPByNCC(mancc);

                if(list.Count >0)
                {
                    MessageBox.Show("Không thể xóa nhà cung cấp này vì có loại sản phẩm liên quan");
                }
                else
                {
                    bll.Delete(mancc);
                    MessageBox.Show("Xóa thành công");
                    btn_Reload_Click(null, null);
                    var dataGridViewArgs = new DataGridViewCellEventArgs(0, 0);
                    grid_NCC_CellClick(null, dataGridViewArgs);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp cần xóa");
            }
        }

        private void btn_KhoiPhuc_Click(object sender, EventArgs e)
        {
            KhoiPhucNCC khoiPhucNCC = new KhoiPhucNCC();
            khoiPhucNCC.ShowDialog();
        }
    }
}
