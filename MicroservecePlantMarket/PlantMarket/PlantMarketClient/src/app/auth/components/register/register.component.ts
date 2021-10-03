import { Component, OnInit } from '@angular/core';
import { RegisterData } from '../../models/register-data';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';
import { UserService } from 'src/app/services/user.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { CheckAuthService } from 'src/app/services/check-auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  data: RegisterData = {
    user: {

      id: 0,

      name: "",

      serName: "",

      adress: "",

      phone: "",

      email: "",

      orders: [],

    },

    login: "",
    password: ""
  }

  isLoginFree: boolean = false;

  constructor(
    private router: Router,
    private auth: AuthService,
    private userService: UserService,
    private snackBar: MatSnackBar,
    private readonly checkAuthService:CheckAuthService
  ) { }

  ngOnInit(): void {
    this.userService.getUser().subscribe(result => {
      if (result) {
        this.router.navigateByUrl('');
      }
    },
      error => {

      })
  }

  checkLogin() {
    this.auth.IsLoginFree(this.data.login).subscribe(result => {
      if (result) {
        this.isLoginFree = true;
      }
      else {
        this.snackBar.open("Login is served.Please, try again");
      }
    })
  }

  cancelRegistration() {
    this.router.navigateByUrl('');
  }

  register() {
    this.checkLogin();
    if (this.isLoginFree) {
      this.auth.Register(this.data).subscribe(result => {                                          
        if (result) {
          this.checkAuthService.changeisUserAuth(true);
          this.router.navigateByUrl('');
        }
        else {

          this.snackBar.open("Error with registration")
        }
      }
      )

    }
  }

}
