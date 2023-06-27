using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyBanQuanAo.Model;
namespace QuanLyBanQuanAo
{
    public partial class FrmSanPham : Form
    {

        BanQuanAoModel db = new BanQuanAoModel();
        tblSanPham sp = new tblSanPham();
        public FrmSanPham()
        {
            InitializeComponent();
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
            //foreach (var item in TK)
            //{
            //    tblDangNhap dn = new tblDangNhap();
            //    dn.TenTaiKhoan = item.TenTaiKhoan;
            //    dn.MatKhau = item.MatKhau;
            //    LTK.Add(dn);
            //}
            //dgvTaiKhoan.DataSource = LTK.ToList<tblDangNhap>();
        }
        public dynamic LayDSTH()
        {
            var th = db.tblThuongHieux.Select(a => new
            {
                a.MaThuongHieu,
                a.TenThuongHieu
            }).ToList();
            return th;
        }
        public void LayCBTH(ComboBox cb)
        {
            cb.DataSource = LayDSTH();
            cb.DisplayMember = "TenThuongHieu";
            cb.ValueMember = "MaThuongHieu";
        }
        public dynamic LayDSCL()
        {
            var cl = db.tblChatLieux.Select(c => new
            {
                c.MaChatLieu,
                c.TenChatLieu
            }).ToList();
            return cl;
        }
        public void LayCBCL(ComboBox cb)
        {
            cb.DataSource = LayDSCL();
            cb.DisplayMember = "TenChatLieu";
            cb.ValueMember = "MaChatLieu";
        }
        public dynamic LayDSPL()
        {
            var pl = db.tblPhanLoais.Select(b => new
            {
                b.MaPhanLoai,
                b.TenPhanLoai
            }).ToList();
            return pl;
        }
        public void LayCBPL(ComboBox cb)
        {
            cb.DataSource = LayDSPL();
            cb.DisplayMember = "TenPhanLoai";
            cb.ValueMember = "MaPhanLoai";
        }
        public void LayDS(DataGridView dvg)
        {
            dvg.DataSource = LayDSSP();
        }
        public void HienThi()
        {
            dgvSanPham.DataSource = null;
            LayDS(dgvSanPham);
        }
        private void FrmSanPham_Load(object sender, EventArgs e)
        {
            HienThi();
            LayCBCL(cboMaChatLieu);
            LayCBPL(cboMaLoai);
            LayCBTH(cboMaThuongHieu);
        }
        private void Reset()
        {
            txtMaSanPham.Text = "SP0";
            txtTenSanPham.Text = "";
            txtKichCo.Text = "0";
            txtSoLuong.Text = "";
            txtDonGiaBan.Text = "";
            txtDonGiaNhap.Text = "";
            txtHinhAnh.Text = "";
            txtGhiChu.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Reset();
            btnBoQua.Enabled = true;
            btnLuu.Enabled = true;
            btnDong.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
        }
        private void CapNhat()
        {
            btnDong.Enabled = true;
            btnBoQua.Enabled = true;
            btnLuu.Enabled = true;
            btnXoa.Enabled = true;
            btnThem.Enabled = true;

        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            sp.MaSanPham = txtMaSanPham.Text.Trim();
            sp.TenSanPham = txtTenSanPham.Text.Trim();
            sp.MaThuongHieu = cboMaThuongHieu.SelectedValue.ToString();
            sp.MaPhanLoai = cboMaLoai.SelectedValue.ToString();
            sp.MaChatLieu = cboMaChatLieu.SelectedValue.ToString();
            sp.KichCo = Int32.Parse(txtKichCo.Text.Trim());
            sp.NgayNhap = dtpNgayNhap.Value;
            sp.SoLuong = float.Parse(txtSoLuong.Text.Trim());
            sp.DonGiaBan = float.Parse(txtDonGiaBan.Text.Trim());
            sp.DonGiaNhap = float.Parse(txtDonGiaBan.Text.Trim());
            sp.Anh = txtHinhAnh.Text.Trim();
            sp.GhiChu = txtGhiChu.Text.Trim();
            using (BanQuanAoModel db = new BanQuanAoModel())
            {
                if (txtMaSanPham.Text == "" || txtTenSanPham.Text == "" || txtKichCo.Text == "" || txtHinhAnh.Text == "" || txtDonGiaNhap.Text == "" ||
                    txtDonGiaBan.Text == "" || txtSoLuong.Text == "" || txtGhiChu.Text == "")
                {
                    MessageBox.Show("Bạn cần nhập thông tin đầy đủ!!", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                }
                else
                {
                    db.tblSanPhams.Add(sp);
                    db.SaveChanges();
                    MessageBox.Show("Bạn đã lưu thông tin thành công!!");
                }

            }
            HienThi();
            Reset();
            CapNhat();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgOpen = new OpenFileDialog();
            dlgOpen.Filter = "Bitmap(*.bmp)|*.bmp|JPEG(*.jpg)|*.jpg|GIF(*.gif)|*.gif|All files(*.*)|*.*";
            dlgOpen.FilterIndex = 2;
            dlgOpen.Title = "Chọn ảnh minh hoạ cho sản phẩm";
            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                picAnh.Image = Image.FromFile(dlgOpen.FileName);
                txtHinhAnh.Text = dlgOpen.FileName;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            sp.MaSanPham = txtMaSanPham.Text.Trim();
            sp.TenSanPham = txtTenSanPham.Text.Trim();
            sp.MaPhanLoai = cboMaLoai.SelectedValue.ToString();
            sp.MaChatLieu = cboMaChatLieu.SelectedValue.ToString();
            sp.MaThuongHieu = cboMaThuongHieu.SelectedValue.ToString();
            sp.KichCo = Int32.Parse(txtKichCo.Text.Trim());
            sp.NgayNhap = dtpNgayNhap.Value;
            sp.SoLuong = float.Parse(txtSoLuong.Text.Trim());
            sp.DonGiaBan = float.Parse(txtDonGiaBan.Text.Trim());
            sp.DonGiaNhap = float.Parse(txtDonGiaBan.Text.Trim());
            sp.Anh = txtHinhAnh.Text.Trim();
            sp.GhiChu = txtGhiChu.Text.Trim();
            using (BanQuanAoModel db = new BanQuanAoModel())
            {
                db.Entry(sp).State = EntityState.Modified;
                db.SaveChanges();
            }
            HienThi();
            MessageBox.Show("Bạn đã Sửa thông tin thành công!!");
            Reset();
            CapNhat();
        }

        private void dgvSanPham_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            sp.MaSanPham = Convert.ToString(dgvSanPham.CurrentRow.Cells["MaSanPham"].Value);
            if (dgvSanPham.CurrentRow.Index != -1)
            {
                using (BanQuanAoModel db = new BanQuanAoModel())
                {
                    sp = db.tblSanPhams.Where(n => n.MaSanPham == sp.MaSanPham).FirstOrDefault();
                    txtMaSanPham.Text = sp.MaSanPham;
                    txtTenSanPham.Text = sp.TenSanPham;
                    cboMaThuongHieu.SelectedValue = sp.MaThuongHieu;
                    cboMaLoai.SelectedValue = sp.MaPhanLoai;
                    cboMaChatLieu.SelectedValue = sp.MaChatLieu;
                    txtKichCo.Text = sp.KichCo.ToString();
                    dtpNgayNhap.Value = sp.NgayNhap.Value;
                    txtSoLuong.Text = sp.SoLuong.ToString();
                    txtDonGiaNhap.Text = sp.DonGiaNhap.ToString();
                    txtDonGiaBan.Text = sp.DonGiaBan.ToString();
                    txtHinhAnh.Text = sp.Anh;
                    picAnh.Image = Image.FromFile(txtHinhAnh.Text);
                    txtGhiChu.Text = sp.GhiChu;

                }
                btnLuu.Text = "Lưu";
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                btnDong.Enabled = true;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc là muốn xóa hay không!!!", "Thong bao!!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                sp.MaSanPham = txtMaSanPham.Text.Trim();
                sp.TenSanPham = txtTenSanPham.Text.Trim();
                sp.MaThuongHieu = cboMaThuongHieu.SelectedValue.ToString();
                sp.MaPhanLoai = cboMaLoai.SelectedValue.ToString();
                sp.MaChatLieu = cboMaChatLieu.SelectedValue.ToString();
                sp.KichCo = Int32.Parse(txtKichCo.Text.Trim());
                sp.NgayNhap = dtpNgayNhap.Value;
                sp.SoLuong = float.Parse(txtSoLuong.Text.Trim());
                sp.DonGiaBan = float.Parse(txtDonGiaBan.Text.Trim());
                sp.DonGiaNhap = float.Parse(txtDonGiaBan.Text.Trim());
                sp.Anh = txtHinhAnh.Text.Trim();
                sp.GhiChu = txtGhiChu.Text.Trim();
                using (BanQuanAoModel db = new BanQuanAoModel())
                {
                    db.Entry(sp).State = EntityState.Modified;
                    db.tblSanPhams.Remove(sp);
                    db.SaveChanges();
                }
                HienThi();
                MessageBox.Show("Bạn đã Xóa thông tin thành công!!");
                Reset();
                CapNhat();
            }
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            Reset();
            CapNhat();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            using (BanQuanAoModel db = new BanQuanAoModel())
            {
                var SP = db.tblSanPhams.Where(kh => kh.MaSanPham.Equals(txtTimKiem.Text)).FirstOrDefault();
                if (SP != null)
                {
                    string keyword = txtTimKiem.Text.Trim();
                    dgvSanPham.DataSource = db.tblSanPhams.Where(sp => sp.MaSanPham.Contains(keyword))
                    .Select(s => new
                    {
                        s.MaSanPham,
                        s.MaPhanLoai,
                        s.MaChatLieu,
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
    }
}
