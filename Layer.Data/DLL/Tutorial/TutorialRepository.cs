using Dapper;
using Layer.Data.Common;
using Layer.Model.Common;
using Layer.Model.Model.Tutorial;
using QueryGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Layer.Data.Interfaces;

namespace Layer.Data.DLL.Tutorial
{
    public class TutorialRepository : DataCommon, ITutorialRepository
    {
        public TutorialRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Create(Tutorials model)
        {
            var query = CRUD<Tutorials>.Insert();
            return _dbContext._connection.Query<int>(query, model).Single();
        }

        public int Delete(long tutorialId)
        {
            var query = CRUD<Tutorials>.Delete(o => o.TutorialId == o.TutorialId);
            return _dbContext._connection.Query<int>(query, new { TutorialId = tutorialId }).Single();
           
        }

        public int Delete(int tutorialId)
        {
            throw new NotImplementedException();
        }

        public Tutorials Get(long tutorialId)
        {
            var query = CRUD<Tutorials>.Select(o => o.TutorialId == o.TutorialId);
            return _dbContext._connection.Query<Tutorials>(query, new { TutorialId = tutorialId }).FirstOrDefault();
            
        }

        public IEnumerable<Tutorials> GetAllTutorialByUserId(long userId)
        {
            var query = CRUD<Tutorials>.Select(o => o.UserId == o.UserId);
            return _dbContext._connection.Query<Tutorials>(query, new { UserId = userId });
        }

        public Tutorials Get(int tutorialId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Tutorials> GetAll()
        {
            var query = CRUD<Tutorials>.Select();
            return _dbContext._connection.Query<Tutorials>(query);
        }

        public int Update(Tutorials model)
        {
            var query = CRUD<Tutorials>.Update(o => o.TutorialId == o.TutorialId && o.UserId==o.UserId);
            return _dbContext._connection.Query<int>(query, model).Single();
        }
    }
}
