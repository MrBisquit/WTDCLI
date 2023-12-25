using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WTDCLI.Commands
{
    public static class SystemInfo
    {
        public static void RegisterSystemInfo()
        {
            Index.commands.Add(new Command()
            {
                command = "systeminfo",
                aliases = new string[] { "sysinfo" },
                action = (string[] args) =>
                {
                    Console.WriteLine($"Current machine name: {Environment.MachineName}\nCurrent user name: {Environment.UserName}");
                }
            });
        }
    }
}
