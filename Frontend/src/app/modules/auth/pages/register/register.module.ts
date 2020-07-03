import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { RegisterComponent } from "./register.component";
import { AuthRoutingModule } from "../../auth-routing.module";
import { RegisterButtonProfileComponent } from "../../components/register-button-profile/register-button-profile.component";

import { MaterialModule } from "src/app/shared/modules/material/material.module";
import { FlexLayoutModule } from "@angular/flex-layout";

@NgModule({
  declarations: [RegisterComponent, RegisterButtonProfileComponent],
  imports: [CommonModule, MaterialModule, AuthRoutingModule, FlexLayoutModule],
})
export class RegisterModule {}
