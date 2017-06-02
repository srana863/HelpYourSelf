using System.Collections.Generic;

namespace Layer.Data.Common
{
    public interface ICommonDataMethods<TEntity>
    {
        int Create(TEntity model);
        int Update(TEntity model);
        int Delete(int id);
        int Delete(long id);
        IEnumerable<TEntity> GetAll();
        TEntity Get(int id);
        TEntity Get(long id);
    }
}
