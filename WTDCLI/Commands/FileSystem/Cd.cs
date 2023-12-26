using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WTDCLI.Commands.FileSystem
{
    public static class Cd
    {
        public static void RegisterCd()
        {
            Index.commands.Add(new Command()
            {
                command = "cd",
                action = (string[] args) =>
                {
                    if(args.Length == 0)
                    {
                        Console.WriteLine("Missing arguments: <File name>");
                    } else
                    {
                        string all = "";
                        foreach (string arg in args)
                        {
                            all += arg + " ";
                        }
                        all.TrimEnd();
                        if(!Directory.Exists(all))
                        {
                            Console.WriteLine($"Could not find {all}");
                        }
                        Environment.CurrentDirectory = all;
                    }
                }
            });
        }
    }
}
