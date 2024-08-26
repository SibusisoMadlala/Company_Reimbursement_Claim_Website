import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

interface Bank{
  id : Number
  bankName : string
}

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
interface Employee{
  full_name: string;
  email : string;
  password :string;
  pan_number : string;
  bankId: Number;
  bank_account_number: string;
}


@Injectable({
  providedIn: 'root'
})
export class EmployeeServiceService {

  private registrationEmployeeUrl = "https://localhost:7061/api/accounts/Registration";
  private bankUrl = "https://localhost:7061/api/claims/GetAllBanks";
  private loginEmployeeUrl = "https://localhost:7061/api/accounts/Login"

  constructor(private http: HttpClient) { }

  public registerEmployee(body: Employee) : Observable<Employee> {
    return this.http.post<Employee> (this.registrationEmployeeUrl,body);
  }

  public getAllBanks() : Observable<Bank[]>{
    return this.http.get<Bank[]> (this.bankUrl)
  }

  public loginUser = ( body: UserForAuthenticationDto) => {
    return this.http.post<AuthResponseDto>(this.loginEmployeeUrl, body);
  }

  public isLoggedin() : boolean{
    return localStorage.getItem("isLoggedin")==='true';
  }

  public isAdmin() : boolean {
    return localStorage.getItem("isApprover") === 'true';
  }

}
