import { Category } from "./category";


export interface Plant {

    id: number;

    name: string;

    price: number;

    shortDescription: string;

    longDescription: string;
    
    pictureLink :string ;

    isFavourite: boolean;

    isAvailable: boolean;

    categoryId: number;

    category?: Category;

}