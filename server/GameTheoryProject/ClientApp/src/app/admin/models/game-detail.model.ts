import { GameStatus } from "src/app/models/game.model";

export interface GameDetails {
  gameId: string;
  gameTitle: string;
  status: GameStatus;
  players: Array<{
    username: string;
    userId: string;
    gameRespose?: number;
  }>
}

export interface CreateGame {
  title: string;
}

export interface Game {
  gameId: string;
  gameTitle: string;
  status: GameStatus;
}
