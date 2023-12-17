using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Global.Enums;

namespace STRCore.STRElements
{
    public class STRLoadCase
    {
        protected int id;
        /// <summary>
        /// Id of load case 
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        protected string name;
        /// <summary>
        /// Name of load case
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private LoadCaseTypes loadCaseType;
        /// <summary>
        /// Load case type 
        /// </summary>
        public LoadCaseTypes LoadCaseType
        {
            get { return loadCaseType; }
            set { loadCaseType = value; }
        }

        internal STRLoadCase(int id, string name, LoadCaseTypes loadCaseType)
        {
            this.id = id;
            this.name = name;
            this.LoadCaseType = loadCaseType; 
        }

        public override string ToString()
        {
            return "STRLoadCase#" + id + " (" + name + ")";
        }

    }
}
