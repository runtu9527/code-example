using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace ConsoleTest
{
    class Program
    {
        static int sendPort = 0x7777;
        static string sendIP = "239.114.114.114";
        static int receivePort = 0x7778;
        static string sendDate = "SearchDevice";
        static void Main(string[] args)
        {
            //接收组播数据
            Thread t = new Thread(new ThreadStart(RecvThread));
            t.IsBackground = true;
            t.Start();

            //向组播发送数据
            IPEndPoint ipend = new IPEndPoint(IPAddress.Any, receivePort);
            UdpClient client = new UdpClient(ipend);
            client.EnableBroadcast = false;
            client.JoinMulticastGroup(IPAddress.Parse(sendIP));
            IPEndPoint multicast = new IPEndPoint(IPAddress.Parse(sendIP), sendPort);
            byte[] buf = Encoding.Default.GetBytes(sendDate);
            
            client.Send(buf, buf.Length, multicast);


            //Console.ReadLine();
            //异步接收数据
            //client.BeginReceive(new AsyncCallback(ReceiveBack), client);

            //设置网络超时时间,一段时间未接收到数据时自动退出
            //client.Client.ReceiveTimeout = 150;

            //单播接收数据
            try
            {
                while (true)
                {
                    byte[] value = client.Receive(ref ipend);

                    TransData data = BytesToStruct<TransData>(value, 0, value.Length);
                    IPStruct ipData = BytesToStruct<IPStruct>(data.Data, 0, data.Data.Length);
                    string msg = new string(ipData.IpAddr).Replace("\0", "");
                    Console.WriteLine(msg);
                    //Console.WriteLine(ipend.Address.ToString());
                }
            }
            catch
            {
                if (client != null)
                {
                    client.Close();
                    client = null;
                }
                return;
            }
        }




        /// <summary>
        /// 将byte[]还原为指定的struct,该函数的泛型仅用于自定义结构
        /// startIndex：数组中 Copy 开始位置的从零开始的索引。
        /// length：要复制的数组元素的数目。
        /// </summary>
        public static T BytesToStruct<T>(byte[] bytes, int startIndex, int length)
        {
            if (bytes == null) return default(T);
            if (bytes.Length <= 0) return default(T);
            IntPtr buffer = Marshal.AllocHGlobal(length);
            try//struct_bytes转换
            {
                Marshal.Copy(bytes, startIndex, buffer, length);
                return (T)Marshal.PtrToStructure(buffer, typeof(T));
            }
            catch (Exception ex)
            {
                throw new Exception("Error in BytesToStruct ! " + ex.Message);
            }
            finally
            {
                Marshal.FreeHGlobal(buffer);
            }
        }
    
        static void RecvThread()
        {
            //绑定组播端口   
            UdpClient client = new UdpClient(sendPort);
            client.EnableBroadcast = false;
            client.JoinMulticastGroup(IPAddress.Parse(sendIP));
            IPEndPoint mult = null;
            while (true)
            {
                byte[] buf = client.Receive(ref mult);
                string msg = Encoding.Default.GetString(buf);
                Console.WriteLine(msg);
                //Console.WriteLine(mult.Address.ToString());
            }
        }

        static void ReceiveBack(IAsyncResult state)
        {
            try
            {
                UdpClient udpClient = (UdpClient)state.AsyncState;
                IPEndPoint endPoint = (IPEndPoint)udpClient.Client.LocalEndPoint;

                byte[] receiveBytes = udpClient.EndReceive(state, ref endPoint);
                string value = Encoding.Default.GetString(receiveBytes);
                Console.WriteLine(value);
                //// 在这里使用异步委托来处理接收到的数组，并再次启动接收
                var ar = udpClient.BeginReceive(new AsyncCallback(ReceiveBack), udpClient);

            }
            catch (Exception e)
            {
                return;
            }

        }
    }


   
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi,Pack=1)]
    public struct TransData
    {
        uint dwSize;
        /// <summary>
        /// 具体数据 x460
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 48)]
        public byte[] Data;
    }


    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct IPStruct
    {
        public byte bEnableDHCP;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public char[] IpAddr;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
        public byte[] bMac;
        public uint dwNetMask;
        public uint dwGateway;
        public uint dwDNS;
        public uint dwComputerIP;
        public uint dwServerVersion;
        public ushort wChannelCount;
        public ushort wDataPort;
        public ushort wWebPort;
    }
}
