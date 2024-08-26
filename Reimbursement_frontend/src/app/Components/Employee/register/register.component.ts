import { Component, inject } from '@angular/core';
import { FormControl, FormGroup, NonNullableFormBuilder, ReactiveFormsModule, Validators , FormsModule} from '@angular/forms';
import { Router } from '@angular/router';
import { EmployeeServiceService } from '../../../Services/employee-service.service';
import e from 'express';
import { NgFor, NgIf, NgClass } from '@angular/common';
import { confirmPasswordValidator } from '../../../Custom_Validators/password-mismatch';
import { passwordFormat } from '../../../Custom_Validators/password-validator';
import { alphanumericValidator } from '../../../Custom_Validators/pan-number';
import { alphanumericTwelveValidator } from '../../../Custom_Validators/bank-account';
import { RouterLink } from '@angular/router';
//import { confirmPasswordValidator } from '../../shared/password/password-mismatch.directive';

interface Bank{
  id : Number
  bankName : string
}

interface Employee{
  full_name: string;
  email : string;
  password :string;
  pan_number : string;
  bankId : Number;
  bank_account_number: string;
}



@Component({
  selector: 'app-register',
  standalone: true,
  imports: [ReactiveFormsModule, NgIf, NgFor, NgClass, FormsModule, RouterLink],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {

  fb = inject(NonNullableFormBuilder);
  registerForm!: FormGroup;
  EmployeeService= inject(EmployeeServiceService);

  banks! : Bank[]

  selectedBank! : Bank
  router = inject(Router);
  

  ngOnInit(): void {
    this.registerForm = new FormGroup({
      full_name: new FormControl('',Validators.required),
      
      pan_number: new FormControl('', [Validators.required, Validators.pattern(/^[A-Za-z\d]{10}$/)]),
      bankId: new FormControl('',Validators.required),
      bank_account_number: new FormControl('', [Validators.required, Validators.pattern(/^[A-Za-z\d]{12}$/)]),
      email: new FormControl('', [Validators.required, Validators.email]),
      password: new FormControl('', [Validators.required, Validators.pattern(/^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%/*#?&])[A-Za-z\d@$/!%*#?&]{8,}$/)] ),
      confirm: new FormControl('', [Validators.required])
    }, [confirmPasswordValidator]);

    this.EmployeeService.getAllBanks().subscribe((banks) => {
      this.banks = banks
    })

    //this.selectedBank=this.banks[0];
  }

  registerEmployee(){
    const employee : Employee = {
      full_name : this.registerForm.value.full_name ?? '',
      pan_number : this.registerForm.value.pan_number ?? '',
      bankId : this.registerForm.value.bankId,
      bank_account_number: this.registerForm.value.bank_account_number ?? '',
      email : this.registerForm.value.email ?? '',
      password : this.registerForm.value.password ?? '',
      
    }

    if (this.registerForm.valid){
      
      this.EmployeeService.registerEmployee(employee).subscribe(
        response => {alert("Employee added")}
      );
      this.router.navigate(['/login'])
      
    }
  }

  onBankChange(event: any) {
    this.selectedBank = event.value;
    //console.log(`Selected bank: ${this.selectedBank}`);
  }
}
