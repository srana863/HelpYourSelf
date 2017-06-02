using Layer.Business.Common;
using Layer.Business.Interfaces;
using Layer.Data.DLL;
using Layer.Data.DLL.User;
using Layer.Data.Interfaces;
using Layer.Model.Common;
using System;
using System.Collections.Generic;
using System.Transactions;
using Layer.Model.Model.Security;

namespace Layer.Business.BAL.Security
{
    public class RoleWisePermissionManager : BllCommon, IRoleWisePermissionManager
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IRoleWisePermissionRepository _roleWisePermissionRepository;
        public RoleWisePermissionManager()
        {
            _usersRepository = new UsersRepository(_dbContext);
            _roleWisePermissionRepository = new RoleWisePermissionRepository(_dbContext);
        }
        public RoleWisePermission Get(int id)
        {
            if (id <= 0)
                return null;
            try
            {
                _dbContext.Open();
                return _roleWisePermissionRepository.Get(id);

            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                _dbContext.Close();
            }
        }

        public ReturnMessage Save(RoleWisePermission admin, AppSession appSession)
        {
            using (var transactionScope = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                try
                {
                    _dbContext.Open();


                    transactionScope.Complete();
                    transactionScope.Dispose();
                    return _vmReturn;
                }
                catch
                {
                    transactionScope.Dispose();
                    return _vmReturn;
                }
                finally
                {
                    _dbContext.Close();
                }
            }

        }

        public IEnumerable<RoleWisePermission> GetAll()
        {
            try
            {
                _dbContext.Open();
                return _roleWisePermissionRepository.GetAll();
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                _dbContext.Close();
            }
        }

        public ReturnMessage Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
