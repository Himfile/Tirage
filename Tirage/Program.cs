using System;
using System.Collections.Generic;

namespace Tirage
{
    class Program
    {
        static void Main(string[] args)
        {
            int b = 0;//Number of sides of the bone.
            int x = 0;//Points in the game.
            Random dice = new Random();
            for (int i = 0; i < 3; i++)
            {
                try
                {
                    //Set the number of points for choosing a game.
                    x = int.Parse(Console.ReadLine());

                    //Input validation.
                    if (x != 4 && x != 5 && x != 6 && x != 7 && x != 8 && x != 12)
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
            GetSide(x);
            if (b == 0) return;
            Console.Write("Roll a die for {0}:  ", b);//Tells which game is selected.

            //Roll a die.
            Tirag();
            Console.WriteLine();
            if (x == 4)
            {
                Console.Write($"\t\t    ");
                Tirag();// Roll a die again for a 4of20-game.
                Console.WriteLine();
            }

            Console.WriteLine(DateTime.Now.ToString());

            Console.ReadKey();

            //Choice of game by points.
            int GetSide(int a)
            {
                switch (a)
                {
                    case 4: b = 20; break;
                    case 5: b = 36; break;
                    case 6: b = 45; break;
                    case 7: b = 49; break;
                    case 8: b = 20; break;
                    case 12: b = 24; break;
                }
                return a;
            }
            //Launch of the drawing.
            void Tirag()
            {
                HashSet<int> tirag = new HashSet<int>();
                while(tirag.Count < x)
                {
                    int d = dice.Next(1, b + 1);
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

