import { RoutesService, eLayoutType } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const APP_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routesService: RoutesService) {
  return () => {
    routesService.add([
      {
        path: '/',
        name: '::Menu:Home',
        iconClass: 'fas fa-home',
        order: 1,
        layout: eLayoutType.application,
      },
      {
        path: '/departments',
        name: "Departments",
        iconClass: "fas fa-building",
        order: 2,
        layout: eLayoutType.application
      },
      {
        path: '/employees',
        name: 'Employees',
        iconClass: 'fas fa-users',
        order: 3,
        layout: eLayoutType.application,
      },
    ]);
  };
}
