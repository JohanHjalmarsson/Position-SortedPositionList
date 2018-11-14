using System;

namespace Lab2
{
    public class Position
    {
        int x;
        int y;

        public int X
        {
            get {return x;}
            set => x = value < 0 ? Math.Abs(value) : value;

        }

        public int Y
        {
            get{return y;}
            set => y = value < 0 ? Math.Abs(value) : value;

        }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public double Lenght()
        {
            double result = (x * x) + (y * y);
            return Math.Sqrt(result);
        }

        public bool Equals(Position p)
        {
            return (p.x == this.x && p.y == this.y);
        }

        public Position Clone()
        {
            return new Position(this.x, this.y);
        }

        public override string ToString()
        {
            string res = "(" + this.x + ", " + this.y + ")";
            return res;
        }

        public static bool operator > (Position p1, Position p2)
        {
            return p1.Lenght() > p2.Lenght();
        }

        public static bool operator < (Position p1, Position p2)
        {
            return p1.Lenght() < p2.Lenght();
        }

        public static Position operator + (Position p1, Position p2)
        {
            var x = p1.x + p2.x;
            var y = p1.y + p2.y;
            return new Position(x, y);
        }

        public static Position operator - (Position p1, Position p2)
        {
            var x = p1.x - p2.x;
            var y = p1.y - p2.y;
            return new Position(x, y);
        }

        public static double operator % (Position p1, Position p2)
        {
            var x2 = (p1.x - p2.x) * (p1.x - p2.x);
            var y2 = (p1.y - p2.y) * (p1.y - p2.y);
            return Math.Sqrt(x2 + y2);
        }

    }
}