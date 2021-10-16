using System;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new ClassicFactory();
            var b = new Furniture(a);
            b.Use();
            var c = new ModernFactory();
            var d = new Furniture(c);
            d.Use();
        }
    }

    abstract class AbstractFactory
    {
        public abstract Chair CreateChair();
        public abstract Table CreateTable();
        public abstract Sofa CreateSofa();
    }

    class ClassicFactory : AbstractFactory
    {
        public override ClChair CreateChair()
        {
            return new ClChair();
        }

        public override ClTable CreateTable()
        {
            return new ClTable();
        }

        public override Sofa CreateSofa()
        {
            return new ClSofa();
        }
    }

    class ModernFactory : AbstractFactory
    {
        public override Chair CreateChair()
        {
            return new ModChair();
        }

        public override Table CreateTable()
        {
            return new ModTable();
        }

        public override Sofa CreateSofa()
        {
            return new ModSofa();
        }
    }

    abstract class Chair
    {
        public abstract void OnUse();
    }

    abstract class Table
    {
        public abstract void OnUse();
    }

    abstract class Sofa
    {
        public abstract void OnUse();
    }

    class ModChair : Chair
    {
        public override void OnUse()
        {
            Console.WriteLine("МодернСтул");
        }
    }

    class ModTable : Table
    {
        public override void OnUse()
        {
            Console.WriteLine("МодернСтол");
        }
    }

    class ModSofa : Sofa
    {
        public override void OnUse()
        {
            Console.WriteLine("МодернДиван");
        }
    }

    class ClChair : Chair
    {
        public override void OnUse()
        {
            Console.WriteLine("КлассикСтул");
        }
    }

    class ClTable : Table
    {
        public override void OnUse()
        {
            Console.WriteLine("КлассикСтол");
        }
    }

    class ClSofa : Sofa
    {
        public override void OnUse()
        {
            Console.WriteLine("Классикдиван");
        }
    }

    class Furniture
    {
        private Chair _chair;
        private Table _table;
        private Sofa _sofa;

        public Furniture(AbstractFactory factory)
        {
            _chair = factory.CreateChair();
            _table = factory.CreateTable();
            _sofa = factory.CreateSofa();
        }

        public void Use()
        {
            _chair.OnUse();
            _table.OnUse();
            _sofa.OnUse();
        }
    }
}