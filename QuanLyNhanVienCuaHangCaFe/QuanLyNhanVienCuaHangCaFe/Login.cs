using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Data.SqlClient;

namespace QuanLyNhanVienCuaHangCaFe
{
    //-----------------------------------------------------  Menu  Đăng nhập -----------------------------------------------------------------
    public partial class Login : Form
    {       
        public Login()
        {
            InitializeComponent();                         
        }
        private void Login_Load(object sender, EventArgs e)
        {

        }
        
        //Đăng nhập vào chương trình 
        private void bttDangNhap_Click(object sender, EventArgs e)
        {                    
                if (KiemTraRong())
                {
                    if (kiemTraTK() == 1)
                    {
                        MessageBox.Show("Đăng Nhập Vào Quyền Admin");
                        // ---------  Form Nhân Quản Lý ---------------
                        MainQL mainQL = new MainQL();
                        mainQL.Show();
                        this.Hide();
                        mainQL.Logout += MainQL_Logout;
                    }
                    else 
                    {
                        if (kiemTraTKNhanVien() == 1)
                        {
                            // ---------  Form Nhân Viên ---------------
                            MainNV mainNV = new MainNV(); // Khởi tạo form 
                            mainNV.Show(); // Show form
                            this.Hide(); // Ẩn đi form đăng nhập 
                            mainNV.Logout += MainNV_Logout;// Được úy thác từ form nhân viên qua
                            // -----------------------------------------       
                        }
                        else 
                            {
                                if (kiemTraTKQuanLy() == 1)
                                {
                                MessageBox.Show("Đăng Nhập Vào Quyền Quản Lý");
                                // ---------  Form Nhân Quản Lý ---------------
                                MainQL mainQL = new MainQL();
                                mainQL.Show();
                                this.Hide();
                                mainQL.Logout += MainQL_Logout;
                                }
                            else
                            {
                                MessageBox.Show("Vui Lòng Kiểm Tra Lại Tài Khoản Hoặc Mật Khẩu !!!");
                            }
                        }
                        

                    }               
                    
                }                                                            
        }
        
        private int kiemTraTKQuanLy()
        {
            int kiemTraTK = 0;
            SqlConnection comn = new SqlConnection(@"Data Source=DESKTOP-GOAP9O5;Initial Catalog=QLNhanVien;Integrated Security=True");
            comn.Open();
            string tk = txtTaiKhoan.Text;
            string mk = txtMatKhau.Text;
            string cv = "Quản Lý";
            string sql = "select *from DangNhap where TaiKhoan = '" + tk + "'  and MatKhau = '" + mk + "'and ChucVu = '" + cv + "' and TrangThai = '" + "True" + "'  ";
            SqlCommand cmd = new SqlCommand(sql, comn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read() == true)
            {
                return kiemTraTK = 1;
            }
            return kiemTraTK;
        }
        private int kiemTraTKNhanVien()
        {
            int kiemTraTK = 0;
            SqlConnection comn = new SqlConnection(@"Data Source=DESKTOP-GOAP9O5;Initial Catalog=QLNhanVien;Integrated Security=True");
            comn.Open();
            string tk = txtTaiKhoan.Text;
            string mk = txtMatKhau.Text;
            string sql = "select *from DangNhap where TaiKhoan = '" + tk + "'  and MatKhau = '" + mk + "'and ChucVu = '" + "Nhân Viên" + "' and TrangThai = '" + "True" + "'  ";
            SqlCommand cmd = new SqlCommand(sql, comn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read() == true)
            {
                return kiemTraTK = 1;
            }
            return kiemTraTK;
        }
        private int kiemTraTK()
        {
            int kiemTraTK = 0;
            SqlConnection comn = new SqlConnection(@"Data Source=DESKTOP-GOAP9O5;Initial Catalog=QLNhanVien;Integrated Security=True");
            comn.Open();
            string tk = txtTaiKhoan.Text;
            string mk = txtMatKhau.Text;
            string sql = "select *from DangNhap where TaiKhoan = '" + tk + "'  and MatKhau = '" + mk + "'and ChucVu = '" + "admin" + "' and TrangThai = '" + "True" + "'  ";
            SqlCommand cmd = new SqlCommand(sql, comn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read() == true)
            {
                return kiemTraTK = 1;
            }                                   
            return kiemTraTK;
        }
        // Kiểm tra rỗng khi nhập       
        private bool KiemTraRong()
        {
            if (txtTaiKhoan.Text == "")
            {
                MessageBox.Show("Vui Nhap Tai Khoan", "Thông báo", MessageBoxButtons.OK);
                return false;
            }
            else if (txtMatKhau.Text == "")
            {
                MessageBox.Show("Vui Nhap Mat Khau", "Thông báo", MessageBoxButtons.OK);
                return false;
            }
            return true;
        }

        //=============================================
        //-- Check box thì sẽ hiện thị ra mật khẩu ----
        //=============================================
        private void checkHienThiMK_CheckedChanged(object sender, EventArgs e)
        {
            if (checkHienThiMK.Checked)
            {
                txtMatKhau.UseSystemPasswordChar = false;  // txtMatKhau đang được thiết lập bên winform là UseSystemPasswordChar = true. Khi chọn vào checkbox thì nó sẽ chuyển thành fales
            }
            else
            {
                txtMatKhau.UseSystemPasswordChar = true; // ngược lại không chọn thì txtMatKhau.UseSystemPasswordChar = true .Ẩn đi mật khẩu 
            }
        }
     //=============================================



     //=============================================
     // ----- Đăng xuất, Thoát chương trình --------
     //=============================================

        // Logout khỏi chương trình nhân viên, quay lại phần login 
        private void MainNV_Logout(object sender, EventArgs e)
        {
            (sender as MainNV).isExit = false; // Chuyển hàm bool bên MainNV thành false, thay vì sẽ thoát khỏi chương trình thì sẽ chỉ là đăng xuất
            (sender as MainNV).Close(); // Đóng cửa số form MainNV
            this.Show(); // show lại cửa số hàm login
        }

        // Logout khỏi chương trình quản lý, quay lại phần login 
        private void MainQL_Logout(object sender, EventArgs e)
        {
            (sender as MainQL).isExit = false; // Chuyển hàm bool bên MainQL thành false, thay vì sẽ thoát khỏi chương trình thì sẽ chỉ là đăng xuất
            (sender as MainQL).Close(); // Đóng cửa số form MainQL
            this.Show(); // show lại cửa số hàm login
        }

        //Thoát khỏi menu đăng nhập 
        private void bttThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
     //=============================================
     //----------------------------------------------------------------------------------------------------------------------------------------------
    }
}
