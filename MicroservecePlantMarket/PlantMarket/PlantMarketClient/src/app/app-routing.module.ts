import { NgModule } from '@angular/core';
import { AutoLoginAllRoutesGuard, AutoLoginPartialRoutesGuard } from 'angular-auth-oidc-client'; //
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './auth/components/login/login.component';
import { RegisterComponent } from './auth/components/register/register.component';
import { HomeComponent } from './components/home/home.component';
import { ShopcartComponent } from './components/shopcart/shopcart.component';
import { AuthorizationGuard } from './authorization.guard';

const routes: Routes = [
  {
    path: "login",
    component: LoginComponent,
    //canActivate: [AutoLoginPartialRoutesGuard]
  },
  {
    path: "",
    component: HomeComponent,
    canActivate: [AutoLoginAllRoutesGuard]
  },
  {
    path: "register",
    component: RegisterComponent,
  }//,
  // {
  //   path: "shopcart",
  //   component: ShopcartComponent,
  // }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }