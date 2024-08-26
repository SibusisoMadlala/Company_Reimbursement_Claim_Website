import { Component, inject } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { EmployeeServiceService } from '../../../Services/employee-service.service';
import { HttpErrorResponse } from '@angular/common/http';
import { Router } from '@angular/router';
import { RouterLink } from '@angular/router';

interface UserForAuthenticationDto {
  email: string;
  password: string;
  
  
}
interface AuthResponseDto {
  isAuthSuccessful: boolean;
  errorMessage: string;
  token: string;
  isApprover: string;
}

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [ReactiveFormsModule, RouterLink],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  
  loginForm!: FormGroup;
  errorMessage: string = '';
  showError!: boolean;
  router = inject(Router);
  EmployeeService = inject(EmployeeServiceService);

  ngOnInit(): void {
    this.loginForm = new FormGroup({
      email: new FormControl("", [Validators.required]),
      password: new FormControl("", [Validators.required])
    })
    //this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }

  loginUser(){
    
    const userForAuth: UserForAuthenticationDto = {
      email: this.loginForm.value.email,
      password: this.loginForm.value.password
      
    }
    this.EmployeeService.loginUser( userForAuth)
    .subscribe({
      next: (res:AuthResponseDto) => {
       localStorage.setItem("token", res.token);
       localStorage.setItem("email", userForAuth.email);
       localStorage.setItem("isLoggedin", 'true' )
       
       if(res.isApprover){
        localStorage.setItem("isApprover", res.isApprover);
        this.router.navigate(['/admin-dashboard']);}
       else{
        localStorage.setItem("isApprover", res.isApprover);
        this.router.navigate(['/reimbursement']);}
    },
    error: (err: HttpErrorResponse) => {
      this.errorMessage = err.message;
      this.showError = true;
      alert("Invalid Email or password")
    }})
  }
}
