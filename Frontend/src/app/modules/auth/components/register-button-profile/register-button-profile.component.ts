import { Component, OnInit, Input } from "@angular/core";

@Component({
  selector: "register-button-profile",
  templateUrl: "./register-button-profile.component.html",
  styleUrls: ["./register-button-profile.component.scss"],
})
export class RegisterButtonProfileComponent implements OnInit {
  @Input() title: string;
  @Input() content: string;
  @Input() selected: boolean;

  constructor() {}

  ngOnInit(): void {}
}
