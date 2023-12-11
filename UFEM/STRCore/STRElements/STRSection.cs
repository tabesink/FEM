using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STRCore.STRElements
{
    public class STRSection
    {
        private int id;
        /// <summary>
        /// Id of the section
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string name;
        /// <summary>
        /// Name of the section
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private double area;
        /// <summary>
        /// Area of the section
        /// </summary>
        public double Area
        {
            get { return area; }
            set { area = value; }
        }

        private double ix;
        /// <summary>
        /// Polar moment of intertia of the section (Ix)
        /// </summary>
        public double Ix
        {
            get { return ix; }
            set { ix = value; }
        }

        private double iy;
        /// <summary>
        /// Polar moment of intertia of the section (Iy)
        /// </summary>
        public double Iy
        {
            get { return iy; }
            set { iy = value; }
        }

        private double iz;
        /// <summary>
        /// Polar moment of intertia of the section (Iz)
        /// </summary>
        public double Iz
        {
            get { return iz; }
            set { iz = value; }
        }

        internal STRSection(int id, string name, double area, double ix, double iy, double iz)
        {
            this.id = id;
            this.name = name;
            this.area = area;
            this.ix = ix;
            this.iy = iy;
            this.iz = iz;
        }

        public override string ToString()
        {
            return "STRSection#" + id + " (" + name + "): A=" + area.ToString("0.00e00");
        }

    }
}
