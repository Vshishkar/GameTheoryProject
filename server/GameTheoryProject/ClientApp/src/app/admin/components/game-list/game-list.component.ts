import { Component, EventEmitter, Input, OnInit, Output } from "@angular/core";
import { Game } from "src/app/game-management/game";

@Component({
  selector: "app-game-list",
  templateUrl: "./game-list.component.html",
  styleUrls: ["./game-list.component.css"],
})
export class GameListComponent implements OnInit {
  @Input() games: Array<Game>;
  @Output() gameClick = new EventEmitter<string>();

  constructor() {}

  ngOnInit() {}

  onGameClicked(gameId: string) {
    console.log("onGameClicked")
    this.gameClick.emit(gameId);
  }
}
