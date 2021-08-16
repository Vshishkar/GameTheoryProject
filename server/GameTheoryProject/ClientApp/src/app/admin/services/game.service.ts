import { HttpClient, HttpParams } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { CreateGame, Game, GameDetails } from "../models/game-detail.model";

@Injectable({
  providedIn: "root",
})
export class GameService {
  constructor(
    private http: HttpClient,
    @Inject("API_URL") private baseUrl: string
  ) {}

  public createGame(game: CreateGame): Observable<Game> {
    return this.http.post<Game>(`${this.baseUrl}/games`, game);
  }

  public deleteGame(gameId: string): Observable<unknown> {
    return this.http.delete<Game>(`${this.baseUrl}/games/${gameId}`);
  }

  public gameDetails(gameId: string): Observable<GameDetails> {
    const params = new HttpParams();
    params.set("gameId", gameId);
    return this.http.get<GameDetails>(`${this.baseUrl}/games/details`, {
      params: { gameId: gameId },
    });
  }

  public getList(): Observable<Array<Game>> {
    return this.http.get<Array<Game>>(`${this.baseUrl}/games`);
  }
}
