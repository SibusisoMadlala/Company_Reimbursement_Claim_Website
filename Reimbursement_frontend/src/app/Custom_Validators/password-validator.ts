import { AbstractControl, ValidationErrors, ValidatorFn } from '@angular/forms';

export const passwordFormat: ValidatorFn = (control : AbstractControl): ValidationErrors | null =>{

    //const password =control.get('password');
    const passwordregex = /^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$/;

    const valid = passwordregex.test(control.value)

    return valid ? null : {invalidPassword : true}
}