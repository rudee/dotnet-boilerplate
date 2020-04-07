import { Injectable } from '@angular/core';
import { CoreModule } from '@app/core/core.module';
import { LoggingService } from '@app/core/logging.service';

@Injectable({
  providedIn: CoreModule
})
export class ErrorHandlingService {

  constructor(private loggingService: LoggingService) {
    console.log('ErrorHandlingService created');
  }

  log(message: string): void {
    this.loggingService.log(message);
  }

  handleError(error: any): void {
    this.loggingService.error(error);
  }
}
