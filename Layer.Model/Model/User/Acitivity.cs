using QueryGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Model.Model.User
{
    [Table("Acitivity", "User")]
    public partial class Acitivity
    {
        [PKey]
        public long SL { get; set; }
        public long UserId { get; set; }
        public string MetaTag { get; set; }

        public virtual Users User { get; set; }
    }
}
