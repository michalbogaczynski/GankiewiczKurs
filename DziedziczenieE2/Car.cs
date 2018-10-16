using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DziedziczenieE2
{
    public abstract class Car
    {
        public double Acceleration { get; protected set; } = 10;
        public double Speed { get; protected set; } = 100;


        public void Start()
        {
            Console.WriteLine("Turning on the engine");
            Console.WriteLine($"Running at:{Speed} km/h");
        }

        public void Stop()
        {
            Console.WriteLine("Stopping the car");
        }

        public virtual void Accelerate()
        {
            Console.WriteLine("Accelerating...");
            Speed += Acceleration;
            Console.WriteLine($"Running at:{Speed} km/h");
        }

        public abstract void Boost();
    
    }

    public class Truck : Car
    {
        public override void Accelerate()
        {
            Console.WriteLine("Accelerating a truck");
            base.Accelerate(); // odwołuje się do klasy bazowej, wykonywana jest metoda z klasy bazowej
        }

        public override void Boost()
        {
            Console.WriteLine("Boositng a truck");
            Speed += 50;
            Console.WriteLine($"Running at:{Speed} km/h");
        }
    }

    public class SportCar : Car
    {
        public override void Accelerate()
        {
            Console.WriteLine("Accelerating a sport car");
            base.Accelerate();
        }

        public override void Boost()
        {
            Console.WriteLine("Boosting a sport car...");
            Speed += 100;
            Console.WriteLine($"Running at:{Speed} km/h");
        }
    }

    public class Race
    {
        public void Begin()
        {
            SportCar sportcar = new SportCar();
            Truck truck = new Truck();

            List<Car> cars = new List<Car>
            {
                sportcar, truck
            };

            foreach (Car car in cars)
            {
                car.Start();
                car.Accelerate();
                car.Boost();
            }
        }
    }
}
