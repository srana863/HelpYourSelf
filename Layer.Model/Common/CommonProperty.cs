using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Model.Common
{
    public class CommonProperty
    {
        public long AddedBy { get; set; }
        public DateTime AddedDate { get; set; }
        public long UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
