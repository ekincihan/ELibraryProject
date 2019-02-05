import { LoginResponse } from "./shared/login-response";
import { User } from "../signin/shared/user";

export class Factory{
    user : User ;
    constructor(private loginResponse: LoginResponse){
        this.createUser(this.loginResponse);
    }

    createUser(loginResponse: LoginResponse){
        this.user = new User();
        this.user.age = (loginResponse["age"]) ? loginResponse["age"] : 0;
        this.user.birthdate = new Date(loginResponse["birthdate"]);
        this.user.email = (loginResponse["email"]) ? loginResponse["email"] : '';
        this.user.gender = (loginResponse["gender"])? loginResponse["gender"] : '';
        this.user.name = (loginResponse["name"])? loginResponse["name"] : '';
        this.user.phoneNumber = (loginResponse["phoneNumber"])? loginResponse["phoneNumber"] : '';
        this.user.surname = (loginResponse["surname"])? loginResponse["surname"] : '';
        this.user.userName = (loginResponse["userName"])? loginResponse["userName"] : '';
        this.user.id = (loginResponse["id"])? loginResponse["id"] : '';
        
        localStorage.setItem('token',loginResponse["bearerToken"]);
        localStorage.setItem('user',JSON.stringify(this.user))
    }
}