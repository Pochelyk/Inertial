﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structurs3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество сечений:");
            string circle = Console.ReadLine();
            int R = Convert.ToInt32(circle);

            double sum = 0;
            double CentrX = 0;
            double CentrY = 0;
            double SumCircles = 0;
            double SumBox = 0;

            Circle[] circles = new Circle[R];
            for (int i = 0; i < circles.Length; i++)
            {
                Console.WriteLine("Введите тип сечения К-квадрат, О-окружность:");
                string size = Console.ReadLine();
                switch (size)
                {
                    case "K":
                        Console.WriteLine("Введите размер стороны квадрата:");
                        string r1 = Console.ReadLine();
                        Console.WriteLine("Введите координату X");
                        string x1 = Console.ReadLine();
                        Console.WriteLine("Введите координату у");
                        string y1 = Console.ReadLine();
                        Console.WriteLine("Введите координату z");
                        string z1 = Console.ReadLine();
                        double P1 = Convert.ToDouble(r1);
                        double X1 = Convert.ToDouble(x1);
                        double Y1 = Convert.ToDouble(y1);
                        double Z1 = Convert.ToDouble(z1);
                        circles[i].R = P1;
                        circles[i].x1 = X1;
                        circles[i].y1 = Y1;
                        circles[i].z1 = Z1;
                        sum += circles[i].InertialBox();
                        SumBox += circles[i].AreaBox();
                        CentrX += circles[i].CTX1();
                        CentrY += circles[i].CTY1();
                        circles[i].AX1 = +CentrX / +SumBox;
                        circles[i].AY1 = +CentrY / +SumBox;
                        Console.WriteLine("Площадь квадрата:{0}", circles[i].AreaBox());
                        Console.WriteLine("Размер={0},координаты X={1},координаты У={2},координаты Z={3}", circles[i].R, circles[i].x1, circles[i].y1, circles[i].z1);
                        Console.WriteLine("Центральный момент инерции квадрата:{0}", circles[i].InertialBox());
                        Console.WriteLine("Момент инерции относительно оси Х={0}, Момент инерции относительно оси У={1}", circles[i].InertialX1(), circles[i].InertialY1());
                        Console.WriteLine("Централный момент инерции оносительно точки Ix={0}, Iy={1}", circles[i].SecondX1(), circles[i].SecondY1());
                        Console.WriteLine("Централный момент инерции оносительно точки Ic={0}", circles[i].FirstCTbox());
                        Console.WriteLine("Централный момент инерции оносительно точки Ic1={0}", circles[i].FunctionBox(+CentrX / +SumBox, +CentrY / +SumBox));
                        Console.WriteLine("Координаты ЦТ X={0}, Y={1}", +CentrX / +SumBox, +CentrY / +SumBox);
                        Console.WriteLine("Сумма моментов инерции окружностей:{0}", +sum);
                        break;
                    case "O":
                        Console.WriteLine("Введите радиус окружности:");
                        string r = Console.ReadLine();
                        Console.WriteLine("Введите координату X");
                        string x = Console.ReadLine();
                        Console.WriteLine("Введите координату у");
                        string y = Console.ReadLine();
                        Console.WriteLine("Введите координату z");
                        string z = Console.ReadLine();
                        double P = Convert.ToDouble(r);
                        double X = Convert.ToDouble(x);
                        double Y = Convert.ToDouble(y);
                        double Z = Convert.ToDouble(z);
                        circles[i].R = P;
                        circles[i].x = X;
                        circles[i].y = Y;
                        circles[i].z = Z;
                        sum += circles[i].Inertial();
                        SumCircles += circles[i].Area();
                        CentrX += circles[i].CTX();
                        CentrY += circles[i].CTY();
                        circles[i].AX = +CentrX / +SumCircles;
                        circles[i].AY = +CentrY / +SumCircles;
                        Console.WriteLine("Площадь окружности:{0}", circles[i].Area());
                        Console.WriteLine("Радиус={0},координаты X={1},координаты У={2},координаты Z={3}", circles[i].R, circles[i].x, circles[i].y, circles[i].z);
                        Console.WriteLine("Центральный момент инерции :{0}", circles[i].Inertial());
                        Console.WriteLine("Момент инерции относительно оси Х={0}, Момент инерции относительно оси У={1}", circles[i].InertialX(), circles[i].InertialY());
                        Console.WriteLine("Централный момент инерции оносительно точки Ix={0}, Iy={1}", circles[i].SecondX(), circles[i].SecondY());
                        Console.WriteLine("Централный момент инерции оносительно точки Ic={0}", circles[i].FirstCT());
                        Console.WriteLine("Централный момент инерции оносительно точки Ic1={0}", circles[i].Function(+CentrX / +SumCircles, +CentrY / +SumCircles));
                        Console.WriteLine("Координаты ЦТ X={0}, Y={1}", +CentrX / +SumCircles, +CentrY / +SumCircles);
                        Console.WriteLine("Сумма моментов инерции окружностей:{0}", +sum);
                        break;

                    default:
                        Console.WriteLine("Вы нажали неизвестную букву");
                        break;
                }
            }
            Console.ReadKey();
        }
    }
}

