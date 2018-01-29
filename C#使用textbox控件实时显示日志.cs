/*
用Textbox显示日志信息，需要将Textbox的Multiline设置为True，并设置Readonly设置为True。
显示信息可以采用如下代码：
*/

//1.往Form1中插入一个textbox控件

//2.为控件textbox1添加一个方法，用于写入变量信息
        public void showinfo(System.Windows.Forms.TextBox txtInfo,string info)
        {
            txtInfo.AppendText(info);
            txtInfo.AppendText(Environment.NewLine);
            txtInfo.ScrollToCaret();
        }
//3.使用该方法，例如：
showinfo(textBox1, Convert.ToString("画框'起始点'坐标下标:" + plus_minus.rec.leftIndex));


