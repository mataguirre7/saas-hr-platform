import { Routes } from "@angular/router";

export const departmentsRoutes: Routes = [
  {
    path: "",
    pathMatch: "full",
    loadComponent: () =>
      import("./department-list/department-list/department-list.component").then(m => m.DepartmentListComponent)
  }
]
