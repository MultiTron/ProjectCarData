import {
  Component,
  ChangeDetectionStrategy,
  inject,
  output,
  signal,
} from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginService } from './login.service';
import { AuthService } from '../auth/auth.service';
import { TokenResponse } from '../interfaces/token-response';

@Component({
  selector: 'app-login',
  standalone: true,
  changeDetection: ChangeDetectionStrategy.OnPush,
  imports: [ReactiveFormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss',
})
export class Login {
  protected loginService = inject(LoginService);
  protected authService = inject(AuthService);
  protected router = inject(Router);

  form = new FormGroup({
    email: new FormControl('', [Validators.required, Validators.email]),
    password: new FormControl('', [
      Validators.required,
      Validators.minLength(4),
    ]),
  });

  readonly loginSuccess = output<TokenResponse>();

  loading = signal(false);
  error = signal<string | null>(null);

  onSubmit() {
    this.loading.set(true);
    this.error.set(null);

    this.loginService
      .login(this.form.value.email!, this.form.value.password!)
      .subscribe({
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
