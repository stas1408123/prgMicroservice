import { Plant } from "./plant";
import { ShopCart } from "./shopCart";




export interface ShopCartItem {

    id: number;

    plantId: number;

    productName: string;

    pictureLink: string;

    price : number;

    shopCart?: ShopCart;

    shopCartId?: number;

}