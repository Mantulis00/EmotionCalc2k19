using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace EmotionCalculator.EmotionCalculator.Tools.Web
{
    public class ConnectionChecker
    {
        public static bool IsConnectedToInternet()
        {
            try 
            {
                Ping myPing = new Ping();
                String host = "google.com";
                byte[] buffer = new byte[32];
                int timeout = 1000;
                PingOptions pingOptions = new PingOptions();
                PingReply pingReply = myPing.Send(host, timeout, buffer, pingOptions);
                return (pingReply.Status == IPStatus.Success);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
