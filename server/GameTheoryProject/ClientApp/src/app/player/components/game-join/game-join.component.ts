import { Output } from "@angular/core";
import { Component, EventEmitter, OnInit } from "@angular/core";

@Component({
  selector: "app-game-join",
  templateUrl: "./game-join.component.html",
  styleUrls: ["./game-join.component.css"],
})
export class GameJoinComponent implements OnInit {
  @Output() joinGame = new EventEmitter();

  constructor() {}

  ngOnInit() {}

  onGameJoin() {
    this.joinGame.emit();
  }
}
