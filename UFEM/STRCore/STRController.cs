using STRCore.FEMElements;
using STRCore.STRElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Global.Enums;

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
        public void PerformAnalysis()
        {
            // Clear the old analysis 
            Helpers.ModelHelper.ClearStrucutralModel();

            // Prepare the strucutral model 
            Helpers.ModelHelper.PrepareStructuralModel();

            // Generate finte elements
            Helpers.ModelHelper.GenerateFiniteElements();

            // Solve F = kx to find x 

            // Perform post-processing
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

        internal FEMBarSpring DefineFEMBarSpring(FEMNode femMasterNode, FEMNode femSlaveNode)
        {
            throw new NotImplementedException();
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
        public STRNode GetSTRNode(double x, double y, double z)
        {
            foreach (STRNode node in structure.Nodes)
            {
                // node.x = x; node.y = y; node.z = z;
                double length = Math.Sqrt(Math.Pow(x - node.X, 2) + Math.Pow(y - node.Y, 2) + Math.Pow(z - node.Z, 2));
                if (length < Global.Constants.Epsilon)
                {
                    return node;
                }
            }
            return null;
        }
        public FEMNode GetFEMNode(double x, double y, double z)
        {
            foreach (FEMNode node in structure.FEMNodes)
            {
                // node.x = x; node.y = y; node.z = z;
                double length = Math.Sqrt(Math.Pow(x - node.X, 2) + Math.Pow(y - node.Y, 2) + Math.Pow(z - node.Z, 2));
                if (length < Global.Constants.FEMEpsilon)
                {
                    return node;
                }
            }
            return null;
        }
        public STRNode DefineSTRNode(double x, double y, double z)
        {
            STRNode possibleDuplicate = GetSTRNode(x, y, z);
            if (possibleDuplicate != null) return possibleDuplicate;

            int id = GetNextNodeId();
            STRNode output = new STRNode(id, x, y, z);
            structure.Nodes.Add(output);
            return output;
        }
        public FEMNode DefineFEMNode(double x, double y, double z)
        {
            FEMNode possibleDuplicate = GetFEMNode(x, y, z);
            if (possibleDuplicate != null) return possibleDuplicate;

            int id = GetNextFEMNodeId();
            FEMNode output = new FEMNode(id, x, y, z);
            structure.FEMNodes.Add(output);
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
        public STRLine DefineSTRLine(STRNode node1, STRNode node2)
        {
            int id = GetNextLineId();
            STRLine output = new STRLine(id, node1, node2);
            structure.Lines.Add(output);
            return output;
        }
        public void DeleteSTRLine(STRLine target)
        {
            if (structure.Lines.Exists(item => item.Id == target.Id))
            {
                structure.Lines.Remove(target);
            }
        }
        public void ModifySTRLine(STRLine target, STRNode node1, STRNode node2, STRMaterial material, STRRelease release, STRSection section)
        {
            target.Node1 = node1;
            target.Node2 = node2;
            target.Material = material;
            target.Release = release;
            target.Section = section;
            target.Refresh();
        }
        public STRLoadCase DefineSTRLoadCase(string name, LoadCaseTypes loadCaseType)
        {
            int id = GetNextLoadCaseId();
            STRLoadCase output = new STRLoadCase(id, name, loadCaseType);
            structure.LoadCases.Add(output);
            return output;
        }
        public void ModifySTRLoadCase(STRLoadCase target, string name, LoadCaseTypes loadCaseType)
        {
            target.Name = name;
            target.LoadCaseType = loadCaseType;
        }
        public void DeleteSTRLoadCase(STRLoadCase target)
        {
            if (structure.LoadCases.Exists(item => item.Id == target.Id))
            {
                structure.LoadCases.Remove(target);

                for (int i = 0; i < structure.LoadCases.Count; i++)
                {
                    STRLoadCase possibleComb = structure.LoadCases[i];
                    if (possibleComb is STRLoadCombination)
                    {
                        STRLoadCombination comb = (STRLoadCombination)possibleComb;
                        if (comb.LoadCases.Exists(item => item.Id == target.Id))
                        {
                            int index = comb.LoadCases.FindIndex(item => item.Id == target.Id);
                            comb.LoadCases.RemoveAt(index);
                            comb.LoadCaseFactors.RemoveAt(index);
                        }
                    }
                }
                // todo: remove case from combinatations
                /*foreach (STRLine line in structure.Lines)
                {
                    if (line.Section.Id == target.Id)
                        line.Section = null;
                }*/
            }
        }
        public STRLoadCombination DefineSTRCombinationCase(string name, LoadCombinationTypes loadCombinationType)
        {
            // applying polymorphism: polymorphism means "many forms", and it occurs when we have many classes that are related to each other by inheritance
            int id = GetNextLoadCaseId();
            STRLoadCombination output = new STRLoadCombination(id, name, loadCombinationType);
            structure.LoadCases.Add(output);
            return output;
        }
        public void ModifySTRLoadCombination(STRLoadCombination target, string name, LoadCombinationTypes loadCombinationType, List<STRLoadCase> includedLoadCases, List<double> includedLoadFactors)
        {
            target.Name = name;
            target.LoadCombinationType = loadCombinationType;
            target.LoadCases.Clear();

            for (int i = 0; i < includedLoadCases.Count; i++)
            {
                target.LoadCaseFactors.Add(includedLoadFactors[i]);
                target.LoadCases.Add(includedLoadCases[i]);
            }

            target.LoadCases = includedLoadCases;
            target.LoadCaseFactors = includedLoadFactors;

        }
        public STRLoad DefineSTRLoad(STRLoadCase loadCase, List<int> appliedOnIds)
        {
            int id = GetNextLoadId();
            STRLoad output = new STRLoad(id, loadCase, appliedOnIds);
            structure.Loads.Add(output);
            return output;
        }
        public STRLoadNodal DefineSTRLoadNodal(STRLoadCase loadCase, List<int> appliedOnIds, double fx, double fy, double fz, double mx, double my, double mz)
        {
            int id = GetNextLoadId();
            STRLoadNodal output = new STRLoadNodal(id, loadCase, appliedOnIds, fx, fy, fz, mx, my, mz);
            structure.Loads.Add(output);
            return output;
        }
        public void ModifySTRLoadNodal(STRLoadNodal target, STRLoadCase loadCase, List<int> appliedOnIds, double fx, double fy, double fz, double mx, double my, double mz)
        {
            target.LoadCase = loadCase;
            target.AppliedOnIds.Clear();
            foreach (int appliedOnId in appliedOnIds)
                target.AppliedOnIds.Add(appliedOnId);
            target.Fx = fx;
            target.Fy = fy;
            target.Fz = fz;
            target.Mx = mx;
            target.My = my;
            target.Mz = mz;
        }
        public STRLoadLinearConcentrated DefineSTRLoadLinearConcentrated(STRLoadCase loadCase, List<int> appliedOnIds, double fx, double fy, double fz, double mx, double my, double mz, double relLoc)
        {
            int id = GetNextLoadId();
            STRLoadLinearConcentrated output = new STRLoadLinearConcentrated(id, loadCase, appliedOnIds, fx, fy, fz, mx, my, mz, relLoc);
            structure.Loads.Add(output);
            return output;
        }
        public void ModifySTRLoadLinearConcentrated(STRLoadLinearConcentrated target, STRLoadCase loadCase, List<int> appliedOnIds, double fx, double fy, double fz, double mx, double my, double mz, double relLoc)
        {
            target.LoadCase = loadCase;
            target.AppliedOnIds.Clear();
            foreach (int appliedOnId in appliedOnIds)
                target.AppliedOnIds.Add(appliedOnId);
            target.Fx = fx;
            target.Fy = fy;
            target.Fz = fz;
            target.Mx = mx;
            target.My = my;
            target.Mz = mz;
            target.RelativeLocation = relLoc;
        }
        public STRLoadLinearDistributed DefineSTRLoadLinearDistributed(STRLoadCase loadCase, List<int> appliedOnIds, 
            double fx1, double fy1, double fz1, double mx1, double my1, double mz1, double relLoc1,
            double fx2, double fy2, double fz2, double mx2, double my2, double mz2, double relLoc2)
        {
            int id = GetNextLoadId();
            STRLoadLinearDistributed output = new STRLoadLinearDistributed(id, loadCase, appliedOnIds, 
                fx1, fy1, fz1, mx1, my1, mz1, relLoc1, 
                fx2, fy2, fz2, mx2, my2, mz2, relLoc2);
            structure.Loads.Add(output);
            return output;
        }
        public void ModifySTRLoadLinearDistributed(STRLoadLinearDistributed target, STRLoadCase loadCase, List<int> appliedOnIds,
            double fx1, double fy1, double fz1, double mx1, double my1, double mz1, double relLoc1,
            double fx2, double fy2, double fz2, double mx2, double my2, double mz2, double relLoc2)
        {
            target.LoadCase = loadCase;
            target.AppliedOnIds.Clear();
            foreach (int appliedOnId in appliedOnIds)
                target.AppliedOnIds.Add(appliedOnId);
            target.Fx1 = fx1;
            target.Fy1 = fy1;
            target.Fz1 = fz1;
            target.Mx1 = mx1;
            target.My1 = my1;
            target.Mz1 = mz1;
            target.Fx2 = fx2;
            target.Fy2 = fy2;
            target.Fz2 = fz2;
            target.Mx2 = mx2;
            target.My2 = my2;
            target.Mz2 = mz2;
            target.RelativeLocation1 = relLoc1;
            target.RelativeLocation2 = relLoc2;
        }
        public void DeleteSTRLoad(STRLoad target)
        {
            if (structure.Loads.Exists(item => item.Id == target.Id))
            {
                structure.Loads.Remove(target);
            }
        }
        public void DeleteSTRLoadCombination(STRLoadCombination target)
        {
            if (structure.LoadCases.Exists(item => item.Id == target.Id))
            {
                structure.LoadCases.Remove(target);
            }
        }
        private int GetNextLoadCaseId()
        {
            structure.LastLoadCaseId++;
            return structure.LastLoadCaseId;
        }
        private int GetNextNodeId()
        {
            structure.LastNodeId++;
            return structure.LastNodeId;
        }
        private int GetNextFEMNodeId()
        {
            structure.LastFEMNodeId++;
            return structure.LastFEMNodeId;
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
        private int GetNextLoadId()
        {
            structure.LastLoadId++;
            return structure.LastLoadId;
        }
    }
}
