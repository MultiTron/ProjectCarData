import { Routes } from '@angular/router';
import { Home } from './home/home.component';
import { Login } from './login/login.component';
import { authGuard } from './auth/auth.guard';

export const routes: Routes = [
  { path: '', component: Home, canActivate: [authGuard] },
  { path: 'login', component: Login },
];
