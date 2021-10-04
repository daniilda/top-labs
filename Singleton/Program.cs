using System;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            var b = Singleton.GetInstance();
            Console.WriteLine(b.Inc());
            var c = Singleton.GetInstance();
            Console.WriteLine(c.Inc());
        }
    }

    class Singleton
    {
        private static Singleton instance;

        public static Singleton GetInstance()
        {
            if (instance != null)
            {
                instance = new Singleton();
                return instance;
            }

            return instance;
        }

        private int a = 0;

        public int Inc()
        {
            return a++;
        }
    }
}