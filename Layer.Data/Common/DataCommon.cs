
using Layer.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Data.Common
{
    public class DataCommon
    {
        public DbContext _dbContext;
        public List<Parameter> _inputParameter;
        public List<Parameter> _outputParameter;
        public string _query;
        public Boolean _isSuccess;
        public int _affectedRows;
        public DataCommon()
        {
            _inputParameter = new List<Parameter>();
            _outputParameter = new List<Parameter>();
        }

    }
}
