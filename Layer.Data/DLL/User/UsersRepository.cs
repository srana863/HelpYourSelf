using Dapper;
using Layer.Data.Common;
using Layer.Data.Interfaces;
using Layer.Model.Common;
using Layer.Model.Model.User;
using QueryGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Data.DLL.User
{
    public class UsersRepository : DataCommon, IUsersRepository
    {
        public UsersRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Create(Users model)
        {
            var query = CRUD<Users>.Insert();
            return _dbContext._connection.Query<int>(query, model).Single();
        }
        public int Delete(long UserId)
        {
            var query = CRUD<Users>.Delete(o => o.UserId == o.UserId);
            return _dbContext._connection.Query<int>(query, new { UserId = UserId }).Single();

        }
        public int Delete(int UserId)
        {
            throw new NotImplementedException();
        }

        public Users Get(int UserId)
        {
            throw new NotImplementedException();
        }
        public Users Get(long UserId)
        {
            var query = CRUD<Users>.Select(o => o.UserId == o.UserId);
            return _dbContext._connection.Query<Users>(query, new { UserId = UserId }).FirstOrDefault();
        }

        public IEnumerable<Users> GetAll()
        {
            var query = CRUD<Users>.Select();
            return _dbContext._connection.Query<Users>(query);
        }

        public int Update(Users model)
        {
            var query = CRUD<Users>.Update(o => o.UserId == o.UserId);
            return _dbContext._connection.Query<int>(query, model).Single();
        }
    }
}
