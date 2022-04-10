using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slitherlink.SlitherlinkCore
{
    public class Tile
    {   
        public Tile(char character)
        {
            Character = character;
        }
        public char Character { get; }
    }
}
