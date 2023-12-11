using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private int lastSupportId;
        /// <summary>
        /// Id system for support
        /// </summary>
        public int LastSupportId
        {
            get { return lastSupportId; }
            set { lastSupportId = value; }
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

        internal STRStructure()
        {
            // Only the STRController has access to the id system
            lastLineId = 0;
            lastNodeId = 0;
            lastReleaseId = 0;
            lastSectionId = 0;
            lastMaterialId = 0;
            lastSupportId = 0;

            nodes = new List<STRNode>();
            lines = new List<STRLine>();
            sections = new List<STRSection>();
            materials = new List<STRMaterial>();
            releases = new List<STRRelease>();
            supports = new List<STRSupport>();
        }

        public override string ToString()
        {
            string output = "";
            output += "STRStructure\n";
            output += "Nodes:\n";
            foreach (STRNode node in nodes)
                output += node.ToString() + "\n";
            output += "Materials:\n";
            foreach (STRMaterial material in materials)
                output += material.ToString() + "\n";
            output += "Releases:\n";
            foreach (STRRelease release in releases)
                output += release.ToString() + "\n";
            output += "Supports:\n";
            foreach (STRSupport support in supports)
                output += support.ToString() + "\n";
            output += "Sections:\n";
            foreach (STRSection section in sections)
                output += section.ToString() + "\n";

            return output;
        }
    }
}
