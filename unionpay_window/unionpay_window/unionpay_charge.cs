using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO.Ports;//获取IO口


namespace unionpay_window
{
    public partial class unionpay_charge : Form
    {
        public unionpay_charge()
        {
            InitializeComponent();
        }
        private SerialPort ComDevice = new SerialPort();//实例化一个端口device
        //
        //
        //初始化串口
        //
        //
        public void InitPort()
        {
            string[] com_str = SerialPort.GetPortNames();
            if (com_str == null)
            {
                MessageBox.Show("本机没有串口！", "Error");
                return;
            }
            else
            {
                ComDevice.PortName = "COM3";//com_str.ToString();    // 串口名
                ComDevice.BaudRate = 9600;                  //波特率
                ComDevice.DataBits = 8;                     //数据位
                ComDevice.StopBits = StopBits.One;          //停止位
                ComDevice.Parity = Parity.None;             //有无奇偶校验
                if (ComDevice.IsOpen == false) {
                    ComDevice.Open();
                }                                             //若串口关闭，打开串口
//向ComDevice.DataReceived（是一个事件）注册一个方法Com_DataReceived，当端口类接收到信息时时会自动调用Com_DataReceived方法
                ComDevice.DataReceived += new SerialDataReceivedEventHandler(Com_DataReceived);
            }
        }
        //
        //
        //接收数据后执行
        //
        //
        private void Com_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //开辟接收缓冲区
            byte[] ReDatas = new byte[ComDevice.BytesToRead];
            //从串口读取数据
            ComDevice.Read(ReDatas, 0, ReDatas.Length);
            //数据解析
            if(ReDatas!=null)
            {
                MessageBox.Show("接收成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("没有接收", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        //
        //
        //向串口发送数据函数
        //
        //
        public bool SendData(byte[] data)
        {
            if (ComDevice.IsOpen)
            {
                ComDevice.Write(data, 0, data.Length);
                return true;
            }
            else
            {
                return false;
            }
        }
        //
        //
        //字符串转十六进制字节数组
        private byte[] strToHexByte(string hexString)
        {
            hexString = hexString.Replace(" ", "");
            if ((hexString.Length % 2) != 0)
                hexString += " ";
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2).Replace(" ", ""), 16);
            return returnBytes;
        }
        //
        //
        //计算停车时间
        //
        //
        public static TimeSpan Ts(DateTime DateTime1, DateTime DateTime2)
       {   //计算停车时间，返回timespan，并用在金额计算上
          
            TimeSpan ts1 = new TimeSpan(DateTime1.Ticks);
           TimeSpan ts2 = new TimeSpan(DateTime2.Ticks);
            TimeSpan ts = ts1.Subtract(ts2).Duration();
        //  dateDiff = ts.Days.ToString() + "天" + ts.Hours.ToString() + "小时" + ts.Minutes.ToString() + "分钟" + ts.Seconds.ToString() + "秒";
          return ts;
       }
        //
        //
        //计算收费金额
        //
        //
        public static int amount_of_money(TimeSpan ts_money,string car_type,string area_type)
        { //计算收费金额
            int money=0;
            if (ts_money.Days==0&&ts_money.Hours==0&&ts_money.Minutes < 15)
            {//小于十五分钟,经济区免费，商务区收费五元
                switch(area_type)
                {
                    case "A":money = 0;break;
                    case "B":money = 5;break;
                }
                
            }
            else {
                if (ts_money.Days == 0 && ts_money.Hours == 0 && ts_money.Minutes >= 15 && ts_money.Minutes <= 30)
                {//首半小时收费
                    if (area_type == "A")
                    {
                        switch (car_type)
                        {
                            case "A": money = 4; break;
                            case "B": money = 5; break;
                            default: money = 6; break;
                        }
                    }
                    else
                    {
                        money = 5;
                    }
                }
                else {
                    int count = ts_money.Minutes / 30 + 1 + ts_money.Hours * 2;//多少个半小时
                    int sum_day_money;//存不满一天部分收费金额
                    if (area_type == "A")
                    {    //经济区
                        switch (car_type)
                        {
                            case "A":
                                {
                                    sum_day_money = 4 + 3 * (count - 1);
                                    if (sum_day_money > 40)
                                    {//一天收费上限金额为40，超出按40计
                                         money = 40 + ts_money.Days * 40;
                                    }
                                    else { money = ts_money.Days * 40 + sum_day_money; }
                                }
                                break;
                            case "B":
                                {
                                    sum_day_money = 5 + 4 * (count - 1);
                                    if (sum_day_money > 50)
                                    {
                                        money = 50 + ts_money.Days * 50;
                                    }
                                    else {
                                        money = ts_money.Days * 50 + sum_day_money;
                                    }
                                }
                                break;
                            default: {
                                    sum_day_money =6 +5 * (count - 1);
                                    if (sum_day_money > 60)
                                    {
                                        money = 60 + ts_money.Days * 60;
                                    }
                                    else
                                    {
                                        money = ts_money.Days * 60 + sum_day_money;
                                    }
                                }
                                break;
                        }
                    }
                    else {//商务区
                        sum_day_money = 5 + 5 * (count - 1);
                        if (sum_day_money > 100)
                        {
                            money = 100 + ts_money.Days * 100;
                        }
                        else
                        {
                            money = ts_money.Days * 100 + sum_day_money;
                        }
                    }
                }
                
            }
            return money;
      }
        //
        //
        //
        //加载窗体
        //
        //
        private void unionpay_charge_Load(object sender, EventArgs e)
        {
            ModuleClass.MyMeans MyData = new ModuleClass.MyMeans();

            SqlDataReader ucDR = MyData.getcom("select * from Table_Cars where License_Plate='" + label_lincensenum_c.Text + "'");
            bool ifcom = ucDR.Read();
            label_outtime_c.Text = ucDR["Outprt_Time"].ToString();
            label_intime_c.Text = ucDR["Inport_Time"].ToString();    //从数据库获取入场时间
            
            label_cartype_c.Text = ucDR["Car_Type"].ToString();
            label_area_c.Text = ucDR["Area_Type"].ToString();

            DateTime out_time = Convert.ToDateTime(ucDR["Outprt_Time"].ToString());
            DateTime in_time = Convert.ToDateTime(ucDR["Inport_Time"].ToString());
            label7_sumtime.Text = Ts(in_time, out_time).Days.ToString() + "天" + Ts(in_time, out_time).Hours.ToString() + "小时" + Ts(in_time, out_time).Minutes.ToString() + "分钟" + Ts(in_time, out_time).Seconds.ToString() + "秒";  //获取停车时间

            //获取收费金额
            label_chargenum.Text = amount_of_money(Ts(in_time, out_time), ucDR["Car_Type"].ToString(), ucDR["Area_Type"].ToString()).ToString() +"元";

            InitPort();//在窗体加载时初始化串口
        }
        //
        //
        //收费按钮
        //
        //
        private void button_charge_Click(object sender, EventArgs e)
        {
           byte[] sendData = null;
           sendData = strToHexByte("F3");
           SendData(sendData);
            if (this.SendData(sendData))
            {
                MessageBox.Show("成功发送", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
           }


        }
    }

}
