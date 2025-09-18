import { ChangeDetectionStrategy, Component } from '@angular/core';

@Component({
  selector: 'app-about-us',
  standalone: true,
  imports: [],

  template: `<h1>About Us</h1>
    <p>
      Welcome to our car management application. We are dedicated to providing
      the best service for managing your vehicle information efficiently and
      securely.
    </p>
    <p>
      Our team is passionate about cars and technology, ensuring that you have
      access to the latest features and updates.
    </p>
    <p>Contact us for more information or support.</p>`,

  styleUrl: './about-us.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class AboutUsComponent {}
