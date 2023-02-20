using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdditionalFeatures
{
    internal class AdditionalFeaturesAssignment
    {
        public AdditionalFeaturesAssignment(string name) : this(name, "City unknown") { }       //Chaining a second construct that inherits from the first
        public AdditionalFeaturesAssignment(string name, string city)       //Creating a construct of the class that takes in 2 parameters
        {
            myName = name;
            myCity = city;
        }

        public string myName { get; set; }
        public string myCity { get; set; }
    }
}
