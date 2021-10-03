import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ShopCart } from '../models/shopCart';

@Injectable({
  providedIn: 'root'
})
export class PaymentService {

  private url ='https://localhost:9001/api/ShopCart/';

  constructor(public http: HttpClient,
    ) { }

  buy(shopCart: ShopCart): Observable<boolean>{

      return this.http.post<boolean>(`${this.url}Buy`,shopCart);
    }
}
