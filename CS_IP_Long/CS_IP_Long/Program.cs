using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS_IP_Long
{
    /*
     JAVA code-http://www.iteye.com/topic/254742 
        public static long ip2long(String ip) {  
            String[] ips = ip.split("[.]");  
            long num =  16777216L*Long.parseLong(ips[0]) + 65536L*Long.parseLong(ips[1]) + 256*Long.parseLong(ips[2]) + Long.parseLong(ips[3]);  
            return num;  
        }  
      
        public static String long2ip(long ipLong) {  
            //long ipLong = 1037591503;  
            long mask[] = {0x000000FF,0x0000FF00,0x00FF0000,0xFF000000};  
            long num = 0;  
            StringBuffer ipInfo = new StringBuffer();  
            for(int i=0;i<4;i++){  
                num = (ipLong & mask[i])>>(i*8);  
                if(i>0) ipInfo.insert(0,".");  
                ipInfo.insert(0,Long.toString(num,10));  
            }  
            return ipInfo.toString();  
        }   
    */
    class Program
    {
        public static Int64 ip2long(String ip, bool Reversal = false)
        {
            String[] ips = ip.Split('.');
            Int64 num=0;
            if (!Reversal)
            {
                num = 16777216L * Convert.ToInt64(ips[0], 10) + 65536L * Convert.ToInt64(ips[1], 10) + 256 * Convert.ToInt64(ips[2], 10) + Convert.ToInt64(ips[3], 10);
            }
            else
            {
                num = 16777216L * Convert.ToInt64(ips[3], 10) + 65536L * Convert.ToInt64(ips[2], 10) + 256 * Convert.ToInt64(ips[1], 10) + Convert.ToInt64(ips[0], 10);
            }
            return num;
        }
        public static String long2ip(Int64 ipLong, bool Reversal=false)
        {  
            //long ipLong = 1037591503;  
            Int64[] mask = new Int64[] { 0x000000FF, 0x0000FF00, 0x00FF0000, 0xFF000000 };
            Int64 num = 0;
            string Buf = "";
            for(int i=0;i<4;i++){  
                num = (ipLong & mask[i])>>(i*8);
                if (!Reversal)
                {
                    Buf = "." + num + Buf;
                }
                else
                {
                    Buf += num+".";
                }
            }

            if (!Reversal)
            {
                Buf = Buf.Substring(1);
            }
            else
            {
                Buf = Buf.Substring(0,Buf.Length-1);  
            }

            return Buf;
        }  
        public static void pause()
        {
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
        static void Main(string[] args)
        {
            Int64 val01 = ip2long("1.2.3.4");
            String Str01 = long2ip(val01);
            Int64 val02 = ip2long("1.2.3.10");
            String Str02 = long2ip(val02);
            Int64 val03 = ip2long("192.168.0.5");
            String Str03 = long2ip(val03);
            //--
            String Str04 = long2ip(3439438016, true);//驗證API數字[SYRIS公司用]
            Int64 val04 = ip2long(Str04, true);//驗證API數字[SYRIS公司用]
            pause();
        }
    }
}
