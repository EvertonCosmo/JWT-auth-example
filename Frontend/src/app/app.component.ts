import { Component } from "@angular/core";
import { AuthService } from "./modules/auth/services/auth/auth.service";
import { Router } from "@angular/router";

@Component({
  selector: "app-root",
  templateUrl: "./app.component.html",
  styleUrls: ["./app.component.scss"],
})
export class AppComponent {
  title = "login-jwt-example";

  constructor(
    private authenticationService: AuthService,
    private route: Router
  ) {
    if (this.authenticationService.currentUserValue) {
      this.route.navigate(["/dashboard"]);
    }
  }
}
