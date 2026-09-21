using System;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace saas_hr_platform.Definitions.Entities.Auditing;

[Serializable]
public abstract class FullAuditedAggregateRootTenant : FullAuditedAggregateRoot, IMultiTenant
{
    public virtual Guid? TenantId { get; protected set; }
}

[Serializable]
public abstract class FullAuditedAggregateRootTenant<TKey> : FullAuditedAggregateRoot<TKey>, IMultiTenant
{
    public virtual Guid? TenantId { get; protected set; }

    protected FullAuditedAggregateRootTenant()
    {

    }

    protected FullAuditedAggregateRootTenant(TKey id)
    : base(id)
    {

    }
}

