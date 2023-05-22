using HolidaysManagement_API.Dtos;
using HolidaysManagement_API.Models;
using HolidaysManagement_API.Repositories.IRepositories;
using HolidaysManagement_API.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace HolidaysManagement_API.Services
{


    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public EmployeeDTO GetEmployeeById(int id)
        {
            var employee = _employeeRepository.GetEmployeeById(id);
            if (employee == null)
            {
                return null;
            }

            return MapToEmployeeDTO(employee);
        }

        public IEnumerable<EmployeeDTO> GetAllEmployees()
        {
            var employees = _employeeRepository.GetAllEmployees();
            return employees.Select(employee => MapToEmployeeDTO(employee));
        }

        public void CreateEmployee(EmployeeDTO employeeDTO)
        {
            var employee = MapToEmployee(employeeDTO);
            _employeeRepository.CreateEmployee(employee);
        }



        public void DeleteEmployee(int id)
        {
            var employee = _employeeRepository.GetEmployeeById(id);
            if (employee == null)
            {
                throw new NotFoundException($"Employee with ID {id} not found.");
            }

            _employeeRepository.DeleteEmployee(employee.EmployeeId);
        }







        private Employee MapToEmployee(EmployeeDTO employeeDTO)
        {
            var employee = new Employee
            {
                // Map common properties from User class
                UserId = employeeDTO.EmployeeId,
                Username = employeeDTO.Username,
                Role = employeeDTO.Role,
                FirstName = employeeDTO.FirstName,
                LastName = employeeDTO.LastName,
                PhoneNumber = employeeDTO.PhoneNumber,
                Address = employeeDTO.Address,

                // Map properties specific to Employee class
                EmployeeId = employeeDTO.EmployeeId,
                Name = employeeDTO.Name,
                Email = employeeDTO.Email,
                SupervisorId = employeeDTO.SupervisorId,
                DateOfJoining = employeeDTO.DateOfJoining,
                FunctionId = employeeDTO.FunctionId,
                Status = employeeDTO.Status
            };

            // Additional mapping logic or data retrieval if needed

            return employee;
        }

        private EmployeeDTO MapToEmployeeDTO(Employee employee)
        {
            var employeeDTO = new EmployeeDTO
            {
                // Map common properties from User class
                EmployeeId = employee.UserId,
                Username = employee.Username,
                Role = employee.Role,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                PhoneNumber = employee.PhoneNumber,
                Address = employee.Address,

                // Map properties specific to Employee class
                Name = employee.Name,
                Email = employee.Email,
                SupervisorId = employee.SupervisorId,
                DateOfJoining = employee.DateOfJoining,
                FunctionId = employee.FunctionId,
                Status = employee.Status
            };

            // Additional mapping logic if needed

            return employeeDTO;
        }

        public void UpdateEmployee(int id, EmployeeDTO employeeDTO)
        {
            var existingEmployee = _employeeRepository.GetEmployeeById(id);

            if (existingEmployee == null)
            {
                throw new NotFoundException($"Employee with ID {id} not found.");
            }
            {
                // Update the common properties from User class
                existingEmployee.Username = employeeDTO.Username;
                existingEmployee.Role = employeeDTO.Role;
                existingEmployee.FirstName = employeeDTO.FirstName;
                existingEmployee.LastName = employeeDTO.LastName;
                existingEmployee.PhoneNumber = employeeDTO.PhoneNumber;
                existingEmployee.Address = employeeDTO.Address;

                // Update properties specific to Employee class
                existingEmployee.Name = employeeDTO.Name;
                existingEmployee.Email = employeeDTO.Email;
                existingEmployee.SupervisorId = employeeDTO.SupervisorId;
                existingEmployee.DateOfJoining = employeeDTO.DateOfJoining;
                existingEmployee.FunctionId = employeeDTO.FunctionId;
                existingEmployee.Status = employeeDTO.Status;

                _employeeRepository.UpdateEmployee(existingEmployee);

            }





            //private void MapUserProperties(User source, UserDTO destination)
            //{
            //    destination.UserId = source.UserId;
            //    destination.Username = source.Username;
            //    destination.Role = source.Role;
            //    destination.FirstName = source.FirstName;
            //    destination.LastName = source.LastName;
            //    destination.PhoneNumber = source.PhoneNumber;
            //    destination.Address = source.Address;
            //}

            //private void MapUserProperties(UserDTO source, User destination)
            //{
            //    destination.UserId = source.UserId;
            //    destination.Username = source.Username;
            //    destination.Role = source.Role;
            //    destination.FirstName = source.FirstName;
            //    destination.LastName = source.LastName;
            //    destination.PhoneNumber = source.PhoneNumber;
            //    destination.Address = source.Address;
            //}
        }

    }
}
