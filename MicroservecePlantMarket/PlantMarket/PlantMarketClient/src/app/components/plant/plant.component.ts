import { Component, Input, OnInit } from '@angular/core';
import { User } from 'src/app/models/user';
import { UserService } from 'src/app/services/user.service';
import { Plant } from 'src/app/models/plant';
import { MatSnackBar } from '@angular/material/snack-bar';
import { PlantService } from 'src/app/services/plant.service';
import { ShopCartService } from 'src/app/services/shop-cart.service';
import { ShopCartItem } from 'src/app/models/shopCartItem';
import { CheckAuthService } from 'src/app/services/check-auth.service';
import { OidcSecurityService, UserDataResult } from 'angular-auth-oidc-client';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-plant',
  templateUrl: './plant.component.html',
  styleUrls: ['./plant.component.scss']
})
export class PlantComponent implements OnInit {

  @Input() plant!: Plant

  userData?: Observable<UserDataResult>;

  shopCartId!:number;

  isAuthenticated = false;


  constructor(
    private snackBar: MatSnackBar,
    private plantService: PlantService,
    private shopCartService: ShopCartService,
    private readonly checkAuthService:CheckAuthService,
    public oidcSecurityService: OidcSecurityService 
  ) {}

  ngOnInit(): void {

    this.oidcSecurityService.isAuthenticated$.subscribe(({ isAuthenticated }) => {
      this.isAuthenticated = isAuthenticated;

      console.warn('authenticated: ', isAuthenticated);
      
    });

    //this.userData = this.oidcSecurityService.userData$;

    // this.oidcSecurityService.checkAuth().subscribe(({ isAuthenticated, userData}) => 
    // {
    //     console.log(userData);
    // });

    

    this.shopCartService.getShopCart().subscribe(result =>{

      this.shopCartId=result.id;

    });
    // this.checkAuthService.isUserAuth.subscribe((isUserAuth) =>{
    //   this.isUserAuth=isUserAuth;
    // })
  }

  addToCart() {

  /*if(this.isUserAuth){
    this.shopCartService.addPlantToCart(this.setShopCartItem()).subscribe(result => {
      if (result) {
        this.snackBar.open('Plant is added to the cart', '', {
          duration: 2000,
        })
      }
      else {
        this.snackBar.open('Try again', '', {
          duration: 2000,
        })
      }
    }
    )
  }
  else{
    this.snackBar.open("You must log in to the site to access", '', {
      duration: 2000,
    })
  }*/


  this.shopCartService.addPlantToCart(this.setShopCartItem()).subscribe(result => {
    if (result) {
      this.snackBar.open('Plant is added to the cart', '', {
        duration: 2000,
      })
    }
    else {
      this.snackBar.open('Try again', '', {
        duration: 2000,
      })
    }
  }
  )

  }

  setShopCartItem(): ShopCartItem {
    return {
      id: 0,
      productName: this.plant.name,
      pictureLink: this.plant.pictureLink,
      price : this.plant.price,
      shopCartId: this.shopCartId,
      plantId: this.plant.id
    };
  }

}

