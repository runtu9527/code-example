using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SerialPortHelper
{
    public class HexConverter
    {
        #region 格式转换
        /// <summary>
        /// 转换十六进制字符串到字节数组
        /// </summary>
        /// <param name="msg">待转换字符串</param>
        /// <returns>字节数组</returns>
        public static byte[] HexToByte(string msg)
        {
            msg = msg.Replace(" ", "");//移除空格

            //create a byte array the length of the
            //divided by 2 (Hex is 2 characters in length)
            byte[] comBuffer = new byte[msg.Length / 2];
            for (int i = 0; i < msg.Length; i += 2)
            {
                //convert each set of 2 characters to a byte and add to the array
                comBuffer[i / 2] = (byte)Convert.ToByte(msg.Substring(i, 2), 16);
            }

            return comBuffer;
        }

        /// <summary>
        /// 转换字节数组到十六进制字符串
        /// </summary>
        /// <param name="comByte">待转换字节数组</param>
        /// <returns>十六进制字符串</returns>
        public static string ByteToHex(byte[] comByte)
        {
            StringBuilder builder = new StringBuilder(comByte.Length * 3);
            foreach (byte data in comByte)
            {
                builder.Append(Convert.ToString(data, 16).PadLeft(2, '0').PadRight(3, ' '));
            }

            return builder.ToString().ToUpper();
        }

        public static string ByteToString(byte[] InBytes)
        {
            string StringOut = "";
            StringOut = System.Text.Encoding.Default.GetString(InBytes);
            return StringOut;
        }
        public static byte[] StringToByte(string InString)
        {
            //string[] ByteStrings;
            //ByteStrings = InString.Split(" ".ToCharArray());
            //byte[] ByteOut;
            //ByteOut = new byte[ByteStrings.Length - 1];
            //for (int i = 0; i == ByteStrings.Length - 1; i++)
            //{
            //    ByteOut[i] = Convert.ToByte(("0x" + ByteStrings[i]));
            //}
            //return ByteOut;
            byte[] byteArray = null;
            byteArray = System.Text.Encoding.Default.GetBytes(InString);
            return byteArray;
        }

        #endregion
    }
}
