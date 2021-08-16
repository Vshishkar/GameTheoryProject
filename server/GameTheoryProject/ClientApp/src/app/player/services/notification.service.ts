import { Inject, Injectable } from "@angular/core";
import { Subject } from "rxjs";
import * as signalR from "@aspnet/signalr";
import { GameStatus } from "src/app/models/game.model";
import { Observable } from "rxjs";

export interface GameNotificationModel {
  winners: Array<{
    userId: string;
    answer: number;
  }>;
  gameStatus: GameStatus;
  answer: number;
}

@Injectable({
  providedIn: "root",
})
export class NotificationService {
  private connection: signalR.HubConnection;
  private notif = new Subject<GameNotificationModel>();
  connectionEstablished = new Subject<Boolean>();

  constructor(@Inject("API_URL") private baseUrl: string) {}

  connect() {
    if (!this.connection) {
      this.connection = new signalR.HubConnectionBuilder()
        .withUrl(`${this.baseUrl}/playersHub`)
        .build();

      this.connection
        .start()
        .then(() => {
          console.log("Hub connection started");
          this.connectionEstablished.next(true);
        })
        .catch((err) => console.log(err));

      this.connection.on("NotifyGameStatus", (winners, gameStatus, answer) => {
        console.log("Received", status);
        this.notif.next({winners, gameStatus, answer});
      });
    }
  }

  disconnect() {
    if (this.connection) {
      this.connection.stop();
      this.connection = null;
    }
  }

  getState(): Observable<GameNotificationModel> {
    return this.notif.asObservable();
  }
}
