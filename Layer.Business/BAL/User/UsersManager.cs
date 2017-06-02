using Layer.Business.Common;
using Layer.Business.Interfaces;
using Layer.Data.DLL.Tutorial;
using Layer.Data.DLL.User;
using Layer.Data.Interfaces;
using Layer.Model.Common;
using Layer.Model.Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Layer.Business.BAL.User
{
    public class UsersManager : BllCommon, IUsersManager
    {
        private readonly ITutorialRepository _tutorialRepository;
        private readonly IUsersRepository _usersRepository;
        public UsersManager()
        {
            _tutorialRepository = new TutorialRepository(_dbContext);
            _usersRepository = new UsersRepository(_dbContext);
        }
        public Users Get(int id)
        {
            if (id <= 0)
                return null;
            try
            {
                _dbContext.Open();
                return _usersRepository.Get(id);

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

        public ReturnMessage Save(Users admin, AppSession appSession)
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

        public IEnumerable<Users> GetAll()
        {
            try
            {
                _dbContext.Open();
                return _usersRepository.GetAll();
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
