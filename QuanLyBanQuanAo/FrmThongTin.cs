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
    public partial class FrmThongTin : Form
    {
        BanQuanAoModel db = new BanQuanAoModel();
        List<tblDangNhap> LTK = new List<tblDangNhap>();
        tblDangNhap dn = new tblDangNhap();
        public FrmThongTin()
        {
            InitializeComponent();
        }
        public dynamic LayDSTK()
        {
            var TK = db.tblDangNhaps
                .Select(m => new
                {

                    m.TenTaiKhoan,
                    m.MatKhau
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
            dvg.DataSource = LayDSTK();
        }
        public void HienThi()
        {
            dgvTaiKhoan.DataSource = null;
            LayDS(dgvTaiKhoan);
        }
        private void FrmThongTin_Load(object sender, EventArgs e)
        {
            HienThi();
        }

        public void reset()
        {
            txtTenTaiKhoan.Text = "";
            txtMatKhau.Text = "";
            txtTimKiem.Text = "";

        }
        public void Capnhat()
        {
            btnLuu.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnDong.Enabled = true;

        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            reset();
            btnBoQua.Enabled = true;
            btnLuu.Enabled = true;
            btnDong.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            tblDangNhap dn = new tblDangNhap();
            dn.TenTaiKhoan = txtTenTaiKhoan.Text;
            dn.MatKhau = txtMatKhau.Text;
            if (txtTenTaiKhoan.Text == "" || txtMatKhau.Text == "")
            {
                 MessageBox.Show("Bạn cần nhập thông tin!!", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
             }
            else
            {
                db.tblDangNhaps.Add(dn);
                db.SaveChanges();
                MessageBox.Show("Bạn đã thêm thành công!!");
            }
            HienThi();
            reset();
            Capnhat();
        }
        private void dgvTaiKhoan_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dn.TenTaiKhoan = Convert.ToString(dgvTaiKhoan.CurrentRow.Cells["TenTaiKhoan"].Value);
            if (dgvTaiKhoan.CurrentRow.Index != -1)
            {
                using (BanQuanAoModel db = new BanQuanAoModel())
                {
                    dn = db.tblDangNhaps.Where(d => d.TenTaiKhoan == dn.TenTaiKhoan).FirstOrDefault();
                    txtTenTaiKhoan.Text = dn.TenTaiKhoan;
                    txtMatKhau.Text = dn.MatKhau;
                }
                btnLuu.Text = "Lưu";
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                btnDong.Enabled = true;
            }
        }
        private void btnBoQua_Click(object sender, EventArgs e)
        {
            reset();
            Capnhat();
            HienThi();
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
           
                dn.TenTaiKhoan = txtTenTaiKhoan.Text.Trim();
                dn.MatKhau = txtMatKhau.Text.Trim();
                using (BanQuanAoModel db = new BanQuanAoModel())
                {
                    db.Entry(dn).State = EntityState.Modified;
                    db.SaveChanges();
                }
                MessageBox.Show("Bạn đã sửa thành công!!");
                HienThi();
                Capnhat();
                reset();
        
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chăc là muốn xóa hay không?", "Thong bao!!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                dn.TenTaiKhoan = txtTenTaiKhoan.Text.Trim();
                dn.MatKhau = txtMatKhau.Text.Trim();
                using (BanQuanAoModel db = new BanQuanAoModel())
                {
                    db.Entry(dn).State = EntityState.Modified;
                    db.tblDangNhaps.Remove(dn);
                    db.SaveChanges();
                }
                MessageBox.Show("Bạn đã xóa thành công!!");
                HienThi();
                Capnhat();
                reset();
            }
        }
        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            using (BanQuanAoModel db = new BanQuanAoModel())
            {
                var TK = db.tblDangNhaps.Where(tk => tk.TenTaiKhoan.Equals(txtTimKiem.Text)).FirstOrDefault();
                if (TK != null)
                {
                    dgvTaiKhoan.DataSource = db.tblDangNhaps.Where(tk => tk.TenTaiKhoan.Contains(txtTimKiem.Text))
                   .Select(tk => new
                   {
                       tk.TenTaiKhoan,
                       tk.MatKhau
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
