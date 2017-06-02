
using Layer.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Business.Common
{
    public interface ICommonBALMethods<T> where T : class
    {
        ReturnMessage Save(T entity, AppSession appSession);
        ReturnMessage Delete(int id);
        IEnumerable<T> GetAll();
        T Get(int id);
    }
}
