/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { SharedLookUpsService } from './Shared-Look-Ups.service';

describe('Service: SharedLookUps', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [SharedLookUpsService]
    });
  });

  it('should ...', inject([SharedLookUpsService], (service: SharedLookUpsService) => {
    expect(service).toBeTruthy();
  }));
});
