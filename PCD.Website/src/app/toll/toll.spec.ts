import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Toll } from './toll';

describe('Toll', () => {
  let component: Toll;
  let fixture: ComponentFixture<Toll>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Toll]
    })
    .compileComponents();

    fixture = TestBed.createComponent(Toll);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
