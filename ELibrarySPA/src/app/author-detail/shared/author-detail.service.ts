import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { RequestManagerService } from "../../service/RequestManager.service";

@Injectable()
export class AuthorDetailService extends RequestManagerService {
    constructor(http: HttpClient) {
        console.log('AuthorDetailService yaratıldı');
        super(http);
       }
}
