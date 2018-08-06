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

using System.IO;




namespace unionpay_window
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();



        }
        private void button_out_Click(object sender, EventArgs e)
        {
           
            if (textbox_licnese_plate.Text == "")   
            {
                MessageBox.Show("请输入车牌号", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                ModuleClass.MyMeans MyData = new ModuleClass.MyMeans();
                SqlDataReader temDR = MyData.getcom("select * from Table_Cars where License_Plate='" + textbox_licnese_plate.Text.Trim() + "'");
                bool ifcom = temDR.Read();
                if (!ifcom)
                {
                    MessageBox.Show("停车场无此车辆", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    In_time_label.Text = temDR["Inport_Time"].ToString();
                    Out_time_label.Text = System.DateTime.Now.ToString();
                    label_license_num.Text = temDR["License_Plate"].ToString();
                    label_name.Text = temDR["Owner_Name"].ToString();
                    label_cartype.Text = temDR["Car_Type"].ToString();
                    label_ID.Text = temDR["Card_ID"].ToString();
                    label_Area.Text = temDR["Area_Type"].ToString();    //更新界面车辆信息

                    MyData.getsqlcom("update Table_Cars set Outprt_Time='" + System.DateTime.Now.ToString() + "' where License_Plate='" + textbox_licnese_plate.Text.Trim() + "'");

                    //初始化数据库 存图片
                //    string picturepath = @"F:\unionpay\IMG_8439.JPG";
                  
                 //   FileStream fs = new FileStream(picturepath, FileMode.Open, FileAccess.Read);

                   // SqlCommand cmd = new SqlCommand("update  Table_Cars(Inport_Image) values(@Inport_Image");
                 //   fs.Position = 0;
                  //  BinaryReader br = new BinaryReader(fs);
                   // byte[] imgByTesin = br.ReadBytes((int)fs.Length);
                   // cmd.Parameters.Add("@Inport_Image", SqlDbType.Image).Value = imgByTesin;   //////***************存储图片存疑？？？？？？？？？？？？
                  //        MyData.getsqlcom("update Table_Cars set Inport_Image='" + imgByTesin + "' where License_Plate='" + textbox_licnese_plate.Text.Trim() + "'");
                    //

                    //读取图片

               //     Byte[] myByte = new Byte[0];
                //    myByte = (Byte[])temDR["Inport_Image"];
               //     if (myByte == null)
                //    {
                //        MessageBox.Show("未查询到图片", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 //   }
                 //   else {
                     //   MessageBox.Show(myByte, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        MemoryStream ms = new MemoryStream(myByte);
                //    pictureBox_in.Image = System.Drawing.Image.FromStream(ms,true);
                 //   this.pictureBox_in.SizeMode = PictureBoxSizeMode.Zoom; }
                    //

                    unionpay_charge fm = new unionpay_charge();
                    fm.label_lincensenum_c.Text = textbox_licnese_plate.Text.Trim();//向子窗口传值
              //     fm.label_outtime_c.Text = Out_time_label.Text;

                    ModuleClass.MyMeans.My_con.Close();
                    ModuleClass.MyMeans.My_con.Dispose();

                    MyData.con_close();
                    fm.Show();                   
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
