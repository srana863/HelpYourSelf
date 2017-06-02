using Layer.Model.Common;
using Layer.Model.Model.User;
using Layer.Model.ViewModel;
using QueryGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Model.Model.Tutorial
{
    [Table("Tutorials", "Tutorial")]
    public partial class Tutorials: CommonProperty
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tutorials()
        {
            this.Comments = new HashSet<Comment>();
            this.UserTutorialReviews = new HashSet<UserTutorialReview>();
            this.UserWiseRatings = new HashSet<UserWiseRating>();
        }

        [PKey]
        public long TutorialId { get; set; }
        public long UserId { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Meta { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string Description { get; set; }
        public Nullable<long> TotalView { get; set; }
        public Nullable<decimal> AvgRating { get; set; }
        public int TotalRatingGivenCount { get; set; }
        public int TotalLikeCount { get; set; }
        public int TotalWorkedCount { get; set; }
        public Nullable<bool> IsReviewd { get; set; }
        public Nullable<bool> ShowInHomePage { get; set; }

        public virtual Category Category { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserTutorialReview> UserTutorialReviews { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserWiseRating> UserWiseRatings { get; set; }
        public virtual IEnumerable<TutorialMetaViewModel> TutorialMetaViewModel { get; set; }
    }

}
