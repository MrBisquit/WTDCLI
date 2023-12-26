using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WTDCLI.Commands.FileSystem
{
    public static class FileEdit
    {
        public static void RegisterFile()
        {
            Index.commands.Add(new Command()
            {
                command = "file",
                aliases = new string[] { "f" },
                action = (string[] args) =>
                {
                    if(args.Length == 0)
                    {
                        Console.WriteLine("Missing arguments: <File name>");
                    } else
                    {
                        if(System.IO.File.Exists(args[0]))
                        {
                            Edit(args[0]);
                        } else
                        {
                            if(System.IO.File.Exists(Path.Combine(Environment.CurrentDirectory, args[0])))
                            {
                                Edit(Path.Combine(Environment.CurrentDirectory, args[0]));
                            } else
                            {
                                Console.WriteLine("Could not find " + args[0]);
                            }
                        }
                    }
                },
                help = () =>
                {
                    Console.WriteLine("The WTDCLI File editor");
                    Console.WriteLine("Usage: file <File name>, f <File name>");
                }
            });
        }

        public static void Edit(string path)
        {
            StringBuilder sb = new StringBuilder(File.ReadAllText(path));
            bool hasCompleted = false;

            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            int bw = Console.BufferWidth - $"Editing {new FileInfo(path).Name}".Length;
            string b = "";
            for (int i = 0; i < bw; i++) b += " ";
            Console.WriteLine($"Editing {new FileInfo(path).Name}{b}");

            bw = Console.BufferWidth - "Save=Ctrl+S Save&Exit=Ctrl+Shift+S Exit=Esc".Length;
            b = "";
            for (int i = 0; i < bw; i++) b += " ";
            Console.SetCursorPosition(0, Console.BufferHeight - 2);
            Console.WriteLine($"Save=Ctrl+S Save&Exit=Ctrl+Shift+S Exit=Esc{b}");

            Console.ResetColor();

            Console.ReadKey();
        }
    }
}
