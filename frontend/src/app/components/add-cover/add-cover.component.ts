import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { CoverService, Cover } from '../../services/cover.service';

@Component({
  selector: 'app-add-cover',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './add-cover.component.html',
  styleUrls: ['./add-cover.component.css']
})
export class AddCoverComponent {
  coverTitle: string = '';

  constructor(private coverService: CoverService) { }

  addCover(): void {
    const newCover: Cover = { title: this.coverTitle };

    this.coverService.addCover(newCover).subscribe({
      next: (response) => {
        console.log('Cover added:', response);
        this.coverTitle = '';
      },
      error: (error) => {
        console.error('Error adding cover:', error);
      }
    });
  }
}
