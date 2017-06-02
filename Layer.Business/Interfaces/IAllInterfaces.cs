using Layer.Business.Common;
using Layer.Model.Model.Security;
using Layer.Model.Model.Tutorial;
using Layer.Model.Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Business.Interfaces
{
    #region Common methods...........

    public interface ICommonBALManager
    {
        IEnumerable<Category> GetAllTutorialCategory();
    }


    #endregion

    #region Tutorial....

    public interface ITutorialManager : ICommonBALMethods<Tutorials>
    {
        IEnumerable<Tutorials> GetAllTutorialByUserId(long UserId);
    }
    #endregion
    #region User....
    public interface IUsersManager : ICommonBALMethods<Users>
    {
    }
    #endregion
    #region Security....
    public interface IRoleWisePermissionManager : ICommonBALMethods<RoleWisePermission>
    {
    }
    public interface IScreenManager : ICommonBALMethods<Screen>
    {
    }
    #endregion
}
