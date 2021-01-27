using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanThucUong
{
    class ConsoleView
    {
        public static void Menu(params string[] list)
        {
            Console.WriteLine("*****************************************************");
            for(int i = 0; i < list.Length; i++)
            {
                Console.WriteLine("* {0,-50}*", list[i]);
            }
            Console.WriteLine("*****************************************************");
        }
    }
}
