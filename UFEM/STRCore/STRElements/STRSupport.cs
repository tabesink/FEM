using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STRCore.STRElements
{
    public class STRSupport
    {
        private int id;
        /// <summary>
        /// Id of support
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string name;
        /// <summary>
        /// Name of support
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private double kUx;
        /// <summary>
        /// Linear spring support in x
        /// </summary>
        public double KUx
        {
            get { return kUx; }
            set { kUx = value; }
        }

        private double kUy;
        /// <summary>
        /// Linear spring support in y
        /// </summary>
        public double KUy
        {
            get { return kUy; }
            set { kUy = value; }
        }

        private double kUz;
        /// <summary>
        /// Linear spring support in y
        /// </summary>
        public double KUz
        {
            get { return kUz; }
            set { kUz = value; }
        }


        private double kRx;
        /// <summary>
        /// Rotational spring support around global x
        /// </summary>
        public double KRx
        {
            get { return kRx; }
            set { kRx = value; }
        }

        private double kRy;
        /// <summary>
        /// Rotational spring support around global y
        /// </summary>
        public double KRy
        {
            get { return kRy; }
            set { kRy = value; }
        }

        private double kRz;
        /// <summary>
        /// Rotational spring support around global z
        /// </summary>
        public double KRz
        {
            get { return kRz; }
            set { kRz = value; }
        }

        private double ux;
        /// <summary>
        /// Ux of support
        /// </summary>
        public double Ux
        {
            get { return ux; }
            set { ux = value; }
        }

        private double uy;
        /// <summary>
        /// Uy of support
        /// </summary>
        public double Uy
        {
            get { return uy; }
            set { uy = value; }
        }

        private double uz;
        /// <summary>
        /// Uz of support
        /// </summary>
        public double Uz
        {
            get { return uz; }
            set { uz = value; }
        }

        private double rx;
        /// <summary>
        /// Rx of support
        /// </summary>
        public double Rx
        {
            get { return rx; }
            set { rx = value; }
        }

        private double ry;
        /// <summary>
        /// Ry of support
        /// </summary>
        public double Ry
        {
            get { return ry; }
            set { ry = value; }
        }

        private double rz;
        /// <summary>
        /// Rz of support
        /// </summary>
        public double Rz
        {
            get { return rz; }
            set { rz = value; }
        }

        private bool isUxActive;
        public bool IsUxActive
        {
            get { return isUxActive; }
            set { isUxActive = value; }
        }

        private bool isUyActive;
        public bool IsUyActive
        {
            get { return isUyActive; }
            set { isUyActive = value; }
        }

        private bool isUzActive;
        public bool IsUzActive
        {
            get { return isUzActive; }
            set { isUzActive = value; }
        }

        private bool isRxActive;
        public bool IsRxActive
        {
            get { return isRxActive; }
            set { isRxActive = value; }
        }

        private bool isRyActive;
        public bool IsRyActive
        {
            get { return isRyActive; }
            set { isRyActive = value; }
        }

        private bool isRzActive;
        public bool IsRzActive
        {
            get { return isRzActive; }
            set { isRzActive = value; }
        }

        internal STRSupport(int id, string name, bool isUxActive, bool isUyActive, bool isUzActive, bool isRxActive, bool isRyActive, bool isRzActive)
        {
            this.id = id;
            this.name = name;
            this.isUxActive = isUxActive;
            this.isUyActive = isUyActive;
            this.isUzActive = isUzActive;
            this.isRxActive = isRxActive;
            this.isRyActive = isRyActive;
            this.isRzActive = isRzActive;
            Referesh();

            if (isUxActive)
                kUx = Global.Constants.RigidKU;
            else
                kUx = Global.Constants.FreeKU;

            if (isUyActive)
                kUy = Global.Constants.RigidKU;
            else
                kUy = Global.Constants.FreeKU;

            if (isUzActive)
                kUz = Global.Constants.RigidKU;
            else
                kUz = Global.Constants.FreeKU;


            if (isRxActive)
                kRx = Global.Constants.RigidKR;
            else
                kRx = Global.Constants.FreeRU;

            if (isRyActive)
                kRy = Global.Constants.RigidKR;
            else
                kRy = Global.Constants.FreeRU;

            if (isRzActive)
                kRz = Global.Constants.RigidKR;
            else
                kRz = Global.Constants.FreeRU;
        }

        internal void Referesh()
        {
            if (isUxActive)
                kUx = Global.Constants.RigidKU;
            else
                kUx = Global.Constants.FreeKU;

            if (isUyActive)
                kUy = Global.Constants.RigidKU;
            else
                kUy = Global.Constants.FreeKU;

            if (isUzActive)
                kUz = Global.Constants.RigidKU;
            else
                kUz = Global.Constants.FreeKU;


            if (isRxActive)
                kRx = Global.Constants.RigidKR;
            else
                kRx = Global.Constants.FreeRU;

            if (isRyActive)
                kRy = Global.Constants.RigidKR;
            else
                kRy = Global.Constants.FreeRU;

            if (isRzActive)
                kRz = Global.Constants.RigidKR;
            else
                kRz = Global.Constants.FreeRU;
        }

        public override string ToString()
        {
            string output = "";
            output += "STRSupport#" + id + " (" + name + ") ";
            output += isUxActive ? "Y" : "N";
            output += isUyActive ? "Y" : "N";
            output += isUzActive ? "Y" : "N";
            output += isRxActive ? "Y" : "N";
            output += isRyActive ? "Y" : "N";
            output += isRzActive ? "Y" : "N";
            return output;
        }
    }
}
