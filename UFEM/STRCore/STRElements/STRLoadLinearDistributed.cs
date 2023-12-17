using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STRCore.STRElements
{
    public class STRLoadLinearDistributed:STRLoad
    {
        private double fx1;
        /// <summary>
        /// Fx1
        /// </summary>
        public double Fx1
        {
            get { return fx1; }
            set { fx1 = value; }
        }
        private double fy1;
        /// <summary>
        /// Fy1
        /// </summary>
        public double Fy1
        {
            get { return fy1; }
            set { fy1 = value; }
        }
        private double fz1;
        /// <summary>
        /// Fz1
        /// </summary>
        public double Fz1
        {
            get { return fz1; }
            set { fz1 = value; }
        }
        private double mx1;
        /// <summary>
        /// Mx1
        /// </summary>
        public double Mx1
        {
            get { return mx1; }
            set { mx1 = value; }
        }
        private double my1;
        /// <summary>
        /// My1
        /// </summary>
        public double My1
        {
            get { return my1; }
            set { my1 = value; }
        }
        private double mz1;
        /// <summary>
        /// Mz1
        /// </summary>
        public double Mz1
        {
            get { return mz1; }
            set { mz1 = value; }
        }
        private double relativeLocation1;
        /// <summary>
        /// Relative location (1) of the start load from the start w.r.t its length 
        /// 0 is start
        /// 1 is end 
        /// 0.5 is mid point
        /// </summary>
        public double RelativeLocation1
        {
            get { return relativeLocation1; }
            set { relativeLocation1 = value; }
        }
        private double fx2;
        /// <summary>
        /// Fx2
        /// </summary>
        public double Fx2
        {
            get { return fx2; }
            set { fx2 = value; }
        }
        private double fy2;
        /// <summary>
        /// Fy2
        /// </summary>
        public double Fy2
        {
            get { return fy2; }
            set { fy2 = value; }
        }
        private double fz2;
        /// <summary>
        /// Fz2
        /// </summary>
        public double Fz2
        {
            get { return fz2; }
            set { fz2 = value; }
        }
        private double mx2;
        /// <summary>
        /// Mx2
        /// </summary>
        public double Mx2
        {
            get { return mx2; }
            set { mx2 = value; }
        }
        private double my2;
        /// <summary>
        /// My2
        /// </summary>
        public double My2
        {
            get { return my2; }
            set { my2 = value; }
        }
        private double mz2;
        /// <summary>
        /// Mz2
        /// </summary>
        public double Mz2
        {
            get { return mz2; }
            set { mz2 = value; }
        }
        private double relativeLocation2;
        /// <summary>
        /// Relative location (2) at the end of dist. 
        /// </summary>
        public double RelativeLocation2
        {
            get { return relativeLocation2; }
            set { relativeLocation2 = value; }
        }
        internal STRLoadLinearDistributed(int id, STRLoadCase loadCase, List<int> appliedOnIds, 
            double fx1, double fy1, double fz1, double mx1, double my1, double mz1, double relLoc1,
            double fx2, double fy2, double fz2, double mx2, double my2, double mz2, double relLoc2) 
            : base(id, loadCase, appliedOnIds)
        {
            this.fx1 = fx1;
            this.fy1 = fy1;
            this.fz1 = fz1;
            this.mx1 = mx1;
            this.my1 = my1;
            this.mz1 = mz1;
            this.fx2 = fx2;
            this.fy2 = fy2;
            this.fz2 = fz2;
            this.mx2 = mx2;
            this.my2 = my2;
            this.mz2 = mz2;
            this.relativeLocation1 = relLoc1;
            this.relativeLocation2 = relLoc2;
        }
        public override string ToString()
        {
            return "STRLoadLinearDistributed#" + Id + " (" + LoadCase.ToString() + ")" + "\n" +
                "Fx1 = " + fx1.ToString("0.00") + "\n" +
                "Fy1 = " + fy1.ToString("0.00") + "\n" +
                "Fz1 = " + fz1.ToString("0.00") + "\n" +
                "Mx1 = " + mx1.ToString("0.00") + "\n" +
                "My1 = " + my1.ToString("0.00") + "\n" +
                "Mz1 = " + mz1.ToString("0.00") + "\n" +
                "RelLoc1 = " + relativeLocation1.ToString("0.00") + "\n" +
                "Fx2 = " + fx2.ToString("0.00") + "\n" +
                "Fy2 = " + fy2.ToString("0.00") + "\n" +
                "Fz2 = " + fz2.ToString("0.00") + "\n" +
                "Mx2 = " + mx2.ToString("0.00") + "\n" +
                "My2 = " + my2.ToString("0.00") + "\n" +
                "Mz2 = " + mz2.ToString("0.00") + "\n" +
                "RelLoc2 = " + relativeLocation2.ToString("0.00");
        }
    }
}
