import { AbstractControl, ValidationErrors, ValidatorFn } from '@angular/forms';

export function alphanumericValidator(): ValidatorFn {
  return (control: AbstractControl): ValidationErrors | null => {
    const alphanumericPattern = /^[A-Za-z\d]{10}$/;

    const valid = alphanumericPattern.test(control.value);
    return valid ? null : { invalidAlphanumeric: true };
  };
}