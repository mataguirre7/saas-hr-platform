namespace saas_hr_platform;

public static class saas_hr_platformDomainErrorCodes
{
    private const string _prefix = "SaasHrPlatform:";

    public static class Employee
    {
        private const string _entity = _prefix + "Employee.";

        public const string InvalidFirstName = _entity + "InvalidFirstName";
        public const string InvalidLastName = _entity + "InvalidLastName";
        public const string InvalidHireDate = _entity + "InvalidHireDate";
        public const string InvalidEmail = _entity + "InvalidEmail";
        public const string DuplicateEmail = _entity + "DuplicateEmail";
        public const string InvalidJobTitle = _entity + "InvalidJobTitle";
        public const string InvalidDepartment = _entity + "InvalidDepartment";
    }

    public static class Department
    {
        private const string _entity = _prefix + "Department.";

        public const string InvalidName = _entity + "InvalidName";
        public const string InvalidDescription = _entity + "InvalidDescription";
        public const string DuplicateName = _entity + "DuplicateName";
        public const string NotFound = _entity + "NotFound";
    }
}
