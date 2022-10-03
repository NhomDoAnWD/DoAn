using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhanVienCuaHangCaFe
{
    public partial class MainNV : Form
    {
        public bool isExit = true;
        public event EventHandler Logout;
        public MainNV()
        {
            InitializeComponent();
        }
        private void MainNV_Load(object sender, EventArgs e)
        {

        }






     //=============================================
     // ----- Đăng xuất, Thoát chương trình --------
     //=============================================   

        // Quay lại màn hình đăng nhập  
        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logout(this,new EventArgs()); // Hàm ủy thác 
        }
        // Thoát hoàn toàn khi nhấn vào nút X trên form
        private void MainNV_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(isExit)
                Application.Exit();
        }
        // Thoát khỏi chương trình.(Nút thoát ở Menu)
        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isExit)
                Application.Exit();
        }
        // Thông báo mỗi khi muốn thoát khỏi chương trình.
        private void MainNV_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(isExit)
            {
                //Box thống báo thoát chương trình 
                if (MessageBox.Show("Bạn Muốn Thoát Chương Trình", "Thông Báo", 
                    MessageBoxButtons.YesNo,MessageBoxIcon.Question) != DialogResult.Yes)
                    e.Cancel = true;
            }
        }

        private void ThongTinNhanVien_Enter(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void cbChucVu_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void txtMucLuong_TextChanged(object sender, EventArgs e)
        {

        }
        //=============================================
    }
}
