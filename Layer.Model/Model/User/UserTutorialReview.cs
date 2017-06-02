using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Layer.Model.Model.Tutorial;
using QueryGenerator;

namespace Layer.Model.Model.User
{
    [Table("UserTutorialReview", "User")]
    public partial class UserTutorialReview
    {
        [PKey]
        public long SL { get; set; }
        public long UserId { get; set; }
        public long TutorialId { get; set; }
        public int ViewCount { get; set; }
        public Nullable<decimal> GivenRating { get; set; }
        public Nullable<bool> Liked { get; set; }
        public Nullable<bool> Worked { get; set; }

        public virtual Tutorials Tutorial { get; set; }
        public virtual Users User { get; set; }
    }
}
