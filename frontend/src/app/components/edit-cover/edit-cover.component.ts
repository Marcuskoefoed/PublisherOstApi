import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { CoverService, Cover } from '../../services/cover.service';

@Component({
  selector: 'app-edit-cover',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './edit-cover.component.html',
  styleUrls: ['./edit-cover.component.css']
})
export class EditCoverComponent {
  coverId: number = 0;
  cover: Cover = { title: '' };

  constructor(
    private route: ActivatedRoute,
    private coverService: CoverService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.coverId = Number(this.route.snapshot.paramMap.get('id'));
    this.loadCover();
  }

  loadCover(): void {
    this.coverService.getCover(this.coverId).subscribe({
      next: (data: Cover) => {
        this.cover = data;
      },
      error: (error: any) => {
        console.error('Error loading cover:', error);
      }
    });
  }

  updateCover(): void {
    this.coverService.updateCover(this.coverId, this.cover).subscribe({
      next: () => {
        console.log('Cover updated successfully.');
        this.router.navigate(['/cover-list']);
      },
      error: (error: any) => {
        console.error('Error updating cover:', error);
      }
    });
  }
}
