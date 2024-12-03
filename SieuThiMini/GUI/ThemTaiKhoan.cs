using SieuThiMini.BLL;
using SieuThiMini.DAL;
using SieuThiMini.DTO;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SieuThiMini.GUI
{
    public partial class ThemTaiKhoan : Form
    {
        private DataProvider dp = new DataProvider();
        private DataTable dt;
        public ThemTaiKhoan()
        {
            InitializeComponent();
        }

        private void ThemTaiKhoan_Load(object sender, EventArgs e)
        {
            dt = dp.ExecuteQuery("SELECT ma_quyen FROM phan_quyen");
            cb_PhanQuyen.DisplayMember = "ma_quyen";
            cb_PhanQuyen.DataSource = dt;
        }
        public bool IsNumeric(string value)
        {
            return value.All(char.IsNumber);
        }

        private void btn_ThemTK_Click(object sender, EventArgs e)
        {
            int matk = 0;
            string tentk = textBox_TenTK.Text;
            string mk = textBox_MK.Text;
            string pq = cb_PhanQuyen.Text;
            if (tentk != "" && mk != "")
            {
                TaiKhoanDTO tk = new TaiKhoanDTO(matk, tentk, mk, int.Parse(pq), 1);
                TaiKhoanBLL bLL = new TaiKhoanBLL();
                bLL.Insert(tk);
                MessageBox.Show("Thêm tài khoản thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_Huy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
