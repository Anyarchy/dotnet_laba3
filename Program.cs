using System;

namespace Lab_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Для вибору квадрату натиснiть 1, для прямокутника 2: ");
            ConsoleKeyInfo s = Console.ReadKey();
            Console.WriteLine();

            switch (s.Key)
            {
                case ConsoleKey.D1:
                    int x = GetInt("Введiть сторону: ");
                    Console.WriteLine();
                    SquareFigure sf = new(x, Console.GetCursorPosition().Top);
                    sf.Create();
                    break;

                case ConsoleKey.D2:
                    int y_ = GetInt("Введiть довжину: ");
                    int x_ = GetInt("Введiть ширину: ");
                    Console.WriteLine();
                    RectangleFigure rf = new(x_, y_, Console.GetCursorPosition().Top);
                    rf.Create();
                    break;

                default:
                    throw new Exception("Один або два");
            }

            Console.WriteLine();
        }

        static int GetInt(string message)
        {
            Console.Write(message);
            string s = Console.ReadLine();
            int i;

            while (!int.TryParse(s, out i))
            {
                Console.Write("Введiть число типу Int32: ");
                s = Console.ReadLine();
            }

            return i;
        }
    }
}
