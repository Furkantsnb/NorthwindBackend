using Business.Abstract;
using Core.Utilitis.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    internal class CategoryManager : ICategoryService
    {
        private ICategoryDal _categorydal;
        public CategoryManager(ICategoryDal categorydal)
        {
            _categorydal = categorydal;
        }

        public IDataResult<List<Category>> GetList()
        {
            return new SuccessDataResult<List<Category>>(_categorydal.GetList().ToList());
        }
    }
}
