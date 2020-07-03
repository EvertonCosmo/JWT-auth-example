import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";

import { AuthRoutingModule } from "./auth-routing.module";
import { LoginComponent } from "./pages/login/login.component";

import { LoginModule } from "./pages/login/login.module";
import { RegisterModule } from "./pages/register/register.module";
import { RegisterButtonProfileComponent } from "./components/register-button-profile/register-button-profile.component";
import { MaterialModule } from "src/app/shared/modules/material/material.module";
import { AuthComponent } from "./auth.component";

@NgModule({
  declarations: [AuthComponent],
  imports: [CommonModule, AuthRoutingModule],
  exports: [AuthRoutingModule, LoginModule, RegisterModule],
})
export class AuthModule {}
