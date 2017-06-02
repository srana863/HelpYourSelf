using QueryGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Model.Model.Security
{
    [Table("Screen", "Security")]
    public partial class Screen
    {
        [PKey]
        public long SL { get; set; }
        public string ScreenCode { get; set; }
        public string ScreenName { get; set; }
        public string Url { get; set; }
    }
}
