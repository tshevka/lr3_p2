using System;
using System.Collections.Generic;
using System.Text;

namespace lr_3_p2
{
    class MyFrac
    {
        public long nom, denom;
        public MyFrac(long nom_, long denom_)
        {
            //беремо по модулю, щоб працювало і з від'ємними числами
            long check_nom = Math.Abs(nom_);
            long check_denom = Math.Abs(denom_);
            //Якщо в знаменнику мінус, то переношу його в чисельник
            if (denom_ < 0)
            {
                nom = -nom_;//переношу мінус у чисельник
                denom = Math.Abs(denom_);
            }
            else
            {
                nom = nom_;
                denom = denom_;
            }

            while ((check_nom != 0) && (check_denom != 0))
            {
                if (check_nom > check_denom)
                    check_nom %= check_denom;
                else
                    check_denom %= check_nom;
            }
            this.nom /= Math.Max(check_nom, check_denom);
            this.denom /= Math.Max(check_nom, check_denom);
        }


        public override string ToString()
        {
            return String.Format("{0}/{1}", this.nom, this.denom);
        }

        public static void Show(MyFrac frac1, MyFrac frac2, MyFrac frac3, int n)
        {
            Console.WriteLine("Перший дрiб: " + frac1);
            Console.WriteLine("Другий дрiб: " + frac2);
            Console.WriteLine("Третiй дрiб: " + frac3);

            Console.WriteLine("Цiла частина третього дробу: " + ToStringWithIntegerPart(frac3));
            Console.WriteLine("Десятковий запис першого дробу: " + DoubleValue(frac1));

            Console.WriteLine("Cума двох перших дробiв: " + Plus(frac1, frac2));

            Console.WriteLine("Рiзниця двох перших дробiв: " + Minus(frac1, frac2));

            Console.WriteLine("Добуток двох перших дробiв: " + Multiply(frac1, frac2));

            Console.WriteLine("Частка двох перших дробiв: " + Divide(frac1, frac2));

            Console.WriteLine("(1–1/4)*(1–1/9)*(1–1/16)*...*(1–1/" + n + "^2) = " + GetRGR115LeftSum(n));
            Console.WriteLine("1/(1*3)+1/(3*5)+1/(5*7)+...+1/((2*" + n + "–1)*(2*" + n + "+1)) = " + GetRGR113LeftSum(n));
        }

        static string ToStringWithIntegerPart(MyFrac frac1)
        {
            long whole_part = frac1.nom / frac1.denom;
            long remainder = frac1.nom % frac1.denom;
            return String.Format("({0}+{1}/{2})", whole_part, remainder, frac1.denom);
        }
        static double DoubleValue(MyFrac frac1)
        {
            double decimal_part = (double)frac1.nom / frac1.denom;
            return decimal_part;
        }
        static MyFrac Plus(MyFrac frac1, MyFrac frac2)
        {
            return new MyFrac(frac1.nom * frac2.denom + frac1.denom * frac2.nom,
            frac1.denom * frac2.denom);
        }
        static MyFrac Minus(MyFrac frac1, MyFrac frac2)
        {
            return new MyFrac(frac1.nom * frac2.denom - frac1.denom * frac2.nom,
            frac1.denom * frac2.denom);
        }
        static MyFrac Multiply(MyFrac frac1, MyFrac frac2)
        {
            return new MyFrac(frac1.nom * frac2.nom,
            frac1.denom * frac2.denom);
        }
        static MyFrac Divide(MyFrac frac1, MyFrac frac2)
        {

            return new MyFrac(frac1.nom * frac2.denom,
            frac1.denom * frac2.nom);
        }
        static MyFrac GetRGR115LeftSum(int n)
        {
            MyFrac result = new MyFrac(1, 1);

            for (int i = 2; i <= n; i++)
            {
                result = Multiply(result, Minus(new MyFrac(1, 1), new MyFrac(1, i * i)));
            }
            return result;
        }
        static MyFrac GetRGR113LeftSum(int n)
        {
            MyFrac res = new MyFrac(1, 1 * 3);

            for (int i = 2; i <= n; i++)
            {
                MyFrac denres = new MyFrac(1, (2 * i - 1) * (2 * i + 1));
                res = Plus(res, denres);
            }
            return res;
        }
    }
}
