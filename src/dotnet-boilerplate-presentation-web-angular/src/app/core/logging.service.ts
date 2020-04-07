import { Injectable } from '@angular/core';
import { CoreModule } from '@app/core/core.module';

@Injectable({
  providedIn: CoreModule
})
export class LoggingService {

  private timestamp: string;

  constructor() {
    this.timestamp = new Date().toISOString();
    console.log(`LoggingService created: ${this.timestamp}`);
  }

  log(message: string): void {
    console.log(`${message}: ${this.timestamp}`);
  }

  error(message: string): void {
    console.error(`${message}: ${this.timestamp}`);
  }
}
