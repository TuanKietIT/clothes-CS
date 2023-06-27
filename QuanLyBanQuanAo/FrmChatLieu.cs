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
    public partial class FrmChatLieu : Form
    {
        BanQuanAoModel db = new BanQuanAoModel();
        List<tblChatLieu> LTK = new List<tblChatLieu>();
        tblChatLieu cl = new tblChatLieu();

        public FrmChatLieu()
        {
            InitializeComponent();
        }

        public dynamic LayDSCL()
        {
            var TK = db.tblChatLieux
                .Select(m => new
                {

                    m.MaChatLieu,
                    m.TenChatLieu
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
            dvg.DataSource = LayDSCL();
        }
        public void HienThi()
        {
            dgvChatLieu.DataSource = null;
            LayDS(dgvChatLieu);
        }

        private void FrmChatLieu_Load(object sender, EventArgs e)
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
            txtMaChatLieu.Text = "CL0";
            txtTenChatLieu.Text = "";
            txtTimKiem.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            cl.MaChatLieu = txtMaChatLieu.Text.Trim();
            cl.TenChatLieu = txtTenChatLieu.Text.Trim();
            using (BanQuanAoModel db = new BanQuanAoModel())
            {
                if (txtMaChatLieu.Text == "" || txtTenChatLieu.Text == "")
                {
                    MessageBox.Show("Bạn cần nhập thông tin!!", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                }
                else
                {
                    db.tblChatLieux.Add(cl);
                    db.SaveChanges();
                    MessageBox.Show("Bạn đã thêm thành công!!");
                }

            }
            HienThi();
            reset();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            cl.MaChatLieu = txtMaChatLieu.Text.Trim();
            cl.TenChatLieu = txtTenChatLieu.Text.Trim();
            using (BanQuanAoModel db = new BanQuanAoModel())
            {
                db.Entry(cl).State = EntityState.Modified;
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
                cl.MaChatLieu = txtMaChatLieu.Text.Trim();
                cl.TenChatLieu = txtTenChatLieu.Text.Trim();
                using (BanQuanAoModel db = new BanQuanAoModel())
                {
                    db.Entry(cl).State = EntityState.Modified;
                    db.tblChatLieux.Remove(cl);
                    db.SaveChanges();
                }
                MessageBox.Show("Bạn đã xóa thành công!!");
                HienThi();
                reset();
            }
        }

        private void dgvChatLieu_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            cl.MaChatLieu = Convert.ToString(dgvChatLieu.CurrentRow.Cells["MaChatLieu"].Value);
            if (dgvChatLieu.CurrentRow.Index != -1)
            {
                using (BanQuanAoModel db = new BanQuanAoModel())
                {
                    cl = db.tblChatLieux.Where(b => b.MaChatLieu == cl.MaChatLieu).FirstOrDefault();
                    txtMaChatLieu.Text = cl.MaChatLieu;
                    txtTenChatLieu.Text = cl.TenChatLieu;
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
                var CL = db.tblChatLieux.Where(kh => kh.TenChatLieu.Equals(txtTimKiem.Text)).FirstOrDefault();
                if (CL != null)
                {
                    dgvChatLieu.DataSource = db.tblChatLieux.Where(c => c.TenChatLieu.Contains(txtTimKiem.Text))
                    .Select(cl => new
                    {
                        cl.MaChatLieu,
                        cl.TenChatLieu
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
