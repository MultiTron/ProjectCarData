import { Injectable, inject, signal, computed } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { API_BASE_URL } from '../../consts/consts';
import { AuthService } from '../auth/auth.service';
import { CarResponse } from '../interfaces/car-response';
import { CarsResponse } from '../interfaces/cars-response';
import { CreateCarRequest } from '../interfaces/create-car-request';

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

  addCar(car: CreateCarRequest) {
    if (this.authService.isAuthenticated()) {
      this._loading.set(true);
      this._error.set(null);
      this.http
        .post<CarResponse>(`${API_BASE_URL}cars`, {
          brand: car.brand,
          model: car.model,
          year: car.year,
          countryOfRegistration: car.countryOfRegistration,
          licensePlateNumber: car.licensePlateNumber,
          vin: car.vin,
          userId: this.authService.user()?.id,
        })
        .subscribe({
          next: () => {
            this._loading.set(false);
            this.getCars();
          },
          error: (err) => {
            this._loading.set(false);
            this._error.set(`Failed to add car: ${err.message}`);
          },
        });
    }
  }

  updateCar(carId: number, car: CreateCarRequest) {
    if (this.authService.isAuthenticated()) {
      this._loading.set(true);
      this._error.set(null);
      this.http
        .put<CarResponse>(`${API_BASE_URL}cars/car/${carId}`, {
          brand: car.brand,
          model: car.model,
          year: car.year,
          countryOfRegistration: car.countryOfRegistration,
          licensePlateNumber: car.licensePlateNumber,
          vin: car.vin,
          userId: this.authService.user()?.id,
        })
        .subscribe({
          next: () => {
            this._loading.set(false);
            this.getCars();
          },
          error: (err) => {
            this._loading.set(false);
            this._error.set(`Failed to update car: ${err.message}`);
          },
        });
    }
  }
}
