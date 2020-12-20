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

        public MethodMath()
        {
            Fi = new List<List<double>>();
            Rx = new List<List<double>>();
            E = new List<double>();
        }

        public List<double> E { get; set; }
        public double R { get; set; }
        public List<List<double>> Rx { get; set; }
        public double K { get; set; }
        public double Order { get; set; }

        public double B { get; set; }
        public double C { get; set; }
        public double D { get; set; }



        private List<List<double>> Fi { get; set; }

        double U(double x)
        {
            return 1 / 2 * K * x * x;
        }

        double FiFunction(double fi, double x, double e)
        {
            return (U(x) - e) * Math.Cos(fi) * Math.Cos(fi) - Math.Sin(fi) * Math.Sin(fi);
        }

        double RxFunction(double fi, double rx, double x, double e)
        {
            return rx * (1+U(x) - e) * Math.Cos(fi)* Math.Sin(fi);
        }

        double dPsiFunction(double fi, double rx)
        {
            return rx * Math.Cos(fi);
        }

        double GoFiRungeKutta( double fi, double r, double e, double h)
        {
            var k1 = FiFunction(fi, r, e);
            var k2 = FiFunction(h / 2 * k1, r + h/2, e);
            var k3 = FiFunction(h / 2 * k2, r + h / 2, e);
            var k4 = FiFunction(h*k3, r + h, e);
            return fi + h / 6 * (k1 + 2 * k2 + 2 * k3 + k4);
        }

        double GoRxRungeKutta(double fi, double rx, double r, double e, double h)
        {
            var k1 = RxFunction(fi, rx, r, e);
            var k2 = RxFunction(h / 2 * k1, rx, r + h / 2, e);
            var k3 = RxFunction(h / 2 * k2, rx, r + h / 2, e);
            var k4 = RxFunction(h * k3, rx, r + h, e);
            return fi + h / 6 * (k1 + 2 * k2 + 2 * k3 + k4);
        }

        double GoDPsiRungeKutta(double fi, double rx, double h)
        {
            var k1 = dPsiFunction(fi, rx);
            var k2 = dPsiFunction(h / 2 * k1, rx);
            var k3 = dPsiFunction(h / 2 * k2, rx);
            var k4 = dPsiFunction(h * k3, rx);
            return fi + h / 6 * (k1 + 2 * k2 + 2 * k3 + k4);
        }

        double GoBisectionMethod(double fi, double from, double to, double precision, int k)
        {
            double middle = 0;
            while (to-from> precision)
            {
                middle = (from + to) / 2;
                var fLeft = FiFunction(fi, R, from) - (2*k+1)*Math.PI/2;
                var fRight = FiFunction(fi, R, middle) - (2 * k + 1) * Math.PI / 2;
                if (fLeft*fRight  > 0)
                    from = middle;
                else if (fLeft * fRight < 0)
                    to = middle;

            }

            return middle;
        }

        double GoBisectionMethodVer2( double from, double to, double precision, int k, double step)
        {
            double middle = 0;

            var tmpFi1 = new List<double>();
            var tmpFi2 = new List<double>();

            do
            {
                tmpFi1.Add(Math.PI / 2);
                tmpFi2.Add(Math.PI / 2);
                middle = (from + to * 31) / 32;
                for (double i = -R; i <= R; i += step)
                {
                    tmpFi1.Add(GoFiRungeKutta(tmpFi1[^1], i, from, step));
                    tmpFi2.Add(GoFiRungeKutta(tmpFi2[^1], i, to, step));
                }

                var fLeft = tmpFi1[^1] + (2 * k + 1) * Math.PI / 2;
                var fRight = tmpFi2[^1] + (2 * k + 1) * Math.PI / 2;
                if (fLeft * fRight > 0)
                    from = middle;
                else if (fLeft * fRight < 0)
                    to = middle;

                tmpFi1.Clear();
                tmpFi2.Clear();
            } while (to - from > precision);

            return middle;
        }


        public List<List<double>> FindStationaryPsi(double step, int count)
        {
            double e = 5;
            

            for (int k = 0; k < count; k++)
            {
                Fi.Add(new List<double>());
                Fi[k].Add(Math.PI / 2);
                E.Add(GoBisectionMethodVer2(0, 30, 0.000001, k, step));


                for (double i = -R; i <= R; i += step)
                {
                    Fi[k].Add(GoFiRungeKutta(Fi[k][^1], i, E[k], step));
                }
            }

            var tmp1 = Fi[0][0];
            var tmp2 = Fi[0][^1];

            for (int k = 0; k < count; k++)
            {
                Rx.Add(new List<double>());
                Rx[k].Add(1);
                for (var i = 0 ; i <Fi[k].Count-1; ++i)
                {

                    Rx[k].Add(GoRxRungeKutta(Fi[k][i], Rx[k][i], -R+i*step, E[k], step));
                }
            }
            
            List<List<double>> tmpDPsi = new List<List<double>>();
            for (int i = 0; i < Fi.Count; i++)
            {
                var fi = Fi[i];
                var rx = Rx[i];
                tmpDPsi.Add(new List<double>());
                for (var j =0; j < fi.Count; j++)
                {
                    //tmpDPsi[i].Add(GoDPsiRungeKutta(fi[j], rx[j], step));
                    tmpDPsi[i].Add(dPsiFunction(fi[j], rx[j]));
                }
               
            }

            return tmpDPsi;
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
