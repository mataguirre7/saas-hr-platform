using System;
using System.Threading.Tasks;
using saas_hr_platform.Departments;
using saas_hr_platform.Employees;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;

namespace saas_hr_platform.Data;

public class SaasHrPlatformDataSeederContributor : IDataSeedContributor, ITransientDependency
{
    private readonly IDepartmentRepository _departmentRepository;
    private readonly IEmployeeRepository _employeeRepository;
    private readonly DepartmentManager _departmentManager;
    private readonly EmployeeManager _employeeManager;

    public SaasHrPlatformDataSeederContributor(
        IDepartmentRepository departmentRepository,
        IEmployeeRepository employeeRepository,
        DepartmentManager departmentManager,
        EmployeeManager employeeManager
    )
    {
        _departmentManager = departmentManager;
        _employeeManager = employeeManager;
        _departmentRepository = departmentRepository;
        _employeeRepository = employeeRepository;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        if (await _departmentRepository.GetCountAsync() > 0)
        {
            return;
        }

        var engineering = await _departmentManager.CreateAsync("Engineering", "Software development team");
        await _departmentRepository.InsertAsync(engineering);

        var sales = await _departmentManager.CreateAsync("Sales", "Sales and business development");
        await _departmentRepository.InsertAsync(sales);

        var humanResources = await _departmentManager.CreateAsync("Human Resources", "People operations and recruitment");
        await _departmentRepository.InsertAsync(humanResources);

        var employees = new[]
        {
            await _employeeManager.CreateAsync("Matias", "Aguirre", "matias.aguirre@nzsitsolutions.com.ar", "Fullstack Developer", new DateTime(2023, 3, 1), EmployeeStatus.Active, engineering),
            await _employeeManager.CreateAsync("Lucia", "Fernandez", "lucia.fernandez@nzsitsolutions.com.ar", "Backend Developer", new DateTime(2024, 6, 15), EmployeeStatus.Active, engineering),
            await _employeeManager.CreateAsync("Martin", "Gomez", "martin.gomez@nzsitsolutions.com.ar", "Sales Executive", new DateTime(2022, 11, 10), EmployeeStatus.Active, sales),
            await _employeeManager.CreateAsync("Sofia", "Lopez", "sofia.lopez@nzsitsolutions.com.ar", "Sales Representative", new DateTime(2023, 8, 20), EmployeeStatus.OnLeave, sales),
            await _employeeManager.CreateAsync("Diego", "Martinez", "diego.martinez@nzsitsolutions.com.ar", "HR Specialist", new DateTime(2021, 4, 5), EmployeeStatus.Active, humanResources),
        };

        await _employeeRepository.InsertManyAsync(employees);
    }
}