using System;
using System.Collections.Generic;

namespace Tirage
{
    class Program
    {
        static void Main(string[] args)
        {
            int b = 0;
            int x = 0;
            Random dice = new Random();
            for (int i = 0; i < 5; i++)
            {
                try
                {
                    x = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Введите число 4-8,12");
                    continue;
                }
                if (x != 4 && x != 5 && x != 6 && x != 7 && x != 8 && x != 12)
                {
                    Console.WriteLine("Введите число 4-8,12");
                    continue;
                }
                else break;
            }
            GetSide(x);
            Console.Write("Roll a die for {0}:  ", b);
            Tirag();
            Console.WriteLine();
            if (x == 4)
            {
                Console.Write($"\t\t    ");
                Tirag();
                Console.WriteLine();
            }

            Console.WriteLine(DateTime.Now.ToString());


            Console.ReadKey();
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
                        Console.Write(" " + i);
                }
            }
        }
    }
}

