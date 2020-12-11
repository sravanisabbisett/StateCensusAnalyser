using System;
using System.Collections.Generic;
using System.Text;

namespace StateCensusAnalyser.POCO
{
    public class StateCodeDAO
    {
        public int serialNumber;
        public string stateName;
        public int tin;
        public string stateCode;

        /// <summary>
        /// Initializes a new instance of the <see cref="StateCodeDAO"/> class.
        /// </summary>
        /// <param name="serialNumber">The serial number.</param>
        /// <param name="stateName">Name of the state.</param>
        /// <param name="tin">The tin.</param>
        /// <param name="stateCode">The state code.</param>
        public StateCodeDAO(string serialNumber,string stateName,string tin,string stateCode)
        {
            this.serialNumber = Convert.ToInt32(serialNumber);
            this.stateName = stateName;
            this.tin = Convert.ToInt32(tin);
            this.stateCode = stateCode;
        }
    }
}
