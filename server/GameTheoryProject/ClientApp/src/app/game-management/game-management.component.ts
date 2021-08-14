import { Observable, Subject } from 'rxjs';
import { Component, OnInit } from '@angular/core';
import { GameManagementService } from './game-management.service';
import { Game } from './game';

@Component({
  selector: 'app-game-management',
  templateUrl: './game-management.component.html',
  styleUrls: ['./game-management.component.css']
})
export class GameManagementComponent implements OnInit {
  public game$: Observable<Game>;

  constructor(private gameService: GameManagementService) {
    this.game$ = new Subject<Game>();
  }

  ngOnInit() {
  }

  public onCreateGame() {
    this.game$ = this.gameService.createGame();
  }

}
