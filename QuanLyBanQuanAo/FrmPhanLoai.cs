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
    public partial class FrmPhanLoai : Form
    {
        BanQuanAoModel db = new BanQuanAoModel();
        List<tblPhanLoai> LTK = new List<tblPhanLoai>();
        tblPhanLoai pl = new tblPhanLoai();
        public FrmPhanLoai()
        {
            InitializeComponent();
        }
        public dynamic LayDSPL()
        {
            var TK = db.tblPhanLoais
                .Select(m => new
                {

                    m.MaPhanLoai,
                    m.TenPhanLoai
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
            dvg.DataSource = LayDSPL();
        }
        public void HienThi()
        {
            dgvPhanLoai.DataSource = null;
            LayDS(dgvPhanLoai);
        }
        private void FrmPhanLoai_Load(object sender, EventArgs e)
        {
            HienThi();
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
        public void reset()
        {
            txtMaLoai.Text = "PL0";
            txtTenLoai.Text = "";
            txtTimKiem.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            pl.MaPhanLoai = txtMaLoai.Text.Trim();
            pl.TenPhanLoai = txtTenLoai.Text.Trim();
            using (BanQuanAoModel db = new BanQuanAoModel())
            {
                if (txtMaLoai.Text == "" || txtTenLoai.Text == "")
                {
                    MessageBox.Show("Bạn cần nhập thông tin!!", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                }
                else
                {
                    db.tblPhanLoais.Add(pl);
                    db.SaveChanges();
                    MessageBox.Show("Bạn đã thêm thành công!!");
                }

            }
            HienThi();
            reset();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            pl.MaPhanLoai = txtMaLoai.Text.Trim();
            pl.TenPhanLoai = txtTenLoai.Text.Trim();
            using (BanQuanAoModel db = new BanQuanAoModel())
            {
                db.Entry(pl).State = EntityState.Modified;
                db.SaveChanges();
            }
            MessageBox.Show("Bạn đã sửa thành công!!");
            HienThi();
            reset();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc là muốn xóa hay không?", "Thong bao!!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                pl.MaPhanLoai = txtMaLoai.Text.Trim();
                pl.TenPhanLoai = txtTenLoai.Text.Trim();
                using (BanQuanAoModel db = new BanQuanAoModel())
                {
                    db.Entry(pl).State = EntityState.Modified;
                    db.tblPhanLoais.Remove(pl);
                    db.SaveChanges();
                }
                MessageBox.Show("Bạn đã xóa thành công!!");
                HienThi();
                reset();
            }
        }

        private void dgvPhanLoai_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            pl.MaPhanLoai = Convert.ToString(dgvPhanLoai.CurrentRow.Cells["MaPhanLoai"].Value);
            if (dgvPhanLoai.CurrentRow.Index != -1)
            {
                using (BanQuanAoModel db = new BanQuanAoModel())
                {
                    pl = db.tblPhanLoais.Where(b => b.MaPhanLoai == pl.MaPhanLoai).FirstOrDefault();
                    txtMaLoai.Text = pl.MaPhanLoai;
                    txtTenLoai.Text = pl.TenPhanLoai;
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

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            using (BanQuanAoModel db = new BanQuanAoModel())
            {
                var PL = db.tblPhanLoais.Where(pl => pl.TenPhanLoai.Equals(txtTimKiem.Text)).FirstOrDefault();
                if (PL != null)
                {
                    dgvPhanLoai.DataSource = db.tblPhanLoais.Where(p => p.TenPhanLoai.Contains(txtTimKiem.Text))
                    .Select(pl => new
                    {
                        pl.MaPhanLoai,
                        pl.TenPhanLoai
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
