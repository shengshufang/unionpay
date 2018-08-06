#include <LPC21XX.H>
#include "confg.h"

unsigned char DISP_TAB[16] = 					  //���������0~F
	{ 0XC0, 0XF9,0XA4,0XB0,0X99,0X92,0X82,0XF8,
   		0X80,0X90,0X88,0X83,0XC6,0XA1,0X86,0X8E	};
void Display( unsigned int led_selct, unsigned char data)	   //��ʾ����
{
	unsigned int i;
	unsigned char x = 0x00;
	
	switch(led_selct)				 //ѡ��ڼ����������
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


	IO0CLR = SPI_CS1;						//595�洢�Ĵ������͵�ƽ
	
		for(i=0; i<8; i++)					   //��ȡ8λ����
	{
		x = data & 0x80;				   //ȡ�������λ
		if(x==0)						   //ȡ��������Ϊ0ʱ��
		{
			IO0CLR = SPI_CLK;				
			IO0CLR = SPI_MO;				
			IO0SET = SPI_CLK;				
		}
		else 
		{
			IO0CLR = SPI_CLK;				//���͵�ƽ
			IO0SET = SPI_MO;				//��������1
			IO0SET = SPI_CLK;				//���ߵ�ƽ����������
		}
		
		data = data <<1;				   //������λ��ֱ����8λ����ȫ����λ����λ�Ĵ�����
	}
	IO0SET = SPI_CS1;			  //595�洢�Ĵ������ߵ�ƽ���������ذ����ݷ���洢����	
                                   //  ����洢�Ĵ���
	IO0CLR = SPI_CS1;
}

void delay(unsigned int a)//��ʱ����
{
	for(;a>0;a--);
}

void Data8_Display(unsigned char data)		 //�������ʾһ�ֽ�����
{
	unsigned char data_H = 0;
	unsigned char data_L = 0;
	unsigned int counter_i;
	for(counter_i=0; counter_i<1000; counter_i++)		//��̬ɨ��
	{
		data_H = data >>4;								//�߰�λ
		Display(3,DISP_TAB[data_H]);
		delay(10000);
		UNEN_LED_3;									  

		data_L = data & 0x0f;						  //�Ͱ�λ
		Display(4,DISP_TAB[data_L]);
		delay(10000);
		UNEN_LED_4;
	}
}

