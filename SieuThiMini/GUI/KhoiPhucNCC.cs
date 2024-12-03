﻿using SieuThiMini.BLL;
using SieuThiMini.DTO;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SieuThiMini.GUI
{
    public partial class KhoiPhucNCC : Form
    {
        public KhoiPhucNCC()
        {
            InitializeComponent();
        }

        private void KhoiPhucNCC_Load(object sender, EventArgs e)
        {
            NhaCungCapBLL bll = new NhaCungCapBLL();
            List<NhaCungCapDTO> list = bll.SelectAllDeleted();

            grid_NCC.DataSource = list;

            grid_NCC.Columns["ma_ncc"].HeaderText = "Mã nhà cung cấp";
            grid_NCC.Columns["ten_ncc"].HeaderText = "Tên nhà cung cấp";
            grid_NCC.Columns["dia_chi"].HeaderText = "Địa chỉ";
            grid_NCC.Columns["trang_thai"].HeaderText = "Trạng thái";

            grid_NCC.Columns["ma_ncc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grid_NCC.Columns["ten_ncc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grid_NCC.Columns["dia_chi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grid_NCC.Columns["trang_thai"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void btn_KhoiPhuc_Click(object sender, EventArgs e)
        {
            if (grid_NCC.SelectedRows.Count > 0)
            {
                int selectedRowIndex = grid_NCC.SelectedRows[0].Index;
                DataGridViewRow selectedRow = grid_NCC.Rows[selectedRowIndex];

                int macc = Convert.ToInt32(selectedRow.Cells["ma_ncc"].Value.ToString());
                NhaCungCapBLL bll = new NhaCungCapBLL();
                bll.Restore(macc);
                var dataGridArgs = new DataGridViewCellEventArgs(0, 0);
                btn_Reload_Click(null, dataGridArgs);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp cần khôi phục");
            }
        }

        private void btn_Reload_Click(object sender, EventArgs e)
        {
            NhaCungCapBLL bLL = new NhaCungCapBLL();
            List<NhaCungCapDTO> list = bLL.SelectAllDeleted();
            grid_NCC.DataSource = list;
        }
    }
}
