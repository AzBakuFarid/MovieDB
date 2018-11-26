using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDB
{
    [Serializable]
    public class Movie
    {

        public string Year { get; set; }
        public Author Author { get; set; }
        public string Title { get; set; }
    }
}
