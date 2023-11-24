using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace quanlicuahangthucphamchay
{
    public partial class banhang : Form
    {
        db conn = new db();
        public banhang()
        {
            InitializeComponent();
        }

        private void banhang_Load(object sender, EventArgs e)
        {
            loaddata();
        }

        public void loaddata()
        {
            string cmnd = "select * from v_sanpham ";
            DataTable dt = conn.readdata(cmnd);

            if (dt != null)
            {
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].Width = 50;
                dataGridView1.Columns[1].Width = 285;
                dataGridView1.Columns[2].Width = 100;
                dataGridView1.Columns[3].Width = 100;
                dataGridView1.Columns[4].Width = 100;
                dataGridView1.Columns[5].Width = 100;
                dataGridView1.Columns[6].Width = 100;
               
            }
            dataGridView1.ClearSelection();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            timkiem();
        }

        public void timkiem()
        {
            string cmnd = "select * from v_sanpham  where [Tên sản phẩm] like N'%" + textBox4.Text + "%'";
            DataTable dt = conn.readdata(cmnd);

            if (dt != null)
            {
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].Width = 50;
                dataGridView1.Columns[1].Width = 285;
                dataGridView1.Columns[2].Width = 100;
                dataGridView1.Columns[3].Width = 100;
                dataGridView1.Columns[4].Width = 100;
                dataGridView1.Columns[5].Width = 100;
                dataGridView1.Columns[6].Width = 100;
               
            }
            dataGridView1.ClearSelection();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cochon = true;
            var selectedRow = dataGridView1.SelectedRows[0];

            // Lưu lại để sử dụng ở nút Thêm
            selectedDataGridView1Row = selectedRow; 
        }

        public DataGridViewRow selectedDataGridView1Row { get; set; }

        void tinhtien() {

            int sl = 0;
            int tong = 0;
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                DataGridViewRow row = dataGridView2.Rows[i];

                int quantity = Convert.ToInt32(row.Cells[2].Value);
                int tt = Convert.ToInt32(row.Cells[3].Value) * quantity;
                // Cộng dồn vào tổng 
                sl += quantity;
                tong += tt;
            }

            // Hiển thị tổng số lượng
            label1.Text = "Số món: " + sl.ToString();
            label3.Text =  tong.ToString();   
        }


        private bool cochon = false;
        private bool cochon1 = false;
        private void button2_Click(object sender, EventArgs e)
        {
            if (cochon)
            {
                dataGridView2.Rows.Add(selectedDataGridView1Row.Cells[0].Value,
                            selectedDataGridView1Row.Cells[1].Value, textBox1.Text, selectedDataGridView1Row.Cells[4].Value
                            );
                tinhtien();
                dataGridView2.ClearSelection();
                dataGridView1.ClearSelection();
                cochon = false;
            }
           
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (cochon1)
            {
                int selectedRowIndex = dataGridView2.CurrentCell.RowIndex;
                int quantity = Convert.ToInt32(dataGridView2.Rows[selectedRowIndex].Cells[2].Value);
                if (quantity > 1)
                {
                    // Giảm số lượng đi 1
                    quantity--;

                    // Cập nhật lại số lượng mới
                    dataGridView2.Rows[selectedRowIndex].Cells[2].Value = quantity;
                }
                else
                {
                    // Xóa dòng nếu số lượng = 1
                    dataGridView2.Rows.RemoveAt(selectedRowIndex);
                }
                tinhtien();
                dataGridView2.ClearSelection();
                cochon1 = false;
            }

        }

        // nút tất cả 
        private void button5_Click(object sender, EventArgs e)
        {
            loaddata();
        }
        // lạnh 
        private void button6_Click(object sender, EventArgs e)
        {
            string cmnd = "select * from v_sanpham  where [Danh mục] like N'%Đông lạnh%'";
            DataTable dt = conn.readdata(cmnd);

            if (dt != null)
            {
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].Width = 50;
                dataGridView1.Columns[1].Width = 285;
                dataGridView1.Columns[2].Width = 100;
                dataGridView1.Columns[3].Width = 100;
                dataGridView1.Columns[4].Width = 100;
                dataGridView1.Columns[5].Width = 100;
                dataGridView1.Columns[6].Width = 100;

            }
            dataGridView1.ClearSelection();
        }
        // khô 
        private void button7_Click(object sender, EventArgs e)
        {
            string cmnd = "select * from v_sanpham  where [Danh mục] like N'%Khô hộp%'";
            DataTable dt = conn.readdata(cmnd);

            if (dt != null)
            {
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].Width = 50;
                dataGridView1.Columns[1].Width = 285;
                dataGridView1.Columns[2].Width = 100;
                dataGridView1.Columns[3].Width = 100;
                dataGridView1.Columns[4].Width = 100;
                dataGridView1.Columns[5].Width = 100;
                dataGridView1.Columns[6].Width = 100;

            }
            dataGridView1.ClearSelection();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string cmnd = "select * from v_sanpham  where [Danh mục] like N'%Ăn liền%'";
            DataTable dt = conn.readdata(cmnd);

            if (dt != null)
            {
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].Width = 50;
                dataGridView1.Columns[1].Width = 285;
                dataGridView1.Columns[2].Width = 100;
                dataGridView1.Columns[3].Width = 100;
                dataGridView1.Columns[4].Width = 100;
                dataGridView1.Columns[5].Width = 100;
                dataGridView1.Columns[6].Width = 100;

            }
            dataGridView1.ClearSelection();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string cmnd = "select * from v_sanpham  where [Danh mục] like N'%Gia vị sốt%'";
            DataTable dt = conn.readdata(cmnd);

            if (dt != null)
            {
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].Width = 50;
                dataGridView1.Columns[1].Width = 285;
                dataGridView1.Columns[2].Width = 100;
                dataGridView1.Columns[3].Width = 100;
                dataGridView1.Columns[4].Width = 100;
                dataGridView1.Columns[5].Width = 100;
                dataGridView1.Columns[6].Width = 100;

            }
            dataGridView1.ClearSelection();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string cmnd = "select * from v_sanpham  where [Danh mục] like N'%Khác%'";
            DataTable dt = conn.readdata(cmnd);

            if (dt != null)
            {
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].Width = 50;
                dataGridView1.Columns[1].Width = 285;
                dataGridView1.Columns[2].Width = 100;
                dataGridView1.Columns[3].Width = 100;
                dataGridView1.Columns[4].Width = 100;
                dataGridView1.Columns[5].Width = 100;
                dataGridView1.Columns[6].Width = 100;

            }
            dataGridView1.ClearSelection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            thanhtoan(dangnhap.ID_USER,textBox3.Text,textBox2.Text,label3.Text);
            loaddata();
        }

        private void thanhtoan(string nhanvien,string khach, string sdt, string tongtien) {

            string cmnd = "sp_ThemHoaDon '"+nhanvien+"',N'" + khach + "','"+ sdt +"','"+ tongtien +"'";
            DataTable dt = conn.readdata(cmnd);
            string a = "";
            if (dt != null)
            {
                a = dt.Rows[0][0].ToString();
                for (int i = 0; i < dataGridView2.RowCount; i++)
                {
                    string cm = "sp_ThemHoaDonCT '" + a + "','" + dataGridView2.Rows[i].Cells[0].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[2].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[3].Value.ToString() + "'";
                    bool y = conn.exedata(cm);
                }
                dataGridView2.Rows.Clear();
                MessageBox.Show("Thanh toán thành công số tiền " + label3.Text);
            }

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cochon1 = true;
        }
    }
}
