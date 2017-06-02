using Layer.Model.Model.User;
using QueryGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Model.Model.Security
{
    [Table("RoleWisePermission", "Security")]
    public partial class RoleWisePermission
    {
        [PKey]
        public long SL { get; set; }
        public string ScreenCode { get; set; }
        public int RoleId { get; set; }
        public bool CanSave { get; set; }
        public bool CanDelete { get; set; }
        public bool CanSee { get; set; }

        public virtual UserRole UserRole { get; set; }
    }
}
