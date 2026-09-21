using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;

namespace saas_hr_platform.Definitions.Entities;

[Serializable]
public abstract class EntityTenant : Entity, IMultiTenant
{
    public virtual Guid? TenantId { get; protected set; }
}

[Serializable]
public abstract class EntityTenant<Tkey> : Entity<Tkey>, IMultiTenant
{
    public virtual Guid? TenantId { get; protected set; }

    protected EntityTenant()
    {
        
    }

    protected EntityTenant(Tkey id) : base(id)
    {
        
    }
}