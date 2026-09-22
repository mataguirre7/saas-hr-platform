import { DepartmentDto } from './../../../proxy/departments/models';
import { Component, inject, OnInit, signal } from '@angular/core';
import { DepartmentService } from '@proxy';

@Component({
  selector: 'app-department-list',
  imports: [],
  templateUrl: './department-list.component.html',
  styleUrl: './department-list.component.scss',
})
export class DepartmentListComponent implements OnInit {
  private departmentService: DepartmentService = inject(DepartmentService);

  departments = signal<DepartmentDto[]>([]);
  isLoading = signal<boolean>(false);

  ngOnInit(): void {
    this.loadDepartments();
  }

  loadDepartments(): void {
    this.isLoading.set(true);
    this.departmentService
      .getList({ maxResultCount: 100, skipCount: 0, sorting: 'name' })
      .subscribe({
        next: result => {
          this.departments.set(result.items ?? []);
          this.isLoading.set(false);
        },
        error: () => this.isLoading.set(false)
      })
  }
}
