import { Component, OnInit } from "@angular/core";
import { Validators, FormBuilder } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { AuthentificationService } from "../service/authentification.service";

@Component({
  selector: "app-sign-up",
  templateUrl: "./sign-up.component.html",
  styleUrls: ["./sign-up.component.css"],
})
export class SignUpComponent implements OnInit {
  returnUrl: string;

  signUpForm = this.fb.group({
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

  public OnSignUp() {
    this.authService
      .signUp(
        this.signUpForm.value["username"],
        this.signUpForm.value["password"]
      )
      .subscribe((x) => {
        this.router.navigateByUrl(this.returnUrl);
      });
  }
}
