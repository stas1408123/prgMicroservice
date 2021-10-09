import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { Order } from 'src/app/models/order';
import { OrderedPlant } from 'src/app/models/orderedPlant';
import { Plant } from 'src/app/models/plant';
import { ShopCart } from 'src/app/models/shopCart';
import { ShopCartItem } from 'src/app/models/shopCartItem';
import { PaymentService } from 'src/app/services/payment.service';
import { PlantService } from 'src/app/services/plant.service';
import { ShopCartService } from 'src/app/services/shop-cart.service';


@Component({
  selector: 'app-shopcart',
  templateUrl: './shopcart.component.html',
  styleUrls: ['./shopcart.component.scss']
})
export class ShopcartComponent implements OnInit {

  shopCart!: ShopCart;

  constructor(
    public dialogRef: MatDialogRef<ShopcartComponent>,
    private shopCartService: ShopCartService,
    private paymentService:PaymentService,
    private plantService: PlantService,
    private snackBar: MatSnackBar,
    private router: Router
  ) { }

  ngOnInit(): void {

    this.shopCartService.getShopCart().subscribe(result => {
      this.shopCart = result;
    },
      error => {
      })    
    
  }

  calculatePrice(): number {

    let result: number = 0

    this.shopCart.shopItems?.forEach(shopItems => {
      result += shopItems.price;
    })

    return result;
  }


  goToHome() {
    this.router.navigateByUrl('');
  }

  onCancelClick(): void {
    this.dialogRef.close();
  }

  removeShopCartItem(shopCartItem: ShopCartItem) {
    
    this.shopCart.shopItems?.splice(this.shopCart.shopItems?.indexOf(shopCartItem), 1)
    this.shopCartService.deleteShopCartItem(shopCartItem.id).subscribe(result => {
      if (result) {
        this.snackBar.open('Item was deleted', '', {
          duration: 2000,
        })
      }
    },
      error => {
      })
  }

  buy() {
    this.paymentService.buy(this.setOrder()).subscribe(result => {
      if (result) {
        this.snackBar.open('Order complite', '', {
          duration: 2000,
        })
      }
    },
      error => {
        console.log(error)
      });
  }

  setOrder(): Order {
    return {
      id: 0,
      name: "string",
      serName: "ss",
      adress: "ss",
      phone: "ss",
      email: "ss",
      userId: 1,
      orderedPlants: this.setOrderedPlants()
    };
  }

  setOrderedPlants(): OrderedPlant[] {
    
    var orderedPlants:OrderedPlant[] = [];

    this.shopCart.shopItems?.forEach(shopItem => {

      orderedPlants.push(this.shopItemToOrderedPlant(shopItem));
    })

    return orderedPlants;    
  }

  shopItemToOrderedPlant(shopCartItem :ShopCartItem) : OrderedPlant{
    return {
      id: 0,
      productName: shopCartItem.productName,
      pictureLink: shopCartItem.pictureLink,
      price : shopCartItem.price,
      plantId: shopCartItem.plantId
    };

  }
}
