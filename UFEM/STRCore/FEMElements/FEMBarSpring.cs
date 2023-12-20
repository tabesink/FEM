using STRCore.STRElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STRCore.FEMElements
{
    class FEMBarSpring: FEMBar
    {
        private int id;
        /// <summary>
        /// Id of support
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string name;
        /// <summary>
        /// Name of support
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private double kUx;
        /// <summary>
        /// Linear spring support in x
        /// </summary>
        public double KUx
        {
            get { return kUx; }
            set { kUx = value; }
        }

        private double kUy;
        /// <summary>
        /// Linear spring support in y
        /// </summary>
        public double KUy
        {
            get { return kUy; }
            set { kUy = value; }
        }

        private double kUz;
        /// <summary>
        /// Linear spring support in y
        /// </summary>
        public double KUz
        {
            get { return kUz; }
            set { kUz = value; }
        }


        private double kRx;
        /// <summary>
        /// Rotational spring support around global x
        /// </summary>
        public double KRx
        {
            get { return kRx; }
            set { kRx = value; }
        }

        private double kRy;
        /// <summary>
        /// Rotational spring support around global y
        /// </summary>
        public double KRy
        {
            get { return kRy; }
            set { kRy = value; }
        }

        private double kRz;
        /// <summary>
        /// Rotational spring support around global z
        /// </summary>
        public double KRz
        {
            get { return kRz; }
            set { kRz = value; }
        }
        internal FEMBarSpring(int id, FEMNode femNode1, FEMNode femNode2, double length, double[] vx, double[] vy, double[] vz, STRSection section, STRMaterial material): base(id, femNode1, femNode2, length, vx, vy, vz, section, material)
        {
            
        }
    }
}
