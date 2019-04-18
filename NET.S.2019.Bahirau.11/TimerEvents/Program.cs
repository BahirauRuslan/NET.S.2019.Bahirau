using System;

namespace TimerEvents
{
    public class Program
    {
        private static int _idpeek = 1;
        private static MyTimer _timer = new MyTimer(0);

        public static void Main()
        {
            while (MainMenu())
            {
            }
        }
        
        private static bool MainMenu()
        {
            var enabled = true;
            var menu = "1. Set timer\n2. Start timer\n" +
                "3. Add user to timer\nCase: ";
            var menuCase = GetInt(menu);
            switch (menuCase)
            {
                case 1:
                    SetTimer();
                    break;
                case 2:
                    _timer.Start();
                    break;
                case 3:
                    AddUserToTimer();
                    break;
                default:
                    enabled = false;
                    break;
            }

            return enabled;
        }

        private static void SetTimer()
        {
            var time = GetInt("Time delay: ");
            _timer = new MyTimer(time);
        }

        private static void AddUserToTimer()
        {
            var user = new ConsoleUser(_idpeek++);
            _timer.Beep += user.ReceiveMessage;
            Console.WriteLine("Add user #{0}", user.UserId);
        }
        
        private static int GetInt(string msg)
        {
            int num;
            Console.Write(msg);
            var strNum = Console.ReadLine();
            while (!int.TryParse(strNum, out num))
            {
                Console.Write("Try again: ");
                strNum = Console.ReadLine();
            }

            return num;
        }
    }
}
