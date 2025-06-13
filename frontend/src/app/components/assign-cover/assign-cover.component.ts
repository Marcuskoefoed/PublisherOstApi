import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ArtistService, Artist } from '../../services/artist.service';
import { CoverService, Cover } from '../../services/cover.service';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-assign-cover',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './assign-cover.component.html',
  styleUrls: ['./assign-cover.component.css']
})
export class AssignCoverComponent {
  artists: Artist[] = [];
  covers: Cover[] = [];
  selectedArtistId: number | null = null;
  selectedCoverId: number | null = null;

  private apiUrl = 'http://localhost:5155/api/artistcovers';

  constructor(
    private artistService: ArtistService,
    private coverService: CoverService,
    private http: HttpClient
  ) { }

  ngOnInit(): void {
    this.loadArtists();
    this.loadCovers();
  }

  loadArtists(): void {
    this.artistService.getArtists().subscribe({
      next: (data: Artist[]) => {
        this.artists = data;
      },
      error: (error: any) => {
        console.error('Error loading artists:', error);
      }
    });
  }

  loadCovers(): void {
    this.coverService.getCovers().subscribe({
      next: (data: Cover[]) => {
        this.covers = data;
      },
      error: (error: any) => {
        console.error('Error loading covers:', error);
      }
    });
  }

  assignCover(): void {
    if (this.selectedArtistId && this.selectedCoverId) {
      const assignment = {
        artistId: this.selectedArtistId,
        coverId: this.selectedCoverId
      };

      this.http.post(`${this.apiUrl}`, assignment).subscribe({
        next: () => {
          console.log('Cover assigned to artist.');
          this.selectedArtistId = null;
          this.selectedCoverId = null;
        },
        error: (error: any) => {
          console.error('Error assigning cover:', error);
        }
      });
    }
  }
}
