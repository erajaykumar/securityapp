import { TestBed } from '@angular/core/testing';

import { Authservice2Service } from './authservice2.service';

describe('Authservice2Service', () => {
  let service: Authservice2Service;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(Authservice2Service);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
