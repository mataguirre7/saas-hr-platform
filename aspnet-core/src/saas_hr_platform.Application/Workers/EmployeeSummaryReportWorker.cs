using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using saas_hr_platform.Departments;
using saas_hr_platform.Employees;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.BackgroundWorkers;
using Volo.Abp.Threading;

namespace saas_hr_platform.Workers;

public class EmployeeSummaryReportWorker : AsyncPeriodicBackgroundWorkerBase
{
    public EmployeeSummaryReportWorker(
        AbpAsyncTimer timer,
        IServiceScopeFactory serviceScopeFactory)
        : base(timer, serviceScopeFactory)
    {
        Timer.Period = 24 * 60 * 60 * 1000;
    }

    protected override async Task DoWorkAsync(PeriodicBackgroundWorkerContext workerContext)
    {
        var employeeRepository = workerContext.ServiceProvider.GetRequiredService<IEmployeeRepository>();
        var departmentRepository = workerContext.ServiceProvider.GetRequiredService<IDepartmentRepository>();
        var logger = workerContext.ServiceProvider.GetRequiredService<ILogger<EmployeeSummaryReportWorker>>();

        var employees = await employeeRepository.GetQueryableAsync();
        var departments = await departmentRepository.GetListAsync();

        var data = employees
            .Where(e => e.Status == EmployeeStatus.Active)
            .GroupBy(e => e.DepartmentId);

        var summary = data.ToList().Select(g => new
        {
            DepartmentName = departments.FirstOrDefault(d => d.Id == g.Key)?.Name ?? "Unknown",
            ActiveEmployeeCount = g.Count()
        });

        logger.LogInformation("[REPORT] Daily Active Employees Report ===");

        foreach(var item in summary)
        {
            logger.LogInformation(
                "[MESSAGE] {DepartmentName}: {ActiveEmployeeCount} active employee(s)",
                item.DepartmentName,
                item.ActiveEmployeeCount);
        }
    }
}
