import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { LayoutModule } from '@app/layout/layout.module';

import { SimpleLayoutRoutingModule } from './simple-layout-routing.module';
import { SimpleLayoutComponent } from './components/simple-layout/simple-layout.component';

@NgModule({
  declarations: [
    SimpleLayoutComponent
  ],
  imports: [
    CommonModule,
    SimpleLayoutRoutingModule,
    LayoutModule
  ]
})
export class SimpleLayoutModule { }
