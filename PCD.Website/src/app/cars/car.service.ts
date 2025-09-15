import { Injectable, inject, signal, computed } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { API_BASE_URL } from '../../consts/consts';
import { AuthService } from '../auth/auth.service';
import { CarResponse } from '../interfaces/car-response';
import { CarsResponse } from '../interfaces/cars-response';

@Injectable({
  providedIn: 'root',
})
export class CarService {
  protected http = inject(HttpClient);
  protected authService = inject(AuthService);

  private _cars = signal<CarResponse[]>([]);
  cars = computed(() => this._cars());
  private _loading = signal(false);
  loading = computed(() => this._loading());
  private _error = signal<string | null>(null);
  error = computed(() => this._error());

  constructor() {}

  getCars() {
    if (this.authService.isAuthenticated()) {
      this._loading.set(true);
      this._error.set(null);
      this.http
        .get<CarsResponse>(
          `${API_BASE_URL}users/user/${this.authService.user()?.id}/cars`
        )
        .subscribe({
          next: (res) => {
            this._loading.set(false);
            this._cars.set(res.content);
          },
          error: (err) => {
            this._loading.set(false);
            this._error.set(`Failed to load cars: ${err.message}`);
          },
        });
    }
  }
}
