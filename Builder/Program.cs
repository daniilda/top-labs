using System;
using System.Text;

namespace Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            var baker = new Baker();
            BreadBuilder builder = new RyeBreadBuilder();
            var ryeBread = baker.Bake(builder);
            Console.WriteLine(ryeBread.ToString());
            builder = new WheatBreadBuilder();
            var wheatBread = baker.Bake(builder);
            Console.WriteLine(wheatBread.ToString());
            Console.Read();
        }
    }

    abstract class BreadBuilder
    {
        public Bread Bread { get; private set; }

        public void CreateBread()
            => Bread = new Bread();

        public abstract void SetFlour();
        public abstract void SetSalt();
        public abstract void SetAdditives();
    }

    internal class Baker
    {
        public Bread Bake(BreadBuilder breadBuilder)
        {
            breadBuilder.CreateBread();
            breadBuilder.SetFlour();
            breadBuilder.SetSalt();
            breadBuilder.SetAdditives();
            return breadBuilder.Bread;
        }
    }

    internal class RyeBreadBuilder : BreadBuilder
    {
        public override void SetFlour()
            => Bread.Flour = new Flour { Sort = "Ржаная мука 1 сорт" };

        public override void SetSalt()
            => Bread.Salt = new Salt();

        public override void SetAdditives()
        {
        }
    }

    internal class WheatBreadBuilder : BreadBuilder
    {
        public override void SetFlour()
            => Bread.Flour = new Flour { Sort = "Пшеничная мука высший сорт" };

        public override void SetSalt()
            => Bread.Salt = new Salt();

        public override void SetAdditives()
            => Bread.Additives = new Additives { Name = "улучшитель хлебопекарный" };
    }

    internal class Flour
    { public string Sort { get; set; } }

    internal class Salt
    { }

    internal class Additives
    {
        public string Name { get; set; }
    }

    class Bread
    {
        public Flour Flour { get; set; }
        public Salt Salt { get; set; }
        public Additives Additives { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            if (Flour != null)
                sb.Append(Flour.Sort + "\n");
            if (Salt != null)
                sb.Append("Соль \n");
            if (Additives != null)
                sb.Append("Добавки: " + Additives.Name + " \n");
            return sb.ToString();
        }
    }
}