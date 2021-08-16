import { GameStatus } from "./../../../models/game.model";
import { Component, Inject, Input, OnInit } from "@angular/core";
import { GameDetails } from "../../models/game-detail.model";
import { GameService } from "../../services/game.service";

@Component({
  selector: "app-game-details",
  templateUrl: "./game-details.component.html",
  styleUrls: ["./game-details.component.css"],
})
export class GameDetailsComponent implements OnInit {
  @Input() gameDetails: GameDetails;

  link: string;
  buttonText: string;
  shouldStartGame: boolean;

  constructor(
    @Inject("BASE_URL") private baseUrl: string,
    private gameService: GameService
  ) {}

  ngOnInit() {
    console.log(this);
    this.shouldStartGame = this.gameDetails.status === GameStatus.Draft;
    this.buttonText = this.shouldStartGame ? "Start Game" : "Finish Game";
    this.link = `${this.baseUrl}/game/${this.gameDetails.gameId}`;
  }

  onActionClicked() {
    if (this.shouldStartGame) {
      this.gameService.startGame(this.gameDetails.gameId).subscribe();
    } else {
      this.gameService.finishGame(this.gameDetails.gameId).subscribe();
    }
  }
}
