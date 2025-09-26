import { Component, ChangeDetectionStrategy, inject, output, signal } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginService } from './services/login-service';
import { AuthService } from '../services/auth-service';
import { ApiTokenResponse } from '../interfaces/api-token-response';

@Component({
  selector: 'app-login',
  imports: [ReactiveFormsModule],
  templateUrl: './login.html',
  styleUrl: './login.scss',
})
export class Login {
  protected readonly loginService = inject(LoginService);
  protected readonly authService = inject(AuthService);
  protected readonly router = inject(Router);

  protected readonly loginSuccess = output<ApiTokenResponse>();
  protected readonly loading = signal(false);
  protected readonly error = signal<string | null>(null);

  form = new FormGroup({
    email: new FormControl('', [Validators.required, Validators.email]),
    password: new FormControl('', [Validators.required, Validators.minLength(4)]),
  });

  onSubmit() {
    this.loading.set(true);
    this.error.set(null);

    this.loginService.login(this.form.value.email!, this.form.value.password!).subscribe({
      next: (response) => {
        this.loading.set(false);
        if (response.statusCode === 200) {
          this.authService.login(response);
          this.loginSuccess.emit(response);
          this.router.navigate(['/']);
        } else {
          this.error.set('Login failed');
        }
      },
      error: (err) => {
        this.loading.set(false);
        this.error.set(err.message || 'An error occurred during login');
      },
    });
  }
}
