using saas_hr_platform.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace saas_hr_platform.Permissions;

public class saas_hr_platformPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(saas_hr_platformPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(saas_hr_platformPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<saas_hr_platformResource>(name);
    }
}
