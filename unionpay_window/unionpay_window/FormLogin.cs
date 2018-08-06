using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;

namespace unionpay_window
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }
        private void textName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
                textPass.Focus();
        }
        private void textPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
                buttonLogin.Focus();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            ModuleClass.MyMeans MyClass = new ModuleClass.MyMeans();
            if (textName.Text != "" & textPass.Text != "")
            {
                SqlDataReader temDR = MyClass.getcom("select * from Table_Login where Name='" + textName.Text.Trim() + "'and Password='" + textPass.Text.Trim() + "'");
                bool ifcom = temDR.Read();   //用Read方法读取数据

                if (ifcom)
                {
                    ModuleClass.MyMeans.Login_Name = textName.Text.Trim();
                    ModuleClass.MyMeans.Login_ID = temDR.GetString(0);
                    ModuleClass.MyMeans.My_con.Close();
                    ModuleClass.MyMeans.My_con.Dispose();
              //         ModuleClass.MyMeans.Login_n = (int)(this.Tag);
                    MessageBox.Show("登录成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    MainForm fm = new MainForm();
                    fm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("用户名或密码错误！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textName.Text = "";
                    textPass.Text = "";

                }
                MyClass.con_close();

            }
            else
                MessageBox.Show("请将登录信息填写完整！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
 