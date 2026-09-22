import { mapEnumToOptions } from '@abp/ng.core';

export enum EmployeeStatus {
  Active = 1,
  OnLeave = 2,
  Terminated = 3,
}

export const employeeStatusOptions = mapEnumToOptions(EmployeeStatus);
