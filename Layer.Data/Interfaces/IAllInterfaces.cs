using Layer.Data.Common;
using Layer.Model.Model.Security;
using Layer.Model.Model.Tutorial;
using Layer.Model.Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Data.Interfaces
{
    #region Secutiry.....
    public interface IRoleWisePermissionRepository : ICommonDataMethods<RoleWisePermission>
    {
    }
    public interface IScreenRepository : ICommonDataMethods<Screen>
    {
    }
    #endregion
    #region Users.....
    public interface IAcitivityRepository : ICommonDataMethods<Acitivity>
    {
    }
    public interface ILogInInfoRepository : ICommonDataMethods<LogInInfo>
    {
    }
    public interface IUserDetailsRepository : ICommonDataMethods<UserDetails>
    {
    }
    public interface IUsersRepository : ICommonDataMethods<Users>
    {
    }
    public interface IUserRoleRepository : ICommonDataMethods<UserRole>
    {
    }
    public interface IUserTutorialReviewRepository : ICommonDataMethods<UserTutorialReview>
    {
    }
    #endregion
    #region Tutorials.....
    public interface ITutorialRepository : ICommonDataMethods<Tutorials>
    {
        IEnumerable<Tutorials> GetAllTutorialByUserId(long userId);
    }
    public interface ICategoryRepository : ICommonDataMethods<Category>
    {
    }
    public interface ICommentRepository : ICommonDataMethods<Comment>
    {
    }
    public interface IReplyRepository : ICommonDataMethods<Reply>
    {
    }
    public interface IUserWiseRatingRepository : ICommonDataMethods<UserWiseRating>
    {
    }
    #endregion
}
