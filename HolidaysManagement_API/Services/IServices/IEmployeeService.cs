using HolidaysManagement_API.Dtos;

namespace HolidaysManagement_API.Services.IServices
{
    public interface IEmployeeService
    {
        EmployeeDTO GetEmployeeById(int id);
        IEnumerable<EmployeeDTO> GetAllEmployees();
        void CreateEmployee(EmployeeDTO employeeDTO);
        void UpdateEmployee(int id, EmployeeDTO employeeDTO);
        void DeleteEmployee(int id);
    }
}
