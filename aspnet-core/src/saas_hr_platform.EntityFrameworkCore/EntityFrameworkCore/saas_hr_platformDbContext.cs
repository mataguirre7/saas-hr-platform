using Microsoft.EntityFrameworkCore;
using saas_hr_platform.Departments;
using saas_hr_platform.Employees;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace saas_hr_platform.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class saas_hr_platformDbContext :
    AbpDbContext<saas_hr_platformDbContext>,
    IIdentityDbContext,
    ITenantManagementDbContext
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */

    #region Entities from the modules

    /* Notice: We only implemented IIdentityDbContext and ITenantManagementDbContext
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityDbContext and ITenantManagementDbContext.
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    //Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }
    public DbSet<IdentityUserDelegation> UserDelegations { get; set; }
    public DbSet<IdentitySession> Sessions { get; set; }
    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    #endregion

    public DbSet<Department> Departments { get; set; }
    public DbSet<Employee> Employees { get; set; }

    public saas_hr_platformDbContext(DbContextOptions<saas_hr_platformDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();

        /* Configure your own tables/entities inside here */

        //builder.Entity<YourEntity>(b =>
        //{
        //    b.ToTable(saas_hr_platformConsts.DbTablePrefix + "YourEntities", saas_hr_platformConsts.DbSchema);
        //    b.ConfigureByConvention(); //auto configure for the base class props
        //    //...
        //});

        builder.Entity<Department>(b =>
        {
            b.ToTable("departments", saas_hr_platformConsts.DbSchema);
            b.ConfigureByConvention();
            b.Property(p => p.Id).HasColumnName("id");
            b.Property(p => p.Name).IsRequired().HasMaxLength(128).HasColumnName("name");
            b.Property(p => p.Description).IsRequired(false).HasColumnName("description");
            b.Property(p => p.ExtraProperties).IsRequired().HasColumnName("extra_properties");
            b.Property(p => p.ConcurrencyStamp).IsRequired().HasColumnName("concurrency_stamp");
            b.Property(p => p.CreationTime).IsRequired().HasColumnName("creation_time");
            b.Property(p => p.CreatorId).HasColumnName("creator_id");
            b.Property(p => p.LastModificationTime).HasColumnName("last_modification_time");
            b.Property(p => p.LastModifierId).HasColumnName("last_modifier_id");
            b.Property(p => p.IsDeleted).IsRequired().HasColumnName("is_deleted");
            b.Property(p => p.DeleterId).HasColumnName("deleter_id");
            b.Property(p => p.DeletionTime).HasColumnName("deletion_time");
            b.Property(p => p.TenantId).HasColumnName("tenant_id");
            b.HasMany(p => p.Employees).WithOne(p => p.Department).HasForeignKey(p => p.DepartmentId).IsRequired();
        });

        builder.Entity<Employee>(b =>
        {
            b.ToTable("employees", saas_hr_platformConsts.DbSchema);
            b.ConfigureByConvention();
            b.Property(p => p.Id)
                .HasColumnName("id");
            b.Property(p => p.FirstName)
                .IsRequired()
                .HasColumnName("first_name");
            b.Property(p => p.LastName)
                .IsRequired()
                .HasColumnName("last_name");
            b.Property(p => p.Email)
                .IsRequired()
                .HasColumnName("email");
            b.Property(p => p.JobTitle)
                .IsRequired()
                .HasColumnName("job_title");
            b.Property(p => p.HireDate)
                .IsRequired()
                .HasColumnName("hire_date");
            b.Property(p => p.Status)
                .IsRequired()
                .HasColumnName("status");
            b.Property(p => p.DepartmentId)
                .IsRequired()
                .HasColumnName("department_id");
            b.Property(p => p.ExtraProperties)
                .IsRequired()
                .HasColumnName("extra_properties");
            b.Property(p => p.ConcurrencyStamp)
                .IsRequired()
                .HasColumnName("concurrency_stamp");
            b.Property(p => p.CreationTime)
                .IsRequired()
                .HasColumnName("creation_time");
            b.Property(p => p.CreatorId)
                .HasColumnName("creator_id");
            b.Property(p => p.LastModificationTime)
                .HasColumnName("last_modification_time");
            b.Property(p => p.LastModifierId)
                .HasColumnName("last_modifier_id");
            b.Property(p => p.IsDeleted)
                .IsRequired()
                .HasColumnName("is_deleted");
            b.Property(p => p.DeleterId)
                .HasColumnName("deleter_id");
            b.Property(p => p.DeletionTime)
                .HasColumnName("deletion_time");
            b.Property(p => p.TenantId)
                .HasColumnName("tenant_id");
        });
    }
}
