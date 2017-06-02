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
    public class AcitivityRepository : DataCommon, IAcitivityRepository
    {
        public AcitivityRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Create(Acitivity model)
        {
            var query = CRUD<Acitivity>.Insert();
            return _dbContext._connection.Query<int>(query, model).Single();
        }
        public int Delete(long SL)
        {
            var query = CRUD<Acitivity>.Delete(o => o.SL == o.SL);
            return _dbContext._connection.Query<int>(query, new { SL = SL }).Single();

        }
        public int Delete(int SL)
        {
            throw new NotImplementedException();
        }

        public Acitivity Get(int SL)
        {
            throw new NotImplementedException();
        }
        public Acitivity Get(long SL)
        {
            var query = CRUD<Acitivity>.Select(o => o.SL == o.SL);
            return _dbContext._connection.Query<Acitivity>(query, new { SL = SL }).FirstOrDefault();
        }

        public IEnumerable<Acitivity> GetAll()
        {
            var query = CRUD<Acitivity>.Select();
            return _dbContext._connection.Query<Acitivity>(query);
        }

        public int Update(Acitivity model)
        {
            var query = CRUD<Acitivity>.Update(o => o.SL == o.SL);
            return _dbContext._connection.Query<int>(query, model).Single();
        }
    }
}
