using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyBanQuanAo.Model;
namespace QuanLyBanQuanAo
{
    public partial class FrmDanhSach : Form
    {

        BanQuanAoModel db = new BanQuanAoModel();
        public FrmDanhSach()
        {
            InitializeComponent();
        }

        private void FrmDanhSach_Load(object sender, EventArgs e)
        {
            HienThiDSNV();
        }
        public dynamic LayDSNV()
        {
            var nv = db.tblNhanViens.Select(b => new
            {
                b.MaNhanVien,
                b.TenNhanVien,
                b.SoDienThoai,
                b.NgaySinh,
                b.GioiTinh,
                b.DiaChi
            }).ToList();
            return nv;
        }
        public void LayDSNV(DataGridView dgv)
        {
            dgv.DataSource = LayDSNV();
        }
        public void HienThiDSNV()
        {
            dgvDanhSach.DataSource = null;
            LayDSNV(dgvDanhSach);
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            HienThiDSNV();
        }
        public dynamic LayDSHD()
        {
            var hd = db.tblHoaDons.Select(h => new
            {
                h.MaHoaDon,
                h.MaKhachHang,
                h.MaNhanVien,
                h.NgayBan,
                h.TongTien
            }).ToList();
            return hd;
        }
        public void LayDSHD(DataGridView dgv)
        {
            dgv.DataSource = LayDSHD();
        }
        public void HienThiDSHD()
        {
            dgvDanhSach.DataSource = null;
            LayDSHD(dgvDanhSach);
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            HienThiDSHD();
        }
        public dynamic LayDSKH()
        {
            var kh = db.tblKhachHangs.Select(k => new
            {
                k.MaKhachHang,
                k.TenKhachHang,
                k.DiaChi,
                k.SoDienThoai,
                k.NgayDatHang
            }).ToList();
            return kh;
        }
        public void LayDSKH(DataGridView dgv)
        {
            dgv.DataSource = LayDSKH();
        }
        public void HienThiDSKH()
        {
            dgvDanhSach.DataSource = null;
            LayDSKH(dgvDanhSach);
        }
        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            HienThiDSKH();
        }
        public dynamic LayDSSP()
        {
            var sp = db.tblSanPhams.Select(s => new
            {
                s.MaSanPham,
                s.TenSanPham,
                s.MaPhanLoai,
                s.MaChatLieu,
                s.MaThuongHieu,
                s.KichCo,
                s.SoLuong,
                s.NgayNhap,
                s.DonGiaNhap,
                s.DonGiaBan,
                s.GhiChu,
                s.Anh
            }).ToList();
            return sp;
        }
        public void LayDSSP(DataGridView dgv)
        {
            dgv.DataSource = LayDSSP();
        }
        public void HienThi()
        {
            dgvDanhSach.DataSource = null;
            LayDSSP(dgvDanhSach);
        }
        private void btnSanPham_Click(object sender, EventArgs e)
        {
            HienThi();
        }
        public dynamic LayDSCTHD()
        {
            var hd = db.tblCTHDs.Select(c => new
            {
                c.MaHoaDon,
                c.MaSanPham,
                c.SoLuong,
                c.DonGia,
                c.GiamGia,
                c.ThanhTien

            }).ToList();
            return hd;
        }
        public void LayDSCTHD(DataGridView dgv)
        {
            dgv.DataSource = LayDSCTHD();
        }
        public void HienThiDSCTHD()
        {
            dgvDanhSach.DataSource = null;
            LayDSCTHD(dgvDanhSach);
        }
        private void btnChiTietHoaDon_Click(object sender, EventArgs e)
        {
            HienThiDSCTHD();
        }
    }
}
