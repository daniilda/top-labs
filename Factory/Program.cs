using System;

namespace Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new WebWindow();
            Console.WriteLine(a.Render());
            var b = new MobWindow();
            Console.WriteLine(b.Render());
        }
    }

    interface IWindow
    {
        string Render();
    }

    public interface IButton
    {
        string Render();
    }

    public class WebWindow : Window
    {
        protected override IButton GetButton()
        {
            return new WebButton();
        }
    }

    public class MobWindow : Window
    {
        protected override IButton GetButton()
        {
            return new MobButton();
        }
    }

    class WebButton : IButton
    {
        public string Render()
        {
            return "Веб-кнопка отрендерелась";
        }
    }

    class MobButton : IButton
    {
        public string Render()
        {
            return "Мобильная кнопка отрендерелась";
        }
    }

    public abstract class Window : IWindow
    {
        protected abstract IButton GetButton();

        public string Render()
        {
            IButton button = GetButton();
            return "Окно отредерилось" + " " + button.Render();;
        }
    }
}