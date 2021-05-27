using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using IngramMicro.USIT.OST.API.Automation;
using System.IO;

namespace IngramMicro.USIT.OST.API.NunitConsole
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            string Feature = args[0];
            Process p = new Process();
            ProcessStartInfo ps = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                WindowStyle = ProcessWindowStyle.Normal,
                RedirectStandardInput = true,
                UseShellExecute = false
            };

            p.StartInfo = ps;
            p.Start();
            switch (Feature)
            {
                case "All":
                    string all = @"nunit3-console.exe " + "\"--result=C:\\OST_API_Result\\" + Feature + "_" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".xml;format=nunit2\"" + @" C:\Automation\IngramMicro.USIT.OST.API.Automation\IngramMicro.USIT.OST.API.Automation\bin\Debug\IngramMicro.USIT.OST.API.Automation.dll";
                    using (StreamWriter sw = p.StandardInput)
                    {
                        if (sw.BaseStream.CanWrite)
                        {
                            sw.WriteLine(@"cd NUnit.org\nunit-console");
                            sw.WriteLine(all);
                        }
                    }
                    break;

                case "OrderDetails":
                    string orderDetails = @"nunit3-console.exe " + "\"--result=C:\\OST_API_Result\\" + Feature + "_" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".xml;format=nunit2\"" + @" C:\Automation\IngramMicro.USIT.OST.API.Automation\IngramMicro.USIT.OST.API.Automation\bin\Debug\IngramMicro.USIT.OST.API.Automation.dll --where cat==" + Feature;
                    using (StreamWriter sw = p.StandardInput)
                    {
                        if (sw.BaseStream.CanWrite)
                        {
                            sw.WriteLine(@"cd NUnit.org\nunit-console");
                            sw.WriteLine(orderDetails);
                        }
                    }
                    break;

                case "OSTReport":
                    string ostReport = @"nunit3-console.exe " + "\"--result=C:\\OST_API_Result\\" + Feature + "_" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".xml;format=nunit2\"" + @" C:\Automation\IngramMicro.USIT.OST.API.Automation\IngramMicro.USIT.OST.API.Automation\bin\Debug\IngramMicro.USIT.OST.API.Automation.dll --where cat==" + Feature;
                    using (StreamWriter sw = p.StandardInput)
                    {
                        if (sw.BaseStream.CanWrite)
                        {
                            sw.WriteLine(@"cd NUnit.org\nunit-console");
                            sw.WriteLine(ostReport);
                        }
                    }
                    break;

		        case "NotificationHub":
                    string notificationHubReport = @"nunit3-console.exe " + "\"--result=C:\\OST_API_Result\\" + Feature + "_" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".xml;format=nunit2\"" + @" C:\Automation\IngramMicro.USIT.OST.API.Automation\IngramMicro.USIT.OST.API.Automation\bin\Debug\IngramMicro.USIT.OST.API.Automation.dll --where cat==" + Feature;
                    using (StreamWriter sw = p.StandardInput)
                    {
                        if (sw.BaseStream.CanWrite)
                        {
                            sw.WriteLine(@"cd NUnit.org\nunit-console");
                            sw.WriteLine(notificationHubReport);
                        }
                    }
                    break;
            }
        }

    }
}
