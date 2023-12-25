using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WTDCLI.Commands
{
    public static class Info
    {
        public static void RegisterInfo()
        {
            Index.commands.Add(new Command()
            {
                command = "info",
                action = (string[] args) =>
                {
                    Console.WriteLine("WTDCLI - WTDawson Command Line Interface");
                    Console.WriteLine("An easy-to-use command line interface for Windows.");
                }
            });
        }
    }
}
