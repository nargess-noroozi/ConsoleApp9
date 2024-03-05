using System;

namespace ConsoleApp9
{
    class Program
    {
               static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of iterations: ");
            int iterations = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the step size:  ");
            double step_size = double.Parse(Console.ReadLine());
            (double x, double y, double best) = HillClimbing(iterations, step_size);
            Console.WriteLine($"Location ({x},{y}) Value : {best}");
        }
        static double Ackley(double x, double y)
        {
            double a = 20;
            double b = 0.2;
            double c = 2 * Math.PI;
            double ackley = -a * Math.Exp(-b * Math.Sqrt(0.5 * (x * x + y * y))) - Math.Exp(0.5 * (Math.Cos(c * x) + Math.Cos(c * y))) + a + Math.Exp(1); ;
            return ackley;
        }

        static (double, double, double) HillClimbing(int iterations, double step)
        {
            Random rand = new Random();
            double x = rand.NextDouble() * 20 - 10;
            double y = rand.NextDouble() * 20 - 10;
            double best = Ackley(x, y);

            for (int i = 0; i < iterations; i++)
            {
                double x_new = x + (rand.NextDouble() * 2 * step) - step;
                double y_new = y + (rand.NextDouble() * 2 * step) - step;
                double newsloution = Ackley(x_new, y_new);
                if (best > newsloution)
                {
                    x = x_new;
                    y = y_new;
                    best = newsloution;
                }
            }
            return (x, y, best);
        }
    }
}
