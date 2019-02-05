import { Injectable, EventEmitter } from "@angular/core";
import { User } from "../signin/shared/user";

@Injectable()
export class TokenService {
    isLogin: boolean;
    user: User
    isLoginChange: EventEmitter<boolean> = new EventEmitter<boolean>();

    constructor() {
        if(localStorage.getItem('token'))
            this.isLogin = true;
    }

    getIsLogin(){
        return this.isLogin;
    }

    setIsLogin(logined){
        this.isLogin = logined;
    }
}
