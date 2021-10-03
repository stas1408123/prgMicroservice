import { Component, OnInit } from '@angular/core';
import { Order } from 'src/app/models/order';
import { OrderService } from 'src/app/services/order.service';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.scss']
})
export class OrderComponent implements OnInit {

  orders: Order[] = [];

  constructor(
    private orderService: OrderService
  ) { }

  ngOnInit(): void {
    this.orderService.getOrders().subscribe(result => {
      if (result) {
        this.orders = result;
      }
    },
      error => {
        console.log("Error loading orders");
      })
  }

  calculatePrice(order: Order): number {

    let result: number = 0

    order.orderedPlants.forEach(orderedPlant => {
      result +=0; //orderedPlant.plant.price;
    })

    return result;
  }

}
