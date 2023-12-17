using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STRCore.Helpers
{
    internal class LineSegment
    {
        private double x1;
        private double y1;
        private double z1;
        private double x2;
        private double y2;
        private double z2;
        private double[] vx; 
        private double length;
        internal LineSegment(double x1, double y1, double z1, double x2, double y2, double z2)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.z1 = z1;
            this.x2 = x2;
            this.y2 = y2;
            this.z2 = z2;
            vx = new double[3] { x2 - x1, y2 - y1, z2 - z1 };
            length = Vector.Length(vx);
            Vector.Normalize(ref vx);
        }
        internal static double[] LineSegmentXLineSegment(LineSegment segment1, LineSegment segment2)
        {
            // Determine if line segements are parrallel
            // if parallel
            double[] result = Vector.CrossProduct(segment1.vx, segment2.vx);
            bool areParallel = Vector.Length(result) < Global.Constants.Epsilon;
            if (areParallel)
                return new double[] { double.NaN, double.NaN, double.NaN };

			// if not parallel
			double a1, b1, c1, a2, b2, c2, x01, y01, z01, x02, y02, z02;
			a1 = segment1.vx[0];
			b1 = segment1.vx[1];
			c1 = segment1.vx[2];
			x01 = segment1.x1;
			y01 = segment1.y1;
			z01 = segment1.z1;
			a2 = segment2.vx[0];
			b2 = segment2.vx[1];
			c2 = segment2.vx[2];
			x02 = segment2.x2;
			y02 = segment2.y2;
			z02 = segment2.z2;

			double t1 = 0;
			double t2 = 0;
			if (Math.Abs(c1 * b2 - c2 * b1) > Global.Constants.Epsilon)
			{
				// y = y and z = z
				if (Math.Abs(b1) > Global.Constants.Epsilon)
				{
					t2 = ((z02 - z01) - c1 / b1 * (y02 - y01)) * b1 / (c1 * b2 - c2 * b1);
					t1 = (y02 - y01 + b2 * t2) / b1;
				}
				else if (Math.Abs(b2) > Global.Constants.Epsilon)
				{
					t1 = ((z01 - z02) - c2 / b2 * (y01 - y02)) * b2 / (c2 * b1 - c1 * b2);
					t2 = (y01 - y02 + b1 * t1) / b2;
				}
				else if (Math.Abs(c1) > Global.Constants.Epsilon)
				{
					t2 = ((y02 - y01) - b1 / c1 * (z02 - z01)) * c1 / (b1 * c2 - b2 * c1);
					t1 = (z02 - z01 + c2 * t2) / c1;
				}
				else if (Math.Abs(c2) > Global.Constants.Epsilon)
				{
					t1 = ((y01 - y02) - b2 / c2 * (z01 - z02)) * c2 / (b2 * c1 - b1 * c2);
					t2 = (z01 - z02 + c1 * t1) / c2;
				}
			}
			else if (Math.Abs(c1 * a2 - c2 * a1) > Global.Constants.Epsilon)
			{
				// x = x and z = z
				if (Math.Abs(a1) > Global.Constants.Epsilon)
				{
					t2 = ((z02 - z01) - c1 / a1 * (x02 - x02)) * a1 / (c1 * a2 - c2 * a1);
					t1 = (x02 - x01 + a2 * t2) / a1;
				}
				else if (Math.Abs(a2) > Global.Constants.Epsilon)
				{
					t1 = ((z01 - z02) - c2 / a2 * (x01 - x02)) * a2 / (c2 * a1 - c1 * a2);
					t2 = (x01 - x02 + a1 * t1);
				}
				else if (Math.Abs(c1) > Global.Constants.Epsilon)
				{
					t2 = ((x02 - x01) - a1 / c1 * (z02 - z01)) * c1 / (c2 * a1 - c1 * a2);
					t1 = (z02 - z01 + c2 * t2) / c1;
				}
				else if (Math.Abs(c2) > Global.Constants.Epsilon)
				{
					t1 = ((x01 - x02) - a2 / c2 * (z01 - z02)) * c2 / (a2 * c1 - a1 * c2);
					t2 = (z01 - z02 + c1 * t1) / c2;
				}
			}
			else if (Math.Abs(b1 * a2 - b2 * a1) > Global.Constants.Epsilon)
			{
				// x = x and y = y
				if (Math.Abs(a1) > Global.Constants.Epsilon)
				{
					t2 = ((y02 - y01) - b1 / a1 * (x02 - x01)) * a1 / (b1 * a2 - b2 * a1);
					t1 = (x02 - x01 + a2 * t2) / a1;
				}
				else if (Math.Abs(a2) > Global.Constants.Epsilon)
				{
					t1 = ((y01 - y02) - b2 / a2 * (x01 - x02)) * a2 / (b2 * a1 - b1 * a2);
					t2 = (x01 - x02 + a1 * t1) / a2;
				}
				else if (Math.Abs(b1) > Global.Constants.Epsilon)
				{
					t2 = ((x02 - x01) - a1 / b1 * (y02 - y01)) * b1 / (a1 * b2 - a2 * b1);
					t1 = (y02 - y01 + b2 * t2) / b1;
				}
				else if (Math.Abs(b2) > Global.Constants.Epsilon)
				{
					t1 = ((x01 - x02) - a2 / b2 * (y01 - y02)) * b2 / (a2 * b1 - a1 * b2);
					t2 = (y01 - y02 + b1 * t1) / b2;
				}
			}
			else
				return new double[] { double.NaN, double.NaN, double.NaN };

			double x11 = x01 + a1 * t1;
			double y11 = y01 + b1 * t1;
			double z11 = z01 + c1 * t1;
			double x22 = x02 + a2 * t2;
			double y22 = y02 + b2 * t2;
			double z22 = z02 + c2 * t2;

			if (Math.Abs(x11 - x22) > Global.Constants.Epsilon ||
				Math.Abs(y11 - y22) > Global.Constants.Epsilon ||
				Math.Abs(z11 - z22) > Global.Constants.Epsilon)
				return new double[] { double.NaN, double.NaN, double.NaN };

			if (!segment1.IsOnLineSegment(x11, y11, z11) || !segment2.IsOnLineSegment(x11, y11, z11))
				return new double[] { double.NaN, double.NaN, double.NaN };

			return new double[] { x11, y11, z11 };
		}

		internal bool IsOnLineSegment(double x, double y, double z)
		{
			//line equation 
			// x = at + x0
			// y = bt + y0
			// z = ct + z0
			double t = 0;
			double a = vx[0];
			double b = vx[1];
			double c = vx[2];
			double x0 = x1;
			double y0 = y1;
			double z0 = z1;
			if (Math.Abs(a) > Global.Constants.Epsilon)
				t = (x - x0) / a;
			else if (Math.Abs(b) > Global.Constants.Epsilon)
				t = (y - y0) / b;
			else if (Math.Abs(c) > Global.Constants.Epsilon)
				t = (z - z0) / c;

			double xCalc = a * t + x0;
			double yCalc = b * t + y0;
			double zCalc = c * t + z0;

			//If the point fullfills the line equation, xCalc should equal x
			if (Math.Abs(xCalc - x) > Global.Constants.Epsilon || //we cannot say xCalc = x because of possible numerical error
				Math.Abs(yCalc - y) > Global.Constants.Epsilon ||
				Math.Abs(zCalc - z) > Global.Constants.Epsilon)
				return false;

			//Check if on the line segment (between both start and end points)
			double xMax = Math.Max(x1, x2); double yMax = Math.Max(y1, y2); double zMax = Math.Max(z1, z2);
			double xMin = Math.Min(x1, x2); double yMin = Math.Min(y1, y2); double zMin = Math.Min(z1, z2);
			if (x < (xMax + Global.Constants.Epsilon) && x > (xMin - Global.Constants.Epsilon) && // x < xMax and x > xMin with errors
				y < (yMax + Global.Constants.Epsilon) && y > (yMin - Global.Constants.Epsilon) &&
				z < (zMax + Global.Constants.Epsilon) && z > (zMin - Global.Constants.Epsilon))
				return true;
			else
				return false;
		}
    }
}
