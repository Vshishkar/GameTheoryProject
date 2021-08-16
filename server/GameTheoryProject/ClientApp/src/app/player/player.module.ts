import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";

import { PlayerRoutingModule } from "./player-routing.module";
import { GameComponent } from "./components/game/game.component";
import { ReactiveFormsModule } from "@angular/forms";
import { MaterialModule } from "../material/material.module";

@NgModule({
  declarations: [GameComponent],
  imports: [
    CommonModule,
    MaterialModule,
    ReactiveFormsModule,
    PlayerRoutingModule,
  ],
})
export class PlayerModule {}
