import { Component, effect, inject, signal } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { RouterLink } from '@angular/router';
import { CarService } from './services/car-service';
import { UpdateCar } from './update-car/update-car';
import { CreateCar } from './create-car/create-car';

@Component({
  selector: 'app-cars',
  imports: [RouterLink, CreateCar, UpdateCar, ReactiveFormsModule],
  templateUrl: './cars.html',
  styleUrl: './cars.scss',
})
export class Cars {
  protected carService = inject(CarService);

  protected isAddFormActive = signal(false);
  protected isUpdateFormActive = signal(false);
  protected carUpdateId = signal<number | null>(null);

  constructor() {
    effect(
      () => {
        this.carService.getCars();
      },
      { allowSignalWrites: true }
    );
  }

  showAddForm() {
    this.isAddFormActive.set(true);
  }

  showUpdateForm(carId: number) {
    this.carUpdateId.set(carId);
    this.isUpdateFormActive.set(true);
  }

  closeAddForm() {
    this.isAddFormActive.set(false);
  }

  closeUpdateForm() {
    this.isAddFormActive.set(false);
  }
}
