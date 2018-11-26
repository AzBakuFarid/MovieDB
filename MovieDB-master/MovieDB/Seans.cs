using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDB
{   [Serializable]
   public class Seans
    {
        public Movie Movie { get; set; }
        public string Day { get; set; }
        public Cinema Cinema { get; set; }
    }
}
