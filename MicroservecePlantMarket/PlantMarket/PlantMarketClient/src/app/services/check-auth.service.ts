import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CheckAuthService {

  public isUserAuth = new Subject<boolean>();

  constructor() { }

  public changeisUserAuth(isAuth: boolean) {
    this.isUserAuth.next(isAuth); 
 }
}
