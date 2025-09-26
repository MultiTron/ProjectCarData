import { Component, input, output, inject } from '@angular/core';
import { ReactiveFormsModule, NonNullableFormBuilder, Validators } from '@angular/forms';
import { CarService } from '../services/car-service';

@Component({
  selector: 'app-update-car',
  imports: [ReactiveFormsModule],
  templateUrl: './update-car.html',
  styleUrl: './update-car.scss',
})
export class UpdateCar {
  protected readonly carService = inject(CarService);
  protected readonly fb = inject(NonNullableFormBuilder);

  readonly carId = input<number>();
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
      this.carService.updateCar(this.carId()!, this.form.getRawValue());
      this.form.reset();
    }
  }
}
