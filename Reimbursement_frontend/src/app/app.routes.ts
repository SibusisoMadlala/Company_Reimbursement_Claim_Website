import { Routes } from '@angular/router';
import { LoginComponent } from './Components/Employee/login/login.component';
import { ReimbursementComponent } from './Components/Employee/reimbursement/reimbursement.component';
import { DashboardComponent } from './Components/Admin/dashboard/dashboard.component';
import { RegisterComponent } from './Components/Employee/register/register.component';
import { LogoutComponent } from './Components/Employee/logout/logout.component';
import { adminGuard } from './Guards/admin.guard';
import { loggedinGuard } from './Guards/loggedin.guard';
import { PagenotfoundComponent } from './Components/shared/pagenotfound/pagenotfound.component';


export const routes: Routes = [
    {path : "user-login", component: LoginComponent },
    
    {path: "admin-dashboard", component : DashboardComponent,
        canActivate: [adminGuard]
    },
    {path : "register", component: RegisterComponent},
    {path : "reimbursement", component : ReimbursementComponent,
        canActivate: [loggedinGuard]
    },
    {path : "logout", component : LogoutComponent},
    {path: '**', component: LoginComponent},
    {path: '', redirectTo: '/user-login', pathMatch: 'full'}
];
