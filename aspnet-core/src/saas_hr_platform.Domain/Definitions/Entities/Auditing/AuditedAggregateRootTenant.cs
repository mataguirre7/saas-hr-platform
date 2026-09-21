using System;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace saas_hr_platform.Definitions.Entities.Auditing;

[Serializable]
public abstract class AuditedAggregateRootTenant : AuditedAggregateRoot, IMultiTenant
{
    public virtual Guid? TenantId { get; protected set; }
}

[Serializable]
public abstract class AuditedAggregateRootTenant<TKey> : AuditedAggregateRoot<TKey>, IMultiTenant
{
    public virtual Guid? TenantId { get; protected set; }

    protected AuditedAggregateRootTenant()
    {
    }

    protected AuditedAggregateRootTenant(TKey id) : base(id)
    {
    }
}
