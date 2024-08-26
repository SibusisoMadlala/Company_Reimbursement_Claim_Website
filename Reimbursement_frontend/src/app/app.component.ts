import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { RegisterComponent } from './Components/Employee/register/register.component';
import { LoginComponent } from './Components/Employee/login/login.component';
import { ReimbursementComponent } from './Components/Employee/reimbursement/reimbursement.component';
import { DashboardComponent } from './Components/Admin/dashboard/dashboard.component';
import { NavbarComponent } from './Components/shared/navbar/navbar.component';
import { LogoutComponent } from './Components/Employee/logout/logout.component';
import { PagenotfoundComponent } from './Components/shared/pagenotfound/pagenotfound.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, RegisterComponent, LoginComponent, ReimbursementComponent,DashboardComponent,NavbarComponent, LogoutComponent,PagenotfoundComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'Reimbursement';
}
