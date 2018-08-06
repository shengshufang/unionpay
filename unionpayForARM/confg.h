#ifndef COFG_H
#define COFG_H

#define LED_1 1<<16		 //P1.16���ţ�������ܵ�һλ,1����16λ
#define LED_2 1<<17		 //P1.17����  ������ܵڶ�λ
#define LED_3 1<<18		 //P1.18����  ������ܵ���λ
#define LED_4 1<<19		 //P1.19����  ������ܵ���λ��LED�ܽ�

#define SPI_MO  1<<19	//P0.19����, �������/�ӻ����룬595�洢���ܽ�
#define SPI_CS1  1<<20	//P0.20���� �����豸Ƭѡ��
#define SPI_CLK 1<<17	//P0.17���� ��ʱ��
#define SPI_MI  1<<18	//P0.18���� ��MISO(��������/�ӻ����)

#define EN_LED_1 IO1CLR = LED_1	 // LED1����
#define EN_LED_2 IO1CLR = LED_2	 // LED2����
#define EN_LED_3 IO1CLR = LED_3	 // LED3����
#define EN_LED_4 IO1CLR = LED_4	 // LED4����

#define UNEN_LED_1 IO1SET = LED_1 //LED1�ر�
#define UNEN_LED_2 IO1SET = LED_2 //LED2�ر�
#define UNEN_LED_3 IO1SET = LED_3 //LED3�ر�
#define UNEN_LED_4 IO1SET = LED_4 //LED4�ر�

#define LED_ON  IO0CLR =  1<<30;	 //arm LED��
#define LED_OFF IO0SET =  1<<30;	 //arm LED��

#else
#endif
