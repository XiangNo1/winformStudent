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

namespace TemplateProject.classForm
{
    public partial class Clazz : Form
    {
        public Clazz()
        {
            InitializeComponent();
            queryClazz();
        }

        public void queryClazz()
        {
            string sql = "select * from clazz ";
            DataTable dt = Cdatabase.S.Select(sql);
            skinDataGridView1.DataSource = dt;
            skinDataGridView1.Columns[0].Visible = false;//隐藏第一列id
        }
    }
}
