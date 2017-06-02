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

namespace Layer.Data.DLL
{
    public class RoleWisePermissionRepository : DataCommon, IRoleWisePermissionRepository
    {
        public RoleWisePermissionRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Create(RoleWisePermission model)
        {
            var query = CRUD<RoleWisePermission>.Insert();
            return _dbContext._connection.Query<int>(query, model).Single();
        }
        public int Delete(long SL)
        {
            var query = CRUD<RoleWisePermission>.Delete(o => o.SL == o.SL);
            return _dbContext._connection.Query<int>(query, new { SL = SL }).Single();
        }
        public int Delete(int SL)
        {
            throw new NotImplementedException();
        }

        public RoleWisePermission Get(int SL)
        {
            throw new NotImplementedException();
        }
        public RoleWisePermission Get(long SL)
        {
            var query = CRUD<RoleWisePermission>.Select(o => o.SL == o.SL);
            return _dbContext._connection.Query<RoleWisePermission>(query, new { SL = SL }).FirstOrDefault();
        }

        public IEnumerable<RoleWisePermission> GetAll()
        {
            var query = CRUD<RoleWisePermission>.Select();
            return _dbContext._connection.Query<RoleWisePermission>(query);
        }

        public int Update(RoleWisePermission model)
        {
            var query = CRUD<RoleWisePermission>.Update(o => o.SL == o.SL);
            return _dbContext._connection.Query<int>(query, model).Single();
        }
    }
}
