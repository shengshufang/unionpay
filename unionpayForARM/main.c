#include <LPC21XX.H>
#include "stdio.h"			//打印扫描等函数
#include "confg.h"
//#include "LED_Display.c"
#define FRQCY 12000000		//晶振12MHz
#define UART_BPS 9600		//波特率9600

/*
自定义数据类型
*/
typedef unsigned char   uint8_t;     //无符号8位数
typedef signed   char   int8_t;      //有符号8位数
typedef unsigned int    uint16_t;    //无符号16位数
typedef signed   int    int16_t;     //有符号16位数
typedef unsigned long   uint32_t;    //无符号32位数
typedef signed   long   int32_t;     //有符号32位数
typedef float           float32;     //单精度浮点数
typedef double          float64;     //双精度浮点数

uint8_t rcv_buf[15];        //接收缓存区
volatile uint8_t rcv_new; // 接收新数据标志

void UART0_Init()	        //UART0串口初始化函数	   
{
	PINSEL0 = (PINSEL0 & (~0X0000000F)) | 0X05;		//将IO口连接到UART0功能
	U0LCR	= 0X83;			//允许设置波特率 ，8位数据长度。1个停止位，无校验
	U0DLL	= (FRQCY/(16*UART_BPS))%256; //存低位，除数锁存
	U0DLM	= (FRQCY/(16*UART_BPS))/256; //存高位
	U0LCR	= 0X03;			//禁止改变波特率

	U0FCR = 0x81;                       // 使能FIFO，并设置触发点为8字节
    U0IER = 0x01;                       // 允许RBR中断，即接收中断
}

void __irq  IRQ_UART0 (void)
{
  	uint8_t i;
   
  	if (( U0IIR & 0x0F ) == 0x04 )	
    rcv_new = 1;  // 设置接收到新的数据标志
  	for (i=0;i<15; i++)
  		{
    		rcv_buf[i] = U0RBR;  // 读取FIFO的数据
    		delay(2);  //延时     
  		}
  	VICVectAddr = 0x00;         // 中断处理结束
}

void UART0_Interrupt(void)	//中断初始化
{
  	VICIntSelect = 0x00000000;  // 设置所有的通道为IRQ中断
  	VICVectCntl0 = 0x20 | 0x06;  // UART0分配到IRQ slot0，即最高优先级
  	VICVectAddr0 = (uint32_t)IRQ_UART0;  //设置UART0向量地址
  	VICIntEnable = 1 << 0x06;  // 使能UART0中断
}

int main(void)
{
	PINSEL0 = 0x00000000;				   //功能选择为I/O功能
	PINSEL1 = 0X00000000;				   //功能选择为I/O功能
	IO0PIN =  1<<30 |SPI_MO | SPI_CS1 | SPI_CLK ;
	IO0DIR =  1<<30 |SPI_MO | SPI_CS1 | SPI_CLK ; //将端口设置为输出
	IO1PIN =  LED_1 | LED_2 | LED_3 | LED_4;
	IO1DIR =  LED_1 | LED_2 | LED_3 | LED_4;

	UART0_Init();

	while(1)
		{
			if(1 == rcv_new)                    // 是否已经接收到8 Bytes的数据  
				{    
					rcv_new = 0;                    // 清除标志  
                    	if(0x10 ==rcv_buf[0] && 0x11 == rcv_buf[1])  
							{  
								printf("\n来啦来啦来啦\n"); 
							}  
						else  
                        	  	  printf("\n来啦来啦来啦yeyeyeyeyeyyeyey\n"); 
                            	 
                        	}  
    	}   
	


	return 0;
}
