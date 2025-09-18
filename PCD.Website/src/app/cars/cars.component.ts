import { Component, effect, inject, signal } from '@angular/core';
import {
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { RouterLink } from '@angular/router';
import { CarService } from './car.service';

@Component({
  selector: 'app-cars',
  imports: [RouterLink, ReactiveFormsModule],
  templateUrl: './cars.component.html',
  styleUrl: './cars.component.scss',
})
export class Cars {
  protected carService = inject(CarService);

  protected isFormActive = signal(false);
  protected isUpdate = signal(false);
  protected carUpdateId = signal<number | null>(null);

  form = new FormGroup({
    brand: new FormControl('', Validators.required),
    model: new FormControl('', Validators.required),
    year: new FormControl(2025, [Validators.required, Validators.min(1900)]),
    countryOfRegistration: new FormControl('', Validators.required),
    licensePlateNumber: new FormControl('', Validators.required),
    vin: new FormControl('', [
      Validators.required,
      Validators.pattern(/\b[(A-H|J-N|P|R-Z|0-9)]{17}\b/gm),
    ]),
  });

  constructor() {
    effect(
      () => {
        this.carService.getCars();
      },
      { allowSignalWrites: true }
    );
  }

  showAddForm() {
    this.isUpdate.set(false);
    this.isFormActive.set(true);
  }

  showUpdateForm(carId: number) {
    this.carUpdateId.set(carId);
    this.isUpdate.set(true);
    this.isFormActive.set(true);
  }

  closeForm() {
    this.isFormActive.set(false);
    this.form.reset();
  }

  submitForm() {
    if (this.isUpdate()) {
      if (this.form.valid) {
        this.carService.updateCar(this.carUpdateId()!, {
          brand: this.form.value.brand!,
          model: this.form.value.model!,
          year: this.form.value.year!,
          licensePlateNumber: this.form.value.licensePlateNumber!,
          countryOfRegistration: this.form.value.countryOfRegistration!,
          vin: this.form.value.vin!,
        });
      }
    } else {
      if (this.form.valid) {
        this.carService.addCar({
          brand: this.form.value.brand!,
          model: this.form.value.model!,
          year: this.form.value.year!,
          licensePlateNumber: this.form.value.licensePlateNumber!,
          countryOfRegistration: this.form.value.countryOfRegistration!,
          vin: this.form.value.vin!,
        });
      }
    }
    this.closeForm();
  }
}
