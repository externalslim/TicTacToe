import { Routes } from '@angular/router';

import { AdminLayoutComponent } from './layouts/admin-layout/admin-layout.component';
import { UserLoginComponent } from 'app/account/user/login/user-login/user-login.component';
import { UserRegisterComponent } from './account/user/register/user-register/user-register.component';
export const AppRoutes: Routes = [
  // {
  //   path: '',
  //   redirectTo: 'dashboard',
  //   pathMatch: 'full',
  // },
  // {
  //   path: '**',
  //   redirectTo: 'xox-main'
  // }, 
  {
    path: '',
    component: AdminLayoutComponent,
    children: [
        {
      path: '',
      loadChildren: './layouts/admin-layout/admin-layout.module#AdminLayoutModule'
  }]},
  {
    path: 'user-login',
    component: UserLoginComponent
  },
  {
    path: 'user-register',
    component: UserRegisterComponent
  },
  
]
