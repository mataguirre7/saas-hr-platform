namespace saas_hr_platform.Departments;

public class DepartmentManager
{
    private readonly IDepartmentRepository _departmentRepository;
    
    public DepartmentManager(
        IDepartmentRepository departmentRepository
    )
    {
        _departmentRepository = departmentRepository;
    }
}