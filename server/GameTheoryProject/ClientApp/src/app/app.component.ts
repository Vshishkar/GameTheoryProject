import { NotificationService } from "./player/services/notification.service";
import { AfterViewInit } from "@angular/core";
import { Component } from "@angular/core";

@Component({
  selector: "app-root",
  templateUrl: "./app.component.html",
})
export class AppComponent implements AfterViewInit {
  constructor(public notification: NotificationService) {}

  ngAfterViewInit(): void {
    this.notification.connect();
  }
  title = "app";
}
