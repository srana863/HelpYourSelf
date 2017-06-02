using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Layer.Model.Model.User;
using QueryGenerator;

namespace Layer.Model.Model.Tutorial
{
    [Table("UserWiseRating", "Tutorial")]
    public partial class UserWiseRating
    {
        [PKey]
        public long SL { get; set; }
        public long TutorialId { get; set; }
        public long UserId { get; set; }
        public Nullable<decimal> RatingGiven { get; set; }
        public Nullable<bool> Liked { get; set; }
        public Nullable<bool> Worked { get; set; }
        public int Viewed { get; set; }
        public System.DateTime AddedDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }

        public virtual Tutorials Tutorial { get; set; }
        public virtual Users User { get; set; }
    }
}
