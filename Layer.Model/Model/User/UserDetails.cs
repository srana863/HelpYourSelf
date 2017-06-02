using QueryGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Model.Model.User
{
    [Table("UserDetails", "User")]
    public partial class UserDetails
    {
        [PKey]
        public long SL { get; set; }
        public long UserId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int Sex { get; set; }
        public string PersonalWeb { get; set; }

        public virtual Users User { get; set; }
    }
}
