using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiffMethodsExample
{
    class Program
    {
        static void Main(string[] args)
        {

            Bus bus1 = new Bus(13);
            Bus bus2 = new Bus(17);
            Wheel wheel1 = new Wheel(15);

            bus1.Drive();
            System.Threading.Thread.Sleep(25);
            bus2.Drive();
            bus2.VisitorTurnover();
            bus1.Pressure(23);
            wheel1.Pressure(34);

            Console.ReadKey();
        }
    }

    public abstract class Transport
    {
        public abstract void VisitorTurnover();
    }

    public class Bus : Transport
    {
        public static readonly DateTime StartTime;

        public int RouteNumber { get; set; }

        public int InputPressure { get; set; }

        static Bus()
        {
            StartTime = DateTime.Now;
            Console.WriteLine("Static constructor sets start time to {0}",StartTime.ToLongTimeString());
        }

        public Bus(int RouteNum)
        {
            RouteNumber = RouteNum;
            Console.WriteLine("Instance constructor is created. Bus number:{0}",RouteNumber);
        }

        public void Drive()
        {
            TimeSpan elapsedTime = DateTime.Now - StartTime;
            Console.WriteLine("{0} is starting its route {1} minutes after start time {1}",
                this.RouteNumber, elapsedTime.TotalMilliseconds, StartTime.ToShortTimeString() );
        }

        public override void VisitorTurnover()
        {
            var amount = 10000;
            Console.WriteLine("Amount of people are {0}",amount);
        }

        public virtual void Pressure(int inPressure)
        {
            InputPressure = inPressure;
            Console.WriteLine("Input pressure in the bus {0}", InputPressure);
        }



    }

    public class Wheel : Bus
    {
        public int WheelPressure { get; set; }

        public Wheel(int RouteNum) : base(RouteNum)
        { }
        public override void Pressure(int inPressure)
        {
            WheelPressure = inPressure;
            Console.WriteLine("Pressure in the wheel is {0}",WheelPressure);
        }
    }
}
