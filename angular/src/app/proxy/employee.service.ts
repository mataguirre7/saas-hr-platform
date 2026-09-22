import type { CreateUpdateEmployeeDto, EmployeeDto } from './employees/models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { Injectable, inject } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class EmployeeService {
  private restService = inject(RestService);
  apiName = 'Default';
  

  create = (input: CreateUpdateEmployeeDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, EmployeeDto>({
      method: 'POST',
      headers: { Accept: 'application/json' },
      url: '/api/app/employee',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/employee/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, EmployeeDto>({
      method: 'GET',
      headers: { Accept: 'application/json' },
      url: `/api/app/employee/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getList = (input: PagedAndSortedResultRequestDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<EmployeeDto>>({
      method: 'GET',
      headers: { Accept: 'application/json' },
      url: '/api/app/employee',
      params: { sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: CreateUpdateEmployeeDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, EmployeeDto>({
      method: 'PUT',
      headers: { Accept: 'application/json' },
      url: `/api/app/employee/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });
}