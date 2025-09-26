import { Routes } from '@angular/router';
import { Home } from './home/home';
import { Dashboard } from './dashboard/dashboard';
import { Cars } from './cars/cars';
import { Toll } from './toll/toll';
import { Login } from './auth/login/login';
import { Register } from './auth/register/register';
import { authGuard } from './auth/auth-guard';

export const routes: Routes = [
  { path: '', component: Home },
  { path: 'dashboard', component: Dashboard, canActivate: [authGuard] },
  { path: 'cars', component: Cars, canActivate: [authGuard] },
  { path: 'toll/:id', component: Toll, canActivate: [authGuard] },
  { path: 'register', component: Register },
  { path: 'login', component: Login },
];
