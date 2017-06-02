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
    public class CategoryRepository : DataCommon, ICategoryRepository
    {
        public CategoryRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Create(Category model)
        {
            var query = CRUD<Category>.Insert();
            return _dbContext._connection.Query<int>(query, model).Single();
        }
        public int Delete(long CategoryId)
        {
            throw new NotImplementedException();
        }
        public int Delete(int CategoryId)
        {
            var query = CRUD<Category>.Delete(o => o.CategoryId == o.CategoryId);
            return _dbContext._connection.Query<int>(query, new { CategoryId = CategoryId }).Single();
        }

        public Category Get(int CategoryId)
        {
            var query = CRUD<Category>.Select(o => o.CategoryId == o.CategoryId);
            return _dbContext._connection.Query<Category>(query, new { CategoryId = CategoryId }).FirstOrDefault();
          
        }
        public Category Get(long CategoryId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetAll()
        {
            var query = CRUD<Category>.Select();
            return _dbContext._connection.Query<Category>(query);
        }

        public int Update(Category model)
        {
            var query = CRUD<Category>.Update(o => o.CategoryId == o.CategoryId);
            return _dbContext._connection.Query<int>(query, model).Single();
        }
    }
}
