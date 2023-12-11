using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STRCore.Helpers
{
    internal static class Vectors // keep static, don't want to instantiate any members of this class
    {
        internal static void Normalize(ref double[] vin)
        {
            double length = Length(vin);
            vin[0] /= length;
            vin[1] /= length;
            vin[2] /= length;
        }

        internal static double Length(double[] vin) // todo: check if length is 0
        {
            return Math.Sqrt(Math.Pow(vin[0],2)+ Math.Pow(vin[1], 2)+ Math.Pow(vin[2], 2));
        }

        internal static double DotProduct(double[] vl, double[] vr)
        {
            return vl[0] * vr[0] + vl[1] * vr[1] + vl[2] * vr[2];
        }

        internal static double[] CrossProduct(double[] vl, double[] vr)
        {
            double[] output = new double[] { 0, 0, 0 };
            // x - y - z 
            double x = vl[1] * vr[2] - vl[2] * vr[1];
            double y = vl[2] * vr[0] - vl[0] * vr[2];
            double z = vl[0] * vr[1] - vl[1] * vr[0];

            output[0] = x;
            output[1] = y;
            output[2] = z;

            return output;
        }
    }
}
