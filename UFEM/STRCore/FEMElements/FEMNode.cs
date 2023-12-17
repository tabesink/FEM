using STRCore.STRElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STRCore.FEMElements
{
    public class FEMNode
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private double x;
        public double X
        {
            get { return x; }
            set { x = value; }
        }
        private double y;
        public double Y
        {
            get { return y; }
            set { y = value; }
        }
        private double z;
        public double Z
        {
            get { return z; }
            set { z = value; }
        }
        private bool isMasterNode;
        public bool IsMasterNode
        {
            get { return isMasterNode; }
            set { isMasterNode = value; }
        }
        private bool isSupportNode;
        public bool IsSupportNode
        {
            get { return isSupportNode; }
            set { isSupportNode = value; }
        }
        private STRNode correspondingSTRNode;
        public STRNode CorrespondingSTRNode
        {
            get { return correspondingSTRNode; }
            set { correspondingSTRNode = value; }
        }
        private FEMNode masterFEMNode;
        public FEMNode MasterFEMNode
        {
            get { return masterFEMNode; }
            set { masterFEMNode = value; }
        }
        private FEMNode slaveFEMNode;
        public FEMNode SlaveFEMNode
        {
            get { return slaveFEMNode; }
            set { slaveFEMNode = value; }
        }
        private bool isSlaveNode;
        public bool IsSlaveNode
        {
            get { return isSlaveNode; }
            set { isSlaveNode = value; }
        }
        internal FEMNode(int id, double x, double y, double z)
        {
            this.id = id;
            this.x = x;
            this.y = y;
            this.z = z;
            isMasterNode = false;
            isSupportNode = false;
            masterFEMNode = null;
            correspondingSTRNode = null;
        }
    }
}
