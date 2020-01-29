using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiSampleConsume.Tools.Models
{
    public class Classifications
    {
        public List<string> dewey_decimal_class { get; set; }
        public List<string> lc_classifications { get; set; }
    }
}
