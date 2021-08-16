import { Answer, PlayerGameDetails } from "./../models/player.models";
import { HttpClient, HttpParams } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { Observable } from "rxjs";
import {
  CreateGame,
  GameDetails,
} from "src/app/admin/models/game-detail.model";
import { Game } from "src/app/game-management/game";
import { WebResponse } from "src/app/models/web-response.model";

@Injectable({
  providedIn: "root",
})
export class PlayerService {
  constructor(
    private http: HttpClient,
    @Inject("API_URL") private baseUrl: string
  ) {}

  public createGame(game: CreateGame): Observable<Game> {
    return this.http.post<Game>(`${this.baseUrl}/games`, game);
  }

  public isJoined(gameId: string): Observable<WebResponse<boolean>> {
    const params = new HttpParams();
    params.set("gameId", gameId);
    return this.http.get<WebResponse<boolean>>(
      `${this.baseUrl}/players/game/is-joined`,
      {
        params: { gameId: gameId },
      }
    );
  }

  public details(gameId: string): Observable<PlayerGameDetails> {
    const params = new HttpParams();
    params.set("gameId", gameId);
    return this.http.get<PlayerGameDetails>(
      `${this.baseUrl}/players/game/details`,
      {
        params: { gameId: gameId },
      }
    );
  }

  public joinGame(gameId: string): Observable<any> {
    return this.http.post(`${this.baseUrl}/players/game/join`, { gameId });
  }

  public submit(answer: Answer): Observable<any> {
    return this.http.post(`${this.baseUrl}/players/game/submit`, answer);
  }
}
