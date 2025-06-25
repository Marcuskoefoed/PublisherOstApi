import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    loadComponent: () => import('./components/artist-list/artist-list.component').then(m => m.ArtistListComponent)
  },
  {
    path: 'add-artist',
    loadComponent: () => import('./components/artist-form/artist-form.component').then(m => m.ArtistFormComponent)
  },
  {
    path: 'cover-list',
    loadComponent: () => import('./components/cover-list/cover-list.component').then(m => m.CoverListComponent)
  },
  {
    path: 'add-cover',
    loadComponent: () => import('./components/add-cover/add-cover.component').then(m => m.AddCoverComponent)
  },
  {
    path: 'edit-artist/:id',
    loadComponent: () => import('./components/edit-artist/edit-artist.component').then(m => m.EditArtistComponent)
  },
  {
    path: 'edit-cover/:id',
    loadComponent: () => import('./components/edit-cover/edit-cover.component').then(m => m.EditCoverComponent)
  },
  {
    path: 'assign-cover',
    loadComponent: () => import('./components/assign-cover/assign-cover.component').then(m => m.AssignCoverComponent)
  }
];
