using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structurs3
{
    struct Circle
    {
        internal double R;
        public double x;
        public double y;
        public double z;
        public double x1;
        public double y1;
        public double z1;
        internal double AX;
        internal double AY;
        internal double AX1;
        internal double AY1;
        // площадь окружности
        public double Area()
        {
            double S = Math.PI * R * R;
            return S;
        }
        //площадь квадрата
        public double AreaBox()
        {
            double S1 =  R * R;
            return S1;
        }
        //центральный момент инерции для окружности
        public double Inertial()
        {
            double J = (Math.PI * (Math.Pow(R * 2, 4)) / 64);
            return J;
        }
        //момент инерции квадрата
        public double InertialBox()
        {
            double J1 = AreaBox()* AreaBox()/12;
            return J1;

        }
        //центральный момент инерции окружности оносительно х
        public double InertialX()
        {
            double Jx = Inertial() + Area() * y * y;
            return Jx;
        }
        //центральный момент инерции квадрата оносительно х
        public double InertialX1()
        {
            double Jx1= Inertial() + AreaBox() * y1 * y1;
            return Jx1;
        }
        //центральный момент инерции окружности оносительно у
        public double InertialY()
        {
            double Jx = Inertial() + Area() * x * x;
            return Jx;
        }
        //центральный момент инерции квадрата оносительно у
        public double InertialY1()
        {
            double Jx1= Inertial() + AreaBox() * y1 * y1;
            return Jx1;
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
        //box
        public double CTX1()
        {
            double CTX1 = (x1 * AreaBox());
            return CTX1;
        }
        //box
        public double CTY1()
        {
            double CTY1 = (y1 * AreaBox());
            return CTY1;
        }
        //момент инерции по Х для каждой окружности относительно координаты общей тяжести
        public double SecondX()
        {
            double SecondX = Inertial() + Area() * (AX - x) * (AX - x);
            return SecondX;
        }
        //момент инерции по Х для квадрата относительно координаты общей тяжести
        public double SecondX1()
        {
            double SecondX1 = InertialBox() + AreaBox() * (AX1 - x1) * (AX1 - x1);
            return SecondX1;
        }
        //момент инерции по У для каждой окружности относительно координаты общей тяжести
        public double SecondY()
       {
           double SecondY = Inertial() + Area() * (AY - y) * (AY - y);
           return SecondY;
        }
        //момент инерции по У для квадрата относительно координаты общей тяжести
        public double SecondY1()
        {
            double SecondY1 = InertialBox() + AreaBox() * (AY1 - y1) * (AY1 - y1);
            return SecondY1;
        }
        //длина отрезка от координаты общей тяжести до центра окружности
        public double FirstAB()
        {
           double AB = Math.Sqrt((AY - y) * (AY - y) + (AX - x) * (AX - x));
           return AB;
        }
        //длина отрезка от координаты общей тяжести до центра квадрата
        public double FirstAB1()
        {
            double AB = Math.Sqrt((AY1 - y1) * (AY1- y1) + (AX1 - x1) * (AX1- x1));
            return AB;
        }
        // значение центра тяжести для каждой окружности относительно  координаты общей тяжести
        public double FirstCT()
        {
           double CT = InertialX() + Area() * FirstAB() * FirstAB();
           return CT;
        }
        // значение центра тяжести для каждого квадрата относительно  координаты общей тяжести
        public double FirstCTbox()
        {
            double CT = InertialX1() + AreaBox() * FirstAB1() * FirstAB1();
            return CT;
        }
        //circle
        public double Function(double AX, double AY)
        {
            double AB = Math.Sqrt((AY - y) * (AY - y) + (AX - x) * (AX - x));
            double CT = InertialX() + Area() *AB * AB;
            return CT;
        }
        //box
        public double FunctionBox(double AX1, double AY1)
        {
            double AB = Math.Sqrt((AY1 - y1) * (AY1 - y1) + (AX1 - x1) * (AX1 - x1));
            double CT = InertialX1() + AreaBox() * AB * AB;
            return CT;
        }

        public void Info()
        {
        }
    }


}