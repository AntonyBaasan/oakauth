import { TestBed } from '@angular/core/testing';
import {
  HttpClientTestingModule,
} from '@angular/common/http/testing';

import { ApplicationsService } from './applications.service';

describe('ApplicationsService', () => {
  beforeEach(() => TestBed.configureTestingModule({
    imports: [HttpClientTestingModule]
  }));

  it('should be created', () => {
    const service: ApplicationsService = TestBed.get(ApplicationsService);
    expect(service).toBeTruthy();
  });
});
