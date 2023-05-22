using HolidaysManagement_API.Data;
using HolidaysManagement_API.Models;
using HolidaysManagement_API.Repositories.IRepositories;

namespace HolidaysManagement_API.Repositories
{
    public class FunctionRepository : IFunctionRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public FunctionRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Function GetFunctionById(int id)
        {
            return _dbContext.Function.FirstOrDefault(f => f.FunctionId == id);
        }

        public IEnumerable<Function> GetAllFunctions()
        {
            return _dbContext.Function.ToList();
        }

        public void CreateFunction(Function function)
        {
            try
            {
                _dbContext.Function.Add(function);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void UpdateFunction(Function function)
        {
            _dbContext.SaveChanges();
        }

        public void DeleteFunction(int id)
        {
            var function = _dbContext.Function.FirstOrDefault(f => f.FunctionId == id);
            if (function != null)
            {
                _dbContext.Function.Remove(function);
                _dbContext.SaveChanges();
            }
        }
    }

}
