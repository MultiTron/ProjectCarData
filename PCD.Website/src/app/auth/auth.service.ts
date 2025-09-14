import { Injectable, signal, computed } from '@angular/core';
import { AUTH_STORAGE_KEY } from '../../consts/consts';
import { TokenResponse } from '../interfaces/token-response';
import { UserResponse } from '../interfaces/user-response';

@Injectable({ providedIn: 'root' })
export class AuthService {
  // ✅ User state
  private _user = signal<UserResponse | null>(null);
  user = computed(() => this._user());

  // ✅ Token state
  private _token = signal<string | null>(null);
  token = computed(() => this._token());

  // ✅ Derived state
  isAuthenticated = computed(() => !!this._token());

  constructor() {
    // Load token from storage on app start
    const stored = localStorage.getItem(AUTH_STORAGE_KEY);
    if (stored) {
      const parsed = JSON.parse(stored) as {
        user: UserResponse;
        token: string;
      };
      this._user.set(parsed.user);
      this._token.set(parsed.token);
    }
  }

  login(response: TokenResponse) {
    this._user.set(response.user);
    this._token.set(response.token);

    localStorage.setItem(
      AUTH_STORAGE_KEY,
      JSON.stringify({ user: response.user, token: response.token })
    );
  }

  logout() {
    this._user.set(null);
    this._token.set(null);
    localStorage.removeItem(AUTH_STORAGE_KEY);
  }
}
