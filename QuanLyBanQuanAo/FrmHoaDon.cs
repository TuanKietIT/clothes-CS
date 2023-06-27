using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyBanQuanAo.Model;
using COMExcel = Microsoft.Office.Interop.Excel;
namespace QuanLyBanQuanAo
{
    public partial class FrmHoaDon : Form
    {
        BanQuanAoModel db = new BanQuanAoModel();
        tblHoaDon hd = new tblHoaDon();
        tblCTHD ct = new tblCTHD();
        public FrmHoaDon()
        {
            InitializeComponent();
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
        public void LayDSHD(DataGridView dgv)
        {
            dgv.DataSource = LayDSCTHD();
        }
        public void HienThi()
        {
            dgvHoaDon.DataSource = null;
            LayDSHD(dgvHoaDon);
        }
        private void FrmHoaDon_Load(object sender, EventArgs e)
        {
            HienThi();
            using (BanQuanAoModel db = new BanQuanAoModel())
            {
                tblKhachHangBindingSource.DataSource = db.tblKhachHangs.ToList();
                tblNhanVienBindingSource.DataSource = db.tblNhanViens.ToList();
                tblSanPhamBindingSource.DataSource = db.tblSanPhams.ToList();
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            Reset();
            btnLuu.Enabled = true;
            btnDong.Enabled = false;
            btnIn.Enabled = false;
        }
        private void Reset()
        {
            txtMaHoaDon.Text = "HD0";
            dtpNgayNhap.Value = DateTime.Now;
            txtSoLuong.Text = "0";
            txtGiamGia.Text = "0";

        }
        private void CapNhat()
        {
            btnDong.Enabled = true;
            btnHuy.Enabled = true;
            btnLuu.Enabled = true;
            btnIn.Enabled = true;
            btnThem.Enabled = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            hd.MaHoaDon = txtMaHoaDon.Text.Trim();
            hd.MaKhachHang = cboMaKhach.Text.Trim();
            hd.MaNhanVien = cboMaNhanVien.Text.Trim();
            hd.NgayBan = dtpNgayNhap.Value;
            hd.TongTien = float.Parse(txtTongTien.Text.Trim());

            ct.MaHoaDon = txtMaHoaDon.Text.Trim();
            ct.MaSanPham = cboMaSanPham.Text.Trim();
            ct.SoLuong = float.Parse(txtSoLuong.Text.Trim());
            ct.DonGia = float.Parse(txtDonGia.Text.Trim());
            ct.GiamGia = float.Parse(txtGiamGia.Text.Trim());
            ct.ThanhTien = float.Parse(txtThanhTien.Text.Trim());
            using (BanQuanAoModel db = new BanQuanAoModel())
            {
                if (txtMaHoaDon.Text == "" || txtTenKhach.Text == "" || txtDiaChi.Text == "" || txtTenNhanVien.Text == "" || txtTenSanPham.Text == "" ||
                    txtThanhTien.Text == "" || txtTongTien.Text == "" || txtSoLuong.Text == "" || mtbDienThoai.Text == "" || txtGiamGia.Text == "" ||
                    txtMaHoaDon.Text == "" || txtTenKhach.Text == "" || txtDiaChi.Text == "" || txtTenNhanVien.Text == "" || txtTenSanPham.Text == "" ||
                    cboMaKhach.Text == "" || cboMaNhanVien.Text == "" || cboMaSanPham.Text == "")
                {
                    MessageBox.Show("Bạn cần nhập thông tin đầy đủ!!", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                }
                else
                {
                    db.tblCTHDs.Add(ct);
                    db.tblHoaDons.Add(hd);
                    db.SaveChanges();
                    MessageBox.Show("Bạn đã lưu thông tin thành công!!");
                }
            }
            HienThi();
            CapNhat();

        }
        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            //Khi thay đổi số lượng thì thực hiện tính lại thành tiền
            double tt, sl, dg, gg;
            if (txtSoLuong.Text == "")
                sl = 0;
            else
                sl = Convert.ToDouble(txtSoLuong.Text);
            if (txtGiamGia.Text == "")
                gg = 0;
            else
                gg = Convert.ToDouble(txtGiamGia.Text);
            if (txtDonGia.Text == "")
                dg = 0;
            else
                dg = Convert.ToDouble(txtDonGia.Text);
            tt = sl * dg - sl * dg * gg / 100;
            txtThanhTien.Text = tt.ToString();
            txtTongTien.Text = tt.ToString();
        }


        private void txtGiamGia_TextChanged(object sender, EventArgs e)
        {
            //Khi thay đổi giảm giá thì tính lại thành tiền
            double tt, sl, dg, gg;
            if (txtSoLuong.Text == "")
                sl = 0;
            else
                sl = Convert.ToDouble(txtSoLuong.Text);
            if (txtGiamGia.Text == "")
                gg = 0;
            else
                gg = Convert.ToDouble(txtGiamGia.Text);
            if (txtDonGia.Text == "")
                dg = 0;
            else
                dg = Convert.ToDouble(txtDonGia.Text);
            tt = sl * dg - sl * dg * gg / 100;
            txtThanhTien.Text = tt.ToString();
            txtTongTien.Text = tt.ToString();
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc là muốn xóa hay không!!!", "Thông bao!!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                hd.MaHoaDon = txtMaHoaDon.Text.Trim();
                hd.MaKhachHang = cboMaKhach.Text.Trim();
                hd.MaNhanVien = cboMaNhanVien.Text.Trim();
                hd.NgayBan = dtpNgayNhap.Value;
                hd.TongTien = float.Parse(txtTongTien.Text.Trim());

                ct.MaHoaDon = txtMaHoaDon.Text.Trim();
                ct.MaSanPham = cboMaSanPham.Text.Trim();
                ct.SoLuong = float.Parse(txtSoLuong.Text.Trim());
                ct.DonGia = float.Parse(txtDonGia.Text.Trim());
                ct.GiamGia = float.Parse(txtGiamGia.Text.Trim());
                ct.ThanhTien = float.Parse(txtThanhTien.Text.Trim());
                using (BanQuanAoModel db = new BanQuanAoModel())
                {
                    db.Entry(ct).State = EntityState.Modified;
                    db.Entry(hd).State = EntityState.Modified;
                    db.tblHoaDons.Remove(hd);
                    db.tblCTHDs.Remove(ct);
                    db.SaveChanges();
                }
                HienThi();
                MessageBox.Show("Bạn đã Huy thông tin thành công !!");
                CapNhat();
            }
        }

        private void dgvHoaDon_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ct.MaHoaDon = Convert.ToString(dgvHoaDon.CurrentRow.Cells["MaHoaDon"].Value);
            if (dgvHoaDon.CurrentRow.Index != -1)
            {
                using (BanQuanAoModel db = new BanQuanAoModel())
                {
                    ct = db.tblCTHDs.Where(n => n.MaHoaDon == ct.MaHoaDon).FirstOrDefault();
                    txtMaHoaDon.Text = hd.MaHoaDon;
                    cboMaKhach.Text = hd.MaKhachHang;
                    cboMaNhanVien.Text = hd.MaNhanVien;
                    txtTongTien.Text = hd.TongTien.ToString();

                    txtMaHoaDon.Text = ct.MaHoaDon;
                    cboMaSanPham.Text = ct.MaSanPham;
                    txtSoLuong.Text = ct.SoLuong.ToString();
                    txtDonGia.Text = ct.DonGia.ToString();
                    txtGiamGia.Text = ct.GiamGia.ToString();
                    txtThanhTien.Text = ct.ThanhTien.ToString();

                }
                btnLuu.Text = "LƯU HÓA ĐƠN";
                CapNhat();
            }
        }
        public static SqlConnection Con;
        internal static DataTable GetDataToTable(string sql)
        {
            Con = new SqlConnection(); // Khởi tao đối tượng con
            //Đường dẫn kết nối database
            Con.ConnectionString = Properties.Settings.Default.QuanLyQuanAo;
            SqlDataAdapter dap = new SqlDataAdapter(sql, Con); //Định nghĩa đối tượng thuộc lớp SqlDataAdapter
            //Khai báo đối tượng table thuộc lớp DataTable
            DataTable table = new DataTable();
            dap.Fill(table); //Đổ kết quả từ câu lệnh sql vào table
            return table;
        }
        private void btnIn_Click(object sender, EventArgs e)
        {
            // Khởi động chương trình Excel
            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook; //Trong 1 chương trình Excel có nhiều Workbook
            COMExcel.Worksheet exSheet; //Trong 1 Workbook có nhiều Worksheet
            COMExcel.Range exRange;
            string sql;
            int hang = 0, cot = 0;
            DataTable tblThongtinHD, tblThongtinHang;
            exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
            exSheet = exBook.Worksheets[1];
            // Định dạng chung
            exRange = exSheet.Cells[1, 1];
            exRange.Range["A1:Z300"].Font.Name = "Times new roman"; //Font chữ
            exRange.Range["A1:B3"].Font.Size = 10;
            exRange.Range["A1:B3"].Font.Bold = true;
            exRange.Range["A1:B3"].Font.ColorIndex = 5; //Màu xanh da trời
            exRange.Range["A1:A1"].ColumnWidth = 7;
            exRange.Range["B1:B1"].ColumnWidth = 15;
            exRange.Range["A1:B1"].MergeCells = true;
            exRange.Range["A1:B1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A1:B1"].Value = "Shop Bán quần áo";
            exRange.Range["A2:B2"].MergeCells = true;
            exRange.Range["A2:B2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:B2"].Value = "TÂN BÌNH - TP.HCM";
            exRange.Range["A3:B3"].MergeCells = true;
            exRange.Range["A3:B3"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A3:B3"].Value = "Điện thoại: (084)3852641";
            exRange.Range["C2:E2"].Font.Size = 16;
            exRange.Range["C2:E2"].Font.Bold = true;
            exRange.Range["C2:E2"].Font.ColorIndex = 3; //Màu đỏ
            exRange.Range["C2:E2"].MergeCells = true;
            exRange.Range["C2:E2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C2:E2"].Value = "HÓA ĐƠN BÁN";
            // Biểu diễn thông tin chung của hóa đơn bán
            sql = "SELECT a.MaHoaDon, a.NgayBan, a.TongTien, b.TenKhachHang, b.DiaChi, b.SoDienThoai, c.TenNhanVien FROM tblHoaDon AS a, tblKhachHang AS b, tblNhanVien AS c WHERE a.MaHoaDon = N'" + txtMaHoaDon.Text + "' AND a.MaKhachHang = b.MaKhachHang AND a.MaNhanVien = c.MaNhanVien";
            tblThongtinHD = GetDataToTable(sql);
            exRange.Range["B6:C9"].Font.Size = 12;
            exRange.Range["B6:B6"].Value = "Mã hóa đơn:";
            exRange.Range["C6:E6"].MergeCells = true;
            exRange.Range["C6:E6"].Value = tblThongtinHD.Rows[0][0].ToString();
            exRange.Range["B7:B7"].Value = "Khách hàng:";
            exRange.Range["C7:E7"].MergeCells = true;
            exRange.Range["C7:E7"].Value = tblThongtinHD.Rows[0][3].ToString();
            exRange.Range["B8:B8"].Value = "Địa chỉ:";
            exRange.Range["C8:E8"].MergeCells = true;
            exRange.Range["C8:E8"].Value = tblThongtinHD.Rows[0][4].ToString();
            exRange.Range["B9:B9"].Value = "Điện thoại:";
            exRange.Range["C9:E9"].MergeCells = true;
            exRange.Range["C9:E9"].Value = tblThongtinHD.Rows[0][5].ToString();
            //Lấy thông tin các mặt hàng
            sql = "SELECT b.TenSanPham, a.SoLuong, b.DonGiaBan, a.GiamGia, a.ThanhTien " +
                  "FROM tblCTHD AS a , tblSanPham AS b WHERE a.MaHoaDon = N'" +
                  txtMaHoaDon.Text + "' AND a.MaSanPham = b.MaSanPham";
            tblThongtinHang = GetDataToTable(sql);
            //Tạo dòng tiêu đề bảng
            exRange.Range["A11:F11"].Font.Bold = true;
            exRange.Range["A11:F11"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C11:F11"].ColumnWidth = 12;
            exRange.Range["A11:A11"].Value = "STT";
            exRange.Range["B11:B11"].Value = "Tên hàng";
            exRange.Range["C11:C11"].Value = "Số lượng";
            exRange.Range["D11:D11"].Value = "Đơn giá";
            exRange.Range["E11:E11"].Value = "Giảm giá";
            exRange.Range["F11:F11"].Value = "Thành tiền";
            for (hang = 0; hang < tblThongtinHang.Rows.Count; hang++)
            {
                //Điền số thứ tự vào cột 1 từ dòng 12
                exSheet.Cells[1][hang + 12] = hang + 1;
                for (cot = 0; cot < tblThongtinHang.Columns.Count; cot++)
                //Điền thông tin hàng từ cột thứ 2, dòng 12
                {
                    exSheet.Cells[cot + 2][hang + 12] = tblThongtinHang.Rows[hang][cot].ToString();
                    if (cot == 3) exSheet.Cells[cot + 2][hang + 12] = tblThongtinHang.Rows[hang][cot].ToString() + "%";
                }
            }
            exRange = exSheet.Cells[cot][hang + 14];
            exRange.Font.Bold = true;
            exRange.Value2 = "Tổng tiền:";
            exRange = exSheet.Cells[cot + 1][hang + 14];
            exRange.Font.Bold = true;
            exRange.Value2 = tblThongtinHD.Rows[0][2].ToString();
            exRange = exSheet.Cells[1][hang + 15]; //Ô A1 
            exRange.Range["A1:F1"].MergeCells = true;
            exRange.Range["A1:F1"].Font.Bold = true;
            exRange.Range["A1:F1"].Font.Italic = true;
            exRange.Range["A1:F1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignRight;
            exRange = exSheet.Cells[4][hang + 17]; //Ô A1 
            exRange.Range["A1:C1"].MergeCells = true;
            exRange.Range["A1:C1"].Font.Italic = true;
            exRange.Range["A1:C1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            DateTime d = Convert.ToDateTime(tblThongtinHD.Rows[0][1]);
            exRange.Range["A1:C1"].Value = "Hà Nội, ngày " + d.Day + " tháng " + d.Month + " năm " + d.Year;
            exRange.Range["A2:C2"].MergeCells = true;
            exRange.Range["A2:C2"].Font.Italic = true;
            exRange.Range["A2:C2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:C2"].Value = "Nhân viên bán hàng";
            exRange.Range["A6:C6"].MergeCells = true;
            exRange.Range["A6:C6"].Font.Italic = true;
            exRange.Range["A6:C6"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A6:C6"].Value = tblThongtinHD.Rows[0][6];
            exSheet.Name = "Hóa đơn nhập";
            exApp.Visible = true;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            using (BanQuanAoModel db = new BanQuanAoModel())
            {
                var CTHD = db.tblCTHDs.Where(ct => ct.MaHoaDon.Equals(txtTimKiem.Text)).FirstOrDefault();
                if (CTHD != null)
                {
                    string keyword = txtTimKiem.Text.Trim();
                    dgvHoaDon.DataSource = db.tblCTHDs.Where(ct => ct.MaHoaDon.Contains(keyword))
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

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
