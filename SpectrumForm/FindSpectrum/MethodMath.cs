using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FindSpectrum
{
    class MethodMath
    {
        public class Complex
        {
            public double Real { get; set; }
            public double Image { get; set; }
            public double Abs
            {
                get => Math.Sqrt(Real * Real + Image * Image);
            }
        }

        public double E { get; set; }
        public double R { get; set; }
        public double Rx { get; set; }
        public double K { get; set; }


        public double B { get; set; }
        public double C { get; set; }
        public double D { get; set; }



        private double Fi { get; set; }

        double U(double x)
        {
            return 1 / 2 * K * x * x;
        }

        double FiFunction(double fi, double x)
        {
            return (U(x) - E) * Math.Cos(fi) * Math.Cos(fi) - Math.Sin(fi) * Math.Sin(fi);
        }

        double RxFunction(double fi, double x)
        {
            return Rx*(1+U(x) - E) * Math.Cos(fi)* Math.Sin(fi);
        }

        double PsiFunction(double fi)
        {
            return Rx * Math.Sin(fi);
        }

        double GoFiRungeKutta( double fi, double r, double h)
        {
            var k1 = FiFunction(fi, r);
            var k2 = FiFunction(h / 2 * k1, r + h/2);
            var k3 = FiFunction(h / 2 * k2, r + h / 2);
            var k4 = FiFunction(h*k3, r + h);
            return fi + h / 6 * (k1 + 2 * k2 + 2 * k3 + k4);
        }

        double GoRxRungeKutta(double fi, double r, double h)
        {
            var k1 = RxFunction(fi, r);
            var k2 = RxFunction(h / 2 * k1, r + h / 2);
            var k3 = RxFunction(h / 2 * k2, r + h / 2);
            var k4 = RxFunction(h * k3, r + h);
            return fi + h / 6 * (k1 + 2 * k2 + 2 * k3 + k4);
        }

        double GoPsiRungeKutta(double fi, double h)
        {
            var k1 = PsiFunction(fi);
            var k2 = PsiFunction(h / 2 * k1);
            var k3 = PsiFunction(h / 2 * k2);
            var k4 = PsiFunction(h * k3);
            return fi + h / 6 * (k1 + 2 * k2 + 2 * k3 + k4);
        }

        public List<List<double>> FindStationaryPsi(double step)
        {

            List<double> tmpFi = new List<double>();
            tmpFi.Add(-Math.PI / 2);

            for (double i = -R; i <= R; i+=step)
            {
                tmpFi.Add( GoFiRungeKutta(tmpFi[^1], i, step));
            }

            Rx = 0;


            List<double> tmpE = new List<double>();
            for (int i = 0; i < (2*R/step); i++)
            {
                tmpE.Add( -((Math.Sin(tmpFi[i]) * Math.Sin(tmpFi[i]) - (2*i +1)*Math.PI/2) / (Math.Cos(tmpFi[i]) * Math.Cos(tmpFi[i])) - U(R)));
            }

            List<double> rx = new List<double>();
            rx.Add(0);
            for (double i = R; i >= -R; i -= step)
            {
               
                tmpFi.Add(GoRxRungeKutta(rx[^1], i, step));
            }

            rx.Reverse();
            List<List<double>> tmpPsi = new List<List<double>>();
            for (int i = 0; i < tmpFi.Count; i++)
            {
                var fi = tmpFi[i];
                tmpPsi.Add(new List<double>());
                for (var j = -R; j <= R; j+=step)
                {
                    tmpPsi[i].Add(GoPsiRungeKutta(fi, step));
                    fi += step;
                }
               
            }

            return tmpPsi;
        }

        public void FindEvolution(double step)
        {
            List<double> x = new List<double>(); 
            List<List<double>> tmpPsi = new List<List<double>>();
            for (double i = 0; i < 2*R; i+=step)
            {
                x.Add(i);
            }

            List<double> tmpA = new List<double>();
            List<double> tmpB = new List<double>();
            List<double> tmpC = new List<double>();
            List<double> tmpD = new List<double>();

            tmpA.Add(-step/((x[2]-x[0])*(x[1] - x[0])));
        }
    }
}
