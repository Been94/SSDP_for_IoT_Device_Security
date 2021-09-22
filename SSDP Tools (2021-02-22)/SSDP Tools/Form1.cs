using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroFramework.Forms;
using SharpPcap.LibPcap;
using SharpPcap;
using PacketDotNet;
using System.Windows.Forms;
using System.Threading;
using System.Collections;
using System.Net.NetworkInformation;
using System.Net;
using System.Text.RegularExpressions;
using System.Net.Sockets;
using System.Runtime.InteropServices;

namespace SSDP_Tool
{

    public partial class Form1 : MetroForm
    {
        [DllImport("iphlpapi.dll", ExactSpelling = true)]
        private static extern int SendARP(int DestIP, int SrcIP, byte[] pMacAddr, ref uint PhyAddrLen);
        private static uint macAddrLen = (uint)new byte[6].Length;

        double nTotalSeconds = 30;
        DateTime dt;
        int packet_send_cnt = 0, text_box_swap_cnt = 0;
        bool loop_exit = true;
        Thread sniffing, packet_gen, mac_addr_find;
        int packetNumber = 1;
        List<LibPcapLiveDevice> interfaceList = new List<LibPcapLiveDevice>();
        LibPcapLiveDevice wifi_device;
        ArrayList ip_list = new ArrayList();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LibPcapLiveDeviceList devices = LibPcapLiveDeviceList.Instance;

            foreach (LibPcapLiveDevice device in devices)
            {
                if (!device.Interface.Addresses.Exists(a => a != null && a.Addr != null && a.Addr.ipAddress != null)) continue;
                var devInterface = device.Interface;
                var friendlyName = devInterface.FriendlyName;
                var description = devInterface.Description;
                interfaceList.Add(device);
                mInterfaceCombo.Items.Add(friendlyName);

            }
            mInterfaceCombo.SelectedIndex = 0;
            SpeedBar.Minimum = 0;
            SpeedBar.Maximum = 10;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (mInterfaceCombo.SelectedIndex >= 0 && mInterfaceCombo.SelectedIndex < interfaceList.Count)
            {
                wifi_device = interfaceList[mInterfaceCombo.SelectedIndex];
            }

            wifi_device.OnPacketArrival += new PacketArrivalEventHandler(Device_OnPacketArrival);

            sniffing = new Thread(new ThreadStart(sniffing_Proccess));
            sniffing.Start();
            Thread sniffing2 = new Thread(new ThreadStart(loop_packet));
            sniffing2.Start();

        }

        private string Get_local_IP_Address()
        {
            string localIP = null;
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList){
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    localIP = ip.ToString();

                }
            }
            return localIP;
        }




        private void loop_packet()
        {
          

            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate ()
                {
                    label1.Visible = true;
                    listView1.Items.Clear();
                    packetNumber = 1;
                    button1.Enabled = false;
                    listView1.FullRowSelect = false;
                    Source_IP_Address_Text.Enabled = false;
                    Destination_IP_Address_Text.Enabled = false;
                    button3.Enabled = false;

                }));
            }

            String mutilcast_ip = @"239.255.255.250";
            String Spoofing_Src_IP = Get_local_IP_Address();//"192.168.0.10";
            String Dst_IP = @"239.255.255.250";//"192.168.0.17";
            String Dst_Port = "1900";

            int i = 0;


            while (true)
            {
                int xxx = Convert.ToInt32(label1.Text.ToString()) - 1;
                if (xxx == 0)
                {
                    if (this.InvokeRequired)
                    {
                        this.Invoke(new MethodInvoker(delegate ()
                        {
                            label1.Visible = false;
                        }));
                    }
                    break;
                }

                if (this.InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        label1.Text = xxx.ToString();
                    }));
                }


                var ethernetPacket = new PacketDotNet.EthernetPacket(
                    PhysicalAddress.Parse(Get_Macaddress()),
                    PhysicalAddress.Parse(MulticastIpToMac(mutilcast_ip)),
                     PacketDotNet.EthernetPacketType.IpV4);
                var ipv4 = new PacketDotNet.IPv4Packet(IPAddress.Parse(Spoofing_Src_IP), IPAddress.Parse(Dst_IP));
                var udp = new PacketDotNet.UdpPacket(Convert.ToUInt16(rand_port()), Convert.ToUInt16(Dst_Port));

                ushort t = 0;
                udp.PayloadData = Encoding.Default.GetBytes("M-SEARCH * HTTP/1.1\r\nHOST: 239.255.255.250:1900\r\nST: ssdp:all\r\nMAN: \"ssdp:discover\"\r\nMX: 3\r\n\r\n");
                udp.Checksum = 0;
                Random r = new Random();

                int xx = 0;

                xx = i;

                if (xx >= 30000)
                {
                    xx = 0;
                }

                ipv4.Id = Convert.ToUInt16(r.Next(xx, 30005));
                ipv4.TimeToLive = 56;
                ipv4.PayloadPacket = udp;
                ipv4.Checksum = ipv4.CalculateIPChecksum();

                ethernetPacket.PayloadPacket = ipv4;


                wifi_device.SendPacket(ethernetPacket);
                i++;
                Thread.Sleep(1000);
               

            }
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate ()
                {
                    label1.Text = "10";
                    button1.Enabled = true;
                    listView1.FullRowSelect = true;
                    Source_IP_Address_Text.Enabled = true;
                    Destination_IP_Address_Text.Enabled = true;
                    button3.Enabled = true;

                    sniffing.Abort();
                    wifi_device.StopCapture();
                    wifi_device.Close();
                }));
            }
           // MessageBox.Show("끝남");


        }
        public static string rand_port()
        {
            Random r = new Random();
            int tmp = 0;
            for (int i = 0; i < 1000; i++){
                tmp = r.Next(1, 65535);
            }
            return tmp.ToString();
        }
        private static string Get_Macaddress()
        {
            string str = NetworkInterface.GetAllNetworkInterfaces()[0].GetPhysicalAddress().ToString();
            string mac = "";

            char[] chrArr = str.ToCharArray();
            for (int i = 0; i < chrArr.Length; i++)
            {
                if (i % 2 == 0)
                {
                    mac += chrArr[i].ToString();
                }
                else
                {
                    mac += chrArr[i].ToString();
                    if (i != chrArr.Length - 1)
                        mac += "-";
                }
            }
            return mac;
        }


        public static string MulticastIpToMac(string str)
        {

            Regex ip = new Regex(@"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b");
            MatchCollection result = ip.Matches(str);

            string[] words = result[0].ToString().Split('.');

            int[] tmp = new int[4];

            for (int x = 0; x < 4; x++)
            {
                tmp[x] = Convert.ToInt32(words[x]);
            }


            if ((tmp[0] < 224) || (tmp[0] > 239) || (tmp[1] < 0) || (tmp[1] > 255) ||
             (tmp[2] < 0) || (tmp[2] > 255) || (tmp[3] < 0) || (tmp[3] > 255))
            {
                Console.WriteLine("invalid multicast IP address");
            }


            words[0] = ToHex(tmp[1] & 127);
            words[1] = ToHex(tmp[2]);
            words[2] = ToHex(tmp[3]);


            for (int ii = 1; ii <= 3; ++ii)
            {
                while (words[ii].Length < 2)
                {
                    words[ii] = "0" + words[ii];
                }
            }
            string mac = "01-00-5E-" + words[0] + "-" + words[1] + "-" + words[2];

            return mac;
        }
        public static string ToHex(int i)
        {
            // 대문자 X일 경우 결과 hex값이 대문자로 나온다.
            string hex = i.ToString("X");
            if (hex.Length % 2 != 0)
            {
                hex = "0" + hex;
            }
            return hex;
        }

        private void sniffing_Proccess()
        {
            // Open the device for capturing
            int readTimeoutMilliseconds = 1000;
            wifi_device.Open(DeviceMode.Promiscuous, readTimeoutMilliseconds);
            wifi_device.Filter = "src port 1900 && udp";
            // Start the capturing process
            if (wifi_device.Opened)
            {
                wifi_device.Capture();
            }
            else
            {
                MessageBox.Show("Device Not Open!!");
            }
        }

        private bool search(string str)
        {
            bool a = false;
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate ()
                {
                    foreach (ListViewItem lvi in listView1.Items)
                    {
                        if (str == lvi.SubItems[1].Text)
                        {
                            a = true;
                        }
                    }

                }));
            }

            return a;
        }




        public void Device_OnPacketArrival(object sender, CaptureEventArgs e)
        {


            string length = e.Packet.Data.Length.ToString();


            var packet = PacketDotNet.Packet.ParsePacket(e.Packet.LinkLayerType, e.Packet.Data);


            var ipPacket = (IpPacket)packet.Extract(typeof(IpPacket));


            if (ipPacket != null)
            {

                string protocol_type = ipPacket.Protocol.ToString();
                string sourceIP = ipPacket.SourceAddress.ToString();
                string destinationIP = ipPacket.DestinationAddress.ToString();


                var protocolPacket = ipPacket.PayloadPacket;


                if(search(sourceIP) == false)
                {

                    ListViewItem item = new ListViewItem(packetNumber.ToString());
                    item.SubItems.Add(sourceIP);
                    item.SubItems.Add(destinationIP);
                    item.SubItems.Add(protocol_type);
                    item.SubItems.Add(length);

                    if (this.InvokeRequired)
                    {
                        this.Invoke(new MethodInvoker(delegate ()
                        {
                            listView1.Items.Add(item);
                        }));
                    }
                    else
                    {
                        listView1.Items.Add(item);
                    }

                ++packetNumber;

                }

            }


        }
        //맥주소 파악하기
        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            string result = null;

            string source = e.Item.SubItems[1].Text;
            string dst = e.Item.SubItems[2].Text;

            // string protocol = e.Item.SubItems[3].Text;
            /*
            mac_addr_find = new Thread(delegate () { result = ThreadedARPRequest(source); });
            mac_addr_find.Start();
            */

            Source_Mac_Address_Text.Text = ARPRequest(source);
            Destination_Mac_Address_Text.Text = ARPRequest(dst);

            Source_IP_Address_Text.Text = source;
            Destination_IP_Address_Text.Text = dst;
        }

        private static string ARPRequest(string ipString)
        {
            IPAddress ipAddress = new IPAddress(0);
            byte[] macAddr = new byte[6];
            string macString = null;
            try
            {
                ipAddress = IPAddress.Parse(ipString);
                SendARP((int)BitConverter.ToInt32(ipAddress.GetAddressBytes(), 0), 0, macAddr, ref macAddrLen);
                if (MacAddresstoString(macAddr) != "00-00-00-00-00-00")
                {
                    macString = MacAddresstoString(macAddr);
                }
            }
            catch (Exception e)
            {
                macString = null;
               // MessageBox.Show("Mac Addr Error");
            }
            return macString;
        }


        private static string MacAddresstoString(byte[] macAdrr)
        {
            string macString = BitConverter.ToString(macAdrr);
            return macString.ToUpper();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            mInterfaceCombo.Enabled = false;
            button1.Enabled = false;
            listView1.FullRowSelect = false;
            SpeedBar.Enabled = false;
            Source_IP_Address_Text.Enabled = true;
            Destination_IP_Address_Text.Enabled = true;
            // Open the device for capturing
            int readTimeoutMilliseconds = 1000;
            wifi_device.Open(DeviceMode.Promiscuous, readTimeoutMilliseconds);
            // Start the capturing process
            if (wifi_device.Opened)
            {
                loop_exit = true;
                //button4.Enabled = true;
                //button3.Enabled = false;
                packet_gen = new Thread(new ThreadStart(Generator_function));
                packet_gen.Start();


            }
            else
            {
                MessageBox.Show("Device Not Open!!");
            }

        }

        
        private void Generator_function()
        {
           // int xx = 0;
                
                

                String mutilcast_ip = @"239.255.255.250";
                String Spoofing_Src_IP = Source_IP_Address_Text.Text;
                String Dst_IP = Destination_IP_Address_Text.Text;//"192.168.0.17";
                String Dst_Port = "1900";


                var ethernetPacket = new PacketDotNet.EthernetPacket(
//   PhysicalAddress.Parse(Get_Macaddress()),
// PhysicalAddress.Parse("64-7B-CE-49-BD-98"),
PhysicalAddress.Parse(Source_Mac_Address_Text.Text),

 PhysicalAddress.Parse(Destination_Mac_Address_Text.Text),

         // PhysicalAddress.Parse(MulticastIpToMac(mutilcast_ip)),

         // PhysicalAddress.Parse("B8-27-EB-6E-EF-AD"),

         PacketDotNet.EthernetPacketType.IpV4);
                var ipv4 = new PacketDotNet.IPv4Packet(IPAddress.Parse(Spoofing_Src_IP), IPAddress.Parse(Dst_IP));
                var udp = new PacketDotNet.UdpPacket(Convert.ToUInt16(rand_port()), Convert.ToUInt16(Dst_Port));

                ushort t = 0;
                udp.PayloadData = Encoding.Default.GetBytes("M-SEARCH * HTTP/1.1\r\nHOST: " + Dst_IP + ":1900\r\nST: ssdp:all\r\nMAN: \"ssdp:discover\"\r\nDevice:uuid:1234-5533-1231-4432\r\nMX: 3\r\n\r\n");
                udp.Checksum = 0;
                Random r = new Random();

                
            /*
                 xx = packet_send_cnt;

                if (xx >= 30000)
                {
                    xx = 0;
                }
            */
                ipv4.Id = Convert.ToUInt16(r.Next(packet_send_cnt, 30005));
                ipv4.TimeToLive = 56;
                ipv4.PayloadPacket = udp;
                ipv4.Checksum = ipv4.CalculateIPChecksum();

                ethernetPacket.PayloadPacket = ipv4;


                wifi_device.SendPacket(ethernetPacket);
                //  i++;
               // Thread.Sleep(Convert.ToInt32(PacketSpeed_label.Text) * 1000);
                packet_send_cnt++;
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate ()
                {
                    Packet_Send_labal.Text = packet_send_cnt.ToString();

                }));
            }

        }
        private void src_ip_arp_processs()
        {
            Notify_Message.Visible = true;
            Notify_Message.Text = "아이피로 부터 맥주소를 불러오는중...";
            string dd = ARPRequest(Source_IP_Address_Text.Text);
            int time = 0;
            while (true)
            {
                System.Windows.Forms.Application.DoEvents();
                if (dd != null)
                {
                    break;
                }
                Thread.Sleep(1000);
                if (time == 5)
                {
                    break;
                }
                time++;

            }
            time = 0;
            if(dd != null) {
                if (this.InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        Clipboard.SetText(dd);
                        Source_Mac_Address_Text.Text = dd;

                    }));
                }
               
                Notify_Message.Visible = true;
                Notify_Message.Text = "클립보드로 맥주소가 복사되었습니다.";
                Delay(2000);
                Notify_Message.Visible = false;
            }
            else
            {
                Notify_Message.Visible = true;
                Notify_Message.Text = "해당 아이피의 맥주소가 존재하지않습니다.";
                Delay(2000);
                Notify_Message.Visible = false;
            }
        }


        private void Source_IP_Address_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                string src_ip = Source_IP_Address_Text.Text;

                Thread ARP_Packet_Search = new Thread(new ThreadStart(src_ip_arp_processs));
                ARP_Packet_Search.Start();
            }
        }
        private static DateTime Delay(int MS)
        {
            DateTime ThisMoment = DateTime.Now;
            TimeSpan duration = new TimeSpan(0, 0, 0, 0, MS);
            DateTime AfterWards = ThisMoment.Add(duration);

            while (AfterWards >= ThisMoment)
            {
                System.Windows.Forms.Application.DoEvents();
                ThisMoment = DateTime.Now;
            }

            return DateTime.Now;
        }
        private void Source_IP_Address_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void Source_IP_Address_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void Destination_IP_Address_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void Destination_IP_Address_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            switch (text_box_swap_cnt)
            {
                case 0:
                    string tmp = Source_IP_Address_Text.Text;
                    Source_IP_Address_Text.Text = Destination_IP_Address_Text.Text;
                    Destination_IP_Address_Text.Text = tmp;

                    tmp = Source_Mac_Address_Text.Text;
                    Source_Mac_Address_Text.Text = Destination_Mac_Address_Text.Text;
                    Destination_Mac_Address_Text.Text = tmp;
                    text_box_swap_cnt = 1;
                    break;
                case 1:
                    tmp = Destination_IP_Address_Text.Text;
                    Destination_IP_Address_Text.Text = Source_IP_Address_Text.Text;
                    Source_IP_Address_Text.Text = tmp;

                    tmp = Destination_Mac_Address_Text.Text;
                    Destination_Mac_Address_Text.Text = Source_Mac_Address_Text.Text;
                    Source_Mac_Address_Text.Text = tmp;
                    text_box_swap_cnt = 0;
                    break;
                default:
                    break;
            }

        }

        private void SpeedBar_Scroll(object sender, EventArgs e)
        {

            PacketSpeed_label.Text = SpeedBar.Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            /*
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate ()
                {
                    Packet_Send_labal.Text = "0";

                }));
            }*/
            mInterfaceCombo.Enabled = true;
            button1.Enabled = true;
            listView1.FullRowSelect = true;
            SpeedBar.Enabled = true;
            Source_IP_Address_Text.Enabled = true;
            Destination_IP_Address_Text.Enabled = true;
            packet_send_cnt = 0;
            Packet_Send_labal.Text = "0";
            loop_exit = false;
            packet_gen.Abort();

            wifi_device.Close();
            button4.Enabled = false;
            button3.Enabled = true;
        }
    }
}
