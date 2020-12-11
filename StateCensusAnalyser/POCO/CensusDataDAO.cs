using System;
using System.Collections.Generic;
using System.Text;

namespace StateCensusAnalyser.POCO
{
    public class CensusDataDAO
    {
        public string state;
        public long population;
        public long area;
        public long density;

        /// <summary>
        /// Initializes a new instance of the <see cref="CensusDataDAO"/> class.
        /// </summary>
        /// <param name="state">The state.</param>
        /// <param name="population">The population.</param>
        /// <param name="area">The area.</param>
        /// <param name="density">The density.</param>
        public CensusDataDAO(string state,string population,string area,string density)
        {
            this.state = state;
            this.population = Convert.ToUInt32(population);
            this.area = Convert.ToUInt32(area);
            this.density = Convert.ToUInt32(density);
        }

    }
}
