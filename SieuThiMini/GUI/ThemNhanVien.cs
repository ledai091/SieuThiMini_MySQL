using SieuThiMini.DAL;
using SieuThiMini.BLL;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using SieuThiMini.DTO;

namespace SieuThiMini.GUI
{
    public partial class ThemNhanVien : Form
    {
        DataProvider dp = new DataProvider();
        DataTable dt = new DataTable();
        public ThemNhanVien()
        {
            InitializeComponent();
        }

        private void ThemNhanVien_Load(object sender, EventArgs e)
        {
            dt = dp.ExecuteQuery("SELECT ma_tai_khoan FROM tai_khoan WHERE trang_thai = '1'");
            cb_TK.DisplayMember = "ma_tai_khoan";
            cb_TK.DataSource = dt;
        }
        public bool IsNumeric(string value)
        {
            return value.All(char.IsNumber);
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            int maNV = 0;
            string tenNV = textBox_TenNV.Text;
            DateTime birth = DateTime.Parse(dateTimePicker_Birth.Text);
            string sdt = textBox_SDT.Text;
            string mail = textBox_Email.Text;
            int maTK = int.Parse(cb_TK.Text);
            if(tenNV == "" || sdt == "" || mail == "" || maTK == null)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!IsNumeric(sdt))
            {
                MessageBox.Show("Số điện thoại không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                NhanVienBLL nvBLL = new NhanVienBLL();
                NhanVienDTO nv = new NhanVienDTO(maNV, tenNV, birth, sdt, mail, maTK);

                if (nvBLL.Insert(nv) == 1)
                {
                    MessageBox.Show("Thêm nhân viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Thêm nhân viên thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
