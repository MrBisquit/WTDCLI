using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WTDCLI.Commands
{
    public static class Help
    {
        public static void RegisterHelp()
        {
            Index.commands.Add(new Command()
            {
                command = "help",
                action = (string[] args) =>
                {
                    int l = args.Length;

                    if(l == 0)
                    {
                        Console.WriteLine("WTDCLI built-in Help tool");
                        Console.WriteLine("<> = Required, () = Not required");
                        Console.WriteLine("Usage: help <Tool Name>");
                        Console.WriteLine("Not all tools may be available.");
                    } else
                    {
                        string cmd = args[0];
                        bool found = false;

                        Index.commands.ForEach(c =>
                        {
                            if(c.command == cmd)
                            {
                                found = true;
                                if(c.help == null)
                                {
                                    Console.WriteLine($"No help provided for command `{c.command}`");
                                    return;
                                } else
                                {
                                    c.help();
                                    return;
                                }
                            } else
                            {
                                foreach (var d in c.aliases)
                                {
                                    if(d == cmd)
                                    {
                                        found = true;
                                        if (c.help == null)
                                        {
                                            Console.WriteLine($"No help provided for command `{c.command}` (Alias used: `{cmd}`)");
                                            return;
                                        }
                                        else
                                        {
                                            c.help();
                                            return;
                                        }
                                    }
                                }
                            }
                        });

                        if(!found) Console.WriteLine($"Command `{cmd}` not found.");
                    }
                },
                help = () =>
                {
                    Console.WriteLine("Please use `help` to see the available usage.");
                }
            });
        }
    }
}
