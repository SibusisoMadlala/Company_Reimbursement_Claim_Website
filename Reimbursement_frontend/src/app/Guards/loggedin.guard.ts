import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { EmployeeServiceService } from '../Services/employee-service.service';

export const loggedinGuard: CanActivateFn = (route, state) => {
  const router = inject(Router);
  const user = inject(EmployeeServiceService);

  if (!user.isLoggedin()){
    alert('You must be logged in to access this page');
    return router.navigate(['/app-login']);
  }

  else{
    return true;
  }
};
