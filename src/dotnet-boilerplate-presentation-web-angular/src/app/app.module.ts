import { HttpClientModule } from '@angular/common/http';
import { ErrorHandler, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from '@app/app-routing.module';
import { AppComponent } from '@app/app.component';
import { CoreModule } from '@app/core/core.module';
import { GlobalErrorHandler } from '@app/global-error-handler';
// import { SharedModule } from '@app/layout/layout.module';
import { SharedModule } from '@app/shared/shared.module';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    // LayoutModule,
    AppRoutingModule,
    SharedModule,
    CoreModule
  ],
  providers: [
    { provide: ErrorHandler, useClass: GlobalErrorHandler }
  ],
  bootstrap: [
    AppComponent
  ]
})
export class AppModule { }
