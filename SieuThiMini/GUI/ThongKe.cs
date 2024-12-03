using System;
using System.Data;
using System.Windows.Forms;
using SieuThiMini.BLL;
namespace SieuThiMini.GUI
{
    public partial class ThongKe : Form
    {
        public ThongKe()
        {
            InitializeComponent();
            ThongKeBLL tkBLL = new ThongKeBLL();
            TongSP.Text = tkBLL.TongSoSanPham().ToString();
            SoNhaCC.Text = tkBLL.SoLuongNCC().ToString();
            TongNV.Text = tkBLL.SoLuongNV().ToString();
            SoTaiKhoan.Text = tkBLL.SoTaiKhoan().ToString();
            textBox_Year.Text = DateTime.Now.Year.ToString();
            // In the constructor, after InitializeComponent();
            comboBox1.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" });
            comboBox1.SelectedIndex = 0; // Select "0" by default
        }

        private void ThongKe_Load(object sender, EventArgs e)
        {

        }

        private void btn_XacNhan_Click(object sender, EventArgs e)
        {
            ThongKeBLL thongKeBLL = new ThongKeBLL();
            int namhientai = DateTime.Now.Year;
            int selectedMonth;
            int selectedYear;
            DataTable result;

            // Validate year input
            if (string.IsNullOrEmpty(textBox_Year.Text.Trim()))
            {
                textBox_Year.Text = namhientai.ToString();
                selectedYear = namhientai;
            }
            else if (!int.TryParse(textBox_Year.Text.Trim(), out selectedYear) || selectedYear <= 2000 || selectedYear > namhientai)
            {
                if (!int.TryParse(textBox_Year.Text.Trim(), out selectedYear))
                {
                    MessageBox.Show("Vui lòng nhập năm là một số.");
                    return;
                }
                else if (selectedYear <= 2000)
                {
                    MessageBox.Show("Vui lòng nhập năm là một số lớn hơn 2000.");
                    textBox_Year.Text = namhientai.ToString();
                    return;
                }
                else if (selectedYear > namhientai)
                {
                    MessageBox.Show("Không thể thống kê vì năm lớn hơn năm hiện tại.");
                    textBox_Year.Text = namhientai.ToString();
                    return;
                }
            }

            // Safely handle comboBox1 selection
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn tháng từ danh sách.");
                return;
            }

            string selectedValue = comboBox1.SelectedItem.ToString().Trim();

            if (selectedValue.Equals("0"))
            {
                // Year statistics
                So_Von.Text = thongKeBLL.TongChiPhiNhapHangTheoNam(selectedYear).ToString() + " đồng";
                So_DoanhThu.Text = thongKeBLL.TongDoanhThuTheoNam(selectedYear).ToString() + " đồng";

                lbl_TKDonNhapHang.Text = thongKeBLL.TongDonNHTheoNam(selectedYear).ToString();
                lb_Sodonnhaphang.Text = thongKeBLL.TongHoaDonTheoNam(selectedYear).ToString();

                result = thongKeBLL.TimMaNVCoTongTienLonNhatTheoNam(selectedYear);
            }
            else
            {
                // Month statistics
                if (!int.TryParse(selectedValue, out selectedMonth))
                {
                    MessageBox.Show("Giá trị tháng không hợp lệ.");
                    return;
                }

                So_Von.Text = thongKeBLL.TongChiPhiNhapHangTheoThang(Convert.ToInt32(selectedMonth), Convert.ToInt32(selectedYear)).ToString() + " đồng";
                So_DoanhThu.Text = thongKeBLL.TongDoanhThuTheoThang(selectedMonth, selectedYear).ToString() + " đồng";

                lbl_TKDonNhapHang.Text = thongKeBLL.TongDonNHTheoThang(selectedMonth, selectedYear).ToString();
                lb_Sodonnhaphang.Text = thongKeBLL.TongHoaDonTheoThang(selectedMonth, selectedYear).ToString();

                result = thongKeBLL.TimMaNVCoTongTienLonNhatTheoThang(selectedMonth, selectedYear);
            }

            // Update employee information
            if (result != null && result.Rows.Count > 0)
            {
                DataRow row = result.Rows[0];
                string maNhanVien = row["ma_nhan_vien"].ToString();
                string tenNhanVien = row["ten_nhan_vien"].ToString();
                string tongTienLonNhat = row["TongTienLonNhat"].ToString();

                label_MaNV.Text = maNhanVien;
                label_TenNV.Text = tenNhanVien;
                label_TongTienNV.Text = tongTienLonNhat;
            }
            else
            {
                label_MaNV.Text = "...";
                label_TenNV.Text = "...";
                label_TongTienNV.Text = "...";
            }
        }

    }
}
