using System;
using System.Windows.Forms;
using SieuThiMini.BLL;
using SieuThiMini.DTO;
namespace SieuThiMini.GUI
{
    public partial class ThemNhaCungCap : Form
    {
        public ThemNhaCungCap()
        {
            InitializeComponent();
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_ThemNCC_Click(object sender, EventArgs e)
        {
            string ten_ncc = textBox_NCC.Text;
            string dia_chi = textBox_DiaChi.Text;
            int ma_ncc = 0;
            string trang_thai = "1";
            if (ten_ncc != "" && dia_chi != "")
            {
                NhaCungCapDTO ncc = new NhaCungCapDTO(ma_ncc, ten_ncc, dia_chi, trang_thai);
                NhaCungCapBLL nccBLL = new NhaCungCapBLL();
                nccBLL.Insert(ncc);
                MessageBox.Show("Thêm nhà cung cấp thành công");
                this.Close();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
            }
        }
    }
}
