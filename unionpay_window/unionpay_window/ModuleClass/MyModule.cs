using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;        

namespace unionpay_window.ModuleClass
{
    class MyModule
    {
        #region
        ModuleClass.MyMeans MyDataClass = new unionpay_window.ModuleClass.MyMeans();
        public static string ADDs = "";     //用来存储添加或修改的SQL语句
        public static string FindValue = "";//存储查询条件件       

        #endregion


    }
}
