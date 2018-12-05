import { TestBed } from '@angular/core/testing';

import { DutchArtService } from './dutch-art.service';

describe('DutchArtService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: DutchArtService = TestBed.get(DutchArtService);
    expect(service).toBeTruthy();
  });
});
