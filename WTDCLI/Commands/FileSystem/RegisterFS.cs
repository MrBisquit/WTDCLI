using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WTDCLI.Commands.FileSystem
{
    public static class RegisterFS
    {
        public static void RegisterAll()
        {
            Pwd.RegisterPwd();
            Ls.RegisterLs();
            Cd.RegisterCd();
            FileEdit.RegisterFile();
        }
    }
}
