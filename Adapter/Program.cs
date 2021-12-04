using System;

namespace Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class RoundHole
    {
        private readonly int _radius;

        public RoundHole(int radius)
            => _radius = radius;

        public bool Fits(RoundStick stick)
            => _radius >= stick.Radius;
    }

    public class RoundStick
    {
        public int Radius { get; }

        public RoundStick(int radius)
            => Radius = radius;
    }

    public class SquareStick
    {
        public int Width { get; init; }

        public SquareStick(int width)
            => Width = width;
    }

    public class SquareStickAdapter : RoundStick
    {
        private readonly SquareStick _stick;
        public SquareStickAdapter(SquareStick stick) : base((int)(stick.Width * Math.Sqrt(2)/2))
            => _stick = stick;
    }
}