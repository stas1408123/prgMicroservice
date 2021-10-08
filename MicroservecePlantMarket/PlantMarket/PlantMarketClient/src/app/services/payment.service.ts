import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Order } from '../models/order';
import { ShopCart } from '../models/shopCart';

@Injectable({
  providedIn: 'root'
})
export class PaymentService {

  private url ='https://localhost:9001/api/ShopCart/';

  constructor(public http: HttpClient,
    ) { }

  buy(order:Order): Observable<boolean>{

      return this.http.post<boolean>(`${this.url}Buy`,order);
    }
}
