import { Routes } from '@angular/router';
import { ArtistListComponent } from './components/artist-list/artist-list.component';
import { ArtistFormComponent } from './components/artist-form/artist-form.component';
import { CoverListComponent } from './components/cover-list/cover-list.component';
import { AddCoverComponent } from './components/add-cover/add-cover.component';
import { EditArtistComponent } from './components/edit-artist/edit-artist.component';
import { EditCoverComponent } from './components/edit-cover/edit-cover.component';
import { AssignCoverComponent } from './components/assign-cover/assign-cover.component';


export const routes: Routes = [
  { path: '', component: ArtistListComponent },
  { path: 'add-artist', component: ArtistFormComponent },
  { path: 'cover-list', component: CoverListComponent },
  { path: 'add-cover', component: AddCoverComponent },
  { path: 'edit-artist/:id', component: EditArtistComponent },
  { path: 'edit-cover/:id', component: EditCoverComponent },
  { path: 'assign-cover', component: AssignCoverComponent }
];
