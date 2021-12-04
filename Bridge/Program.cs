using System;

namespace Bridge
{
    class Program
    {
        static void Main(string[] args)
        {
            TestDevice(new Tv());
            
            void TestDevice(IDevice device)
            {
                Console.WriteLine("Tests with basic remote.");
                var basicRemote = new BasicRemote(device);
                basicRemote.Power();
                Console.WriteLine(device.PrintStatus());

                Console.WriteLine("Tests with advanced remote.");
                var advancedRemote = new AdvanceRemote(device);
                advancedRemote.Power();
                advancedRemote.VolumeUp();
                advancedRemote.Mute();
                Console.WriteLine(device.PrintStatus());
            }
        }
    }

    public interface IDevice
    {
        public bool IsEnabled { get; }
        public int Volume { get; set; }
        public int Channel { get; set; }

        public void Enable();

        public void Disable();
        public string PrintStatus();
    }

    public class Radio : IDevice
    {
        private bool _isEnabled;
        public bool IsEnabled => _isEnabled;

        private int _volume;
        public int Volume
        {
            get => _volume;
            set => _volume = value switch
                {
                    > 100 => 100,
                    < 0 => 0,
                    _ => value
                };
        }
        
        public int Channel { get; set; }

        public void Enable()
            => _isEnabled = true;

        public void Disable()
            => _isEnabled = false;

        public string PrintStatus()
        {
            return "------------------------------------\n"
                   + "| I'm radio. \n"
                   + "| I'm " + (_isEnabled ? "enabled" : "disabled") + "\n"
                   + "| Current volume is " + _volume + "%" + "\n"
                   + "| Current channel is " + Channel + "\n"
                   + "------------------------------------\n";
        }
    }

    public class Tv : IDevice
    {
        private bool _isEnabled;
        public bool IsEnabled => _isEnabled;

        private int _volume;
        public int Volume
        {
            get => _volume;
            set => _volume = value switch
            {
                > 100 => 100,
                < 0 => 0,
                _ => value
            };
        }
        
        public int Channel { get; set; }

        public void Enable()
            => _isEnabled = true;

        public void Disable()
            => _isEnabled = false;

        public string PrintStatus()
        {
            return "------------------------------------\n"
                   + "| I'm TV. \n"
                   + "| I'm " + (_isEnabled ? "enabled" : "disabled") + "\n"
                   + "| Current volume is " + _volume + "%" + "\n"
                   + "| Current channel is " + Channel + "\n"
                   + "------------------------------------\n";
        }
    }

    internal interface IRemote
    {
        void Power();
        void VolumeDown();
        void VolumeUp();
        void ChannelDown();
        void ChannelUp();
    }

    public class BasicRemote : IRemote
    {
        protected IDevice _device;
        
        public BasicRemote(IDevice device)
            => _device = device;

        public void Power()
        {
            Console.WriteLine("Remote: power toggle");
            if (_device.IsEnabled)
                _device.Disable();
            else
                _device.Enable();
        }

        public void VolumeDown()
        {
            _device.Volume -= 10;
        }

        public void VolumeUp()
        {
            Console.WriteLine("Remote: volume up");
            _device.Volume += 10;
        }

        public void ChannelDown()
        {
            Console.WriteLine("Remote: channel down");
            _device.Channel -= 1;
        }

        public void ChannelUp()
        {
            Console.WriteLine("Remote: channel up");
            _device.Channel += 1;
        }
    }

    public class AdvanceRemote : BasicRemote
    {
        public AdvanceRemote(IDevice device) : base(device)
            => _device = device;

        public void Mute()
        {
            Console.WriteLine("Remote: mute");
            _device.Volume = 0;
        }
    }
}