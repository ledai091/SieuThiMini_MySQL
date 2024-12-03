using SieuThiMini.BLL;
using SieuThiMini.DAL;
using SieuThiMini.DTO;
using System;
using System.Data;
using System.Windows.Forms;

namespace SieuThiMini.GUI
{
    public partial class ThemLoaiSanPham : Form
    {
        private DataProvider dp = new DataProvider();
        private DataTable dt;
        public ThemLoaiSanPham()
        {
            InitializeComponent();
            dt = dp.ExecuteQuery("SELECT ma_ncc FROM nha_cung_cap ORDER BY ma_ncc ASC");
            cb_MaNCC.ValueMember = "ma_ncc";
            cb_MaNCC.DataSource = dt;
        }

        private void ThemLoaiSanPham_Load(object sender, EventArgs e)
        {

        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_ThemLoaiSanPham_Click(object sender, EventArgs e)
        {
            int mancc;
            if (cb_MaNCC.Text != "")
            {
                mancc = int.Parse(cb_MaNCC.Text);
            }
            else
            {
                mancc = 0;
            }
            string tenLoai = textBox_TenLoaiSanPham.Text;
            int maLoai = 0;
            if (tenLoai != "" && mancc > 0)
            {
                LoaiSanPhamDTO lsp = new LoaiSanPhamDTO(maLoai, tenLoai, mancc, "1");
                LoaiSanPhamBLL bll = new LoaiSanPhamBLL();
                bll.Insert(lsp);
                this.Close();
                MessageBox.Show("Thêm loại sản phẩm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Các hạn chế gồm:\n \n1. Không được bỏ trống bất cứ ô nào", "Thông tin không hợp lệ! Hãy kiểm tra lại", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
