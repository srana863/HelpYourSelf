using Layer.Model.Model.User;
using QueryGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Model.Model.Tutorial
{
    [Table("Comment", "Tutorial")]
    public partial class Comment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Comment()
        {
            this.Replies = new HashSet<Reply>();
        }

        [PKey]
        public long CommentId { get; set; }
        public long TutorialId { get; set; }
        public long UserId { get; set; }
        public string CommentString { get; set; }
        public bool IsActive { get; set; }
        public System.DateTime AddedDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }

        public virtual Tutorials Tutorial { get; set; }
        public virtual Users User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reply> Replies { get; set; }
    }
}
