using System;

namespace Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            var hole = new RoundHole(5);
            var roundStick = new RoundStick(5);
            Console.WriteLine(hole.Fits(roundStick)); // TRUE
        
            var smallSquareStick = new SquareStick(5);
            var largeSquareStick = new SquareStick(10);
        
            var smallSquareStickAdapter = new SquareStickAdapter(smallSquareStick);
            var largeSquareStickAdapter = new SquareStickAdapter(largeSquareStick);
        
            Console.WriteLine(hole.Fits(smallSquareStickAdapter)); // TRUE
            Console.WriteLine(hole.Fits(largeSquareStickAdapter)); // FALSE
        }
    }

    internal class RoundHole
    {
        private readonly int _radius;

        public RoundHole(int radius)
            => _radius = radius;

        public bool Fits(RoundStick stick)
            => _radius >= stick.Radius;
    }

    internal class RoundStick
    {
        public int Radius { get; init; }

        public RoundStick(int radius)
            => Radius = radius;
    }

    internal class SquareStick
    {
        public int Width { get; init; }

        public SquareStick(int width)
            => Width = width;
    }
    internal class SquareStickAdapter : RoundStick
    {
        private readonly SquareStick _stick;
        public SquareStickAdapter(SquareStick stick) : base((int)(stick.Width * Math.Sqrt(2)/2))
            => _stick = stick;
    }
}