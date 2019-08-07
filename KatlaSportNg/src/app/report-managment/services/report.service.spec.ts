import { TestBed, inject } from '@angular/core/testing';

import { AccountantService } from './accountant.service';

describe('AccountantService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AccountantService]
    });
  });

  it('should be created', inject([AccountantService], (service: AccountantService) => {
    expect(service).toBeTruthy();
  }));
});
