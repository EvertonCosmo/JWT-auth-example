import { Component, OnInit } from "@angular/core";
import { AuthService } from "../auth/services/auth/auth.service";

@Component({
  selector: "app-dashboard",
  templateUrl: "./dashboard.component.html",
  styleUrls: ["./dashboard.component.scss"],
})
export class DashboardComponent implements OnInit {
  user = this.authenticationService.currentUserValue;
  constructor(private authenticationService: AuthService) {}

  ngOnInit(): void {}
}
