using System;
using System.Collections.Generic;
using System.Text;
using Slitherlink.SlitherlinkCore;
using Slitherlink.SlitherlinkCore.SlitherlinkEntity;
using Slitherlink.SlitherlinkCore.SlitherlinkService;
using Slitherlink.SlitherlinkCore.SlitherlinkService.CommentService;
using Slitherlink.SlitherlinkCore.SlitherlinkService.HodnotenieService;

namespace Slitherlink.SlitherlinkConsole
{
    public class ConsoleUI
    {
        private Field _field;
        private GameSourse _game;
        private readonly ScoreService scoreService = new ScoreServiceEF();
        private readonly HodnotenieService hodnotenieService = new HodnotenieServiceEF();
        private readonly CommentService commentService = new CommentServiceEF();
        private HodnotenieGame hodnotenieGame = new HodnotenieGame();
        public ConsoleUI(Field field , GameSourse game)
        {   
            _field = field;
            _game = game;
            _field.initializeField();
        }
        public void printField()
        {
            Console.Clear();
            for (var i = 0; i < _field.RowCount; i++)
            {
                for (var j = 0; j < _field.ColumnCount; j++)
                {
                    var tile = _field[i, j];
                    if (tile != null)
                    {
                        Console.Write("{0,3}", tile.Character);
                    }
                }
                Console.WriteLine();
            }
        }

        public void rules()
        {
            Console.WriteLine("\n\t\tThe object is to link adjacent dots so:\n");
            Console.WriteLine("\t*The value of each clue equals the number of links surrounding it\n");
            Console.WriteLine("\t*Empty squares may be surrounded by any number of links\n");
            Console.WriteLine("\t*When completed, the solution forms a single continuous loop with no crossings or branches\n");
            Console.WriteLine("\n\t\t\tPress any button");
            Console.ReadKey();
        }
        public void Menu()
        {
            Console.WriteLine("\t\tWelcome to Slitherlink!\n");
            Console.WriteLine("1.Play game\n");
            Console.WriteLine("2.Game rules\n");
            Console.WriteLine("3.Exit game\n");
            Console.WriteLine("\n");
            Console.WriteLine("Choose one!\n");
            string text = Console.ReadLine();
            switch (text)
            {
                case "play":
                    printField();
                    do
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
                        _game.action(what_to_do, x, y, typ);

                        Console.Clear();
                        printField();
                    } while (!_field.isSolved());
                    scoreService.addScore(new Score { Player = Environment.UserName, score = _field.getScore(), DateTime = DateTime.Now });
                    Console.WriteLine("Time " + _field.getScore() + " seconds\n");
                    Console.WriteLine("Teraz si môžeš zadať komentár a ohodnotiť hru od 1 po 5\n");
                    hodnotenieGame.Rate();

                    Console.WriteLine("Game over! Press any button");
                    break;
                case "rules":
                    Console.Clear();
                    rules();
                    Console.Clear();
                    Menu();
                    break;
                case "exit":
                    Console.Clear();
                    Console.WriteLine("\n\n\t\tGood luck!\n");
                    System.Environment.Exit(0);
                    break;
                default:
                    Console.Clear();
                    Menu();
                    break;
            }
        }
    }
}
