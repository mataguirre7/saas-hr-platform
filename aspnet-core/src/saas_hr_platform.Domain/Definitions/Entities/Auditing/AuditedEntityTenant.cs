using System;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace saas_hr_platform.Definitions.Entities.Auditing;

[Serializable]
public abstract class AuditedEntityTenant : AuditedEntity, IMultiTenant
{
    public virtual Guid? TenantId { get; protected set; }
}

[Serializable]
public abstract class AuditedEntityTenant<TKey> : AuditedEntity<TKey>, IMultiTenant
{
    public virtual Guid? TenantId { get; protected set; }

    protected AuditedEntityTenant()
    {
    }

    protected AuditedEntityTenant(TKey id) : base(id)
    {
    }
}
