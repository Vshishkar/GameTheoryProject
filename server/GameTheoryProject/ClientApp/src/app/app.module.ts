import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { HttpClientModule, HTTP_INTERCEPTORS } from "@angular/common/http";
import { RouterModule } from "@angular/router";

import { AppComponent } from "./app.component";
import { NavMenuComponent } from "./nav-menu/nav-menu.component";
import { GameManagementComponent } from "./game-management/game-management.component";
import { NoopAnimationsModule } from "@angular/platform-browser/animations";
import { ReactiveFormsModule } from "@angular/forms";
import { MaterialModule } from "./material/material.module";
import { AuthModule } from "./auth/auth.module";
import { AuthGuard } from "./auth/auth.guard";
import { AuthInterceptor } from "./auth/service/auth.interceptor";
import { PlayerModule } from "./player/player.module";
import { AdminModule } from "./admin/admin.module";

@NgModule({
  declarations: [AppComponent, NavMenuComponent, GameManagementComponent],
  imports: [
    BrowserModule.withServerTransition({ appId: "ng-cli-universal" }),
    HttpClientModule,
    FormsModule,
    MaterialModule,
    ReactiveFormsModule,
    AuthModule,
    AdminModule,
    PlayerModule,
    RouterModule.forRoot([
      {
        path: "game-management2",
        component: GameManagementComponent,
        canActivate: [AuthGuard],
      },
    ]),
    NoopAnimationsModule,
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true,
    },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
