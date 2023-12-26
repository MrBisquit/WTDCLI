using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WTDCLI.Commands.FileSystem
{
    public static class Pwd
    {
        public static void RegisterPwd()
        {
            Index.commands.Add(new Command()
            {
                command = "pwd",
                action = (string[] args) =>
                {
                    Console.WriteLine(Environment.CurrentDirectory);
                }
            });
        }
    }
}
