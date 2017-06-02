using Layer.Model.Model.User;
using QueryGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Model.Model.Tutorial
{
    [Table("Reply", "Tutorial")]
    public partial class Reply
    {
        [PKey]
        public long ReplyId { get; set; }
        public long CommentId { get; set; }
        public long UserId { get; set; }
        public string ReplyString { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public System.DateTime AddedDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }

        public virtual Comment Comment { get; set; }
        public virtual Users User { get; set; }
    }
}
