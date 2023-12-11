using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STRCore.STRElements
{
    public class STRMaterial
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string name;
        /// <summary>
        /// The name of the material
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        private double elasticModulus;

        public double ElasticModulus
        {
            get { return elasticModulus; }
            set { elasticModulus = value; }
        }

        internal STRMaterial(int id, double elasticModulus, string name)
        {
            this.id = id;
            this.elasticModulus = elasticModulus;
            this.name = name;
        }

        public override string ToString()
        {
            return "STRMaterial#" + id + " ("+name+") " + "E = "+elasticModulus.ToString("0.00e00");
        }

        public STRMaterial DefineSTRMaterial(double elasticModulus, string name)
        {
            return new STRMaterial(id, elasticModulus, name);
        }
    }
}
