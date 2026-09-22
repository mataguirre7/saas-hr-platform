import type { EntityDto, FullAuditedEntityDto } from '@abp/ng.core';

export interface CreateUpdateDepartmentDto extends EntityDto {
  name: string;
  description?: string | null;
}

export interface DepartmentDto extends FullAuditedEntityDto<string> {
  name?: string;
  description?: string | null;
}
