using HolidaysManagement_API.Models;

namespace HolidaysManagement_API.Repositories.IRepositories
{
    public interface IFunctionRepository
    {
        Function GetFunctionById(int id);
        IEnumerable<Function> GetAllFunctions();
        void CreateFunction(Function function);
        void UpdateFunction(Function function);
        void DeleteFunction(int id);
    }

}
