import { Component, OnInit } from "@angular/core";
import { UserService } from "../../services/user.service";
import { User } from "../../interfaces/auth";
import { first } from "rxjs/operators";
import { AuthService } from "../../services/auth/auth.service";
import { Router, ActivatedRoute } from "@angular/router";

@Component({
  selector: "app-login",
  templateUrl: "./login.component.html",
  styleUrls: ["./login.component.scss"],
})
export class LoginComponent implements OnInit {
  returnUrl: string;
  constructor(
    private userService: UserService,
    private auth: AuthService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.returnUrl =
      this.route.snapshot.queryParams["returnUrl"] || "/dashboard";
  }
  login() {
    //  integration test
    this.auth
      .login({ cpf: "53244828035", password: "test" })
      .pipe(first())
      .subscribe((data) => this.router.navigate([this.returnUrl]));
  }
}
