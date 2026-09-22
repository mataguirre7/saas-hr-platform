import { Component, EventEmitter, Input, Output, OnChanges, OnInit, SimpleChanges, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormBuilder, Validators } from '@angular/forms';
import { DialogModule } from 'primeng/dialog';
import { InputTextModule } from 'primeng/inputtext';
import { ButtonModule } from 'primeng/button';
import { DropdownModule } from 'primeng/dropdown';
import { CalendarModule } from 'primeng/calendar';
import { EmployeeService } from '../../proxy/employee.service';
import { CreateUpdateEmployeeDto, EmployeeDto } from '../../proxy/employees/models';
import { EmployeeStatus, employeeStatusOptions } from '../../proxy/employees/employee-status.enum';
import { DepartmentService } from '../../proxy/department.service';
import { DepartmentDto } from '../../proxy/departments/models';

@Component({
  selector: 'app-employee-form',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, DialogModule, InputTextModule, ButtonModule, DropdownModule, CalendarModule],
  templateUrl: './employee-form.component.html',
})
export class EmployeeFormComponent implements OnInit, OnChanges {
  private fb = inject(FormBuilder);
  private employeeService = inject(EmployeeService);
  private departmentService = inject(DepartmentService);

  @Input() visible = false;
  @Input() employee: EmployeeDto | null = null;

  @Output() visibleChange = new EventEmitter<boolean>();
  @Output() saved = new EventEmitter<void>();

  isSaving = false;
  departments: DepartmentDto[] = [];
  statusOptions = employeeStatusOptions;

  form = this.fb.nonNullable.group({
    firstName: ['', [Validators.required, Validators.maxLength(128)]],
    lastName: ['', [Validators.required, Validators.maxLength(128)]],
    email: ['', [Validators.required, Validators.email]],
    jobTitle: ['', [Validators.required, Validators.maxLength(128)]],
    hireDate: [new Date(), [Validators.required]],
    status: [EmployeeStatus.Active, [Validators.required]],
    departmentId: ['', [Validators.required]],
  });

  ngOnInit(): void {
    this.departmentService.getList({ maxResultCount: 1000, skipCount: 0 }).subscribe(result => {
      this.departments = result.items ?? [];
    });
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['employee']) {
      this.form.reset({
        firstName: this.employee?.firstName ?? '',
        lastName: this.employee?.lastName ?? '',
        email: this.employee?.email ?? '',
        jobTitle: this.employee?.jobTitle ?? '',
        hireDate: this.employee?.hireDate ? new Date(this.employee.hireDate) : new Date(),
        status: this.employee?.status ?? EmployeeStatus.Active,
        departmentId: this.employee?.departmentId ?? '',
      });

      this.isEditMode ? this.form.controls.email.disable() : this.form.controls.email.enable();
    }
  }

  get isEditMode(): boolean {
    return !!this.employee?.id;
  }

  close(): void {
    this.visible = false;
    this.visibleChange.emit(false);
  }

  submit(): void {
    if (this.form.invalid) {
      this.form.markAllAsTouched();
      return;
    }

    this.isSaving = true;
    const input = this.form.getRawValue();

    let data: CreateUpdateEmployeeDto = {
      ...input,
      hireDate: input.hireDate.toISOString()
    }

    const request$ = this.isEditMode
      ? this.employeeService.update(this.employee!.id!, data)
      : this.employeeService.create(data);

    request$.subscribe({
      next: () => {
        this.isSaving = false;
        this.saved.emit();
        this.close();
      },
      error: () => {
        this.isSaving = false;
      },
    });
  }
}
