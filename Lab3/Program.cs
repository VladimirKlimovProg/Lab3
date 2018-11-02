using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            const int k = 10;
            const double a = 0.1, b = 1;

            for (double x = 0.1; x <= 1; x += (b-a)/k)
            {
                //точное значение функции
                double y = (1 + 2 * x * x) * Math.Exp(x * x);

                //значение суммы ряда для заданного n (n = 10)
                double sn = 1;
                double fact = 1;
                for (int n = 1; n <= 10; n++)
                {
                    fact = n * fact;
                    sn = sn + ((2 * n + 1) / fact) * Math.Pow(x, 2 * n);
                }

                //значение суммы ряда для заданной точности eps (eps = 0.0001)
                const double eps = 0.0001;
                double se = 1;
                double fact2 = 1;
                int m = 1;
                double currentTerm = 1;
                while (currentTerm > eps)
                {
                    fact2 = m * fact2;
                    currentTerm = ((2 * m + 1) / fact2) * Math.Pow(x, 2 * m);
                    se = se + currentTerm;
                    m++;
                }

                Console.WriteLine($"x = {String.Format("{0:0.00}",x)} Sn = {String.Format("{0:0.00000000000000}", sn)}" +
                    $" Se = {String.Format("{0:0.00000000000000}", se)} y = {String.Format("{0:0.00000000000000}",y)} ");
            }

            Console.ReadLine();
        }
    }
}
