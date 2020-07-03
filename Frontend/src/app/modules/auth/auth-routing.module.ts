import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { RegisterComponent } from "./pages/register/register.component";
import { LoginComponent } from "./pages/login/login.component";

import { AuthComponent } from "./auth.component";

const routes: Routes = [
  {
    path: "",
    pathMatch: "full",
    redirectTo: "register",
  },
  {
    path: "register",
    component: AuthComponent,
    children: [
      {
        path: "",
        component: RegisterComponent,
      },
    ],
  },
  {
    path: "login",
    component: AuthComponent,
    children: [
      {
        path: "",
        component: LoginComponent,
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AuthRoutingModule {}
