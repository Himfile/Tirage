using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    Console.WriteLine("Введите число 4-7,12");
                    continue;
                }
                if (x != 4 && x != 5 && x != 6 && x != 7 && x != 12)
                {
                    Console.WriteLine("Введите число 4-7,12");
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
            Console.ReadKey();
            int GetSide(int a)
            {
                switch (a)
                {
                    case 4: b = 20; break;
                    case 5: b = 36; break;
                    case 6: b = 45; break;
                    case 7: b = 49; break;
                    case 12:b = 24; break;
                }
                return a;
            }
            void Tirag()
            {
                for (int k = 1; k < 6; k++)
                {
                    HashSet<int> tirag = new HashSet<int>();
                    for (int counter = 0; counter < x; counter++)
                    {
                        int d = dice.Next(1, b + 1);
                        tirag.Add(d);
                    }
                    if (k > 1)
                    {
                        Console.WriteLine();
                        Console.Write($"Попытка {k}");
                        Console.Write($"\t  ");
                    }
                    foreach (int i in tirag)
                    {
                        if (tirag.Count == x)
                            Console.Write(" " + i);
                        if (tirag.Count == 0) Tirag();
                    }
                    if (tirag.Count == x) return;
                    if (k == 5) Console.WriteLine("Подходящая комбинация не найдена.");
                }
            }
        }
    }
}

