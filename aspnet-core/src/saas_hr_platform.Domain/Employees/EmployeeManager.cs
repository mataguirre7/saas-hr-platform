namespace saas_hr_platform.Employees;

public class EmployeeManager
{
    private readonly IEmployeeRepository _employeeRepository;
    
    public EmployeeManager(
        IEmployeeRepository employeeRepository
    )
    {
        _employeeRepository = employeeRepository;
    }
}