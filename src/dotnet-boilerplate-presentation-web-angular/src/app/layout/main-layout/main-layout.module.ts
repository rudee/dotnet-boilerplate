import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { LayoutModule } from '@app/layout/layout.module';

import { MainLayoutRoutingModule } from './main-layout-routing.module';
import { MainLayoutComponent } from './components/main-layout/main-layout.component';

@NgModule({
  declarations: [
    MainLayoutComponent
  ],
  imports: [
    CommonModule,
    MainLayoutRoutingModule,
    LayoutModule
  ]
})
export class MainLayoutModule { }
