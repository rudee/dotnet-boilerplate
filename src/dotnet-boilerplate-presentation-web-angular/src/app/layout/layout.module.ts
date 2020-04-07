import { NgModule } from '@angular/core';

import { SharedModule } from '@app/shared/shared.module';

import { ContentComponent } from './components/content/content.component';
import { FooterComponent } from './components/footer/footer.component';
import { HeaderComponent } from './components/header/header.component';
import { LeftSiderComponent } from './components/left-sider/left-sider.component';

@NgModule({
  declarations: [
    ContentComponent,
    FooterComponent,
    HeaderComponent,
    LeftSiderComponent
  ],
  imports: [
    SharedModule,
  ],
  exports: [
    ContentComponent,
    FooterComponent,
    HeaderComponent,
    LeftSiderComponent
  ]
})
export class LayoutModule { }
