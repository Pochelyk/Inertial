using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structurs3
{
    abstract class Shape
    {
        abstract public double Area();
        abstract public double Inertial();
        public double x;
        public double y;
        public double z;
        internal double AX;
        internal double AY;
        //длина отрезка от координаты общей тяжести до центра окружности
        public double FirstAB()
        {
            double AB = Math.Sqrt((AY - y) * (AY - y) + (AX - x) * (AX - x));
            return AB;
        }
        public double CTX()
        {
            double CTX = (x * Area());
            return CTX;
        }
        public double CTY()
        {
            double CTY = (y * Area());
            return CTY;
        }
        //центральный момент инерции оносительно х
        public double InertialX()
        {
            double Jx = Inertial() + Area() * y * y;
            return Jx;
        }
        //центральный момент инерции оносительно у
        public double InertialY()
        {
            double Jx = Inertial() + Area() * x * x;
            return Jx;
        }
        //момент инерции по Х для каждой окружности относительно координаты общей тяжести
        public double SecondX()
        {
            double SecondX = Inertial() + Area() * (AX - x) * (AX - x);
            return SecondX;
        }
        //момент инерции по У для каждой окружности относительно координаты общей тяжести
        public double SecondY()
        {
            double SecondY = Inertial() + Area() * (AY - y) * (AY - y);
            return SecondY;
        }
        public double Function(double AX, double AY)
        {
            double AB = Math.Sqrt((AY - y) * (AY - y) + (AX - x) * (AX - x));
            double CT = InertialX() + Area() * AB * AB;
            return CT;
        }
        // значение центра тяжести для каждой окружности относительно  координаты общей тяжести
        public double FirstCT()
        {
            double CT = InertialX() + Area() * FirstAB() * FirstAB();
            return CT;
        }
    }
    class Circle : Shape
    {
        public double R;
        // площадь окружности
        override public double Area()
        {
            double S = Math.PI * R * R;
            return S;
        }
        //центральный момент инерции для окружности
        override public double Inertial()
        {
            double J = (Math.PI * (Math.Pow(R * 2, 4)) / 64);
            return J;
        }
    }
    class Square : Shape
    {
        public double size;
        //площадь квадрата
        override public double Area()
        {
            double S1 = size * size;
            return S1;
        }
        //момент инерции квадрата
        override public double Inertial()
        {
            double J1 = Area() * Area() / 12;
            return J1;
        }
    }
    class Box : Shape
    {
        public double width;
        public double height;
        override public double Area()
        {
            double S1 = width * height;
            return S1;
        }
        override public double Inertial()
        {
            double J1 = width * Math.Pow(height, 3) / 12;
            return J1;
        }
    }

}