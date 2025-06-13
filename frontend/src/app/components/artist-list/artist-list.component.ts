import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { ArtistService, Artist } from '../../services/artist.service';

@Component({
  selector: 'app-artist-list',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './artist-list.component.html',
  styleUrls: ['./artist-list.component.css']
})
export class ArtistListComponent implements OnInit {
  artists: Artist[] = [];

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
