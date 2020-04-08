using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TemplateProject.classForm;

namespace TemplateProject.studentForm
{
    public partial class Index : Form
    {
        private StudentList studentList;
        private Clazz clazz;
        public Index()
        {
            InitializeComponent();
        }


        private void Index_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(0);
            this.Dispose();
            this.Close();
        }

        private void IndexFormClosing(object sender, FormClosingEventArgs e)
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

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("没想到吧！这里什么也没有！");
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("没想到吧！这里什么也没有！");
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult a = MessageBox.Show("是否确认退出应用程序？", "退出程序", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (a == DialogResult.Yes)
            {
                System.Environment.Exit(0);
                this.Dispose();
                this.Close();
            }
            else
            {
                
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("没想到吧！这里什么也没有！");
        }

        private void skinButton1_Click(object sender, EventArgs e)
        {
            skinSplitContainer1.Panel2.Controls.Clear();  // 清空原有的控件
            studentList.TopLevel = false;  // 非顶级窗口
            studentList.FormBorderStyle = FormBorderStyle.None;  // 不显示标题栏
            studentList.Dock = System.Windows.Forms.DockStyle.Fill;  // 填充panel
            skinSplitContainer1.Panel2.Controls.Add(studentList);  // 添加学生窗体
            studentList.Show();
        }

        private void Index_Load(object sender, EventArgs e)
        {
            //初始化内容
            studentList = new StudentList();
            clazz = new Clazz();
        }

        private void skinButton2_Click(object sender, EventArgs e)
        {
            skinSplitContainer1.Panel2.Controls.Clear();  // 清空原有的控件
            clazz.TopLevel = false;  // 非顶级窗口
            clazz.FormBorderStyle = FormBorderStyle.None;  // 不显示标题栏
            clazz.Dock = System.Windows.Forms.DockStyle.Fill;  // 填充panel
            skinSplitContainer1.Panel2.Controls.Add(clazz);  // 添加学生窗体
            clazz.Show();
        }
    }
}
