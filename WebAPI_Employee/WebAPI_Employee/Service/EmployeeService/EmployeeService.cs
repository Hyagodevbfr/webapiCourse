using Microsoft.EntityFrameworkCore;
using WebAPI_Employee.DataContext;
using WebAPI_Employee.Models;

namespace WebAPI_Employee.Service.EmployeeService;

public class EmployeeService: IEmployeeInterface
{
    private readonly ApplicationDbContext _context;
    public EmployeeService(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<ServiceResponse<List<EmployeeModel>>> CreateEmplyee(EmployeeModel newEmployee)
    {
        ServiceResponse<List<EmployeeModel>> serviceResponse = new( );

        try
        {
            if (newEmployee == null)
            {
                serviceResponse.Data = null;
                serviceResponse.Message = "Informar dados";
                serviceResponse.Sucess = false;

                return serviceResponse;
            }
            _context.Add(newEmployee);
            await _context.SaveChangesAsync();

            serviceResponse.Data = _context.Employees.ToList();

        }catch (Exception ex)
        {
            serviceResponse.Message = ex.Message;
            serviceResponse.Sucess = false;
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<EmployeeModel>>> DeleteEmployee(int id)
    {
        ServiceResponse<List<EmployeeModel>> serviceResponse = new( );

        try
        {
            EmployeeModel employee = _context.Employees.FirstOrDefault(x => x.Id == id);
            if(employee == null)
            {
                serviceResponse.Data = null;
                serviceResponse.Message = "Usuário não localizado";
                serviceResponse.Sucess = false;

                return serviceResponse;
            }
                
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync( );

            serviceResponse.Data = _context.Employees.ToList( );

        }catch (Exception ex)
        {
            serviceResponse.Message = ex.Message;
            serviceResponse.Sucess = false;
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<EmployeeModel>>> GetEmployee()
    {
        ServiceResponse<List<EmployeeModel>> serviceResponse = new( );
        try
        {
            serviceResponse.Data = _context.Employees.ToList();
            if (serviceResponse.Data.Count== 0)
            {
                serviceResponse.Message = "Nenhum dado encontrado!";
            }

        }
        catch (Exception ex)
        {
            serviceResponse.Message = ex.Message;
            serviceResponse.Sucess = false;
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<EmployeeModel>> GetEmplyeeById(int id)
    {
        
        ServiceResponse<EmployeeModel> serviceResponse = new( );
        try
        {
            EmployeeModel employee = _context.Employees.FirstOrDefault(x => x.Id == id)!;

            if (employee == null)
            {
                serviceResponse.Data = null;
                serviceResponse.Message = "Usuário não localizado!";
                serviceResponse.Sucess = false;
            }

            serviceResponse.Data = employee;

        }
        catch(Exception ex)
        {
            serviceResponse.Message = ex.Message;
            serviceResponse.Sucess = false;
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<EmployeeModel>>> InactivateEmployee(int id)
    {
        ServiceResponse<List<EmployeeModel>> serviceResponse = new( );
        {
            try
            {
                EmployeeModel employee = _context.Employees.FirstOrDefault(x => x.Id == id)!;
                if(employee == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "Usuário não localizado!";
                    serviceResponse.Sucess = false;
                }
                employee!.Active = false;
                employee.ChangeDate = DateTime.Now.ToLocalTime();

                _context.Employees.Update(employee);
                await _context.SaveChangesAsync();

                serviceResponse.Data = _context.Employees.ToList( );

            }
            catch( Exception ex ) 
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Sucess = false;
            }
            return serviceResponse;
        }
    }

    public async Task<ServiceResponse<List<EmployeeModel>>> UpdateEmployee(EmployeeModel editedEmployee)
    {
        ServiceResponse<List<EmployeeModel>> serviceResponse = new( );

        try
        {
            EmployeeModel employee = _context.Employees.AsNoTracking().FirstOrDefault(x=> x.Id == editedEmployee.Id);
            if(employee == null)
            {
                serviceResponse.Data = null;
                serviceResponse.Message = "Usuário não localizado!";
                serviceResponse.Sucess = false;
            }

            employee.CreationDate = DateTime.Now.ToLocalTime();
            _context.Employees.Update(editedEmployee);
            await _context.SaveChangesAsync( );
            serviceResponse.Data = _context.Employees.ToList( );
        }
        catch( Exception ex )
        {
            serviceResponse.Message = ex.Message;
            serviceResponse.Sucess = false;
        }
        return serviceResponse;
    }
}
