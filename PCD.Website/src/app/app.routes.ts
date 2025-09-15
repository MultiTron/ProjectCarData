import { Routes } from '@angular/router';
import { Home } from './home/home.component';
import { Cars } from './cars/cars.component';
import { Login } from './login/login.component';
import { authGuard } from './auth/auth.guard';
import { Vignette } from './vignette/vignette.component';

export const routes: Routes = [
  { path: '', component: Home, canActivate: [authGuard] },
  { path: 'cars', component: Cars, canActivate: [authGuard] },
  { path: 'vignette/:id', component: Vignette, canActivate: [authGuard] },
  { path: 'login', component: Login },
];
