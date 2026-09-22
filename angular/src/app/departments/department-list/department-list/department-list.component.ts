import { Component, OnInit, inject, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ButtonModule } from 'primeng/button';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { ConfirmationService } from 'primeng/api';
import { DepartmentFormComponent } from '../../department-form/department-form.component';
import { DepartmentService } from '@proxy';
import { DepartmentDto } from '@proxy/departments';

@Component({
  selector: 'app-department-list',
  standalone: true,
  imports: [CommonModule, ButtonModule, ConfirmDialogModule, DepartmentFormComponent],
  providers: [ConfirmationService],
  templateUrl: './department-list.component.html',
})
export class DepartmentListComponent implements OnInit {
  private departmentService = inject(DepartmentService);
  private confirmationService = inject(ConfirmationService);

  departments = signal<DepartmentDto[]>([]);
  isLoading = signal(false);

  formVisible = false;
  selectedDepartment: DepartmentDto | null = null;

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
        error: () => this.isLoading.set(false),
      });
  }

  openCreate(): void {
    this.selectedDepartment = null;
    this.formVisible = true;
  }

  openEdit(department: DepartmentDto): void {
    this.selectedDepartment = department;
    this.formVisible = true;
  }

  confirmDelete(department: DepartmentDto): void {
    this.confirmationService.confirm({
      message: `Are you sure you want to delete "${department.name}"?`,
      header: 'Confirm Deletion',
      icon: 'pi pi-exclamation-triangle',
      accept: () => this.deleteDepartment(department.id!),
    });
  }

  deleteDepartment(id: string): void {
    this.departmentService.delete(id).subscribe(() => this.loadDepartments());
  }

  onSaved(): void {
    this.loadDepartments();
  }
}
