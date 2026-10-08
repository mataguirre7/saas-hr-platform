import { Routes } from '@angular/router';
import { authGuard } from '@abp/ng.core';

export const appRoutes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    loadChildren: () => import('./home/home.routes').then(m => m.homeRoutes),
  },
  {
    path: 'account',
    loadChildren: () => import('@abp/ng.account').then(m => m.createRoutes()),
  },
  {
    path: 'identity',
    loadChildren: () => import('@abp/ng.identity').then(m => m.createRoutes()),
  },
  {
    path: 'tenant-management',
    loadChildren: () =>
      import('@abp/ng.tenant-management').then(m => m.createRoutes()),
  },
  {
    path: 'setting-management',
    loadChildren: () =>
      import('@abp/ng.setting-management').then(m => m.createRoutes()),
  },
  {
    path: 'departments',
    loadChildren: () =>
      import("./departments/departments.routes").then(m => m.departmentsRoutes),
    canActivate: [authGuard]
  },
  {
    path: 'employees',
    loadChildren: () => import('./employees/employees.routes').then(m => m.employeesRoutes),
    canActivate: [authGuard]
  },
];
