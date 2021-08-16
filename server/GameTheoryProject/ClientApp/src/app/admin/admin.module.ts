import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";

import { AdminRoutingModule } from "./admin-routing.module";
import { GameContainerComponent } from "./components/game-container/game-container.component";
import { GameDetailsComponent } from "./components/game-details/game-details.component";
import { GameListComponent } from "./components/game-list/game-list.component";
import { PlayerListComponent } from "./components/player-list/player-list.component";
import { MaterialModule } from "../material/material.module";
import { ReactiveFormsModule } from "@angular/forms";

@NgModule({
  declarations: [
    GameContainerComponent,
    GameDetailsComponent,
    GameListComponent,
    PlayerListComponent,
  ],
  imports: [
    CommonModule,
    MaterialModule,
    ReactiveFormsModule,
    AdminRoutingModule,
  ],
})
export class AdminModule {}
