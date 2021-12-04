using System;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public abstract class AbstractFactory
    {
        public abstract Chair CreateChair();
        public abstract Table CreateTable();
        public abstract Sofa CreateSofa();
    }

    public class ClassicFactory : AbstractFactory
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

    public class ModernFactory : AbstractFactory
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

    public abstract class Chair
    {
        public abstract string OnUse();
    }

    public abstract class Table
    {
        public abstract string OnUse();
    }

    public abstract class Sofa
    {
        public abstract string OnUse();
    }

    public class ModChair : Chair
    {
        public override string OnUse()
        {
            return "МодернСтул";
        }
    }

    public class ModTable : Table
    {
        public override string OnUse()
        {
            return "МодернСтол";
        }
    }

    public class ModSofa : Sofa
    {
        public override string OnUse()
        {
            return "МодернДиван";
        }
    }

    public class ClChair : Chair
    {
        public override string OnUse()
        {
            return "КлассикСтул";
        }
    }

    public class ClTable : Table
    {
        public override string OnUse()
        {
            return "КлассикСтол";
        }
    }

    public class ClSofa : Sofa
    {
        public override string OnUse()
        {
           return "Классикдиван";
        }
    }

    public class Furniture
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

        public string[] Use()
        {
            var usage = new string[3];
            usage[0] = _chair.OnUse();
            usage[1] = _table.OnUse();
            usage[2] = _sofa.OnUse();
            return usage;
        }
    }
}