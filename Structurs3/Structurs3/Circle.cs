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
               
        public double CTX()
        {
            return (x * Area());
            
        }
        public double CTY()
        {
            return (y * Area());
            
        }
        //центральный момент инерции оносительно х
        public double InertialX()
        {
            return Inertial() + Area() * y * y;
            
        }
        //центральный момент инерции оносительно у
        public double InertialY()
        {
            return Inertial() + Area() * x * x;            
        }
        //момент инерции по Х для каждой окружности относительно координаты общей тяжести
        public double SecondX(double AX, double AY)
        {
            return Inertial() + Area() * (AX - x) * (AX - x);
            
        }
        //момент инерции по У для каждой окружности относительно координаты общей тяжести
        public double SecondY(double AX, double AY)
        {
            return Inertial() + Area() * (AY - y) * (AY - y);            
        }
        
        public double Function(double AX, double AY)
        {
            double AB = Math.Sqrt((AY - y) * (AY - y) + (AX - x) * (AX - x));
            return InertialX() + Area() * AB * AB;
            
        }
        // значение центра тяжести для каждой окружности относительно  координаты общей тяжести
        public double FirstCT(double AX, double AY)
        {
            double AB = Math.Sqrt((AY - y) * (AY - y) + (AX - x) * (AX - x));
            return InertialX() + Area() * AB * AB;            
        }
    }
    class Circle : Shape
    {
        public double R;
        // площадь окружности
        override public double Area()
        {
            return Math.PI * R * R;
        }
        //центральный момент инерции для окружности
        override public double Inertial()
        {
            return (Math.PI * (Math.Pow(R * 2, 4)) / 64);            
        }
    }
    class Ring : Shape {
        public double R;
        public double R1;
        public double L;
        // площадь кольца
        override public double Area()
        {
            double Soutput = Math.PI * R * R;
            double Sinput = Math.PI* R1* R1;
            return (Soutput- Sinput)*L;

        }
        //центральный момент инерции для кольца
        override public double Inertial()
        {
            return Area()*L;
        }
    }
     
    class Square : Shape
    {
        public double size;
        //площадь квадрата
        override public double Area()
        {
            return size * size;            
        }
        //момент инерции квадрата
        override public double Inertial()
        {
            return Area() * Area() / 12;            
        }
    }
    class Box : Shape
    {
        public double width;
        public double height;
        override public double Area()
        {
            return width * height;            
        }
        override public double Inertial()
        {
            return width * Math.Pow(height, 3) / 12;
           
        }
    }

}