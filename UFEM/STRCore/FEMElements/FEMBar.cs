using STRCore.STRElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STRCore.FEMElements
{
    public class FEMBar
    {
        private FEMNode femNode1;
        /// <summary>
        /// Starting FEM node 
        /// </summary>
        public FEMNode FEMNode1
        {
            get { return  femNode1; }
            set {  femNode1 = value; }
        }
        private FEMNode femNode2;
        /// <summary>
        /// End FEM node 
        /// </summary>
        public FEMNode FEMNode2
        {
            get { return femNode2; }
            set { femNode2 = value; }
        }
        private List<FEMNode> femNodes;
        /// <summary>
        /// List of all nodes in fem bar
        /// </summary>
        public List<FEMNode> FEMNodes
        {
            get { return femNodes; }
            set { femNodes = value; }
        }
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private double[] vx;
        public double[] Vx
        {
            get { return vx; }
            set { vx = value; }
        }
        private double[] vy;
        public double[] Vy
        {
            get { return vy; }
            set { vy = value; }
        }
        private double[] vz;
        public double[] Vz
        {
            get { return vz; }
            set { vz = value; }
        }
        private STRLine correspondingSTRLine;
        public STRLine CorrespondingSTRLine
        {
            get { return correspondingSTRLine; }
            set { correspondingSTRLine = value; }
        }
        private STRMaterial material;
        public STRMaterial Material
        {
            get { return material; }
            set { material = value; }
        }
        private STRSection section;
        public STRSection Section
        {
            get { return section; }
            set { section = value; }
        }
        private double length;
        public double Length
        {
            get { return length; }
            set { length = value; }
        }
        internal FEMBar(int id, FEMNode femNode1, FEMNode femNode2, double length, double[] vx, double[] vy, double[] vz, STRSection section, STRMaterial material)
        {
            this.id = id;
            this.femNode1 = femNode1;
            this.femNode2 = femNode2;
            this.length = length;
            this.vx = vx;
            this.vy = vy;
            this.vz = vz;
            this.section = section;
            this.material = material;
            femNodes = new List<FEMNode>();
            femNodes.Add(femNode1);
            femNodes.Add(femNode2);
            correspondingSTRLine = null;
        }
    }
}
