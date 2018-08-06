#include <LPC21XX.H>
#include "confg.h"

unsigned char DISP_TAB[16] = 					  //共阳极码表0~F
	{ 0XC0, 0XF9,0XA4,0XB0,0X99,0X92,0X82,0XF8,
   		0X80,0X90,0X88,0X83,0XC6,0XA1,0X86,0X8E	};
void Display( unsigned int led_selct, unsigned char data)	   //显示函数
{
	unsigned int i;
	unsigned char x = 0x00;
	
	switch(led_selct)				 //选择第几个数码管亮
	{
		case 1: 
			EN_LED_1;
			break;
		case 2:
			EN_LED_2;
			break;
		case 3:
			EN_LED_3;
			break;
		case 4:
			EN_LED_4;
			break;
		default:EN_LED_1;
	}


	IO0CLR = SPI_CS1;						//595存储寄存器给低电平
	
		for(i=0; i<8; i++)					   //提取8位数据
	{
		x = data & 0x80;				   //取数据最高位
		if(x==0)						   //取到的数据为0时：
		{
			IO0CLR = SPI_CLK;				
			IO0CLR = SPI_MO;				
			IO0SET = SPI_CLK;				
		}
		else 
		{
			IO0CLR = SPI_CLK;				//给低电平
			IO0SET = SPI_MO;				//输入数据1
			IO0SET = SPI_CLK;				//给高电平，即上升沿
		}
		
		data = data <<1;				   //数据移位，直至把8位数据全部移位到移位寄存器中
	}
	IO0SET = SPI_CS1;			  //595存储寄存器给高电平，即上升沿把数据放入存储器中	
                                   //  存入存储寄存器
	IO0CLR = SPI_CS1;
}

void delay(unsigned int a)//延时函数
{
	for(;a>0;a--);
}

void Data8_Display(unsigned char data)		 //数码管显示一字节数据
{
	unsigned char data_H = 0;
	unsigned char data_L = 0;
	unsigned int counter_i;
	for(counter_i=0; counter_i<1000; counter_i++)		//动态扫描
	{
		data_H = data >>4;								//高八位
		Display(3,DISP_TAB[data_H]);
		delay(10000);
		UNEN_LED_3;									  

		data_L = data & 0x0f;						  //低八位
		Display(4,DISP_TAB[data_L]);
		delay(10000);
		UNEN_LED_4;
	}
}

