import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Artist {
  artistId?: number;
  name: string;
}

@Injectable({
  providedIn: 'root'
})
export class ArtistService {
  private apiUrl = 'http://localhost:5155/api/artists';

  constructor(private http: HttpClient) { }

  getArtists(): Observable<Artist[]> {
    const headers = this.getAuthHeaders();
    return this.http.get<Artist[]>(this.apiUrl, { headers });
  }

  getArtist(id: number): Observable<Artist> {
    const headers = this.getAuthHeaders();
    return this.http.get<Artist>(`${this.apiUrl}/${id}`, { headers });
  }

  addArtist(artist: Artist): Observable<Artist> {
    const headers = this.getAuthHeaders();
    return this.http.post<Artist>(this.apiUrl, artist, { headers });
  }

  updateArtist(id: number, artist: Artist): Observable<void> {
    const headers = this.getAuthHeaders();
    return this.http.put<void>(`${this.apiUrl}/${id}`, artist, { headers });
  }

  deleteArtist(id: number): Observable<void> {
    const headers = this.getAuthHeaders();
    return this.http.delete<void>(`${this.apiUrl}/${id}`, { headers });
  }

  private getAuthHeaders(): HttpHeaders {
    const token = localStorage.getItem('jwtToken');
    return new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}`
    });
  }
}
