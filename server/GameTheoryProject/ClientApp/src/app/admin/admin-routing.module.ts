import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { AuthGuard } from "../auth/auth.guard";
import { AdminGuard } from "./admin.guard";
import { GameContainerComponent } from "./components/game-container/game-container.component";

const routes: Routes = [
  {
    path: "game-management",
    component: GameContainerComponent,
    canActivate: [AuthGuard, AdminGuard],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AdminRoutingModule {}
