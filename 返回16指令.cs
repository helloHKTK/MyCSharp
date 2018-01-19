using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        /* 根据前12位，计算后面3位的CRC值，并返回整个16位命令 */
        //参数为十六进制格式：0x_ _
        public static byte[] getsendCollector(byte ID01, byte ID02, byte PFC01, byte PFC02, byte value08, byte value09, byte value10, byte value11)
        {
            byte[] bytData = new byte[16];
            bytData[0] = 0x21;//命令开始字节
            bytData[1] = ID01;
            bytData[2] = ID02;
            bytData[3] = 0x30;//附加信息(默认为ASCII的0)
            bytData[4] = PFC01;
            bytData[5] = PFC02;
            /* 下标6~11为value(其中高位的6、7设置为前导0[注意:此处的前导0是0x20]，只用后4位) */
            bytData[6] = 0x20;
            bytData[7] = 0x20;
            bytData[8] = value08;
            bytData[9] = value09;
            bytData[10] = value10;
            bytData[11] = value11;

            //计算3位的CRC(12~14位)
            int sum = 0;
            for (int i = 0; i <= 11; i++)//
            {
                int a = bytData[i];
                Console.WriteLine("["+i+"]:"+a);
               
                
                sum += a;
            }
            Console.WriteLine("sum="+sum);

            int remainder = sum % 256;    //取余
            Console.WriteLine("余数=" + remainder);

            int aa = remainder / 100;
            int bb=  remainder / 10 % 10;
            int cc = remainder % 10;


            byte[] buff1 = BitConverter.GetBytes(31 + (aa - 1));
            byte[] buff2 = BitConverter.GetBytes(31 + (bb - 1));
            byte[] buff3 = BitConverter.GetBytes(31 + (cc - 1));
           
            bytData[12] = buff1[0];
            bytData[13] = buff2[0];
            bytData[14] = buff3[0];

            Console.WriteLine(" CRC[12]=" + buff1[0]);
            Console.WriteLine(" CRC[13]=" + buff2[0]);
            Console.WriteLine(" CRC[14]=" + buff3[0]);
            

            bytData[15] = 0x0A;//停止位

            return bytData;
        }
        static void Main(string[] args)
        {
            //(byte ID01, byte ID02, byte PFC01, byte PFC02, byte value08, byte value09, byte value10, byte value11)
            byte[] bytData = getsendCollector(0x30, 0x30, 0x30, 0x31, 0x20, 0x20, 0x20, 0x20);
                       
            Console.WriteLine();
            for (int i = 0; i < 16; i++)
            {
                Console.Write(bytData[i]+"  ");
            }
            Console.ReadKey();
            
        }
    }
}
