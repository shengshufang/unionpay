#include <LPC21XX.H>
#include "stdio.h"			//��ӡɨ��Ⱥ���
#include "confg.h"
//#include "LED_Display.c"
#define FRQCY 12000000		//����12MHz
#define UART_BPS 9600		//������9600

/*
�Զ�����������
*/
typedef unsigned char   uint8_t;     //�޷���8λ��
typedef signed   char   int8_t;      //�з���8λ��
typedef unsigned int    uint16_t;    //�޷���16λ��
typedef signed   int    int16_t;     //�з���16λ��
typedef unsigned long   uint32_t;    //�޷���32λ��
typedef signed   long   int32_t;     //�з���32λ��
typedef float           float32;     //�����ȸ�����
typedef double          float64;     //˫���ȸ�����

uint8_t rcv_buf[15];        //���ջ�����
volatile uint8_t rcv_new; // ���������ݱ�־

void UART0_Init()	        //UART0���ڳ�ʼ������	   
{
	PINSEL0 = (PINSEL0 & (~0X0000000F)) | 0X05;		//��IO�����ӵ�UART0����
	U0LCR	= 0X83;			//�������ò����� ��8λ���ݳ��ȡ�1��ֹͣλ����У��
	U0DLL	= (FRQCY/(16*UART_BPS))%256; //���λ����������
	U0DLM	= (FRQCY/(16*UART_BPS))/256; //���λ
	U0LCR	= 0X03;			//��ֹ�ı䲨����

	U0FCR = 0x81;                       // ʹ��FIFO�������ô�����Ϊ8�ֽ�
    U0IER = 0x01;                       // ����RBR�жϣ��������ж�
}

void __irq  IRQ_UART0 (void)
{
  	uint8_t i;
   
  	if (( U0IIR & 0x0F ) == 0x04 )	
    rcv_new = 1;  // ���ý��յ��µ����ݱ�־
  	for (i=0;i<15; i++)
  		{
    		rcv_buf[i] = U0RBR;  // ��ȡFIFO������
    		delay(2);  //��ʱ     
  		}
  	VICVectAddr = 0x00;         // �жϴ������
}

void UART0_Interrupt(void)	//�жϳ�ʼ��
{
  	VICIntSelect = 0x00000000;  // �������е�ͨ��ΪIRQ�ж�
  	VICVectCntl0 = 0x20 | 0x06;  // UART0���䵽IRQ slot0����������ȼ�
  	VICVectAddr0 = (uint32_t)IRQ_UART0;  //����UART0������ַ
  	VICIntEnable = 1 << 0x06;  // ʹ��UART0�ж�
}

int main(void)
{
	PINSEL0 = 0x00000000;				   //����ѡ��ΪI/O����
	PINSEL1 = 0X00000000;				   //����ѡ��ΪI/O����
	IO0PIN =  1<<30 |SPI_MO | SPI_CS1 | SPI_CLK ;
	IO0DIR =  1<<30 |SPI_MO | SPI_CS1 | SPI_CLK ; //���˿�����Ϊ���
	IO1PIN =  LED_1 | LED_2 | LED_3 | LED_4;
	IO1DIR =  LED_1 | LED_2 | LED_3 | LED_4;

	UART0_Init();

	while(1)
		{
			if(1 == rcv_new)                    // �Ƿ��Ѿ����յ�8 Bytes������  
				{    
					rcv_new = 0;                    // �����־  
                    	if(0x10 ==rcv_buf[0] && 0x11 == rcv_buf[1])  
							{  
								printf("\n������������\n"); 
							}  
						else  
                        	  	  printf("\n������������yeyeyeyeyeyyeyey\n"); 
                            	 
                        	}  
    	}   
	


	return 0;
}
