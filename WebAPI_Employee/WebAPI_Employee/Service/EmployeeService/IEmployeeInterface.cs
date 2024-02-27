using WebAPI_Employee.Models;

namespace WebAPI_Employee.Service.EmployeeService;

public interface IEmployeeInterface
{
    Task<ServiceResponse<List<EmployeeModel>>> GetEmployee();
    Task<ServiceResponse<List<EmployeeModel>>> CreateEmplyee(EmployeeModel newEmployee);
    Task<ServiceResponse<EmployeeModel>> GetEmplyeeById(int id);
    Task<ServiceResponse<List<EmployeeModel>>> UpdateEmployee(EmployeeModel editedEmployee);
    Task<ServiceResponse<List<EmployeeModel>>> DeleteEmployee(int id);
    Task<ServiceResponse<List<EmployeeModel>>> InactivateEmployee(int id);
}
