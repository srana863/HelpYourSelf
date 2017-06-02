using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Layer.Business.Interfaces;
using Layer.Data.Common;
using Layer.Data.DLL.Tutorial;
using Layer.Data.Interfaces;
using Layer.Model.Model.Tutorial;

namespace Layer.Business.Common
{
    public class CommonBALManager :BllCommon, ICommonBALManager
    {
        private readonly ICategoryRepository _categoryRepository;
        public CommonBALManager()
        {
            _categoryRepository = new CategoryRepository(_dbContext);
        }

        public IEnumerable<Category> GetAllTutorialCategory()
        {
            try
            {
                _dbContext.Open();
                return _categoryRepository.GetAll();
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                _dbContext.Close();
            }
        }
    }
}
