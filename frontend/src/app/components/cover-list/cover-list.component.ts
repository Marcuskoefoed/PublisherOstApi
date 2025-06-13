import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { CoverService, Cover } from '../../services/cover.service';

@Component({
  selector: 'app-cover-list',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './cover-list.component.html',
  styleUrls: ['./cover-list.component.css']
})
export class CoverListComponent {
  covers: Cover[] = [];

  constructor(private coverService: CoverService) { }

  ngOnInit(): void {
    this.loadCovers();
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

  deleteCover(id: number | undefined): void {
    if (id !== undefined) {
      this.coverService.deleteCover(id).subscribe({
        next: () => {
          this.covers = this.covers.filter(cover => cover.coverId !== id);
          console.log(`Cover with ID ${id} deleted`);
        },
        error: (error: any) => {
          console.error('Error deleting cover:', error);
        }
      });
    }
  }
}
