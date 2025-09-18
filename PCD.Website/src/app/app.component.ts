import { Component } from '@angular/core';

import { RouterOutlet } from '@angular/router';
import { Nav } from './nav/nav.component';

@Component({
    selector: 'app-root',
    imports: [RouterOutlet, Nav],
    templateUrl: './app.component.html',
    styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'PCD.Website';
}
