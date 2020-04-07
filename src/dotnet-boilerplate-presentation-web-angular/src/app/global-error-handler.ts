import { ErrorHandler, Injectable } from '@angular/core';
import { ErrorHandlingService } from '@app/core/error-handling.service';

@Injectable()
export class GlobalErrorHandler implements ErrorHandler {

  constructor(private errorHandlingService: ErrorHandlingService) {
    console.log('GlobalErrorHandler created');
  }

  handleError(error: any): void {
    this.errorHandlingService.handleError(error);
  }
}
