using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;

namespace saas_hr_platform.Definitions.Entities;

[Serializable]
public abstract class AggregateRootTenant : AggregateRoot, IMultiTenant
{
    public virtual Guid? TenantId { get; protected set; }
}

[Serializable]
public abstract class AggregateRootTenant<TKey> : AggregateRoot<TKey>, IMultiTenant
{
    public virtual Guid? TenantId { get; protected set; }

    protected AggregateRootTenant()
    {
    }

    protected AggregateRootTenant(TKey id) : base(id)
    {
    }
}
