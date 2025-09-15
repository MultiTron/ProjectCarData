import { Component, computed, effect, inject, signal } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { VignetteService } from './vignette.service';

@Component({
  selector: 'app-vignette',
  standalone: true,
  imports: [],
  templateUrl: './vignette.component.html',
  styleUrl: './vignette.component.scss',
})
export class Vignette {
  private _carId = signal<number | null>(null);
  private _route = inject(ActivatedRoute);
  protected _vignetteService = inject(VignetteService);

  constructor() {
    this._route.params.subscribe((params) => {
      this._carId.set(params['id']);
    });
    effect(
      () => {
        this._vignetteService.getVignetteByCarId(this._carId()!);
      },
      { allowSignalWrites: true }
    );
  }
}
