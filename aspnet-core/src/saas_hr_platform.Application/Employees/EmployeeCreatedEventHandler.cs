using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus;

namespace saas_hr_platform.Employees;

public class EmployeeCreatedEventHandler :
    ILocalEventHandler<EmployeeCreatedEto>, ITransientDependency
{
    private readonly ILogger<EmployeeCreatedEventHandler> _logger;

    public EmployeeCreatedEventHandler(ILogger<EmployeeCreatedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task HandleEventAsync(EmployeeCreatedEto eventData)
    {
        _logger.LogInformation(
            "Handle event for employee created eto, data: {FirstName} {LastName} ({Email})" +
            " - Department: {DepartmentId}",
        eventData.FirstName,
        eventData.LastName,
        eventData.Email,
        eventData.DepartmentId);

        return Task.CompletedTask;
    }
}
