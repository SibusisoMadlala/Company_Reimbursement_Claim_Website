import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { EmployeeServiceService } from '../Services/employee-service.service';

export const adminGuard: CanActivateFn = (route, state) => {
  const user = inject(EmployeeServiceService);
  const router = inject(Router)

  if(!user.isAdmin()){
    alert('Admin can only access');
    return router.navigate(['/app-login']);
  }
  else{
    return true;
  }
};
