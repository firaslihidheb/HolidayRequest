using HolidaysManagement_API.Dtos;
using HolidaysManagement_API.Models;
using HolidaysManagement_API.Repositories.IRepositories;
using HolidaysManagement_API.Services.IServices;

namespace HolidaysManagement_API.Services
{
    public class FunctionService : IFunctionService
    {
        private readonly IFunctionRepository _functionRepository;

        public FunctionService(IFunctionRepository functionRepository)
        {
            _functionRepository = functionRepository;
        }

        public FunctionDto GetFunctionById(int id)
        {
            var function = _functionRepository.GetFunctionById(id);
            if (function == null)
            {
                return null;
            }

            return MapToFunctionDTO(function);
        }

        public IEnumerable<FunctionDto> GetAllFunctions()
        {
            var functions = _functionRepository.GetAllFunctions();
            return functions.Select(function => MapToFunctionDTO(function));
        }

        public void CreateFunction(FunctionDto functionDTO)
        {
            var function = MapToFunction(functionDTO);
            _functionRepository.CreateFunction(function);
        }

        public void UpdateFunction(int id, FunctionDto functionDTO)
        {
            var existingFunction = _functionRepository.GetFunctionById(id);

            if (existingFunction == null)
            {
                throw new NotFoundException($"Function with ID {id} not found.");
            }

            // Update the properties of the existing function
            existingFunction.FunctionName = functionDTO.FunctionName;
            existingFunction.Description = functionDTO.Description;

            _functionRepository.UpdateFunction(existingFunction);
        }

        public void DeleteFunction(int id)
        {
            var function = _functionRepository.GetFunctionById(id);
            if (function == null)
            {
                throw new NotFoundException($"Function with ID {id} not found.");
            }

            _functionRepository.DeleteFunction(function.FunctionId);
        }

        private Function MapToFunction(FunctionDto functionDTO)
        {
            var function = new Function
            {
                FunctionId = functionDTO.FunctionId,
                FunctionName = functionDTO.FunctionName,
                Description = functionDTO.Description
            };

            // Additional mapping logic or data retrieval if needed

            return function;
        }

        private FunctionDto MapToFunctionDTO(Function function)
        {
            var functionDTO = new FunctionDto
            {
                FunctionId = function.FunctionId,
                FunctionName = function.FunctionName,
                Description = function.Description
            };

            // Additional mapping logic if needed

            return functionDTO;
        }
    }

}
