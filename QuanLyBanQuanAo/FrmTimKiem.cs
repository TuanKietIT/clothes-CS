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
    public partial class FrmTimKiem : Form
    {
        public FrmTimKiem()
        {
            InitializeComponent();
        }

        private void FrmTimKiem_Load(object sender, EventArgs e)
        {

        }

        private void btnTimKiemHD_Click(object sender, EventArgs e)
        {
            using (BanQuanAoModel db = new BanQuanAoModel())
            {
                var HD = db.tblHoaDons.Where(hd => hd.MaHoaDon.Equals(txtTimKiem.Text)).FirstOrDefault();
                if (HD != null)
                {
                    dgvTimKiem.DataSource = db.tblHoaDons.Where(h => h.MaHoaDon.Contains(txtTimKiem.Text))
                    .Select(h => new
                    {
                        h.MaHoaDon,
                        h.MaKhachHang,
                        h.MaNhanVien,
                        h.NgayBan,
                        h.TongTien
                    }).ToList();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy kết quả!!", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                }

            }

        }

        private void btnTimKiemNV_Click(object sender, EventArgs e)
        {
            using (BanQuanAoModel db = new BanQuanAoModel())
            {
                var NV = db.tblNhanViens.Where(nv => nv.MaNhanVien.Equals(txtTimKiem.Text)).FirstOrDefault();
                var TNV = db.tblNhanViens.Where(nv => nv.TenNhanVien.Equals(txtTimKiem.Text)).FirstOrDefault();
                if (NV != null)
                {
                    dgvTimKiem.DataSource = db.tblNhanViens.Where(nv => nv.TenNhanVien.Contains(txtTimKiem.Text))
                   .Select(nv => new
                   {
                       nv.MaNhanVien,
                       nv.TenNhanVien,
                       nv.SoDienThoai,
                       nv.NgaySinh,
                       nv.GioiTinh,
                       nv.DiaChi
                   }).ToList();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy kết quả!!", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                }

            }
        }

        private void btnTimKiemSP_Click(object sender, EventArgs e)
        {
            using (BanQuanAoModel db = new BanQuanAoModel())
            {
                var SP = db.tblSanPhams.Where(kh => kh.MaSanPham.Equals(txtTimKiem.Text)).FirstOrDefault();
                if (SP != null)
                {
                    string keyword = txtTimKiem.Text.Trim();
                    dgvTimKiem.DataSource = db.tblSanPhams.Where(sp => sp.MaSanPham.Contains(keyword))
                    .Select(s => new
                    {
                        s.MaSanPham,
                        s.TenSanPham,
                        s.MaThuongHieu,
                        s.KichCo,
                        s.SoLuong,
                        s.NgayNhap,
                        s.DonGiaNhap,
                        s.DonGiaBan,
                        s.GhiChu,
                        s.Anh
                    }).ToList();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy kết quả!!", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                }

            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            using (BanQuanAoModel db = new BanQuanAoModel())
            {
                var CTHD = db.tblCTHDs.Where(ct => ct.MaHoaDon.Equals(txtTimKiem.Text)).FirstOrDefault();
                if (CTHD != null)
                {
                    string keyword = txtTimKiem.Text.Trim();
                    dgvTimKiem.DataSource = db.tblCTHDs.Where(ct => ct.MaHoaDon.Contains(keyword))
                    .Select(c => new
                    {
                        c.MaHoaDon,
                        c.MaSanPham,
                        c.SoLuong,
                        c.DonGia,
                        c.GiamGia,
                        c.ThanhTien
                    }).ToList();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy kết quả!!", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                }
            }
        }

        private void btnTimKiemKH_Click(object sender, EventArgs e)
        {
            using (BanQuanAoModel db = new BanQuanAoModel())
            {
                var KH = db.tblKhachHangs.Where(kh => kh.MaKhachHang.Equals(txtTimKiem.Text)).FirstOrDefault();
                if (KH != null)
                {
                    dgvTimKiem.DataSource = db.tblKhachHangs.Where(k => k.MaKhachHang.Contains(txtTimKiem.Text))
                    .Select(k => new
                    {
                        k.MaKhachHang,
                        k.TenKhachHang,
                        k.DiaChi,
                        k.SoDienThoai,
                        k.NgayDatHang
                    }).ToList();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy kết quả!!", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                }


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
