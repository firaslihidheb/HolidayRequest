using HolidaysManagement_API.Dtos;

namespace HolidaysManagement_API.Services.IServices
{
    public interface IFunctionService
    {
        FunctionDto GetFunctionById(int id);
        IEnumerable<FunctionDto> GetAllFunctions();
        void CreateFunction(FunctionDto functionDTO);
        void UpdateFunction(int id, FunctionDto functionDTO);
        void DeleteFunction(int id);
    }

}
