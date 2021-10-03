import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private url = '/api/User/';


  constructor(public http: HttpClient) { }

  getUser(): Observable<User> {
    return this.http.get<User>(`${this.url}`);
  }

  updateUser(user: User): Observable<User> {
    return this.http.put<User>(`${this.url}UpdateUser`, user);
  }

  getAll(): Observable<User[]> {
    return this.http.get<User[]>(`${this.url}GetAllUsers`);
  }
  
}
