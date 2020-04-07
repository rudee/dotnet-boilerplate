import { TestBed } from '@angular/core/testing';

import { GlobalErrorHandler } from './global-error-handler';

// describe('GlobalErrorHandler', () => {
//   it('should create an instance', () => {
//     expect(new GlobalErrorHandler()).toBeTruthy();
//   });
// });

describe('GlobalErrorHandler', () => {
  let service: GlobalErrorHandler;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(GlobalErrorHandler);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
