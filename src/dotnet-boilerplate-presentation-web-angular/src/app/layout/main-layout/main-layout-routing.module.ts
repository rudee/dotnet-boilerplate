import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from '@app/home/home.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'main', component: HomeComponent },
  { path: 'characters', loadChildren: () => import('@app/characters/characters.module').then(m => m.CharactersModule) },
];

@NgModule({
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
})
export class MainLayoutRoutingModule { }
