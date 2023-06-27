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
    public partial class FrmKhachHang : Form
    {
        BanQuanAoModel db = new BanQuanAoModel();
        List<tblKhachHang> LTK = new List<tblKhachHang>();
        tblKhachHang kh = new  tblKhachHang();
       
        public FrmKhachHang()
        {
            InitializeComponent();
        }
       
        public dynamic LayDSKH()
        {
            var TK = db.tblKhachHangs
                .Select(k => new
                {
                    k.MaKhachHang,
                    k.TenKhachHang,
                    k.DiaChi,
                    k.SoDienThoai,
                    k.NgayDatHang

                }).ToList();
            return TK;
            //foreach (var item in TK)
            //{
            //    tblDangNhap dn = new tblDangNhap();
            //    dn.TenTaiKhoan = item.TenTaiKhoan;
            //    dn.MatKhau = item.MatKhau;
            //    LTK.Add(dn);
            //}
            //dgvTaiKhoan.DataSource = LTK.ToList<tblDangNhap>();
        }
        public void LayDS(DataGridView dvg)
        {
            dvg.DataSource = LayDSKH();
        }
        public void HienThi()
        {
            dgvKhachHang.DataSource = null;
            LayDS(dgvKhachHang);
        }
        private void FrmKhachHang_Load(object sender, EventArgs e)
        {
            HienThi();
        }
        public void reset()
        {
            txtMaKhachHang.Text = "KH0";
            txtTenKhachHang.Text = "";
            txtDiaChi.Text = "";
            mtbSoDienThoai.Text = "";
            dtpNgayDatHang.Value = DateTime.Now;
            txtTimKiem.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnLuu.Enabled = true;
            btnBoQua.Enabled = true;
            btnDong.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            reset();
        }
        public bool checkdata()
        {
            if (String.IsNullOrEmpty(txtMaKhachHang.Text))
            {
                MessageBox.Show("Bạn cần phải nhập mã vào.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaKhachHang.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtTenKhachHang.Text))
            {
                MessageBox.Show("Bạn cần phải nhập tên vào.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenKhachHang.Focus();
                return false;
            }
            else if (String.IsNullOrEmpty(mtbSoDienThoai.Text))
            {
                MessageBox.Show("Bạn cần phải nhập số điện thoại.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mtbSoDienThoai.Focus();
                return false;
            }
            else if (String.IsNullOrEmpty(txtDiaChi.Text))
            {
                MessageBox.Show("Bạn cần phải nhập địa chỉ.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiaChi.Focus();
                return false;
            }

            return true;
        }//xong

        private void btnLuu_Click(object sender, EventArgs e)
        {
            kh.MaKhachHang = txtMaKhachHang.Text.Trim();
            kh.TenKhachHang = txtTenKhachHang.Text.Trim();
            kh.DiaChi = txtDiaChi.Text.Trim();
            kh.SoDienThoai = mtbSoDienThoai.Text.Trim();
            kh.NgayDatHang = dtpNgayDatHang.Value;
            using (BanQuanAoModel db = new BanQuanAoModel())
            {
                if (checkdata())
                {
                    MessageBox.Show("dữ liệu phù hợp! mời bạn lưu!!", "Thành Công", MessageBoxButtons.OK);
                    db.tblKhachHangs.Add(kh);
                    db.SaveChanges();
                    MessageBox.Show("Bạn đã lưu thông tin thành công!!");
                    reset();
                    // btnLuu.Enabled = true;
                }
                else
                {
                    MessageBox.Show("dữ liệu không phù hợp!! mời nhập lại", "Thất Bại", MessageBoxButtons.OK);
                    db.SaveChanges();
                    btnLuu.Enabled = false;
                }
            //    if (txtMaKhachHang.Text == "" || txtTenKhachHang.Text == "" || txtDiaChi.Text == "" || mtbSoDienThoai.Text == "")
            //    {
            //        MessageBox.Show("Bạn cần nhập thông tin đầy đủ!!", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            //    }
            //    else
            //    {
            //        db.tblKhachHangs.Add(kh);
            //        db.SaveChanges();
            //        MessageBox.Show("Bạn đã lưu thông tin thành công!!");
            //        reset();
            //    }
            }
            HienThi();
            btnThem.Enabled = true;
            btnLuu.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnDong.Enabled = true;

        }
        private void dgvKhachHang_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            kh.MaKhachHang = Convert.ToString(dgvKhachHang.CurrentRow.Cells["MaKhachHang"].Value);
            using (BanQuanAoModel db = new BanQuanAoModel())
            {
                kh = db.tblKhachHangs.Where(k => k.MaKhachHang == kh.MaKhachHang).FirstOrDefault();
                txtMaKhachHang.Text = kh.MaKhachHang;
                txtTenKhachHang.Text = kh.TenKhachHang;
                txtDiaChi.Text = kh.DiaChi;
                mtbSoDienThoai.Text = kh.SoDienThoai;
            }
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            kh.MaKhachHang = txtMaKhachHang.Text.Trim();
            kh.TenKhachHang = txtTenKhachHang.Text.Trim();
            kh.DiaChi = txtDiaChi.Text.Trim();
            kh.SoDienThoai = mtbSoDienThoai.Text.Trim();
            kh.NgayDatHang = dtpNgayDatHang.Value;
            using (BanQuanAoModel db = new BanQuanAoModel())
            {
                db.Entry(kh).State = EntityState.Modified;
                db.SaveChanges();
            }
            HienThi();
            MessageBox.Show("Bạn đã lưu thông tin thành công!!");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn thật sự muốn xóa??", "Thong bao!!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (dgvKhachHang.CurrentRow.Index != -1)
                {
                    kh.MaKhachHang = txtMaKhachHang.Text.Trim();
                    kh.TenKhachHang = txtTenKhachHang.Text.Trim();
                    kh.DiaChi = txtDiaChi.Text.Trim();
                    kh.SoDienThoai = mtbSoDienThoai.Text.Trim();
                    kh.NgayDatHang = dtpNgayDatHang.Value;
                    using (BanQuanAoModel db = new BanQuanAoModel())
                    {
                        db.Entry(kh).State = EntityState.Modified;
                        db.tblKhachHangs.Remove(kh);
                        db.SaveChanges();
                    }
                    HienThi();
                    MessageBox.Show("Bạn đã lưu thông tin thành công!!");
                }
            }
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = true;
            btnLuu.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnDong.Enabled = true;
            reset();
            HienThi();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            using (BanQuanAoModel db = new BanQuanAoModel())
            {
                var KH = db.tblKhachHangs.Where(kh => kh.MaKhachHang.Equals(txtTimKiem.Text)).FirstOrDefault();
                if (KH != null)
                {
                    dgvKhachHang.DataSource = db.tblKhachHangs.Where(k => k.MaKhachHang.Contains(txtTimKiem.Text))
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
                    MessageBox.Show("Không tìm thấy kết quả xin mời nhập lại!!", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                }


            }
        }
    }
}
