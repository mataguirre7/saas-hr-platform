using System;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace saas_hr_platform.Definitions.Entities.Auditing;

[Serializable]
public abstract class FullAuditedEntityTenant : FullAuditedEntity, IMultiTenant
{
    public virtual Guid? TenantId { get; protected set; }
}

[Serializable]
public abstract class FullAuditedEntityTenant<TKey> : FullAuditedEntity<TKey>, IMultiTenant
{
    public virtual Guid? TenantId { get; protected set; }

    protected FullAuditedEntityTenant()
    {
    }

    protected FullAuditedEntityTenant(TKey id) : base(id)
    {
    }
}
