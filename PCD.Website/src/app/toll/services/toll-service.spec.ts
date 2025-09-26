import { TestBed } from '@angular/core/testing';

import { TollService } from './toll-service';

describe('TollService', () => {
  let service: TollService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TollService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
