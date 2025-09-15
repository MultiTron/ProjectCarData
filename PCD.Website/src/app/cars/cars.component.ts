import { Component, effect, inject } from '@angular/core';
import { CarService } from './car.service';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-cars',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './cars.component.html',
  styleUrl: './cars.component.scss',
})
export class Cars {
  protected carService = inject(CarService);

  constructor() {
    effect(
      () => {
        //if (!this.carService.cars()) {
        this.carService.getCars();
        //}
      },
      { allowSignalWrites: true }
    );
  }
}
