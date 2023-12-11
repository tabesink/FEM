using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STRCore.STRElements
{
    public class STRNode // public for the purpose of debugging
    {
        private int id;
        /// <summary>
        /// The id
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private double x;
        /// <summary>
        /// The X Coordinate
        /// </summary>
        public double X
        {
            get { return x; }
            set { x = value;}
        }

        private double y;
        /// <summary>
        /// The Y Coordinate
        /// </summary>
        public double Y
        {
            get { return y; }
            set { y = value;}
        }

        private double z;
        /// <summary>
        /// The Z Coordinate
        /// </summary>
        public double Z
        {
            get { return z; }
            set { z = value; }
        }

        private STRSupport support;
        /// <summary>
        /// The BC of the node
        /// </summary>
        public STRSupport Support
        {
            get { return support; }
            set { support = value; }
        }


        public STRNode(int id, double x, double y, double z)
        {
            this.id = id;
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public override string ToString()
        {
            return "STRNode #" +id + ": [" + x.ToString("0.00") + ", " + y.ToString("0.00") + ", " + z.ToString("0.00") + "]" + " Support: " + (support == null? "Free": support.Name);
        }

    }
}
