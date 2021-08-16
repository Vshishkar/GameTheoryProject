import { Component, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { merge, Observable, Subject } from "rxjs";
import { filter, switchMap } from "rxjs/operators";
import { User } from "src/app/auth/models/user.model";
import { AuthentificationService } from "src/app/auth/service/authentification.service";
import { WebResponse } from "src/app/models/web-response.model";
import { PlayerGameDetails } from "../../models/player.models";
import {
  GameNotificationModel,
  NotificationService,
} from "../../services/notification.service";
import { PlayerService } from "../../services/player.service";

@Component({
  selector: "app-game-container",
  templateUrl: "./game-container.component.html",
  styleUrls: ["./game-container.component.css"],
})
export class GameContainerComponent implements OnInit {
  gameId: string;
  isJoined$: Observable<WebResponse<boolean>>;
  gameDetails$: Observable<PlayerGameDetails>;
  user$: Observable<User>;
  status$: Observable<GameNotificationModel>;

  private triggerDetails$ = new Subject<boolean>();

  constructor(
    private authService: AuthentificationService,
    private route: ActivatedRoute,
    private playerService: PlayerService,
    public notification: NotificationService
  ) {}

  ngOnInit() {
    console.log("at init");
    this.status$ = this.notification.getState();
    this.isJoined$ = this.route.paramMap.pipe(
      filter((x) => x.has("gameId")),
      switchMap((x) => {
        console.log("gameId");
        this.gameId = x.get("gameId");
        return this.playerService.isJoined(this.gameId);
      })
    );
    this.gameDetails$ = merge(
      this.triggerDetails$.asObservable(),
      this.status$,
      this.isJoined$.pipe(filter((x) => x.data))
    ).pipe(switchMap((x) => this.playerService.details(this.gameId)));
    this.user$ = this.authService.getUser();
  }

  onGameJoin() {
    this.playerService.joinGame(this.gameId).subscribe(() => {
      this.isJoined$ = this.playerService.isJoined(this.gameId);
    });
  }

  onSubmitted(answer: number) {
    this.playerService
      .submit({
        answer: answer,
        gameId: this.gameId,
      })
      .subscribe((r) => {
        this.triggerDetails$.next(true);
      });
  }
}
