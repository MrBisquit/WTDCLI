using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WTDCLI.Commands
{
    public static class WhoAmI
    {
        public static void RegisterWhoAmI()
        {
            Index.commands.Add(new Command()
            {
                command = "whoami",
                aliases = new string[] { "wai" },
                action = (string[] args) =>
                {
                    Console.WriteLine($"You are {Environment.UserName} at {Environment.MachineName}");
                },
                help = () =>
                {
                    Console.WriteLine("The WhoAmI command tells you who you are on what system.");
                    Console.WriteLine("Usage: whoami, wai");
                }
            });
        }
    }
}
