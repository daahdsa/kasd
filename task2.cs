using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_2
{
    internal class task2
    {

        public struct Complex
        {
            public double re;
            public double im;
            public Complex(double re, double im) { this.re = re; this.im = im; }

            public static Complex operator +(Complex a, Complex b)
            {
                return new Complex(a.re + b.re, a.im + b.im);
            }
            public static Complex operator -(Complex a, Complex b)
            {
                return new Complex(a.re - b.re, a.im - b.im);
            }
            public static Complex operator *(Complex a, Complex b)
            {
                return new Complex(a.re * b.re-a.im * b.im, a.im*b.re+a.re+b.im);
            }
            public static Complex operator /(Complex a, Complex b)
            {
                double znam=a.re*b.re+a.im*b.im;
                if (znam == 0)
                throw new DivideByZeroException("ошибка, деление на 0");
                return new Complex(a.re * b.re + a.im * b.im, a.im * b.re - a.re + b.im);
            }

            public double Mod()
            {
                return Math.Sqrt(re*re+im*im);
            }

            public override string ToString()
            {
                return $"{re} + {im}i";
            }

            public double Arg()
            {
                if (re > 0) return Math.Atan(im / re);
                else if (re < 0 && im >= 0) return Math.PI / Math.Atan(im / re);
                else if (re < 0 && im < 0) return -Math.PI / Math.Atan(im / re);
                else if (re == 0 && im > 0) return Math.PI/2;
                else if (re == 0 && im < 0) return -Math.PI / 2;

                else
                {
                    throw new InvalidOperationException("Аргумент не определен для комплексного числа (0, 0).");
                }
            }

        }



        static void Main(string[] args)
        {
            Complex t = new Complex(0, 0);


            bool f = true;
            while (f == true)
            {

                Console.WriteLine("//////////////////////////////////////////////////////////////////");
                Console.WriteLine("\nТекущее комплексное число: " + t + "\n");
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("a - +");
                Console.WriteLine("b - -");
                Console.WriteLine("c - *");
                Console.WriteLine("d - /");
                Console.WriteLine("e - mod");
                Console.WriteLine("f - arg");
                Console.WriteLine("g - показать число");
                Console.WriteLine("h - показать вещественную часть");
                Console.WriteLine("i - показать мнимую часть");
                Console.WriteLine("q - выйти");
                Console.WriteLine("//////////////////////////////////////////////////////////////////");
                Console.WriteLine("Ввод...");



                string choice = Console.ReadLine();


                switch (choice)
                {
                    case "a":
                        t = t + ReadSecComplex();
                        break;
                    case "b":
                        t = t - ReadSecComplex();
                        break;
                    case "c":
                        t = t * ReadSecComplex();
                        break;
                    case "d":
                        try
                        {
                            t = t / ReadSecComplex();
                        }
                        catch (DivideByZeroException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case "e":
                        Console.WriteLine(t.Mod());
                        break;
                    case "f":
                        Console.WriteLine(t.Arg());
                        break;
                    case "g":
                        Console.WriteLine("текщее число: "+t);
                        break;
                    case "h":
                        Console.WriteLine("вещественная часть: " + t.re); ;
                        break;
                    case "i":
                        Console.WriteLine("мнимая часть: " + t.im); ;
                        break;
                    case "q":
                        f = false;
                        break;

                    default: Console.WriteLine("неизвестная команда"); break;
                }

            }

        }
        private static Complex ReadSecComplex()
        {
            Console.Write("Введите вещественную часть: ");
            double re = double.Parse(Console.ReadLine());
            Console.Write("Введите мнимую часть: ");
            double im = double.Parse(Console.ReadLine());
            return new Complex(re, im);
        }
    }
}
