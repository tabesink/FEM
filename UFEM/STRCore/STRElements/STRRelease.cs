using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STRCore.STRElements
{
    public class STRRelease
    {
        private int id;
        /// <summary>
        /// Identifier of the release
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string name;
        /// <summary>
        /// Unique name for release
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private double kUxStart;
        /// <summary>
        /// Starting spring in x
        /// </summary>
        public double KUxStart
        {
            get { return kUxStart; }
            set { kUxStart = value; }
        }

        private double kUyStart;
        /// <summary>
        /// Starting spring in y
        /// </summary>
        public double KUyStart
        {
            get { return kUyStart; }
            set { kUyStart = value; }
        }

        private double kUzStart;
        /// <summary>
        /// Starting spring in z
        /// </summary>
        public double KUzStart
        {
            get { return kUzStart; }
            set { kUzStart = value; }
        }

        private double kRxStart;
        /// <summary>
        /// Starting spring in rx
        /// </summary>
        public double KRxStart
        {
            get { return kRxStart; }
            set { kRxStart = value; }
        }

        private double kRyStart;
        /// <summary>
        /// Starting spring in ry
        /// </summary>
        public double KRyStart
        {
            get { return kRyStart; }
            set { kRyStart = value; }
        }

        private double kRzStart;
        /// <summary>
        /// Starting spring in rz
        /// </summary>
        public double KRzStart
        {
            get { return kRzStart; }
            set { kRzStart = value; }
        }

        private double kUxEnd;
        /// <summary>
        /// End spring in x
        /// </summary>
        public double KUxEnd
        {
            get { return kUxEnd; }
            set { kUxEnd = value; }
        }

        private double kUyEnd;
        /// <summary>
        /// End spring in y
        /// </summary>
        public double KUyEnd
        {
            get { return kUyEnd; }
            set { kUyEnd = value; }
        }

        private double kUzEnd;
        /// <summary>
        /// End spring in z
        /// </summary>
        public double KUzEnd
        {
            get { return kUzEnd; }
            set { kUzEnd = value; }
        }

        private double kRxEnd;
        /// <summary>
        /// End spring in rx
        /// </summary>
        public double KRxEnd
        {
            get { return kRxEnd; }
            set { kRxEnd = value; }
        }

        private double kRyEnd;
        /// <summary>
        /// End spring in ry
        /// </summary>
        public double KRyEnd
        {
            get { return kRyEnd; }
            set { kRyEnd = value; }
        }

        private double kRzEnd;
        /// <summary>
        /// End spring in rz
        /// </summary>
        public double KRzEnd
        {
            get { return kRzEnd; }
            set { kRzEnd = value; }
        }

        internal STRRelease(int id, string name, double kUxStart, double kUyStart, double kUzStart, double kRxStart, double kRyStart, double kRzStart, double kUxEnd, double kUyEnd, double kUzEnd, double kRxEnd, double kRyEnd, double kRzEnd)
        {
            this.id = id;
            this.name = name;
            this.kUxStart = kUxStart;
            this.kUyStart = kUyStart;
            this.kUzStart = kUzStart;
            this.kRxStart = kRxStart;
            this.kRyStart = kRyStart;
            this.kRzStart = kRzStart;

            this.kUxEnd = kUxEnd;
            this.kUyEnd = kUyEnd;
            this.kUzEnd = kUzEnd;
            this.kRxEnd = kRxEnd;
            this.kRyEnd = kRyEnd;
            this.kRzEnd = kRzEnd;
        }

        public override string ToString()
        {
            return "STRRelease#" + id + " (" + name + ")";
        }
    }
}
