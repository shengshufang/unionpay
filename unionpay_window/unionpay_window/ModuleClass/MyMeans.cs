using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace unionpay_window.ModuleClass
{
    class MyMeans
    {
        #region

        public static string Login_ID = "";        //记录登录的用户编号
        public static string Login_Name = "";      //记录当前登录的用户名
        //记录窗体表名，SQL语句以及要添加和修改的字段名
        public static string Mean_SQL = "", Mean_Table = "", Mean_Field = "";
        //定义一个SqlConnection类型的静态公共变量My_con，用于判断数据库是否连接成功
        public static SqlConnection My_con;

        public static string M_str_sqlcon = "Data Source=PC201508281305;Database=db_unionpay;User id=sa;PWD=";

        public static int Login_n = 0;          //用户登录与重新登录的标识
        //存储车辆基本信息表中的SQL语句
        public static string AllSql = "Select * from Table_Cars";
        #endregion 

        public static SqlConnection getcon()
        {   //打开数据库连接
            My_con = new SqlConnection(M_str_sqlcon);
            My_con.Open();
            return My_con;
        }

        public void con_close()
        {   //关闭数据库连接
            if (My_con.State == System.Data.ConnectionState.Open) {
                My_con.Close();
                My_con.Dispose();
            }
        }

        public SqlDataReader getcom(string SQLstr)
        {//获取数据库中信息
            getcon();
            SqlCommand My_com = My_con.CreateCommand();
            My_com.CommandText = SQLstr;
            SqlDataReader My_read = My_com.ExecuteReader();
            return My_read;
        }

        public void getsqlcom(string SQLstr)
        {    //操作数据库
            getcon();
            SqlCommand SQLcom = new SqlCommand(SQLstr, My_con);
            SQLcom.ExecuteNonQuery();
            SQLcom.Dispose();
            con_close();
        }

        public DataSet getDataSet(string SQLstr,string tableName)
        {
            getcon();
            SqlDataAdapter SQLda = new SqlDataAdapter(SQLstr, My_con);
            DataSet My_DataSet = new DataSet();
            SQLda.Fill(My_DataSet, tableName);
            con_close();
            return My_DataSet;   
        }
    }
}
