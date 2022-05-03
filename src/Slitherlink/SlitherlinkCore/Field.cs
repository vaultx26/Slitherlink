using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Slitherlink.SlitherlinkCore
{
    [Serializable]
    public class Field
    {
        private DateTime _date;
        private GameSourse gameSourse;
        public Tile[,] _tiles;
        public Tile[,] tiles;
        char[,] solved_easy =
            {
                { '*' , '-' , '-' , '-' , '*' , ' ' , '*' , '-' , '-' , '-' ,  '*' },
                { '|' , ' ' , ' ' , ' ' , '|' , '2' , '|' , '2' , ' ' , '3' ,  '|' },
                { '*' , '-' , '*' , ' ' , '|' , ' ' , '|' , ' ' , '*' , '-' ,  '*' },
                { ' ' , '3' , '|' , '2' , '|' , ' ' , '|' , ' ' , '|' , ' ' ,  ' ' },
                { '*' , '-' , '*' , ' ' , '*' , '-' , '*' , ' ' , '*' , '-' ,  '*' },
                { '|' , '3' , ' ' , '0' , ' ' , ' ' , ' ' , ' ' , ' ' , ' ' ,  '|' },
                { '*' , '-' , '*' , ' ' , '*' , '-' , '-' , '-' , '*' , ' ' ,  '|' },
                { ' ' , '3' , '|' , ' ' , '|' , ' ' , ' ' , '2' , '|' , '2' ,  '|' },
                { '*' , '-' , '*' , ' ' , '*' , '-' , '*' , ' ' , '|' , ' ' ,  '|' },
                { '|' , ' ' , ' ' , '1' , ' ' , '3' , '|' , ' ' , '|' , ' ' ,  '|' },
                { '*' , '-' , '-' , '-' , '-' , '-' , '*' , ' ' , '*' , '-' ,  '*' }
            };
        /*char[,] easy =
            {
                { '*' , ' ' , ' ' , ' ' , '*' , ' ' , '*' , ' ' , ' ' , ' ' ,  '*' },
                { ' ' , ' ' , ' ' , ' ' , ' ' , '2' , ' ' , '2' , ' ' , '3' ,  ' ' },
                { '*' , ' ' , '*' , ' ' , ' ' , ' ' , ' ' , ' ' , '*' , ' ' ,  '*' },
                { ' ' , '3' , ' ' , '2' , ' ' , ' ' , ' ' , ' ' , ' ' , ' ' ,  ' ' },
                { '*' , ' ' , '*' , ' ' , '*' , ' ' , '*' , ' ' , '*' , ' ' ,  '*' },
                { ' ' , '3' , ' ' , '0' , ' ' , ' ' , ' ' , ' ' , ' ' , ' ' ,  ' ' },
                { '*' , ' ' , '*' , ' ' , '*' , ' ' , ' ' , ' ' , '*' , ' ' ,  ' ' },
                { ' ' , '3' , ' ' , ' ' , ' ' , ' ' , ' ' , '2' , ' ' , '2' ,  ' ' },
                { '*' , ' ' , '*' , ' ' , '*' , ' ' , ' ' , ' ' , ' ' , ' ' ,  ' ' },
                { ' ' , ' ' , ' ' , '1' , ' ' , '3' , ' ' , ' ' , ' ' , ' ' ,  ' ' },
                { '*' , ' ' , ' ' , ' ' , ' ' , ' ' , '*' , ' ' , '*' , ' ' ,  '*' }
            };*/
        char[,] easy =
            {
                { '*' , ' ' , '-' , '-' , '*' , ' ' , '*' , '-' , '-' , '-' ,  '*' },
                { '|' , ' ' , ' ' , ' ' , '|' , '2' , '|' , '2' , ' ' , '3' ,  '|' },
                { '*' , '-' , '*' , ' ' , '|' , ' ' , '|' , ' ' , '*' , '-' ,  '*' },
                { ' ' , '3' , '|' , '2' , '|' , ' ' , '|' , ' ' , '|' , ' ' ,  ' ' },
                { '*' , '-' , '*' , ' ' , '*' , '-' , '*' , ' ' , '*' , '-' ,  '*' },
                { '|' , '3' , ' ' , '0' , ' ' , ' ' , ' ' , ' ' , ' ' , ' ' ,  '|' },
                { '*' , '-' , '*' , ' ' , '*' , '-' , '-' , '-' , '*' , ' ' ,  '|' },
                { ' ' , '3' , '|' , ' ' , '|' , ' ' , ' ' , '2' , '|' , '2' ,  '|' },
                { '*' , '-' , '*' , ' ' , '*' , '-' , '*' , ' ' , '|' , ' ' ,  '|' },
                { '|' , ' ' , ' ' , '1' , ' ' , '3' , '|' , ' ' , '|' , ' ' ,  '|' },
                { '*' , '-' , '-' , '-' , '-' , '-' , '*' , ' ' , '*' , '-' ,  '*' }
            };
        public int RowCount { get; }
        public int ColumnCount { get; }
        public Field(int rowCount , int columnCount)
        {
            RowCount = rowCount;
            ColumnCount = columnCount;
            _tiles = new Tile[rowCount, columnCount];
            tiles = new Tile[rowCount, columnCount];
            _date = DateTime.Now;
            gameSourse = new GameSourse(this);
        }
        public Tile GetTile(int row, int column)
        {
            return _tiles[row, column];
        }

        public Tile this[int row, int column]
        {
            get { return _tiles[row, column]; }
        }
        public void initSolvedField()
        {
            for (int i = 0; i < RowCount; i++)
            {
                for (int j = 0; j < ColumnCount; j++)
                {
                    tiles[i, j] = new Tile(solved_easy[i, j]);
                }
            }
        }
        public void initializeField()
        {

            for (int i = 0; i < RowCount; i++)
            {
                for (int j = 0; j < ColumnCount; j++)
                {
                    _tiles[i, j] = new Tile(easy[i, j]);
                }
            }
        }
        public bool isSolved()
        {
            for(int i = 0; i < RowCount; i++)
            {
                for(int j = 0; j < ColumnCount; j++)
                {
                    //Console.WriteLine(solved_easy[i, j] + " > " + (int)solved_easy[i, j]);
                    if (_tiles[i,j].Character != tiles[i,j].Character)
                    {
                        //Console.WriteLine(i + " " + j + " [" + (int)_tiles[i, j].Character + "] : [" + (int)solved_easy[i, j] + "]" + " > " + (_tiles[i, j].Character == solved_easy[i, j]));
                        return false;
                    }
                }
            }
            return true;
        }
        public void PlayGame()
        {
            string what_to_do = Console.ReadLine();
            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());
            string typ;
            if (what_to_do == "place")
            {
                typ = Console.ReadLine();
            }
            else
            {
                typ = "remove";
            }
            gameSourse.action(what_to_do, x, y, typ);

            Console.Clear();
        }
        
        public int getScore()
        {
            return (DateTime.Now - _date).Seconds;
        }
    }
}
