using System;
using System.Collections.Generic;
using System.Text;

namespace FindSpectrum
{
    public static class FFT
    {
        /// <summary>
        /// Вычисление поворачивающего модуля e^(-i*2*PI*k/N)
        /// </summary>
        /// <param name="k"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        private static MethodMath.Complex w(int k, int N)
        {
            //if (k % N == 0) return 1;
            double arg = -2 * Math.PI * k / N;
            return new MethodMath.Complex(Math.Cos(arg), Math.Sin(arg));
        }
        /// <summary>
        /// Возвращает спектр сигнала
        /// </summary>
        /// <param name="x">Массив значений сигнала. Количество значений должно быть степенью 2</param>
        /// <returns>Массив со значениями спектра сигнала</returns>
        public static MethodMath.Complex[] fft(MethodMath.Complex[] x)
        {
            MethodMath.Complex[] X;
            int N = x.Length;
            if (N == 2)
            {
                X = new MethodMath.Complex[2];
                X[0] = x[0] + x[1];
                X[1] = x[0] - x[1];
            }
            else
            {
                MethodMath.Complex[] x_even = new MethodMath.Complex[N / 2];
                MethodMath.Complex[] x_odd = new MethodMath.Complex[N / 2];
                for (int i = 0; i < N / 2; i++)
                {
                    x_even[i] = x[2 * i];
                    x_odd[i] = x[2 * i + 1];
                }
                MethodMath.Complex[] X_even = fft(x_even);
                MethodMath.Complex[] X_odd = fft(x_odd);
                X = new MethodMath.Complex[N];
                for (int i = 0; i < N / 2; i++)
                {
                    X[i] = X_even[i] + w(i, N) * X_odd[i];
                    X[i + N / 2] = X_even[i] - w(i, N) * X_odd[i];
                }
            }
            return X;
        }
        /// <summary>
        /// Центровка массива значений полученных в fft (спектральная составляющая при нулевой частоте будет в центре массива)
        /// </summary>
        /// <param name="X">Массив значений полученный в fft</param>
        /// <returns></returns>
        public static MethodMath.Complex[] nfft(MethodMath.Complex[] X)
        {
            int N = X.Length;
            MethodMath.Complex[] X_n = new MethodMath.Complex[N];
            for (int i = 0; i < N / 2; i++)
            {
                X_n[i] = X[N / 2 + i];
                X_n[N / 2 + i] = X[i];
            }
            return X_n;
        }
    }
}
