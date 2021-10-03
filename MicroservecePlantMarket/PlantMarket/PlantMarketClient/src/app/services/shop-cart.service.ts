import { HttpClient,HttpHeaders  } from '@angular/common/http';
import { Injectable, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Order } from '../models/order';
import { ShopCart } from '../models/shopCart';
import { ShopCartItem } from '../models/shopCartItem';
import { User } from '../models/user';
import { OidcSecurityService } from 'angular-auth-oidc-client';

@Injectable({
  providedIn: 'root'
})
export class ShopCartService implements OnInit{

  private url ='https://localhost:7001/api/ShopCart/';

  private httpOptions = {
    headers: new HttpHeaders({
      Authorization: 'Bearer ' + this.oidcSecurityServices.getAccessToken(),
    }),
  };

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
  
  constructor(public http: HttpClient,
    public oidcSecurityServices:OidcSecurityService) { }

  createShopCart(userId:number): Observable<ShopCart>{

    return this.http.post<ShopCart>(`${this.url}CreateCart`,userId,this.httpOptions);
  }

  getShopCart(): Observable<ShopCart>{

    return this.http.get<ShopCart>(`${this.url}GetShopCart`,this.httpOptions);
  }

  addPlantToCart(shopCartItem :ShopCartItem) : Observable<boolean>{
    return this.http.post<boolean>(`${this.url}AddPlantToCart`,shopCartItem,this.httpOptions);
  }

  deleteShopCartItem(shopCartItemId:number): Observable<boolean>{

    return this.http.delete<boolean>(`${this.url}DeleteShopCartItem/${shopCartItemId}`,this.httpOptions);
  }

  // buy(shopCart: ShopCart): Observable<Order>{

  //   return this.http.post<Order>(`${this.url}buy`,shopCart);
  // }

}
