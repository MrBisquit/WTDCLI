using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WTDCLI.Commands.FileSystem
{
    public static class Ls
    {
        public static void RegisterLs()
        {
            Index.commands.Add(new Command()
            {
                command = "ls",
                aliases = new string[] { "list" },
                action = (string[] args) =>
                {
                    if(args.Length == 0)
                    {
                        foreach (var dir in Directory.EnumerateDirectories(Environment.CurrentDirectory))
                        {
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write($"{new DirectoryInfo(dir).Name}");
                            Console.ResetColor();
                            Console.Write(" ");
                        }

                        foreach (var file in Directory.EnumerateFiles(Environment.CurrentDirectory))
                        {
                            Console.Write($"{new FileInfo(file).Name} ");
                        }

                        Console.WriteLine();
                    } else
                    {
                        string all = "";
                        foreach (string arg in args)
                        {
                            all += arg + " ";
                        }
                        all.TrimEnd();
                        if (!Directory.Exists(all))
                        {
                            Console.WriteLine($"Could not find {all}");
                        }

                        foreach (var dir in Directory.EnumerateDirectories(all))
                        {
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write($"{new DirectoryInfo(dir).Name}");
                            Console.ResetColor();
                            Console.Write(" ");
                        }

                        foreach (var file in Directory.EnumerateFiles(all))
                        {
                            Console.Write($"{new FileInfo(file).Name} ");
                        }

                        Console.WriteLine();
                    }
                }
            });
        }
    }
}
