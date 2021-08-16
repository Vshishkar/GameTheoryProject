export interface JoinGame {
  gameId: string;
  userId: string;
}

export interface PlayerGameDetails {
  title: string;
  answer?: number;
}

export interface Answer {
  gameId: string;
  answer: number;
}
