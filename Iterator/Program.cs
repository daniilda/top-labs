using System;
using System.Collections.Generic;

namespace Iterator
{
    class Program
    {
        static void Main(string[] args)
        {
            var menu = new Menu();
            var reader = new MenuReader();
            reader.SeeFoodItems(menu);
        }
    }

    public class MenuReader
    {
        public List<string> SeeFoodItems(Menu menu)
        {
            var iterator = menu.CreateNumerator();
            var result = new List<string>();
            while (iterator.HasNext())
            {
                var food = iterator.Next();
                result.Add(food.Name);
            }

            return result;
        }
    }

    public interface IFoodIterator
    {
        bool HasNext();
        Food Next();
    }

    public interface IFoodNumerable
    {
        IFoodIterator CreateNumerator();
        int Count { get; }
        Food this[int index] { get; }
    }

    public class Food
    {
        public string Name { get; set; }
    }

    public class Menu : IFoodNumerable
    {
        private Food[] _foodItems;

        public Menu()
        {
            _foodItems = new Food[]
            {
                new Food { Name = "Number 9" },
                new Food { Name = "Number 9 LARGE" },
                new Food { Name = "Number 6 WITH EXTRA DIP" },
                new Food { Name = "Number 7" },
                new Food { Name = "Number 45" },
                new Food { Name = "LargeSoda" }
            };
        }

        public int Count => _foodItems.Length;

        public Food this[int index] => _foodItems[index];

        public IFoodIterator CreateNumerator()
            => new MenuNumerator(this);
    }

    public class MenuNumerator : IFoodIterator
    {
        private readonly IFoodNumerable _aggregate;
        private int _index = 0;

        public MenuNumerator(IFoodNumerable a)
            => _aggregate = a;

        public bool HasNext()
            => _index < _aggregate.Count;

        public Food Next()
            => _aggregate[_index++];
    }
}