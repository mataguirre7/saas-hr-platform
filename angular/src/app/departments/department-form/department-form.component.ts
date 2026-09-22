import { CommonModule } from '@angular/common';
import { Component, EventEmitter, inject, Input, OnChanges, Output, SimpleChanges } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { DepartmentService } from '@proxy/department.service';
import { DepartmentDto } from '@proxy/departments';
import { ButtonModule } from 'primeng/button';
import { DialogModule } from 'primeng/dialog';
import { InputTextModule } from 'primeng/inputtext';
import { InputTextareaModule } from 'primeng/inputtextarea';

@Component({
  selector: 'app-department-form',
  imports: [CommonModule, ReactiveFormsModule, DialogModule, InputTextModule,
    InputTextareaModule, ButtonModule
  ],
  templateUrl: './department-form.component.html',
  styleUrl: './department-form.component.scss',
})
export class DepartmentFormComponent implements OnChanges {
  private fb = inject(FormBuilder);
  private departmentService = inject(DepartmentService);

  @Input() visible = false;
  @Input() department: DepartmentDto | null = null;

  @Output() visibleChange = new EventEmitter<boolean>();
  @Output() saved = new EventEmitter<void>();

  isSaving = false;

  form = this.fb.nonNullable.group({
    name: ['', [Validators.required, Validators.maxLength(128)]],
    description: ['']
  })

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['department']) {
      this.form.reset({
        name: this.department?.name ?? '',
        description: this.department?.description ?? '',
      })
    }
  }

  get isEditMode(): boolean {
    return !!this.department?.id;
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

    const request$ = this.isEditMode
      ? this.departmentService.update(this.department!.id!, input)
      : this.departmentService.create(input);

    request$.subscribe({
      next: () => {
        this.isSaving = false;
        this.saved.emit();
        this.close();
      },
      error: () => {
        this.isSaving = false;
      }
    })
  }
}
