import { Order } from "./order";
import { Plant } from "./plant";


export interface OrderedPlant {

    id: number;

    plantId: number;

    productName: string;

    pictureLink: string;

    price : number;

    Order?: Order;

    OrderId?: number;

}