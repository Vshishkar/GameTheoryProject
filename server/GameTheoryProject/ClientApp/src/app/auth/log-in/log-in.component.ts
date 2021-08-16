import { Component, OnInit } from "@angular/core";
import { FormBuilder, Validators } from "@angular/forms";
import { Router, ActivatedRoute } from "@angular/router";
import { AuthentificationService } from "../service/authentification.service";

@Component({
  selector: "app-log-in",
  templateUrl: "./log-in.component.html",
  styleUrls: ["./log-in.component.css"],
})
export class LogInComponent implements OnInit {
  returnUrl: string;

  loginForm = this.fb.group({
    username: ["", Validators.required],
    password: ["", Validators.required],
  });

  constructor(
    private fb: FormBuilder,
    private authService: AuthentificationService,
    private router: Router,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {
    this.route.queryParams.subscribe(
      (x) => (this.returnUrl = x["return"] || "")
    );
  }

  OnSignIn() {
    this.router.navigate(["/signup"], {
      queryParams: {
        return: this.returnUrl,
      },
    });
  }

  public OnSignUp() {
    this.authService
      .signIn(
        this.loginForm.value["username"],
        this.loginForm.value["password"]
      )
      .subscribe((x) => {
        this.router.navigateByUrl(this.returnUrl);
      });
  }
}
