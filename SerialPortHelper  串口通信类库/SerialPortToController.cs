using SerialPortHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

///与控制器通信，串口方式
namespace SerialPortHelper
{
    public class SerialPortController
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern void OutputDebugString(string message);

        /// <summary>
        /// 单位：0.1S
        /// </summary>
        private static int TimeOut = 300;//单位ms

        public static string readstring = string.Empty;
        private static Dictionary<string, SerialPortUtil> dictionarySerialPort = new Dictionary<string, SerialPortUtil>();

        public static void SetTimeOut(int timeout)
        {
            TimeOut = timeout;
        }
        public static int GetTimeOut()
        {
            return TimeOut;
        }
        public static string SendCMDStrToController(string cmdString, string strCom, int nBaudrate)
        {
            return SendCMDStrToController(Encoding.Default.GetBytes(cmdString), strCom, nBaudrate);
        }

        private static object ojbSend = new object();
        public static string SendCMDStrToController(byte[] bytes, string strCom, int nBaudrate, int nCount = 0, int nOffset = 0)
        {
            SerialPortUtil serialPort;
            if (strCom == null)
            {
                return null;
            }
            try
            {
                lock (ojbSend)
                {

                    //1.初始化串口
                    if (false == InitSerialPort(strCom, out serialPort, nBaudrate))
                    {
                        return null;
                    }
                    serialPort.DiscardBuffer();

                    //2.发送数据
                    string strSendCMD = Encoding.ASCII.GetString(bytes, 0, bytes.Length);
                    PrintLog.LogText(string.Format("{0} Send: {1}", strCom, strSendCMD));

                    readstring = string.Empty; //清空接收缓冲区
                    Thread SendCmdToControllerThread = new Thread(() =>
                    {
                        try
                        {
                            if (!serialPort.IsOpen)
                            {
                                serialPort.OpenPort();
                            }
#if TEST
#else
                            serialPort.DataReceived += new DataReceivedEventHandler(serialPort_DataReceived);
#endif
                            readstring = string.Empty;
                            //写数据
                            if (nCount == 0 && nOffset == 0)
                            {
                                serialPort.WriteData(bytes);
                            }
                            else
                            {
                                serialPort.WriteData(bytes, nOffset, nCount);
                            }
                        }
                        catch (Exception ex)
                        {

                            if (serialPort != null && serialPort.IsOpen)  //关闭端口
                            {
                                serialPort.ClosePort();
                            }
                            dictionarySerialPort.Remove(strCom);
                            serialPort = null;
                        }
                        finally
                        {
                            if (serialPort != null)
                            {
                                if (serialPort.IsOpen == true)
                                    serialPort.ClosePort();
                            }

                            serialPort = null;
                        }
                    });

                    SendCmdToControllerThread.IsBackground = true;
                    SendCmdToControllerThread.Start();

                    //根据命令与底层控制器之间的繁忙时间，适当增加延时,一般不用

                    ReceiveDataTimeOut(bytes);
                    

                    //回读数据超时，已经等到数据，返回
                    if (string.Empty == readstring)
                    {
                        return null;
                    }
                    PrintLog.LogText(string.Format("{0} Receive :{1}",strCom, readstring));
                }
            }
            catch (System.ArgumentNullException ex)
            {
                PrintLog.LogText(string.Format("{0} Receive Error: ArgumentNullException",strCom));
                return null;
            }
            catch (Exception e)
            {
                PrintLog.LogText(string.Format("{0} Receive Error: Exception",strCom));
                return null;
            }
            return readstring;
        }

        public static void serialPort_DataReceived(DataReceivedEventArgs e)
        {
#if TEST
            readstring = string.Empty;
#else
            //readstring = Regex.Match(e.DataReceived, @"[<]{1}[\s\S]*[>]{1}").ToString();
            readstring = e.DataReceived;
#endif
        }

        /// <summary>
        /// 初始化串口
        /// </summary>
        private static bool InitSerialPort(string strCom, out SerialPortUtil serialPort, int nBaudrate)
        {
            if (dictionarySerialPort.ContainsKey(strCom))   //是否存在串口
            {
                serialPort = dictionarySerialPort[strCom];
            }
            else
            {
                serialPort = new SerialPortUtil(strCom, nBaudrate.ToString(), "0", "8", "1");
                dictionarySerialPort.Add(strCom, serialPort);
            }

            if (serialPort == null)
            {
                return false;
            }

            return true;
        }




        /// <summary>
        /// 根据命令与底层控制器之间的繁忙时间，适当增加延时
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        private static int ReceiveDataTimeOut(byte[] bytes)
        {
            int count = GetTimeOut();   //超时时间
            string strSendCMD = Encoding.ASCII.GetString(bytes, 0, bytes.Length);

            //默认超时时间
            if (bytes.Length < 1000)
            {
                //作用，根据命令类型定义延时时间,增加灵活性
                if (strSendCMD.IndexOf("<open,") >= 0)       //发送开窗操作
                {
                    count = 80;
                }
                else if (strSendCMD.IndexOf("<shut,") >= 0)  //关窗操作
                {
                    count = 80;
                }
                else if (strSendCMD.IndexOf("<move,") >= 0)   //移动窗口
                {
                    count = 50;
                }
                else if (strSendCMD.IndexOf("<winf,") >= 0)   //此指令表示将指定显示墙组的所有窗口信息列出来。
                {
                    count = 900;
                }
                else if (strSendCMD.IndexOf("<edgeshift,") >= 0)
                {
                    count = 40;
                }
                else if (strSendCMD.IndexOf("<fontset,") >= 0)
                {
                    count = 200;
                }
                else if (strSendCMD.IndexOf("<wallinf,") >= 0)  //1.6.1	查询显示墙组信息指令
                {
                    count = 300;
                }
                else if (strSendCMD.IndexOf("<sync_subsrc") >= 0)
                {
                    count = 250;
                }
                else if (strSendCMD.IndexOf("<ctrcmdbox,") >= 0 || strSendCMD.IndexOf("<ctrscreen,") >= 0)
                {
                    count = 100;
                }
                else if (strSendCMD.IndexOf("<piclock,") >= 0)
                {
                    count = 50;
                }
                else if (strSendCMD.IndexOf("<checkpower") >= 0)    //电源检测回读
                {
                    count = 50;
                }
                else if (strSendCMD.IndexOf("<edgestate,") >= 0)
                {
                    count = 60;
                }
                else if (strSendCMD.IndexOf("<nandinf>") >= 0)   //查询底图及字幕存储空间信息
                {
                    count = 800;
                }
                else if (strSendCMD.IndexOf("<call,") >= 0)      //情景轮询排队等待时间
                {
                    count = 80;
                }
                else if (strSendCMD.IndexOf("<movz,") >= 0)
                {
                    System.Threading.Thread.Sleep(150);
                    count = 50;
                }
                else if (strSendCMD.IndexOf("<outget,") >= 0)
                {
                    count = 20;
                }
                else if (strSendCMD.IndexOf("heart") >= 0)
                {
                    count = 20;
                }
                else if (strSendCMD.IndexOf("<vdnetstateinf>") >= 0) //查询解码设备各通道解码状态,将当前控制器处理上的所有解码通道状态罗列出（由主控板主动查询）
                {
                    count = 200;
                }
                else if (strSendCMD.IndexOf("<vdnetipcmatrix>") >= 0) //返回解码设备各通道解码状态
                {
                    count = 200;
                }
                else if (strSendCMD.IndexOf("<bitchange,") >= 0)
                {
                    count = 100;
                }
                else if (strSendCMD.IndexOf("<vdnetipcrsp,") >= 0)
                {
                    count = 150;
                }
                else
                {
                    count = 100;
                }

            }

            //延时操作
            while (count > 0 && string.Empty == readstring)
            {
                System.Threading.Thread.Sleep(1);
                count--;
            }

            return count;
        }




        public static bool Connect(string strCom, int nBaudrate)
        {
            SerialPortUtil serialPort;
            try
            {
                string[] coms = SerialPortUtil.GetComList();
                if (!coms.Contains(strCom))
                {
                    string str = string.Format("未找到串口:{0}", strCom);
                    PrintLog.LogText(string.Format(str));
#if TEST
                    OutputDebugString(str);
#endif
                    return false;
                }

                if (dictionarySerialPort.ContainsKey(strCom))
                {
                    serialPort = dictionarySerialPort[strCom];
                }
                else
                {
                    serialPort = new SerialPortUtil(strCom, nBaudrate.ToString(), "0", "8", "1");
                    dictionarySerialPort.Add(strCom, serialPort);
                }

                serialPort.OpenPort();
            }
            catch
            {
                return false;
            }

            if (serialPort.IsOpen)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public static bool Disconnect(string strCom)
        {
            if (dictionarySerialPort.ContainsKey(strCom))
            {
                SerialPortUtil serialPort;
                serialPort = dictionarySerialPort[strCom];
                if (serialPort.IsOpen)
                {
                    serialPort.ClosePort();
                }

                if (serialPort.IsOpen)
                {
                    return false;
                }
                else
                {
                    serialPort = null;
                    dictionarySerialPort.Remove(strCom);
                    return true;
                }
            }
            else
            {
                foreach (string key in dictionarySerialPort.Keys)
                {
                    SerialPortUtil serialPort;
                    serialPort = dictionarySerialPort[key];
                    if (serialPort.IsOpen)
                    {
                        serialPort.ClosePort();
                    }
                    else
                    {
                        serialPort.ClosePort();
                    }
                }
                return true;
            }
        }

        private class PrintLog
        {
            public static string logFile = System.Windows.Forms.Application.StartupPath + "\\SerialPortLog.txt";
            private static Object thisLock = new object();

            /// <summary>
            /// 写日志
            /// </summary>
            /// <param name="strText">日志文本，按行写入</param>
            /// <param name="filepath">写入地址，默认为System.Windows.Forms.Application.StartupPath + "\\SerialPortLog.txt"</param>
            public static void LogText(string strText,string filepath = null)
            {
                //#if TEST
                lock (thisLock)
                {
                    if (filepath == null)
                    {
                        using (System.IO.StreamWriter sw = new System.IO.StreamWriter(logFile, true))
                        {
                            sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + ":" + strText + "\r\n");
                        }
                    }
                    else
                    {
                        using (System.IO.StreamWriter sw = new System.IO.StreamWriter(filepath, true))
                        {
                            sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + ":" + strText + "\r\n");
                        }
                    }
                  
                }
                //#endif
            }
        }
    }
}
