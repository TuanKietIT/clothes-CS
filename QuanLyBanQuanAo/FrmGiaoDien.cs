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
    public partial class FrmGiaoDien : Form
    {
        public FrmGiaoDien()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmDangNhapNhanVien nv = new FrmDangNhapNhanVien();
            nv.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmDangNhapQuanLy ql = new FrmDangNhapQuanLy();
            ql.Show();
        }
    }
}
