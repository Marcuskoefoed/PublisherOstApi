import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Cover {
  coverId?: number;
  title: string;
}

@Injectable({
  providedIn: 'root'
})
export class CoverService {
  private apiUrl = 'http://localhost:5155/api/covers';

  constructor(private http: HttpClient) { }

  getCovers(): Observable<Cover[]> {
    return this.http.get<Cover[]>(this.apiUrl);
  }

  getCover(id: number): Observable<Cover> {
    return this.http.get<Cover>(`${this.apiUrl}/${id}`);
  }

  addCover(cover: Cover): Observable<Cover> {
    return this.http.post<Cover>(this.apiUrl, cover);
  }

  updateCover(id: number, cover: Cover): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${id}`, cover);
  }

  deleteCover(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
