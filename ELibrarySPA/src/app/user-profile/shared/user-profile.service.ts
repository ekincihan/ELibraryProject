import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { RequestManagerService } from "../../service/RequestManager.service";

@Injectable()
export class UserProfileService extends RequestManagerService {
    constructor(http: HttpClient) {
        super(http);
       }
}
