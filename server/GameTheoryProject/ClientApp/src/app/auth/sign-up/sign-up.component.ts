import { Component, OnInit } from '@angular/core';
import { Validators, FormBuilder } from '@angular/forms';
import { AuthentificationService } from '../service/authentification.service';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class SignUpComponent implements OnInit {
  signUpForm = this.fb.group({
    username: ["", Validators.required],
    password: ["", Validators.required],
  });

  constructor(
    private fb: FormBuilder,
    private authService: AuthentificationService
  ) {}

  ngOnInit() {}

  public OnSignUp() {
    this.authService.signUp(
      this.signUpForm.value["username"],
      this.signUpForm.value["password"]
    );
  }
}
