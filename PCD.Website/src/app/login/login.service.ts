import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { API_BASE_URL } from '../../consts/consts';
import { TokenResponse } from '../interfaces/token-response';

@Injectable({
  providedIn: 'root',
})
export class LoginService {
  protected http = inject(HttpClient);

  constructor() {}

  login(email: string, password: string) {
    return this.http.get<TokenResponse>(`${API_BASE_URL}users/login`, {
      params: { email, password },
    });
  }
}
