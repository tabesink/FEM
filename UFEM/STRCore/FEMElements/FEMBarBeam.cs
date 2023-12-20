using STRCore.STRElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STRCore.FEMElements
{
    internal class FEMBarBeam:FEMBar
    {
        internal FEMBarBeam(int id, FEMNode femNode1, FEMNode femNode2, double length, double[] vx, double[] vy, double[] vz, STRSection section, STRMaterial material) : base(id, femNode1, femNode2, length, vx, vy, vz, section, material)
        {

        }
    }
}
