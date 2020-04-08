using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TemplateProject.utils;

namespace TemplateProject.studentForm
{
    public partial class StudentList : Form
    {
        public StudentList()
        {
            InitializeComponent();
            queryStudent();
        }


        public void queryStudent()
        {
            string sql = "select t1.*,t2.classname from student t1 left join clazz t2 on t1.clazz=t2.ID where t1.stuname like '%" + skinWaterTextBox1.Text + "%'";
            DataTable dt = Cdatabase.S.Select(sql);
            skinDataGridView1.DataSource = dt;
            skinDataGridView1.Columns[0].Visible = false;//隐藏第一列id
        }

        private void skinButton4_Click(object sender, EventArgs e)
        {
            queryStudent();
        }

        private void skinButton1_Click(object sender, EventArgs e)
        {
            //让用户选择是否考勤
            MessageBoxButtons btn = MessageBoxButtons.YesNoCancel;
            if (MessageBox.Show("确定要考勤一次吗？", "考勤一次", btn) == DialogResult.Yes)
            {
                int i = this.skinDataGridView1.CurrentRow.Index;
                
                Object id = skinDataGridView1.Rows[i].Cells[0].Value;
                Object kq = skinDataGridView1.Rows[i].Cells[5].Value;
                if (Convert.ToInt32(kq) <= 0)
                {
                    MessageBox.Show("剩余上课次数不足，不能考勤！");
                    return;
                }
                string sql = "update student set stulast=stulast-1 where id = " + id + " ";

                bool f = Cdatabase.S.Excute(sql);
                if (f)
                {
                    MessageBox.Show("考勤成功");
                }
                else
                {
                    MessageBox.Show("考勤失败");
                }
                queryStudent();
            }
        }

        private void skinButton3_Click(object sender, EventArgs e)
        {
            //让用户选择是否删除
            MessageBoxButtons btn = MessageBoxButtons.YesNoCancel;
            if (MessageBox.Show("确定要删除数据吗？", "删除数据", btn) == DialogResult.Yes)
            {
                int i = this.skinDataGridView1.CurrentRow.Index;
                Object id = skinDataGridView1.Rows[i].Cells[0].Value;
                string sql = "delete from student where id = " + id + " ";

                bool f = Cdatabase.S.Excute(sql);
                if (f)
                {
                    MessageBox.Show("删除成功");
                }
                else
                {
                    MessageBox.Show("删除失败");
                }
                queryStudent();
            }
        }

        private void skinButton2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("没想到吧！这个功能还没做呢");
        }
    }
}
