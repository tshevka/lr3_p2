using System;

namespace lr_3_p2
{
    public class Program
    {
        static void Main(string[] args)
        {
            MyFrac frac1 = new MyFrac(5, 40);
            MyFrac frac2 = new MyFrac(-3, 6);
            MyFrac frac3 = new MyFrac(45, 6);
            Console.Write("Введiть n: ");
            int n = int.Parse(Console.ReadLine());

            MyFrac.Show(frac1, frac2, frac3, n);

        }
    }
}