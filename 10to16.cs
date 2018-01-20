

	   byte[] bytData = { 0x21, 0x39, 0x38, 0x30, 0x31, 0x36, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x32, 0x33, 0x33, 0x0A };
	    //虽然存入该数组的是十六进制，但是打印的时候，仍然输出的是十进制,为了让输出也为十六进制，需进行进制转换
            
            for (int i = 0; i < 16; i++)
            {
                string temp = Convert.ToString(bytData[i],16);//十进制转换成十六进制
                if (temp.Length == 1)//比如十六进制A会输出0A
                    temp = "0" + temp;

                Console.Write(temp+" ");
            }
