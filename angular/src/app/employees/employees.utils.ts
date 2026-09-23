import { EmployeeStatus } from "@proxy/employees";

const statusLabel: Record<EmployeeStatus, string> = {
  [EmployeeStatus.Active]: 'Active',
  [EmployeeStatus.OnLeave]: 'On Leave',
  [EmployeeStatus.Terminated]: 'Terminated'
}

export function getEmployeeStatusLabel(status?: EmployeeStatus): string {
  return status != null ? (statusLabel[status] ?? 'Unknown') : 'Unknown';
}
