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
    public partial class FrmThuongHieu : Form
    {
        BanQuanAoModel db = new BanQuanAoModel();
        List<tblThuongHieu> LTK = new List<tblThuongHieu>();
        tblThuongHieu th = new tblThuongHieu();
        public FrmThuongHieu()
        {
            InitializeComponent();
        }
        


        public dynamic LayDSTH()
        {
            var TK = db.tblThuongHieux
                .Select(m => new
                {

                    m.MaThuongHieu,
                    m.TenThuongHieu
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
            dvg.DataSource = LayDSTH();
        }
        public void HienThi()
        {
            dgvThuongHieu.DataSource = null;
            LayDS(dgvThuongHieu);
        }

        private void FrmThuongHieu_Load(object sender, EventArgs e)
        {
            HienThi();
        }
        public void reset()
        {
            txtMaThuongHieu.Text = "TH0";
            txtTenThuongHieu.Text = "";
            txtTimKiem.Text = "";
        }

        private void btnThem_Click_1(object sender, EventArgs e)
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
            th.MaThuongHieu = txtMaThuongHieu.Text.Trim();
            th.TenThuongHieu = txtTenThuongHieu.Text.Trim();
            using (BanQuanAoModel db = new BanQuanAoModel())
            {
                if (txtMaThuongHieu.Text == "" || txtTenThuongHieu.Text == "")
                {
                    MessageBox.Show("Bạn cần nhập thông tin!!", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                }
                else
                {
                    db.tblThuongHieux.Add(th);
                    db.SaveChanges();
                    MessageBox.Show("Bạn đã thêm thành công!!");
                }

            }
            HienThi();
            reset();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            th.MaThuongHieu = txtMaThuongHieu.Text.Trim();
            th.TenThuongHieu = txtTenThuongHieu.Text.Trim();
            using (BanQuanAoModel db = new BanQuanAoModel())
            {
                db.Entry(th).State = EntityState.Modified;
                db.SaveChanges();
            }
            MessageBox.Show("Bạn đã sửa thành công!!");
            HienThi();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc là muốn xóa hay không?", "Thong bao!!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                th.MaThuongHieu = txtMaThuongHieu.Text.Trim();
                th.TenThuongHieu = txtTenThuongHieu.Text.Trim();
                using (BanQuanAoModel db = new BanQuanAoModel())
                {
                    db.Entry(th).State = EntityState.Modified;
                    db.tblThuongHieux.Remove(th);
                    db.SaveChanges();
                }
                MessageBox.Show("Bạn đã xóa thành công!!");
                HienThi();
                reset();
            }
        }


        private void btnBoQua_Click(object sender, EventArgs e)
        {
            reset();
            btnLuu.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnDong.Enabled = true;
            HienThi();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvThuongHieu_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            th.MaThuongHieu = Convert.ToString(dgvThuongHieu.CurrentRow.Cells["MaThuongHieu"].Value);
            if (dgvThuongHieu.CurrentRow.Index != -1)
            {
                using (BanQuanAoModel db = new BanQuanAoModel())
                {
                    th = db.tblThuongHieux.Where(t => t.MaThuongHieu == th.MaThuongHieu).FirstOrDefault();
                    txtMaThuongHieu.Text = th.MaThuongHieu;
                    txtTenThuongHieu.Text = th.TenThuongHieu;
                }
                btnLuu.Text = "Lưu";
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                btnDong.Enabled = true;
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            using (BanQuanAoModel db = new BanQuanAoModel())
            {
                var TH = db.tblThuongHieux.Where(t => t.TenThuongHieu.Equals(txtTimKiem.Text)).FirstOrDefault();
                if (TH != null)
                {
                    dgvThuongHieu.DataSource = db.tblThuongHieux.Where(t => t.TenThuongHieu.Contains(txtTimKiem.Text))
                    .Select(th => new
                    {
                        th.MaThuongHieu,
                        th.TenThuongHieu
                    }).ToList();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy kết quả!!Xin mời bạn nhập lại!!", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                }

            }
        }
    }
}
