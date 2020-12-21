using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FindSpectrum
{
    class MethodMath
    {
        public class Complex : IEnumerable<Complex>
        {

            private List<Complex> internalList = new List<Complex>();
            public IEnumerator<Complex> GetEnumerator() => internalList.GetEnumerator();

            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => internalList.GetEnumerator();

            //public void Add(double real, double image) => internalList.Add(new Complex(real,image));

            //public void Add(double real, double image) => internalList.Add(new Complex(real, image));
            public void Add(double real, double image)
            {
                this.Real = real;
                this.Image = image;
            }

            public double Real { get; set; }
            public double Image { get; set; }

            public double Abs
            {
                get => Math.Sqrt(Real * Real + Image * Image);
            }

            public Complex (double real, double image)
            {
                this.Real = real;
                this.Image = image;
            }

            public Complex()
            {
            }

            public static Complex operator +(Complex a, Complex b)
                => new Complex(a.Real + b.Real , a.Image + b.Image);
            public static Complex operator -(Complex a, Complex b)
                => new Complex(a.Real - b.Real , a.Image- b.Image);

            public static Complex operator *(Complex a, Complex b)
                => new Complex(a.Real * b.Real - a.Image*b.Image, a.Image * b.Real + a.Real*b.Image);

            public static Complex operator /(Complex a, Complex b)
                => new Complex((a.Real*b.Real + a.Image*b.Image)/(b.Real * b.Real + b.Image*b.Image), (b.Real * a.Image - a.Real * b.Image) / (b.Real * b.Real + b.Image * b.Image));

            public static Complex operator -(Complex a) => new Complex(-a.Real, -a.Image);
        }

        public MethodMath(double step, double r)
        {
            Fi = new List<List<double>>();
            Rx = new List<List<double>>();
            E = new List<double>();
            _x = new List<double>();
            R = r;
            Step = step;
            for (double i = -R; i <= R; i += Step)
            {
                _x.Add(i);
            }
        }

        public void Refresh(double step, double r)
        {
            R = r;
            _x.Clear();
            Step = step;
            for (double i = -R; i <= R; i += Step)
            {
                _x.Add(i);
            }
        }



        private List<List<double>> Psi { get; set; }

        private List<List<double>> Fi { get; set; }
        public List<double> E { get; set; }
        public double R { get; set; }
        public double Step { get; set; }
        public List<List<double>> Rx { get; set; }
        public double K { get; set; }
        public double Order { get; set; }
        private List<double> _x;

        Complex A(int k)
        {
            return new Complex() {{Convert.ToDouble(0), Convert.ToDouble(-Step / ((_x[k + 1] - _x[k - 1])*(_x[k] - _x[k - 1])))}};
        }

        Complex B(int k)
        {
            return new Complex() { { Convert.ToDouble(0), Convert.ToDouble(-Step / ((_x[k + 1] - _x[k - 1]) * (_x[k+1] - _x[k]))) } };
        }

        Complex C(int k)
        {
            return new Complex() { { Convert.ToDouble(1), Convert.ToDouble(Step * U(_x[k])/2 + Step/(_x[k+1] - _x[k-1]) *(1/(_x[k+1] - _x[k]) + 1/(_x[k] - _x[k-1]))) } };
        }

        Complex D(int k, List<Complex> psi)
        {
            return new Complex() { { psi[k].Real + Step / 2 * (2 / (_x[k + 1] - _x[k - 1]) * ((psi[k + 1].Image - psi[k].Image) / (_x[k + 1] - _x[k]) - (psi[k].Image - psi[k - 1].Image) / (_x[k] - _x[k - 1]) - U(_x[k] * psi[k].Image))), Step/2 *(2/(_x[k+1]-_x[k-1])*((psi[k+1].Real - psi[k].Real) /(_x[k+1]-_x[k]) - (psi[k].Real - psi[k-1].Real) /(_x[k] - _x[k-1]) - U(_x[k]*psi[k].Real))) } };
        }
        
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

        double GoFiRungeKutta( double fi, double r, double e)
        {
            var k1 = FiFunction(fi, r, e);
            var k2 = FiFunction(Step / 2 * k1, r + Step / 2, e);
            var k3 = FiFunction(Step / 2 * k2, r + Step / 2, e);
            var k4 = FiFunction(Step * k3, r + Step, e);
            return fi + Step / 6 * (k1 + 2 * k2 + 2 * k3 + k4);
        }

        double GoRxRungeKutta(double fi, double rx, double r, double e)
        {
            var k1 = RxFunction(fi, rx, r, e);
            var k2 = RxFunction(Step / 2 * k1, rx, r + Step / 2, e);
            var k3 = RxFunction(Step / 2 * k2, rx, r + Step / 2, e);
            var k4 = RxFunction(Step * k3, rx, r + Step, e);
            return fi + Step / 6 * (k1 + 2 * k2 + 2 * k3 + k4);
        }

        double GoDPsiRungeKutta(double fi, double rx)
        {
            var k1 = dPsiFunction(fi, rx);
            var k2 = dPsiFunction(Step / 2 * k1, rx);
            var k3 = dPsiFunction(Step / 2 * k2, rx);
            var k4 = dPsiFunction(Step * k3, rx);
            return fi + Step / 6 * (k1 + 2 * k2 + 2 * k3 + k4);
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

        double GoBisectionMethodVer2( double from, double to, double precision, int k)
        {
            double middle = 0;

            var tmpFi1 = new List<double>();
            var tmpFi2 = new List<double>();

            do
            {
                tmpFi1.Add(Math.PI / 2);
                tmpFi2.Add(Math.PI / 2);
                middle = (from + 15*to) / 16;
                for(var i =1; i < _x.Count; ++i)
                {
                    tmpFi1.Add(GoFiRungeKutta(tmpFi1[^1], _x[i], from));
                    tmpFi2.Add(GoFiRungeKutta(tmpFi2[^1], _x[i], to));
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


        public List<List<double>> FindStationaryPsi(int count)
        {
            double e = 5;

            for (int k = 0; k < count; k++)
            {
                Fi.Add(new List<double>());
                Fi[k].Add(Math.PI / 2);
                E.Add(GoBisectionMethodVer2(0, 300, 0.001, k));


                for(var i = 1; i < _x.Count; ++i)
                {
                    Fi[k].Add(GoFiRungeKutta(Fi[k][^1], -_x[i], E[k]));
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

                    Rx[k].Add(GoRxRungeKutta(Fi[k][i], Rx[k][i], -R+(i+1)* Step, E[k]));
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

        public List<List<Complex>> FindEvolution(int tMax)
        {
            List<List<Complex>> tmpPsi0 = new List<List<Complex>>();
            List<Complex> alpha = new List<Complex>();
            List<Complex> beta = new List<Complex>();
            List<Complex> tmpA = new List<Complex>();
            List<Complex> tmpB = new List<Complex>();
            List<Complex> tmpC = new List<Complex>();
            List<Complex> tmpD = new List<Complex>();

            tmpPsi0.Add(new List<Complex>());
            for (int i = 0; i < _x.Count; i++)
            {
                tmpPsi0[^1].Add(new Complex(1* Math.Exp(-(_x[i]* _x[i])/(2*1)), 0));
            }
            for (int t = 0; t < tMax; ++t)
            {
                for (int i = 1; i < _x.Count - 1; i++)
                {
                    tmpA.Add(A(i));
                    tmpB.Add(B(i));
                    tmpC.Add(C(i));
                    tmpD.Add(D(i, tmpPsi0[^1]));
                }

                alpha.Add(new Complex(0, 0));
                beta.Add(new Complex(0, 0));
                for (int i = 2; i < _x.Count; i++)
                {
                    alpha.Add(-(tmpB[i - 2] / (tmpC[i - 2] + tmpA[i - 2] * alpha[i - 2])));
                    beta.Add((tmpD[i - 2] - tmpB[i - 2] * beta[i - 2]) / (tmpC[i - 2] + tmpA[i - 2] * alpha[i - 2]));
                }

                tmpPsi0.Add(new List<Complex>());
                tmpPsi0[^1].Add(new Complex(0, 0));
                for (int i = _x.Count - 2; i > -1; --i)
                {
                    var a = alpha[i];
                    var ps = tmpPsi0[^1][^1];
                    var b = beta[i];
                    var tmp1 = a * ps;
                    var tmp2 = tmp1 + b;

                    tmpPsi0[^1].Add((alpha[i] * tmpPsi0[^1][^1]) + beta[i]);
                }

                tmpPsi0[^1].Reverse();
                alpha.Clear();
                beta.Clear();
                tmpA.Clear();
                tmpB.Clear();
                tmpC.Clear();
                tmpD.Clear();
            }

            return tmpPsi0;
        }
    }
}
