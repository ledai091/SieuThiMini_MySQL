using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using SieuThiMini.BLL;
using SieuThiMini.DAL;
using SieuThiMini.DTO;

namespace SieuThiMini.GUI
{
    public partial class LoginGUI : Form
    {
        private TaiKhoanBLL tkBLL = new TaiKhoanBLL();
        private TaiKhoanDTO tkDTO;

        public LoginGUI()
        {
            InitializeComponent();
        }

        private void LoginGUI_Load(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
        }
        private void btnSignIn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }
            try
            {
                tkDTO = tkBLL.SignIn(txtUsername.Text, txtPassword.Text);
            }
            catch
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }
           
            MessageBox.Show("Đăng nhập thành công.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (tkDTO.phan_quyen == 2)
            {
                this.Hide();
                NhanVienBLL nvBLL = new NhanVienBLL();
               
                List<NhanVienDTO> nvDTOList = nvBLL.GetNVByMaTK(tkDTO.ma_tai_khoan);
                if (nvDTOList.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy thông tin nhân viên cho tài khoản này.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                NhanVienDTO nvDTO = nvDTOList[0];
                var formBH = new BanHang(nvDTO.ma_nhan_vien);
                formBH.FormClosed += (s, args) => this.Close();
                formBH.Show();
            }
            // admin & quản lý
            else
            {
                this.Hide();
                NhanVienBLL nvBLL = new NhanVienBLL();
                List<NhanVienDTO> nvDTOlist = nvBLL.GetNVByMaTK(tkDTO.ma_tai_khoan);
                NhanVienDTO nvDTO = nvDTOlist[0];
                var formQL = new QuanLy(nvDTO.ma_nhan_vien);
                formQL.FormClosed += (s, args) => this.Close();
                formQL.Show();
            }
            return;
        }
    }
}
