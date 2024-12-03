using System;
using System.Windows.Forms;
using System.Drawing;
using SieuThiMini.BLL;
using SieuThiMini.DTO;

namespace SieuThiMini.GUI
{
    public partial class QuanLy : Form
    {
        private int maNV;
        private NhanVienBLL nvBLL = new NhanVienBLL();
        private NhanVienDTO nvDTO;
        private TaiKhoanBLL tkBLL = new TaiKhoanBLL();
        private TaiKhoanDTO tkDTO;

        // Add fields to track the currently selected button
        private Button currentSelectedButton;
        private Color selectedButtonColor = Color.FromArgb(78, 115, 223); // A blue color for selection
        private Color defaultButtonColor = Color.FromArgb(240, 255, 255); // Default dark background color

        public QuanLy(int maNV)
        {
            InitializeComponent();
            this.maNV = maNV;
            this.nvDTO = nvBLL.GetNVByMaNV(maNV.ToString());
            this.tkDTO = tkBLL.GetTKByMaTK(nvDTO.ma_nhan_vien.ToString());
        }

        private Form currentChildForm;
        private void openChildForm(Form childForm)
        {
            if (currentChildForm != null) { currentChildForm.Close(); }
            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel_Body.Controls.Add(childForm);
            panel_Body.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        // New method to handle button selection visual effect
        private void SelectButton(Button button)
        {
            // Reset previous button's color
            if (currentSelectedButton != null)
            {
                currentSelectedButton.BackColor = defaultButtonColor;
            }

            // Highlight the new button
            button.BackColor = selectedButtonColor;
            currentSelectedButton = button;
        }

        private void QuanLy_Load(object sender, EventArgs e)
        {
            label_HoTenNV.Text = nvDTO.ten_nhan_vien;
            if (tkDTO.phan_quyen == 1)
            {
                panel_TaiKhoan.Visible = false;
                panel_NhanVien.Visible = false;
            }
        }

        private void btn_DangXuat_Click(object sender, EventArgs e)
        {
            this.Hide();
            var formLogin = new LoginGUI();
            formLogin.Closed += (s, args) => this.Close();
            formLogin.Show();
        }

        private void btn_HoaDon_Click(object sender, EventArgs e)
        {
            openChildForm(new HoaDon());
            SelectButton(btn_HoaDon);
        }

        private void btn_SanPham_Click(object sender, EventArgs e)
        {
            openChildForm(new SanPham());
            SelectButton(btn_SanPham);
        }

        private void btn_ThongKe_Click(object sender, EventArgs e)
        {
            openChildForm(new ThongKe());
            SelectButton(btn_ThongKe);
        }

        private void btn_LoaiSanPham_Click(object sender, EventArgs e)
        {
            openChildForm(new LoaiSanPham());
            SelectButton(btn_LoaiSanPham);
        }

        private void btn_TaiKhoan_Click(object sender, EventArgs e)
        {
            openChildForm(new TaiKhoan());
            SelectButton(btn_TaiKhoan);
        }

        private void btn_NhanVien_Click(object sender, EventArgs e)
        {
            openChildForm(new NhanVien());
            SelectButton(btn_NhanVien);
        }

        private void btn_DonNhapHang_Click(object sender, EventArgs e)
        {
            openChildForm(new DonNhapHang());
            SelectButton(btn_DonNhapHang);
        }

        private void btn_NhaCungCap_Click(object sender, EventArgs e)
        {
            openChildForm(new NhaCungCap());
            SelectButton(btn_NhaCungCap);
        }
    }
}