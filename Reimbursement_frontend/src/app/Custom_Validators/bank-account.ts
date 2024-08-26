import { AbstractControl, ValidationErrors, ValidatorFn } from '@angular/forms';

export function alphanumericTwelveValidator(): ValidatorFn {
  return (control: AbstractControl): ValidationErrors | null => {
    const alphanumericPattern = /^[A-Za-z\d]{12}$/;

    const valid = alphanumericPattern.test(control.value);
    return valid ? null : { invalidtwelveAlphanumeric: true };
  };
}