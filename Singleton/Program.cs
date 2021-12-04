using System;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            var b = Singleton.GetInstance();
            Console.WriteLine(b.Inc());
            Console.WriteLine(b.Inc());
            Console.WriteLine(b.Inc());
            var c = Singleton.GetInstance();
            Console.WriteLine(c.Inc());
            Console.WriteLine(b.Inc());
            Console.WriteLine(c.Inc());
        }
    }

    public class Singleton
    {
        private static Singleton instance;

        public static Singleton GetInstance()
        {
            if (instance != null) return instance;
            instance = new Singleton();
            return instance;

        }

        private int a = 0;

        public int Inc()
        {
            return a++;
        }
    }
}