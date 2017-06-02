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
    public class LogInInfoRepository : DataCommon, ILogInInfoRepository
    {
        public LogInInfoRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Create(LogInInfo model)
        {
            var query = CRUD<LogInInfo>.Insert();
            return _dbContext._connection.Query<int>(query, model).Single();
        }
        public int Delete(long SL)
        {
            var query = CRUD<LogInInfo>.Delete(o => o.SL == o.SL);
            return _dbContext._connection.Query<int>(query, new { SL = SL }).Single();

        }
        public int Delete(int SL)
        {
            throw new NotImplementedException();
        }

        public LogInInfo Get(int SL)
        {
            throw new NotImplementedException();
        }
        public LogInInfo Get(long SL)
        {
            var query = CRUD<LogInInfo>.Select(o => o.SL == o.SL);
            return _dbContext._connection.Query<LogInInfo>(query, new { SL = SL }).FirstOrDefault();
        }

        public IEnumerable<LogInInfo> GetAll()
        {
            var query = CRUD<LogInInfo>.Select();
            return _dbContext._connection.Query<LogInInfo>(query);
        }

        public int Update(LogInInfo model)
        {
            var query = CRUD<LogInInfo>.Update(o => o.SL == o.SL);
            return _dbContext._connection.Query<int>(query, model).Single();
        }
    }
}
