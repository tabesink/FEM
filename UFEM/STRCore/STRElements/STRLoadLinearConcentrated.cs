using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STRCore.STRElements
{
    public class STRLoadLinearConcentrated:STRLoad
    {
        private double fx;
        /// <summary>
        /// Fx
        /// </summary>
        public double Fx
        {
            get { return fx; }
            set { fx = value; }
        }
        private double fy;
        /// <summary>
        /// Fy
        /// </summary>
        public double Fy
        {
            get { return fy; }
            set { fy = value; }
        }
        private double fz;
        /// <summary>
        /// Fz
        /// </summary>
        public double Fz
        {
            get { return fz; }
            set { fz = value; }
        }
        private double mx;
        /// <summary>
        /// Mx
        /// </summary>
        public double Mx
        {
            get { return mx; }
            set { mx = value; }
        }
        private double my;
        /// <summary>
        /// My
        /// </summary>
        public double My
        {
            get { return my; }
            set { my = value; }
        }
        private double mz;
        /// <summary>
        /// Mz
        /// </summary>
        public double Mz
        {
            get { return mz; }
            set { mz = value; }
        }
        private double relativeLocation;
        /// <summary>
        /// Relative location of the load from the start w.r.t its length 
        /// 0 is start
        /// 1 is end 
        /// 0.5 is mid point
        /// </summary>
        public double RelativeLocation
        {
            get { return relativeLocation; }
            set { relativeLocation = value; }
        }
        internal STRLoadLinearConcentrated(int id, STRLoadCase loadCase, List<int> appliedOnIds, double fx, double fy, double fz, double mx, double my, double mz, double relLoc) : base(id, loadCase, appliedOnIds)
        {
            this.fx = fx;
            this.fy = fy;
            this.fz = fz;
            this.mx = mx;
            this.my = my;
            this.mz = mz;
            this.relativeLocation = relLoc;
        }
        public override string ToString()
        {
            return "STRLoadLinearConcentrated#" + Id + " (" + LoadCase.ToString() + ")" + "\n" +
                "Fx = " + fx.ToString("0.00") + "\n" +
                "Fy = " + fy.ToString("0.00") + "\n" +
                "Fz = " + fz.ToString("0.00") + "\n" +
                "Mx = " + mx.ToString("0.00") + "\n" +
                "My = " + my.ToString("0.00") + "\n" +
                "Mz = " + mz.ToString("0.00") + "\n" +
                "RelLoc = " + relativeLocation.ToString("0.00");
        }
    }
}
