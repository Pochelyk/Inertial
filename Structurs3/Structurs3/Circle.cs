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
        public double R;
        public double A;
        public double B;
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
        //площадь квадрата
        override public double Area()
        {
            double S1 = R * R;
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
        override public double Area()
        {
            double S1 = A * B;
            return S1;
        }
        override public double Inertial()
        {
            double J1 = A * Math.Pow(B, 3) / 12;
            return J1;
        }
    }

    
    //struct Circle
    //{
    //  internal double R;
    //  public double x;
    //  public double y;
    //  public double z;
    //  internal double AX;
    //  internal double AY;
    //  площадь окружности
    //  public double Area()
    //  {
    //      double S = Math.PI * R * R;
    //      return S;
    //  }
    //  площадь квадрата
    //  public double AreaBox()
    //  {
    //      double S1 = R * R;
    //      return S1;
    //  }
    //  центральный момент инерции для окружности
    //  public double Inertial()
    //  {
    //      double J = (Math.PI * (Math.Pow(R * 2, 4)) / 64);
    //      return J;
    //  }
    //  момент инерции квадрата
    //  public double InertialBox()
    //  {
    //      double J1 = AreaBox() * AreaBox() / 12;
    //      return J1;
    //  }
    //  центральный момент инерции окружности оносительно х
    //  public double InertialX()
    //  {
    //      double Jx = Inertial() + Area() * y * y;
    //      return Jx;
    //  }
    //  центральный момент инерции квадрата оносительно х
    //  public double InertialX1()
    //  {
    //      double Jx1 = Inertial() + AreaBox() * y * y;
    //      return Jx1;
    //  }
    //  центральный момент инерции окружности оносительно у
    //  public double InertialY()
    //  {
    //      double Jx = Inertial() + Area() * x * x;
    //      return Jx;
    //  }
    //  центральный момент инерции квадрата оносительно у
    //  public double InertialY1()
    //  {
    //      double Jx1 = Inertial() + AreaBox() * x * x;
    //      return Jx1;
    //  }
    //  public double CTX()
    //  {
    //      double CTX = (x * Area());
    //      return CTX;
    //  }
    //  public double CTY()
    //  {
    //      double CTY = (y * Area());
    //      return CTY;
    //  }
    //  box
    //  public double CTX1()
    //  {
    //      double CTX1 = (x * AreaBox());
    //      return CTX1;
    //  }
    //  box
    //  public double CTY1()
    //  {
    //      double CTY1 = (y * AreaBox());
    //      return CTY1;
    //  }
    //  момент инерции по Х для каждой окружности относительно координаты общей тяжести
    //  public double SecondX()
    //  {
    //      double SecondX = Inertial() + Area() * (AX - x) * (AX - x);
    //      return SecondX;
    //  }
    //  момент инерции по Х для квадрата относительно координаты общей тяжести
    //  public double SecondX1()
    //  {
    //      double SecondX1 = InertialBox() + AreaBox() * (AX - x) * (AX - x);
    //      return SecondX1;
    //  }
    //  момент инерции по У для каждой окружности относительно координаты общей тяжести
    //  public double SecondY()
    //  {
    //      double SecondY = Inertial() + Area() * (AY - y) * (AY - y);
    //      return SecondY;
    //  }
    //  момент инерции по У для квадрата относительно координаты общей тяжести
    //  public double SecondY1()
    //  {
    //      double SecondY1 = InertialBox() + AreaBox() * (AY - y) * (AY - y);
    //      return SecondY1;
    //  }
    //  длина отрезка от координаты общей тяжести до центра окружности
    //  public double FirstAB()
    //  {
    //      double AB = Math.Sqrt((AY - y) * (AY - y) + (AX - x) * (AX - x));
    //      return AB;
    //  }
    //  значение центра тяжести для каждой окружности относительно  координаты общей тяжести
    //  public double FirstCT()
    //  {
    //      double CT = InertialX() + Area() * FirstAB() * FirstAB();
    //      return CT;
    //  }
    //  значение центра тяжести для каждого квадрата относительно  координаты общей тяжести
    //  public double FirstCTbox()
    //  {
    //      double CT = InertialX1() + AreaBox() * FirstAB() * FirstAB();
    //      return CT;
    //  }
    //  //circle
    //  public double Function(double AX, double AY)
    //  {
    //      double AB = Math.Sqrt((AY - y) * (AY - y) + (AX - x) * (AX - x));
    //      double CT = InertialX() + Area() * AB * AB;
    //      return CT;
    //  }
    //  //box
    //  public double FunctionBox(double AX, double AY)
    //  {
    //      double AB = Math.Sqrt((AY - y) * (AY - y) + (AX - x) * (AX - x));
    //      double CT = InertialX1() + AreaBox() * AB * AB;
    //      return CT;
    //  }
    //    public void Info()
    //    {
    //    }
    //}
}