using Microsoft.AspNetCore.Mvc;
using WebAPI_Employee.Models;
using WebAPI_Employee.Service.EmployeeService;

namespace WebAPI_Employee.Controllers;
[Route("api/[controller]")]
[ApiController]
public class EmployeeController: ControllerBase
{
    private readonly IEmployeeInterface _employeeInterface;
    public EmployeeController(IEmployeeInterface employeeInterface)
    {
        _employeeInterface = employeeInterface;
    }
    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<EmployeeModel>>>> GetEmployee()
    {
        return Ok(await _employeeInterface.GetEmployee());
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceResponse<EmployeeModel>>> GetEmplyeeById(int id)
    {
        ServiceResponse<EmployeeModel> serviceResponse = await _employeeInterface.GetEmplyeeById(id);
        return Ok(serviceResponse);
    }

    [HttpPost]
    public async Task<ActionResult<ServiceResponse<List<EmployeeModel>>>> CreateEmployee(EmployeeModel newEmployee)
    {
        return Ok(await _employeeInterface.CreateEmplyee(newEmployee));
    }

    [HttpPut]
    public async Task<ActionResult<ServiceResponse<List<EmployeeModel>>>> UpdateEmployee(EmployeeModel editedEmployee)
    {
        ServiceResponse<List<EmployeeModel>> serviceResponse = await _employeeInterface.UpdateEmployee(editedEmployee);

        return Ok(serviceResponse);
    }

    [HttpPut("intactiveEmployee")]
    public async Task<ActionResult<ServiceResponse<List<EmployeeModel>>>> InactiveEmployee(int id)
    {
        ServiceResponse<List<EmployeeModel>> serviceResponse = await _employeeInterface.InactivateEmployee(id);
        return Ok(serviceResponse);
    }

    [HttpDelete]
    public async Task<ActionResult<ServiceResponse<List<EmployeeModel>>>> DeleteEmployee(int id)
    {
        ServiceResponse<List<EmployeeModel>> serviceResponse = await _employeeInterface.DeleteEmployee(id);
        
        return Ok(serviceResponse);
    }
}
