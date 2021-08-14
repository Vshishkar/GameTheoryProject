import { Game } from './game';
import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class GameManagementService {

  constructor(private http: HttpClient, @Inject('API_URL') private baseUrl: string) { }

  createGame(): Observable<Game> {
    return this.http.post<Game>(`${this.baseUrl}/games`, {});
  }
}
