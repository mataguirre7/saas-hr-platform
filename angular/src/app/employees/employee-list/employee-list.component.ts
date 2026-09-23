import { Component, OnInit, inject, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ButtonModule } from 'primeng/button';
import { EmployeeService } from '../../proxy/employee.service';
import { EmployeeDto } from '../../proxy/employees/models';
import { EmployeeStatus, employeeStatusOptions } from '../../proxy/employees/employee-status.enum';
import { EmployeeFormComponent } from '../employee-form/employee-form.component';
import { ConfirmationService } from 'primeng/api';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { getEmployeeStatusLabel } from '../employees.utils';

@Component({
  selector: 'app-employee-list',
  standalone: true,
  imports: [CommonModule, ButtonModule, EmployeeFormComponent, ConfirmDialogModule],
  providers: [ConfirmationService],
  templateUrl: './employee-list.component.html',
})
export class EmployeeListComponent implements OnInit {
  private employeeService = inject(EmployeeService);
  private confirmationService = inject(ConfirmationService);

  employees = signal<EmployeeDto[]>([]);
  isLoading = signal(false);

  formVisible = false;
  selectedEmployee: EmployeeDto | null = null;

  ngOnInit(): void {
    this.loadEmployees();
  }

  loadEmployees(): void {
    this.isLoading.set(true);
    this.employeeService
      .getList({ maxResultCount: 100, skipCount: 0, sorting: 'lastName' })
      .subscribe({
        next: result => {
          this.employees.set(result.items ?? []);
          this.isLoading.set(false);
        },
        error: () => this.isLoading.set(false),
      });
  }

  statusLabel(status?: EmployeeStatus): string {
    return getEmployeeStatusLabel(status);
  }

  openCreate(): void {
    this.selectedEmployee = null;
    this.formVisible = true;
  }

  openEdit(employee: EmployeeDto): void {
    this.selectedEmployee = employee;
    this.formVisible = true;
  }

  onSaved(): void {
    this.loadEmployees();
  }

  confirmDelete(employee: EmployeeDto): void {
    this.confirmationService.confirm({
      message: `Are you sure you want to delete "${employee.firstName} ${employee.lastName}"?`,
      header: 'Confirm Deletion',
      icon: 'pi pi-exclamation-triangle',
      accept: () => this.deleteEmployee(employee.id!),
    });
  }

  deleteEmployee(id: string): void {
    this.employeeService.delete(id).subscribe(() => this.loadEmployees());
  }
}
