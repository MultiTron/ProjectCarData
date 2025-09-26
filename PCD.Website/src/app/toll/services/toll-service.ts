import { Injectable, computed, inject, signal } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { API_URL } from '../../consts';
import { AuthService } from '../../auth/services/auth-service';
import { ApiTollResponse } from '../interfaces/api-toll-response';

@Injectable({
  providedIn: 'root',
})
export class TollService {
  protected readonly http = inject(HttpClient);
  protected readonly authService = inject(AuthService);

  readonly toll = signal<ApiTollResponse | null>(null);
  readonly loading = signal(false);
  readonly error = signal<string | null>(null);

  constructor() {}

  getTollByCarId(carId: number) {
    this.loading.set(true);
    this.error.set(null);
    if (this.authService.isAuthenticated()) {
      return this.http.get<ApiTollResponse>(`${API_URL}cars/getTollInfo/car/${carId}`).subscribe({
        next: (res) => {
          this.loading.set(false);
          this.toll.set(res);
        },
        error: (err) => {
          this.loading.set(false);
          this.error.set(`Failed to load toll: ${err}`);
        },
      });
    }
    return null;
  }
}
