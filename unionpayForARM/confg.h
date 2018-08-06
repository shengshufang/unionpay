#ifndef COFG_H
#define COFG_H

#define LED_1 1<<16		 //P1.16引脚，即数码管第一位,1左移16位
#define LED_2 1<<17		 //P1.17引脚  即数码管第二位
#define LED_3 1<<18		 //P1.18引脚  即数码管第三位
#define LED_4 1<<19		 //P1.19引脚  即数码管第四位，LED管脚

#define SPI_MO  1<<19	//P0.19引脚, 主机输出/从机输入，595存储器管脚
#define SPI_CS1  1<<20	//P0.20引脚 ，从设备片选端
#define SPI_CLK 1<<17	//P0.17引脚 ，时钟
#define SPI_MI  1<<18	//P0.18引脚 ，MISO(主机输入/从机输出)

#define EN_LED_1 IO1CLR = LED_1	 // LED1开启
#define EN_LED_2 IO1CLR = LED_2	 // LED2开启
#define EN_LED_3 IO1CLR = LED_3	 // LED3开启
#define EN_LED_4 IO1CLR = LED_4	 // LED4开启

#define UNEN_LED_1 IO1SET = LED_1 //LED1关闭
#define UNEN_LED_2 IO1SET = LED_2 //LED2关闭
#define UNEN_LED_3 IO1SET = LED_3 //LED3关闭
#define UNEN_LED_4 IO1SET = LED_4 //LED4关闭

#define LED_ON  IO0CLR =  1<<30;	 //arm LED亮
#define LED_OFF IO0SET =  1<<30;	 //arm LED灭

#else
#endif
