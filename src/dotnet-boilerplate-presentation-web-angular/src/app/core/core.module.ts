import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
// import { ErrorHandlingService } from '@app/core/error-handling.service';
// import { LoggingService } from '@app/core/logging.service';

@NgModule({
  declarations: [],
  imports: [
    CommonModule
  ]
})
export class CoreModule {

  constructor() {
    console.log('CoreModule created');
  }
}
