

			byte[] bytData = { 0x21, 0x39, 0x38, 0x30, 0x31, 0x36, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x32, 0x33, 0x33, 0x0A };
			//��Ȼ������������ʮ�����ƣ����Ǵ�ӡ��ʱ����Ȼ�������ʮ����,Ϊ�������ҲΪʮ�����ƣ�����н���ת��
            for (int i = 0; i < 16; i++)
            {
                string temp = Convert.ToString(bytData[i],16);//ʮ����ת����ʮ������
                if (temp.Length == 1)//����ʮ������A�����0A
                    temp = "0" + temp;

                Console.Write(temp+" ");
            }