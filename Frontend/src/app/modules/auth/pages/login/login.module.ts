import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { LoginComponent } from "./login.component";
import { AuthRoutingModule } from "../../auth-routing.module";
import { MaterialModule } from "src/app/shared/modules/material/material.module";
import { FlexLayoutModule } from "@angular/flex-layout";

@NgModule({
  declarations: [LoginComponent],
  imports: [CommonModule, AuthRoutingModule, FlexLayoutModule, MaterialModule],
})
export class LoginModule {}
