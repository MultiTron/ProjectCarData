import { Injectable, computed, inject, signal } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { API_BASE_URL } from '../../consts/consts';
import { AuthService } from '../auth/auth.service';
import { VignetteResponse } from '../interfaces/vignette-response';

@Injectable({
  providedIn: 'root',
})
export class VignetteService {
  private http = inject(HttpClient);
  private authService = inject(AuthService);

  private _vignette = signal<VignetteResponse | null>(null);
  vignette = computed(() => this._vignette());
  private _loading = signal(false);
  loading = computed(() => this._loading());
  private _error = signal<string | null>(null);
  error = computed(() => this._error());

  constructor() {}

  getVignetteByCarId(carId: number) {
    this._loading.set(true);
    this._error.set(null);
    if (this.authService.isAuthenticated()) {
      return this.http
        .get<VignetteResponse>(`${API_BASE_URL}cars/getTollInfo/car/${carId}`)
        .subscribe({
          next: (res) => {
            this._loading.set(false);
            this._vignette.set(res);
          },
          error: (err) => {
            this._loading.set(false);
            this._error.set(`Failed to load vignette: ${err}`);
          },
        });
    }
    return null;
  }
}
