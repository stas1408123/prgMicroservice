import { OrderedPlant } from './orderedPlant';


export interface Order {

  id: number;

  name: string;

  serName: string;

  adress: string;

  phone: string;

  email: string;

  userId: number

  orderedPlants: OrderedPlant[]

}