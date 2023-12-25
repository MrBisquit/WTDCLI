using System.Text;
using WTDCLI.Commands;

namespace WTDCLI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Register.RegisterAll();

            bool exit = false;
            while(!exit)
            {
                string input = AcceptInput();
                Console.WriteLine();

                if(input == "cls" || input == "clear")
                {
                    Console.Clear();
                } else
                {
                    Register.RunCommand(input);
                }
            }
        }

        static string AcceptInput()
        {
            StringBuilder sb = new StringBuilder();
            bool hasCompleted = false;

            int pos = 0;
            int lastLength = 0;

            while(!hasCompleted)
            {
                Console.Write($"\rwtd> {sb}");
                lastLength = $"\rwtd> {sb}".Length + 1;

                try
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    if (key.Key == ConsoleKey.Enter)
                    {
                        hasCompleted = true;
                        return sb.ToString();
                    }
                    else if (key.Key == ConsoleKey.Escape)
                    {
                        string fillf = "";

                        for (int i = 0; i < lastLength * 10; i++)
                        {
                            fillf += " ";
                        }

                        Console.Write("\r" + fillf);

                        sb.Clear();

                        continue;
                    }
                    else if (key.Key == ConsoleKey.Backspace)
                    {
                        try
                        {
                            sb.Remove(pos - 1, 1);
                            pos--;
                        }
                        catch { }
                    }
                    else if (key.Key == ConsoleKey.Delete)
                    {
                        try
                        {
                            sb.Remove(pos + 1, 1);
                            pos--;
                        }
                        catch { }
                    }
                    else if (key.Key == ConsoleKey.LeftArrow)
                    {
                        if (pos == 0) continue;
                        //pos--;
                        pos = Math.Max(0, pos - 1);
                    }
                    else if (key.Key == ConsoleKey.RightArrow)
                    {
                        if (pos == (sb.Length - 1)) continue;
                        //pos++;
                        pos = Math.Min(sb.Length, pos + 1);
                    }
                    else
                    {
                        //sb.Capacity++;
                        //sb.Length++;
                        //sb.Append(new char[] { key.KeyChar }, pos, 0);
                        sb.Insert(pos, key.KeyChar);
                        pos++;
                    }
                } catch { }

                string fill = "";

                for (int i = 0; i < lastLength; i++)
                {
                    fill += " ";
                }

                Console.Write("\r" + fill);
                Console.Write($"\rwtd> {sb}");

                try
                {
                    int cursorLeft = $"\rwtd> {sb.ToString(0, pos)}".Length;
                    Console.SetCursorPosition(cursorLeft, Console.CursorTop);
                } catch { }
            }

            return sb.ToString();
        }
    }
}
