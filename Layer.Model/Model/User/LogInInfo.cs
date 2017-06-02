using QueryGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Model.Model.User
{
    [Table("LogInInfo", "User")]
    public partial class LogInInfo
    {
        [PKey]
        public long SL { get; set; }
        public long UserId { get; set; }
        public string Password { get; set; }
        public System.DateTime LastLogInDate { get; set; }

        public virtual Users User { get; set; }
    }
}
