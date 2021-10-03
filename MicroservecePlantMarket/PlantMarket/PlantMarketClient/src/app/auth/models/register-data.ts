import { User } from "src/app/models/user";


export interface RegisterData {

    user: User;
    password: string;
    login: string;
}