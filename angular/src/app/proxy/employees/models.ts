import type { EmployeeStatus } from './employee-status.enum';
import type { FullAuditedEntityDto } from '@abp/ng.core';

export interface CreateUpdateEmployeeDto {
  firstName: string;
  lastName: string;
  email: string;
  jobTitle: string;
  hireDate: string;
  status: EmployeeStatus;
  departmentId: string;
}

export interface EmployeeDto extends FullAuditedEntityDto<string> {
  firstName?: string;
  lastName?: string;
  email?: string;
  jobTitle?: string;
  hireDate?: string;
  status?: EmployeeStatus;
  departmentId?: string;
  departmentName?: string;
}
