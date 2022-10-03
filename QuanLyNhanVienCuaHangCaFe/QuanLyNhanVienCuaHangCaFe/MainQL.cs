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
    public partial class MainQL : Form
    {
        public bool isExit = true;
        public event EventHandler Logout;
        public MainQL()
        {
            InitializeComponent();
        }

        private void MainQL_Load(object sender, EventArgs e)
        {

        }




        // ----------------------- Thoát chương trình và Logout ---------------------------

        // Quay lại màn hình đăng nhập  
        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logout(this, new EventArgs()); // Hàm ủy thác 
        }
        // Thoát hoàn toàn khi nhấn vào nút X trên form
        private void MainQL_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (isExit)
                Application.Exit();
        }
        // Thoát khỏi chương trình.(Nút thoát ở Menu)
        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isExit)
                Application.Exit();
        }
        // Thông báo mỗi khi muốn thoát khỏi chương trình.
        private void MainQL_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isExit)
            {
                //Box thống báo thoát chương trình 
                if (MessageBox.Show("Bạn Muốn Thoát Chương Trình", "Thông Báo",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    e.Cancel = true;
            }
        }

       
        //--------------------------------------------------------------------------------------
    }
}
