using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanQuanAo
{
    public partial class FrmGiaoDienQuanLy :DevComponents.DotNetBar.Office2007RibbonForm
    {
        public FrmGiaoDienQuanLy()
        {
            InitializeComponent();
        }

        private void FrmGiaoDienQuanLy_Load(object sender, EventArgs e)
        {

        }

        private void buttonItem3_Click(object sender, EventArgs e)
        {
            FrmLienHe lh = new FrmLienHe();
            lh.Show();
        }

        private void buttonItem4_Click(object sender, EventArgs e)
        {
            FrmThongTin tt = new FrmThongTin();
            tt.Show();
        }

        private void buttonItem5_Click(object sender, EventArgs e)
        {
            FrmDangNhapQuanLy ql = new FrmDangNhapQuanLy();
            ql.Show();
        }

        private void buttonItem6_Click(object sender, EventArgs e)
        {
            FrmGiaoDien gd = new FrmGiaoDien();
            this.Hide();
            gd.Show();
        }

        private void buttonItem7_Click(object sender, EventArgs e)
        {
            FrmChatLieu cl = new FrmChatLieu();
            cl.Show();
        }

        private void btnPhanLoai_Click(object sender, EventArgs e)
        {
            FrmPhanLoai pl = new FrmPhanLoai();
            pl.Show();
        }

        private void btnThuongHieu_Click(object sender, EventArgs e)
        {
            FrmThuongHieu th = new FrmThuongHieu();
            th.Show();
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            FrmNhanVien nv = new FrmNhanVien();
            nv.Show();
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            FrmKhachHang kh = new FrmKhachHang();
            kh.Show();
        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {
            FrmSanPham sp = new FrmSanPham();
            sp.Show();
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            FrmHoaDon hd = new FrmHoaDon();
            hd.Show();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            FrmTimKiem tk = new FrmTimKiem();
            tk.Show();
        }

        private void btnDanhSach_Click(object sender, EventArgs e)
        {
            FrmDanhSach ds = new FrmDanhSach();
            ds.Show();
        }
    }
}
