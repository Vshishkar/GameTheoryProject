import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";

import { PlayerRoutingModule } from "./player-routing.module";
import { GameComponent } from "./components/game/game.component";
import { ReactiveFormsModule } from "@angular/forms";
import { MaterialModule } from "../material/material.module";
import { GameContainerComponent } from './components/game-container/game-container.component';
import { GameJoinComponent } from './components/game-join/game-join.component';
import { GameDetailsComponent } from './components/game-details/game-details.component';

@NgModule({
  declarations: [GameComponent, GameContainerComponent, GameJoinComponent, GameDetailsComponent],
  imports: [
    CommonModule,
    MaterialModule,
    ReactiveFormsModule,
    PlayerRoutingModule,
  ],
})
export class PlayerModule {}
