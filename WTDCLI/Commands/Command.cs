using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WTDCLI.Commands
{
    public class Command
    {
        public string command = "";
        public string[] aliases = { };
        public Action<string[]> action;
        public Action help;
    }
}
