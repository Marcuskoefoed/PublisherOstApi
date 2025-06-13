import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ArtistService, Artist } from '../../services/artist.service';

@Component({
  selector: 'app-edit-artist',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './edit-artist.component.html',
  styleUrls: ['./edit-artist.component.css']
})
export class EditArtistComponent {
  artistId: number = 0;
  artist: Artist = { name: '' };

  constructor(
    private route: ActivatedRoute,
    private artistService: ArtistService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.artistId = Number(this.route.snapshot.paramMap.get('id'));
    this.loadArtist();
  }

  loadArtist(): void {
    this.artistService.getArtist(this.artistId).subscribe({
      next: (data: Artist) => {
        this.artist = data;
      },
      error: (error: any) => {
        console.error('Error loading artist:', error);
      }
    });
  }

  updateArtist(): void {
    this.artistService.updateArtist(this.artistId, this.artist).subscribe({
      next: () => {
        console.log('Artist updated successfully.');
        this.router.navigate(['/']);
      },
      error: (error: any) => {
        console.error('Error updating artist:', error);
      }
    });
  }
}
