import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { LoginData } from '../models/login-data';
import { Observable } from 'rxjs';
import { RegisterData } from '../models/register-data';




@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private url = '/api/auth/';

  constructor(private http: HttpClient) {
  }

  LogIn(data: LoginData): Observable<boolean> {

    return this.http.put<boolean>(`${this.url}`, data);

  }

  IsLoginFree(login: string): Observable<boolean> {
    return this.http.get<boolean>(`${this.url}IsLoginFree/${login}`);
  }

  Register(data: RegisterData): Observable<boolean> {
    return this.http.post<boolean>(`${this.url}Register`, data)
  }

  Logout(): Observable<boolean>{

     return this.http.get<boolean>(`${this.url}Logout`);

  }

}
