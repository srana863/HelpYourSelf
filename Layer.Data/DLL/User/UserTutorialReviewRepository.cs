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
    public class UserTutorialReviewRepository : DataCommon, IUserTutorialReviewRepository
    {
        public UserTutorialReviewRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Create(UserTutorialReview model)
        {
            var query = CRUD<UserTutorialReview>.Insert();
            return _dbContext._connection.Query<int>(query, model).Single();
        }
        public int Delete(long SL)
        {
            var query = CRUD<UserTutorialReview>.Delete(o => o.SL == o.SL);
            return _dbContext._connection.Query<int>(query, new { SL = SL }).Single();

        }
        public int Delete(int SL)
        {
            throw new NotImplementedException();
        }

        public UserTutorialReview Get(int SL)
        {
            throw new NotImplementedException();
        }
        public UserTutorialReview Get(long SL)
        {
            var query = CRUD<UserTutorialReview>.Select(o => o.SL == o.SL);
            return _dbContext._connection.Query<UserTutorialReview>(query, new { SL = SL }).FirstOrDefault();
        }

        public IEnumerable<UserTutorialReview> GetAll()
        {
            var query = CRUD<UserTutorialReview>.Select();
            return _dbContext._connection.Query<UserTutorialReview>(query);
        }

        public int Update(UserTutorialReview model)
        {
            var query = CRUD<UserTutorialReview>.Update(o => o.SL == o.SL);
            return _dbContext._connection.Query<int>(query, model).Single();
        }
    }
}
