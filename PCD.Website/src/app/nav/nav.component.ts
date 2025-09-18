import { Component, inject } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { AuthService } from '../auth/auth.service';

@Component({
    selector: 'app-nav',
    imports: [RouterLink],
    templateUrl: './nav.component.html',
    styleUrl: './nav.component.scss'
})
export class Nav {
  protected authService = inject(AuthService);
  protected router = inject(Router);

  logout() {
    this.authService.logout();
    this.router.navigate(['/login']);
  }
}
