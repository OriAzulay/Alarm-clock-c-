using System;
using System.Threading;

namespace a.clock
{
    class Program
    {
        class AlarmClock
        {
            public bool stop;
            public delegate void whatToDo(string time);
            public event whatToDo costumEvent;
            public void start()
            {
                new Thread(delegate ()
                {
                    while (!stop)
                    {
                        string time = DateTime.Now.ToString("HH:mm: ss tt");
                        costumEvent(time);
                        Thread.Sleep(1000);

                    }
                }).Start();
            }
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            AlarmClock ac = new AlarmClock();
            ac.costumEvent += delegate (string time)
            {
                if (time.Equals("13:31: 00 PM"))
                {
                    Console.WriteLine("ALARM!");
                }
            };
            ac.costumEvent += delegate (string time)
            {
                Console.WriteLine(time);

            };


            ac.start();
            Thread.Sleep(3 * 60 * 1000);
            ac.stop = true;
            Console.ReadKey();
        }
    }
}
