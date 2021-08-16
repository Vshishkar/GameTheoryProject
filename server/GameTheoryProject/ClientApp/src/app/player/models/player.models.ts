import { GameStatus } from "src/app/models/game.model";

export interface JoinGame {
  gameId: string;
  userId: string;
}

export interface PlayerGameDetails {
  title: string;
  answer?: number;
  status: GameStatus;
  winners?: Array<GameWinner>;
}

export interface GameWinner {
  answer: number;
  userId: string;
}

export interface Answer {
  gameId: string;
  answer: number;
}
