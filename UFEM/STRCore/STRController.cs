using STRCore.STRElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STRCore
{
    public class STRController
    {
        public static STRController CurrentController;
        private STRStructure structure;
        /// <summary>
        /// The structure currently controlled by the controller
        /// </summary>
        public STRStructure Structure
        {
            get { return structure; }
            set { structure = value; }
        }

        public static void Initialize()
        {
            CurrentController = new STRController();
        }

        internal STRController()
        {
            structure = new STRStructure();
        }

        public override string ToString()
        {
            return "Active controller with the current structure: \n" + structure.ToString();
        }

        public STRMaterial DefineSTRMaterial(string name, double elasticModulus)
        {
            int id = GetNextMaterialId();
            STRMaterial definedMaterial = new STRMaterial(id, elasticModulus, name);
            structure.Materials.Add(definedMaterial);
            return definedMaterial;
        }

        public void ModifySTRMaterial(STRMaterial target, string name, double elasticModulus)
        {
            target.Name = name;
            target.ElasticModulus = elasticModulus;
        }

        public void DeleteSTRMaterial(STRMaterial target)
        {
            if (structure.Materials.Exists(item => item.Id == target.Id))
            {
                structure.Materials.Remove(target);
                foreach (STRLine line in structure.Lines)
                {
                    if (line.Material.Id == target.Id)
                        line.Material = null;
                }
            }
        }

        public STRRelease DefineSTRRelease(string name, double kUxStart, double kUyStart, double kUzStart, double kRxStart, double kRyStart, double kRzStart, double kUxEnd, double kUyEnd, double kUzEnd, double kRxEnd, double kRyEnd, double kRzEnd)
        {
            int id = GetNextReleaseId();
            STRRelease output = new STRRelease(id, name, kUxStart, kUyStart, kUzStart, kRxStart, kRyStart, kRzStart, kUxEnd, kUyEnd, kUzEnd, kRxEnd, kRyEnd, kRzEnd);
            structure.Releases.Add(output);
            return output;
        }

        public void ModifySTRRelease(STRRelease target, string name, double kUxStart, double kUyStart, double kUzStart, double kRxStart, double kRyStart, double kRzStart, double kUxEnd, double kUyEnd, double kUzEnd, double kRxEnd, double kRyEnd, double kRzEnd)
        {
            target.Name = name;
            target.KUxStart = kUxStart;
            target.KUyStart = kUyStart;
            target.KUzStart = kUzStart;
            target.KRxStart = kRxStart;
            target.KRyStart = kRyStart;
            target.KRzStart = kRzStart;

            target.KUxEnd = kUxEnd;
            target.KUyEnd = kUyEnd;
            target.KUzEnd = kUzEnd;
            target.KRxEnd = kRxEnd;
            target.KRyEnd = kRyEnd;
            target.KRzEnd = kRzEnd;
        }

        public void DeleteSTRRelease(STRRelease target)
        {
            if (structure.Releases.Exists(item => item.Id == target.Id))
            {
                structure.Releases.Remove(target);
                foreach (STRLine line in structure.Lines)
                {
                    if (line.Release.Id == target.Id)
                        line.Release = null;
                }
            }
        }

        public STRSupport DefineSTRSupport(string name, bool isUxActive, bool isUyActive, bool isUzActive, bool isRxActive, bool isRyActive, bool isRzActive)
        {
            int id = GetNextSupportId();
            STRSupport output = new STRSupport(id, name, isUxActive, isUyActive, isUzActive, isRxActive, isRyActive, isRzActive);
            structure.Supports.Add(output);
            return output;
        }

        public void ModifySTRSupport(STRSupport target, string name, bool isUxActive, bool isUyActive, bool isUzActive, bool isRxActive, bool isRyActive, bool isRzActive)
        {
            target.Name = name;
            target.IsUxActive = isUxActive;
            target.IsUyActive = isUyActive;
            target.IsUzActive = isUzActive;
            target.IsRxActive = isRxActive;
            target.IsRyActive = isRyActive;
            target.IsRzActive = isRzActive;
            target.Referesh();
        }

        public void DeleteSTRSupport(STRSupport target)
        {
            if (structure.Supports.Exists(item => item.Id == target.Id))
            {
                structure.Supports.Remove(target);
                foreach (STRNode node in structure.Nodes)
                {
                    if (node.Support.Id == target.Id)
                        node.Support = null;
                }
            }
        }

        public STRSection DefineSTRSection(string name, double area, double ix, double iy, double iz)
        {
            int id = GetNextSectionId();
            STRSection output = new STRSection(id, name, area, ix, iy, iz);
            structure.Sections.Add(output);
            return output;
        }

        public void ModifySTRSection(STRSection target, string name, double area, double ix, double iy, double iz)
        {
            target.Name = name;
            target.Area = area;
            target.Ix = ix;
            target.Iy = iy;
            target.Iz = iz;
        }

        public void DeleteSTRSection(STRSection target)
        {
            if (structure.Sections.Exists(item => item.Id == target.Id))
            {
                structure.Sections.Remove(target);
                foreach (STRLine line in structure.Lines)
                {
                    if (line.Section.Id == target.Id)
                        line.Section = null;
                }
            }
        }

        public STRNode DefineSTRNode(double x, double y, double z)
        {
            int id = GetNextNodeId();
            STRNode output = new STRNode(id, x, y, z);
            structure.Nodes.Add(output);
            return output;
        }

        public void ModifySTRNode(STRNode target, double x, double y, double z, STRSupport support)
        {
            target.X = x;
            target.Y = y;
            target.Z = z;
            target.Support = support;
            foreach (STRLine line in structure.Lines)
            {
                if (line.Node1.Id == target.Id || line.Node2.Id == target.Id)
                    line.Refresh();
            }
        }

        public void DeleteSTRNode(STRNode target, bool forceDelete)
        {
            bool isNodePartOfLine = false;
            foreach (STRLine line in structure.Lines)
            {
                if (line.Node1.Id == target.Id || line.Node2.Id == target.Id)
                {
                    isNodePartOfLine = true;
                    break;
                }
            }

            if (isNodePartOfLine && !forceDelete) return;
            else
            {
                // delete the node
                if (structure.Nodes.Exists(item => item.Id == target.Id))
                    structure.Nodes.Remove(target);

                // search for all lines that have this node as node1 or 2
                List<STRLine> affectedLines = structure.Lines.FindAll(item => item.Node1.Id == target.Id || item.Node2.Id == target.Id);

                // delete all lines 
                foreach (STRLine affectedLine in affectedLines)
                    DeleteSTRLine(affectedLine);
            }
        }

        public void DeleteSTRLine(STRLine target)
        {
            
        }

        private int GetNextNodeId()
        {
            structure.LastNodeId++;
            return structure.LastNodeId;
        }

        private int GetNextLineId()
        {
            structure.LastLineId++;
            return structure.LastLineId;
        }

        private int GetNextMaterialId()
        {
            structure.LastMaterialId++;
            return structure.LastMaterialId;
        }

        private int GetNextReleaseId()
        {
            structure.LastReleaseId++;
            return structure.LastReleaseId;
        }

        private int GetNextSupportId()
        {
            structure.LastSupportId++;
            return structure.LastSupportId;
        }

        private int GetNextSectionId()
        {
            structure.LastSectionId++;
            return structure.LastSectionId;
        }
    }
}
