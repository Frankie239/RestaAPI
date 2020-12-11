import { TestBed } from '@angular/core/testing';

import { GuardPageService } from './guard-page.service';

describe('GuardPageService', () => {
  let service: GuardPageService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(GuardPageService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
