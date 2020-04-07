import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PageNotFoundComponent } from '@app/error/page-not-found/page-not-found.component';
import { HomeComponent } from '@app/home/home.component';
import { SimpleLayoutComponent } from '@app/layout/simple-layout/components/simple-layout/simple-layout.component';

//import { MainLayoutComponent } from '@app/layout/main-layout/components/main-layout/main-layout.component';

const routes: Routes = [
  // { path: '', component: HomeComponent },
  // { path: 'characters', loadChildren: () => import('./characters/characters.module').then(m => m.CharactersModule) },

  // { path: '', loadChildren: () => import('@app/layout/simple-layout/simple-layout.module').then(m => m.SimpleLayoutModule) },

  // { path: '', component: MainLayoutComponent, loadChildren: () => import('@app/layout/main-layout/main-layout.module').then(m => m.MainLayoutModule) },
  { path: '', component: SimpleLayoutComponent, loadChildren: () => import('@app/layout/simple-layout/simple-layout.module').then(m => m.SimpleLayoutModule) },

  // { path: 'test', loadChildren: () => import('./layout/simple-layout/simple-layout.module').then(m => m.SimpleLayoutModule) },

  // { path: 'login', loadChildren: () => import('./layout/simple-layout/simple-layout.module').then(m => m.SimpleLayoutModule) },
  // { path: 'login', loadChildren: () => import('./layout/auth-layout.module').then(m => m.CharactersModule) },

  // { path: '**', component: PageNotFoundComponent }
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class AppRoutingModule { }
