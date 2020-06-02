using System;
using System.Collections.Generic;

namespace Tirage {
    class Program {
        static void Main (string[] args) {
            int b = 0;
            int x = 0;
            int[] Sides = { 20, 24, 36, 45, 49 };
            int[] xBool = { 4, 5, 6, 7, 8, 12 };

            Random dice = new Random ();
            for (int i = 0; i < 5; i++) {
                try {
                    x = int.Parse (Console.ReadLine ());
                } catch (FormatException) {
                    Console.WriteLine ("Введите число 4-8,12");
                    continue;
                }
                if (Array.IndexOf (xBool, x) < 0) {
                    Console.WriteLine ("Введите число 4-8,12");
                    continue;
                } else break;
            }
            GetSide (x);
            Console.Write ("Roll a die for {0}:  ", b);
            Tirag ();
            Console.WriteLine ();
            if (x == 4) {
                Console.Write ($"\t\t    ");
                Tirag ();
                Console.WriteLine ();
            }
            Console.ReadKey ();
            int GetSide (int a) {
                switch (a) {
                    case 4:
                        b = Sides[0];
                        break;
                    case 5:
                        b = Sides[2];
                        break;
                    case 6:
                        b = Sides[3];
                        break;
                    case 7:
                        b = Sides[4];
                        break;
                    case 8:
                        b = Sides[0];
                        break;
                    case 12:
                        b = Sides[1];
                        break;
                }
                return a;
            }
            void Tirag () {
                for (int k = 1; k <= x; k++) {
                    HashSet<int> tirag = new HashSet<int> ();
                    for (int counter = 0; counter < x; counter++) {
                        int d = dice.Next (1, b + 1);
                        tirag.Add (d);
                    }
                    if (k > 1) {
                        Console.WriteLine ();
                        Console.Write ($"Попытка {k}");
                        Console.Write ($"\t  ");
                    }
                    foreach (int i in tirag) {
                        if (tirag.Count == x)
                            Console.Write (" " + i);
                        if (tirag.Count == 0) Tirag ();
                    }
                    if (tirag.Count == x) return;
                    if (k == x) Console.WriteLine ("Подходящая комбинация не найдена.");
                }
            }
        }
    }
}