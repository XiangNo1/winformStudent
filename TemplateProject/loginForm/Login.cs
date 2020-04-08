using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TemplateProject.studentForm;
using TemplateProject.utils;

namespace TemplateProject.loginForm
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void skinButton1_Click(object sender, EventArgs e)
        {
            //获取用户名
            string username = skinTextBox1.Text;
            //获取密码
            string password = skinTextBox2.Text;
            //判断用户名密码是否正确
            string sql = "select * from account where username='" + username + "' and password='" + password + "'";
            DataTable dt = Cdatabase.S.Select(sql);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("登录成功！");
                this.Hide();
                Index studentList = new Index();
                studentList.StartPosition = FormStartPosition.CenterScreen;
                studentList.Show();
            }
            else
            {
                MessageBox.Show("用户名或密码错误！登录失败！");
            }
            
            
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult a = MessageBox.Show("是否确认退出应用程序？", "退出程序", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (a == DialogResult.Yes)
            {
                e.Cancel = false;
                //Application.Exit();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(0);
            this.Dispose();
            this.Close();
        }

        private void skinButton2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("注册功能暂未启用！敬请期待");
        }
    }
}
