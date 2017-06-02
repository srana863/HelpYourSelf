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
    public class ReplyRepository : DataCommon, IReplyRepository
    {
        public ReplyRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Create(Reply model)
        {
            var query = CRUD<Reply>.Insert();
            return _dbContext._connection.Query<int>(query, model).Single();
        }
        public int Delete(long ReplyId)
        {
            var query = CRUD<Reply>.Delete(o => o.ReplyId == o.ReplyId);
            return _dbContext._connection.Query<int>(query, new { ReplyId = ReplyId }).Single();

        }
        public int Delete(int ReplyId)
        {
            throw new NotImplementedException();
        }

        public Reply Get(int ReplyId)
        {
            throw new NotImplementedException();
        }
        public Reply Get(long ReplyId)
        {
            var query = CRUD<Reply>.Select(o => o.ReplyId == o.ReplyId);
            return _dbContext._connection.Query<Reply>(query, new { ReplyId = ReplyId }).FirstOrDefault();
        }

        public IEnumerable<Reply> GetAll()
        {
            var query = CRUD<Reply>.Select();
            return _dbContext._connection.Query<Reply>(query);
        }

        public int Update(Reply model)
        {
            var query = CRUD<Reply>.Update(o => o.ReplyId == o.ReplyId);
            return _dbContext._connection.Query<int>(query, model).Single();
        }
    }
}
