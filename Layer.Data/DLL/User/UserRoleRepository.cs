using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Data.DLL.User
{
    using Dapper;

    using Layer.Data.Common;
    using Layer.Data.Interfaces;
    using Layer.Model.Common;
    using Layer.Model.Model.User;

    using QueryGenerator;

    public class UserRoleRepository : DataCommon, IUserRoleRepository
    {
        public UserRoleRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Create(UserRole model)
        {
            var query = CRUD<UserRole>.Insert();
            return _dbContext._connection.Query<int>(query, model).Single();
        }
        public int Delete(long UserRoleId)
        {
            var query = CRUD<UserRole>.Delete(o => o.UserRoleId == o.UserRoleId);
            return _dbContext._connection.Query<int>(query, new { UserRoleId = UserRoleId }).Single();

        }
        public int Delete(int UserRoleId)
        {
            throw new NotImplementedException();
        }

        public UserRole Get(int UserRoleId)
        {
            throw new NotImplementedException();
        }
        public UserRole Get(long UserRoleId)
        {
            var query = CRUD<UserRole>.Select(o => o.UserRoleId == o.UserRoleId);
            return _dbContext._connection.Query<UserRole>(query, new { UserRoleId = UserRoleId }).FirstOrDefault();
        }

        public IEnumerable<UserRole> GetAll()
        {
            var query = CRUD<UserRole>.Select();
            return _dbContext._connection.Query<UserRole>(query);
        }

        public int Update(UserRole model)
        {
            var query = CRUD<UserRole>.Update(o => o.UserRoleId == o.UserRoleId);
            return _dbContext._connection.Query<int>(query, model).Single();
        }
    }
}
