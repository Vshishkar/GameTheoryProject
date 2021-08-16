import { Component, OnInit } from "@angular/core";
import { FormBuilder, Validators } from "@angular/forms";
import { ActivatedRoute } from "@angular/router";
import { Observable } from "rxjs";
import { filter, switchMap } from "rxjs/operators";
import { WebResponse } from "src/app/models/web-response.model";
import { PlayerGameDetails } from "../../models/player.models";
import { PlayerService } from "../../services/player.service";

@Component({
  selector: "app-game",
  templateUrl: "./game.component.html",
  styleUrls: ["./game.component.css"],
})
export class GameComponent implements OnInit {
  isJoined$: Observable<WebResponse<boolean>>;
  gameDetails$: Observable<PlayerGameDetails>;
  gameId: string;

  submitAnswerForm = this.fb.group({
    answer: ["", Validators.required],
  });

  constructor(
    private route: ActivatedRoute,
    private playerService: PlayerService,
    private fb: FormBuilder
  ) {}

  ngOnInit() {
    this.isJoined$ = this.route.paramMap.pipe(
      filter((x) => x.has("gameId")),
      switchMap((x) => {
        this.gameId = x.get("gameId");
        return this.playerService.isJoined(this.gameId);
      })
    );
    this.gameDetails$ = this.isJoined$.pipe(
      filter((x) => x.data),
      switchMap((x) => this.playerService.details(this.gameId))
    );
  }

  public onSubmitAnswer() {
    console.log(this.submitAnswerForm);
    if (!this.submitAnswerForm.valid) {
      return;
    }

    this.playerService
      .submit({
        gameId: this.gameId,
        answer: this.submitAnswerForm.value["answer"],
      })
      .subscribe();
  }

  public onGameClicked() {
    this.playerService.joinGame(this.gameId).subscribe();
  }
}
