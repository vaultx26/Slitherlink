using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slitherlink.SlitherlinkCore
{
    public class GameSourse
    {
        private Field field;
        private Tile _tile;
        public GameSourse(Field field)
        {
            this.field = field;
        }
        public void action(string text , int x , int y , string type)
        {
            switch (text)
            {
                case "place":
                    place(x, y, type);
                    break;
                case "remove":
                    Console.Clear();
                    remove(x, y);
                    break;
                default:
                    break;
            }
        }
        public void place(int x , int y , string type)
        { 
            switch(type)
            {
                case "vertical":
                    field._tiles[x, y] = new Tile('|');
                    break;
                case "horizontal":
                    field._tiles[x, y] = new Tile('-');
                    break;
                default:
                    field._tiles[x, y] = new Tile(' ');
                    break;
            }
        }
        public void remove(int x , int y)
        { 
            field._tiles[x,y] = new Tile(' ');
        }
    }
}
