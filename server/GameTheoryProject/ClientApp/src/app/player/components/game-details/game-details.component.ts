import { PlayerGameDetails } from "./../../models/player.models";
import { Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges } from "@angular/core";
import { GameStatus } from "src/app/models/game.model";
import { GameNotificationModel } from "../../services/notification.service";
import { User } from "src/app/auth/models/user.model";
import { FormBuilder, Validators } from "@angular/forms";

@Component({
  selector: "app-game-details",
  templateUrl: "./game-details.component.html",
  styleUrls: ["./game-details.component.css"],
})
export class GameDetailsComponent implements OnChanges {
  @Input() gameDetails: PlayerGameDetails;
  @Input() user: User;

  @Output() submited = new EventEmitter<number>();

  hideForm = false;

  submitForm = this.fb.group({
    answer: ["", [Validators.required, Validators.min(1), Validators.max(100)]],
  });

  constructor(private fb: FormBuilder) {}

  ngOnChanges(changes: SimpleChanges): void {
    if (
      this.gameDetails.status === GameStatus.InProgress &&
      this.gameDetails.answer == null
    ) {
      this.hideForm = false;
    } else {
      this.hideForm = true;
    }

  }

  onSubmitted() {
    const val = +this.submitForm.value["answer"];
    this.submited.emit(val);
  }

  isStarted() {
    return this.gameDetails.status === GameStatus.InProgress;
  }

  isFinished() {
    return this.gameDetails.status === GameStatus.Done;
  }

  isInDraft() {
    return this.gameDetails.status === GameStatus.Draft;
  }

  gameResultBanner() {
    const isWinner =
      this.gameDetails.winners &&
      this.gameDetails.winners.filter((x) => x.userId == this.user.userId)
        .length > 0;
    if (isWinner) {
      return "Congratulations! You win!";
    } else {
      return "Sorry, looks like you didn't win :(";
    }
  }
}
