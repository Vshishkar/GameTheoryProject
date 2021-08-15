import { Component, OnInit } from "@angular/core";
import { FormBuilder, Validators } from "@angular/forms";
import { AuthentificationService } from "../service/authentification.service";

@Component({
  selector: "app-log-in",
  templateUrl: "./log-in.component.html",
  styleUrls: ["./log-in.component.css"],
})
export class LogInComponent implements OnInit {
  loginForm = this.fb.group({
    username: ["", Validators.required],
    password: ["", Validators.required],
  });

  constructor(
    private fb: FormBuilder,
    private authService: AuthentificationService
  ) {}

  ngOnInit() {}

  public OnSignUp() {
    this.authService.signIn(
      this.loginForm.value["username"],
      this.loginForm.value["password"]
    );
  }
}
