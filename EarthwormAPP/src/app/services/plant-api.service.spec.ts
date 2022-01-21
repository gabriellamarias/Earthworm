import { TestBed } from '@angular/core/testing';

import { PlantApiService } from './plant-api.service';

describe('PlantApiService', () => {
  let service: PlantApiService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PlantApiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
