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
    public partial class FrmGiaoDienNhanVien :DevComponents.DotNetBar.Office2007RibbonForm
    {
        public FrmGiaoDienNhanVien()
        {
            InitializeComponent();
        }

        private void FrmGiaoDienNhanVien_Load(object sender, EventArgs e)
        {
           
        }

        private void btnLienHe_Click(object sender, EventArgs e)
        {
            FrmLienHe lh = new FrmLienHe();
            lh.Show();
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            FrmDangNhapNhanVien nv = new FrmDangNhapNhanVien();
            this.Hide();
            nv.Show();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            FrmGiaoDien FF = new FrmGiaoDien();
            FF.Show();
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            FrmKhachHang kh = new FrmKhachHang();
            kh.Show();
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
