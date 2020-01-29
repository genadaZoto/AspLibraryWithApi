using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiSampleConsume.Tools.Models
{
    public class Identifiers
    {
        public List<string> lccn { get; set; }
        public List<string> openlibrary { get; set; }
        public List<string> isbn_10 { get; set; }
        public List<string> oclc { get; set; }
        public List<string> goodreads { get; set; }
        public List<string> project_gutenberg { get; set; }
        public List<string> librarything { get; set; }
    }
}
