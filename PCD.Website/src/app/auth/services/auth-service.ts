import { Injectable, signal, computed } from '@angular/core';
import { AUTH_STORAGE_KEY } from '../../consts';
import { ApiTokenResponse } from '../interfaces/api-token-response';
import { ApiUserResponse } from '../interfaces/api-user-response';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private _user = signal<ApiUserResponse | null>(null);
  user = computed(() => this._user());

  private _token = signal<string | null>(null);
  token = computed(() => this._token());

  isAuthenticated = computed(() => !!this._token());

  constructor() {
    const stored = localStorage.getItem(AUTH_STORAGE_KEY);
    if (stored) {
      const parsed = JSON.parse(stored) as {
        user: ApiUserResponse;
        token: string;
      };
      this._user.set(parsed.user);
      this._token.set(parsed.token);
    }
  }

  login(response: ApiTokenResponse) {
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
