import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { BehaviorSubject, Observable, ReplaySubject } from "rxjs";
import {
  User,
  UserPayload,
  LoginPayload,
  UserResponse,
} from "../../interfaces/auth";
import { environment } from "@environments/environment";
import { map } from "rxjs/operators";
import { StorageService } from "src/app/core/services/storage/storage.service";
import { Router } from "@angular/router";
@Injectable({
  providedIn: "root",
})
export class AuthService {
  public currentUser: Observable<UserResponse>;
  private currentUserSubject: BehaviorSubject<UserResponse>;

  // private isAuthenticatedSubject: ReplaySubject<boolean>;
  // public isAuthenticated = this.isAuthenticatedSubject.asObservable();

  constructor(
    private http: HttpClient,
    private storage: StorageService,
    private route: Router
  ) {
    this.currentUserSubject = new BehaviorSubject<UserResponse>(
      JSON.parse(localStorage.getItem("currentUser"))
    );
    this.currentUser = this.currentUserSubject.asObservable();
  }

  public get currentUserValue(): UserResponse {
    return this.currentUserSubject.value;
  }

  login(user: LoginPayload) {
    return this.http
      .post<UserResponse>(`${environment.apiUrl}/account/authenticate`, user)
      .pipe(
        map((user) => {
          localStorage.setItem("currentUser", JSON.stringify(user));

          this.currentUserSubject.next(user);
          return user;
        })
      );
  }
  logout() {
    localStorage.removeItem("currentUser");
    localStorage.removeItem("token");
    this.currentUserSubject.next(null);
    this.route.navigate(["/login"]);
  }
}
