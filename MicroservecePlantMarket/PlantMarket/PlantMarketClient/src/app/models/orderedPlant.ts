import { Order } from "./order";
import { Plant } from "./plant";


export interface OrderedPlant {

    id: number;

    plantId: number;

    Order?: Order;

    OrderId?: number;

}