import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { UserResponse, User } from "../interfaces/auth";
import { environment } from "@environments/environment";

@Injectable({
  providedIn: "root",
})
export class UserService {
  // TEST API REQUEST
  constructor(private http: HttpClient) {}

  getAllUsers() {
    return this.http.get<User[]>(`${environment.apiUrl}/account/all`);
  }
}
