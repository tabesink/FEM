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

            Console.WriteLine(STRController.CurrentController);

            STRController.CurrentController.ModifySTRNode(node1, node1.X, node1.Y, node1.Z, fix);
            Console.WriteLine(STRController.CurrentController);

            Console.ReadKey();
        }
    }
}
