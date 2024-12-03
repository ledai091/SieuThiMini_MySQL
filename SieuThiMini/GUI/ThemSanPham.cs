using SieuThiMini.BLL;
using SieuThiMini.DAL;
using SieuThiMini.DTO;
using System;
using System.Data;
using System.Windows.Forms;

namespace SieuThiMini.GUI
{
    public partial class ThemSanPham : Form
    {
        private DataProvider dp = new DataProvider();
        private DataTable dt;
        public ThemSanPham()
        {
            InitializeComponent();
            dt = dp.ExecuteQuery("SELECT ma_loai FROM 'loai_san_pham' ORDER BY 'ma_loai' ASC");
            cb_MaLoai.ValueMember = "ma_loai";
            cb_MaLoai.DataSource = dt;
        }

        private void btn_ThemSanPham_Click(object sender, EventArgs e)
        {
            int maLoai;
            int maSP = 0;
            string tenSP = textBox_TenSanPham.Text;
            int soLuong = 1;
            int gia;
            int gianhap;
            if (textBox_Gia.Text != "" && textBox_GiaNhap.Text != "" && cb_MaLoai.Text != "")
            {
                gia = int.Parse(textBox_Gia.Text);
                gianhap = int.Parse(textBox_GiaNhap.Text);
                maLoai = int.Parse(cb_MaLoai.Text);
            }
            else
            {
                gia = 0;
                gianhap = 0;
                maLoai = 0;
            }
            if (tenSP != "" && gia > 0 && maLoai > 0 && gianhap > 0)
            {
                SanPhamDTO spDTO = new SanPhamDTO(maSP, tenSP, soLuong, gia, gianhap, maLoai, "1");
                SanPhamBLL spBLL = new SanPhamBLL();
                spBLL.Insert(spDTO);
                this.Close();
                MessageBox.Show("Thêm sản phẩm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
