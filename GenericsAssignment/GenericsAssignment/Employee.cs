using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsAssignment
{
    internal class Employee<T>
    {
        public List<T> things { get; set; }     //Assigning a parameter with a generic data type
    }
}
