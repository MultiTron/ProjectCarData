import { Component, effect, inject, signal } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TollService } from './services/toll-service';

@Component({
  selector: 'app-toll',
  imports: [],
  templateUrl: './toll.html',
  styleUrl: './toll.scss',
})
export class Toll {
  protected readonly carId = signal<number | null>(null);
  protected readonly route = inject(ActivatedRoute);

  protected readonly tollService = inject(TollService);

  constructor() {
    this.route.params.subscribe((params) => {
      this.carId.set(params['id']);
    });
    effect(
      () => {
        this.tollService.getTollByCarId(this.carId()!);
      },
      { allowSignalWrites: true }
    );
  }
}
