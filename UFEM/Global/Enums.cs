using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Global
{
    public static class Enums
    {
        public enum LoadCaseTypes
        {
            Dead, 
            Live, 
            Wind, 
            Seismic
        }
        public enum LoadCombinationTypes
        {
            ULS,
            SLS,
            ACC
        }

    }
}
