import { Component, OnInit } from "@angular/core";
import { FormBuilder, Validators } from "@angular/forms";
import { Observable, Subject } from "rxjs";
import { Game } from "src/app/game-management/game";
import { GameDetails } from "../../models/game-detail.model";
import { GameService } from "../../services/game.service";

@Component({
  selector: "app-game-container",
  templateUrl: "./game-container.component.html",
  styleUrls: ["./game-container.component.css"],
})
export class GameContainerComponent implements OnInit {
  createGameForm = this.fb.group({
    title: ["", Validators.required],
  });

  games$: Observable<Array<Game>>;
  gameDetails$: Observable<GameDetails>;

  constructor(private gameService: GameService, private fb: FormBuilder) {}

  ngOnInit() {
    this.games$ = this.gameService.getList();
  }

  public onCreateGame() {
    if (!this.createGameForm.valid) {
      return;
    }

    this.gameService.createGame(this.createGameForm.value).subscribe();
    this.games$ = this.gameService.getList();
  }

  public onGameClicked(gameId: string) {
    console.log(gameId, "at gameClicked");
    this.gameDetails$ = this.gameService.gameDetails(gameId);
  }
}
