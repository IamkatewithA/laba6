using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Windows.Forms.AxHost;

namespace laba6
{
    internal class Class1
    {
        public double G(double x, double y)
        {
            try
            {
                double f = y / Math.Sin(-x * x);
                return f;
            }
            catch (Exception) {
                return double.NaN;
            }
            
            
        }
        public Array X(double startX, double endX, double step)
        {
            int size = (int)Math.Ceiling((endX - startX) / step) + 1;
            double[] range = new double[size];

            for (int i = 0; i < size; i++)
            {
                range[i] = startX + step * i;
            }

            return range;
        }
        public Array Y(double startY, double endY, int n)
        {
            double step = (endY - startY) / (n - 1);
            double[] range = new double[n];

            for (int i = 0; i < n; i++)
            {
                range[i] = startY + step * i;
            }

            return range;
        }

    }
}
