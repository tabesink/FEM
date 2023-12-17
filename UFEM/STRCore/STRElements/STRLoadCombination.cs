using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Global.Enums;

namespace STRCore.STRElements
{
    public class STRLoadCombination : STRLoadCase
    {
        private LoadCombinationTypes loadCombinationType;
        /// <summary>
        /// The nature of combination (ULS SLS ACC)
        /// </summary>
        public LoadCombinationTypes LoadCombinationType
        {
            get { return loadCombinationType; }
            set { loadCombinationType = value; }
        }

        private List<STRLoadCase> loadCases;
        /// <summary>
        /// A list of all cases considered in the load combination
        /// </summary>
        public List<STRLoadCase> LoadCases
        {
            get { return loadCases; }
            set { loadCases = value; }
        }

        private List<double> loadCaseFactors;
        /// <summary>
        /// Factors that are multiplied by the cases considered in the combination 
        /// </summary>
        public List<double> LoadCaseFactors
        {
            get { return loadCaseFactors; }
            set { loadCaseFactors = value; }
        }

        internal STRLoadCombination(int id, string name, LoadCombinationTypes loadCombinationType):base(id, name, LoadCaseTypes.Dead)
        {
            this.loadCombinationType = loadCombinationType;
            loadCases = new List<STRLoadCase>();
            loadCaseFactors = new List<double>();
        }

        public override string ToString()
        {
            return "STRLoadCombination#" + Id + " (" + name + ")";
        }
    }
}
