using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STRCore;
using STRCore.STRElements;

namespace UFEM
{
    class Program
    {
        static void Main(string[] args)
        {
            STRController.Initialize();
            STRMaterial conc = STRController.CurrentController.DefineSTRMaterial("concrete", 20e9);

            STRRelease release1 = STRController.CurrentController.DefineSTRRelease("rl", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

            STRSupport fix = STRController.CurrentController.DefineSTRSupport("fixed", true, true, true, true, true, true);
            STRSection section1 = STRController.CurrentController.DefineSTRSection("Sec1", 0.15, 0.02, 0.02, 0.02);

            STRNode node1 = STRController.CurrentController.DefineSTRNode(0, 0, 0);
            STRNode node2 = STRController.CurrentController.DefineSTRNode(5, 0, 0);
            STRNode node3 = STRController.CurrentController.DefineSTRNode(0, 0, 0);

            STRLine line1 = STRController.CurrentController.DefineSTRLine(node1, node2);
            STRLine line2 = STRController.CurrentController.DefineSTRLine(node1, node2);
            STRLine line3 = STRController.CurrentController.DefineSTRLine(node2, node1);

            STRLoadCase dl1 = STRController.CurrentController.DefineSTRLoadCase("dead load", Global.Enums.LoadCaseTypes.Dead);
            STRLoadCombination uls1 = STRController.CurrentController.DefineSTRCombinationCase("ULS", Global.Enums.LoadCombinationTypes.ULS);

            STRLoadCase wind = STRController.CurrentController.DefineSTRLoadCase("live load", Global.Enums.LoadCaseTypes.Live);
            Console.WriteLine(STRController.CurrentController);

            List<int> appliedOnIds = new List<int>();
            appliedOnIds.Add(-1);
            STRLoad load1 = STRController.CurrentController.DefineSTRLoad(dl1, appliedOnIds);
            STRLoadNodal nodalLoad1 = STRController.CurrentController.DefineSTRLoadNodal(dl1, appliedOnIds, 5, 0,0,0,0,0);
            STRLoadLinearConcentrated linearConcentratedLoad1 = STRController.CurrentController.DefineSTRLoadLinearConcentrated(dl1, appliedOnIds, 15, 0, 0, 0, 0, 0, 0.5);
            STRLoadLinearDistributed linearDistLoad1 = STRController.CurrentController.DefineSTRLoadLinearDistributed(dl1, appliedOnIds, 
                15, 0, 0, 0, 0, 0, 0.25,
                30, 0, 0, 0, 0, 0, 0.75);
            STRLoadLinearDistributed linearDistLoad2 = STRController.CurrentController.DefineSTRLoadLinearDistributed(dl1, appliedOnIds,
               -15, 0, 0, 0, 0, 0, 0.25,
               -30, 0, 0, 0, 0, 0, 0.75);

            Console.WriteLine(STRController.CurrentController);

            STRController.CurrentController.ModifySTRLoadLinearDistributed(linearDistLoad1, dl1, appliedOnIds,
               25, 0, 0, 0, 0, 0, 0.25,
               50, 0, 0, 0, 0, 0, 0.75);

            STRController.CurrentController.DeleteSTRLoad(linearDistLoad2);
            Console.WriteLine(STRController.CurrentController);

            Console.ReadKey();
        }
    }
}
