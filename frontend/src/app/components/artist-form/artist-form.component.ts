import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ArtistService, Artist } from '../../services/artist.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-artist-form',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './artist-form.component.html',
  styleUrls: ['./artist-form.component.css']
})
export class ArtistFormComponent {
  artistName: string = '';

  constructor(private artistService: ArtistService, private router: Router) { }

  addArtist(): void {
    console.log('Add Artist button pressed. Artist Name:', this.artistName);

    if (!this.artistName.trim()) {
      console.warn('Artist name is required.');
      return;
    }

    const newArtist: Artist = { name: this.artistName };

    this.artistService.addArtist(newArtist).subscribe({
      next: (response: Artist) => {
        console.log('Artist added successfully:', response);
        this.artistName = '';
        this.router.navigate(['/']);
      },
      error: (error: any) => {
        console.error('Error adding artist:', error);
      }
    });
  }
}
