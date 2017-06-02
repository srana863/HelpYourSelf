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
    public class UserDetailsRepository : DataCommon, IUserDetailsRepository
    {
        public UserDetailsRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Create(UserDetails model)
        {
            var query = CRUD<UserDetails>.Insert();
            return _dbContext._connection.Query<int>(query, model).Single();
        }
        public int Delete(long SL)
        {
            var query = CRUD<UserDetails>.Delete(o => o.SL == o.SL);
            return _dbContext._connection.Query<int>(query, new { SL = SL }).Single();

        }
        public int Delete(int SL)
        {
            throw new NotImplementedException();
        }

        public UserDetails Get(int SL)
        {
            throw new NotImplementedException();
        }
        public UserDetails Get(long SL)
        {
            var query = CRUD<UserDetails>.Select(o => o.SL == o.SL);
            return _dbContext._connection.Query<UserDetails>(query, new { SL = SL }).FirstOrDefault();
        }

        public IEnumerable<UserDetails> GetAll()
        {
            var query = CRUD<UserDetails>.Select();
            return _dbContext._connection.Query<UserDetails>(query);
        }

        public int Update(UserDetails model)
        {
            var query = CRUD<UserDetails>.Update(o => o.SL == o.SL);
            return _dbContext._connection.Query<int>(query, model).Single();
        }
    }
}
