using Dapper;
using Layer.Data.Common;
using Layer.Data.Interfaces;
using Layer.Model.Common;
using Layer.Model.Model.Security;
using QueryGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Data.DLL.Security
{
    public class ScreenRepository : DataCommon, IScreenRepository
    {
        public ScreenRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Create(Screen model)
        {
            var query = CRUD<Screen>.Insert();
            return _dbContext._connection.Query<int>(query, model).Single();
        }
        public int Delete(long SL)
        {
            var query = CRUD<Screen>.Delete(o => o.SL == o.SL);
            return _dbContext._connection.Query<int>(query, new { SL = SL }).Single();
        }
        public int Delete(int SL)
        {
            throw new NotImplementedException();
        }

        public Screen Get(int SL)
        {
            throw new NotImplementedException();
        }
        public Screen Get(long SL)
        {
            var query = CRUD<Screen>.Select(o => o.SL == o.SL);
            return _dbContext._connection.Query<Screen>(query, new { SL = SL }).FirstOrDefault();
        }

        public IEnumerable<Screen> GetAll()
        {
            var query = CRUD<Screen>.Select();
            return _dbContext._connection.Query<Screen>(query);
        }

        public int Update(Screen model)
        {
            var query = CRUD<Screen>.Update(o => o.SL == o.SL);
            return _dbContext._connection.Query<int>(query, model).Single();
        }
    }
}
