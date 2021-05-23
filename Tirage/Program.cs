using System;
using System.Collections.Generic;

namespace Tirage
{
    class Program
    {
        static void Main(string[] args)
        {
            int sides = 0;//Number of sides of the bone.
            int points = 0;//Points in the game.
            Random dice = new Random();
            for (int i = 0; i < 3; i++)
            {
                try
                {
                    //Set the number of points for choosing a game.
                    points = int.Parse(Console.ReadLine());

                    //Input validation.
                    if (points != 4 && points != 5 && points != 6 && points != 7 && points != 8 && points != 12)
                    {
                        if (i == 2)
                        {
                            Console.WriteLine("Game over");
                            break;
                        }
                        Console.WriteLine("Enter the number 4-8,12");
                        continue;
                    }
                    else break;
                }
                catch (FormatException)
                {
                    if (i == 2)
                    {
                        Console.WriteLine("Game over");
                        break;
                    }

                    Console.WriteLine("Enter the number 4-8,12");
                    continue;
                }
            }

            //The game is selected by points.
            GetSide(points);
            if (sides == 0) return;
            Console.Write("Roll a die for {0}:  ", sides);//Tells which game is selected.

            //Roll a die.
            Tirag();
            Console.WriteLine();
            if (points == 4)
            {
                Console.Write($"\t\t    ");
                Tirag();// Roll a die again for a 4of20-game.
                Console.WriteLine();
            }

            //Console.WriteLine(DateTime.Now.ToString());

            Console.ReadKey();

            //Choice of game by points.
            int GetSide(int a)
            {
                switch (a)
                {
                    case 4: sides = 20; break;
                    case 5: sides = 36; break;
                    case 6: sides = 45; break;
                    case 7: sides = 49; break;
                    case 8: sides = 20; break;
                    case 12: sides = 24; break;
                }
                return a;
            }
            //Launch of the drawing.
            void Tirag()
            {
                HashSet<int> tirag = new HashSet<int>();
                while(tirag.Count < points)
                {
                    int d = dice.Next(1, sides + 1);
                    tirag.Add(d);
                }
                foreach (int i in tirag)
                {
                        Console.Write(" " + i);//The draw report.
                }
            }
        }
    }
}

