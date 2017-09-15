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
            double CentX = 0;
            double CentY = 0;
            double Sum = 0;
            Sum += shape.Area();
            CentX += shape.CTX();
            CentY += shape.CTY();
            Console.WriteLine("Площадь фигуры:{0}", shape.Area());
            Console.WriteLine("координаты X={0},координаты У={1},координаты Z={2}", shape.x, shape.y, shape.z);
            Console.WriteLine("Центральный момент инерции :{0}", shape.Inertial());
            Console.WriteLine("Момент инерции относительно оси Х={0}, Момент инерции относительно оси У={1}", shape.InertialX(), shape.InertialY());
            Console.WriteLine("Централный момент инерции оносительно  Ix={0}, Iy={1}", shape.SecondX(+CentX / +Sum, +CentY / +Sum), shape.SecondY(+CentX / +Sum, +CentY / +Sum));
            Console.WriteLine("Централный момент инерции оносительно точки Ic={0}", shape.FirstCT(+CentX / +Sum, +CentY / +Sum));
            Console.WriteLine("Централный момент инерции оносительно точки Ic1={0}", shape.Function(+CentX / +Sum, +CentY / +Sum));
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество сечений:");
            string circl = Console.ReadLine();
            int R = Convert.ToInt32(circl);
            double sumK = 0;
            double sumO = 0;
            double sumP = 0;
            double sum = 0;
            double CentrX = 0;
            double CentrY = 0;
            double Sum = 0;

            Shape[] shapes = new Shape[R];
            for (int i = 0; i < shapes.Length; i++)
            {
                Console.WriteLine("Введите тип сечения К-квадрат, О-окружность, П-прямоугольник:");
                string size = Console.ReadLine();
                switch (size)
                {
                    case "K":
                        Square square = new Square();
                        Console.WriteLine("Введите размер стороны квадрата:");
                        string r1 = Console.ReadLine();
                        double P1 = Convert.ToDouble(r1);
                        square.size = P1;
                        Console.WriteLine("Сторона квадрата {0}", square.size);
                        sumK += square.Inertial();
                        Console.WriteLine("Сумма моментов инерции к:{0}", +sumK);
                        shapes[i] = square;
                        break;

                    case "O":
                        Circle circle = new Circle();
                        Console.WriteLine("Введите радиус окружности:");
                        string r = Console.ReadLine();
                        double P = Convert.ToDouble(r);
                        circle.R = P;
                        Console.WriteLine("Радиус окружности {0}", circle.R);
                        sumO += circle.Inertial();
                        Console.WriteLine("Сумма моментов инерции окружностей:{0}", +sumO);
                        shapes[i] = circle;
                        break;
                    case "П":
                        Box box = new Box();
                        Console.WriteLine("Введите ширину :");
                        string width = Console.ReadLine();
                        double A = Convert.ToDouble(width);
                        Console.WriteLine("Введите длину:");
                        string height = Console.ReadLine();
                        double B = Convert.ToDouble(height);
                        box.width = A;
                        box.height = B;
                        Console.WriteLine("Ширина прямоугольника {0}, высота прямоугольника {1}", box.width, box.height);
                        sumP += box.Inertial();
                        Console.WriteLine("Сумма моментов инерции п:{0}", +sumP);
                        shapes[i] = box;
                        break;
                    default:
                        Console.WriteLine("Вы нажали неизвестную букву");
                        break;
                }
                Sum += shapes[i].Area();
                CentrX += shapes[i].CTX();
                CentrY += shapes[i].CTY();
                
                SetCoordinates(shapes[i]);
                WriteLines(shapes[i]);
                sum += shapes[i].Inertial();

            }
            Console.WriteLine("Координаты ЦТ X={0}, Y={1}", CentrX / Sum, CentrY / Sum);
            Console.WriteLine("Сумма моментов инерции всех фигур:{0}", +sum);
            Console.ReadKey();
        }
    }
}

