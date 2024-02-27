using WebAPI_Employee.Enums;

namespace WebAPI_Employee.Models;

public class EmployeeModel
{
    public int Id { get; set; }
    public string Name { get; set; }  = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DepartmentEnum Department { get; set; } 
    public bool Active { get; set; }
    public ShiftEnum Shift { get; set; }
    public DateTime CreationDate { get; set; } = DateTime.Now.ToLocalTime();
    public DateTime ChangeDate { get; set; } = DateTime.Now.ToLocalTime( );
}
