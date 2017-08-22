using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structurs3
{
    class Program
    {
        static void SetCoordinates(Shape shape)
        {            
            Console.WriteLine("Введите координату X");
            string x = Console.ReadLine();
            Console.WriteLine("Введите координату у");
            string y = Console.ReadLine();
            Console.WriteLine("Введите координату z");
            string z = Console.ReadLine();           
            double X = Convert.ToDouble(x);
            double Y = Convert.ToDouble(y);
            double Z = Convert.ToDouble(z);
            shape.x = X;
            shape.y = Y;
            shape.z = Z;
        }
        static void WriteLines(Shape shape)
        {
            double CentrX = 0;
            double CentrY = 0;
            double Sum = 0;
            Sum += shape.Area();
            CentrX += shape.CTX();
            CentrY += shape.CTY();
            shape.AX = +CentrX / +Sum;
            shape.AY = +CentrY / +Sum;
            Console.WriteLine("Площадь фигура:{0}", shape.Area());
            Console.WriteLine("координаты X={0},координаты У={1},координаты Z={2}", shape.x, shape.y, shape.z);
            Console.WriteLine("Центральный момент инерции :{0}", shape.Inertial());
            Console.WriteLine("Момент инерции относительно оси Х={0}, Момент инерции относительно оси У={1}", shape.InertialX(), shape.InertialY());
            Console.WriteLine("Централный момент инерции оносительно точки Ix={0}, Iy={1}", shape.SecondX(), shape.SecondY());
            Console.WriteLine("Централный момент инерции оносительно точки Ic={0}", shape.FirstCT());
            Console.WriteLine("Централный момент инерции оносительно точки Ic1={0}", shape.Function(+CentrX / +Sum, +CentrY / +Sum));
            Console.WriteLine("Координаты ЦТ X={0}, Y={1}", +CentrX / +Sum, +CentrY / +Sum);
            
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество сечений:");
            string circle = Console.ReadLine();
            int R = Convert.ToInt32(circle);
            double sum = 0;
            double sum1 = 0;
            double SUMMA = 0;           

            Shape[] shapes = new Shape[R];
            for (int i = 0; i < shapes.Length; i++)
            {
                Console.WriteLine("Введите тип сечения К-квадрат, О-окружность, П-прямоугольник:");
                string size = Console.ReadLine();
                switch (size)
                {
                    case "K":
                        shapes[i] = new Square();
                        Console.WriteLine("Введите размер стороны квадрата:");
                        string r1 = Console.ReadLine();
                        double P1 = Convert.ToDouble(r1);
                        shapes[i].size = P1;
                        Console.WriteLine("Сторона квадрата {0}", shapes[i].size);
                        break;
                    case "O":
                        shapes[i] = new Circle();
                        Console.WriteLine("Введите радиус окружности:");
                        string r = Console.ReadLine();
                        double P = Convert.ToDouble(r);
                        shapes[i].R = P;
                        Console.WriteLine("Радиус окружности {0}", shapes[i].R);
                        break;
                    case "П":
                        shapes[i] = new Box();
                         Console.WriteLine("Введите ширину :");
                         string width = Console.ReadLine();
                        double A = Convert.ToDouble(width);
                        Console.WriteLine("Введите длину:");
                          string height = Console.ReadLine();
                          double B = Convert.ToDouble(height);
                         shapes[i].width = A;
                        shapes[i].height = B;
                        Console.WriteLine("Ширина прямоугольника {0}, высота прямоугольника {1}", shapes[i].width, shapes[i].height);
                        break;
                    default:
                        Console.WriteLine("Вы нажали неизвестную букву");
                        break;
                }
                SetCoordinates(shapes[i]);
                WriteLines(shapes[i]);
                sum += shapes[i].Inertial();
                SUMMA = sum + sum1;
            }
            Console.WriteLine("Сумма моментов инерции окружностей:{0}", +sum);
            Console.WriteLine("Сумма моментов инерции квадратов:{0}", +sum1);
            Console.WriteLine("Сумма моментов инерции квадратов и окружностей:{0}", SUMMA);
            Console.ReadKey();
        }
    }
}

