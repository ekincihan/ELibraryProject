import { Injectable, EventEmitter } from "@angular/core";

@Injectable()
export class TokenService {
    isLogin: boolean;
    isLoginChange: EventEmitter<boolean> = new EventEmitter<boolean>();

    constructor() {
    }
}
