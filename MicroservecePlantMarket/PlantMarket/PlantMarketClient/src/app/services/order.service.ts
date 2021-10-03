import { HttpClient,HttpHeaders  } from '@angular/common/http';
import { Injectable, OnInit } from '@angular/core';
import { OidcSecurityService } from 'angular-auth-oidc-client';
import { Observable } from 'rxjs';
import { Order } from '../models/order';

@Injectable({
  providedIn: 'root'
})
export class OrderService implements OnInit{

  private url = 'https://localhost:8001/api/Order/';

  private httpOptions = {
    headers: new HttpHeaders({
      Authorization: 'Bearer ' + this.oidcSecurityServices.getAccessToken(),
    }),
  };


  constructor(public http: HttpClient,
    public oidcSecurityServices:OidcSecurityService) { }

  ngOnInit() {
    this.oidcSecurityServices.checkAuth().subscribe((auth) => {
      /*...*/
      console.log("Is Auth"+auth);

      this.httpOptions = {
        headers: new HttpHeaders({
          Authorization: 'Bearer ' + this.oidcSecurityServices.getAccessToken(),
      }),
     };
    });
  }

  getOrders(): Observable<Order[]> {
    return this.http.get<Order[]>(`${this.url}GetAllUserOrders`,this.httpOptions);
  }



}
