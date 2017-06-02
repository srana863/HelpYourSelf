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
    public class CommentRepository : DataCommon, ICommentRepository
    {
        public CommentRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Create(Comment model)
        {
            var query = CRUD<Comment>.Insert();
            return _dbContext._connection.Query<int>(query, model).Single();
        }
        public int Delete(long CommentId)
        {
            var query = CRUD<Comment>.Delete(o => o.CommentId == o.CommentId);
            return _dbContext._connection.Query<int>(query, new { CommentId = CommentId }).Single();
            
        }
        public int Delete(int CommentId)
        {
            throw new NotImplementedException();
        }

        public Comment Get(int CommentId)
        {
            throw new NotImplementedException();
        }
        public Comment Get(long CommentId)
        {
            var query = CRUD<Comment>.Select(o => o.CommentId == o.CommentId);
            return _dbContext._connection.Query<Comment>(query, new { CommentId = CommentId }).FirstOrDefault();
        }

        public IEnumerable<Comment> GetAll()
        {
            var query = CRUD<Comment>.Select();
            return _dbContext._connection.Query<Comment>(query);
        }

        public int Update(Comment model)
        {
            var query = CRUD<Comment>.Update(o => o.CommentId == o.CommentId);
            return _dbContext._connection.Query<int>(query, model).Single();
        }
    }
}
