import { Component, inject } from '@angular/core';
import { Router } from '@angular/router';
import { RouterLink } from '@angular/router';
import { EmployeeServiceService } from '../../../Services/employee-service.service';

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css'
})
export class NavbarComponent {

  router = inject(Router);
  user = inject(EmployeeServiceService)

  logout(){
    localStorage.clear();
    this.router.navigate(['/user-login'])
  }
}
