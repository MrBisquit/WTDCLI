using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WTDCLI.Commands
{
    public static class Register
    {
        public static void RegisterAll()
        {
            Info.RegisterInfo();
            SystemInfo.RegisterSystemInfo();
            Help.RegisterHelp();
            WhoAmI.RegisterWhoAmI();

            FileSystem.RegisterFS.RegisterAll();
        }

        public static void RunCommand(string command)
        {
            List<string> argsl = command.Split(' ').ToList();
            argsl.RemoveRange(0, 1);
            string[] args = argsl.ToArray();
            string c = command.Split(' ')[0];

            Index.commands.ForEach(i =>
            {
                if(i.command == c)
                {
                    i.action(args);
                    return;
                } else
                {
                    foreach (var f in i.aliases)
                    {
                        if(f == c)
                        {
                            i.action(args);
                            return;
                        }
                    }
                }
            });
        }
    }
}
