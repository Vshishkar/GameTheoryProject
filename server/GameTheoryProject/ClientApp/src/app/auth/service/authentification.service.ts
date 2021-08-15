import { User, UserPayload } from './../models/user.model';
import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { filter, map } from 'rxjs/operators';
import jwtDecode, { JwtPayload } from "jwt-decode";

@Injectable({
  providedIn: 'root'
})
export class AuthentificationService {

  private accessToken$ = new BehaviorSubject<string>(undefined);
  private user$: Observable<User>;

  constructor(
    private http: HttpClient,
    @Inject('API_URL') private baseUrl: string) {
      this.user$ = this.accessToken$.asObservable().pipe(
        filter(x => !!x),
        map(x => {
        const decoded = jwtDecode<UserPayload>(x);
        return new User(decoded.userId, decoded.isAdmin, decoded.name);
      }));
    }

  public signIn(username: string, password: string)
  {
      this.http.post<string>(`${this.baseUrl}/users/login`, { username, password })
        .subscribe(x => this.accessToken$.next(x));
  }

  public signUp(username: string, password: string)
  {
      this.http.post<string>(`${this.baseUrl}/users/register`, { username, password })
        .subscribe(x => this.accessToken$.next(x));
  }
}
