import { Plant } from "./plant";


export interface Category {

    id: number;

    name: string;

    description: string;

    plants?: Plant[];

}