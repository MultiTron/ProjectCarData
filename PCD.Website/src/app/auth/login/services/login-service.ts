import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { API_URL } from '../../../consts';
import { ApiTokenResponse } from '../../interfaces/api-token-response';

@Injectable({
  providedIn: 'root',
})
export class LoginService {
  protected readonly http = inject(HttpClient);

  constructor() {}

  login(email: string, password: string) {
    return this.http.get<ApiTokenResponse>(`${API_URL}users/login`, {
      params: { email, password },
    });
  }
}
