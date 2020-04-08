using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TemplateProject.utils
{
    
    class Cdatabase
    {
        string dbfn;
        private OleDbConnection conn;
        private static Cdatabase s;
        public static Cdatabase S
        {
            get
            {
                if (s == null)
                {
                    s = new Cdatabase();
                    string apppath = Path.GetDirectoryName(Application.ExecutablePath);
                    Cdatabase.S.Init(apppath + "\\utils\\db.mdb");
                }
                
                
                return s;
            }

        }
        //初始化数据库
        public void Init(string dbfn)
        {
            this.dbfn = dbfn;
            string connstr = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source =" + dbfn;
            conn = new OleDbConnection(connstr);
        }

        //返回数据
        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            Console.WriteLine(sql);
            OleDbDataAdapter myAd = new OleDbDataAdapter(sql, conn);
            myAd.Fill(dt);
            myAd.Dispose();
            conn.Close();
            /*foreach (DataRow row in dt.Rows)
            {
                foreach (DataColumn column in dt.Columns)
                {
                    Console.WriteLine(row[column]);
                    Console.WriteLine(row["Email"]);
                }
            }*/

            return dt;
        }

        //执行sql
        public bool Excute(string sql)
        {
            bool f = true;
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            OleDbCommand command = new OleDbCommand(sql, conn);
            
            OleDbTransaction trans = conn.BeginTransaction();
            try
            {
                command.Transaction = trans;
                command.CommandText = sql;
                Console.WriteLine(sql);
                command.ExecuteNonQuery();
                trans.Commit();
            }
            catch (Exception ex)
            {
                f = false;
                trans.Rollback();
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
            return f;

        }

    }
}
