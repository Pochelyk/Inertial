using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structurs3
{
    class Program
    {
        static double ReadDouble(string message)
        {
            double result;
            bool parsed;
            do
            {
                Console.WriteLine(message);
                string d = Console.ReadLine();
                parsed = double.TryParse(d, out result);
            } while (!parsed);
            
            return result;
        }

        static void SetCoordinates(Shape shape)
        {
            shape.x = ReadDouble("Введите координату X");
            shape.y = ReadDouble("Введите координату у");
            shape.z = ReadDouble("Введите координату z");
        }
        static void WriteLines(Shape shape)
        {
            double CentX = 0;
            double CentY = 0;
            double Sum = 0;
            double X1 = 0;
            double Y1 = 0;
            Sum += shape.Area();
            CentX += shape.CTX();
            CentY += shape.CTY();
            X1 = CentX / Sum;
            Y1 = CentY / Sum;
            Console.WriteLine("Площадь фигуры:{0}", shape.Area());
            Console.WriteLine("координаты X={0},координаты У={1},координаты Z={2}", shape.x, shape.y, shape.z);
            Console.WriteLine("Центральный момент инерции :{0}", shape.Inertial());
            Console.WriteLine("Момент инерции относительно оси Х={0}, Момент инерции относительно оси У={1}", shape.InertialX(), shape.InertialY());
            Console.WriteLine("Централный момент инерции оносительно  Ix={0}, Iy={1}", shape.SecondX(X1, Y1), shape.SecondY(X1, Y1));
            Console.WriteLine("Централный момент инерции оносительно точки Ic={0}", shape.FirstCT(X1, Y1));
            Console.WriteLine("Централный момент инерции оносительно точки Ic1={0}", shape.Function(X1, Y1));
        }
        static Square MakeSqare()
        {
            Square square = new Square();
            square.size = ReadDouble("Введите размер стороны квадрата:");
            Console.WriteLine("Сторона квадрата {0}", square.size);
            return square;
        }
        static Circle MakeCircle()
        {
            Circle circle = new Circle();
            circle.R = ReadDouble("Введите радиус окружности:");
            Console.WriteLine("Радиус окружности {0}", circle.R);
            return circle;
        }
        static Box MakeBox()
        {
            Box box = new Box();
            box.width = ReadDouble("Введите ширину :");
            box.height = ReadDouble("Введите длину:");
            Console.WriteLine("Ширина прямоугольника {0}, высота прямоугольника {1}", box.width, box.height);
            return box;
        }
        static Ring MakeRing()
        {
            Ring ring = new Ring();
            ring.L = ReadDouble("Введите длинну кольца :");
            ring.R = ReadDouble("Введите наружный радиус:");
            ring.R1 = ReadDouble("Введите внутреннний радиус:");
            Console.WriteLine("Длина кольца {0}, радиус кольца наружный {1}, радиус кольца внутренний {2}", ring.L, ring.R, ring.R1);
            return ring;
        }
        static Shape MakeShape()
        {
            Shape shape;
            Console.WriteLine("Введите тип сечения C-кольцо К-квадрат, О-окружность, П-прямоугольник:");
            string size = Console.ReadLine();
            switch (size)
            {
                case "K":
                    shape = MakeSqare();
                    break;
                case "O":
                    shape = MakeCircle();
                    break;
                case "П":
                    shape = MakeBox();
                    break;
                case "C":
                    shape = MakeRing();
                    break;
                default:
                    shape = null;
                    Console.WriteLine("Вы нажали неизвестную букву");
                    break;
            }
            return shape;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество сечений:");
            string circl = Console.ReadLine();
            int R = Convert.ToInt32(circl);
            double sum = 0;
            double CentrX = 0;
            double CentrY = 0;
            double Sum = 0;

            Shape[] shapes = new Shape[R];
            for (int i = 0; i < shapes.Length; i++)
            {
                Shape shape = null;
                do
                {
                    shape = MakeShape();
                }
                while (shape == null);
                
                SetCoordinates(shape);
                WriteLines(shape);
                sum += shape.Inertial();

                Sum += shape.Area();
                CentrX += shape.CTX();
                CentrY += shape.CTY();

                shapes[i] = shape;
            }
            Console.WriteLine("Координаты ЦТ X={0}, Y={1}", CentrX / Sum, CentrY / Sum);
            Console.WriteLine("Сумма моментов инерции всех фигур:{0}", +sum);
            Console.ReadKey();
        }
    }
}

