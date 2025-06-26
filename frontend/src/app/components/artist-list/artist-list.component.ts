import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { ArtistService, Artist } from '../../services/artist.service';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-artist-list',
  standalone: true,
  imports: [CommonModule, RouterModule, FormsModule],
  templateUrl: './artist-list.component.html',
  styleUrls: ['./artist-list.component.css']
})
export class ArtistListComponent implements OnInit {
  artists: Artist[] = [];
  editingArtistId: number | null = null; 

  constructor(private artistService: ArtistService) { }

  ngOnInit(): void {
    this.loadArtists();
  }

  loadArtists(): void {
    this.artistService.getArtists().subscribe({
      next: (data: Artist[]) => {
        console.log('Artists received:', data);
        this.artists = data;
      },
      error: (error: any) => {
        console.error('Error fetching artists:', error);
      }
    });
  }

  updateArtist(artist: Artist): void {
    if (artist.artistId === undefined || !artist.name.trim()) {
      console.warn('Invalid artist data');
      return;
    }

    this.artistService.updateArtist(artist.artistId, artist).subscribe({
      next: () => {
        console.log(`Updated artist ${artist.artistId}`);
        this.editingArtistId = null; 
      },
      error: (error) => {
        console.error('Error updating artist:', error);
      }
    });
  }

  editArtist(artist: Artist): void {
    this.editingArtistId = artist.artistId ?? null;
  }

  deleteArtist(id: number | undefined): void {
    if (id !== undefined) {
      this.artistService.deleteArtist(id).subscribe({
        next: () => {
          this.artists = this.artists.filter(artist => artist.artistId !== id);
          console.log(`Artist with ID ${id} deleted`);
        },
        error: (error: any) => {
          console.error('Error deleting artist:', error);
        }
      });
    }
  }
}
