using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STRCore.FEMElements;
using STRCore.STRElements;

namespace STRCore
{
    public class STRStructure
    {
        private int lastNodeId;
        /// <summary>
        /// Id system for nodes
        /// </summary>
        public int LastNodeId
        {
            get { return lastNodeId; }
            set { lastNodeId = value; }
        }
        private int lastLineId;
        /// <summary>
        /// Id system for lines
        /// </summary>
        public int LastLineId
        {
            get { return lastLineId; }
            set { lastLineId = value; }
        }
        private int lastMaterialId;
        /// <summary>
        /// Id system for material
        /// </summary>
        public int LastMaterialId
        {
            get { return lastMaterialId; }
            set { lastMaterialId = value; }
        }
        private int lastReleaseId;
        /// <summary>
        /// Id system for material 
        /// </summary>
        public int LastReleaseId
        {
            get { return lastReleaseId; }
            set { lastReleaseId = value; }
        }
        private int lastSectionId;
        /// <summary>
        /// Id system for section
        /// </summary>
        public int LastSectionId
        {
            get { return lastSectionId; }
            set { lastSectionId = value; }
        }
        private int lastLoadId;
        /// <summary>
        /// Id system for loads
        /// </summary>
        public int LastLoadId
        {
            get { return lastLoadId; }
            set { lastLoadId = value; }
        }
        private int lastSupportId;
        /// <summary>
        /// Id system for support
        /// </summary>
        public int LastSupportId
        {
            get { return lastSupportId; }
            set { lastSupportId = value; }
        }
        private int lastLoadCaseId;
        /// <summary>
        /// Last load case id
        /// </summary>
        public int LastLoadCaseId
        {
            get { return lastLoadCaseId; }
            set { lastLoadCaseId = value; }
        }
        private int lastFEMNodeId;
        /// <summary>
        ///  The Id system of the FEM Nodes
        /// </summary>
        public int LastFEMNodeId
        {
            get { return lastFEMNodeId; }
            set { lastFEMNodeId = value; }
        }
        private int lastFEMBarId;
        /// <summary>
        ///  The Id system of the FEM bars
        /// </summary>
        public int LastFEMBarId
        {
            get { return lastFEMBarId; }
            set { lastFEMBarId = value; }
        }
        private List<STRNode> nodes;
        /// <summary>
        /// All the STRNodes defined in the structure
        /// </summary>
        public List<STRNode> Nodes
        {
            get { return nodes; }
            set { nodes = value; }
        }
        private List<STRLine> lines;
        /// <summary>
        /// All the STRLines defined in the structure
        /// </summary>
        public List<STRLine> Lines
        {
            get { return lines; }
            set { lines = value; }
        }
        private List<STRRelease> releases;
        /// <summary>
        /// All releases defined in the structure
        /// </summary>
        public List<STRRelease> Releases
        {
            get { return releases; }
            set { releases = value; }
        }
        private List<STRSupport> supports;
        /// <summary>
        /// All supports defined in the structure
        /// </summary>
        public List<STRSupport> Supports
        {
            get { return supports; }
            set { supports = value; }
        }
        private List<STRSection> sections;
        /// <summary>
        /// All sections defined in the structure
        /// </summary>
        public List<STRSection> Sections
        {
            get { return sections; }
            set { sections = value; }
        }
        private List<STRMaterial> materials;
        /// <summary>
        /// All materials defined in the structure
        /// </summary>
        public List<STRMaterial> Materials
        {
            get { return materials; }
            set { materials = value; }
        }
        private List<STRLoadCase> loadCases;
        /// <summary>
        /// All load cases defined in the structure
        /// </summary>
        public List<STRLoadCase> LoadCases
        {
            get { return loadCases; }
            set { loadCases = value; }
        }
        private List<STRLoad> loads;
        /// <summary>
        /// All loads that are defined on the structure
        /// </summary>
        public List<STRLoad> Loads
        {
            get { return loads; }
            set { loads = value; }
        }
        private List<FEMNode> fEMNodes;
        /// <summary>
        /// A list of all defined FEM nodes in the structure
        /// </summary>
        public List<FEMNode> FEMNodes
        {
            get { return fEMNodes; }
            set { fEMNodes = value; }
        }
        private List<FEMBar> fEMBars;
        /// <summary>
        /// A list of all defined FEM bars in the structure
        /// </summary>
        public List<FEMBar> FEMBars
        {
            get { return fEMBars; }
            set { fEMBars = value; }
        }
        internal STRStructure()
        {
            // Only the STRController has access to the id system
            lastLineId = 0;
            lastNodeId = 0;
            lastReleaseId = 0;
            lastSectionId = 0;
            lastMaterialId = 0;
            lastSupportId = 0;
            lastLoadCaseId = 0;
            lastLoadId = 0;
            lastFEMNodeId = 0;
            lastFEMBarId = 0;
            nodes = new List<STRNode>();
            lines = new List<STRLine>();
            sections = new List<STRSection>();
            materials = new List<STRMaterial>();
            releases = new List<STRRelease>();
            supports = new List<STRSupport>();
            loadCases = new List<STRLoadCase>();
            loads = new List<STRLoad>();
            fEMNodes = new List<FEMNode>();
            fEMBars = new List<FEMBar>();
        }

        public override string ToString()
        {
            string output = "";
            output += "STRStructure\n\n";
            output += "\nNodes:\n";
            foreach (STRNode node in nodes)
                output += node.ToString() + "\n";
            output += "\nLines:\n";
            foreach (STRLine line in lines)
                output += line.ToString() + "\n";
            output += "\nMaterials:\n";
            foreach (STRMaterial material in materials)
                output += material.ToString() + "\n";
            output += "\nReleases:\n";
            foreach (STRRelease release in releases)
                output += release.ToString() + "\n";
            output += "\nSupports:\n";
            foreach (STRSupport support in supports)
                output += support.ToString() + "\n";
            output += "\nSections:\n";
            foreach (STRSection section in sections)
                output += section.ToString() + "\n";
            output += "\nLoadCases:\n";
            foreach (STRLoadCase loadCase in loadCases)
                output += loadCase.ToString() + "\n";
            output += "\nLoads:\n";
            foreach (STRLoad load in loads)
            {
                if (load is STRLoadNodal)
                {
                    output += (load as STRLoadNodal).ToString() + "\n";
                }
                else if (load is STRLoadLinearConcentrated)
                {
                    output += (load as STRLoadLinearConcentrated).ToString() + "\n";
                }
                else if (load is STRLoadLinearDistributed)
                {
                    output += (load as STRLoadLinearDistributed).ToString() + "\n";
                }
                else
                {
                    output += load.ToString() + "\n";
                }
            }

            output += "=======================================================================\n";
            return output;
        }
    }
}
