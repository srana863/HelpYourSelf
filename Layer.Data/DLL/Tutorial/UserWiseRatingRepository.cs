using Dapper;
using Layer.Data.Common;
using Layer.Data.Interfaces;
using Layer.Model.Common;
using Layer.Model.Model.Tutorial;
using QueryGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Data.DLL.Tutorial
{
    public class UserWiseRatingRepository : DataCommon, IUserWiseRatingRepository
    {
        public UserWiseRatingRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Create(UserWiseRating model)
        {
            var query = CRUD<UserWiseRating>.Insert();
            return _dbContext._connection.Query<int>(query, model).Single();
        }
        public int Delete(long SL)
        {
            var query = CRUD<UserWiseRating>.Delete(o => o.SL == o.SL);
            return _dbContext._connection.Query<int>(query, new { SL = SL }).Single();

        }
        public int Delete(int SL)
        {
            throw new NotImplementedException();
        }

        public UserWiseRating Get(int SL)
        {
            throw new NotImplementedException();
        }
        public UserWiseRating Get(long SL)
        {
            var query = CRUD<UserWiseRating>.Select(o => o.SL == o.SL);
            return _dbContext._connection.Query<UserWiseRating>(query, new { SL = SL }).FirstOrDefault();
        }

        public IEnumerable<UserWiseRating> GetAll()
        {
            var query = CRUD<UserWiseRating>.Select();
            return _dbContext._connection.Query<UserWiseRating>(query);
        }

        public int Update(UserWiseRating model)
        {
            var query = CRUD<UserWiseRating>.Update(o => o.SL == o.SL);
            return _dbContext._connection.Query<int>(query, model).Single();
        }
    }
}
