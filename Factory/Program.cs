using System;

namespace Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new WebWindow();
            a.Render();
            var b = new MobWindow();
            b.Render();
        }
    }

    interface IWindow
    {
        void Render();
    }

    interface IButton
    {
        void Render();
    }

    class WebWindow : Window
    {
        protected override IButton GetButton()
        {
            return new WebButton();
        }
    }

    class MobWindow : Window
    {
        protected override IButton GetButton()
        {
            return new MobButton();
        }
    }

    class WebButton : IButton
    {
        public void Render()
        {
            Console.WriteLine("Веб-кнопка отрендерелась");
        }
    }

    class MobButton : IButton
    {
        public void Render()
        {
            Console.WriteLine("Мобильная кнопка отрендерелась");
        }
    }

    abstract class Window : IWindow
    {
        protected abstract IButton GetButton();

        public void Render()
        {
            IButton button = GetButton();
            button.Render();
            Console.WriteLine("Окно отредерилось");
        }
    }
}