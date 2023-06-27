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
    public partial class FrmDangNhapQuanLy : Form
    {
        public FrmDangNhapQuanLy()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            using (BanQuanAoModel db = new BanQuanAoModel())
            {
                if (txtTaiKhoan.Text != string.Empty || txtMatKhau.Text != string.Empty)
                {
                    var NguoiSuDung = db.tblDangNhaps.Where(dn => dn.TenTaiKhoan.Equals(txtTaiKhoan.Text)).FirstOrDefault();
                    if (NguoiSuDung != null)
                    {
                        if (NguoiSuDung.MatKhau.Equals(txtMatKhau.Text))
                        {
                            FrmGiaoDienQuanLy ql = new FrmGiaoDienQuanLy();
                            this.Hide();
                            ql.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Bạn đẫ nhập sai mật khẩu!!", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        //MessageBox.Show("Bạn đẫ nhập sai Tài khoản!!", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Tài khoản không hơp lệ!!", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                }
            }
        }

        private void FrmDangNhapQuanLy_Load(object sender, EventArgs e)
        {
            txtTaiKhoan.Text = "quangdinh";
            txtMatKhau.Text = "1111";
        }

        private void btnThoast_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
