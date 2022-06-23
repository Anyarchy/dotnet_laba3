using System;

namespace Lab_3
{
    //Абстрактний клас для фігури
    abstract class Figure
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int E { get; set; }

        public Figure(int x, int e, int y = 0)
        {
            X = x;
            Y = y;
            E = e;
        }

        //Factory Method
        abstract public Create Create();
    }

    //Виводить квадрат з заданою стороною
    class SquareFigure : Figure
    {
        public SquareFigure(int x, int e) : base(x, e)
        { }

        public override Create Create()
        {
            return new SquareMaker(X, E);
        }
    }

    //Виводить квадрат з заданою шириною та довжиною
    class RectangleFigure : Figure
    {
        public RectangleFigure(int x, int y, int e) : base(x, e, y)
        { }

        public override Create Create()
        {
            return new RectangleMaker(X, Y, E);
        }
    }

    abstract class Create
    {
        public abstract void PrintFigure(int e, params int[] sides);

        public static void PrintLength(int x, int y, int e)
        {
            AlgorytmX(x, y, e, false);
            AlgorytmX(x, y, e, true);
        }

        public static void PrintWidth(int x, int y, int e)
        {
            AlgorytmY(y, x, e, false);
            AlgorytmY(y, x, e, true);
        }

        private static void AlgorytmX(int x, int y, int e, bool isSecond)
        {
            for (int i = 0; i < x * 2; i += 2)
            {
                Console.SetCursorPosition(i, isSecond ? y + e - 1 : e);
                Console.Write("o");
            }
        }

        private static void AlgorytmY(int y, int x, int e, bool isSecond)
        {
            for (int i = e; i < y + e; i++)
            {
                Console.SetCursorPosition(isSecond ? x * 2 - 2 : 0, i);
                Console.Write("o");
            }
        }
    }

    class SquareMaker : Create
    {
        public SquareMaker(int x, int e)
        {
            PrintFigure(e, x);
        }

        public override void PrintFigure(int e, params int[] sides)
        {
            int x = sides[0];

            PrintLength(x, x, e);
            PrintWidth(x, x, e);
        }
    }

    class RectangleMaker : Create
    {
        public RectangleMaker(int x, int y, int e)
        {
            PrintFigure(e, x, y);
        }

        public override void PrintFigure(int e, params int[] sides)
        {
            int x = sides[0];
            int y = sides[1];

            PrintLength(x, y, e);
            PrintWidth(x, y, e);
        }
    }
}
