using System;
using Slitherlink.SlitherlinkCore;
using Slitherlink.SlitherlinkConsole;
namespace Slitherlink
{
    public class Program
    {
        static void Main()
        {
            var Field = new Field(11, 11);
            var game = new GameSourse(Field);
            var ui = new ConsoleUI(Field,game);
            ui.Menu();
        }
    }
}