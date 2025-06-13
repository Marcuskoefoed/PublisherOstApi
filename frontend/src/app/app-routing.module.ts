import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ArtistListComponent } from './components/artist-list/artist-list.component';
import { ArtistFormComponent } from './components/artist-form/artist-form.component';

const routes: Routes = [
  { path: '', component: ArtistListComponent },
  { path: 'add-artist', component: ArtistFormComponent },
  { path: 'edit-artist/:id', component: ArtistFormComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
