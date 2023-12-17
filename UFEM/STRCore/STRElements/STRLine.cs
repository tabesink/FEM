using STRCore.FEMElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STRCore.STRElements
{
    public class STRLine
    {
        private int id;
        /// <summary>
        /// Id of bar
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private STRNode node1;
        /// <summary>
        /// Starting node of line
        /// </summary>
        public STRNode Node1
        {
            get { return node1; }
            set { node1 = value; }
        }

        private STRNode node2;
        /// <summary>
        /// Ending node of line
        /// </summary>
        public STRNode Node2
        {
            get { return node2; }
            set { node2 = value; }
        }

        private STRMaterial material;
        /// <summary>
        /// The material of the line
        /// </summary>
        public STRMaterial Material
        {
            get { return material; }
            set { material = value; }
        }

        private STRRelease release;
        /// <summary>
        /// The releases (e.g. internal hinges) of the lines
        /// </summary>
        public STRRelease Release
        {
            get { return release; }
            set { release = value; }
        }

        private STRSection section;
        /// <summary>
        /// THe cross-section information of the line
        /// </summary>
        public STRSection Section
        {
            get { return section; }
            set { section = value; }
        }

        private double[] cG;
        /// <summary>
        /// The centre of gravity
        /// </summary>
        public double[] CG
        {
            get { return cG; }
            set { cG = value; }
        }

        private double length;
        /// <summary>
        /// Length of the bar 
        /// </summary>
        public double Length
        {
            get { return length; }
            set { length = value; }
        }


        private double[] vx;
        /// <summary>
        /// The local x-axis unit vector
        /// </summary>
        public double[] Vx
        {
            get { return vx; }
            set { vx = value; }
        }

        private double[] vy;
        /// <summary>
        /// The local x-axis unit vector
        /// </summary>
        public double[] Vy
        {
            get { return vy; }
            set { vy = value; }
        }

        private double[] vz;
        /// <summary>
        /// The local x-axis unit vector
        /// </summary>
        public double[] Vz
        {
            get { return vz; }
            set { vz = value; }
        }

        private List<FEMBar> fEMBars;
        /// <summary>
        /// A list of FEMBars
        /// </summary>
        public List<FEMBar> FEMBars
        {
            get { return fEMBars; }
            set { fEMBars = value; }
        }

        public STRLine(int id, STRNode node1, STRNode node2)
        {
            this.id = id;
            this.node1 = node1;
            this.node2 = node2;
            Refresh();
        }

        public void Refresh()
        {
            cG = new double[3];
            cG[0] = (node2.X - node1.X) / 2.0;
            cG[1] = (node2.Y - node1.Y) / 2.0;
            cG[2] = (node2.Z - node1.Z) / 2.0;

            vx = new double[3];
            vx[0] = node2.X - node1.X;
            vx[1] = node2.Y - node1.Y;
            vx[2] = node2.Z - node1.Z;
            length = Helpers.Vector.Length(vx);
            Helpers.Vector.Normalize(ref vx);

            vx = new double[3];
            vx[0] = node2.X - node1.X;
            vx[1] = node2.Y - node1.Y;
            vx[2] = node2.Z - node1.Z;
            Helpers.Vector.Normalize(ref vx);

            // catch special cases
            bool isParallelToZ = false;
            if (Math.Abs(vx[0]) < Global.Constants.Epsilon && Math.Abs(vx[1]) < Global.Constants.Epsilon)
                isParallelToZ = true;
            if (!isParallelToZ)
            {
                double[] globalZ = new double[] { 0, 0, 1 };
                vy = Helpers.Vector.CrossProduct(globalZ, vx);
                Helpers.Vector.Normalize(ref vy);
                vz = Helpers.Vector.CrossProduct(vx, vy);
                Helpers.Vector.Normalize(ref vz);

            }
            else 
            {
                if (vx[2] < Global.Constants.Epsilon)
                {
                    vy = new double[] { 0, 1, 0 };
                    vz = Helpers.Vector.CrossProduct(vx, vy);
                    Helpers.Vector.Normalize(ref vz);
                }
                else
                {
                    vy = new double[] { 0, 1, 0 };
                    vz = Helpers.Vector.CrossProduct(vx, vy);
                    Helpers.Vector.Normalize(ref vz);
                }
            }

        }

        public override string ToString()
        {
            return "STRLine#" + id + "\n" + node1.ToString() + "\n" + node2.ToString() + "\n" +
                "L = " + length.ToString("0.00") + "\n" +
                "vx = [" + vx[0].ToString("0.00") + ", " + vx[1].ToString("0.00") + ", " + vx[2].ToString("0.00") + "]\n" +
                "vx = [" + vy[0].ToString("0.00") + ", " + vy[1].ToString("0.00") + ", " + vy[2].ToString("0.00") + "]\n" +
                "vx = [" + vz[0].ToString("0.00") + ", " + vz[1].ToString("0.00") + ", " + vz[2].ToString("0.00") + "]\n" +
                "Section: " + (section == null? "n/a" : section.ToString()) + "\n" + 
                "Material: " + (material == null ? "n/a" : material.ToString()) + "\n" + 
                "Release: " + (release == null ? "n/a" : release.ToString());
        }

    }
}
