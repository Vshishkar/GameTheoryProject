import { Component, Inject, Input, OnInit } from "@angular/core";
import { GameDetails } from "../../models/game-detail.model";

@Component({
  selector: "app-game-details",
  templateUrl: "./game-details.component.html",
  styleUrls: ["./game-details.component.css"],
})
export class GameDetailsComponent implements OnInit {
  @Input() gameDetails: GameDetails;

  link: string;

  constructor(@Inject("BASE_URL") private baseUrl: string) {}

  ngOnInit() {
    this.link = `${this.baseUrl}/game/${this.gameDetails.gameId}`;
  }
}
