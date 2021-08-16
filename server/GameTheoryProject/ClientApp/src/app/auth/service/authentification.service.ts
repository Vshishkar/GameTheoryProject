import { User, UserPayload } from "./../models/user.model";
import { HttpClient } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { BehaviorSubject, Observable } from "rxjs";
import { filter, map } from "rxjs/operators";
import jwtDecode, { JwtPayload } from "jwt-decode";
import { WebResponse } from "src/app/models/web-response.model";

@Injectable({
  providedIn: "root",
})
export class AuthentificationService {
  private accessToken$ = new BehaviorSubject<string>(
    localStorage.getItem("access_token")
  );
  private user$: Observable<User>;

  constructor(
    private http: HttpClient,
    @Inject("API_URL") private baseUrl: string
  ) {
    this.user$ = this.accessToken$.asObservable().pipe(
      filter((x) => !!x),
      map((x) => {
        const decoded = jwtDecode<UserPayload>(x);
        return new User(decoded.userId, decoded.isAdmin, decoded.name);
      })
    );
  }

  public isAuthrorised(): boolean {
    return this.accessToken$.value != undefined;
  }

  public getAccessToken(): string {
    return this.accessToken$.value;
  }

  public signIn(username: string, password: string) {
    this.http
      .post<WebResponse<string>>(`${this.baseUrl}/users/login`, {
        username,
        password,
      })
      .subscribe(
        (x) => {
          this.accessToken$.next(x.data);
          localStorage.setItem("access_token", x.data);
        },
        (e) => console.log(e)
      );
  }

  public signUp(username: string, password: string) {
    this.http
      .post<WebResponse<string>>(`${this.baseUrl}/users/register`, {
        username,
        password,
      })
      .subscribe((x) => this.accessToken$.next(x.data));
  }
}
