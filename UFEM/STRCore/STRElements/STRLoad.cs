using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STRCore.STRElements
{
    public class STRLoad
    {
        private int id;
        // the load Id
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private STRLoadCase loadCase;
        // the load case under which this load is applied
        public STRLoadCase LoadCase
        {
            get { return loadCase; }
            set { loadCase = value; }
        }

        private List<int> appliedOnIds;
        // the ids of the memebers upon which the load is applied 
        public List<int> AppliedOnIds
        {
            get { return appliedOnIds; }
            set { appliedOnIds = value; }
        }

        // instatiate only using the controller
        internal STRLoad(int id, STRLoadCase loadCase, List<int> appliedOnIds)
        {
            this.id = id;
            this.loadCase = loadCase;
            this.appliedOnIds = new List<int>();
            foreach (int appliedOnId in appliedOnIds)
                this.appliedOnIds.Add(appliedOnId);
            this.appliedOnIds = appliedOnIds;
        }
        public override string ToString()
        {
            return "STRLoad#" + id;
        }

    }
}
