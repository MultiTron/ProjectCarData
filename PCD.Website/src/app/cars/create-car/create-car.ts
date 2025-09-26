import { Component, output, inject } from '@angular/core';
import { ReactiveFormsModule, NonNullableFormBuilder, Validators } from '@angular/forms';
import { CarService } from '../services/car-service';

@Component({
  selector: 'app-create-car',
  imports: [ReactiveFormsModule],
  templateUrl: './create-car.html',
  styleUrl: './create-car.scss',
})
export class CreateCar {
  protected readonly carService = inject(CarService);
  protected readonly fb = inject(NonNullableFormBuilder);

  readonly cancel = output<void>();

  readonly form = this.fb.group({
    brand: this.fb.control('', Validators.required),
    model: this.fb.control('', Validators.required),
    year: this.fb.control(2025, [Validators.required, Validators.min(1900)]),
    countryOfRegistration: this.fb.control('', Validators.required),
    licensePlateNumber: this.fb.control('', Validators.required),
    vin: this.fb.control('', [
      Validators.required,
      Validators.pattern(/\b[(A-H|J-N|P|R-Z|0-9)]{17}\b/gm),
    ]),
  });

  submit() {
    if (this.form.valid) {
      this.carService.addCar(this.form.getRawValue());
      this.form.reset();
    }
  }
}
